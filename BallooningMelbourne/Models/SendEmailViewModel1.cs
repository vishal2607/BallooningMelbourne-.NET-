using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BallooningMelbourne.Models
{
    public class SendEmailViewModel1
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ToEmail1{ get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ToEmail2{ get; set; }

        [Required(ErrorMessage = "Please enter a subject.")]
        public string Subject { get; set; }

        [Display(Name = "Choose File")]
        public HttpPostedFileBase Upload { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please enter the contents")]

        public string Contents { get; set; }

    }
}