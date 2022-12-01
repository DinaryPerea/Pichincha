using PTPichincha.Models.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Models.DTO
{
    public class AccountDto
    {
   
        public string AccountNumber { get; set; }
      
        public string Type { get; set; }
        public decimal InitialBalance { get; set; }
        public bool Status { get; set; }
        public int Idusuario { get; set; }
    }
}
