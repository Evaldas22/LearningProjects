using System;
using System.ComponentModel.DataAnnotations;
using Vidbit.Models;

namespace Vidbit.Dtos
{
    public class CustomerDto
    {
        // DTO is data transfer object and it should completely separate from domain object
        // MemebershipType cannot be in here since it's a domain class and in DTO only built-in values can exist, like int, bool, byte ...
        // and also MembershipType creates a depedency. DTO becomes dependent on domain model
        // if we want MembershipType, we should create it's separate class MembershipTypeDto

        public int Id { get; set; }

        [Required]
        [StringLength(255)] 
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        
        public byte MembershipTypeId { get; set; }
        
        //[Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
    }
}