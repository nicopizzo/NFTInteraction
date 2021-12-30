using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using NFTInteraction.ContractDefinition;

namespace NFTInteraction
{
    public class NFTService
    {
        private readonly IWeb3 _Web3;
        private readonly ContractHandler _ContractHandler;

        public NFTService(IWeb3 web3, string contractAddress)
        {
            _Web3 = web3;
            _ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddToPrivateSaleWhitelistRequestAsync(AddToPrivateSaleWhitelistFunction addToPrivateSaleWhitelistFunction)
        {
             return _ContractHandler.SendRequestAsync(addToPrivateSaleWhitelistFunction);
        }

        public Task<TransactionReceipt> AddToPrivateSaleWhitelistRequestAndWaitForReceiptAsync(AddToPrivateSaleWhitelistFunction addToPrivateSaleWhitelistFunction, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(addToPrivateSaleWhitelistFunction, cancellationToken);
        }

        public Task<string> AddToPrivateSaleWhitelistRequestAsync(List<string> privateSaleAddresses)
        {
            var addToPrivateSaleWhitelistFunction = new AddToPrivateSaleWhitelistFunction();
                addToPrivateSaleWhitelistFunction.PrivateSaleAddresses = privateSaleAddresses;
            
             return _ContractHandler.SendRequestAsync(addToPrivateSaleWhitelistFunction);
        }

        public Task<TransactionReceipt> AddToPrivateSaleWhitelistRequestAndWaitForReceiptAsync(List<string> privateSaleAddresses, CancellationTokenSource cancellationToken = null)
        {
            var addToPrivateSaleWhitelistFunction = new AddToPrivateSaleWhitelistFunction();
                addToPrivateSaleWhitelistFunction.PrivateSaleAddresses = privateSaleAddresses;
            
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(addToPrivateSaleWhitelistFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return _ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string to, BigInteger tokenId)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.To = to;
                approveFunction.TokenId = tokenId;
            
             return _ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.To = to;
                approveFunction.TokenId = tokenId;
            
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string owner, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.Owner = owner;
            
            return _ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<string> GetApprovedQueryAsync(GetApprovedFunction getApprovedFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<GetApprovedFunction, string>(getApprovedFunction, blockParameter);
        }

        
        public Task<string> GetApprovedQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var getApprovedFunction = new GetApprovedFunction();
                getApprovedFunction.TokenId = tokenId;
            
            return _ContractHandler.QueryAsync<GetApprovedFunction, string>(getApprovedFunction, blockParameter);
        }

        public Task<bool> GetPrivateSaleWhitelistQueryAsync(GetPrivateSaleWhitelistFunction getPrivateSaleWhitelistFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<GetPrivateSaleWhitelistFunction, bool>(getPrivateSaleWhitelistFunction, blockParameter);
        }

        
        public Task<bool> GetPrivateSaleWhitelistQueryAsync(string addr, BlockParameter blockParameter = null)
        {
            var getPrivateSaleWhitelistFunction = new GetPrivateSaleWhitelistFunction();
                getPrivateSaleWhitelistFunction.Addr = addr;
            
            return _ContractHandler.QueryAsync<GetPrivateSaleWhitelistFunction, bool>(getPrivateSaleWhitelistFunction, blockParameter);
        }

        public Task<string> GiveRequestAsync(GiveFunction giveFunction)
        {
             return _ContractHandler.SendRequestAsync(giveFunction);
        }

        public Task<TransactionReceipt> GiveRequestAndWaitForReceiptAsync(GiveFunction giveFunction, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(giveFunction, cancellationToken);
        }

        public Task<string> GiveRequestAsync(string to, BigInteger mintCount)
        {
            var giveFunction = new GiveFunction();
                giveFunction.To = to;
                giveFunction.MintCount = mintCount;
            
             return _ContractHandler.SendRequestAsync(giveFunction);
        }

        public Task<TransactionReceipt> GiveRequestAndWaitForReceiptAsync(string to, BigInteger mintCount, CancellationTokenSource cancellationToken = null)
        {
            var giveFunction = new GiveFunction();
                giveFunction.To = to;
                giveFunction.MintCount = mintCount;
            
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(giveFunction, cancellationToken);
        }

        public Task<BigInteger> GiveMintCountQueryAsync(GiveMintCountFunction giveMintCountFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<GiveMintCountFunction, BigInteger>(giveMintCountFunction, blockParameter);
        }

        
        public Task<BigInteger> GiveMintCountQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<GiveMintCountFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> GoLiveRequestAsync(GoLiveFunction goLiveFunction)
        {
             return _ContractHandler.SendRequestAsync(goLiveFunction);
        }

        public Task<string> GoLiveRequestAsync()
        {
             return _ContractHandler.SendRequestAsync<GoLiveFunction>();
        }

        public Task<TransactionReceipt> GoLiveRequestAndWaitForReceiptAsync(GoLiveFunction goLiveFunction, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(goLiveFunction, cancellationToken);
        }

        public Task<TransactionReceipt> GoLiveRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync<GoLiveFunction>(null, cancellationToken);
        }

