using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CarsController : Controller
    {
        ICarService _carService;

        public CarsController(ICarService carService) ///startupa  bunu ekledik. services.AddSingleton<ICarService, CarManager>();
        {
            _carService = carService;

        }

        [HttpGet("getall")]

        public IActionResult GetAll()  //burada GetAll yerine başka bişeyde yazabilirdik.
        {
            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
            
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("add")]

        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("colorid")]
        public IActionResult GetAllByColorId(int id)
        {
            var result = _carService.GetAllByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }



    }


        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }

