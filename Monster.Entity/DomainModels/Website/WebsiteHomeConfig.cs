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
using Monster.Entity.Enums;
using Monster.Entity.SystemModels;

namespace Monster.Entity.DomainModels
{
    [Entity(TableCnName = "首页轮播配置", TableName = "Website_home_config")]
    [Table("Website_home_config")]
    public class WebsiteHomeConfig : BaseEntity
    {
        /// <summary>
        ///
        /// </summary>
        [Key]
        [Display(Name = "Id")]
        [Column(TypeName = "int")]
        [Required(AllowEmptyStrings = false)]
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "MappingType")]
        [Column(TypeName = "int"), Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public WebsiteHomeConfigType MappingType { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "MappingId")]
        [Column(TypeName = "int"), Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public int MappingId { get; set; }

        /// <summary>
        ///轮播图
        /// </summary>
        [Display(Name = "推荐图")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)"), Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string BannerImg { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "CreateID")]
        [Column(TypeName = "int")]
        [Required(AllowEmptyStrings = false)]
        public int CreateID { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Creator")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Required(AllowEmptyStrings = false)]
        public string Creator { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "CreateDate")]
        [Column(TypeName = "datetime")]
        [Required(AllowEmptyStrings = false)]
        public DateTime CreateDate { get; set; }

        /// <summary>
        ///简介文案
        /// </summary>
        [Display(Name = "简介文案")]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)"), Editable(true)]
        public string Description { get; set; }

        /// <summary>
        ///标题
        /// </summary>
        [Display(Name = "标题")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)"), Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }


    }
}