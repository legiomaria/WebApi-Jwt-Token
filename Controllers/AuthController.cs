using Demo.Dtos.Auth;
using Demo.Identity;
using Demo.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")] 
    public class AuthController : ControllerBase
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly IUserService _userService;
        public AuthController(
            IJwtProvider jwtProvider,
            IUserService userService)
        {
            _jwtProvider = jwtProvider;
            _userService = userService;
        }

        [HttpPost]
        [Route("authenticate")]
        public ActionResult<string> Authenticate(
            [FromBody]AuthenticateRequest request)
        {
            var user = new User {
                Username = request.userName,
                Password = request.password
            };

            var result = _userService
            .IsCredentialsValid(user?.Username ?? string.Empty, 
                                user?.Password ?? string.Empty);
            if(!result)
            {
                return Unauthorized();
            }

            var authenticatedUser = 
            _userService.GetCredentials(user?.Username ?? string.Empty);

           return _jwtProvider.Generate(authenticatedUser);
        }
    }
} 