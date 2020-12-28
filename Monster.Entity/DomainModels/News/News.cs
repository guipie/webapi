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
using Monster.Entity.SystemModels;

namespace Monster.Entity.DomainModels
{
    [Table("News")]
    [Entity(TableCnName = "资讯管理", TableName = "News", DetailTable = new Type[] { typeof(NewsTypeMapping) }, DetailTableCnName = "资讯类别")]
    public class News : BaseEntity
    {
        /// <summary>
        ///
        /// </summary>
        [Key]
        [Display(Name = "新闻ID")]
        [Column(TypeName = "int")]
        [Required(AllowEmptyStrings = false)]
        public int NewsId { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Modifier")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string Modifier { get; set; }


        /// <summary>
        ///状态
        /// </summary>
        [Display(Name = "状态")]
        [Column(TypeName = "int"), DefaultValue(1)]
        public int? Status { get; set; }


        [Display(Name = "类别")]
        [Column(TypeName = "nvarchar(10)"), DefaultValue("article"), Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string Type { get; set; }
        /// <summary>
        ///是否推荐
        /// </summary>
        [Display(Name = "是否推荐")]
        [Column(TypeName = "tinyint"), DefaultValue(false)]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public bool IsRecommend { get; set; }

        /// <summary>
        ///创建人
        /// </summary>
        [Display(Name = "创建人")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string Creator { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "ModifyDate")]
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "CreateID")]
        [Column(TypeName = "int")]
        public int? CreateID { get; set; }


        /// <summary>
        ///浏览次数
        /// </summary>
        [Display(Name = "浏览次数")]
        [Column(TypeName = "int"), DefaultValue(1)]
        public int? ViewCount { get; set; }

        /// <summary>
        ///内容
        /// </summary>
        [Display(Name = "内容")]
        [Editable(true)]
        public string Content { get; set; }

        /// <summary>
        ///简介
        /// </summary>
        [Display(Name = "简介")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string Summary { get; set; }

        /// <summary>
        ///封面地址
        /// </summary>
        [Display(Name = "封面地址")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        [Editable(true)]
        public string CoverImageUrls { get; set; }


        [Display(Name = "视频地址")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string VideoUrl { get; set; }

        /// <summary>
        ///标题
        /// </summary>
        [Display(Name = "标题")]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public string Title { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "ModifyID")]
        [Column(TypeName = "int")]
        public int? ModifyID { get; set; }

        [Display(Name = "资讯类别")]
        [ForeignKey("NewsId")]
        public List<NewsTypeMapping> NewsTypeMapping { get; set; }

        [NotMapped]
        public string[] SeletedCovers { get; set; }
        [NotMapped]
        public int[] NewsTypes { get; set; }
        [NotMapped]
        public string[] Tags { get; set; }

    }
}