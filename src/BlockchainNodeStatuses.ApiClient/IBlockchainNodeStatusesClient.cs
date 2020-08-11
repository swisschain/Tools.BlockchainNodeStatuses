using Swisschain.Tools.BlockchainNodeStatuses.ApiContract;

namespace Swisschain.Tools.BlockchainNodeStatuses.ApiClient
{
    public interface IBlockchainNodeStatusesClient
    {
        Monitoring.MonitoringClient Monitoring { get; }
    }
}
