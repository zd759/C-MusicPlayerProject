namespace ServerLoginIPC
{
    partial class ServerLogin
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
            this.gpServer = new System.Windows.Forms.GroupBox();
            this.lblPipeName = new System.Windows.Forms.Label();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.tbPipeName = new System.Windows.Forms.TextBox();
            this.gbClient = new System.Windows.Forms.GroupBox();
            this.btnResetUserTexboxes = new System.Windows.Forms.Button();
            this.btnTestUser = new System.Windows.Forms.Button();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lbLogDisplay = new System.Windows.Forms.ListBox();
            this.tbSendMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.lblSendMessage = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.lblLog = new System.Windows.Forms.Label();
            this.gbMessaging = new System.Windows.Forms.GroupBox();
            this.btnResetUsers = new System.Windows.Forms.Button();
            this.gpServer.SuspendLayout();
            this.gbClient.SuspendLayout();
            this.gbMessaging.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpServer
            // 
            this.gpServer.BackColor = System.Drawing.Color.LightGreen;
            this.gpServer.Controls.Add(this.lblPipeName);
            this.gpServer.Controls.Add(this.btnStartServer);
            this.gpServer.Controls.Add(this.tbPipeName);
            this.gpServer.Location = new System.Drawing.Point(12, 12);
            this.gpServer.Name = "gpServer";
            this.gpServer.Size = new System.Drawing.Size(289, 124);
            this.gpServer.TabIndex = 1;
            this.gpServer.TabStop = false;
            this.gpServer.Text = "Server";
            // 
            // lblPipeName
            // 
            this.lblPipeName.AutoSize = true;
            this.lblPipeName.Location = new System.Drawing.Point(3, 20);
            this.lblPipeName.Name = "lblPipeName";
            this.lblPipeName.Size = new System.Drawing.Size(62, 13);
            this.lblPipeName.TabIndex = 7;
            this.lblPipeName.Text = "Pipe Name:";
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(179, 70);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(104, 48);
            this.btnStartServer.TabIndex = 7;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.BtnStartServer_Click);
            // 
            // tbPipeName
            // 
            this.tbPipeName.Location = new System.Drawing.Point(6, 33);
            this.tbPipeName.Name = "tbPipeName";
            this.tbPipeName.Size = new System.Drawing.Size(277, 20);
            this.tbPipeName.TabIndex = 2;
            this.tbPipeName.Text = "\\\\.\\pipe\\myPipe";
            // 
            // gbClient
            // 
            this.gbClient.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gbClient.Controls.Add(this.btnResetUsers);
            this.gbClient.Controls.Add(this.btnResetUserTexboxes);
            this.gbClient.Controls.Add(this.btnTestUser);
            this.gbClient.Controls.Add(this.btnCreateUser);
            this.gbClient.Controls.Add(this.lblPassword);
            this.gbClient.Controls.Add(this.lblUsername);
            this.gbClient.Controls.Add(this.tbPassword);
            this.gbClient.Controls.Add(this.tbUsername);
            this.gbClient.Location = new System.Drawing.Point(12, 153);
            this.gbClient.Name = "gbClient";
            this.gbClient.Size = new System.Drawing.Size(289, 171);
            this.gbClient.TabIndex = 2;
            this.gbClient.TabStop = false;
            this.gbClient.Text = "Client";
            // 
            // btnResetUserTexboxes
            // 
            this.btnResetUserTexboxes.Location = new System.Drawing.Point(179, 131);
            this.btnResetUserTexboxes.Name = "btnResetUserTexboxes";
            this.btnResetUserTexboxes.Size = new System.Drawing.Size(104, 34);
            this.btnResetUserTexboxes.TabIndex = 9;
            this.btnResetUserTexboxes.Text = "Reset Fields";
            this.btnResetUserTexboxes.UseVisualStyleBackColor = true;
            this.btnResetUserTexboxes.Click += new System.EventHandler(this.BtnResetUserTexboxes_Click);
            // 
            // btnTestUser
            // 
            this.btnTestUser.Location = new System.Drawing.Point(179, 91);
            this.btnTestUser.Name = "btnTestUser";
            this.btnTestUser.Size = new System.Drawing.Size(104, 34);
            this.btnTestUser.TabIndex = 8;
            this.btnTestUser.Text = "Test User";
            this.btnTestUser.UseVisualStyleBackColor = true;
            this.btnTestUser.Click += new System.EventHandler(this.BtnTestUser_Click);
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(179, 24);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(104, 46);
            this.btnCreateUser.TabIndex = 7;
            this.btnCreateUser.Text = "Create";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.BtnCreateUser_Click);
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
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 1;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(73, 24);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(100, 20);
            this.tbUsername.TabIndex = 0;
            // 
            // lbLogDisplay
            // 
            this.lbLogDisplay.FormattingEnabled = true;
            this.lbLogDisplay.Location = new System.Drawing.Point(6, 107);
            this.lbLogDisplay.Name = "lbLogDisplay";
            this.lbLogDisplay.Size = new System.Drawing.Size(323, 173);
            this.lbLogDisplay.TabIndex = 0;
            // 
            // tbSendMessage
            // 
            this.tbSendMessage.Location = new System.Drawing.Point(6, 33);
            this.tbSendMessage.Multiline = true;
            this.tbSendMessage.Name = "tbSendMessage";
            this.tbSendMessage.Size = new System.Drawing.Size(323, 33);
            this.tbSendMessage.TabIndex = 3;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(225, 69);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(104, 35);
            this.btnSendMessage.TabIndex = 4;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.BtnSendMessage_Click);
            // 
            // lblSendMessage
            // 
            this.lblSendMessage.AutoSize = true;
            this.lblSendMessage.Location = new System.Drawing.Point(3, 20);
            this.lblSendMessage.Name = "lblSendMessage";
            this.lblSendMessage.Size = new System.Drawing.Size(81, 13);
            this.lblSendMessage.TabIndex = 5;
            this.lblSendMessage.Text = "Send Message:";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(6, 283);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(323, 23);
            this.btnClearLog.TabIndex = 6;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.BtnClearLog_Click);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(3, 91);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(28, 13);
            this.lblLog.TabIndex = 7;
            this.lblLog.Text = "Log:";
            // 
            // gbMessaging
            // 
            this.gbMessaging.BackColor = System.Drawing.Color.LightBlue;
            this.gbMessaging.Controls.Add(this.lblLog);
            this.gbMessaging.Controls.Add(this.btnClearLog);
            this.gbMessaging.Controls.Add(this.lblSendMessage);
            this.gbMessaging.Controls.Add(this.btnSendMessage);
            this.gbMessaging.Controls.Add(this.tbSendMessage);
            this.gbMessaging.Controls.Add(this.lbLogDisplay);
            this.gbMessaging.Location = new System.Drawing.Point(316, 12);
            this.gbMessaging.Name = "gbMessaging";
            this.gbMessaging.Size = new System.Drawing.Size(335, 312);
            this.gbMessaging.TabIndex = 2;
            this.gbMessaging.TabStop = false;
            this.gbMessaging.Text = "Messaging";
            // 
            // btnResetUsers
            // 
            this.btnResetUsers.Location = new System.Drawing.Point(6, 142);
            this.btnResetUsers.Name = "btnResetUsers";
            this.btnResetUsers.Size = new System.Drawing.Size(104, 23);
            this.btnResetUsers.TabIndex = 11;
            this.btnResetUsers.Text = "Reset All Users";
            this.btnResetUsers.UseVisualStyleBackColor = true;
            this.btnResetUsers.Click += new System.EventHandler(this.BtnResetUsers_Click);
            // 
            // ServerLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 334);
            this.Controls.Add(this.gbClient);
            this.Controls.Add(this.gbMessaging);
            this.Controls.Add(this.gpServer);
            this.Name = "ServerLogin";
            this.Text = "Server Login";
            this.gpServer.ResumeLayout(false);
            this.gpServer.PerformLayout();
            this.gbClient.ResumeLayout(false);
            this.gbClient.PerformLayout();
            this.gbMessaging.ResumeLayout(false);
            this.gbMessaging.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gpServer;
        private System.Windows.Forms.TextBox tbPipeName;
        private System.Windows.Forms.GroupBox gbClient;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblPipeName;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnResetUserTexboxes;
        private System.Windows.Forms.Button btnTestUser;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ListBox lbLogDisplay;
        private System.Windows.Forms.TextBox tbSendMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Label lblSendMessage;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.GroupBox gbMessaging;
        private System.Windows.Forms.Button btnResetUsers;
    }
}

