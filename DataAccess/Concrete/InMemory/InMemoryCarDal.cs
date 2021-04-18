using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        //tüm methodların dışında referans tip tanımladığımızda _ (alt çizgi) ile tanımlarız. Adı convention

        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=225, Description="Otomatik", ModelYear=2020 },
                new Car{CarId=2, BrandId=1, ColorId=3, DailyPrice=250, Description="Düz Vites", ModelYear=2019 },
                new Car{CarId=3, BrandId=2, ColorId=2, DailyPrice=330, Description="Otomatik", ModelYear=2021 },
                new Car{CarId=4, BrandId=3, ColorId=5, DailyPrice=410, Description="Otomatik", ModelYear=2020 },
                new Car{CarId=5, BrandId=3, ColorId=4, DailyPrice=270, Description="Düz Vites", ModelYear=2021 }
            };
        }

        public void Add(Car car)
        {

            _cars.Add(car);
            
        }

        public void Delete(Car car)
        {
            Car carToDelete;

            carToDelete = _cars.SingleOrDefault(c=> c.CarId==car.CarId);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrandId(int BrandId)
        {
            return _cars.Where(c=> c.BrandId==BrandId).ToList();
        }

        public List<Car> GetAllByColorId(int ColorId)
        {
            return _cars.Where(c=> c.ColorId==ColorId).ToList();
        }

        public List<CarDetailDTO> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate;

            carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
    }
}
