
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
//await SetupPublic(nftService, wallet);
//await SetPublicUrl(nftService, "ipfs://QmSUhLdcY6ZQvVaWwRX6esaScS5HkBiVeftHfRkkZnPJwy/");
//await SetPublicUrl(nftService, "https://gateway.pinata.cloud/ipfs/QmSUhLdcY6ZQvVaWwRX6esaScS5HkBiVeftHfRkkZnPJwy/");


Console.ReadLine();
