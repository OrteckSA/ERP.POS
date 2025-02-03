﻿namespace ERP.POS.Domain.Common.Interfaces
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
