using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.CategoryDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult CategoryList()
        {
            var values=_context.Categories.ToList();
            return Ok(values);
        }

        [HttpGet("GetById")]
        public IActionResult GetCategory(int id)
        {
            var value = _context.Categories.Find(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto ) {
            //_context.Categories.Add(category);
            //_context.SaveChanges();
            var value = _mapper.Map<Category>(createCategoryDto);
            _context.Categories.Add(value);
            _context.SaveChanges();
            return Ok("Kategori ekleme işlemi başarılı");
        }

        //[HttpDelete]
        //public IActionResult DeleteCategory(int? id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest("Id boş ola bilməz");
        //    }

        //    var category = _context.Categories
        //        .FirstOrDefault(c => c.CategoryId == id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Categories.Remove(category);
        //    _context.SaveChanges();

        //    return Ok(category);
        //}
        [HttpDelete]
        public IActionResult DeleteCategory(int id) {
            var value=_context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Kategori silme işlemi başarılı");
        }


        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto) {
            var value = _mapper.Map<Category>(updateCategoryDto);
            _context.Categories.Update(value);
            _context.SaveChanges();
            return Ok("Kategori güncelleme işlemi başarılı");
        }


    }
}
