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

    public class ColorsController : Controller
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService) ///startupa  bunu ekledik. services.AddSingleton<IColorService, ColorManager>();
        {
            _colorService = colorService;

        }

        [HttpGet("getall")]

        public IActionResult GetAll()  //burada GetAll yerine başka bişeyde yazabilirdik.
        {
            var result = _colorService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
            
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _colorService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("add")]

        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);

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

