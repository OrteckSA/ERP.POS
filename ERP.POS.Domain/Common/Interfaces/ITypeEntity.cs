namespace ERP.POS.Domain.Common.Interfaces
{
    public interface ITypeEntity<T>
    {
        T TypeId { get; set; }
    }
}
