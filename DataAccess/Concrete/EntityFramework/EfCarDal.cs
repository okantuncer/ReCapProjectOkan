using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (CarRentalContext context=new CarRentalContext())
            {
                var result = from c in context.Cars
                             join o in context.Colors
                             on c.ColorId equals o.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDTO
                             {
                                 CarId = c.CarId,
                                 Description = c.Description,
                                 ColorName = o.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 BrandName = b.BrandName


                             };

                return result.ToList();

            }
        }
    }
}
