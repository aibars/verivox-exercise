using System;

namespace Verivox.Domain.ApiModels.Response
{
    public class ConsumptionModel
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public DateTime ReadDate { get; set; }
    }
}
