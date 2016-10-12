using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthereumWebAPI.Models
{
    public class EthAccount
    {
        public string Address { get; set; }
        public string FilterId { get; set; }
        public bool Unlocked { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Address, Unlocked ? "Unlocked" : "Locked");
        }

        public string Balance { get; set; }
    }

    public class SendTxHistory
    {
        public string DateTime { get; set; }
        public string Amount { get; set; }
        public string Hash { get; set; }
    }

    public class TransferDT0
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string EtherValue { get; set; }

    }


}