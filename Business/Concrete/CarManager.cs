using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using static Core.Aspects.Autofac.Validation.EmptyClass;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        //void özel birşey döndürmüyor demek..
        [ValidationAspect(typeof(CarValidator))]  // Add kodunu doğrula. CarValidator kullanarak.

        public IResult Add(Car car)
        {

            //if (car.Description.Length < 2)
            //{
            //    return new ErrorResult(Messages.CarNameInvalid);
            //}

            //validation ekleme k için üstteki satırları comment yaptık.

            //validation bağlama
            //ValidationTool.Validate(new CarValidator(), car); //yukarıya validation aspects eklediğimiz için buna gerek kalmadı.
            //validation bitiş


            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);

        }



        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();  ////////////////////////////////
        }

        public IDataResult<List<Car>> GetAll()
        {
            // İş kodları buraya yazılacak...
            //Yetkisi var mı? bu soruları geçip alttaki fonksiyon çalışıyor.

            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
                
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == carId));
        }

        public IDataResult<List<Car>> GetByUnitPrice(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarDetailDTO>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails(),Messages.CarListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult();
        }
    }
}
