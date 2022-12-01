using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Domain.Entity
{
    public  class Activity
    {
        [Key]
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTime DateActivity { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Balance { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Value { get; set; }
        [ForeignKey("Account")]
        public int IdAccount { get; set; }
    }
}
