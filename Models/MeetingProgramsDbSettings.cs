using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingPlannerAPI.Models
{
    public class MeetingProgramsDbSettings : IMeetingProgramsDbSettings
    {
        public string ProgramsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMeetingProgramsDbSettings
    {
        string ProgramsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
