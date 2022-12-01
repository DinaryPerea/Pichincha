﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Models.DTO
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
