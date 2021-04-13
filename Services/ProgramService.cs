using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MeetingPlannerAPI.Models;


namespace MeetingPlannerAPI.Services
{
    public class ProgramService
    {
        private readonly IMongoCollection<MeetingProgram> _programs;

        public ProgramService(IMeetingProgramsDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _programs = database.GetCollection<MeetingProgram>(settings.ProgramsCollectionName);
        }

        public List<MeetingProgram> Get() =>
            _programs.Find(program => true).ToList();

        public MeetingProgram Get(string id) =>
            _programs.Find<MeetingProgram>(program => program.Id == id).FirstOrDefault();

        public MeetingProgram Create(MeetingProgram program)
        {
            _programs.InsertOne(program);
            return program;
        }

        public void Update(string id, MeetingProgram programIn) =>
            _programs.ReplaceOne(program => program.Id == id, programIn);

        public void Remove(MeetingProgram programIn) =>
            _programs.DeleteOne(program => program.Id == programIn.Id);

        public void Remove(string id) =>
            _programs.DeleteOne(program => program.Id == id);
    }
}
