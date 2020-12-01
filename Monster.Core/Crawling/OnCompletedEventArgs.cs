using System;


namespace Monster.Core.Utilities
{
    /// <summary>
    /// 爬虫完成事件
    /// </summary>
    public class OnCompletedEventArgs
    {
        public Uri Uri { get; private set; }// 爬虫URL地址
        public int ThreadId { get; private set; }// 任务线程ID
        public string PageSource { get; private set; }// 页面源代码
        public long Milliseconds { get; private set; }// 爬虫请求执行时间
        public OnCompletedEventArgs(Uri uri, int threadId, long milliseconds, string pageSource)
        {
            Uri = uri;
            ThreadId = threadId;
            Milliseconds = milliseconds;
            PageSource = pageSource;
        }
    }
}
