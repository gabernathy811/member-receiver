using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Receiver.Api.Entities
{
    [Table("IncomingTicketMemberPhone")]
    public class IncomingTicketMemberPhone
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        public string Type { get; set; }

        [MaxLength(20)]
        public string Number { get; set; }

        [MaxLength(20)]
        public string Extension { get; set; }
    }
}
