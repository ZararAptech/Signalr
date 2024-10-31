using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRChat.Models
{
    public class user
    {
        public int MinAge = 0;
        [Key]
        public int userId { get; set; }
        [Required]
        //[StringLength(50)]
        public string username { get; set; }
        [Required]
        public int password {  get; set; }

        [Required]
        public DateTime DOB { get; set; }
        [StringLength(100)]
        public string ConnectionId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public string Role {  get; set; }


    }
}
