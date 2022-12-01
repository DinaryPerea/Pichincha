using PTPichincha.Models.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Models.DTO
{
    public  class CustomerDto: PersonDto
    {
        public string Password { get; set; }
        public bool Status { get; set; }

    }
}
