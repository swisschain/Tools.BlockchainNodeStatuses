using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockchainNodeStatuses.Configuration;
using Microsoft.Extensions.Logging;

namespace BlockchainNodeStatuses.Domain
{
    public class NodeStatusService : INodeStatusService
    {
        private readonly AppConfig _config;
        private readonly ILogger<NodeStatusService> _logger;
        private readonly Dictionary<string, NodeStatusInfo> _data = new Dictionary<string, NodeStatusInfo>();

        public NodeStatusService(AppConfig config, ILogger<NodeStatusService> logger)
        {
            _config = config;
            _logger = logger;
        }

        public Task<bool> ValidateToken(string token)
        {
            if (!string.IsNullOrEmpty(_config?.AccessToken) && token == _config.AccessToken)
            {
                return Task.FromResult(true);
            }

            _logger.LogWarning($"Try to access with wrong token: {token}");
            return Task.FromResult(false);
        }

        public Task ReportStatusAsync(string node, string status, long lastBlock)
        {
            lock (_data)
            {
                if (!_data.TryGetValue(node, out var data))
                {
                    data = new NodeStatusInfo()
                    {
                        NodeName = node,
                    };
                }

                data.Status = status;
                data.LastBlock = lastBlock;

                _data[data.NodeName] = data;
            }

            _logger.LogInformation($"Update status. Node: {node}; status: {status}; LastBlock: {lastBlock}");

            return Task.CompletedTask;

        }

        public Task<List<NodeStatusInfo>> GetAllStatusesAsync()
        {
            List<NodeStatusInfo> result;

            lock (_data)
            {
                result = _data.Values.ToList();
            }

            return Task.FromResult(result);
        }
    }
}
