using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeedDesk.Application.DTO.Classificacao;
using NeedDesk.Application.Interfaces;

namespace NeedDesk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificacaoController : ControllerBase
    {
        private readonly IClassificacaoAppService _classificacaoAppService;

        public ClassificacaoController(IClassificacaoAppService classificacaoAppService)
        {
            _classificacaoAppService = classificacaoAppService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(_classificacaoAppService.All());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithCla_id")]
        public ActionResult Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _classificacaoAppService.Get(id);
                if (result == null) return BadRequest();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] ClassificacaoCreate classificacaoCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _classificacaoAppService.Create(classificacaoCreate);
                if (result.Valid())
                    return Created(new Uri(Url.Link("GetWithCat_id", new { id = result })), _classificacaoAppService.Get(result));

                return BadRequest(ModelState);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ClassificacaoUpdate classificacaoUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (_classificacaoAppService.Get(classificacaoUpdate.Cla_id) == null) return BadRequest();
                _classificacaoAppService.Update(classificacaoUpdate);
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
                if (_classificacaoAppService.Get(id) == null) return BadRequest();
                _classificacaoAppService.Remove(id);
                return Ok(new { success = true });
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("status")]
        public ActionResult Status([FromBody] ClassificacaoStatus classificacaoStatus)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (_classificacaoAppService.Get(classificacaoStatus.Cla_id) == null) return BadRequest();

                bool success = _classificacaoAppService.Status(classificacaoStatus);
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