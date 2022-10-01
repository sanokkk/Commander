using Commander.DAL.Interfaces;
using Commander.Models;
using System.Collections.Generic;

namespace Commander.DAL.Repositories
{
    public class MockCommanderRepository : ICommanderRepository
    {
        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return new List<Command>() {
                new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" },
                new Command { Id = 1, HowTo = "Make couple of tea", Line = "Place teabag in cup", Platform = "Kettle & Cup" },
                new Command { Id = 2, HowTo = "Make a humberger", Line = "Cheese and meat", Platform = "McDonalds" }
            };
            
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}
