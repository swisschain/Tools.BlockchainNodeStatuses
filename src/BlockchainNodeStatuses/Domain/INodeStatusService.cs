using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace BlockchainNodeStatuses.Domain
{
    public interface INodeStatusService
    {
        Task<bool> ValidateToken(string token);
        Task ReportStatusAsync(string node, string status, long lastBlock);
        Task<List<NodeStatusInfo>> GetAllStatusesAsync();
    }
}
