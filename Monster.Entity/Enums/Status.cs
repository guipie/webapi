using System;
using System.Collections.Generic;
using System.Text;

namespace Monster.Entity.Enums
{
    public enum Status
    {
        /// <summary>
        /// 待审核
        /// </summary>
        Pending = 0,
        /// <summary>
        /// 审核通过
        /// </summary>
        Audited = 1,
        /// <summary>
        /// 关闭
        /// </summary>
        Close = 2

    }
}
