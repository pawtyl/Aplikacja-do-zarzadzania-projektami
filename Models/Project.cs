using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet.Models
{
    public class Project
    {

        [Key]
        public int ProjectId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime DueDate { get; set; }
    }
}
