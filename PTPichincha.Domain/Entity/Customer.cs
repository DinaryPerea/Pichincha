using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Domain.Entity
{
    public  class Customer: Person
    {
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
