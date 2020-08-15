using System.Collections.Generic;

namespace ElrondConsoleLibrary.Model
{
    public class HeartBeatStatusModel
    {
        public HeartBeatStatusData Data { get; set; }
        public string Error { get; set; }
        public string Code { get; set; }
    }

    public class HeartBeatStatusData
    {
        public List<HeartBeatStatus> Heartbeats { get; set; }
    }

    public class HeartBeatStatus
    {
        public string Timestamp { get; set; }
        public string PublicKey { get; set; }
        public string VersionNumber { get; set; }
        public string NodeDisplayName { get; set; }
        public string Identity { get; set; }
        public long TotalUpTimeSec { get; set; }
        public long TotalDownTimeSec { get; set; }
        public string MaxInactiveTime { get; set; }
        public long ReceivedShardId { get; set; }
        public long ComputedShardId { get; set; }
        public string PeerType { get; set; }
        public bool IsActive { get; set; }
    }
}
