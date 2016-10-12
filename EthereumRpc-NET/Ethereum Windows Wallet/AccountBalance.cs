using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EthereumRpc;
using EthereumRpc.Ethereum;
using EthereumRpc.RpcObjects;
using EthereumRpc.Service;

namespace Ethereum.Wallet
{
    public partial class AccountBalance : Form
    {
        public EthereumService EthereumService { get; set; }
        public List<SendTxHistory> SendTxHistoryList { get; set; }
        public List<Account> Accounts { get; set; }
        public int AccountIndex = -1;
        public string CurrentAccount;


        public AccountBalance()
        {
            InitializeComponent();

            var privateConnection = new ConnectionOptions()
            {
                Port = "8545",
                Url = "http://localhost"
            };

            EthereumService = new EthereumService(privateConnection);

        }

        private void btnShowBalance_Click(object sender, EventArgs e)
        {
            string account = lstboxAccountList.SelectedItem.ToString();
            bool result = EthereumService.UnlockAccount(account, "Pass@123");
            if (result)
            {
                var balance = EthereumService.GetBalance(account, BlockTag.Latest);

                MessageBox.Show(account + " - " + string.Format("{0} Eth", balance.WeiToEther()));
            }
            else
            {
                MessageBox.Show("No Balance in this account");
            }

        }

        private void btAccountList_Click(object sender, EventArgs e)
        {
            LoadAccounts();
        }


        private void LoadAccounts()
        {
            Accounts = new List<Account>();

            var accounts = EthereumService.GetAccounts();



            foreach (var account in accounts)
            {
                var a = new Account();
                a.Address = account;

                var filter = new Filter(fromBlock: "0x01")
                {
                    Address = a.Address

                };

                a.FilterId = EthereumService.NewFilter(filter);
                Accounts.Add(a);
                ListViewItem item = new ListViewItem(a.Address);
                var sign = EthereumService.Sign(a.Address, "Pass@123");
                lstboxAccountList.Items.Add(a.Address);

                a.Unlocked = sign != null;
                EthereumService.UnlockAccount(a.Address, "Pass@123");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BigInteger myval = 505004147510133867000;
            //string mystringval = myval.WeiToEther();
            //MessageBox.Show(mystringval);
            
        }

        //public static string WeiToEther(this BigInteger value)
        //{
        //    var divRem1 = BigInteger.Zero;
        //    var bal = BigInteger.DivRem(value, 1000000000000000000, out divRem1);
        //    var balanceString = string.Format("{0}.{1}", bal, divRem1);
        //    decimal decimalBalance = 0;
        //    //decimal.TryParse(textBox7.Text, out dvalue);
        //    bool result = decimal.TryParse(balanceString, NumberStyles.Float | NumberStyles.AllowExponent, CultureInfo.InvariantCulture, out decimalBalance);
        //    return decimalBalance.ToString("0.00");
        //}
    }
}
