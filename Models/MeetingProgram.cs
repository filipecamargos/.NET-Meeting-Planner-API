using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MeetingPlannerAPI.Models
{
    public class MeetingProgram
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string date { get; set; }
        public string conductor { get; set; }
        public string openingSong { get; set; }
        public string sacramentHymn { get; set; }
        public string specialSong { get; set; }
        public string closingSong { get; set; }
        public string openingPrayer { get; set; }
        public string closingPrayer { get; set; }
        public List<Speaker> speakers { get; set; }
    }
}
