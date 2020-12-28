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
    [Entity(TableCnName = "评论", TableName = "News_comment")]
    [Table("News_comment")]
    public class NewsComment : BaseEntity
    {
        /// <summary>
        ///
        /// </summary>
        [Key]
        [Column(TypeName = "int")]
        [Required(AllowEmptyStrings = false)]
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "回复的ID")]
        [Editable(true)]
        [Column(TypeName = "int")]
        public int ParentId { get; set; }


        [Editable(true)]
        [Column(TypeName = "int")]
        public int RelationId { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Coments")]
        [MaxLength(500)]
        [Editable(true)]
        [Column(TypeName = "nvarchar(500)")]
        [Required(AllowEmptyStrings = false)]
        public string Coments { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Praise")]
        [Column(TypeName = "int")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public int Praise { get; set; }

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
        ///
        /// </summary>
        [Display(Name = "Type")]
        [MaxLength(8)]
        [Editable(true)]
        [Column(TypeName = "nvarchar(8)")]
        [Required(AllowEmptyStrings = false)]
        public string Type { get; set; }

        #region 扩展映射
        [NotMapped]
        public int ReCount { get; set; }
        #endregion
    }
}