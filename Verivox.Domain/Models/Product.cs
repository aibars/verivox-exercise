using System;
using System.ComponentModel.DataAnnotations;

namespace Verivox.Domain.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public string TariffName { get; set; }
    }
}