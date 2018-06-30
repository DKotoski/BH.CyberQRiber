using Nethereum.Contracts;
using Nethereum.Signer;
using Nethereum.Web3;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EtherApi
{

    private readonly string abi = "[{'constant':true,'inputs':[],'name':'showMeWhatYouGot','outputs':[{'name':'','type':'string'}],'payable':false,'stateMutability':'pure','type':'function'},{'onstant':true,'inputs':[{'name':'_contestEntry','type':'string'}],'name':'enterContest','outputs':[{'name':'','type':'string'}],'payable':false,'stateMutability':'view','type':'function'},{'inputs':[{'name':'_contestResult','type':'string'}],'payable':false,'stateMutability':'nonpayable','type':'constructor'}]";
    private readonly string contractAddress = "0x123402bea5b53cb35bdd1e7675349e0f38bbd669";
    private string privateKey;
    private string url;

    public EtherApi(string privateKey, string url)
    {
        this.privateKey = privateKey;
        this.url = url;
        this.web3 = new Web3(url);
        this.address = EthECKey.GetPublicAddress(privateKey); //could do checksum
       // var testSometing = web3.Eth.get;

        this.contract = web3.Eth.GetContract(abi, contractAddress);
    }

    public static EtherApi Current { private set; get; }

    public static void Init(string privateKey, string url)
    {
        Current = new EtherApi(privateKey, url);
    }

    public string PrivateKey { get; private set; }
    public string Url { get; private set; }
    private Web3 web3;
    private string address;
    private Contract contract;

    public async Task<string> ShowMeWhatYouGot()
    {
        var function = contract.GetFunction("showMeWhatYouGot");
        var result = await function.CallAsync<string>(address).ConfigureAwait(false);
        return result;
    }

}
