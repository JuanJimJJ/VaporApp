using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaporApp.Application.Requests;
using VaporApp.Domain.Interfaces;
using VaporApp.Domain.Entities;

namespace VaporApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetUsers());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] GetUsersByIdRequest request)
        {
            return Ok(_repository.GetUsersById(request.Id));
        }

        [HttpPost]
        public IActionResult Post(CreateUsersRequest request)
        {
            var users = _mapper.Map<Users>(request);
            _repository.InsertUsers(users);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UpdateUsersRequest request)
        {
            var users = _mapper.Map<Users>(request);
            _repository.UpdateUsers(users);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] DeleteUsersRequest request)
        {
            _repository.DeleteUsers(request.Id);
            return Ok();
        }
    }
}
