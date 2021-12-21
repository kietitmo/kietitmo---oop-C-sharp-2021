using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportApp.DAL.Entities
{
    public class CommentEntity
    {
        public CommentEntity() { }
        public CommentEntity(string content)
        {
            Id = Guid.NewGuid();
            ContentOfComment = content;      
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string ContentOfComment { get; set; }
    }
}
