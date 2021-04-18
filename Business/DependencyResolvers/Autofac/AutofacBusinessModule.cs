using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module // statup da yazdıklarımızın yerine bunu kurduk.
    {

        protected override void Load(ContainerBuilder builder)  //uygulama ayağa kaltığında burası çalışacak.
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance(); //birisi senden ICarservice isterse CarManager vereceksin. 100.000 kullanıcı bile olsa bir tane instance üretir.
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance(); 
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();



            //attributelara bakıyor...
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }

    }
}

//WebAPI içinde Program.CS'ye Autofac ekledik. Böylece Autofac ile projemizi bağladık.