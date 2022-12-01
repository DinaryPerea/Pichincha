using PTPichincha.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Models.DTO
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime DateActivity { get; set; }
        public decimal Balance { get; set; }
        public decimal Value { get; set; }
        public int IdAccount { get; set; }

    }
}
