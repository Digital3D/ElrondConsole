namespace ElrondConsole
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupResult = new System.Windows.Forms.GroupBox();
            this.txtResult = new ScintillaNET.Scintilla();
            this.groupActions = new System.Windows.Forms.GroupBox();
            this.btnGetBlock = new System.Windows.Forms.Button();
            this.txtBlockNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBlockShardId = new System.Windows.Forms.TextBox();
            this.linkMetachainStatus = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtAccountAddress = new System.Windows.Forms.TextBox();
            this.lblAccountAddress = new System.Windows.Forms.Label();
            this.btnGetNodeHearBeat = new System.Windows.Forms.Button();
            this.txtNodeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetHeartBeatStatus = new System.Windows.Forms.Button();
            this.btnGetShardStatus = new System.Windows.Forms.Button();
            this.txtShardId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetNetworkConfig = new System.Windows.Forms.Button();
            this.btnGetDetailTransaction = new System.Windows.Forms.Button();
            this.txtTransactionHash = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetTransactions = new System.Windows.Forms.Button();
            this.groupResult.SuspendLayout();
            this.groupActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupResult
            // 
            this.groupResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupResult.Controls.Add(this.txtResult);
            this.groupResult.Location = new System.Drawing.Point(12, 180);
            this.groupResult.Name = "groupResult";
            this.groupResult.Size = new System.Drawing.Size(776, 258);
            this.groupResult.TabIndex = 1;
            this.groupResult.TabStop = false;
            this.groupResult.Text = "Result";
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(3, 16);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(770, 239);
            this.txtResult.TabIndex = 0;
            // 
            // groupActions
            // 
            this.groupActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupActions.Controls.Add(this.btnGetBlock);
            this.groupActions.Controls.Add(this.txtBlockNumber);
            this.groupActions.Controls.Add(this.label5);
            this.groupActions.Controls.Add(this.txtBlockShardId);
            this.groupActions.Controls.Add(this.linkMetachainStatus);
            this.groupActions.Controls.Add(this.label4);
            this.groupActions.Controls.Add(this.btnConnect);
            this.groupActions.Controls.Add(this.txtAccountAddress);
            this.groupActions.Controls.Add(this.lblAccountAddress);
            this.groupActions.Controls.Add(this.btnGetNodeHearBeat);
            this.groupActions.Controls.Add(this.txtNodeName);
            this.groupActions.Controls.Add(this.label3);
            this.groupActions.Controls.Add(this.btnGetHeartBeatStatus);
            this.groupActions.Controls.Add(this.btnGetShardStatus);
            this.groupActions.Controls.Add(this.txtShardId);
            this.groupActions.Controls.Add(this.label2);
            this.groupActions.Controls.Add(this.btnGetNetworkConfig);
            this.groupActions.Controls.Add(this.btnGetDetailTransaction);
            this.groupActions.Controls.Add(this.txtTransactionHash);
            this.groupActions.Controls.Add(this.label1);
            this.groupActions.Controls.Add(this.btnGetTransactions);
            this.groupActions.Location = new System.Drawing.Point(12, 12);
            this.groupActions.Name = "groupActions";
            this.groupActions.Size = new System.Drawing.Size(773, 162);
            this.groupActions.TabIndex = 2;
            this.groupActions.TabStop = false;
            this.groupActions.Text = "Actions";
            // 
            // btnGetBlock
            // 
            this.btnGetBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetBlock.Location = new System.Drawing.Point(696, 126);
            this.btnGetBlock.Name = "btnGetBlock";
            this.btnGetBlock.Size = new System.Drawing.Size(69, 20);
            this.btnGetBlock.TabIndex = 23;
            this.btnGetBlock.Text = "Detail";
            this.btnGetBlock.UseVisualStyleBackColor = true;
            this.btnGetBlock.Click += new System.EventHandler(this.btnGetBlock_Click);
            // 
            // txtBlockNumber
            // 
            this.txtBlockNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlockNumber.Location = new System.Drawing.Point(321, 126);
            this.txtBlockNumber.Name = "txtBlockNumber";
            this.txtBlockNumber.Size = new System.Drawing.Size(370, 20);
            this.txtBlockNumber.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "and block number:";
            // 
            // txtBlockShardId
            // 
            this.txtBlockShardId.Location = new System.Drawing.Point(143, 126);
            this.txtBlockShardId.Name = "txtBlockShardId";
            this.txtBlockShardId.Size = new System.Drawing.Size(74, 20);
            this.txtBlockShardId.TabIndex = 20;
            this.txtBlockShardId.Text = "0";
            // 
            // linkMetachainStatus
            // 
            this.linkMetachainStatus.AutoSize = true;
            this.linkMetachainStatus.Location = new System.Drawing.Point(419, 75);
            this.linkMetachainStatus.Name = "linkMetachainStatus";
            this.linkMetachainStatus.Size = new System.Drawing.Size(242, 13);
            this.linkMetachainStatus.TabIndex = 19;
            this.linkMetachainStatus.TabStop = true;
            this.linkMetachainStatus.Text = "Use 4294967295 in order to query the Metachain.";
            this.linkMetachainStatus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMetachainStatus_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Get Block on Shard Id:";
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(696, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(69, 20);
            this.btnConnect.TabIndex = 17;
            this.btnConnect.Text = "Detail";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtAccountAddress
            // 
            this.txtAccountAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountAddress.Location = new System.Drawing.Point(115, 19);
            this.txtAccountAddress.Name = "txtAccountAddress";
            this.txtAccountAddress.Size = new System.Drawing.Size(577, 20);
            this.txtAccountAddress.TabIndex = 16;
            this.txtAccountAddress.Text = "erd1....";
            // 
            // lblAccountAddress
            // 
            this.lblAccountAddress.AutoSize = true;
            this.lblAccountAddress.Location = new System.Drawing.Point(18, 22);
            this.lblAccountAddress.Name = "lblAccountAddress";
            this.lblAccountAddress.Size = new System.Drawing.Size(91, 13);
            this.lblAccountAddress.TabIndex = 15;
            this.lblAccountAddress.Text = "Account Address:";
            // 
            // btnGetNodeHearBeat
            // 
            this.btnGetNodeHearBeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetNodeHearBeat.Location = new System.Drawing.Point(697, 98);
            this.btnGetNodeHearBeat.Name = "btnGetNodeHearBeat";
            this.btnGetNodeHearBeat.Size = new System.Drawing.Size(69, 20);
            this.btnGetNodeHearBeat.TabIndex = 14;
            this.btnGetNodeHearBeat.Text = "Detail";
            this.btnGetNodeHearBeat.UseVisualStyleBackColor = true;
            this.btnGetNodeHearBeat.Click += new System.EventHandler(this.btnGetNodeHearBeat_Click);
            // 
            // txtNodeName
            // 
            this.txtNodeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNodeName.Location = new System.Drawing.Point(264, 98);
            this.txtNodeName.Name = "txtNodeName";
            this.txtNodeName.Size = new System.Drawing.Size(427, 20);
            this.txtNodeName.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Get Node Name:";
            // 
            // btnGetHeartBeatStatus
            // 
            this.btnGetHeartBeatStatus.Location = new System.Drawing.Point(21, 97);
            this.btnGetHeartBeatStatus.Name = "btnGetHeartBeatStatus";
            this.btnGetHeartBeatStatus.Size = new System.Drawing.Size(111, 20);
            this.btnGetHeartBeatStatus.TabIndex = 11;
            this.btnGetHeartBeatStatus.Text = "Get Heart Beat";
            this.btnGetHeartBeatStatus.UseVisualStyleBackColor = true;
            this.btnGetHeartBeatStatus.Click += new System.EventHandler(this.btnGetHeartBeatStatus_Click);
            // 
            // btnGetShardStatus
            // 
            this.btnGetShardStatus.Location = new System.Drawing.Point(344, 72);
            this.btnGetShardStatus.Name = "btnGetShardStatus";
            this.btnGetShardStatus.Size = new System.Drawing.Size(69, 20);
            this.btnGetShardStatus.TabIndex = 10;
            this.btnGetShardStatus.Text = "Go";
            this.btnGetShardStatus.UseVisualStyleBackColor = true;
            this.btnGetShardStatus.Click += new System.EventHandler(this.btnGetShardStatus_Click);
            // 
            // txtShardId
            // 
            this.txtShardId.Location = new System.Drawing.Point(264, 72);
            this.txtShardId.Name = "txtShardId";
            this.txtShardId.Size = new System.Drawing.Size(74, 20);
            this.txtShardId.TabIndex = 9;
            this.txtShardId.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Get Shard Status:";
            // 
            // btnGetNetworkConfig
            // 
            this.btnGetNetworkConfig.Location = new System.Drawing.Point(21, 71);
            this.btnGetNetworkConfig.Name = "btnGetNetworkConfig";
            this.btnGetNetworkConfig.Size = new System.Drawing.Size(111, 20);
            this.btnGetNetworkConfig.TabIndex = 7;
            this.btnGetNetworkConfig.Text = "Get Network Config";
            this.btnGetNetworkConfig.UseVisualStyleBackColor = true;
            this.btnGetNetworkConfig.Click += new System.EventHandler(this.btnGetNetworkConfig_Click);
            // 
            // btnGetDetailTransaction
            // 
            this.btnGetDetailTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetDetailTransaction.Location = new System.Drawing.Point(697, 46);
            this.btnGetDetailTransaction.Name = "btnGetDetailTransaction";
            this.btnGetDetailTransaction.Size = new System.Drawing.Size(69, 20);
            this.btnGetDetailTransaction.TabIndex = 6;
            this.btnGetDetailTransaction.Text = "Detail";
            this.btnGetDetailTransaction.UseVisualStyleBackColor = true;
            this.btnGetDetailTransaction.Click += new System.EventHandler(this.btnGetDetailTransaction_Click);
            // 
            // txtTransactionHash
            // 
            this.txtTransactionHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTransactionHash.Location = new System.Drawing.Point(264, 46);
            this.txtTransactionHash.Name = "txtTransactionHash";
            this.txtTransactionHash.Size = new System.Drawing.Size(427, 20);
            this.txtTransactionHash.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Get Detail Transaction:";
            // 
            // btnGetTransactions
            // 
            this.btnGetTransactions.Location = new System.Drawing.Point(21, 45);
            this.btnGetTransactions.Name = "btnGetTransactions";
            this.btnGetTransactions.Size = new System.Drawing.Size(111, 20);
            this.btnGetTransactions.TabIndex = 3;
            this.btnGetTransactions.Text = "Get Transactions";
            this.btnGetTransactions.UseVisualStyleBackColor = true;
            this.btnGetTransactions.Click += new System.EventHandler(this.btnGetTransactions_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupActions);
            this.Controls.Add(this.groupResult);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Elrond Console";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupResult.ResumeLayout(false);
            this.groupActions.ResumeLayout(false);
            this.groupActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupResult;
        private ScintillaNET.Scintilla txtResult;
        private System.Windows.Forms.GroupBox groupActions;
        private System.Windows.Forms.Button btnGetTransactions;
        private System.Windows.Forms.Button btnGetDetailTransaction;
        private System.Windows.Forms.TextBox txtTransactionHash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetNetworkConfig;
        private System.Windows.Forms.Button btnGetShardStatus;
        private System.Windows.Forms.TextBox txtShardId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetHeartBeatStatus;
        private System.Windows.Forms.Button btnGetNodeHearBeat;
        private System.Windows.Forms.TextBox txtNodeName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtAccountAddress;
        private System.Windows.Forms.Label lblAccountAddress;
        private System.Windows.Forms.LinkLabel linkMetachainStatus;
        private System.Windows.Forms.Button btnGetBlock;
        private System.Windows.Forms.TextBox txtBlockNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBlockShardId;
    }
}

