using AutoMapper;
using Itbit.WebAPI.Domain.Models;
using Itbit.WebAPI.Domain.Services;
using Itbit.WebAPI.Inbound.InputModels;
using Itbit.WebAPI.Inbound.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Itbit.WebAPI.Inbound.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SexoController : Controller
    {
        private readonly SexoService _sexoService;
        private readonly IMapper _mapper;

        public SexoController(
            SexoService sexoService,
            IMapper mapper
        )
        {
            _sexoService = sexoService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<SexoViewModel>> Get()
        {
            if (!_sexoService.Exist())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<SexoViewModel>>(_sexoService.Get()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<SexoViewModel> Create([FromBody] SexoInputModel sexoInputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sexoInput = _mapper.Map<Sexo>(sexoInputModel);
            var sexoOutput = _sexoService.Create(sexoInput);
            return Created(string.Empty, _mapper.Map<SexoViewModel>(sexoOutput));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            if (!_sexoService.Exist(id))
            {
                return NotFound();
            }

            _sexoService.Delete(id);
            return NoContent();
        }
    }
}
