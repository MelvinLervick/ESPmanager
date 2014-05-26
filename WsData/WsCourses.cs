using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESPmanager.WsData
{
    [DataContract]
    public class WsCourses
    {
        [DataMember]
        public List<Course> Courses { get; set; }
    }

    [DataContract]
    public class Course
    {
        [DataMember]
        public int CourseId { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
