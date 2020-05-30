namespace MusicPlayerProject
{
    partial class MusicPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlayer));
            this.btnSecurityApp = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnDeleteTrack = new System.Windows.Forms.Button();
            this.btnClearAllTracks = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSaveTrackList = new System.Windows.Forms.Button();
            this.btnAddTracks = new System.Windows.Forms.Button();
            this.gbMediaPlayer = new System.Windows.Forms.GroupBox();
            this.lbTracks = new System.Windows.Forms.ListBox();
            this.tbTrackSearch = new System.Windows.Forms.TextBox();
            this.btnBinarySearch = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnUserLogin = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPipe = new System.Windows.Forms.Label();
            this.tbPipeName = new System.Windows.Forms.TextBox();
            this.gpServer = new System.Windows.Forms.GroupBox();
            this.btnDisconnectPipe = new System.Windows.Forms.Button();
            this.btnConnectPipe = new System.Windows.Forms.Button();
            this.gbClient = new System.Windows.Forms.GroupBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.gbMessaging = new System.Windows.Forms.GroupBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.btnClearMessageLog = new System.Windows.Forms.Button();
            this.lblSendMessage = new System.Windows.Forms.Label();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.tbSendMessage = new System.Windows.Forms.TextBox();
            this.lbLogDisplay = new System.Windows.Forms.ListBox();
            this.gpApps = new System.Windows.Forms.GroupBox();
            this.btnLoadTrackList = new System.Windows.Forms.Button();
            this.gbMediaPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            this.gpServer.SuspendLayout();
            this.gbClient.SuspendLayout();
            this.gbMessaging.SuspendLayout();
            this.gpApps.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSecurityApp
            // 
            this.btnSecurityApp.BackColor = System.Drawing.Color.LightSalmon;
            this.btnSecurityApp.Location = new System.Drawing.Point(39, 19);
            this.btnSecurityApp.Name = "btnSecurityApp";
            this.btnSecurityApp.Size = new System.Drawing.Size(124, 36);
            this.btnSecurityApp.TabIndex = 6;
            this.btnSecurityApp.Text = "Security App";
            this.btnSecurityApp.UseVisualStyleBackColor = false;
            this.btnSecurityApp.Click += new System.EventHandler(this.BtnSecurityApp_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(113, 204);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(98, 24);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(9, 174);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(98, 24);
            this.btnPlay.TabIndex = 11;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(113, 174);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(98, 24);
            this.btnPause.TabIndex = 10;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // btnDeleteTrack
            // 
            this.btnDeleteTrack.Location = new System.Drawing.Point(113, 19);
            this.btnDeleteTrack.Name = "btnDeleteTrack";
            this.btnDeleteTrack.Size = new System.Drawing.Size(98, 34);
            this.btnDeleteTrack.TabIndex = 9;
            this.btnDeleteTrack.Text = "Delete Track";
            this.btnDeleteTrack.UseVisualStyleBackColor = true;
            this.btnDeleteTrack.Click += new System.EventHandler(this.BtnDeleteTrack_Click);
            // 
            // btnClearAllTracks
            // 
            this.btnClearAllTracks.Location = new System.Drawing.Point(9, 59);
            this.btnClearAllTracks.Name = "btnClearAllTracks";
            this.btnClearAllTracks.Size = new System.Drawing.Size(98, 34);
            this.btnClearAllTracks.TabIndex = 8;
            this.btnClearAllTracks.Text = "Clear All";
            this.btnClearAllTracks.UseVisualStyleBackColor = true;
            this.btnClearAllTracks.Click += new System.EventHandler(this.BtnClearAllTracks_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(113, 235);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(98, 24);
            this.btnPrevious.TabIndex = 7;
            this.btnPrevious.Text = "Prev";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(9, 235);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(98, 24);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btnSaveTrackList
            // 
            this.btnSaveTrackList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveTrackList.Location = new System.Drawing.Point(113, 59);
            this.btnSaveTrackList.Name = "btnSaveTrackList";
            this.btnSaveTrackList.Size = new System.Drawing.Size(98, 19);
            this.btnSaveTrackList.TabIndex = 3;
            this.btnSaveTrackList.Text = "Save Tracks";
            this.btnSaveTrackList.UseVisualStyleBackColor = true;
            this.btnSaveTrackList.Click += new System.EventHandler(this.BtnSaveTrackList_Click);
            // 
            // btnAddTracks
            // 
            this.btnAddTracks.Location = new System.Drawing.Point(9, 19);
            this.btnAddTracks.Name = "btnAddTracks";
            this.btnAddTracks.Size = new System.Drawing.Size(98, 34);
            this.btnAddTracks.TabIndex = 2;
            this.btnAddTracks.Text = "Add Tracks";
            this.btnAddTracks.UseVisualStyleBackColor = true;
            this.btnAddTracks.Click += new System.EventHandler(this.BtnAddTracks_Click);
            // 
            // gbMediaPlayer
            // 
            this.gbMediaPlayer.BackColor = System.Drawing.Color.LemonChiffon;
            this.gbMediaPlayer.Controls.Add(this.btnLoadTrackList);
            this.gbMediaPlayer.Controls.Add(this.lbTracks);
            this.gbMediaPlayer.Controls.Add(this.btnDeleteTrack);
            this.gbMediaPlayer.Controls.Add(this.tbTrackSearch);
            this.gbMediaPlayer.Controls.Add(this.btnBinarySearch);
            this.gbMediaPlayer.Controls.Add(this.axWindowsMediaPlayer);
            this.gbMediaPlayer.Controls.Add(this.btnStop);
            this.gbMediaPlayer.Controls.Add(this.btnPlay);
            this.gbMediaPlayer.Controls.Add(this.btnPause);
            this.gbMediaPlayer.Controls.Add(this.btnClearAllTracks);
            this.gbMediaPlayer.Controls.Add(this.btnPrevious);
            this.gbMediaPlayer.Controls.Add(this.btnNext);
            this.gbMediaPlayer.Controls.Add(this.btnSaveTrackList);
            this.gbMediaPlayer.Controls.Add(this.btnAddTracks);
            this.gbMediaPlayer.Location = new System.Drawing.Point(11, 324);
            this.gbMediaPlayer.Name = "gbMediaPlayer";
            this.gbMediaPlayer.Size = new System.Drawing.Size(728, 268);
            this.gbMediaPlayer.TabIndex = 10;
            this.gbMediaPlayer.TabStop = false;
            this.gbMediaPlayer.Text = "Media Player";
            // 
            // lbTracks
            // 
            this.lbTracks.FormattingEnabled = true;
            this.lbTracks.Location = new System.Drawing.Point(217, 19);
            this.lbTracks.Name = "lbTracks";
            this.lbTracks.Size = new System.Drawing.Size(237, 238);
            this.lbTracks.TabIndex = 15;
            this.lbTracks.SelectedIndexChanged += new System.EventHandler(this.LbTracks_SelectedIndexChanged);
            // 
            // tbTrackSearch
            // 
            this.tbTrackSearch.Location = new System.Drawing.Point(9, 109);
            this.tbTrackSearch.Name = "tbTrackSearch";
            this.tbTrackSearch.Size = new System.Drawing.Size(202, 20);
            this.tbTrackSearch.TabIndex = 8;
            // 
            // btnBinarySearch
            // 
            this.btnBinarySearch.Location = new System.Drawing.Point(97, 135);
            this.btnBinarySearch.Name = "btnBinarySearch";
            this.btnBinarySearch.Size = new System.Drawing.Size(114, 28);
            this.btnBinarySearch.TabIndex = 14;
            this.btnBinarySearch.Text = "Binary Search";
            this.btnBinarySearch.UseVisualStyleBackColor = true;
            this.btnBinarySearch.Click += new System.EventHandler(this.BtnBinarySearch_Click);
            // 
            // axWindowsMediaPlayer
            // 
            this.axWindowsMediaPlayer.Enabled = true;
            this.axWindowsMediaPlayer.Location = new System.Drawing.Point(460, 19);
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.Size = new System.Drawing.Size(263, 240);
            this.axWindowsMediaPlayer.TabIndex = 13;
            // 
            // btnUserLogin
            // 
            this.btnUserLogin.Location = new System.Drawing.Point(224, 24);
            this.btnUserLogin.Name = "btnUserLogin";
            this.btnUserLogin.Size = new System.Drawing.Size(104, 46);
            this.btnUserLogin.TabIndex = 7;
            this.btnUserLogin.Text = "User Login";
            this.btnUserLogin.UseVisualStyleBackColor = true;
            this.btnUserLogin.Click += new System.EventHandler(this.BtnUserLogin_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(6, 53);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password:";
            // 
            // lblPipe
            // 
            this.lblPipe.AutoSize = true;
            this.lblPipe.Location = new System.Drawing.Point(3, 20);
            this.lblPipe.Name = "lblPipe";
            this.lblPipe.Size = new System.Drawing.Size(62, 13);
            this.lblPipe.TabIndex = 7;
            this.lblPipe.Text = "Pipe Name:";
            // 
            // tbPipeName
            // 
            this.tbPipeName.Location = new System.Drawing.Point(6, 33);
            this.tbPipeName.Name = "tbPipeName";
            this.tbPipeName.Size = new System.Drawing.Size(322, 20);
            this.tbPipeName.TabIndex = 2;
            this.tbPipeName.Text = "\\\\.\\pipe\\myPipe";
            // 
            // gpServer
            // 
            this.gpServer.BackColor = System.Drawing.Color.LightGreen;
            this.gpServer.Controls.Add(this.btnDisconnectPipe);
            this.gpServer.Controls.Add(this.btnConnectPipe);
            this.gpServer.Controls.Add(this.lblPipe);
            this.gpServer.Controls.Add(this.tbPipeName);
            this.gpServer.Location = new System.Drawing.Point(11, 12);
            this.gpServer.Name = "gpServer";
            this.gpServer.Size = new System.Drawing.Size(334, 123);
            this.gpServer.TabIndex = 7;
            this.gpServer.TabStop = false;
            this.gpServer.Text = "Server";
            // 
            // btnDisconnectPipe
            // 
            this.btnDisconnectPipe.Location = new System.Drawing.Point(201, 74);
            this.btnDisconnectPipe.Name = "btnDisconnectPipe";
            this.btnDisconnectPipe.Size = new System.Drawing.Size(127, 32);
            this.btnDisconnectPipe.TabIndex = 9;
            this.btnDisconnectPipe.Text = "Diconnect";
            this.btnDisconnectPipe.UseVisualStyleBackColor = true;
            this.btnDisconnectPipe.Click += new System.EventHandler(this.BtnDisconnectPipe_Click);
            // 
            // btnConnectPipe
            // 
            this.btnConnectPipe.Location = new System.Drawing.Point(6, 74);
            this.btnConnectPipe.Name = "btnConnectPipe";
            this.btnConnectPipe.Size = new System.Drawing.Size(127, 32);
            this.btnConnectPipe.TabIndex = 8;
            this.btnConnectPipe.Text = "Connect";
            this.btnConnectPipe.UseVisualStyleBackColor = true;
            this.btnConnectPipe.Click += new System.EventHandler(this.BtnConnectPipe_Click);
            // 
            // gbClient
            // 
            this.gbClient.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gbClient.Controls.Add(this.btnUserLogin);
            this.gbClient.Controls.Add(this.lblPassword);
            this.gbClient.Controls.Add(this.lblUsername);
            this.gbClient.Controls.Add(this.tbPassword);
            this.gbClient.Controls.Add(this.tbUsername);
            this.gbClient.Location = new System.Drawing.Point(11, 152);
            this.gbClient.Name = "gbClient";
            this.gbClient.Size = new System.Drawing.Size(334, 86);
            this.gbClient.TabIndex = 9;
            this.gbClient.TabStop = false;
            this.gbClient.Text = "Client";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(6, 27);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Username:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(73, 50);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(145, 20);
            this.tbPassword.TabIndex = 1;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(73, 24);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(145, 20);
            this.tbUsername.TabIndex = 0;
            // 
            // gbMessaging
            // 
            this.gbMessaging.BackColor = System.Drawing.Color.LightBlue;
            this.gbMessaging.Controls.Add(this.lblLog);
            this.gbMessaging.Controls.Add(this.btnClearMessageLog);
            this.gbMessaging.Controls.Add(this.lblSendMessage);
            this.gbMessaging.Controls.Add(this.btnSendMessage);
            this.gbMessaging.Controls.Add(this.tbSendMessage);
            this.gbMessaging.Controls.Add(this.lbLogDisplay);
            this.gbMessaging.Location = new System.Drawing.Point(353, 12);
            this.gbMessaging.Name = "gbMessaging";
            this.gbMessaging.Size = new System.Drawing.Size(387, 306);
            this.gbMessaging.TabIndex = 8;
            this.gbMessaging.TabStop = false;
            this.gbMessaging.Text = "Messaging";
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(3, 74);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(28, 13);
            this.lblLog.TabIndex = 7;
            this.lblLog.Text = "Log:";
            // 
            // btnClearMessageLog
            // 
            this.btnClearMessageLog.Location = new System.Drawing.Point(6, 277);
            this.btnClearMessageLog.Name = "btnClearMessageLog";
            this.btnClearMessageLog.Size = new System.Drawing.Size(375, 23);
            this.btnClearMessageLog.TabIndex = 6;
            this.btnClearMessageLog.Text = "Clear Log";
            this.btnClearMessageLog.UseVisualStyleBackColor = true;
            this.btnClearMessageLog.Click += new System.EventHandler(this.BtnClearMessageLog_Click);
            // 
            // lblSendMessage
            // 
            this.lblSendMessage.AutoSize = true;
            this.lblSendMessage.Location = new System.Drawing.Point(3, 17);
            this.lblSendMessage.Name = "lblSendMessage";
            this.lblSendMessage.Size = new System.Drawing.Size(81, 13);
            this.lblSendMessage.TabIndex = 5;
            this.lblSendMessage.Text = "Send Message:";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(282, 54);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(99, 35);
            this.btnSendMessage.TabIndex = 4;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.BtnSendMessage_Click);
            // 
            // tbSendMessage
            // 
            this.tbSendMessage.Location = new System.Drawing.Point(6, 33);
            this.tbSendMessage.Multiline = true;
            this.tbSendMessage.Name = "tbSendMessage";
            this.tbSendMessage.Size = new System.Drawing.Size(375, 20);
            this.tbSendMessage.TabIndex = 3;
            // 
            // lbLogDisplay
            // 
            this.lbLogDisplay.FormattingEnabled = true;
            this.lbLogDisplay.Location = new System.Drawing.Point(6, 90);
            this.lbLogDisplay.Name = "lbLogDisplay";
            this.lbLogDisplay.Size = new System.Drawing.Size(375, 186);
            this.lbLogDisplay.TabIndex = 0;
            // 
            // gpApps
            // 
            this.gpApps.BackColor = System.Drawing.Color.Bisque;
            this.gpApps.Controls.Add(this.btnSecurityApp);
            this.gpApps.Location = new System.Drawing.Point(11, 248);
            this.gpApps.Name = "gpApps";
            this.gpApps.Size = new System.Drawing.Size(334, 70);
            this.gpApps.TabIndex = 11;
            this.gpApps.TabStop = false;
            this.gpApps.Text = "Apps";
            // 
            // btnLoadTrackList
            // 
            this.btnLoadTrackList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadTrackList.Location = new System.Drawing.Point(113, 84);
            this.btnLoadTrackList.Name = "btnLoadTrackList";
            this.btnLoadTrackList.Size = new System.Drawing.Size(98, 19);
            this.btnLoadTrackList.TabIndex = 16;
            this.btnLoadTrackList.Text = "Load Tracks";
            this.btnLoadTrackList.UseVisualStyleBackColor = true;
            this.btnLoadTrackList.Click += new System.EventHandler(this.BtnLoadTrackList_Click);
            // 
            // MusicPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 599);
            this.Controls.Add(this.gpApps);
            this.Controls.Add(this.gbMediaPlayer);
            this.Controls.Add(this.gpServer);
            this.Controls.Add(this.gbClient);
            this.Controls.Add(this.gbMessaging);
            this.Name = "MusicPlayer";
            this.Text = "Form1";
            this.gbMediaPlayer.ResumeLayout(false);
            this.gbMediaPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            this.gpServer.ResumeLayout(false);
            this.gpServer.PerformLayout();
            this.gbClient.ResumeLayout(false);
            this.gbClient.PerformLayout();
            this.gbMessaging.ResumeLayout(false);
            this.gbMessaging.PerformLayout();
            this.gpApps.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSecurityApp;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnDeleteTrack;
        private System.Windows.Forms.Button btnClearAllTracks;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSaveTrackList;
        private System.Windows.Forms.Button btnAddTracks;
        private System.Windows.Forms.GroupBox gbMediaPlayer;
        private System.Windows.Forms.Button btnUserLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblPipe;
        private System.Windows.Forms.TextBox tbPipeName;
        private System.Windows.Forms.GroupBox gpServer;
        private System.Windows.Forms.Button btnDisconnectPipe;
        private System.Windows.Forms.Button btnConnectPipe;
        private System.Windows.Forms.GroupBox gbClient;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.GroupBox gbMessaging;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Button btnClearMessageLog;
        private System.Windows.Forms.Label lblSendMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox tbSendMessage;
        private System.Windows.Forms.ListBox lbLogDisplay;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private System.Windows.Forms.GroupBox gpApps;
        private System.Windows.Forms.Button btnBinarySearch;
        private System.Windows.Forms.TextBox tbTrackSearch;
        private System.Windows.Forms.ListBox lbTracks;
        private System.Windows.Forms.Button btnLoadTrackList;
    }
}

