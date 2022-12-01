using PTPichincha.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Models.Response
{
    public class CustomerRP 
    {
        public bool Status { get; set; }
        public string  Error { get; set; }
        public CustomerDto data { get; set; }

    }
}
