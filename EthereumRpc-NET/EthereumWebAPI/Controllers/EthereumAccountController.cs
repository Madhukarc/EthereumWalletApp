using EthereumWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EthereumRpc;
using EthereumRpc.Ethereum;
using EthereumRpc.RpcObjects;
using EthereumRpc.Service;
using System.Globalization;

namespace EthereumWebAPI.Controllers
{
    public class EthereumAccountController : ApiController
    {
        public EthereumService ethereumService { get; set; }
        public List<EthAccount> Accounts { get; set; }

        public List<SendTxHistory> SendTxHistoryList { get; set; }

        public IEnumerable<EthAccount> GetAllAccount()
        {
            return LoadAccounts();
            //return products;
        }

        private List<EthAccount> LoadAccounts()
        {
            var privateConnection = new ConnectionOptions()
            {
                Port = "8545",
                Url = "http://localhost"
            };

            ethereumService = new EthereumService(privateConnection);
            Accounts = new List<EthAccount>();

            var accounts = ethereumService.GetAccounts();



            foreach (var account in accounts)
            {
                var a = new EthAccount();
                a.Address = account;

                var filter = new Filter(fromBlock: "0x01")
                {
                    Address = a.Address

                };

                a.FilterId = ethereumService.NewFilter(filter);
                Accounts.Add(a);
                var sign = ethereumService.Sign(a.Address, "Pass@123");
                a.Unlocked = sign != null;

                ethereumService.UnlockAccount(a.Address, "Pass@123");

                bool result = ethereumService.UnlockAccount(account, "Pass@123");
                if (result)
                {
                    var balance = ethereumService.GetBalance(account, BlockTag.Latest);
                    //var specifier = "0,0.000";
                    a.Balance = balance.WeiToEther();//string.Format("{0} Eth", balance.WeiToEther().ToString("0,0.000")); 
                }
            }
            return Accounts;
        }

        private string GetBalance(string account)
        {
            return string.Empty;
        }

        [HttpPost]
        public HttpResponseMessage Post(TransferDT0 tarnsfer)
        {
            try
            {
                string hex = SendTransaction(tarnsfer.FromAddress, tarnsfer.ToAddress, tarnsfer.EtherValue);
                var response = Request.CreateResponse<string>(System.Net.HttpStatusCode.Created, hex);
                return response;
            }
            catch (Exception ex)
            {
                string error = "Exception occurred: " + ex.Message + "Data Sent:" + tarnsfer.FromAddress + ", " + tarnsfer.ToAddress + ", " + tarnsfer.EtherValue;
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new StringContent(error);
                throw new HttpResponseException(response);
            }
        }
        private string SendTransaction(string fromAccount, string ToAccount, string ethvalue)
        {
            //var value = txtAmount.Text.ToBigInteger(NumberStyles.Integer);
            SendTxHistoryList = new List<SendTxHistory>();

            var privateConnection = new ConnectionOptions()
            {
                Port = "8545",
                Url = "http://localhost"
            };

            ethereumService = new EthereumService(privateConnection);

            var value = ethvalue.ToBigInteger(NumberStyles.Integer) * 1000000000000000000;

            var transaction = new Transaction()
            {
                To = ToAccount,
                From = fromAccount,
                Value = value.ToHexString()
            };



            var txHash = ethereumService.SendTransaction(transaction);

            return txHash;
        }
    }
}

