using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaporApp.Application.Requests.ProductCategories;
using VaporApp.Domain.Entities;
using VaporApp.Domain.Interfaces;

namespace VaporApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoriesRepository _repository;
        private readonly IMapper _mapper;

        public ProductCategoriesController(IProductCategoriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetProductCategories());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] GetProductCategoriesByIdRequest request)
        {
            return Ok(_repository.GetProductCategoriesById(request.Id));
        }

        [HttpPost]
        public IActionResult Post(CreateProductCategoriesRequest request)
        {
            var productCategories = _mapper.Map<ProductCategories>(request);
            _repository.InsertProductCategories(productCategories);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UpdateProductCategoriesRequest request)
        {
            var productCategories = _mapper.Map<ProductCategories>(request);
            _repository.UpdateProductCategories(productCategories);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] DeleteProductCategoriesRequest request)
        {
            _repository.DeleteProductCategories(request.Id);
            return Ok();
        }
    }
}
