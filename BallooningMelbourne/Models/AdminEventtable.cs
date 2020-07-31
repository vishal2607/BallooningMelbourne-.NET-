namespace BallooningMelbourne.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminEventtable")]
    public partial class AdminEventtable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdminEventtable()
        {
            bookings = new HashSet<booking>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Please Enter Event ID")]
        [Display(Name = "Event ID")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Please Enter Event Name")]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Please Enter Event Address")]
        [Display(Name = "Event Address")]
        public string EventAddress { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Event Capacity")]
        public int? EventCapacity { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Journey")]
        public DateTime? Doj { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Enter price between 0 to 1000")]
        public int? Price { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }


        [Range(0, 24, ErrorMessage = "Enter price between 0 to 24")]
        public int? Duration { get; set; }

        public string Description { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<booking> bookings { get; set; }
    }
}
