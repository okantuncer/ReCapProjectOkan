using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDTO:IDto
    {
        public int CarId { get; set; }

        public string Description { get; set; }

        public float DailyPrice { get; set; }

        public int ColorId { get; set; }

        public string ColorName { get; set; }

        public int BrandId { get; set; }

        public string BrandName { get; set; }

    }
}
