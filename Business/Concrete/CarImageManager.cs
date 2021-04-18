using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }



        public IResult Add(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Add(file);
            carImage.AddedDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();


        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
