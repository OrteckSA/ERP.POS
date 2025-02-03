namespace ERP.POS.Domain.Common
{
    // I think it would be better to implement all the security columns in the BaseEntity class
    // like CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, IsActive, IsDeleted, etc.
    public class BaseEntity : Entity<Guid>
    {
        public override bool Equals(object? entity)
        {
            if (entity == null || !(entity is BaseEntity baseEntity))
                return false;
            if (baseEntity.Id == Guid.Empty)
                return GetBaseHashCode() == baseEntity.GetBaseHashCode();
            return Id == baseEntity.Id;
        }

        private int GetBaseHashCode()
        {
            return base.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
