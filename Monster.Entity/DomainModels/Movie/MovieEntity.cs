/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果数据库字段发生变化，请在代码生器重新生成此Model
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monster.Entity.SystemModels;

namespace Monster.Entity.DomainModels
{
    [Entity(TableCnName = "影视", TableName = "Movie")]
    [Table("movie")]
    public class MovieEntity : BaseEntity
    {
        /// <summary>
        ///
        /// </summary>
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "int")]
        [Required(AllowEmptyStrings = false)]
        public int Id { get; set; }

        [Display(Name = "WebsiteId")]
        [Column(TypeName = "int")]
        [Required(AllowEmptyStrings = false)]
        public int WebsiteId { get; set; }

        /// <summary>
        ///影视名称
        /// </summary>
        [Display(Name = "Name")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }


        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string NewestSet { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string ImgUrl { get; set; }

        /// <summary>
        ///影视其他名称-别名
        /// </summary>
        [Display(Name = "AnotherName")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string AnotherName { get; set; }

        /// <summary>
        ///清晰度/最新集等
        /// </summary>
        [Display(Name = "清晰度")]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string Sharpness { get; set; }


        /// <summary>
        ///导演
        /// </summary>
        [Display(Name = "导演")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string Director { get; set; }

        /// <summary>
        ///演员，主演
        /// </summary>
        [Display(Name = "Actor")]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string Actor { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "TypeId")]
        [Column(TypeName = "int")]
        public int? TypeId { get; set; }

        /// <summary>
        /// 类型 剧情片、爱情片
        /// </summary>
        [Column(TypeName = "nvarchar(10)")]
        public string TypeName { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Region")]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string Region { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Language")]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string Language { get; set; }

        /// <summary>
        ///上映发布时间
        /// </summary>
        [Display(Name = "上映发布时间")]
        [Column(TypeName = "datetime")]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// 源更新时间
        /// </summary>
        [Display(Name = "源更新时间")]
        [Column(TypeName = "datetime")]
        public DateTime? ObtainTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Keyword")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string Keyword { get; set; }


        /// <summary>
        ///
        /// </summary>
        [Display(Name = "描述内容")]
        [Column(TypeName = "longtext")]
        public string Content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "PlayUrls")]
        [Column(TypeName = "longtext"), Required(AllowEmptyStrings = false)]
        public string PlayUrls { get; set; }

        /// <summary>
        /// 播放类型 影视播放类型(33uuck,33uu,mp4等)
        /// </summary>
        [Display(Name = "PlayTypes")]
        [Column(TypeName = "nvarchar(200)"), Required(AllowEmptyStrings = false)]

        public string PlayTypes { get; set; }

        [Display(Name = "SourceUrl")]
        [Column(TypeName = "nvarchar(200)"), Required(AllowEmptyStrings = false)]
        public string SourceUrl { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Creator")]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string Creator { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "ModifyDate")]
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }


    }
}