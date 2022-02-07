
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nethereum.RPC.Accounts;
using Nethereum.Web3;
using NFTInteraction;
using Nethereum.HdWallet;
using Nethereum.Web3.Accounts;
using NFTInteraction.Console;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

var network = config.GetSection("Web3:Network").Value;
var chainId = config.GetSection("Web3:ChainId").Value;
var contractAddress = config.GetSection("Web3:ContractAddress").Value;
var projectId = config.GetSection("ProjectId").Value;
var mnemonic = config.GetSection("Mnemonic").Value;
var privateKey = config.GetSection("PrivateKey").Value;

var wallet = new Wallet(mnemonic, "");
var account = new Account(privateKey, int.Parse(chainId));

var serviceProvider = new ServiceCollection()
    .AddSingleton<IWeb3>(f => new Web3(account, $"https://{network}.infura.io/v3/{projectId}"))
    .AddSingleton<NFTService>(f => new NFTService(f.GetRequiredService<IWeb3>(), contractAddress))
    .BuildServiceProvider();

var nftService = serviceProvider.GetRequiredService<NFTService>();

var interactions = new Interactions(nftService);
//await interactions.StartPrivateSale();
await interactions.CreatePrivateSaleWhitelist(new List<string> { "0xcedC3BEbB270cB4178770f8D0195218E0a087BC1", "0xEaDaAE05570a12013E4a214F9f79Dc1E3ACbf994" });
//await interactions.StartPublicSale();
//await interactions.SetPublicUrl("ipfs://QmSUhLdcY6ZQvVaWwRX6esaScS5HkBiVeftHfRkkZnPJwy/");
//await interactions.Give(account.Address, 5);

Console.ReadLine();
