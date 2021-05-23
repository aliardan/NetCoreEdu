using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FileRepository
{
    [Table("texts", Schema = "public")]
    public class Text
    {
        /// <summary>
        /// For EntityFramework only
        /// </summary>
        [Obsolete("For EF only")]
        public Text()
        {
        }

        public Text(string content, string textName, Guid id)
        {
            Content = content;
            TextName = textName;
            Id = id;
        }

        [Key]
        [Column("id")]
        [Required]
        public Guid Id {get; set; }

        [Column("textname")]
        [Required]
        public string TextName {get; set; }

        [Column("content")]
        [Required]
        public string Content { get; set; }
    }
}
