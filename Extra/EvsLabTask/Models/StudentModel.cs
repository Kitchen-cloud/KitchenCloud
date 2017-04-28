﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvsLabTask.Models
{
    public class StudentModel
    {

       
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string Email { get; set; }


    }
}