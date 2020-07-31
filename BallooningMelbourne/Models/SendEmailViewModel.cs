using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BallooningMelbourne.Models
{
    public class SendEmailViewModel
    {
        [Display(Name = "Email address")]

        public string ToEmail { get; set; }

        [Required(ErrorMessage = "Please enter a subject.")]
        public string Subject { get; set; }

        [Display(Name = "Choose File")]
        public HttpPostedFileBase Upload { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please enter the contents")]

        public string Contents { get; set; }

    }
}