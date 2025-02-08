using ERP.POS.Domain.Common;

namespace ERP.POS.Domain.Entities
{
    public class Material : BaseEntity
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
    }
}