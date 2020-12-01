/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下MovieService与IMovieService中编写
 */
using Microsoft.Extensions.Logging;
using Monster.Business.IRepositories;
using Monster.Business.IServices;
using Monster.Business.Repositories;
using Monster.Core.BaseProvider;
using Monster.Core.Crawling.MovieCrawling; 
using Monster.Core.Extensions;
using Monster.Core.Extensions.AutofacManager;
using Monster.Core.Services;
using Monster.Entity.DomainModels;
using System;
using System.Linq;

namespace Monster.Business.Services
{
    public partial class MovieService : ServiceBase<MovieEntity, IMovieRepository>, IMovieService, IDependency
    {
        public MovieService(IMovieRepository repository)
             : base(repository)
        {
            Init(repository);
        }
        public static IMovieService Instance
        {
            get { return AutofacContainerModule.GetService<IMovieService>(); }
        }

    }
}
