﻿using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApiSample.Infrastructure;
using WebApiSample.Models;
namespace WebApiSample.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public EmpresaController(ILogger<ProductsController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost(Name = "Post Empresa")]
        public async Task<IActionResult> Post(Empresa entity)
        {
            var result = await _unitOfWork.Empresas.AddAsync(entity);
            // Cero filas afectada ... we have problems.
            if (result == 0)
            {
                return NotFound();
            }
            // Ok
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Empresa entity)
        {
            // Controlo que el id sea consistente.
            if (id != entity.id)
            {
                return BadRequest();
            }
            var result = await _unitOfWork.Empresas.UpdateAsync(entity);
            // Si la operacion devolvio 0 filas .... es por que no le pegue al id.
            if (result == 0)
            {
                return NotFound();
            }
            // Si llegue hasta aca ... OK
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Empresas.DeleteAsync(id);
            // Ninguna fila afectada .... El id no existe
            if (result == 0)
            {
                return NotFound();
            }
            // Si llegue hasta aca, OK
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> Get(int id)
        {
            var result = await _unitOfWork.Empresas.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return result;
            }
        }

        [HttpGet(Name = "GetAll Empresa")]
        public async Task<IEnumerable<Empresa>> GetAll()
        {
            return await _unitOfWork.Empresas.GetAllAsync();
        }
    }
}
