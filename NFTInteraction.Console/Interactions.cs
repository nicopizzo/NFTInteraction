using Nethereum.HdWallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTInteraction.Console
{
    internal class Interactions
    {
        private readonly NFTService _NFTService;

        public Interactions(NFTService service)
        {
            _NFTService = service;
        }

        public async Task StartPrivateSale()
        {
            var setLive = await _NFTService.GoPresaleLiveRequestAndWaitForReceiptAsync();
        }

        public async Task CreatePrivateSaleWhitelist(List<string> addreses)
        {
            var whiteLIst = await _NFTService.AddToPrivateSaleWhitelistRequestAsync(new ContractDefinition.AddToPrivateSaleWhitelistFunction()
            {
                PrivateSaleAddresses = addreses
            });
        }

        public async Task StartPublicSale()
        {
            var setLive = await _NFTService.GoLiveRequestAndWaitForReceiptAsync();
        }

        public async Task PrivateMint(Wallet wallet, string toAddress = null)
        {
            var isPresaleLive = await _NFTService.PrivateSaleLiveQueryAsync();
            if (!isPresaleLive)
            {
                await StartPrivateSale();
                await CreatePrivateSaleWhitelist(new List<string> { wallet.GetAccount(0).Address });
            }
            var mintCost = await _NFTService.PrivateSaleCostQueryAsync();
            var mintResult = await _NFTService.PrivateSaleMintRequestAndWaitForReceiptAsync(new ContractDefinition.PrivateSaleMintFunction()
            {
                To = string.IsNullOrEmpty(toAddress) ? wallet.GetAccount(0).Address : toAddress,
                AmountToSend = mintCost,
                MintCount = 1
            });
        }

        public async Task PublicMint(Wallet wallet, string toAddress = null)
        {
            var isLive = await _NFTService.IsLiveQueryAsync();
            if (!isLive)
            {
                await StartPublicSale();
            }

            var mintCost = await _NFTService.MintCostQueryAsync();
            var mintResult = await _NFTService.MintRequestAndWaitForReceiptAsync(new ContractDefinition.MintFunction()
            {
                To = string.IsNullOrEmpty(toAddress) ? wallet.GetAccount(0).Address : toAddress,
                AmountToSend = mintCost,
                MintCount = 1
            });
        }

        public async Task SetPublicUrl(string url)
        {
            var result = await _NFTService.SetBaseUriRequestAndWaitForReceiptAsync(new ContractDefinition.SetBaseUriFunction()
            {
                Uri = url
            });
        }

        public async Task Give(string toAddress, int count)
        {
            var result = await _NFTService.GiveRequestAndWaitForReceiptAsync(new ContractDefinition.GiveFunction()
            {
                To = toAddress,
                MintCount = count
            });
        }
    }
}
