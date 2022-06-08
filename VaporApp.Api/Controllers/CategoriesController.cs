using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaporApp.Application.Requests;
using VaporApp.Domain.Interfaces;
using VaporApp.Domain.Entities;
using VaporApp.Application.Requests.Categories;

namespace VaporApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _repository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetCategories());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] GetCategoriesByIdRequest request)
        {
            return Ok(_repository.GetCategoriesById(request.Id));
        }

        [HttpPost]
        public IActionResult Post(CreateCategoriesRequest request)
        {
            var categories = _mapper.Map<Categories>(request);
            _repository.InsertCategories(categories);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UpdateCategoriesRequest request)
        {
            var categories = _mapper.Map<Categories>(request);
            _repository.UpdateCategories(categories);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] DeleteCategoriesRequest request)
        {
            _repository.DeleteCategories(request.Id);
            return Ok();
        }
    }
}
