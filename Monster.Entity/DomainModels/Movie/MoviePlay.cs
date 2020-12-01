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
    [Entity(TableCnName = "播放配置", TableName = "Movie_play")]
    [Table("Movie_play")]
    public class MoviePlay : BaseEntity
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
        ///播放类型
        /// </summary>
        [Display(Name = "播放类型")]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        [Required(AllowEmptyStrings = false), Editable(true)]
        public string Name { get; set; }

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
        [Display(Name = "CreateID")]
        [Column(TypeName = "int")]
        public int? CreateID { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Creator")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string Creator { get; set; }

        /// <summary>
        ///播放地址
        /// </summary>
        [Display(Name = "播放地址")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)"), Editable(true)]
        public string PlayUrl { get; set; }


        [Column(TypeName = "int")]
        [Required(AllowEmptyStrings = false), Editable(true)]
        public int Sequence { get; set; }




    }
}