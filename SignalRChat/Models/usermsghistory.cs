using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRChat.Models
{
    public class usermsghistory


    {
        [Key]
        public int id { get; set; }

        public int userId { get; set; }

        public string? msghistory { get; set; }

    }
}
