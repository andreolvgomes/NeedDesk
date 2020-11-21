using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeedDesk.Application.DTO.User;
using NeedDesk.Application.Interfaces;
using NeedDesk.Domain.Models;

namespace NeedDesk.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginAppService _loginAppService;

        public LoginController(ILoginAppService loginAppService)
        {
            _loginAppService = loginAppService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route(ApiRoutes.Identity.LogIn)]
        public ActionResult Login([FromBody] LogIn login)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                User user = _loginAppService.FinByEmail(login.Use_email);
                if (user == null) return NotFound();

                var result = _loginAppService.SigIn(user);
                if (result != null)
                    return Ok(result);
                return NotFound();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}