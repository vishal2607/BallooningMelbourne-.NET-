namespace BallooningMelbourne.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("booking")]
    public partial class booking
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]

        
        public int BOOKINGID { get; set; }


        [Range(1, 10, ErrorMessage = "Can book for minimum 1 passenger  and maximum of 10 passengers")]
        [Display(Name = "No of passengers")]
        public int PASSENGERCOUNT { get; set; }

        [Display(Name = "Phone Number")]
        public int PhoneNo { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [Display(Name = "Event Name")]
        public int EventId { get; set; }

        
        [Display(Name = "Rating")]
      
        public int? Rating { get; set; }

        public virtual AdminEventtable AdminEventtable { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
