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
    [Entity(TableCnName = "影视类别",TableName = "movie_type")]
[Table("movie_type")]
    public class MovieType:BaseEntity
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
       [Display(Name ="Pid")]
       [Column(TypeName="int"), Editable(true)]
       public int Pid { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Name")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Required(AllowEmptyStrings=false),Editable(true)]
       
       public string Name { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Code")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)"), Editable(true)]
       public string Code { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Sequence")]
       [Column(TypeName="short"), Editable(true)]
       public short? Sequence { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Description")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)"), Editable(true)]
       public string Description { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="IsHidden")]
       [Column(TypeName="short")]
       public short? IsHidden { get; set; }

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
       public int? CreateID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Creator")]
       [MaxLength(30)]
       [Column(TypeName="nvarchar(30)")]
       public string Creator { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Modifier")]
       [MaxLength(30)]
       [Column(TypeName="nvarchar(30)")]
       public string Modifier { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ModifyDate")]
       [Column(TypeName="datetime")]
       public DateTime? ModifyDate { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="ModifyID")]
       [Column(TypeName="int")]
       public int? ModifyID { get; set; }

       
    }
}