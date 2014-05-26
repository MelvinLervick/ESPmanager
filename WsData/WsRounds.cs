using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESPmanager.WsData
{
    [DataContract]
    public class WsRounds
    {
        [DataMember]
        public List<WsRound> Rounds { get; set; }
    }

    [DataContract]
    public class WsRound
    {
        [DataMember]
        public int RoundId { get; set; }
    }
}