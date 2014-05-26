using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESPmanager.WsData
{
    [DataContract]
    public class WsCourses
    {
        [DataMember]
        public List<WsCourse> Courses { get; set; }
    }

    [DataContract]
    public class WsCourse
    {
        [DataMember]
        public int CourseId { get; set; }

        [DataMember]
        public string ClubNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ShortCourseName { get; set; }

        [DataMember]
        public string CourseName { get; set; }

        [DataMember]
        public byte NumberOfTees { get; set; }

        [DataMember]
        public byte DefaultHandicapType { get; set; }

        [DataMember]
        public byte MaxPlayers { get; set; }

        [DataMember]
        public byte NumberOfPoints { get; set; }

        [DataMember]
        public string Address1 { get; set; }

        [DataMember]
        public string Address2 { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string PostalCode { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public byte Primary { get; set; }
    }
}
