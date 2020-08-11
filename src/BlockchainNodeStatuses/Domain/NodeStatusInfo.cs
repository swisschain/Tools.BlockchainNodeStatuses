namespace BlockchainNodeStatuses.Domain
{
    public class NodeStatusInfo
    {
        public string NodeName { get; set; }
        public string Status { get; set; }
        public long LastBlock { get; set; }

    }
}
