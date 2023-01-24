﻿using Contract.Api.Entities;

namespace Contract.Api.Dto
{
    public class Contract
    {
        public Guid Id { get; set; }
        public EContractStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public uint ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
