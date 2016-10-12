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
using System.Threading;

namespace EthereumWebAPI.Controllers
{
    public class MinerController : ApiController
    {
        public EthereumService ethereumService { get; set; }

        // GET: api/Miner
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Miner/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Miner
        public HttpResponseMessage Post()
        {

            try
            {
                var privateConnection = new ConnectionOptions()
                {
                    Port = "8545",
                    Url = "http://localhost"
                };

                ethereumService = new EthereumService(privateConnection);
                ethereumService.StartMining();
                if (ethereumService.GetMining())
                {
                    Thread.Sleep(10000);      // sleeps for 50000= 50 seconds
                }
               
                var result = ethereumService.StopMining();
                Thread.Sleep(10000);
                if (!ethereumService.GetMining())
                {
                    var response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
                    return response;
                }
                return new HttpResponseMessage(HttpStatusCode.ExpectationFailed);

            }
            catch (Exception ex)
            {
                string error = "Exception occurred: " + ex.Message;
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new StringContent(error);
                throw new HttpResponseException(response);
            }
        }

        // PUT: api/Miner/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Miner/5
        public void Delete(int id)
        {
        }
    }
}
