using System.Collections.Generic;
using AutoMapper;
using UMS.Data;
using UMS.Dtos;
using UMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace UMS.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUmsRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(IUmsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetUsers([FromQuery] int faculty, [FromQuery] int department, [FromQuery] int role, [FromQuery] string text)
        {
            if (faculty > 0 && department > 0 && role > 0 && !string.IsNullOrWhiteSpace(text))
            {
                var userItems = _repository.GetUsers(faculty, text);
                if (userItems != null)
                {
                    return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
                }
                return NotFound();
            }
            else if (faculty > 0 && department > 0 && role > 0)
            {
                var userItems = _repository.GetUsers(faculty, department, role);
                if (userItems != null)
                {
                    return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
                }
                return NotFound();
            }
            else if (faculty > 0 && department > 0 && !string.IsNullOrWhiteSpace(text))
            {
                var userItems = _repository.GetUsers(faculty, text);
                if (userItems != null)
                {
                    return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
                }
                return NotFound();
            }
            else if (faculty > 0 && department > 0)
            {
                var userItems = _repository.GetUsers(faculty, department);
                if (userItems != null)
                {
                    return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
                }
                return NotFound();
            }
            else if (faculty > 0 && !string.IsNullOrWhiteSpace(text))
            {
                var userItems = _repository.GetUsers(faculty, text);
                if (userItems != null)
                {
                    return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
                }
                return NotFound();
            }
            else if (faculty > 0)
            {
                var userItems = _repository.GetUsers(faculty);
                if (userItems != null)
                {
                    return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
                }
                return NotFound();
            }
            else
            {
                // Handle the case when neither faculty nor department is provided
                return BadRequest("Both faculty and department parameters are required.");
            }
        }

    }

}