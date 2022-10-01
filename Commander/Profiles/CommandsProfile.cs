using AutoMapper;
using Commander.DTOs;
using Commander.Models;

namespace Commander.Profiles
{
    //для маппинга между дто и энтити
    public class CommandsProfile: Profile
    {
        public CommandsProfile()
        {
            //source -> targer
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }

    }
}
