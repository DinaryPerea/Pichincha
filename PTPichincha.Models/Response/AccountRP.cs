using PTPichincha.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Models.Response
{
    public class AccountRP: AccountDto
    {
        public string Error { get; set; }
        public bool Status { get; set; }

        public AccountDto data { get; set; }
    }
}
