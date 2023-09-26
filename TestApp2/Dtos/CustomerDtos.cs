using System;
using System.ComponentModel.DataAnnotations;
using TestApp2.Models;

namespace TestApp2.Dtos
{
    public class CustomerDtos
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Min18YearIfAMember]
        public DateTime BirthDay { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }


        public byte MembershipTypeId { get; set; }
    }
}