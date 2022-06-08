using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaporApp.Application.Requests;
using VaporApp.Domain.Interfaces;
using VaporApp.Domain.Entities;
using VaporApp.Application.Requests.Products;

namespace VaporApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetProducts());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] GetProductsByIdRequest request)
        {
            return Ok(_repository.GetProductsById(request.Id));
        }

        [HttpPost]
        public IActionResult Post(CreateProductsRequest request)
        {
            var products = _mapper.Map<Products>(request);
            _repository.InsertProducts(products);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UpdateProductsRequest request)
        {
            var products = _mapper.Map<Products>(request);
            _repository.UpdateProducts(products);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] DeleteProductsRequest request)
        {
            _repository.DeleteProducts(request.Id);
            return Ok();
        }
    }
}
