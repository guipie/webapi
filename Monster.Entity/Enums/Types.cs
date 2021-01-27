using System;
using System.Collections.Generic;
using System.Text;

namespace Monster.Entity.Enums
{
    public enum NewsTypeEnum
    {
        micro = 1,
        pic = 2,
        video = 3,
        voice = 4,
        article = 5
    }
    public enum FollowTypeEnum
    {
        /// <summary>
        /// 关注的用户
        /// </summary>
        user = 1,
        /// <summary>
        /// 关注的论坛
        /// </summary>
        bbs = 2,
        /// <summary>
        /// 喜欢的帖子
        /// </summary>
        news = 3
    }
}
