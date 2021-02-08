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
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(
            UsuarioService usuarioService,
            IMapper mapper
        )
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UsuarioViewModel>> Get(string? nome, bool? ativo)
        {
            var usuarios = _usuarioService.Get(nome, ativo);
            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<UsuarioViewModel>>(usuarios));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UsuarioViewModel> GetById(int id)
        {
            if (!_usuarioService.Exist(id))
            {
                return NotFound();
            }

            var usuario = _usuarioService.GetById(id);
            return Ok(_mapper.Map<UsuarioViewModel>(usuario));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UsuarioViewModel> Create([FromBody] UsuarioInputModel usuarioInputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioInput = _mapper.Map<Usuario>(usuarioInputModel);
            var usuarioOutput = _usuarioService.Create(usuarioInput);
            return Created(nameof(GetById), _mapper.Map<UsuarioViewModel>(usuarioOutput));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UsuarioViewModel> Update(int id, [FromBody] UsuarioInputModel usuarioInputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_usuarioService.Exist(id))
            {
                return NotFound();
            }

            var usuarioInput = _mapper.Map<Usuario>(usuarioInputModel);
            var usuarioOutput = _usuarioService.Update(id, usuarioInput);
            return Ok(_mapper.Map<UsuarioViewModel>(usuarioOutput));
        }

        [HttpPut("{id}/status/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UsuarioViewModel> UpdateStatus(int id, bool status)
        {
            if (!_usuarioService.Exist(id))
            {
                return NotFound();
            }

            var usuario = _usuarioService.UpdateStatus(id, status);
            return Ok(_mapper.Map<UsuarioViewModel>(usuario));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            if (!_usuarioService.Exist(id))
            {
                return NotFound();
            }

            _usuarioService.Delete(id);
            return Ok();
        }
    }
}
