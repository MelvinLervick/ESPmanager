using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESPmanager.WsData
{
    [DataContract]
    public class WsTees
    {
        [DataMember]
        public List<WsTee> Tees { get; set; }
    }

    [DataContract]
    public class WsTee
    {
        [DataMember]
        public int TeeId { get; set; }

        [DataMember]
        public int CourseId { get; set; }

        [DataMember]
        public byte TeeOrder { get; set; }

        [DataMember]
        public string TeeName { get; set; }

        [DataMember]
        public string ShortName { get; set; }

        [DataMember]
        public bool Mens { get; set; }

        [DataMember]
        public double MCourseRating { get; set; }

        [DataMember]
        public short MSlope { get; set; }

        [DataMember]
        public bool MPrint { get; set; }

        [DataMember]
        public double FCourseRating { get; set; }

        [DataMember]
        public short FSlope { get; set; }

        [DataMember]
        public bool FPrint { get; set; }

        [DataMember]
        public string PinLocation { get; set; }
    }
}