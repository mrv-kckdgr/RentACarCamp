using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BrandEntity : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<ModelEntity> Models { get; set; }

        public BrandEntity()
        {
        }

        public BrandEntity(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
