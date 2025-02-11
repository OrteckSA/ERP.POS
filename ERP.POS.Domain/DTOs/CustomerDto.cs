namespace ERP.POS.Domain.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; } = null!;
        public string LatinName { get; set; } = default!;
        public float DiscRatio { get; set; }
        public decimal MaximumSales { get; set; }
        public Guid ReferenceId { get; set; }

        #region Navigation Properties
        public List<CustomerBranchDto> CustomerBranches { get; set; } = new();
        #endregion
    }
}
