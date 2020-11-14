using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeedDesk.Application.DTO.Departamento;
using NeedDesk.Application.DTO.Status;
using NeedDesk.Application.Interfaces;

namespace NeedDesk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoAppService _departamentoAppService;

        public DepartamentosController(IDepartamentoAppService departamentoAppService)
        {
            _departamentoAppService = departamentoAppService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(_departamentoAppService.All());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithDep_id")]
        public ActionResult Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(_departamentoAppService.Get(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] DepartamentoCreate departamentoCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _departamentoAppService.Create(departamentoCreate);
                if (result.Valid())
                    return Created(new Uri(Url.Link("GetWithDep_id", new { id = result })), _departamentoAppService.Get(result));

                return BadRequest(ModelState);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] DepartamentoUpdate departamentoUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _departamentoAppService.Update(departamentoUpdate);
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
                _departamentoAppService.Remove(id);
                return Ok(new { success = true });
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("status")]
        public ActionResult Status([FromBody] DepartamentoStatus departamentoStatus)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                bool success = _departamentoAppService.Status(departamentoStatus);
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