namespace ERP.POS.Service.IServices
{
    public interface IBaseService
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}