using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Models.DTO
{
    public class ReportDto
    {
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string  AccountNumber { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public string Activity { get; set; }
        public int Balance { get; set; }
    }
}
