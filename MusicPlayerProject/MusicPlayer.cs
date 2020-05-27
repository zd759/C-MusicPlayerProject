using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayerProject
{
    /* Name: Zara Duncanson
    * Student ID: P229768
    * Date: 22/05/2020
    * Project, AT3, Programming 3
    * This program is the client part of a server-client program which lets the user login to a
    * server using hashing techniques on their password. Once logged in, users are able to chat,
    * use a media player which can load music and save to .csv file using a third party library.
    * Songs are sorted automatically upon upload and can then be searched. Tracks are stored in a  
    * dynamic data-structure (doubly-linked list) and users are stored as objects with attributes 
    * in a list. This program communicates with a server program using named pipes using 
    * inter-process communication (IPC).
    */
    public partial class MusicPlayer : Form
    {
        //global pipe and linkedList
        private PipeClient pipeClient;
        //create instance of trackList linked list with node objects stored as items
        LinkedList<Node<string>> trackList = new LinkedList<Node<string>>();
        
        //default contructor
        public MusicPlayer()
        {
            InitializeComponent();
            CreateNewPipeClient();
            btnDisconnectPipe.Enabled = false;
            btnUserLogin.Enabled = false;
            btnSendMessage.Enabled = false;
            btnSecurityApp.Enabled = false;
            //DisableMediaPlayerButtons();
        }//end constructor
        //--------------------PIPE CLIENT--------------------//
        //method to create a new pipe client
        void CreateNewPipeClient()
        {
            if (pipeClient != null)
            {
                pipeClient.MessageReceived -= PipeClient_MessageReceived;
                pipeClient.ServerDisconnected -= PipeClient_ServerDisconnected;
            }
            pipeClient = new PipeClient();
            pipeClient.MessageReceived += PipeClient_MessageReceived;
            pipeClient.ServerDisconnected += PipeClient_ServerDisconnected;
        }

        //method handler for server disconnection
        void PipeClient_ServerDisconnected()
        {
            Invoke(new PipeClient.ServerDisconnectedHandler(EnableStartButton));
        }

        //method handler for enabling the connect button if server is disconnected
        void EnableStartButton()
        {
            btnConnectPipe.Enabled = true;
            btnDisconnectPipe.Enabled = false;
            lbLogDisplay.Items.Add("Error: Server disconnected");
        }

        //button method to connect pipe server. connects to the text box inputted named pipe. checks if pipe is already connected
        private void BtnConnectPipe_Click(object sender, EventArgs e)
        {
            if (!pipeClient.Connected) //check if not already connected
            {
                pipeClient.Connect(tbPipeName.Text);
                if (pipeClient.Connected) //if connection is successful
                {
                    lbLogDisplay.Items.Add("You have been connected to the server");
                    SendMessage("Client connected to server");
                    btnConnectPipe.Enabled = false;
                    btnDisconnectPipe.Enabled = true;
                    btnUserLogin.Enabled = true;
                    btnSendMessage.Enabled = true;
                }
                else
                {
                    lbLogDisplay.Items.Add("Error: Connection failed");
                }
            }
        }

        //button method for disconnect pipe server
        private void BtnDisconnectPipe_Click(object sender, EventArgs e)
        {
            if (pipeClient.Connected)
            {
                pipeClient.Disconnect();
                EnableStartButton();
                lbLogDisplay.Items.Add("You have been manually disconnected from server");
                btnDisconnectPipe.Enabled = false;
            }
        }
        //--------------------END PIPE CLIENT--------------------//

        //--------------------USER FUCTIONS GROUP BOX--------------------//
        //button method for user login uses ascii encoding
        private void BtnUserLogin_Click(object sender, EventArgs e)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            pipeClient.SendMessage(encoder.GetBytes(tbUsername.Text + "," + tbPassword.Text));
            lbLogDisplay.Items.Add("Username: " + tbUsername.Text);
            lbLogDisplay.Items.Add("Password: " + tbPassword.Text);
            ClearClientTextboxes();
        }

        //button method to clear user text boxes
        private void ClearClientTextboxes()
        {
            tbUsername.Clear();
            tbPassword.Clear();
        }//end clear method

        //--------------------END USERS GROUP BOX--------------------//

        //--------------------MESSAGING GROUP BOX--------------------//

        //button method to send message to client, calls on the private method
        private void BtnSendMessage_Click(object sender, EventArgs e)
        {
            if (pipeClient.Connected)
            {
                SendMessage(tbSendMessage.Text);
            }
        }

        //private method to send message to server used by button method. uses bytes stored in an array to transfer string
        private void SendMessage(string message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] messageBuffer = encoder.GetBytes(message);
            pipeClient.SendMessage(messageBuffer);
            if (!string.IsNullOrEmpty(tbSendMessage.Text)) //eliminates a blank message displayed on connection
            {
                lbLogDisplay.Items.Add(tbSendMessage.Text); //display the message on both logs
            }
        }

        //method to handle a message received from server passes to DisplayMessageReceived method
        void PipeClient_MessageReceived(byte[] message)
        {
            Invoke(new PipeClient.MessageReceivedHandler(DisplayMessageReceived), new object[] { message });
        }

        //display message from server method
        void DisplayMessageReceived(byte[] message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            string str = encoder.GetString(message, 0, message.Length);
            //if login successful
            if (str == "Login success")
            {
                lbLogDisplay.Items.Add("Server sent message: " + str);
                btnSecurityApp.Enabled = true;
                EnableMediaPlayerButtons();
            }//if username password string info
            else if (str.Contains("."))
            {
                lbLogDisplay.Items.Add("Server sent message: ");
                string[] data = str.Split('.');
                for (int i = 0; i < data.Length; i++)
                {
                    lbLogDisplay.Items.Add(data[i] + "\r\n");
                }
            }//if other messaging
            else
            {
                lbLogDisplay.Items.Add("Server sent message: " + str);
            }
            //add more instances here to enable other apps etc using keywords sent by server
        }

        //button method to clear the log listBox
        private void BtnClearMessageLog_Click(object sender, EventArgs e)
        {
            lbLogDisplay.Items.Clear();
        }
        //--------------------END MESSAGING GROUP BOX--------------------//

        //--------------------SECURITY APP--------------------//
        private void BtnSecurityApp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Security has been enabled due to successful server login!");
        }

        //--------------------END SECURITY APP--------------------//

        //--------------------MEDIA PLAYER GROUP BOX--------------------//
        
        //global variable for current track
        string currentTrack = "a";
        string defaultPath = "./";
        //Node<string> current;
        

        //method to disable functions until login is successful
        private void DisableMediaPlayerButtons()
        {
            btnAddTracks.Enabled = false;
            btnDeleteTrack.Enabled = false;
            btnClearAllTracks.Enabled = false;
            btnPlay.Enabled = false;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            btnSaveTrackList.Enabled = false;
            btnTrackSearch.Enabled = false;
            
        }
        //method to enable functions once login is successful
        private void EnableMediaPlayerButtons()
        {
            btnAddTracks.Enabled = true;
            btnDeleteTrack.Enabled = true;
            btnClearAllTracks.Enabled = true;
            btnPlay.Enabled = true;
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
            btnSaveTrackList.Enabled = true;
            btnTrackSearch.Enabled = true;
        }

        private void BtnAddTracks_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Multiselect = true,
                Filter = "WMA|*.wma|WMV|*.wmv|WAV|*wav|MP3|*.mp3|MP4|*.mp4|MKV|*.mkv"
            })
            {
                
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Node<string> head;
                    //List<Track> files = new List<Track>();
                    foreach (string fileName in fileDialog.FileNames)
                    {
                        //put this info into a file object
                        FileInfo file = new FileInfo(fileName);
                        //obtain path and name information as strings
                        string name = Path.GetFileNameWithoutExtension(file.FullName);
                        string path = file.FullName;
                        //create a node object with name and path as attributes
                        Node<string> track = new Node<string>(name, path);
                        Node<string> current;
                        //if list is empty make first node the head
                        if (trackList.Count == 0)
                        {
                            trackList.AddFirst(track);
                            //head = track;
                        }
                        else
                        {
                            current = trackList.Last();
                            current.next = track;
                            //track.prev = current;
                            trackList.AddLast(track);
                        }           
                    }
                    //declare the head of the list
                    //Node<string> head = trackList.First.Value;
                    //head.next = trackList.First.Next;
                    //now sort the linked list using merge sort method and head as input
                    Node<string> sortedHead = trackList.First.Value.mergeSort(trackList.First.Value);
                    //create new linked list of sorted tracks
                    LinkedList<Node<string>> sortedTrackList = new LinkedList<Node<string>>();
                    Node<string> temp = sortedHead;


                    if ((sortedHead != null) && (sortedTrackList.Count == 0))
                    {
                        //add the new sorted nodes to a new linked list
                        while (temp != null)
                        {
                            sortedTrackList.AddLast(temp);
                            temp = temp.next;
                        }
                    }
                    else
                    {
                        //clear the list
                        for (int i = 0; i < sortedTrackList.Count; i++)
                        {
                            sortedTrackList.RemoveFirst();
                        }
                        //add the new sorted nodes to a new linked list
                        while (temp != null)
                        {
                            sortedTrackList.AddLast(temp);
                            temp = temp.next;
                        }
                    }
                    //pass this into a new linked list
                    //if (sortedTrackList.Count == 0)
                    //{
                    //    sortedTrackList.AddFirst(sortedHead);
                    //    Node<string> current = sortedHead.next;

                    //    if (sortedHead.next != null)
                    //    {
                    //        //Node<string> current = sortedHead;
                    //        while (current.next != null)
                    //        {
                    //            Node<string> previous = current;
                    //            current = current.next;
                    //            //    current = current.next;
                    //            //    previous = current;
                    //        }
                    //    }
                    //}
                    //merge sort should return a sortedlinked list
                    //pass into a new linkedlist



                    //sortedHead.
                    //display sorted tracks in listBox

                    DisplayTracks(sortedHead);
                    //set current song to first in list
                    //current = trackList.First();

                }
            }
        }

        private void DisplayTracks(Node<string> sortedHead)
        {
            lbTracks.Items.Clear();
            Node<string> temp = sortedHead;
            while (temp != null)
            {
                lbTracks.Items.Add(temp.name);
                temp = temp.next;
            }
            //if (trackList.Count > 0)
            //{
            //    try
            //    {
            //        for (int i = 0; i < trackList.Count; i++)
            //        {
            //            string item = trackList.ElementAt<Node<string>>(i).name;
            //            lbTracks.Items.Add(item);
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        MessageBox.Show("something went wrong " + e);

            //    }
            //}
        }

        private void BtnDeleteTrack_Click(object sender, EventArgs e)
        {

        }

        private void BtnClearAllTracks_Click(object sender, EventArgs e)
        {

        }

        private void BtnTrackSearch_Click(object sender, EventArgs e)
        {

        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {

        }

        private void BtnPause_Click(object sender, EventArgs e)
        {

        }

        private void BtnStop_Click(object sender, EventArgs e)
        {

        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                //string next = sortedTrackList.Find(current).Next.Value;
                //current = next;
                //PlayTracks(current);
            }
            catch
            {
                MessageBox.Show("Error: Cannot play next song");
            }
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                //Track prev = sortedTrackList.Find(current).Previous.Value;
                //current = prev;
                //PlayTracks(current);
            }
            catch
            {
                MessageBox.Show("Error: Cannot play previous song");
            }
        }

        //method to save track list to .csv
        private void BtnSaveTrackList_Click(object sender, EventArgs e)
        {

        }

        //method to play songs
        private void PlayTracks(string track)
        {
            try
            {
                //axWindowsMediaPlayer.URL = track.Path;
            }
            catch
            {
                MessageBox.Show("Error: Cannot play");
            }
        }

        //method to set the selected tracks path and play it
        private void LbTracks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string track = lbTracks.SelectedItem as string;
            if (track != null)
            {
                //axWindowsMediaPlayer.URL = track.Path;
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
        }

        //--------------------END MEDIA PLAYER GROUP BOX--------------------//
    }
}
