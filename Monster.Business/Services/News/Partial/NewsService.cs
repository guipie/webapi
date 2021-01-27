/*
 *所有关于News类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*NewsService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;
using System.Linq;
using Monster.Core.Utilities;
using System.Linq.Expressions;
using Monster.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using Dapper;
using Monster.Business.IServices;
using Monster.Core.Enums;

namespace Monster.Business.Services
{
    public partial class NewsService
    {
        /// <summary>
        /// 网站列表
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public object GetList(PageDataOptions options)
        {
            var result = base.GetPageData(options);
            var data = from news in result.rows
                       join users in repository.DbContext.Set<Sys_User>()
                       on news.CreateID equals users.User_Id
                       select new
                       {
                           news.NewsId,
                           news.CoverImageUrls,
                           news.Type,
                           news.Title,
                           news.Tags,
                           news.Summary,
                           news.VideoUrl,
                           news.VoiceUrl,
                           news.CreateDate,
                           users.UserTrueName,
                           users.HeadImageUrl,
                           PraiseCount = newsPraiseRepository.FindAsIQueryable(m => m.NewsId == news.NewsId).Count(),
                           CommentCount = newsCommentRepository.FindAsIQueryable(m => m.RelationId == news.NewsId).Count()
                       };

            return new { data, result.total, size = options.Rows };
        }
        public object GetDetail(int Id)
        {
            var news = base.GetOne(Id);
            if (news == null) return WebResponseContent.Instance.OK(ResponseType.NotFound);
            var user = repository.DbContext.Set<Sys_User>().Where(m => m.User_Id == news.CreateID).FirstOrDefault();
            var result = new
            {
                news.NewsId,
                news.CoverImageUrls,
                news.Type,
                news.Title,
                news.Summary,
                news.Content,
                news.VideoUrl,
                news.VoiceUrl,
                news.CreateDate,
                user.UserTrueName,
                user.HeadImageUrl
            };
            return result;
        }
        public WebResponseContent Like(int key)
        {
            if (userFollowRepository.Exists(m => m.FollowId == key && m.FollowType == Entity.Enums.FollowTypeEnum.news))
                return WebResponseContent.Instance.Error("已经收藏了");
            else
            {
                var addModel = new Sys_user_follow() { FollowId = key, FollowType = Entity.Enums.FollowTypeEnum.news }.SetCreateDefaultVal();
                userFollowRepository.Add(addModel, true);
                return WebResponseContent.Instance.Info(addModel.Id > 0,"已收藏");
            }
        }
        public WebResponseContent Praise(int key)
        {
            if (newsPraiseRepository.Exists(m => m.NewsId == key))
                return WebResponseContent.Instance.Error("已经赞啦");
            else
            {
                var addModel = new NewsPraise() { NewsId = key }.SetCreateDefaultVal();
                newsPraiseRepository.Add(addModel, true);
                return WebResponseContent.Instance.Info(addModel.Id > 0);
            }
        }
    }
}
