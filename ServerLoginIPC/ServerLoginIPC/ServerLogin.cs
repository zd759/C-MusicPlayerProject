using System;
using System.Text;
using System.Windows.Forms;

namespace ServerLoginIPC
{
    /* Name: Zara Duncanson
     * Student ID: P229768
     * Date: 06/04/2020
     * Task 5, AT2, Programming 3
     * This program is the server part of a server-client program to communicate using IPC 
     * (inter-process communication) to communicate using named pipes.
     */
    public partial class ServerLogin : Form
    {
        //global variables
        private PipeServer pipeServer = new PipeServer();
        string username;
        string password;
        // Dummy repository class for DB operations
        static MockUserRepository userRepo = new MockUserRepository();
        // Let us use the Password manager class to generate the password ans salt
        static PasswordManager pwdManager = new PasswordManager();

        //default constuctor upon run
        public ServerLogin()
        {
            InitializeComponent();
            pipeServer.MessageReceived += pipeServer_MessageReceived; //add method to handler
            pipeServer.ClientDisconnected += pipeServer_ClientDisconnected;
            InitialiseUserAccount();
            btnCreateUser.Enabled = false;
            btnTestUser.Enabled = false;
            btnSendMessage.Enabled = false;
        }//end default constructor

        //--------------------PIPE SERVER--------------------//
        //handler for when client is disconnected from server
        void pipeServer_ClientDisconnected()
        {
            Invoke(new PipeServer.ClientDisconnectedHandler(ClientDisconnected));
        }
        //method used when client disconnected
        void ClientDisconnected()
        {
            lbLogDisplay.Items.Add("Client disconnected");
            lbLogDisplay.Items.Add("Total connected clients: " + pipeServer.TotalConnectedClients);
        }

        //pipe server start button method
        private void BtnStartServer_Click(object sender, EventArgs e)
        {
            //start pipe server if it isnt already running
            if (!pipeServer.Running)
            {
                pipeServer.Start(tbPipeName.Text);
                if (pipeServer.Running)
                {
                    btnStartServer.Enabled = false;
                    btnCreateUser.Enabled = true;
                    btnTestUser.Enabled = true;
                    btnSendMessage.Enabled = true;
                    lbLogDisplay.Items.Add("Server ready");
                }
            }
            //else //cannot access this code, is unnessesary
            //{
            //    lbLogDisplay.Items.Add("Server already running");
            //}
        }
        //--------------------END PIPE SERVER--------------------//

        //--------------------USER FUCTIONS GROUP BOX--------------------//
        //this method sets up a default user account and password
        private void InitialiseUserAccount()
        {
            string userId = "admin";
            string password = "1234";
            string salt = null;
            string passwordHash = pwdManager.GeneratePasswordHash(password, out salt);
            //save the values in the database
            User user = new User
            {
                UserId = userId,
                PasswordHash = passwordHash,
                Salt = salt
            };
            //add the User to the database
            userRepo.AddUser(user);
        }
        //end initialise default user account method

        //button method to create a new client user
        private void BtnCreateUser_Click(object sender, EventArgs e)
        {
            lbLogDisplay.Items.Add("New user created");
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            lbLogDisplay.Items.Add("Username: " + username);
            lbLogDisplay.Items.Add("Password: " + password);
            string salt = null;
            string passwordHash = pwdManager.GeneratePasswordHash(password, out salt);
            User user = new User
            {
                UserId = username,
                PasswordHash = passwordHash,
                Salt = salt
            };
            userRepo.AddUser(user);
            lbLogDisplay.Items.Add("Salt: " + salt);
            BtnResetUserTexboxes_Click(sender, e);
            SendMessage("New user created. Username: " + username + ".Password: " + password);
        }
        //end create new user button method

        //button method to clear user text boxes
        private void BtnResetUserTexboxes_Click(object sender, EventArgs e)
        {
            tbUsername.Clear();
            tbPassword.Clear();
        }//end clear method

        //button to test login details for a user passes to private method
        private void BtnTestUser_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            //pass to private method
            TestUser(username, password);
        }

        //private method to test login details of a user
        private void TestUser(string username, string password)
        {
            lbLogDisplay.Items.Add("Validating details");
            lbLogDisplay.Items.Add("Username: " + username);
            lbLogDisplay.Items.Add("Password: " + password);
            User user = userRepo.GetUser(username);
            bool result = pwdManager.IsPasswordMatch(password, user.Salt, user.PasswordHash);
            if (result)
            {
                //display success
                lbLogDisplay.Items.Add("Success: Password matched");
                //lblResultTestUser.Text = "Success: Password matched";
                SendMessage("Login success");
            }
            else
            {
                //display no match
                lbLogDisplay.Items.Add("Error: Password did not match");
                //lblResultTestUser.Text = "Error: Password did not match";
                SendMessage("Login failed");
            }
            tbUsername.Clear();
            tbPassword.Clear();
        }
        
        //method to reset/clear all users except admin
        private void BtnResetUsers_Click(object sender, EventArgs e)
        {
            userRepo.ResetUsers();
            InitialiseUserAccount();
        }
        //--------------------END USERS GROUP BOX--------------------//

        //--------------------MESSAGING GROUP BOX--------------------//
        //button to send messsage to client passes to private send message method
        private void BtnSendMessage_Click(object sender, EventArgs e)
        {
            SendMessage(tbSendMessage.Text);
        }

        //private method to send message to client(s)
        private void SendMessage(string message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] messageBuffer = encoder.GetBytes(message);
            pipeServer.SendMessage(messageBuffer);
            lbLogDisplay.Items.Add(tbSendMessage.Text); //display the message on both logs
        }

        //method to display message from client passes to DisplayMessageReceived method
        void pipeServer_MessageReceived(byte[] message)
        {
            Invoke(new PipeServer.MessageReceivedHandler(DisplayMessageReceived), new object[] { message });
        }

        //display message from client method
        void DisplayMessageReceived(byte[] message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            string str = encoder.GetString(message, 0, message.Length);
            if (str.Contains(","))
            {
                string[] data = str.Split(',');
                username = data[0];
                password = data[1]; //error if regular message (not login details)
                lbLogDisplay.Items.Add("Client " + username + " sent message: " + str); //display which user sent message if multiple clients connected?
                TestUser(username, password);
            }
            else
            {
                lbLogDisplay.Items.Add("Client sent message: " + str); 
            }
        }

        //clear log listBox button method
        private void BtnClearLog_Click(object sender, EventArgs e)
        {
            lbLogDisplay.Items.Clear();
        }
        //--------------------END MESSAGING GROUP BOX--------------------//
    }
}
