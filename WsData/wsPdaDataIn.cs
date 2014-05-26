using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESPmanager.WsData
{
    [DataContract]
    public class WsPdaDataIn
    {
        [DataMember]
        public List<WsPdaData> PdaDataIn { get; set; }
    }

    [DataContract]
    public class WsPdaData
    {
        [DataMember]
        public int PdaDataInId { get; set; }

        [DataMember]
        public int CourseId { get; set; }

        [DataMember]
        public DateTime InDate { get; set; }

        [DataMember]
        public string InTime { get; set; }

        [DataMember]
        public byte StartHole { get; set; }

        [DataMember]
        public string HHUnit { get; set; }

        [DataMember]
        public string InTimeMilitary { get; set; }

        [DataMember]
        public int RoundId { get; set; }

        [DataMember]
        public string DisplayListName { get; set; }
    }
}