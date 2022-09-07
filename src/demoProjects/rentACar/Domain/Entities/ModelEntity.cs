using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ModelEntity:Entity
    {
        public int BrandId { get; set; }        
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }
        public virtual BrandEntity? Brand { get; set; }

        public ModelEntity()
        {
        }

        public ModelEntity(int id, int brandId, string name, decimal dailyPrice, string imageUrl) : this()
        {
            Id = id;
            BrandId = brandId;
            Name = name;
            DailyPrice = dailyPrice;
            ImageUrl = imageUrl;
        }
    }
}
