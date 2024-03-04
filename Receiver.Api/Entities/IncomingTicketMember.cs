using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Receiver.Api.Entities
{
    [Table("IncomingTicketMember")]
    public class IncomingTicketMember
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }
        
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(40)]
        public string FacitliyType { get; set; }
        
        public List<IncomingTicketMemberPhone> PhoneNumbers { get; set; }

        public IncomingTicketMember()
        {
            PhoneNumbers = new List<IncomingTicketMemberPhone>();
        }
    }
}
