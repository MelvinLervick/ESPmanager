using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESPmanager.WsData
{
    [DataContract]
    public class WsUnprintedRounds
    {
        [DataMember]
        public List<WsUnprintedRound> UnprintedRounds { get; set; }
    }

    [DataContract]
    public class WsUnprintedRound
    {
        [DataMember]
        public int RoundId { get; set; }
    }
}