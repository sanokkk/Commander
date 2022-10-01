using AutoMapper;
using Commander.DAL.Interfaces;
using Commander.DAL.Repositories;
using Commander.DTOs;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepository _commands;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepository commands, IMapper mapper)
        {
            _commands = commands;
            _mapper = mapper;
        }


        //GET api/commands/
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var response = _commands.GetAllCommands();
            if (response == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(response));
        }


        //GET api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var command = _commands.GetCommandById(id);
            if (command == null) return NotFound();
            return Ok(_mapper.Map<CommandReadDto>(command));
        }


        //POST api/commands/
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto createDto)
        {
            var response = _mapper.Map<Command>(createDto);
            _commands.CreateCommand(response);
            var command = _mapper.Map<CommandReadDto>(response);
            //чтобы в хедере была ссылка на объект
            return CreatedAtRoute(nameof(GetCommandById), new { Id = command.Id }, command);

        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult<CommandReadDto> UpdateCommand(int id, CommandUpdateDto updateDto)
        {
            var getById = _commands.GetCommandById(id);
            if (getById == null) return NotFound();
            _mapper.Map(updateDto, getById);

            _commands.UpdateCommand(getById);
            return NoContent();
        }


        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var command = _commands.GetCommandById(id);
            if (command == null) return NotFound();


            var commandToPatch = _mapper.Map<CommandUpdateDto>(command);
            patchDoc.ApplyTo(commandToPatch, ModelState);
            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }


            _mapper.Map(commandToPatch, command);
            _commands.UpdateCommand(command);
            return NoContent();

            //пример
            //    [
            //        {
            //            "op": "replace",
            //            "path": "/howto",
            //            "value": "Some new value"
            //        }

            //    ]
        }


        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var command = _commands.GetCommandById(id);
            if (command == null) return NotFound();
            _commands.DeleteCommand(command);
            return NoContent();
        }


    }
}
