﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EasyNutrition.API.Resources
{
    public class SaveSessionResource
    {

        public int Id { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string Link { get; set; }
    }
}
