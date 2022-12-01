using PTPichincha.Models.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Models.Response
{
    public  class ActivityRP
    {
        public bool Status { get; set; }
        public string Error { get; set; }
        public ActivityDto data { get; set; }
    }
}
