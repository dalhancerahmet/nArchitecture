﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BrandModels.Dtos
{
    public class BrandModelListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}
