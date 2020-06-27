using System;
using System.Windows.Forms;
using ElrondConsoleLibrary;

namespace ElrondConsole
{
    public partial class frmMain : Form
    {
        private MainService _service;
        public frmMain()
        {
            InitializeComponent();
            //Instance Service
            _service = new MainService();
            //Instance TextArea Scintilla
            ScintillaInit scintilla1 = new ScintillaInit(this, txtResult);
            txtResult = scintilla1.TextArea;
            //Load if already we have the erd address
            if(!string.IsNullOrEmpty(Properties.Settings.Default.ErdAddress))
                txtAccountAddress.Text = Properties.Settings.Default.ErdAddress;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.NodeName))
                txtNodeName.Text = Properties.Settings.Default.NodeName;
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            var result = await _service.GetInformationElrondAddress(txtAccountAddress.Text);
            if (!result.IsError)
            {
                //I save Erd to load quickly next time in the textbox
                Properties.Settings.Default.ErdAddress = txtAccountAddress.Text;
                Properties.Settings.Default.Save();
            }
            DisplayResult(result);
        }

        private void DisplayResult<T>(ApiResponse<T> response)
        {
            txtResult.ResetText();
            txtResult.Text = response.Url + Environment.NewLine;
            if (response.IsError)
                txtResult.Text += response.Message;
            else
                txtResult.Text += response.ResultJson;
        }

        private async void btnGetTransactions_Click(object sender, EventArgs e)
        {
            var result = await _service.GetTransactions(txtAccountAddress.Text);
            DisplayResult(result);
        }

        private async void btnGetDetailTransaction_Click(object sender, EventArgs e)
        {
            var result = await _service.GetDetailTransaction(txtTransactionHash.Text);
            DisplayResult(result);
        }

        private async void btnGetNetworkConfig_Click(object sender, EventArgs e)
        {
            var result = await _service.GetNetworkConfig();
            DisplayResult(result);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnGetNetworkConfig.PerformClick();
        }

        private async void btnGetShardStatus_Click(object sender, EventArgs e)
        {
            var result = await _service.GetShardStatus(txtShardId.Text);
            DisplayResult(result);
        }

        private async void btnGetHeartBeatStatus_Click(object sender, EventArgs e)
        {
            var result = await _service.GetHeartBeatStatus();
            DisplayResult(result);
        }

        private async void btnGetNodeHearBeat_Click(object sender, EventArgs e)
        {
            var result = await _service.GetHeartBeatStatus(txtNodeName.Text);
            if (!result.IsError)
            {
                //I save the node name
                Properties.Settings.Default.NodeName = txtNodeName.Text;
                Properties.Settings.Default.Save();
            }
            DisplayResult(result);

        }

        private void linkMetachainStatus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtShardId.Text = "4294967295";
            btnGetShardStatus.PerformClick();
        }

        private async void btnGetBlock_Click(object sender, EventArgs e)
        {
            var result = await _service.GetBlock(txtBlockShardId.Text, txtBlockNumber.Text);
            DisplayResult(result);
        }
    }
}
