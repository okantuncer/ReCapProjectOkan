using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]


    public class CarImagesController : Controller
    {

        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }


        [HttpPost("add")]

        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        //// GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
