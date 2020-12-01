/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下NewsService与INewsService中编写
 */
using Monster.Business.IRepositories;
using Monster.Business.IServices;
using Monster.Core.BaseProvider;
using Monster.Core.Extensions;
using Monster.Core.Extensions.AutofacManager;
using Monster.Core.Utilities;
using Monster.Entity.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monster.Business.Services
{
    public partial class NewsService : ServiceBase<News, INewsRepository>, INewsService, IDependency
    {
        public NewsService(INewsRepository repository)
             : base(repository)
        {
            Init(repository);
        }
        public static INewsService Instance
        {
            get { return AutofacContainerModule.GetService<INewsService>(); }
        }

        /// <summary>
        /// 添加资讯
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override WebResponseContent Add(SaveModel saveModel)
        {

            WebResponseContent responseContent = WebResponseContent.Instance;
            AddOnExecuting = (News news, object list) =>
            {
                if (!(list is List<NewsTypeMapping> newsTypes) || newsTypes.Count == 0)
                    return responseContent.Error("类别必填");
                if (newsTypes.Count > 5)
                    return responseContent.Error("类别不能超过五个");
                return responseContent.OK();
            };
            AddOnExecuted = (News news, object list) =>
            {
                string[] tags = saveModel.Extra.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (tags.Length > 5)
                    return responseContent.Error("标签不能超过5个");
                if (tags.Length == 0)
                    return responseContent.OK("创建成功.");
                List<NewsTagMapping> tag_Mappings = new List<NewsTagMapping>();
                for (int i = 0; i < tags.Length; i++)
                {
                    var tagModel = repository.DbContext.Set<NewsTag>().Where(m => m.Tag == tags[i]).FirstOrDefault();
                    if (tagModel == null)
                    {
                        tagModel = new NewsTag() { Tag = tags[i] };
                        tagModel.SetCreateDefaultVal();
                        repository.DbContext.Set<NewsTag>().Add(tagModel);
                        repository.DbContext.SaveChanges();
                    }
                    tag_Mappings.Add(new NewsTagMapping() { TagId = tagModel.Id, NewsId = news.NewsId });
                }
                repository.DbContext.Set<NewsTagMapping>().AddRange(tag_Mappings);
                if (repository.DbContext.SaveChanges() > 0)
                    return responseContent.OK("创建成功.");
                else
                    return responseContent.Error("创建失败.");
            };
            return base.Add(saveModel);
        }

        public override WebResponseContent Update(SaveModel saveModel)
        {
            WebResponseContent responseContent = new WebResponseContent();
            UpdateOnExecute = (SaveModel saveModel) =>
            {
                List<object> currentDelKeys = new List<object>();
                int NewsId = saveModel.MainData.GetValue("NewsId").ToInt();
                saveModel.DelKeys = repository.DbContext.Set<NewsTypeMapping>().Where(m => m.NewsId == NewsId).Select(m => (object)m.Id).ToList();

                string[] tags = saveModel.Extra.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (tags.Length > 5)
                    return responseContent.Error("标签不能超过5个");
                if (tags.Length == 0)
                    return responseContent.OK("创建成功.");
                List<NewsTagMapping> tag_Mappings = new List<NewsTagMapping>();
                var delKeys = repository.DbContext.Set<NewsTagMapping>().Where(m => m.NewsId == NewsId).Select(m => (object)m.Id).ToArray();
                repository.DapperContext.DelWithKey<NewsTagMapping>(delKeys);
                for (int i = 0; i < tags.Length; i++)
                {
                    var tagModel = repository.DbContext.Set<NewsTag>().Where(m => m.Tag == tags[i]).FirstOrDefault();
                    if (tagModel == null)
                    {
                        tagModel = new NewsTag() { Tag = tags[i] };
                        tagModel.SetCreateDefaultVal();
                        repository.DbContext.Set<NewsTag>().Add(tagModel);
                        repository.DbContext.SaveChanges();
                    }
                    tag_Mappings.Add(new NewsTagMapping() { TagId = tagModel.Id, NewsId = NewsId });
                }
                repository.DbContext.Set<NewsTagMapping>().AddRange(tag_Mappings);
                repository.DbContext.SaveChanges();
                return responseContent.OK();
            };
            return base.Update(saveModel);
        }

        public object GetHandleOne(int key)
        {
            News news = base.GetOne(key);
            var typeIds = repository.DbContext.Set<NewsTypeMapping>().Where(m => m.NewsId == news.NewsId).Select(m => m.TypeId).ToArray();
            var tagIds = repository.DbContext.Set<NewsTagMapping>().Where(m => m.NewsId == news.NewsId).Select(m => m.TagId).ToArray();
            return new
            {
                news.NewsId,
                news.Title,
                news.Summary,
                news.Content,
                news.IsRecommend,
                news.CoverImageUrls,
                seletedCovers = news.CoverImageUrls?.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(m => new { path = m }),
                NewsTypes = typeIds,
                Tags = tagIds.Length > 0 ? repository.DbContext.Set<NewsTag>().Where(m => tagIds.Contains(m.Id)).Select(m => m.Tag).ToArray() : new string[0]
            };
        }
    }
}
