using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeedDesk.Application.DTO.Categoria;
using NeedDesk.Application.Interfaces;

namespace NeedDesk.Api.Controllers
{
    //[Route("api/[controller]")]
    //[Authorize("Bearer")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriasController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        [HttpGet]
        [Route(ApiRoutes.Categorias.GetAll)]
        public ActionResult GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(_categoriaAppService.All());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route(ApiRoutes.Categorias.Get, Name = "GetWithCat_id")]
        public ActionResult Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _categoriaAppService.Get(id);
                if (result == null) return BadRequest();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route(ApiRoutes.Categorias.Create)]
        public ActionResult Create([FromBody] CategoriaCreate categoriaCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _categoriaAppService.Create(categoriaCreate);
                if (result.Valid())
                    return Created(new Uri(Url.Link("GetWithCat_id", new { id = result })), _categoriaAppService.Get(result));

                return BadRequest(ModelState);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route(ApiRoutes.Categorias.Update)]
        public ActionResult Update([FromBody] CategoriaUpdate categoriaUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (_categoriaAppService.Get(categoriaUpdate.Cat_id) == null) return BadRequest();

                _categoriaAppService.Update(categoriaUpdate);
                return Ok(new { success = true });
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route(ApiRoutes.Categorias.Delete)]
        public ActionResult Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (_categoriaAppService.Get(id) == null) return BadRequest();

                _categoriaAppService.Remove(id);
                return Ok(new { success = true });
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route(ApiRoutes.Categorias.Status)]
        public ActionResult Status([FromBody] CategoriaStatus categoriaStatus)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (_categoriaAppService.Get(categoriaStatus.Cat_id) == null) return BadRequest();

                bool success = _categoriaAppService.Status(categoriaStatus);
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