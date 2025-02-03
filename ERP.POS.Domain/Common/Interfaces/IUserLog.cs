namespace ERP.POS.Domain.Common.Interfaces
{
    public interface IUserLog : ICreatedAt, IUpdatedAt
    {
        Guid CreatedBy { get; set; }
        Guid UpdatedBy { get; set; }
    }
}
