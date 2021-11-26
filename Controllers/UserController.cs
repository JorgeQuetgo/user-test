using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using user_test.Repository;
using user_test.Models;

namespace user_test.Controllers
{
    [ApiController]
    [Route("")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository = null;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("api/users", Name = "userRoute"), HttpPost]
        public IActionResult AddNewClient([FromBody]UserModel userModel)
        {            
            if (ModelState.IsValid)
            {
                var result = _userRepository.AddNewUser(userModel);
                return Ok(result);
            }
            var errorList = ModelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            ); 
            return BadRequest(errorList);
            //return BadRequest(JsonConvert.SerializeObject(ModelState.Values.Select(e => e.Errors).ToList()));
        }

        
        [Route("api/users", Name="userRoute-list"), HttpGet]
        public Task<List<UserModel>> getUsers()
        {
            return _userRepository.GetUsers();
        }
        
    }
}
