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
    [Entity(TableCnName = "影视资源网站", TableName = "movie_website")]
    [Table("movie_website")]
    public class MovieWebsite : BaseEntity
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
        [Display(Name = "Title")]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        [Required(AllowEmptyStrings = false), Editable(true)]
        public string Title { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Url")]
        [MaxLength(100), Editable(true)]
        [Column(TypeName = "nvarchar(100)")]
        public string Url { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Remark")]
        [MaxLength(200), Editable(true)]
        [Column(TypeName = "nvarchar(200)")]
        public string Remark { get; set; }


        /// <summary>
        ///最后更新的源日期
        /// </summary>
        [Display(Name = "最后更新的源日期")]
        [Column(TypeName = "datetime")]
        public DateTime? LastObtainTime { get; set; }
        /// <summary>
        ///
        /// </summary>
        [Display(Name = "ModifyDate")]
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "ModifyID")]
        [Column(TypeName = "int")]
        public int? ModifyID { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Modifier")]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string Modifier { get; set; }


    }
}