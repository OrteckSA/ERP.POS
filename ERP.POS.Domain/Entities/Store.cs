using ERP.POS.Domain.Common;

namespace ERP.POS.Domain.Entities
{
    public class Store : BaseEntity
    {
        public string Name { get; set; } = null!;
    }
}