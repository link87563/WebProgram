using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebProgramApi.Interface;
using WebProgramApi.Service;

namespace WebProgramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route(""), HttpGet]
        public ActionResult GetUsers()
        {
            return Ok();
        }

        // GET api/user/12
        [Route("{id}"), HttpGet]
        public ActionResult GetUser(string id)
        {
            var result = _userService.GetUser(id);
            return Ok(result);
        }
    }
}