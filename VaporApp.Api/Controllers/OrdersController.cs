using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaporApp.Application.Requests.Orders;
using VaporApp.Domain.Entities;
using VaporApp.Domain.Interfaces;

namespace VaporApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _repository;
        private readonly IMapper _mapper;

        public OrdersController(IOrdersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetOrders());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] GetOrdersByIdRequest request)
        {
            return Ok(_repository.GetOrdersById(request.Id));
        }

        [HttpPost]
        public IActionResult Post(CreateOrdersRequest request)
        {
            var orders = _mapper.Map<Orders>(request);
            _repository.InsertOrders(orders);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UpdateOrdersRequest request)
        {
            var orders = _mapper.Map<Orders>(request);
            _repository.UpdateOrders(orders);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] DeleteOrdersRequest request)
        {
            _repository.DeleteOrders(request.Id);
            return Ok();
        }
    }
}
