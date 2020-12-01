/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下MovieTypeService与IMovieTypeService中编写
 */
using Monster.Business.IRepositories;
using Monster.Business.IServices;
using Monster.Core.BaseProvider;
using Monster.Core.Enums;
using Monster.Core.Extensions;
using Monster.Core.Extensions.AutofacManager;
using Monster.Core.Utilities;
using Monster.Core.Utilities.Crawler.MovieCrawer;
using Monster.Core.Utilities.HttpCrawler.MovieCrawer;
using Monster.Entity.DomainDto;
using Monster.Entity.DomainModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monster.Business.Services
{
    public partial class MovieTypeService : ServiceBase<MovieType, IMovieTypeRepository>, IMovieTypeService, IDependency
    {
        public MovieTypeService(IMovieTypeRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMovieTypeService Instance
        {
           get { return AutofacContainerModule.GetService<IMovieTypeService>(); }
        }


        public async Task<IList<MovieWebsiteTypeRelation>> GetTypesRelationAsync(SysMovieWebsite website)
        {
            List<string> types = await MovieCrawlerCore.Instance(website).GetMovieTypes();
            if (types.Count == 0) types = await MovieCrawlerCore.Instance(website).GetMovieTypes();
            if (types.Count == 0) throw new BusinessException($"未抓取到{website.GetRemark()}类别");
            int siteId = website.GetEnumValue<SysMovieWebsite>();
            string querySql = "SELECT a.Id,TypeId,a.Name SiteTypeName,b.Name TypeName from movie_website_type a left JOIN movie_type b on a.TypeId=b.Id where a.SiteId=@SiteId";
            var typeRelation = repository.DapperContext.QueryList<MovieWebsiteTypeRelation>(querySql, new { SiteId = siteId }).ToList();
            var list = from t1 in types
                       join t2 in typeRelation on t1 equals t2.SiteTypeName into temp
                       from tt in temp.DefaultIfEmpty()
                       select new MovieWebsiteTypeRelation
                       {
                           Id = tt == null ? 0 : tt.Id,
                           TypeId = tt == null ? 0 : tt.TypeId,
                           TypeName = tt == null ? "" : tt.TypeName,
                           SiteTypeName = t1,
                           SiteId = siteId
                       };
            return list.ToList();
        }

        public WebResponseContent MovieWebsiteTypePost(MovieWebsiteType type)
        {

            WebResponseContent Response = type.ValidationEntity();
            if (!Response.Status) return Response;
            if (type.Id > 0)
                repository.DbContext.Set<MovieWebsiteType>().Update(type);
            else
                repository.DbContext.Set<MovieWebsiteType>().Add(type);
            if (repository.DbContext.SaveChanges() > 0)
                return Response.OK(ResponseType.SaveSuccess);
            return Response.Error("绑定失败.");
        }

    }
}
