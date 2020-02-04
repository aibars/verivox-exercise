using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Verivox.Domain.Models
{
    [Table("Consumptions")]
    public class Consumption
    {
        [Key]
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public DateTime ReadDate { get; set; }
    }
}