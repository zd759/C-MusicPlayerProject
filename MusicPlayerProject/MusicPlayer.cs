using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CsvHelper; //using 3rd party library

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
        TrackLinkedList<string> trackList = new TrackLinkedList<string>();
        //create another list for storing the final sorted list to be displayed to user
        TrackLinkedList<string> sortedTrackList = new TrackLinkedList<string>();

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
            toolStripStatusLabel.Text = "";
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
                    toolStripStatusLabel.Text = ("Success: You have been connected to the server");
                }
                else
                {
                    lbLogDisplay.Items.Add("Error: Connection failed");
                    toolStripStatusLabel.Text = ("Error: Server connection failed");
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
                DisableMediaPlayerButtons();
                toolStripStatusLabel.Text = ("Error: Server has been manually disconnected");
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
            toolStripStatusLabel.Text = "";
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
                toolStripStatusLabel.Text = "Success! Client successfully logged in to server";
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
        Node<string> currentTrack = null;

        //method to disable functions until client login is successful
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
            btnBinarySearch.Enabled = false;
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
            btnBinarySearch.Enabled = true;
        }

        //method to add user selected files (of certain audio formats) to listbox
        //and to the linked list, while also sorting them with a merge sort
        private void BtnAddTracks_Click(object sender, EventArgs e)
        {
            //use open file dialog
            using (OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Multiselect = true,
                //InitialDirectory = ".\",
                //accepted files types
                Filter = "WMA|*.wma|WMV|*.wmv|WAV|*wav|MP3|*.mp3|MP4|*.mp4|MKV|*.mkv"
            })
            {
                //if the user presses 'ok'
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    //set the sorted track list to the unsorted - used if user add files multiple times
                    //this serves to correct the node values of 'next' and 'prev' in the unsorted list 
                    trackList = sortedTrackList;
                    //loop through the selected files and add as nodes to linked list
                    foreach (string fileName in fileDialog.FileNames)
                    {
                        //put this info into a file object
                        FileInfo file = new FileInfo(fileName);
                        //obtain path and name information as strings
                        string name = Path.GetFileNameWithoutExtension(file.FullName);
                        string path = file.FullName;
                        //if list isn't empty, check for dupes
                        if (trackList.GetLengthOfList() > 0)
                        {
                            Node<string> checkDupe = trackList.CheckForDuplicate(name);
                            if (checkDupe == null) //not not null, isnt added
                            {
                                //call add method
                                trackList.AddLastNode(name, path);
                            }
                        }
                        else
                        {
                            trackList.AddLastNode(name, path);
                        }
                    }
                    //null a new head object (useful if user adds files multiple times)
                    Node<string> newHead = null;
                    //set the new head object to the first place of the sorted list
                    newHead = trackList.MergeSort(trackList.getHead());
                    //clear the sorted list (in case of user adding songs multiple times)
                    sortedTrackList = new TrackLinkedList<string>();
                    //use a temp node object to traverse the sorted head nodes and store them in the sorted linked list
                    Node<string> temp = newHead;
                    while (temp != null)
                    {
                        sortedTrackList.AddLastNode(temp.getName(), temp.getPath());
                        temp = temp.next;
                    }
                    //display sorted tracks in listBox
                    DisplayTracks();
                    //set current song to first in list
                    currentTrack = newHead;
                }
            }
            toolStripStatusLabel.Text = "Success! Tracks have been added";
        }
    
        //method to display sorted track list in listbox
        private void DisplayTracks()
        {
            lbTracks.Items.Clear();
            Node<string> temp = sortedTrackList.getHead();
            while (temp != null)
            {
                lbTracks.Items.Add(temp.getName());
                temp = temp.next;
            }
        }

        //method to delete track from sorted list and listbox
        private void BtnDeleteTrack_Click(object sender, EventArgs e)
        {
            if (lbTracks.SelectedIndex != -1)
            {
                string name = lbTracks.SelectedItem.ToString();
                DialogResult res = MessageBox.Show(
                    "Are you sure you want to delete this track?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    sortedTrackList.Remove(name);
                }
            }
            else
            {
                toolStripStatusLabel.Text = "Error: Please select a track to delete";
            }
            DisplayTracks();
        }

        private void BtnClearAllTracks_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to delete all music?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                sortedTrackList = new TrackLinkedList<string>();
                lbTracks.Items.Clear();
            }
            currentTrack = null;
            toolStripStatusLabel.Text = "All tracks cleared";
        }

        //method to search a custom user inpu string
        private void BtnBinarySearch_Click(object sender, EventArgs e)
        {
            if (sortedTrackList.getHead() != null)
            {
                string target = tbTrackSearch.Text;
                Node<string> result = sortedTrackList.BinarySearch(target);
                if (result != null)
                {
                    PlayMusic(currentTrack);
                    //status strip display result
                    toolStripStatusLabel.Text = "Target " + result.getName() + " found... Now playing";
                }
            }
            else
            {
                toolStripStatusLabel.Text = "Error: There aren't any songs to search!";
            }
        }

        //private play method used by most media player button functions
        private void PlayMusic(Node<string> path)
        {
            try
            {
                //change pointer for current node
                currentTrack = path;
                //play song at given node's path attribute
                axWindowsMediaPlayer.URL = path.getPath();
            }
            catch
            {
                toolStripStatusLabel.Text = "Error: Cannot play!";
            }
        }

        //button method for play changes selected index to play
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            //play selected index
            if (lbTracks.SelectedIndex != -1)
            {
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
            else //else play first song in list
            {
                lbTracks.SelectedItem = sortedTrackList.getHead().getName();
            }
        }

        //method to pause play
        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer.Ctlcontrols.pause();
            }
            else
            {
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
        }

        //method to stop play
        private void BtnStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.Ctlcontrols.stop();
        }

        //method to play next track in listbox, just changes to selected index thus passing to selected index method
        private void BtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                //axWindowsMediaPlayer.Ctlcontrols.next();
                //Node<string> next = sortedTrackList.BinarySearch(currentTrack.getName()).next;

                //change the selected index which calls the selected index changed method
                lbTracks.SelectedItem = currentTrack.next.getName();
            }
            catch
            {
                toolStripStatusLabel.Text = "Error: There is no next song to play";
            }
        }

        //method to play previous track in list, similar to next button method
        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                lbTracks.SelectedItem = currentTrack.prev.getName();
            }
            catch
            {
                toolStripStatusLabel.Text = "Error: There is no previous song to play";
            }
        }

        //method to set the selected tracks path and play it
        private void LbTracks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTracks.SelectedIndex != -1)
            {
                //search the title which returns a node, play the path of that node
                string title = lbTracks.SelectedItem.ToString();
                Node<string> current = sortedTrackList.BinarySearch(title);
                currentTrack = current;
                PlayMusic(currentTrack);
            }
        }

        //method to save track list to .csv
        private void BtnSaveTrackList_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog fileDialog = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileDialog.FileName))
                    using (CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                    {
                        //make a list to store linked list objects to be written to csv as linked list has no enumerator
                        List<Node<string>> records = new List<Node<string>>();
                        //traverse sorted linked list and add nodes to new list for saving
                        Node<string> temp = sortedTrackList.getHead();
                        while (temp != null)
                        {
                            records.Add(temp);
                            temp = temp.next;
                        }
                        //write headers
                        //streamWriter.WriteLine("Song Name,Song Path");//,Next Song Name,Next Song Path,Previous Song Name,Previous Song Path");
                        //traverse the objects in the list writing the relevent info in columns
                        foreach (var trackList in records)
                        {
                            if (trackList.prev == null)
                            {
                                csvWriter.WriteField(trackList.getName());
                                csvWriter.WriteField(trackList.getPath());
                                //csvWriter.WriteField(trackList.next.getName());
                                //csvWriter.WriteField(trackList.next.getPath());
                                //csvWriter.WriteField("NULL");
                                //csvWriter.WriteField("NULL");
                            }
                            else if (trackList.next == null)
                            {
                                csvWriter.WriteField(trackList.getName());
                                csvWriter.WriteField(trackList.getPath());
                                //csvWriter.WriteField("NULL");
                                //csvWriter.WriteField("NULL");
                                //csvWriter.WriteField(trackList.prev.getName());
                                //csvWriter.WriteField(trackList.prev.getPath());
                            }
                            else
                            {
                                csvWriter.WriteField(trackList.getName());
                                csvWriter.WriteField(trackList.getPath());
                                //csvWriter.WriteField(trackList.next.getName());
                                //csvWriter.WriteField(trackList.next.getPath());
                                //csvWriter.WriteField(trackList.prev.getName());
                                //csvWriter.WriteField(trackList.prev.getPath());
                            }//go to next record
                            csvWriter.NextRecord();
                        }
                        //flush the stream
                        streamWriter.Flush();
                    }//once using block is exited, writer is automatically flushed
                }
            }
            toolStripStatusLabel.Text = "Success: Track list saved to file";
        }//end csv writer

        //method to load track list from .csv file
        //private void BtnLoadTrackList_Click(object sender, EventArgs e)
        //{
        //    using (OpenFileDialog fileDialog = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
        //    {
        //        if (fileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            using (StreamReader streamReader = new StreamReader(new FileStream(fileDialog.FileName, FileMode.Open)))
        //            using (CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
        //            {
        //                while (csvReader.Read())
        //                {
        //                }
        //            }
        //        }
                
        //    }
        //}

        //--------------------END MEDIA PLAYER GROUP BOX--------------------//
    }
}
