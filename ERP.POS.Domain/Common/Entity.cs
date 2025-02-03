using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ERP.POS.Domain.Common.Interfaces;

namespace ERP.POS.Domain.Common
{
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }

        public override string ToString()
        {
            return $"[{GetType().Name} {Id}]";
        }
    }
}
