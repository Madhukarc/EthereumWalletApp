using System;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Support.V4.Hardware.Fingerprint;
using Android.Util;
using Android.Views;
using Android.Widget;

using System.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;

using Res = Android.Resource;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace EthereumWalletXApp
{
    /// <summary>
    ///     Fingerprint manager API activity.
    /// </summary>
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
    public class FingerprintManagerApiActivity : Activity
    {
        // ReSharper disable InconsistentNaming
        static readonly string TAG = "X:" + typeof(FingerprintManagerApiActivity).Name;
        static readonly string DIALOG_FRAGMENT_TAG = "fingerprint_auth_fragment";
        static readonly int ERROR_TIMEOUT = 250;
        static string _sourceAccount, _targetAccount;
        HttpClient client;
        // ReSharper restore InconsistentNaming
        bool _canScan;

        FingerprintManagerApiDialogFragment _dialogFrag;
        View _errorPanel, _authenticatedPanel, _initialPanel, _scanInProgressPanel, _accountBalancePanel, _transferBalancePanel;
        TextView _errorTextView1, _errorTextView2;//, _successMessage;
        EditText _transferbal;
        FingerprintManagerCompat _fingerprintManager;
        Button _startAuthenticationScanButton, _scanAgainButton, _failedScanAgainButton, _showAccountBalanceButton, _transferAccountBalanceButton, _transferBalanceButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_fingerprintmanager_api);
            client = new HttpClient();
            InitializeViewReferences();

            _fingerprintManager = FingerprintManagerCompat.From(this);
            string canScanMsg = CheckFingerprintEligibility();

            _startAuthenticationScanButton.Click += StartFingerprintScan;
            //_startAuthenticationScanButton.Click += ShowTransferPanel;

            _scanAgainButton.Click += ScanAgainButtonOnClick;
            _failedScanAgainButton.Click += RecheckEligibility;
            _showAccountBalanceButton.Click += ShowAccountBalance;
            _transferAccountBalanceButton.Click += ShowTransferPanel;
            _transferBalanceButton.Click += makeTransaction;

            if (_canScan)
            {
                _dialogFrag = FingerprintManagerApiDialogFragment.NewInstance(_fingerprintManager);
            }
            else
            {
                ShowError("Can't use this device for the sample.", canScanMsg);
            }
        }

        async void ShowAccountBalance(object sender, EventArgs eventArgs)
        {
            string url = "http://52.172.158.181:80/api/EthereumAccount";

            List<EthAccount> ethAccounts;
            var uri = new Uri(string.Format(url, string.Empty));
            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ethAccounts = JsonConvert.DeserializeObject<List<EthAccount>>(content);

                    TextView account1 = FindViewById<TextView>(Resource.Id.Account_1_panel_textview);
                    TextView balance1 = FindViewById<TextView>(Resource.Id.Account_1_Balance_panel_textview);
                    TextView account2 = FindViewById<TextView>(Resource.Id.Account_2_panel_textview);
                    TextView balance2 = FindViewById<TextView>(Resource.Id.Account_2_Balance_panel_textview);

                    TextView account3 = FindViewById<TextView>(Resource.Id.Account_3_panel_textview);
                    TextView balance3 = FindViewById<TextView>(Resource.Id.Account_3_Balance_panel_textview);
                    account1.Text = ethAccounts[0].Address;
                    balance1.Text = ethAccounts[0].Balance;

                    account2.Text = ethAccounts[1].Address;
                    balance2.Text = ethAccounts[1].Balance;

                    account3.Text = ethAccounts[2].Address;
                    balance3.Text = ethAccounts[2].Balance;
                }


                _initialPanel.Visibility = ViewStates.Gone;
                _authenticatedPanel.Visibility = ViewStates.Gone;
                _errorPanel.Visibility = ViewStates.Gone;
                _scanInProgressPanel.Visibility = ViewStates.Gone;
                _accountBalancePanel.Visibility = ViewStates.Visible;
                _transferBalancePanel.Visibility = ViewStates.Gone;
            }
            catch (Exception ex)
            {
                ShowError("Error", ex.Message);
            }
        }


        async void ShowTransferPanel(object sender, EventArgs eventArgs)
        {

            // _successMessage.Visibility = ViewStates.Gone;
            Spinner sourcespinner = FindViewById<Spinner>(Resource.Id.spnrsourceAccount);
            Spinner targetspinner = FindViewById<Spinner>(Resource.Id.spnrtargetAccount);

            sourcespinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(sourcespinner_ItemSelected);
            targetspinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(targetspinner_ItemSelected);

            string url = "http://52.172.158.181:80/api/EthereumAccount";
            List<EthAccount> ethAccounts = null;
            var uri = new Uri(string.Format(url, string.Empty));
            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ethAccounts = JsonConvert.DeserializeObject<List<EthAccount>>(content);

                }
            }
            catch (Exception ex)
            {
                ShowError("Error", ex.Message);
            }

            List<string> items = new List<string>();
            foreach (var account in ethAccounts)
            {
                items.Add(account.Address);
            }

            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            sourcespinner.Adapter = adapter;
            targetspinner.Adapter = adapter;

            _initialPanel.Visibility = ViewStates.Gone;
            _authenticatedPanel.Visibility = ViewStates.Gone;
            _errorPanel.Visibility = ViewStates.Gone;
            _scanInProgressPanel.Visibility = ViewStates.Gone;
            _accountBalancePanel.Visibility = ViewStates.Gone;
            _transferBalancePanel.Visibility = ViewStates.Visible;
        }


        async void makeTransaction(object sender, EventArgs eventArgs)
        {
            string url = "http://52.172.158.181:80/api/EthereumAccount/";
            TransferDT0 tarnsfer = new TransferDT0();
            tarnsfer.FromAddress = _sourceAccount;
            tarnsfer.ToAddress = _targetAccount;
            tarnsfer.EtherValue = _transferbal.Text;
            string transactionDetails = "Transaction Details: " + "Source : " + tarnsfer.FromAddress + "target: " + tarnsfer.ToAddress + "Ether: " + tarnsfer.EtherValue;
            Toast.MakeText(this, transactionDetails, ToastLength.Long).Show();

            var uri = new Uri(string.Format(url, string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(tarnsfer);
                Toast.MakeText(this, json, ToastLength.Long).Show();
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var successMsg = "Transaction Successful";
                    Toast.MakeText(this, successMsg, ToastLength.Long).Show();
                }
                Mine();
            }
            catch (Exception ex)
            {
                ShowError("Error", ex.Message);
            }
        }

        async void Mine()
        {
            string url = "http://52.172.158.181:80/api/Miner/";
            var uri = new Uri(string.Format(url, string.Empty));
            try
            {
                var response = await client.PostAsync(uri, null);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var successMsg = "Mining Done";
                    Toast.MakeText(this, successMsg, ToastLength.Long).Show();
                }
                if (response.StatusCode == HttpStatusCode.ExpectationFailed)
                {
                    var successMsg = "Try after some time";
                    Toast.MakeText(this, successMsg, ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                ShowError("Error", ex.Message);
            }

        }


        private void sourcespinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner sourcespinner = (Spinner)sender;

            string toast = string.Format("The planet is {0}", sourcespinner.GetItemAtPosition(e.Position));
            _sourceAccount = sourcespinner.GetItemAtPosition(e.Position).ToString();
            //Toast.MakeText(this, toast, ToastLength.Long).Show();

        }
        private void targetspinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            _targetAccount = spinner.GetItemAtPosition(e.Position).ToString();
            //Toast.MakeText(this, toast, ToastLength.Long).Show();
        }


        void RecheckEligibility(object sender, EventArgs eventArgs)
        {
            string canScanMsg = CheckFingerprintEligibility();
            if (_canScan)
            {
                _dialogFrag = FingerprintManagerApiDialogFragment.NewInstance(_fingerprintManager);
                _initialPanel.Visibility = ViewStates.Visible;
                _authenticatedPanel.Visibility = ViewStates.Gone;
                _errorPanel.Visibility = ViewStates.Gone;
                _scanInProgressPanel.Visibility = ViewStates.Gone;
                _accountBalancePanel.Visibility = ViewStates.Gone;
                _transferBalancePanel.Visibility = ViewStates.Gone;
            }
            else
            {
                Log.Debug(TAG, "This device is still ineligiblity for fingerprint authentication. ");
                _dialogFrag = null;
                ShowError("Can't use this device for the sample.", canScanMsg);
            }
        }


        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug(TAG, "OnResume");
        }

        protected override void OnPause()
        {
            base.OnPause();
            Log.Debug(TAG, "OnPause");
        }

        void StartFingerprintScan(object sender, EventArgs args)
        {
            Permission permissionResult = ContextCompat.CheckSelfPermission(this,
                                                                                   Manifest.Permission.UseFingerprint);
            if (permissionResult == Permission.Granted)
            {
                _initialPanel.Visibility = ViewStates.Gone;
                _authenticatedPanel.Visibility = ViewStates.Gone;
                _errorPanel.Visibility = ViewStates.Gone;
                _accountBalancePanel.Visibility = ViewStates.Gone;
                _scanInProgressPanel.Visibility = ViewStates.Visible;
                _transferBalancePanel.Visibility = ViewStates.Gone;

                _dialogFrag.Init();
                _dialogFrag.Show(FragmentManager, DIALOG_FRAGMENT_TAG);
            }
            else
            {
                Snackbar.Make(FindViewById(Res.Id.Content),
                              Resource.String.missing_fingerprint_permissions,
                              Snackbar.LengthLong)
                        .Show();
            }
        }

        void ScanAgainButtonOnClick(object sender, EventArgs eventArgs)
        {
            _initialPanel.Visibility = ViewStates.Visible;
            _authenticatedPanel.Visibility = ViewStates.Gone;
            _errorPanel.Visibility = ViewStates.Gone;
            _scanInProgressPanel.Visibility = ViewStates.Gone;
            _accountBalancePanel.Visibility = ViewStates.Gone;
            _transferBalancePanel.Visibility = ViewStates.Gone;
        }

        void InitializeViewReferences()
        {
            _scanInProgressPanel = FindViewById(Resource.Id.scan_in_progress);
            _initialPanel = FindViewById(Resource.Id.initial_panel);
            _startAuthenticationScanButton = FindViewById<Button>(Resource.Id.start_authentication_scan_buton);

            _errorPanel = FindViewById(Resource.Id.error_panel);
            _errorTextView1 = FindViewById<TextView>(Resource.Id.error_text1);
            _errorTextView2 = FindViewById<TextView>(Resource.Id.error_text2);
            _failedScanAgainButton = FindViewById<Button>(Resource.Id.failed_scan_again_button);

            _authenticatedPanel = FindViewById(Resource.Id.authenticated_panel);
            _scanAgainButton = FindViewById<Button>(Resource.Id.scan_again_button);

            _accountBalancePanel = FindViewById(Resource.Id.showAccount_Balance_panel);
            _showAccountBalanceButton = FindViewById<Button>(Resource.Id.show_account_button);

            _transferBalancePanel = FindViewById(Resource.Id.transferAccount_Balance_panel);
            _transferAccountBalanceButton = FindViewById<Button>(Resource.Id.transfer_button);
            _transferBalanceButton = FindViewById<Button>(Resource.Id.transfer_balance_button);
            _transferbal = FindViewById<EditText>(Resource.Id.etherValue);
            // _successMessage = FindViewById<EditText>(Resource.Id.SuccessMessage_textview);
        }

        /// <summary>
        ///     Checks to see if the hardware is available to scan for fingerprints
        ///     and that the user has fingerprints enrolled.
        /// </summary>
        /// <returns></returns>
        string CheckFingerprintEligibility()
        {
            _canScan = true;

            if (!_fingerprintManager.IsHardwareDetected)
            {
                _canScan = false;
                string msg = Resources.GetString(Resource.String.missing_fingerprint_scanner);
                Log.Warn(TAG, msg);
                return msg;
            }

            KeyguardManager keyguardManager = (KeyguardManager)GetSystemService(KeyguardService);
            if (!keyguardManager.IsKeyguardSecure)
            {
                string msg = Resources.GetString(Resource.String.keyguard_disabled);
                _canScan = false;
                Log.Warn(TAG, msg);
                return msg;
            }


            if (!_fingerprintManager.HasEnrolledFingerprints)
            {
                _canScan = false;
                string msg = Resources.GetString(Resource.String.register_fingerprint);
                Log.Warn(TAG, msg);
                return msg;
            }

            return string.Empty;
        }

        /// <summary>
        ///     Display error message feedback to the user.
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        public void ShowError(string text1, string text2 = "")
        {
            Log.Debug(TAG, "ShowError: '{0}' / '{1}'", text1, text2);
            _errorPanel.PostDelayed(() =>
                                    {
                                        _errorTextView1.Text = text1;
                                        _errorTextView2.Text = text2;

                                        _initialPanel.Visibility = ViewStates.Gone;
                                        _authenticatedPanel.Visibility = ViewStates.Gone;
                                        _errorPanel.Visibility = ViewStates.Visible;
                                        _scanInProgressPanel.Visibility = ViewStates.Gone;
                                        _accountBalancePanel.Visibility = ViewStates.Gone;
                                        _transferBalancePanel.Visibility = ViewStates.Gone;
                                    }, ERROR_TIMEOUT);
        }

        public void AuthenticationSuccessful()
        {
            _initialPanel.Visibility = ViewStates.Gone;
            _authenticatedPanel.Visibility = ViewStates.Visible;
            _errorPanel.Visibility = ViewStates.Gone;
            _scanInProgressPanel.Visibility = ViewStates.Gone;
            _accountBalancePanel.Visibility = ViewStates.Gone;
            _transferBalancePanel.Visibility = ViewStates.Gone;
        }
    }




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

    public class TransferDT0
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string EtherValue { get; set; }

    }


}