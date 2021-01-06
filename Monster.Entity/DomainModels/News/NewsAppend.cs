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
    [Entity(TableCnName = "跟帖",TableName = "News_append")]
[Table("News_append")]
    public class NewsAppend:BaseEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="Id")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int Id { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Content")]
       [Column(TypeName="nvarchar(max)")]
       [Required(AllowEmptyStrings=false)]
       public string Content { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="PraiseCount")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int PraiseCount { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="CreateDate")]
       [Column(TypeName="datetime")]
       [Required(AllowEmptyStrings=false)]
       public DateTime CreateDate { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="CreateID")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int CreateID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Creator")]
       [MaxLength(30)]
       [Column(TypeName="nvarchar(30)")]
       [Required(AllowEmptyStrings=false)]
       public string Creator { get; set; }

       
    }
}