using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BrandModel : Entity
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }

        public virtual Brand? Brand { get; set; }

        public BrandModel()
        {

        }
        public BrandModel(int id, int brandId, string name, decimal dailyPrice, string imageUrl):this()
        {
            Id = id;
            Name = name;
            DailyPrice = dailyPrice;
            ImageUrl = imageUrl;
            BrandId = brandId;
        }
    }
}
