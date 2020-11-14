using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeedDesk.Application.DTO.Prioridade;
using NeedDesk.Application.Interfaces;

namespace NeedDesk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadesController : ControllerBase
    {
        private readonly IPrioridadeAppService _prioridadeAppService;

        public PrioridadesController(IPrioridadeAppService prioridadeAppService)
        {
            _prioridadeAppService = prioridadeAppService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(_prioridadeAppService.All());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithPri_id")]
        public ActionResult Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(_prioridadeAppService.Get(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] PrioridadeCreate prioridadeCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _prioridadeAppService.Create(prioridadeCreate);
                if (result.Valid())
                    return Created(new Uri(Url.Link("GetWithCat_id", new { id = result })), _prioridadeAppService.Get(result));

                return BadRequest(ModelState);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] PrioridadeUpdate prioridadeUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _prioridadeAppService.Update(prioridadeUpdate);
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
                _prioridadeAppService.Remove(id);
                return Ok(new { success = true });
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("status")]
        public ActionResult Status([FromBody] PrioridadeStatus prioridadeStatus)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                bool success = _prioridadeAppService.Status(prioridadeStatus);
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