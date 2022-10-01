using Commander.DAL.Interfaces;
using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Commander.DAL.Repositories
{
    public class CommanderRepository : ICommanderRepository
    {
        private readonly ApplicationDbContext _db;
        public CommanderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void CreateCommand(Command command)
        {
            if (command == null) 
                throw new ArgumentNullException(nameof(command));
            _db.Commands.Add(command);
            _db.SaveChanges();
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            _db.Commands.Remove(command);
            _db.SaveChanges();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _db.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            var command = _db.Commands.FirstOrDefault(c => c.Id == id);
            return command;
        }

        public void UpdateCommand(Command command)
        {
            //var response = _db.Commands.ElementAt(command.Id);
            //response = new Command() { Line = command.Line, HowTo = command.HowTo, Platform = command.Platform };
            //_db.Commands.Update(response);
            //_db.SaveChanges();
            //return response;
            _db.SaveChanges();
        }
    }
}
