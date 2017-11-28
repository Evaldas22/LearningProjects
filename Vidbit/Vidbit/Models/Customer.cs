using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidbit.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Plese enter customer's name.")] // Name wont be nullable
        [StringLength(255)] // Name max length 255
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //this is called navigation property
        public MembershipType MembershipType{ get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        // MemebershipTypeId is implicitly required because it is of type 'byte'.
        // If it was byte?, then it wouldn't be required

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
        // custom validation won't work in client-side validation if no additional JQuery code is writtens
    }
}