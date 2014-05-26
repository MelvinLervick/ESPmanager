using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESPmanager.WsData
{
    [DataContract]
    public class WsTees
    {
        [DataMember]
        public List<Tee> Tees { get; set; }
    }

    [DataContract]
    public class Tee
    {
        [DataMember]
        public int TeeId { get; set; }

        [DataMember]
        public int CourseId { get; set; }

        [DataMember]
        public string TeeName { get; set; }
    }
}