using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {

        IDataResult<List<Car>> GetAll();

        IDataResult<List<Car>> GetAllByColorId(int id);

        IDataResult<List<Car>> GetByUnitPrice(int min, int max);

        IDataResult<List<CarDetailDTO>> GetCarDetails();

        IDataResult<Car> GetById(int carId);

        IResult Add(Car car);

        IResult Update(Car car);

        IResult Delete(Car car);



    }
}
