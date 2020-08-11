using Swisschain.Tools.BlockchainNodeStatuses.ApiClient.Common;
using Swisschain.Tools.BlockchainNodeStatuses.ApiContract;

namespace Swisschain.Tools.BlockchainNodeStatuses.ApiClient
{
    public class BlockchainNodeStatusesClient : BaseGrpcClient, IBlockchainNodeStatusesClient
    {
        public BlockchainNodeStatusesClient(string serverGrpcUrl) : base(serverGrpcUrl)
        {
            Monitoring = new Monitoring.MonitoringClient(Channel);
        }

        public Monitoring.MonitoringClient Monitoring { get; }
    }
}