        public Task<string> GoPresaleLiveRequestAsync(GoPresaleLiveFunction goPresaleLiveFunction)
        {
             return _ContractHandler.SendRequestAsync(goPresaleLiveFunction);
        }

        public Task<string> GoPresaleLiveRequestAsync()
        {
             return _ContractHandler.SendRequestAsync<GoPresaleLiveFunction>();
        }

        public Task<TransactionReceipt> GoPresaleLiveRequestAndWaitForReceiptAsync(GoPresaleLiveFunction goPresaleLiveFunction, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(goPresaleLiveFunction, cancellationToken);
        }

        public Task<TransactionReceipt> GoPresaleLiveRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync<GoPresaleLiveFunction>(null, cancellationToken);
        }

        public Task<bool> IsApprovedForAllQueryAsync(IsApprovedForAllFunction isApprovedForAllFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction, blockParameter);
        }

        
        public Task<bool> IsApprovedForAllQueryAsync(string owner, string @operator, BlockParameter blockParameter = null)
        {
            var isApprovedForAllFunction = new IsApprovedForAllFunction();
                isApprovedForAllFunction.Owner = owner;
                isApprovedForAllFunction.Operator = @operator;
            
            return _ContractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction, blockParameter);
        }

        public Task<bool> IsLiveQueryAsync(IsLiveFunction isLiveFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<IsLiveFunction, bool>(isLiveFunction, blockParameter);
        }

        
        public Task<bool> IsLiveQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<IsLiveFunction, bool>(null, blockParameter);
        }

        public Task<BigInteger> MaxGiveSupplyQueryAsync(MaxGiveSupplyFunction maxGiveSupplyFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<MaxGiveSupplyFunction, BigInteger>(maxGiveSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> MaxGiveSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<MaxGiveSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> MaxMintPerUserQueryAsync(MaxMintPerUserFunction maxMintPerUserFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<MaxMintPerUserFunction, BigInteger>(maxMintPerUserFunction, blockParameter);
        }

        
        public Task<BigInteger> MaxMintPerUserQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<MaxMintPerUserFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> MaxPrivateSaleMintPerUserQueryAsync(MaxPrivateSaleMintPerUserFunction maxPrivateSaleMintPerUserFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<MaxPrivateSaleMintPerUserFunction, BigInteger>(maxPrivateSaleMintPerUserFunction, blockParameter);
        }

        
        public Task<BigInteger> MaxPrivateSaleMintPerUserQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<MaxPrivateSaleMintPerUserFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> MaxSupplyQueryAsync(MaxSupplyFunction maxSupplyFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<MaxSupplyFunction, BigInteger>(maxSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> MaxSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<MaxSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> MintRequestAsync(MintFunction mintFunction)
        {
             return _ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(MintFunction mintFunction, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public Task<string> MintRequestAsync(string to, BigInteger mintCount)
        {
            var mintFunction = new MintFunction();
                mintFunction.To = to;
                mintFunction.MintCount = mintCount;
            
             return _ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(string to, BigInteger mintCount, CancellationTokenSource cancellationToken = null)
        {
            var mintFunction = new MintFunction();
                mintFunction.To = to;
                mintFunction.MintCount = mintCount;
            
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public Task<BigInteger> MintCostQueryAsync(MintCostFunction mintCostFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<MintCostFunction, BigInteger>(mintCostFunction, blockParameter);
        }

        
        public Task<BigInteger> MintCostQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<MintCostFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> OwnerOfQueryAsync(OwnerOfFunction ownerOfFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction, blockParameter);
        }

        
        public Task<string> OwnerOfQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var ownerOfFunction = new OwnerOfFunction();
                ownerOfFunction.TokenId = tokenId;
            
            return _ContractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction, blockParameter);
        }

        public Task<string> PreMintMetadataUriQueryAsync(PreMintMetadataUriFunction preMintMetadataUriFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<PreMintMetadataUriFunction, string>(preMintMetadataUriFunction, blockParameter);
        }

        
        public Task<string> PreMintMetadataUriQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<PreMintMetadataUriFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> PrivateMintCountQueryAsync(PrivateMintCountFunction privateMintCountFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<PrivateMintCountFunction, BigInteger>(privateMintCountFunction, blockParameter);
        }

        
        public Task<BigInteger> PrivateMintCountQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<PrivateMintCountFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> PrivateSaleCostQueryAsync(PrivateSaleCostFunction privateSaleCostFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<PrivateSaleCostFunction, BigInteger>(privateSaleCostFunction, blockParameter);
        }

        
        public Task<BigInteger> PrivateSaleCostQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<PrivateSaleCostFunction, BigInteger>(null, blockParameter);
        }

        public Task<bool> PrivateSaleLiveQueryAsync(PrivateSaleLiveFunction privateSaleLiveFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<PrivateSaleLiveFunction, bool>(privateSaleLiveFunction, blockParameter);
        }

        
        public Task<bool> PrivateSaleLiveQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<PrivateSaleLiveFunction, bool>(null, blockParameter);
        }

        public Task<string> PrivateSaleMintRequestAsync(PrivateSaleMintFunction privateSaleMintFunction)
        {
             return _ContractHandler.SendRequestAsync(privateSaleMintFunction);
        }

        public Task<TransactionReceipt> PrivateSaleMintRequestAndWaitForReceiptAsync(PrivateSaleMintFunction privateSaleMintFunction, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(privateSaleMintFunction, cancellationToken);
        }

        public Task<string> PrivateSaleMintRequestAsync(string to, BigInteger mintCount)
        {
            var privateSaleMintFunction = new PrivateSaleMintFunction();
                privateSaleMintFunction.To = to;
                privateSaleMintFunction.MintCount = mintCount;
            
             return _ContractHandler.SendRequestAsync(privateSaleMintFunction);
        }

        public Task<TransactionReceipt> PrivateSaleMintRequestAndWaitForReceiptAsync(string to, BigInteger mintCount, CancellationTokenSource cancellationToken = null)
        {
            var privateSaleMintFunction = new PrivateSaleMintFunction();
                privateSaleMintFunction.To = to;
                privateSaleMintFunction.MintCount = mintCount;
            
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(privateSaleMintFunction, cancellationToken);
        }

        public Task<string> ProvenanceHashQueryAsync(ProvenanceHashFunction provenanceHashFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<ProvenanceHashFunction, string>(provenanceHashFunction, blockParameter);
        }

        
        public Task<string> ProvenanceHashQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<ProvenanceHashFunction, string>(null, blockParameter);
        }

        public Task<string> RemoveFromPrivateSaleWhitelistRequestAsync(RemoveFromPrivateSaleWhitelistFunction removeFromPrivateSaleWhitelistFunction)
        {
             return _ContractHandler.SendRequestAsync(removeFromPrivateSaleWhitelistFunction);
        }

        public Task<TransactionReceipt> RemoveFromPrivateSaleWhitelistRequestAndWaitForReceiptAsync(RemoveFromPrivateSaleWhitelistFunction removeFromPrivateSaleWhitelistFunction, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(removeFromPrivateSaleWhitelistFunction, cancellationToken);
        }

        public Task<string> RemoveFromPrivateSaleWhitelistRequestAsync(List<string> privateSaleAddresses)
        {
            var removeFromPrivateSaleWhitelistFunction = new RemoveFromPrivateSaleWhitelistFunction();
                removeFromPrivateSaleWhitelistFunction.PrivateSaleAddresses = privateSaleAddresses;
            
             return _ContractHandler.SendRequestAsync(removeFromPrivateSaleWhitelistFunction);
        }

        public Task<TransactionReceipt> RemoveFromPrivateSaleWhitelistRequestAndWaitForReceiptAsync(List<string> privateSaleAddresses, CancellationTokenSource cancellationToken = null)
        {
            var removeFromPrivateSaleWhitelistFunction = new RemoveFromPrivateSaleWhitelistFunction();
                removeFromPrivateSaleWhitelistFunction.PrivateSaleAddresses = privateSaleAddresses;
            
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(removeFromPrivateSaleWhitelistFunction, cancellationToken);
        }

        public Task<string> RenounceOwnershipRequestAsync(RenounceOwnershipFunction renounceOwnershipFunction)
        {
             return _ContractHandler.SendRequestAsync(renounceOwnershipFunction);
        }

        public Task<string> RenounceOwnershipRequestAsync()
        {
             return _ContractHandler.SendRequestAsync<RenounceOwnershipFunction>();
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(RenounceOwnershipFunction renounceOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(renounceOwnershipFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceOwnershipFunction>(null, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFromFunction safeTransferFromFunction)
        {
             return _ContractHandler.SendRequestAsync(safeTransferFromFunction);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFromFunction safeTransferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger tokenId)
        {
            var safeTransferFromFunction = new SafeTransferFromFunction();
                safeTransferFromFunction.From = from;
                safeTransferFromFunction.To = to;
                safeTransferFromFunction.TokenId = tokenId;
            
             return _ContractHandler.SendRequestAsync(safeTransferFromFunction);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFromFunction = new SafeTransferFromFunction();
                safeTransferFromFunction.From = from;
                safeTransferFromFunction.To = to;
                safeTransferFromFunction.TokenId = tokenId;
            
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFrom1Function safeTransferFrom1Function)
        {
             return _ContractHandler.SendRequestAsync(safeTransferFrom1Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFrom1Function safeTransferFrom1Function, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom1Function, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger tokenId, byte[] data)
        {
            var safeTransferFrom1Function = new SafeTransferFrom1Function();
                safeTransferFrom1Function.From = from;
                safeTransferFrom1Function.To = to;
                safeTransferFrom1Function.TokenId = tokenId;
                safeTransferFrom1Function.Data = data;
            
             return _ContractHandler.SendRequestAsync(safeTransferFrom1Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFrom1Function = new SafeTransferFrom1Function();
                safeTransferFrom1Function.From = from;
                safeTransferFrom1Function.To = to;
                safeTransferFrom1Function.TokenId = tokenId;
                safeTransferFrom1Function.Data = data;
            
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom1Function, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(SetApprovalForAllFunction setApprovalForAllFunction)
        {
             return _ContractHandler.SendRequestAsync(setApprovalForAllFunction);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(SetApprovalForAllFunction setApprovalForAllFunction, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(string @operator, bool approved)
        {
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
                setApprovalForAllFunction.Operator = @operator;
                setApprovalForAllFunction.Approved = approved;
            
             return _ContractHandler.SendRequestAsync(setApprovalForAllFunction);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(string @operator, bool approved, CancellationTokenSource cancellationToken = null)
        {
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
                setApprovalForAllFunction.Operator = @operator;
                setApprovalForAllFunction.Approved = approved;
            
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction, cancellationToken);
        }

        public Task<string> SetBaseUriRequestAsync(SetBaseUriFunction setBaseUriFunction)
        {
             return _ContractHandler.SendRequestAsync(setBaseUriFunction);
        }

        public Task<TransactionReceipt> SetBaseUriRequestAndWaitForReceiptAsync(SetBaseUriFunction setBaseUriFunction, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(setBaseUriFunction, cancellationToken);
        }

        public Task<string> SetBaseUriRequestAsync(string uri)
        {
            var setBaseUriFunction = new SetBaseUriFunction();
                setBaseUriFunction.Uri = uri;
            
             return _ContractHandler.SendRequestAsync(setBaseUriFunction);
        }

        public Task<TransactionReceipt> SetBaseUriRequestAndWaitForReceiptAsync(string uri, CancellationTokenSource cancellationToken = null)
        {
            var setBaseUriFunction = new SetBaseUriFunction();
                setBaseUriFunction.Uri = uri;
            
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(setBaseUriFunction, cancellationToken);
        }

        public Task<BigInteger> StartingIndexQueryAsync(StartingIndexFunction startingIndexFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<StartingIndexFunction, BigInteger>(startingIndexFunction, blockParameter);
        }

        
        public Task<BigInteger> StartingIndexQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<StartingIndexFunction, BigInteger>(null, blockParameter);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterfaceFunction supportsInterfaceFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        
        public Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter blockParameter = null)
        {
            var supportsInterfaceFunction = new SupportsInterfaceFunction();
                supportsInterfaceFunction.InterfaceId = interfaceId;
            
            return _ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        public Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<SymbolFunction, string>(symbolFunction, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<SymbolFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> TokenByIndexQueryAsync(TokenByIndexFunction tokenByIndexFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<TokenByIndexFunction, BigInteger>(tokenByIndexFunction, blockParameter);
        }

        
        public Task<BigInteger> TokenByIndexQueryAsync(BigInteger index, BlockParameter blockParameter = null)
        {
            var tokenByIndexFunction = new TokenByIndexFunction();
                tokenByIndexFunction.Index = index;
            
            return _ContractHandler.QueryAsync<TokenByIndexFunction, BigInteger>(tokenByIndexFunction, blockParameter);
        }

        public Task<BigInteger> TokenOfOwnerByIndexQueryAsync(TokenOfOwnerByIndexFunction tokenOfOwnerByIndexFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<TokenOfOwnerByIndexFunction, BigInteger>(tokenOfOwnerByIndexFunction, blockParameter);
        }

        
        public Task<BigInteger> TokenOfOwnerByIndexQueryAsync(string owner, BigInteger index, BlockParameter blockParameter = null)
        {
            var tokenOfOwnerByIndexFunction = new TokenOfOwnerByIndexFunction();
                tokenOfOwnerByIndexFunction.Owner = owner;
                tokenOfOwnerByIndexFunction.Index = index;
            
            return _ContractHandler.QueryAsync<TokenOfOwnerByIndexFunction, BigInteger>(tokenOfOwnerByIndexFunction, blockParameter);
        }

        public Task<string> TokenURIQueryAsync(TokenURIFunction tokenURIFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<TokenURIFunction, string>(tokenURIFunction, blockParameter);
        }

        
        public Task<string> TokenURIQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var tokenURIFunction = new TokenURIFunction();
                tokenURIFunction.TokenId = tokenId;
            
            return _ContractHandler.QueryAsync<TokenURIFunction, string>(tokenURIFunction, blockParameter);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return _ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return _ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string from, string to, BigInteger tokenId)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.TokenId = tokenId;
            
             return _ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.TokenId = tokenId;
            
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return _ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return _ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(WithdrawFunction withdrawFunction)
        {
             return _ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<string> WithdrawRequestAsync()
        {
             return _ContractHandler.SendRequestAsync<WithdrawFunction>();
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return _ContractHandler.SendRequestAndWaitForReceiptAsync<WithdrawFunction>(null, cancellationToken);
        }
    }
}
