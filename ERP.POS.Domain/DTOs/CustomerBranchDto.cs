﻿namespace ERP.POS.Domain.DTOs
{
    public class CustomerBranchDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Name { get; set; } = null!;
    }
}
