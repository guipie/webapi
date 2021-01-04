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
                           news.Summary,
                           news.VideoUrl,
                           news.VoiceUrl,
                           news.CreateDate,
                           users.UserTrueName,
                           users.HeadImageUrl
                       };
            return new { data, result.total };
        }
        public object GetDetail(int Id)
        {
            var news = base.GetOne(Id);
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

    }
}
