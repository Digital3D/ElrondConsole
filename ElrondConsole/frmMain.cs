﻿using System;
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
            if (!string.IsNullOrEmpty(Properties.Settings.Default.BlockNumber))
                txtBlockNumber.Text = Properties.Settings.Default.BlockNumber;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.BlockShardId))
                txtBlockShardId.Text = Properties.Settings.Default.BlockShardId;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.TransactionHash))
                txtTransactionHash.Text = Properties.Settings.Default.TransactionHash;
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
            if (!result.IsError)
            {
                Properties.Settings.Default.TransactionHash = txtTransactionHash.Text;
                Properties.Settings.Default.Save();
            }
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
            if (!result.IsError)
            {
                //I save the node name
                Properties.Settings.Default.BlockNumber = txtBlockNumber.Text;
                Properties.Settings.Default.BlockShardId = txtBlockShardId.Text;
                Properties.Settings.Default.Save();
            }
            DisplayResult(result);
        }

        private void txtBlockNumber_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnGetBlock;
        }

        private void txtNodeName_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnGetNodeHearBeat;
        }

        private void txtShardId_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnGetShardStatus;
        }

        private void txtTransactionHash_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnGetDetailTransaction;
        }

        private void txtAccountAddress_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnConnect;
        }

        private void txtBlockShardId_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnGetBlock;
        }

        private async void btnTransactionSend_Click(object sender, EventArgs e)
        {
            var result = await _service.SendTransaction(txtNonce.Text, txtValue.Text, txtSender.Text, txtReceiver.Text, txtGasPrice.Text, txtGasLimit.Text, txtData.Text);
            DisplayResult(result);
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            string signature = _service.CreateSignature(txtNonce.Text, txtValue.Text, txtSender.Text, txtReceiver.Text, txtGasPrice.Text, txtGasLimit.Text, txtData.Text);
            txtSignature.Text = signature;
        }
    }
}
