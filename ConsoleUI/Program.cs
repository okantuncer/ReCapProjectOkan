using System;
using Business.Concrete;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //CategoryTest();


            CarManager carManager = new CarManager(new EfCarDal());


                    var result = carManager.GetCarDetails();

                    if (result.Success == true)
                    {
                        foreach (var car in result.Data)
                        {
                            Console.WriteLine(car.Description + "/" +car.DailyPrice);                        
                        }
                        Console.WriteLine(result.Message);
                    }

                    else
                        Console.WriteLine(result.Message);


            //foreach (var cars in carManager.GetCarDetails().Data)
            //{
            //    Console.WriteLine(cars.Description + "-----" + cars.BrandName + "-----" + cars.ColorName + "-----" + cars.DailyPrice);

            //}


        //    foreach (var car in carManager.GetAll().Data)
        //    {
        //        Console.WriteLine(car.Description);
        //
        //    }
            


            //Car odev = new Car();
            //odev.CarId = 5;
            //odev.ColorId = 2;
            //odev.ModelYear = 1996;
            //odev.Description = "Odev Ekleme";
            //odev.DailyPrice = 199;
            //odev.BrandId = 1;
            //EfEntityRepositoryBase<Car, CarRentalContext> efEntityRepositoryBase = new EfEntityRepositoryBase<Car, CarRentalContext>();
            //efEntityRepositoryBase.Add(odev);



            //Car odev2 = new Car() { CarId = 7, ColorId = 2, BrandId = 1, DailyPrice = 99, Description = "Gizemin Arabası", ModelYear = 2011 };
            //carManager.Add(odev2);

            //carManager.Update(odev2);


            //Car odev3 = new Car() { CarId = 5, };
            //carManager.Delete(odev3);




        }

        private static void CategoryTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var cars in carManager.GetAll().Data)
            {
                Console.WriteLine(cars.ModelYear);

            }


            foreach (var cars in carManager.GetByUnitPrice(190, 300).Data)
            {
                Console.WriteLine(cars.Description);

            }
        }
    }
}
