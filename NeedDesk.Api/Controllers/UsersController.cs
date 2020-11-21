using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using NeedDesk.Application.DTO.User;
using NeedDesk.Application.Interfaces;

namespace NeedDesk.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        [Route(ApiRoutes.Users.GetAll)]
        public ActionResult GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(_userAppService.All());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route(ApiRoutes.Users.Get, Name = "GetWithId")]
        public ActionResult Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(_userAppService.Get(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route(ApiRoutes.Users.Create)]
        public ActionResult Create([FromBody] UserCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _userAppService.Create(user);
                if (result.Valid())
                    return Created(new Uri(Url.Link("GetWithId", new { id = result })), _userAppService.Get(result));

                return BadRequest(ModelState);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route(ApiRoutes.Users.Update)]
        public ActionResult Update([FromBody] UserUpdate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _userAppService.Update(user);
                return Ok(new { success = true });
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route(ApiRoutes.Users.Delete)]
        public ActionResult Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _userAppService.Remove(id);
                return Ok(new { success = true });
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}