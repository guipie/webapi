/*
 *所有关于NewsType类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*NewsTypeService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using Monster.Core.BaseProvider;
using Monster.Core.Extensions.AutofacManager;
using Monster.Entity.DomainModels;
using System.Linq;
using Monster.Core.Utilities;
using System.Linq.Expressions;
using Monster.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Threading.Tasks;

namespace Monster.Business.Services
{
    public partial class NewsTypeService
    {
        public object GetRecommendList()
        {
            return from recommend in websiteHomeConfigRepository.Find(m => m.MappingType == Entity.Enums.WebsiteHomeConfigType.BBS)
                   join list in repository.Find(m => m.Status == Entity.Enums.Status.Audited) on recommend.MappingId equals list.Id
                   select new
                   {
                       list.Id,
                       list.Name,
                       recommend.Title,
                       Description = recommend.Description ?? list.Description,
                       BgImg = recommend.BannerImg ?? list.BgImg
                   };
        }
        public NewsType GetOneByName(string name)
        {
            return repository.FindFirst(m => m.Name == name);
        }
        public WebResponseContent FollowBbs(int bbsId)
        {
            bool isExist = userFollowRepository.Exists(m => m.FollowType == Entity.Enums.FollowTypeEnum.bbs && m.FollowId == bbsId);
            if (isExist)
                return WebResponseContent.Instance.Error("您已经关注了.");
            else
            {
                var currentBbs = GetOne(bbsId);
                repository.Update(new NewsType() { Id = bbsId, FollowCount = currentBbs.FollowCount + 1 }, (m) => m.FollowCount, true);
                var addModel = new Sys_user_follow() { FollowId = bbsId, FollowType = Entity.Enums.FollowTypeEnum.bbs };
                userFollowRepository.Add(addModel.SetCreateDefaultVal(), true);

                return WebResponseContent.Instance.Info(addModel.Id > 0);
            }
        }

        public bool FollowExist(int bbsId)
        {
            bool isExist = userFollowRepository.Exists(m => m.FollowType == Entity.Enums.FollowTypeEnum.bbs && m.FollowId == bbsId);
            return isExist;
        }
    }
}
