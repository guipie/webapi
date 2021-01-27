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
        private readonly INewsPraiseRepository newsPraiseRepository;
        private readonly IUserFollowRepository userFollowRepository;
        private readonly INewsCommentRepository newsCommentRepository;
        public NewsService(INewsRepository repository, INewsPraiseRepository repository1, IUserFollowRepository repository2, INewsCommentRepository repository3)
             : base(repository)
        {
            newsPraiseRepository = repository1;
            userFollowRepository = repository2;
            newsCommentRepository = repository3;
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
            AddOnExecuted = (News news, object list) =>
            {
                if (news.Tags.IsNullOrEmpty())
                    return responseContent.OK();
                string[] tags = news.Tags?.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (tags.Length > 5)
                    return responseContent.Error("标签不能超过5个");
                if (tags.Length > 0)
                {
                    for (int i = 0; i < tags.Length; i++)
                    {
                        var tagModel = repository.DbContext.Set<NewsTag>().Where(m => m.Tag == tags[i]).FirstOrDefault();
                        if (tagModel == null)
                        {
                            tagModel = new NewsTag() { Tag = tags[i], UseCount = 1 };
                            tagModel.SetCreateDefaultVal();
                            repository.DbContext.Set<NewsTag>().Add(tagModel);
                        }
                        else
                        {
                            tagModel.UseCount += 1;
                            repository.DbContext.Set<NewsTag>().Update(tagModel);
                        }
                    }
                    if (repository.DbContext.SaveChanges() > 0)
                        return responseContent.OK("创建成功.");
                }
                news.SetModifyDefaultVal();
                return responseContent.OK();
            };
            return base.Add(saveModel).OK("已提交，正在审核中..");
        }
    }
}
