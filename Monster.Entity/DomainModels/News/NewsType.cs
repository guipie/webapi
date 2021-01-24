/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果数据库字段发生变化，请在代码生器重新生成此Model
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monster.Entity.Enums;
using Monster.Entity.SystemModels;

namespace Monster.Entity.DomainModels
{
    [Entity(TableCnName = "资讯类别", TableName = "news_type")]
    [Table("news_type")]
    public class NewsType : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "int")]
        [Required(AllowEmptyStrings = false)]
        public int Id { get; set; }


        [Display(Name = "论坛名称")]
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)"), Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Display(Name = "论坛描述")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)"), Editable(true)]
        public string Description { get; set; }

        [Column(TypeName = "mediumtext"), Editable(true)]
        public string BgImg { get; set; }


        [Display(Name = "排序自动")]
        [Column(TypeName = "int"), Editable(true), DefaultValue(1)]
        [Required(AllowEmptyStrings = false)]
        public int Sequence { get; set; }


        [Display(Name = "被关注数量")]
        [Column(TypeName = "int"), DefaultValue(1)]
        public int FollowCount { get; set; }

        [Display(Name = "状态")]
        [Column(TypeName = "int"), Editable(true), DefaultValue(1)]
        public Status Status { get; set; }

        /// <summary>
        ///创建人Id
        /// </summary>
        [Display(Name = "创建人Id")]
        [Column(TypeName = "int")]
        [Required(AllowEmptyStrings = false)]
        public int CreateID { get; set; }

        /// <summary>
        ///创建人
        /// </summary>
        [Display(Name = "创建人")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Required(AllowEmptyStrings = false)]
        public string Creator { get; set; }

        /// <summary>
        ///申请时间
        /// </summary>
        [Display(Name = "申请时间")]
        [Column(TypeName = "datetime")]
        [Required(AllowEmptyStrings = false)]
        public DateTime CreateDate { get; set; }

        /// <summary>
        ///修改人ID
        /// </summary>
        [Display(Name = "修改人ID")]
        [Column(TypeName = "int")]
        public int? ModifyID { get; set; }

        /// <summary>
        ///修改人
        /// </summary>
        [Display(Name = "修改人")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string Modifier { get; set; }

        /// <summary>
        ///修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }


    }
}