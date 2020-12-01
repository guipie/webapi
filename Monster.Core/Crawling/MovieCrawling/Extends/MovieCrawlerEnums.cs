using Monster.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monster.Core.Utilities.HttpCrawler.MovieCrawer
{

    public enum SysMovieWebsite
    {
        [EnumRemark("209资源", "http://www.209zy.net/")]
        ZY209 = 2,  // 1对应数据库表里ID值
        [EnumRemark("酷云资源", "http://www.kuyunzy1.com/")]
        ZYkuyun = 1 // 2对应数据库表里ID值
    }
}
