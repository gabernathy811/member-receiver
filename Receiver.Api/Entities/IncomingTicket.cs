using Receiver.Api.Serialize;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Receiver.Api.Entities
{
    [Table("IncomingTicket")]
    public class IncomingTicket
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(20)]
        public string OneCallCenter { get; set; } 

        [Required]
        [MaxLength(24)]
        public string TicketNumber { get; set; } 
        
        [Required]
        [MaxLength(150)]
        public string LocateRequestFor { get; set; } 

        [Required]
        public int SequenceNumber { get; set; } 

        [MaxLength(24)]
        public string PreviousTicketNumber { get; set; } 

        [Required]
        [MaxLength(60)]
        public string TicketType { get; set; }  

        [Required]
        [MaxLength(30)]
        public string TicketSource { get; set; } 

        [MaxLength(75)]
        public string LastResponseCode { get; set; }

        [MaxLength(300)]
        public string LastResponseDescription { get; set; }

        [MaxLength(1000)]
        public string LastResponseComment { get; set; }

        [MaxLength(150)]
        public string CallerName { get; set; }

        [MaxLength(20)]
        public string CallerPhoneNumber { get; set; }

        [MaxLength(20)]
        public string CallerPhoneExtension { get; set; }

        [MaxLength(255)]
        public string CallerEmailAddress { get; set; }

        public DateTime? CommenceOn { get; set; }

        public DateTime? CompletedBy { get; set; }

        [MaxLength(150)]
        public string ContactName { get; set; }

        [MaxLength(20)]
        public string ContactPhoneNumber { get; set; }

        [MaxLength(20)]
        public string ContactPhoneExtension { get; set; }

        [MaxLength(255)]
        public string ContactEmailAddress { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [MaxLength(255)]
        public string CrossStreet { get; set; }

        // nvarchar(max)
        public string DigsiteWKT { get; set; }

        public bool DirectionalBoring { get; set; }

        [MaxLength(50)]
        public string DoneFor { get; set; }

        [MaxLength(255)]
        public string Duration { get; set; }

        [MaxLength(255)]
        public string ExcavatorName { get; set; }

        [MaxLength(20)]
        public string ExcavatorPhoneNumber { get; set; }

        [MaxLength(255)]
        public string ExcavatorType { get; set; }

        [MaxLength(255)]
        public string ExcavatorAddress { get; set; }

        [MaxLength(255)]
        public string ExcavatorCity { get; set; }

        [MaxLength(2)]
        public string ExcavatorState { get; set; }

        [MaxLength(5)]
        public string ExcavatorZIPCode { get; set; }

        public DateTime? ExpiresOn { get; set; }
                
        public bool Explosives { get; set; }

        public DateTime? LegalOn { get; set; }

        // nvarchar(max)
        public string LocateInstructions { get; set; }

        public DateTime? MeetingDate { get; set; }

        [MaxLength(255)]
        public string MeetingLocation { get; set; }
        
        // nvarchar(max)
        public string Remarks { get; set; }

        public DateTime? RespondBy { get; set; }

        public DateTime? RespondBy2 { get; set; }

        public DateTime? RespondBy3 { get; set; }

        [MaxLength(255)]
        public string ScopeOfWork { get; set; }

        // nvarchar(max)
        public string TicketText { get; set; }

        [Required]
        public DateTime TransmittedOn { get; set; }

        public DateTime? UpdateBy { get; set; }

        public DateTime? UpdateableOn { get; set; }
                
        public bool WhitePaint { get; set; }

        [Required]
        public int WhitePaintCount { get; set; }

        [Required]
        [MaxLength(75)]
        public string WorkCity { get; set; }


        public string WorkCounty { get; set; }
        
        [Required]
        [MaxLength(2)]
        public string WorkState { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string WorkStreetName { get; set; }
                
        [MaxLength(20)]
        public string WorkStreetNumber { get; set; }
                
        [MaxLength(10)]
        public string WorkStreetPrefix { get; set; }
                
        [MaxLength(10)]
        public string WorkStreetSuffix { get; set; }
        
        [MaxLength(30)]
        public string WorkStreetType { get; set; }
        
        [MaxLength(255)]
        public string WorkType { get; set; }

        [MaxLength(50)]
        public string FacilityTypeDamaged { get; set; }

        [MaxLength(255)]
        public string TypeOfLine { get; set; }

        [MaxLength(50)]
        public string DamageExtent { get; set; }

        
        public bool ServiceIsOut { get; set; }

        [MaxLength(50)]
        public string EquipmentTypeUsed { get; set; }


        public bool IsCrewOnSite { get; set; }

        public DateTime? DamagedOnDate { get; set; }


        public List<IncomingTicketMember> Members { get; set; }

        public IncomingTicket()
        {
            Members = new List<IncomingTicketMember>();
        }

        // Copies a deserialized XML object from the post
        // into an entity ready to be inserted into the database
        public void CopyFromXml(XmlTicket ticket)
        {
            TicketNumber = ticket.TicketNumber;
            TicketSource = ticket.TicketSource;
            TicketType = ticket.TicketType;
            SequenceNumber = ticket.SequenceNumber;
            PreviousTicketNumber = ticket.PreviousTicketNumber;
            OneCallCenter = ticket.OneCallCenter;
            LocateRequestFor = ticket.LocateRequestFor;

            LastResponseCode = ticket.LastResponse.Code;
            LastResponseDescription = ticket.LastResponse.Description;
            LastResponseComment = ticket.LastResponse.Comment;

            CreatedOn = ticket.Dates.CreatedOn;
            RespondBy = DateFromString(ticket.Dates.RespondBy);
            LegalOn = DateFromString(ticket.Dates.LegalOn);
            UpdateableOn = DateFromString(ticket.Dates.UpdateableOn);
            UpdateBy = DateFromString(ticket.Dates.UpdateBy);
            ExpiresOn = DateFromString(ticket.Dates.ExpiresOn);
            CommenceOn = DateFromString(ticket.Dates.CommenceOn);
            CompletedBy = DateFromString(ticket.Dates.CompletedBy);
            MeetingDate = DateFromString(ticket.Dates.MeetingDate);
            TransmittedOn = ticket.Dates.TransmittedOn;

            ExcavatorName = ticket.Excavator.Name;
            ExcavatorType = ticket.Excavator.Type;
            ExcavatorPhoneNumber = ticket.Excavator.PhoneNumber;
            ExcavatorAddress = ticket.Excavator.Address;
            ExcavatorCity = ticket.Excavator.City;
            ExcavatorState = ticket.Excavator.State;
            ExcavatorZIPCode = ticket.Excavator.ZIPCode;

            CallerName = ticket.Caller.Name;
            CallerPhoneNumber = ticket.Caller.Phone;
            CallerPhoneExtension = ticket.Caller.PhoneExtension;
            CallerEmailAddress = ticket.Caller.Email;

            ContactName = ticket.FieldContact.Name;
            ContactPhoneNumber = ticket.FieldContact.Phone;
            ContactPhoneExtension = ticket.FieldContact.PhoneExtension;
            ContactEmailAddress = ticket.FieldContact.Email;

            WorkType = ticket.Work.WorkType;
            DoneFor = ticket.Work.DoneFor;
            Explosives = BoolFromString(ticket.Work.Explosives);
            DirectionalBoring = BoolFromString(ticket.Work.DirectionalBoring);
            WhitePaint = BoolFromString(ticket.Work.WhitePaint);
            WhitePaintCount = ticket.Work.WhitePaintCount;
            Duration = ticket.Work.Duration;
            ScopeOfWork = ticket.Work.ScopeOfWork;
            WorkStreetNumber = ticket.Work.Address.Street.Number;
            WorkStreetPrefix = ticket.Work.Address.Street.Prefix;
            WorkStreetName = ticket.Work.Address.Street.Name;
            WorkStreetType = ticket.Work.Address.Street.Type;
            WorkStreetSuffix = ticket.Work.Address.Street.Suffix;
            WorkState = ticket.Work.Address.State;
            WorkCounty = ticket.Work.Address.County;
            WorkCity = ticket.Work.Address.City;
            CrossStreet = ticket.Work.CrossStreet;
            DigsiteWKT = ticket.Work.DigsiteWKT;
            LocateInstructions = ticket.Work.LocateInstructions;
            Remarks = ticket.Work.Remarks;
            MeetingLocation = ticket.MeetingLocation;

            FacilityTypeDamaged = ticket.Damage.FacilityTypeDamaged;
            TypeOfLine = ticket.Damage.TypeOfLine;
            DamageExtent = ticket.Damage.DamageExtent;
            ServiceIsOut = BoolFromString(ticket.Damage.ServiceIsOut);
            EquipmentTypeUsed = ticket.Damage.EquipmentTypeUsed;
            IsCrewOnSite = BoolFromString(ticket.Damage.IsCrewOnSite);
            DamagedOnDate = DateFromString(ticket.Damage.DamagedOnDate);

            TicketText = ticket.TicketText;

            foreach (XmlMember xm in ticket.Members)
            {
                IncomingTicketMember m = new IncomingTicketMember
                {
                    Code = xm.Code,
                    Name = xm.Name,
                    FacitliyType = xm.FacilityType
                };
                foreach (XmlPhoneNumber xp in xm.PhoneNumbers)
                {
                    IncomingTicketMemberPhone mp = new IncomingTicketMemberPhone
                    {
                        Type = xp.Type,
                        Number = xp.Number,
                        Extension = xp.Extension,
                    };
                    m.PhoneNumbers.Add(mp);
                }

                Members.Add(m);
            }
        }
        
        // Nullable dates are handled as strings, as null values are empty strings
        private DateTime? DateFromString(string date)
        {
            DateTime d;
            DateTime.TryParse(date, out d);

            // DateTime.MinValue may used to indicate a blank value
            if (d == DateTime.MinValue)
            {
                return null;
            }
            else
            {
                return d;
            }
        }

        private bool BoolFromString(string b)
        {
            if (String.IsNullOrWhiteSpace(b))
            {
                // default to false
                return false;
            }
            else if (b.ToLower().Contains("yes"))
            {
                // this is true
                return true;
            }
            else
            {
                // any other text is false
                return false;
            }
        }

    }
}
