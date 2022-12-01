using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Domain.Entity
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? AccountNumber { get; set; }
        [Required]
        public string? Type { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal InitialBalance { get; set; }
        public bool Status { get; set; }
        [ForeignKey("Customer")]
        public int IdPerson { get; set; }

    }
}
