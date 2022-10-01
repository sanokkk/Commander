using Commander.Models;
using System.Collections.Generic;

namespace Commander.DAL.Interfaces
{
    public interface ICommanderRepository
    {
        IEnumerable<Command> GetAllCommands();

        Command GetCommandById(int id);

        void CreateCommand(Command command);

        void UpdateCommand(Command command);

        void DeleteCommand(Command command);
    }
}
