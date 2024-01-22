using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }
    }
}
