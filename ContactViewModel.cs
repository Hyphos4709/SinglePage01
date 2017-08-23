﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSV01.UI.MVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "* Required")]
        public string Message { get; set; }

    }
}