# Tools.BlockchainNodeStatuses

![Continous integration build and publish](https://github.com/swisschain/Tools.BlockchainNodeStatuses/workflows/Continous%20integration%20build%20and%20publish/badge.svg)

![API docker image](https://img.shields.io/docker/v/swisschains/tools-blockchain-node-statuses?sort=semver)

# Environment Variables
[Logging](https://github.com/swisschain/Swisschain.Sdk.Server/blob/master/README.md#logging)

# Instructions

1. configure environment variable `AccessToken` - set secret token to acce to POST method to update status
2. run docker image `swisschains/tools-blockchain-node-statuses:1.0.0`
3. use http port 5000
4. check swagger: `/swagger/ui/index.html`
