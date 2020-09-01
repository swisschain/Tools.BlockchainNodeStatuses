using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockchainNodeStatuses.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BlockchainNodeStatuses.WebApi
{
    [ApiController]
    [Route("api/monitoring/nodes")]
    public class NodeMonitoringController : ControllerBase
    {
        private readonly INodeStatusService _nodeStatusService;

        public NodeMonitoringController(INodeStatusService nodeStatusService)
        {
            _nodeStatusService = nodeStatusService;
        }

        [HttpPost("report-status/{token}")]
        public async Task ReportNodeStatusAsyncAsync([FromRoute]string token, NodeStatusReport report)
        {
            var isTokenValid = await _nodeStatusService.ValidateToken(token);
            if (!isTokenValid)
                return;

            await _nodeStatusService.ReportStatusAsync(report.NodeName, report.Status, report.LastBlock);
        }

        [HttpPost("get-statuses")]
        public Task<List<NodeStatusInfo>> GetPostNodeStatusesAsync()
        {
            return _nodeStatusService.GetAllStatusesAsync();
        }
        
        [HttpGet("get-statuses")]
        public Task<List<NodeStatusInfo>> GetNodeStatusesAsync()
        {
            return _nodeStatusService.GetAllStatusesAsync();
        }
    }

    public class NodeStatusReport
    {
        public string NodeName { get; set; }
        public string Status { get; set; }
        public long LastBlock { get; set; }
    }
}
