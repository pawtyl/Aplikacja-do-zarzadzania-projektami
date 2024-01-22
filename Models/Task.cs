using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [ForeignKey("ProjectID")]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime DueDate { get; set; }
    }
}
