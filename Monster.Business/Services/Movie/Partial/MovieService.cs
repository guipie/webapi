/*
 *所有关于Movie类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*MovieService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using Monster.Entity.DomainModels;
using System.Linq;
using Monster.Business.Repositories;
using System;
using Monster.Core.Services;
using System.Collections.Generic;

namespace Monster.Business.Services
{
    public partial class MovieService
    {
        public object GetMovies(PageDataOptions options)
        {
            var result = base.GetPageData(options);
            return new
            {
                data = result.rows.Select(m => new { m.Id, m.Name, m.ImgUrl, m.NewestSet }).ToList(),
                result.total,
                nextPage = options.Page * options.Rows < result.total ? options.Page + 1 : -1
            };
        }

        public object GetPlayOne(int id)
        {
            var model = base.GetOne(id);
            var sourcePlay = MoviePlayRepository.Instance.Find(m => true).OrderBy(m => m.Sequence).ToArray();
            var modelPlay = model.PlayTypes.Split("$$$", StringSplitOptions.RemoveEmptyEntries);
            var modelPlayUrls = model.PlayUrls.Split("$$$", StringSplitOptions.RemoveEmptyEntries);
            if (modelPlay.Length != modelPlayUrls.Length) Logger.Error(Core.Enums.LoggerType.Crawling, $"[{model.Name + model.SourceUrl}]播放地址不匹配");
            List<(string, string[])> keyValuePairs = new List<(string, string[])>();
            for (int i = 0; i < modelPlay.Length; i++)
                keyValuePairs.Add((modelPlay[i], modelPlayUrls[i].Split("<br>", StringSplitOptions.RemoveEmptyEntries)));
            var sortList = from a in keyValuePairs
                           join c in sourcePlay on a.Item1 equals c.Name
                           orderby c.Sequence ascending
                           select new { Type = a.Item1, Urls = a.Item2, PlayPage = c.PlayUrl };
            return new { model.Name, model.ImgUrl, model.Director, model.Actor, model.Content, PlayList = sortList };
        }
    }
}
