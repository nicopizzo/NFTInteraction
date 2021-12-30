
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nethereum.RPC.Accounts;
using Nethereum.Web3;
using NFTInteraction;
using Nethereum.HdWallet;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

var network = config.GetSection("Web3:Network").Value;
var chainId = config.GetSection("Web3:ChainId").Value;
var contractAddress = config.GetSection("Web3:ContractAddress").Value;
var projectId = config.GetSection("ProjectId").Value;
var mnemonic = config.GetSection("Mnemonic").Value;

var wallet = new Wallet(mnemonic, "");
var accounts = wallet.GetAddresses();

var serviceProvider = new ServiceCollection()
    .AddSingleton<IAccount>(f => wallet.GetAccount(0, int.Parse(chainId)))
    .AddSingleton<IWeb3>(f => new Web3(f.GetRequiredService<IAccount>(), $"https://{network}.infura.io/v3/{projectId}"))
    .AddSingleton<NFTService>(f => new NFTService(f.GetRequiredService<IWeb3>(), contractAddress))
    .BuildServiceProvider();

var nftService = serviceProvider.GetRequiredService<NFTService>();

//await PrivateMint(nftService, wallet);
await SetupPublic(nftService, wallet, "0xcedC3BEbB270cB4178770f8D0195218E0a087BC1");


Console.ReadLine();




async Task PrivateMint(NFTService nftService, Wallet wallet, string toAddress = null)
{
    var isPresaleLive = await nftService.PrivateSaleLiveQueryAsync();
    if (!isPresaleLive)
    {
        var setLive = await nftService.GoPresaleLiveRequestAndWaitForReceiptAsync();
        var whiteLIst = await nftService.AddToPrivateSaleWhitelistRequestAsync(new NFTInteraction.ContractDefinition.AddToPrivateSaleWhitelistFunction()
        {
            PrivateSaleAddresses = new List<string> { wallet.GetAccount(0).Address }
        });
    }
    var mintCost = await nftService.PrivateSaleCostQueryAsync();
    var mintResult = await nftService.PrivateSaleMintRequestAndWaitForReceiptAsync(new NFTInteraction.ContractDefinition.PrivateSaleMintFunction()
    {
        To = string.IsNullOrEmpty(toAddress) ? wallet.GetAccount(0).Address : toAddress,
        AmountToSend = mintCost,
        MintCount = 1
    });
}

async Task SetupPublic(NFTService nftService, Wallet wallet, string toAddress = null)
{
    var isLive = await nftService.IsLiveQueryAsync();
    if (!isLive)
    {
        var setLive = await nftService.GoLiveRequestAndWaitForReceiptAsync();
    }
    
    var mintCost = await nftService.MintCostQueryAsync();
    var mintResult = await nftService.MintRequestAndWaitForReceiptAsync(new NFTInteraction.ContractDefinition.MintFunction()
    {
        To = string.IsNullOrEmpty(toAddress) ? wallet.GetAccount(0).Address : toAddress,
        AmountToSend = mintCost,
        MintCount = 1
    });
}
