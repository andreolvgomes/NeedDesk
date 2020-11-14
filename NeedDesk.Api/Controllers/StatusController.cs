using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeedDesk.Application.DTO.Status;
using NeedDesk.Application.Interfaces;

namespace NeedDesk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusAppService _statusAppService;

        public StatusController(IStatusAppService statusAppService)
        {
            _statusAppService = statusAppService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(_statusAppService.All());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithSta_id")]
        public ActionResult Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(_statusAppService.Get(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] StatusCreate statusCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _statusAppService.Create(statusCreate);
                if (result.Valid())
                    return Created(new Uri(Url.Link("GetWithSta_id", new { id = result })), _statusAppService.Get(result));

                return BadRequest(ModelState);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] StatusUpdate statusUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _statusAppService.Update(statusUpdate);
                return Ok(new { success = true });
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _statusAppService.Remove(id);
                return Ok(new { success = true });
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("status")]
        public ActionResult Status([FromBody] StatusStatus statusStatus)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                bool success = _statusAppService.Status(statusStatus);
                if (success == false)
                    return NotFound();
                return Ok(new { success = true });
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}