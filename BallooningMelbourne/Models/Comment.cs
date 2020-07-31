namespace BallooningMelbourne.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int Id { get; set; }

        [Required]
        
            
        [Display(Name = "Please Review your experience")]
        public string Comments { get; set; }


        [Display(Name = "Event")]
        public int EventId { get; set; }
    }
}
