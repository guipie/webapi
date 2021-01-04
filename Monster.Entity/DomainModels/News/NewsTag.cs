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
    [Entity(TableCnName = "资讯标签", TableName = "News_tag")]
    [Table("News_tag")]
    public class NewsTag : BaseEntity
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
        ///标签
        /// </summary>
        [Display(Name = "标签")]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        [Required(AllowEmptyStrings = false)]
        [Editable(true)] 
        public string Tag { get; set; }

        [Display(Name = "使用次数")] 
        [Column(TypeName = "int")]
        [Required(AllowEmptyStrings = false)]
        [Editable(true)]
        public int UseCount { get; set; }
        
        /// <summary>
        ///创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "CreateID")]
        [Column(TypeName = "int")]
        public int? CreateID { get; set; }

        /// <summary>
        ///创建人
        /// </summary>
        [Display(Name = "创建人")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string Creator { get; set; }


    }
}