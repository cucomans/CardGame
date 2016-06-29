using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;


namespace Client
{
    public partial class MainDisplay : Form
    {

        List<string> _items = new List<string>(); //sounds list

        public MainDisplay()
        {
            InitializeComponent();
            _items.Add("zumbido");
            _items.Add("dormischu");
            _items.Add("que loro");
            _items.Add("vuela una");


            listBox1.DataSource = _items;
            listBox1.Enabled = false;
        }

        NetComm.Client client; //The client object used for the communication
        private void MainDisplay_Load(object sender, EventArgs e)
        {
            client = new NetComm.Client(); //Initialize the client object

            //Adding event handling methods for the client
            client.Connected += new NetComm.Client.ConnectedEventHandler(client_Connected);
            client.Disconnected += new NetComm.Client.DisconnectedEventHandler(client_Disconnected);
            client.DataReceived += new NetComm.Client.DataReceivedEventHandler(client_DataReceived);

            //Connecting to the host
            //client.Connect("localhost", 2020, "Jack"); //Connecting to the host (on the same machine) with port 2020 and ID "Jack"
        }

        private void MainDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client.isConnected) client.Disconnect(); //Disconnects if the client is connected, closing the communication thread
        }
        void player_print1(Byte[] Data, string ID)
        {
            string aux = ConvertBytesToString(Data);

            if (ID == null)
            {
                switch (aux)
                {
                    case "*oro1c1p1":
                        c1p1.Image = Properties.Resources.culosucio;
                        break;
                    case "basto12c1p1":
                        c1p1.Image = Properties.Resources.basto9;
                        break;
                    case "basto9c1p1":
                        c1p1.Image = Properties.Resources.copa10;
                        break;
                    case "copa10c1p1":
                        c1p1.Image = Properties.Resources.copa11;
                        break;
                    case "copa11c1p1":
                        c1p1.Image = Properties.Resources.copa5;
                        break;
                    case "copa5c1p1":
                        c1p1.Image = Properties.Resources.copa6;
                        break;
                    case "copa6c1p1":
                        c1p1.Image = Properties.Resources.basto12;
                        break;
                    case "esp2c1p1":
                        c1p1.Image = Properties.Resources.esp2;
                        break;
                    case "esp3c1p1":
                        c1p1.Image = Properties.Resources.esp3;
                        break;
                    case "esp7c1p1":
                        c1p1.Image = Properties.Resources.esp7;
                        break;
                    case "esp8c1p1":
                        c1p1.Image = Properties.Resources.esp8;
                        break;
                    case "oro4c1p1":
                        c1p1.Image = Properties.Resources.oro4;
                        break;


                        //el cp3 se cambio para todos mal ahi
                        //
                }
            }
        }
        void player_print2(Byte[] Data, string ID)
        { }
        void player_print3(Byte[] Data, string ID)
        { }
        void player_PrintImg(Byte[] Data, string ID)
        {
            //player 1 carta 1 cxo cxo 
            if (ConvertBytesToString(Data).Substring(ConvertBytesToString(Data).Length - 1, 1) == "1" && ConvertBytesToString(Data)[0].ToString() == "*")
            {
                c1p1.Visible = true;
                player_print1(Data, ID);
            }
            else
            {                                                //player 2 carta 1 cxo cxo              
                if (ConvertBytesToString(Data).Substring(ConvertBytesToString(Data).Length - 1, 1) == "2" && ConvertBytesToString(Data)[0].ToString() == "*")
                {
                    c1p2.Visible = true;
                    player_print2(Data, ID);
                }
                else
                {
                    if (ConvertBytesToString(Data).Substring(ConvertBytesToString(Data).Length - 1, 1) == "3" && ConvertBytesToString(Data)[0].ToString() == "*")
                        c1p3.Visible = true;
                }
            }
        }

        void displayDormischu()
        {
            dormischu.Visible = true;
        }

        void hideDormischu()
        {
            dormischu.Visible = false;

        }

        void switch_player1(char carta, int num)
        {
            switch (carta)
            {
                case '1':
                    c1p1.Visible = true;
                    switch (num)
                    {
                        case 1:

                            c1p1.Image = Properties.Resources.culosucio;
                            c1p1.Refresh();
                            break;
                        case 2:
                            c1p1.Image = Properties.Resources.esp2;
                            c1p1.Refresh();
                            break;
                        case 3:
                            c1p1.Image = Properties.Resources.esp3;
                            c1p1.Refresh();
                            break;
                        case 4:
                            c1p1.Image = Properties.Resources.oro4;
                            c1p1.Refresh();
                            break;
                        case 5:
                            c1p1.Image = Properties.Resources.copa5;
                            c1p1.Refresh();
                            break;
                        case 6:
                            c1p1.Image = Properties.Resources.copa6;
                            c1p1.Refresh();
                            break;
                        case 7:
                            c1p1.Image = Properties.Resources.esp7;
                            c1p1.Refresh();
                            break;
                        case 8:
                            c1p1.Image = Properties.Resources.esp8;
                            c1p1.Refresh();
                            break;
                        case 9:
                            c1p1.Image = Properties.Resources.basto9;
                            c1p1.Refresh();
                            break;
                        case 10:
                            c1p1.Image = Properties.Resources.copa10;
                            c1p1.Refresh();
                            break;
                        case 11:
                            c1p1.Image = Properties.Resources.copa11;
                            c1p1.Refresh();
                            break;
                        case 12:
                            c1p1.Image = Properties.Resources.basto12;
                            c1p1.Refresh();
                            break;

                    }
                    break;
                case '2':
                    c2p1.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c2p1.Image = Properties.Resources.culosucio;
                            c2p1.Refresh();
                            break;
                        case 2:
                            c2p1.Image = Properties.Resources.esp2;
                            c2p1.Refresh();
                            break;
                        case 3:
                            c2p1.Image = Properties.Resources.esp3;
                            c2p1.Refresh();
                            break;
                        case 4:
                            c2p1.Image = Properties.Resources.oro4;
                            c2p1.Refresh();
                            break;
                        case 5:
                            c2p1.Image = Properties.Resources.copa5;
                            c2p1.Refresh();
                            break;
                        case 6:
                            c2p1.Image = Properties.Resources.copa6;
                            c2p1.Refresh();
                            break;
                        case 7:
                            c2p1.Image = Properties.Resources.esp7;
                            c2p1.Refresh();
                            break;
                        case 8:
                            c2p1.Image = Properties.Resources.esp8;
                            c2p1.Refresh();
                            break;
                        case 9:
                            c2p1.Image = Properties.Resources.basto9;
                            c2p1.Refresh();
                            break;
                        case 10:
                            c2p1.Image = Properties.Resources.copa10;
                            c2p1.Refresh();
                            break;
                        case 11:
                            c2p1.Image = Properties.Resources.copa11;
                            c2p1.Refresh();
                            break;
                        case 12:
                            c2p1.Image = Properties.Resources.basto12;
                            c2p1.Refresh();
                            break;

                    }
                    break;
                case '3':
                    c3p1.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c3p1.Image = Properties.Resources.culosucio;
                            c3p1.Refresh();
                            break;
                        case 2:
                            c3p1.Image = Properties.Resources.esp2;
                            c3p1.Refresh();
                            break;
                        case 3:
                            c3p1.Image = Properties.Resources.esp3;
                            c3p1.Refresh();
                            break;
                        case 4:
                            c3p1.Image = Properties.Resources.oro4;
                            c3p1.Refresh();
                            break;
                        case 5:
                            c3p1.Image = Properties.Resources.copa5;
                            c3p1.Refresh();
                            break;
                        case 6:
                            c3p1.Image = Properties.Resources.copa6;
                            c3p1.Refresh();
                            break;
                        case 7:
                            c3p1.Image = Properties.Resources.esp7;
                            c3p1.Refresh();
                            break;
                        case 8:
                            c3p1.Image = Properties.Resources.esp8;
                            c3p1.Refresh();
                            break;
                        case 9:
                            c3p1.Image = Properties.Resources.basto9;
                            c3p1.Refresh();
                            break;
                        case 10:
                            c3p1.Image = Properties.Resources.copa10;
                            c3p1.Refresh();
                            break;
                        case 11:
                            c3p1.Image = Properties.Resources.copa11;
                            c3p1.Refresh();
                            break;
                        case 12:
                            c3p1.Image = Properties.Resources.basto12;
                            c3p1.Refresh();
                            break;

                    }
                    break;
                case '4':
                    c4p1.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c4p1.Image = Properties.Resources.culosucio;
                            c4p1.Refresh();
                            break;
                        case 2:
                            c4p1.Image = Properties.Resources.esp2;
                            c4p1.Refresh();
                            break;
                        case 3:
                            c4p1.Image = Properties.Resources.esp3;
                            c4p1.Refresh();
                            break;
                        case 4:
                            c4p1.Image = Properties.Resources.oro4;
                            c4p1.Refresh();
                            break;
                        case 5:
                            c4p1.Image = Properties.Resources.copa5;
                            c4p1.Refresh();
                            break;
                        case 6:
                            c4p1.Image = Properties.Resources.copa6;
                            c4p1.Refresh();
                            break;
                        case 7:
                            c4p1.Image = Properties.Resources.esp7;
                            c4p1.Refresh();
                            break;
                        case 8:
                            c4p1.Image = Properties.Resources.esp8;
                            c4p1.Refresh();
                            break;
                        case 9:
                            c4p1.Image = Properties.Resources.basto9;
                            c4p1.Refresh();
                            break;
                        case 10:
                            c4p1.Image = Properties.Resources.copa10;
                            c4p1.Refresh();
                            break;
                        case 11:
                            c4p1.Image = Properties.Resources.copa11;
                            c4p1.Refresh();
                            break;
                        case 12:
                            c4p1.Image = Properties.Resources.basto12;
                            c4p1.Refresh();
                            break;

                    }
                    break;
                case '5':
                    c5p1.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c5p1.Image = Properties.Resources.culosucio;
                            c5p1.Refresh();
                            break;
                        case 2:
                            c5p1.Image = Properties.Resources.esp2;
                            c5p1.Refresh();
                            break;
                        case 3:
                            c5p1.Image = Properties.Resources.esp3;
                            c5p1.Refresh();
                            break;
                        case 4:
                            c5p1.Image = Properties.Resources.oro4;
                            c5p1.Refresh();
                            break;
                        case 5:
                            c5p1.Image = Properties.Resources.copa5;
                            c5p1.Refresh();
                            break;
                        case 6:
                            c5p1.Image = Properties.Resources.copa6;
                            c5p1.Refresh();
                            break;
                        case 7:
                            c5p1.Image = Properties.Resources.esp7;
                            c5p1.Refresh();
                            break;
                        case 8:
                            c5p1.Image = Properties.Resources.esp8;
                            c5p1.Refresh();
                            break;
                        case 9:
                            c5p1.Image = Properties.Resources.basto9;
                            c5p1.Refresh();
                            break;
                        case 10:
                            c5p1.Image = Properties.Resources.copa10;
                            c4p1.Refresh();
                            break;
                        case 11:
                            c5p1.Image = Properties.Resources.copa11;
                            c5p1.Refresh();
                            break;
                        case 12:
                            c5p1.Image = Properties.Resources.basto12;
                            c5p1.Refresh();
                            break;

                    }
                    break;
                case '6':
                    c6p1.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c6p1.Image = Properties.Resources.culosucio;
                            c6p1.Refresh();
                            break;
                        case 2:
                            c6p1.Image = Properties.Resources.esp2;
                            c6p1.Refresh();
                            break;
                        case 3:
                            c6p1.Image = Properties.Resources.esp3;
                            c6p1.Refresh();
                            break;
                        case 4:
                            c6p1.Image = Properties.Resources.oro4;
                            c6p1.Refresh();
                            break;
                        case 5:
                            c6p1.Image = Properties.Resources.copa5;
                            c6p1.Refresh();
                            break;
                        case 6:
                            c6p1.Image = Properties.Resources.copa6;
                            c6p1.Refresh();
                            break;
                        case 7:
                            c6p1.Image = Properties.Resources.esp7;
                            c6p1.Refresh();
                            break;
                        case 8:
                            c6p1.Image = Properties.Resources.esp8;
                            c6p1.Refresh();
                            break;
                        case 9:
                            c6p1.Image = Properties.Resources.basto9;
                            c6p1.Refresh();
                            break;
                        case 10:
                            c6p1.Image = Properties.Resources.copa10;
                            c6p1.Refresh();
                            break;
                        case 11:
                            c6p1.Image = Properties.Resources.copa11;
                            c6p1.Refresh();
                            break;
                        case 12:
                            c6p1.Image = Properties.Resources.basto12;
                            c6p1.Refresh();
                            break;
                    }
                    break;
                case '7':
                    c7p1.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c7p1.Image = Properties.Resources.culosucio;
                            c7p1.Refresh();
                            break;
                        case 2:
                            c7p1.Image = Properties.Resources.esp2;
                            c7p1.Refresh();
                            break;
                        case 3:
                            c7p1.Image = Properties.Resources.esp3;
                            c7p1.Refresh();
                            break;
                        case 4:
                            c7p1.Image = Properties.Resources.oro4;
                            c7p1.Refresh();
                            break;
                        case 5:
                            c7p1.Image = Properties.Resources.copa5;
                            c7p1.Refresh();
                            break;
                        case 6:
                            c7p1.Image = Properties.Resources.copa6;
                            c7p1.Refresh();
                            break;
                        case 7:
                            c7p1.Image = Properties.Resources.esp7;
                            c7p1.Refresh();
                            break;
                        case 8:
                            c7p1.Image = Properties.Resources.esp8;
                            c7p1.Refresh();
                            break;
                        case 9:
                            c7p1.Image = Properties.Resources.basto9;
                            c7p1.Refresh();
                            break;
                        case 10:
                            c7p1.Image = Properties.Resources.copa10;
                            c7p1.Refresh();
                            break;
                        case 11:
                            c7p1.Image = Properties.Resources.copa11;
                            c7p1.Refresh();
                            break;
                        case 12:
                            c7p1.Image = Properties.Resources.basto12;
                            c7p1.Refresh();
                            break;
                    }
                    break;
            }

        }
        void switch_player2(char carta, int num)
        {
            switch (carta)
            {
                case '1':
                    c1p2.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c1p2.Image = Properties.Resources.culosucio;
                            c1p2.Refresh();
                            break;
                        case 2:
                            c1p2.Image = Properties.Resources.esp2;
                            c1p2.Refresh();
                            break;
                        case 3:
                            c1p2.Image = Properties.Resources.esp2;
                            c1p2.Refresh();
                            break;
                        case 4:
                            c1p2.Image = Properties.Resources.oro4;
                            c1p2.Refresh();
                            break;
                        case 5:
                            c1p2.Image = Properties.Resources.copa5;
                            c1p2.Refresh();
                            break;
                        case 6:
                            c1p2.Image = Properties.Resources.copa6;
                            c1p2.Refresh();
                            break;
                        case 7:
                            c1p2.Image = Properties.Resources.esp7;
                            c1p2.Refresh();
                            break;
                        case 8:
                            c1p2.Image = Properties.Resources.esp8;
                            c1p2.Refresh();
                            break;
                        case 9:
                            c1p2.Image = Properties.Resources.basto9;
                            c1p2.Refresh();
                            break;
                        case 10:
                            c1p2.Image = Properties.Resources.copa10;
                            c1p2.Refresh();
                            break;
                        case 11:
                            c1p2.Image = Properties.Resources.copa11;
                            c1p2.Refresh();
                            break;
                        case 12:
                            c1p2.Image = Properties.Resources.basto12;
                            c1p2.Refresh();
                            break;

                    }
                    break;
                case '2':
                    c2p2.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c2p2.Image = Properties.Resources.culosucio;
                            c2p2.Refresh();
                            break;
                        case 2:
                            c2p2.Image = Properties.Resources.esp2;
                            c2p2.Refresh();
                            break;
                        case 3:
                            c2p2.Image = Properties.Resources.esp2;
                            c2p2.Refresh();
                            break;
                        case 4:
                            c2p2.Image = Properties.Resources.oro4;
                            c2p2.Refresh();
                            break;
                        case 5:
                            c2p2.Image = Properties.Resources.copa5;
                            c2p2.Refresh();
                            break;
                        case 6:
                            c2p2.Image = Properties.Resources.copa6;
                            c2p2.Refresh();
                            break;
                        case 7:
                            c2p2.Image = Properties.Resources.esp7;
                            c2p2.Refresh();
                            break;
                        case 8:
                            c2p2.Image = Properties.Resources.esp8;
                            c2p2.Refresh();
                            break;
                        case 9:
                            c2p2.Image = Properties.Resources.basto9;
                            c2p2.Refresh();
                            break;
                        case 10:
                            c2p2.Image = Properties.Resources.copa10;
                            c2p2.Refresh();
                            break;
                        case 11:
                            c2p2.Image = Properties.Resources.copa11;
                            c2p2.Refresh();
                            break;
                        case 12:
                            c2p2.Image = Properties.Resources.basto12;
                            c2p2.Refresh();
                            break;

                    }
                    break;
                case '3':
                    c3p2.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c3p2.Image = Properties.Resources.culosucio;
                            c3p2.Refresh();
                            break;
                        case 2:
                            c3p2.Image = Properties.Resources.esp2;
                            c3p2.Refresh();
                            break;
                        case 3:
                            c3p2.Image = Properties.Resources.esp2;
                            c3p2.Refresh();
                            break;
                        case 4:
                            c3p2.Image = Properties.Resources.oro4;
                            c3p2.Refresh();
                            break;
                        case 5:
                            c3p2.Image = Properties.Resources.copa5;
                            c3p2.Refresh();
                            break;
                        case 6:
                            c3p2.Image = Properties.Resources.copa6;
                            c3p2.Refresh();
                            break;
                        case 7:
                            c3p2.Image = Properties.Resources.esp7;
                            c3p2.Refresh();
                            break;
                        case 8:
                            c3p2.Image = Properties.Resources.esp8;
                            c3p2.Refresh();
                            break;
                        case 9:
                            c3p2.Image = Properties.Resources.basto9;
                            c3p2.Refresh();
                            break;
                        case 10:
                            c3p2.Image = Properties.Resources.copa10;
                            c3p2.Refresh();
                            break;
                        case 11:
                            c3p2.Image = Properties.Resources.copa11;
                            c3p2.Refresh();
                            break;
                        case 12:
                            c3p2.Image = Properties.Resources.basto12;
                            c3p2.Refresh();
                            break;

                    }
                    break;
                case '4':
                    c4p2.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c4p2.Image = Properties.Resources.culosucio;
                            c4p2.Refresh();
                            break;
                        case 2:
                            c4p2.Image = Properties.Resources.esp2;
                            c4p2.Refresh();
                            break;
                        case 3:
                            c4p2.Image = Properties.Resources.esp2;
                            c4p2.Refresh();
                            break;
                        case 4:
                            c4p2.Image = Properties.Resources.oro4;
                            c4p2.Refresh();
                            break;
                        case 5:
                            c4p2.Image = Properties.Resources.copa5;
                            c4p2.Refresh();
                            break;
                        case 6:
                            c4p2.Image = Properties.Resources.copa6;
                            c4p2.Refresh();
                            break;
                        case 7:
                            c4p2.Image = Properties.Resources.esp7;
                            c4p2.Refresh();
                            break;
                        case 8:
                            c4p2.Image = Properties.Resources.esp8;
                            c4p2.Refresh();
                            break;
                        case 9:
                            c4p2.Image = Properties.Resources.basto9;
                            c4p2.Refresh();
                            break;
                        case 10:
                            c4p2.Image = Properties.Resources.copa10;
                            c4p2.Refresh();
                            break;
                        case 11:
                            c4p2.Image = Properties.Resources.copa11;
                            c4p2.Refresh();
                            break;
                        case 12:
                            c4p2.Image = Properties.Resources.basto12;
                            c4p2.Refresh();
                            break;

                    }
                    break;
                case '5':
                    c5p2.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c5p2.Image = Properties.Resources.culosucio;
                            c5p2.Refresh();
                            break;
                        case 2:
                            c5p2.Image = Properties.Resources.esp2;
                            c5p2.Refresh();
                            break;
                        case 3:
                            c5p2.Image = Properties.Resources.esp2;
                            c5p2.Refresh();
                            break;
                        case 4:
                            c5p2.Image = Properties.Resources.oro4;
                            c5p2.Refresh();
                            break;
                        case 5:
                            c5p2.Image = Properties.Resources.copa5;
                            c5p2.Refresh();
                            break;
                        case 6:
                            c5p2.Image = Properties.Resources.copa6;
                            c5p2.Refresh();
                            break;
                        case 7:
                            c5p2.Image = Properties.Resources.esp7;
                            c5p2.Refresh();
                            break;
                        case 8:
                            c5p2.Image = Properties.Resources.esp8;
                            c5p2.Refresh();
                            break;
                        case 9:
                            c5p2.Image = Properties.Resources.basto9;
                            c5p2.Refresh();
                            break;
                        case 10:
                            c5p2.Image = Properties.Resources.copa10;
                            c4p2.Refresh();
                            break;
                        case 11:
                            c5p2.Image = Properties.Resources.copa11;
                            c5p2.Refresh();
                            break;
                        case 12:
                            c5p2.Image = Properties.Resources.basto12;
                            c5p2.Refresh();
                            break;

                    }
                    break;
                case '6':
                    c6p2.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c6p2.Image = Properties.Resources.culosucio;
                            c6p2.Refresh();
                            break;
                        case 2:
                            c6p2.Image = Properties.Resources.esp2;
                            c6p2.Refresh();
                            break;
                        case 3:
                            c6p2.Image = Properties.Resources.esp2;
                            c6p2.Refresh();
                            break;
                        case 4:
                            c6p2.Image = Properties.Resources.oro4;
                            c6p2.Refresh();
                            break;
                        case 5:
                            c6p2.Image = Properties.Resources.copa5;
                            c6p2.Refresh();
                            break;
                        case 6:
                            c6p2.Image = Properties.Resources.copa6;
                            c6p2.Refresh();
                            break;
                        case 7:
                            c6p2.Image = Properties.Resources.esp7;
                            c6p2.Refresh();
                            break;
                        case 8:
                            c6p2.Image = Properties.Resources.esp8;
                            c6p2.Refresh();
                            break;
                        case 9:
                            c6p2.Image = Properties.Resources.basto9;
                            c6p2.Refresh();
                            break;
                        case 10:
                            c6p2.Image = Properties.Resources.copa10;
                            c6p2.Refresh();
                            break;
                        case 11:
                            c6p2.Image = Properties.Resources.copa11;
                            c6p2.Refresh();
                            break;
                        case 12:
                            c6p2.Image = Properties.Resources.basto12;
                            c6p2.Refresh();
                            break;
                    }
                    break;
                case '7':
                    c7p2.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c7p2.Image = Properties.Resources.culosucio;
                            c7p2.Refresh();
                            break;
                        case 2:
                            c7p2.Image = Properties.Resources.esp2;
                            c7p2.Refresh();
                            break;
                        case 3:
                            c7p2.Image = Properties.Resources.esp2;
                            c7p2.Refresh();
                            break;
                        case 4:
                            c7p2.Image = Properties.Resources.oro4;
                            c7p2.Refresh();
                            break;
                        case 5:
                            c7p2.Image = Properties.Resources.copa5;
                            c7p2.Refresh();
                            break;
                        case 6:
                            c7p2.Image = Properties.Resources.copa6;
                            c7p2.Refresh();
                            break;
                        case 7:
                            c7p2.Image = Properties.Resources.esp7;
                            c7p2.Refresh();
                            break;
                        case 8:
                            c7p2.Image = Properties.Resources.esp8;
                            c7p2.Refresh();
                            break;
                        case 9:
                            c7p2.Image = Properties.Resources.basto9;
                            c7p2.Refresh();
                            break;
                        case 10:
                            c7p2.Image = Properties.Resources.copa10;
                            c7p2.Refresh();
                            break;
                        case 11:
                            c7p2.Image = Properties.Resources.copa11;
                            c7p2.Refresh();
                            break;
                        case 12:
                            c7p2.Image = Properties.Resources.basto12;
                            c7p2.Refresh();
                            break;
                    }
                    break;
            }

        }
        void switch_player3(char carta, int num)
        {
            switch (carta)
            {
                case '1':
                    c1p3.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c1p3.Image = Properties.Resources.culosucio;
                            c1p3.Refresh();
                            break;
                        case 2:
                            c1p3.Image = Properties.Resources.esp2;
                            c1p3.Refresh();
                            break;
                        case 3:
                            c1p3.Image = Properties.Resources.esp3;
                            c1p3.Refresh();
                            break;
                        case 4:
                            c1p3.Image = Properties.Resources.oro4;
                            c1p3.Refresh();
                            break;
                        case 5:
                            c1p3.Image = Properties.Resources.copa5;
                            c1p3.Refresh();
                            break;
                        case 6:
                            c1p3.Image = Properties.Resources.copa6;
                            c1p3.Refresh();
                            break;
                        case 7:
                            c1p3.Image = Properties.Resources.esp7;
                            c1p3.Refresh();
                            break;
                        case 8:
                            c1p3.Image = Properties.Resources.esp8;
                            c1p3.Refresh();
                            break;
                        case 9:
                            c1p3.Image = Properties.Resources.basto9;
                            c1p3.Refresh();
                            break;
                        case 10:
                            c1p3.Image = Properties.Resources.copa10;
                            c1p3.Refresh();
                            break;
                        case 11:
                            c1p3.Image = Properties.Resources.copa11;
                            c1p3.Refresh();
                            break;
                        case 12:
                            c1p3.Image = Properties.Resources.basto12;
                            c1p3.Refresh();
                            break;

                    }
                    break;
                case '2':
                    c2p3.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c2p3.Image = Properties.Resources.culosucio;
                            c2p3.Refresh();
                            break;
                        case 2:
                            c2p3.Image = Properties.Resources.esp2;
                            c2p3.Refresh();
                            break;
                        case 3:
                            c2p3.Image = Properties.Resources.esp3;
                            c2p3.Refresh();
                            break;
                        case 4:
                            c2p3.Image = Properties.Resources.oro4;
                            c2p3.Refresh();
                            break;
                        case 5:
                            c2p3.Image = Properties.Resources.copa5;
                            c2p3.Refresh();
                            break;
                        case 6:
                            c2p3.Image = Properties.Resources.copa6;
                            c2p3.Refresh();
                            break;
                        case 7:
                            c2p3.Image = Properties.Resources.esp7;
                            c2p3.Refresh();
                            break;
                        case 8:
                            c2p3.Image = Properties.Resources.esp8;
                            c2p3.Refresh();
                            break;
                        case 9:
                            c2p3.Image = Properties.Resources.basto9;
                            c2p3.Refresh();
                            break;
                        case 10:
                            c2p3.Image = Properties.Resources.copa10;
                            c2p3.Refresh();
                            break;
                        case 11:
                            c2p3.Image = Properties.Resources.copa11;
                            c2p3.Refresh();
                            break;
                        case 12:
                            c2p3.Image = Properties.Resources.basto12;
                            c2p3.Refresh();
                            break;

                    }
                    break;
                case '3':
                    c3p3.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c3p3.Image = Properties.Resources.culosucio;
                            c3p3.Refresh();
                            break;
                        case 2:
                            c3p3.Image = Properties.Resources.esp2;
                            c3p3.Refresh();
                            break;
                        case 3:
                            c3p3.Image = Properties.Resources.esp3;
                            c3p3.Refresh();
                            break;
                        case 4:
                            c3p3.Image = Properties.Resources.oro4;
                            c3p3.Refresh();
                            break;
                        case 5:
                            c3p3.Image = Properties.Resources.copa5;
                            c3p3.Refresh();
                            break;
                        case 6:
                            c3p3.Image = Properties.Resources.copa6;
                            c3p3.Refresh();
                            break;
                        case 7:
                            c3p3.Image = Properties.Resources.esp7;
                            c3p3.Refresh();
                            break;
                        case 8:
                            c3p3.Image = Properties.Resources.esp8;
                            c3p3.Refresh();
                            break;
                        case 9:
                            c3p3.Image = Properties.Resources.basto9;
                            c3p3.Refresh();
                            break;
                        case 10:
                            c3p3.Image = Properties.Resources.copa10;
                            c3p3.Refresh();
                            break;
                        case 11:
                            c3p3.Image = Properties.Resources.copa11;
                            c3p3.Refresh();
                            break;
                        case 12:
                            c3p3.Image = Properties.Resources.basto12;
                            c3p3.Refresh();
                            break;

                    }
                    break;
                case '4':
                    c4p3.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c4p3.Image = Properties.Resources.culosucio;
                            c4p3.Refresh();
                            break;
                        case 2:
                            c4p3.Image = Properties.Resources.esp2;
                            c4p3.Refresh();
                            break;
                        case 3:
                            c4p3.Image = Properties.Resources.esp3;
                            c4p3.Refresh();
                            break;
                        case 4:
                            c4p3.Image = Properties.Resources.oro4;
                            c4p3.Refresh();
                            break;
                        case 5:
                            c4p3.Image = Properties.Resources.copa5;
                            c4p3.Refresh();
                            break;
                        case 6:
                            c4p3.Image = Properties.Resources.copa6;
                            c4p3.Refresh();
                            break;
                        case 7:
                            c4p3.Image = Properties.Resources.esp7;
                            c4p3.Refresh();
                            break;
                        case 8:
                            c4p3.Image = Properties.Resources.esp8;
                            c4p3.Refresh();
                            break;
                        case 9:
                            c4p3.Image = Properties.Resources.basto9;
                            c4p3.Refresh();
                            break;
                        case 10:
                            c4p3.Image = Properties.Resources.copa10;
                            c4p3.Refresh();
                            break;
                        case 11:
                            c4p3.Image = Properties.Resources.copa11;
                            c4p3.Refresh();
                            break;
                        case 12:
                            c4p3.Image = Properties.Resources.basto12;
                            c4p3.Refresh();
                            break;

                    }
                    break;
                case '5':
                    c5p3.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c5p3.Image = Properties.Resources.culosucio;
                            c5p3.Refresh();
                            break;
                        case 2:
                            c5p3.Image = Properties.Resources.esp2;
                            c5p3.Refresh();
                            break;
                        case 3:
                            c5p3.Image = Properties.Resources.esp3;
                            c5p3.Refresh();
                            break;
                        case 4:
                            c5p3.Image = Properties.Resources.oro4;
                            c5p3.Refresh();
                            break;
                        case 5:
                            c5p3.Image = Properties.Resources.copa5;
                            c5p3.Refresh();
                            break;
                        case 6:
                            c5p3.Image = Properties.Resources.copa6;
                            c5p3.Refresh();
                            break;
                        case 7:
                            c5p3.Image = Properties.Resources.esp7;
                            c5p3.Refresh();
                            break;
                        case 8:
                            c5p3.Image = Properties.Resources.esp8;
                            c5p3.Refresh();
                            break;
                        case 9:
                            c5p3.Image = Properties.Resources.basto9;
                            c5p3.Refresh();
                            break;
                        case 10:
                            c5p3.Image = Properties.Resources.copa10;
                            c4p3.Refresh();
                            break;
                        case 11:
                            c5p3.Image = Properties.Resources.copa11;
                            c5p3.Refresh();
                            break;
                        case 12:
                            c5p3.Image = Properties.Resources.basto12;
                            c5p3.Refresh();
                            break;

                    }
                    break;
                case '6':
                    c6p3.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c6p3.Image = Properties.Resources.culosucio;
                            c6p3.Refresh();
                            break;
                        case 2:
                            c6p3.Image = Properties.Resources.esp2;
                            c6p3.Refresh();
                            break;
                        case 3:
                            c6p3.Image = Properties.Resources.esp3;
                            c6p3.Refresh();
                            break;
                        case 4:
                            c6p3.Image = Properties.Resources.oro4;
                            c6p3.Refresh();
                            break;
                        case 5:
                            c6p3.Image = Properties.Resources.copa5;
                            c6p3.Refresh();
                            break;
                        case 6:
                            c6p3.Image = Properties.Resources.copa6;
                            c6p3.Refresh();
                            break;
                        case 7:
                            c6p3.Image = Properties.Resources.esp7;
                            c6p3.Refresh();
                            break;
                        case 8:
                            c6p3.Image = Properties.Resources.esp8;
                            c6p3.Refresh();
                            break;
                        case 9:
                            c6p3.Image = Properties.Resources.basto9;
                            c6p3.Refresh();
                            break;
                        case 10:
                            c6p3.Image = Properties.Resources.copa10;
                            c6p3.Refresh();
                            break;
                        case 11:
                            c6p3.Image = Properties.Resources.copa11;
                            c6p3.Refresh();
                            break;
                        case 12:
                            c6p3.Image = Properties.Resources.basto12;
                            c6p3.Refresh();
                            break;
                    }
                    break;
                case '7':
                    c7p3.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c7p3.Image = Properties.Resources.culosucio;
                            c7p3.Refresh();
                            break;
                        case 2:
                            c7p3.Image = Properties.Resources.esp2;
                            c7p3.Refresh();
                            break;
                        case 3:
                            c7p3.Image = Properties.Resources.esp3;
                            c7p3.Refresh();
                            break;
                        case 4:
                            c7p3.Image = Properties.Resources.oro4;
                            c7p3.Refresh();
                            break;
                        case 5:
                            c7p3.Image = Properties.Resources.copa5;
                            c7p3.Refresh();
                            break;
                        case 6:
                            c7p3.Image = Properties.Resources.copa6;
                            c7p3.Refresh();
                            break;
                        case 7:
                            c7p3.Image = Properties.Resources.esp7;
                            c7p3.Refresh();
                            break;
                        case 8:
                            c7p3.Image = Properties.Resources.esp8;
                            c7p3.Refresh();
                            break;
                        case 9:
                            c7p3.Image = Properties.Resources.basto9;
                            c7p3.Refresh();
                            break;
                        case 10:
                            c7p3.Image = Properties.Resources.copa10;
                            c7p3.Refresh();
                            break;
                        case 11:
                            c7p3.Image = Properties.Resources.copa11;
                            c7p3.Refresh();
                            break;
                        case 12:
                            c7p3.Image = Properties.Resources.basto12;
                            c7p3.Refresh();
                            break;
                    }
                    break;
            }

        }
        void switch_player4(char carta, int num)
        {
            switch (carta)
            {
                case '1':
                    c1p4.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c1p4.Image = Properties.Resources.culosucio;
                            c1p4.Refresh();
                            break;
                        case 2:
                            c1p4.Image = Properties.Resources.esp2;
                            c1p4.Refresh();
                            break;
                        case 3:
                            c1p4.Image = Properties.Resources.esp3;
                            c1p4.Refresh();
                            break;
                        case 4:
                            c1p4.Image = Properties.Resources.oro4;
                            c1p4.Refresh();
                            break;
                        case 5:
                            c1p4.Image = Properties.Resources.copa5;
                            c1p4.Refresh();
                            break;
                        case 6:
                            c1p4.Image = Properties.Resources.copa6;
                            c1p4.Refresh();
                            break;
                        case 7:
                            c1p4.Image = Properties.Resources.esp7;
                            c1p4.Refresh();
                            break;
                        case 8:
                            c1p4.Image = Properties.Resources.esp8;
                            c1p4.Refresh();
                            break;
                        case 9:
                            c1p4.Image = Properties.Resources.basto9;
                            c1p4.Refresh();
                            break;
                        case 10:
                            c1p4.Image = Properties.Resources.copa10;
                            c1p4.Refresh();
                            break;
                        case 11:
                            c1p4.Image = Properties.Resources.copa11;
                            c1p4.Refresh();
                            break;
                        case 12:
                            c1p4.Image = Properties.Resources.basto12;
                            c1p4.Refresh();
                            break;

                    }
                    break;
                case '2':
                    c2p4.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c2p4.Image = Properties.Resources.culosucio;
                            c2p4.Refresh();
                            break;
                        case 2:
                            c2p4.Image = Properties.Resources.esp2;
                            c2p4.Refresh();
                            break;
                        case 3:
                            c2p4.Image = Properties.Resources.esp3;
                            c2p4.Refresh();
                            break;
                        case 4:
                            c2p4.Image = Properties.Resources.oro4;
                            c2p4.Refresh();
                            break;
                        case 5:
                            c2p4.Image = Properties.Resources.copa5;
                            c2p4.Refresh();
                            break;
                        case 6:
                            c2p4.Image = Properties.Resources.copa6;
                            c2p4.Refresh();
                            break;
                        case 7:
                            c2p4.Image = Properties.Resources.esp7;
                            c2p4.Refresh();
                            break;
                        case 8:
                            c2p4.Image = Properties.Resources.esp8;
                            c2p4.Refresh();
                            break;
                        case 9:
                            c2p4.Image = Properties.Resources.basto9;
                            c2p4.Refresh();
                            break;
                        case 10:
                            c2p4.Image = Properties.Resources.copa10;
                            c2p4.Refresh();
                            break;
                        case 11:
                            c2p4.Image = Properties.Resources.copa11;
                            c2p4.Refresh();
                            break;
                        case 12:
                            c2p4.Image = Properties.Resources.basto12;
                            c2p4.Refresh();
                            break;

                    }
                    break;
                case '3':
                    c3p4.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c3p4.Image = Properties.Resources.culosucio;
                            c3p4.Refresh();
                            break;
                        case 2:
                            c3p4.Image = Properties.Resources.esp2;
                            c3p4.Refresh();
                            break;
                        case 3:
                            c3p4.Image = Properties.Resources.esp3;
                            c3p4.Refresh();
                            break;
                        case 4:
                            c3p4.Image = Properties.Resources.oro4;
                            c3p4.Refresh();
                            break;
                        case 5:
                            c3p4.Image = Properties.Resources.copa5;
                            c3p4.Refresh();
                            break;
                        case 6:
                            c3p4.Image = Properties.Resources.copa6;
                            c3p4.Refresh();
                            break;
                        case 7:
                            c3p4.Image = Properties.Resources.esp7;
                            c3p4.Refresh();
                            break;
                        case 8:
                            c3p4.Image = Properties.Resources.esp8;
                            c3p4.Refresh();
                            break;
                        case 9:
                            c3p4.Image = Properties.Resources.basto9;
                            c3p4.Refresh();
                            break;
                        case 10:
                            c3p4.Image = Properties.Resources.copa10;
                            c3p4.Refresh();
                            break;
                        case 11:
                            c3p4.Image = Properties.Resources.copa11;
                            c3p4.Refresh();
                            break;
                        case 12:
                            c3p4.Image = Properties.Resources.basto12;
                            c3p4.Refresh();
                            break;

                    }
                    break;
                case '4':
                    c4p4.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c4p4.Image = Properties.Resources.culosucio;
                            c4p4.Refresh();
                            break;
                        case 2:
                            c4p4.Image = Properties.Resources.esp2;
                            c4p4.Refresh();
                            break;
                        case 3:
                            c4p4.Image = Properties.Resources.esp3;
                            c4p4.Refresh();
                            break;
                        case 4:
                            c4p4.Image = Properties.Resources.oro4;
                            c4p4.Refresh();
                            break;
                        case 5:
                            c4p4.Image = Properties.Resources.copa5;
                            c4p4.Refresh();
                            break;
                        case 6:
                            c4p4.Image = Properties.Resources.copa6;
                            c4p4.Refresh();
                            break;
                        case 7:
                            c4p4.Image = Properties.Resources.esp7;
                            c4p4.Refresh();
                            break;
                        case 8:
                            c4p4.Image = Properties.Resources.esp8;
                            c4p4.Refresh();
                            break;
                        case 9:
                            c4p4.Image = Properties.Resources.basto9;
                            c4p4.Refresh();
                            break;
                        case 10:
                            c4p4.Image = Properties.Resources.copa10;
                            c4p4.Refresh();
                            break;
                        case 11:
                            c4p4.Image = Properties.Resources.copa11;
                            c4p4.Refresh();
                            break;
                        case 12:
                            c4p4.Image = Properties.Resources.basto12;
                            c4p4.Refresh();
                            break;

                    }
                    break;
                case '5':
                    c5p4.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c5p4.Image = Properties.Resources.culosucio;
                            c5p4.Refresh();
                            break;
                        case 2:
                            c5p4.Image = Properties.Resources.esp2;
                            c5p4.Refresh();
                            break;
                        case 3:
                            c5p4.Image = Properties.Resources.esp3;
                            c5p4.Refresh();
                            break;
                        case 4:
                            c5p4.Image = Properties.Resources.oro4;
                            c5p4.Refresh();
                            break;
                        case 5:
                            c5p4.Image = Properties.Resources.copa5;
                            c5p4.Refresh();
                            break;
                        case 6:
                            c5p4.Image = Properties.Resources.copa6;
                            c5p4.Refresh();
                            break;
                        case 7:
                            c5p4.Image = Properties.Resources.esp7;
                            c5p4.Refresh();
                            break;
                        case 8:
                            c5p4.Image = Properties.Resources.esp8;
                            c5p4.Refresh();
                            break;
                        case 9:
                            c5p4.Image = Properties.Resources.basto9;
                            c5p4.Refresh();
                            break;
                        case 10:
                            c5p4.Image = Properties.Resources.copa10;
                            c4p4.Refresh();
                            break;
                        case 11:
                            c5p4.Image = Properties.Resources.copa11;
                            c5p4.Refresh();
                            break;
                        case 12:
                            c5p4.Image = Properties.Resources.basto12;
                            c5p4.Refresh();
                            break;

                    }
                    break;
                case '6':
                    c6p4.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c6p4.Image = Properties.Resources.culosucio;
                            c6p4.Refresh();
                            break;
                        case 2:
                            c6p4.Image = Properties.Resources.esp2;
                            c6p4.Refresh();
                            break;
                        case 3:
                            c6p4.Image = Properties.Resources.esp3;
                            c6p4.Refresh();
                            break;
                        case 4:
                            c6p4.Image = Properties.Resources.oro4;
                            c6p4.Refresh();
                            break;
                        case 5:
                            c6p4.Image = Properties.Resources.copa5;
                            c6p4.Refresh();
                            break;
                        case 6:
                            c6p4.Image = Properties.Resources.copa6;
                            c6p4.Refresh();
                            break;
                        case 7:
                            c6p4.Image = Properties.Resources.esp7;
                            c6p4.Refresh();
                            break;
                        case 8:
                            c6p4.Image = Properties.Resources.esp8;
                            c6p4.Refresh();
                            break;
                        case 9:
                            c6p4.Image = Properties.Resources.basto9;
                            c6p4.Refresh();
                            break;
                        case 10:
                            c6p4.Image = Properties.Resources.copa10;
                            c6p4.Refresh();
                            break;
                        case 11:
                            c6p4.Image = Properties.Resources.copa11;
                            c6p4.Refresh();
                            break;
                        case 12:
                            c6p4.Image = Properties.Resources.basto12;
                            c6p4.Refresh();
                            break;
                    }
                    break;
                case '7':
                    c7p4.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c7p4.Image = Properties.Resources.culosucio;
                            c7p4.Refresh();
                            break;
                        case 2:
                            c7p4.Image = Properties.Resources.esp2;
                            c7p4.Refresh();
                            break;
                        case 3:
                            c7p4.Image = Properties.Resources.esp3;
                            c7p4.Refresh();
                            break;
                        case 4:
                            c7p4.Image = Properties.Resources.oro4;
                            c7p4.Refresh();
                            break;
                        case 5:
                            c7p4.Image = Properties.Resources.copa5;
                            c7p4.Refresh();
                            break;
                        case 6:
                            c7p4.Image = Properties.Resources.copa6;
                            c7p4.Refresh();
                            break;
                        case 7:
                            c7p4.Image = Properties.Resources.esp7;
                            c7p4.Refresh();
                            break;
                        case 8:
                            c7p4.Image = Properties.Resources.esp8;
                            c7p4.Refresh();
                            break;
                        case 9:
                            c7p4.Image = Properties.Resources.basto9;
                            c7p4.Refresh();
                            break;
                        case 10:
                            c7p4.Image = Properties.Resources.copa10;
                            c7p4.Refresh();
                            break;
                        case 11:
                            c7p4.Image = Properties.Resources.copa11;
                            c7p4.Refresh();
                            break;
                        case 12:
                            c7p4.Image = Properties.Resources.basto12;
                            c7p4.Refresh();
                            break;
                    }
                    break;
            }

        }
        void switch_player5(char carta, int num)
        {
            switch (carta)
            {
                case '1':
                    c1p5.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c1p5.Image = Properties.Resources.culosucio;
                            c1p5.Refresh();
                            break;
                        case 2:
                            c1p5.Image = Properties.Resources.esp2;
                            c1p5.Refresh();
                            break;
                        case 3:
                            c1p5.Image = Properties.Resources.esp3;
                            c1p5.Refresh();
                            break;
                        case 4:
                            c1p5.Image = Properties.Resources.oro4;
                            c1p5.Refresh();
                            break;
                        case 5:
                            c1p5.Image = Properties.Resources.copa5;
                            c1p5.Refresh();
                            break;
                        case 6:
                            c1p5.Image = Properties.Resources.copa6;
                            c1p5.Refresh();
                            break;
                        case 7:
                            c1p5.Image = Properties.Resources.esp7;
                            c1p5.Refresh();
                            break;
                        case 8:
                            c1p5.Image = Properties.Resources.esp8;
                            c1p5.Refresh();
                            break;
                        case 9:
                            c1p5.Image = Properties.Resources.basto9;
                            c1p5.Refresh();
                            break;
                        case 10:
                            c1p5.Image = Properties.Resources.copa10;
                            c1p5.Refresh();
                            break;
                        case 11:
                            c1p5.Image = Properties.Resources.copa11;
                            c1p5.Refresh();
                            break;
                        case 12:
                            c1p5.Image = Properties.Resources.basto12;
                            c1p5.Refresh();
                            break;

                    }
                    break;
                case '2':
                    c2p5.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c2p5.Image = Properties.Resources.culosucio;
                            c2p5.Refresh();
                            break;
                        case 2:
                            c2p5.Image = Properties.Resources.esp2;
                            c2p5.Refresh();
                            break;
                        case 3:
                            c2p5.Image = Properties.Resources.esp3;
                            c2p5.Refresh();
                            break;
                        case 4:
                            c2p5.Image = Properties.Resources.oro4;
                            c2p5.Refresh();
                            break;
                        case 5:
                            c2p5.Image = Properties.Resources.copa5;
                            c2p5.Refresh();
                            break;
                        case 6:
                            c2p5.Image = Properties.Resources.copa6;
                            c2p5.Refresh();
                            break;
                        case 7:
                            c2p5.Image = Properties.Resources.esp7;
                            c2p5.Refresh();
                            break;
                        case 8:
                            c2p5.Image = Properties.Resources.esp8;
                            c2p5.Refresh();
                            break;
                        case 9:
                            c2p5.Image = Properties.Resources.basto9;
                            c2p5.Refresh();
                            break;
                        case 10:
                            c2p5.Image = Properties.Resources.copa10;
                            c2p5.Refresh();
                            break;
                        case 11:
                            c2p5.Image = Properties.Resources.copa11;
                            c2p5.Refresh();
                            break;
                        case 12:
                            c2p5.Image = Properties.Resources.basto12;
                            c2p5.Refresh();
                            break;

                    }
                    break;
                case '3':
                    c3p5.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c3p5.Image = Properties.Resources.culosucio;
                            c3p5.Refresh();
                            break;
                        case 2:
                            c3p5.Image = Properties.Resources.esp2;
                            c3p5.Refresh();
                            break;
                        case 3:
                            c3p5.Image = Properties.Resources.esp3;
                            c3p5.Refresh();
                            break;
                        case 4:
                            c3p5.Image = Properties.Resources.oro4;
                            c3p5.Refresh();
                            break;
                        case 5:
                            c3p5.Image = Properties.Resources.copa5;
                            c3p5.Refresh();
                            break;
                        case 6:
                            c3p5.Image = Properties.Resources.copa6;
                            c3p5.Refresh();
                            break;
                        case 7:
                            c3p5.Image = Properties.Resources.esp7;
                            c3p5.Refresh();
                            break;
                        case 8:
                            c3p5.Image = Properties.Resources.esp8;
                            c3p5.Refresh();
                            break;
                        case 9:
                            c3p5.Image = Properties.Resources.basto9;
                            c3p5.Refresh();
                            break;
                        case 10:
                            c3p5.Image = Properties.Resources.copa10;
                            c3p5.Refresh();
                            break;
                        case 11:
                            c3p5.Image = Properties.Resources.copa11;
                            c3p5.Refresh();
                            break;
                        case 12:
                            c3p5.Image = Properties.Resources.basto12;
                            c3p5.Refresh();
                            break;

                    }
                    break;
                case '4':
                    c4p5.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c4p5.Image = Properties.Resources.culosucio;
                            c4p5.Refresh();
                            break;
                        case 2:
                            c4p5.Image = Properties.Resources.esp2;
                            c4p5.Refresh();
                            break;
                        case 3:
                            c4p5.Image = Properties.Resources.esp3;
                            c4p5.Refresh();
                            break;
                        case 4:
                            c4p5.Image = Properties.Resources.oro4;
                            c4p5.Refresh();
                            break;
                        case 5:
                            c4p5.Image = Properties.Resources.copa5;
                            c4p5.Refresh();
                            break;
                        case 6:
                            c4p5.Image = Properties.Resources.copa6;
                            c4p5.Refresh();
                            break;
                        case 7:
                            c4p5.Image = Properties.Resources.esp7;
                            c4p5.Refresh();
                            break;
                        case 8:
                            c4p5.Image = Properties.Resources.esp8;
                            c4p5.Refresh();
                            break;
                        case 9:
                            c4p5.Image = Properties.Resources.basto9;
                            c4p5.Refresh();
                            break;
                        case 10:
                            c4p5.Image = Properties.Resources.copa10;
                            c4p5.Refresh();
                            break;
                        case 11:
                            c4p5.Image = Properties.Resources.copa11;
                            c4p5.Refresh();
                            break;
                        case 12:
                            c4p5.Image = Properties.Resources.basto12;
                            c4p5.Refresh();
                            break;

                    }
                    break;
                case '5':
                    c5p5.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c5p5.Image = Properties.Resources.culosucio;
                            c5p5.Refresh();
                            break;
                        case 2:
                            c5p5.Image = Properties.Resources.esp2;
                            c5p5.Refresh();
                            break;
                        case 3:
                            c5p5.Image = Properties.Resources.esp3;
                            c5p5.Refresh();
                            break;
                        case 4:
                            c5p5.Image = Properties.Resources.oro4;
                            c5p5.Refresh();
                            break;
                        case 5:
                            c5p5.Image = Properties.Resources.copa5;
                            c5p5.Refresh();
                            break;
                        case 6:
                            c5p5.Image = Properties.Resources.copa6;
                            c5p5.Refresh();
                            break;
                        case 7:
                            c5p5.Image = Properties.Resources.esp7;
                            c5p5.Refresh();
                            break;
                        case 8:
                            c5p5.Image = Properties.Resources.esp8;
                            c5p5.Refresh();
                            break;
                        case 9:
                            c5p5.Image = Properties.Resources.basto9;
                            c5p5.Refresh();
                            break;
                        case 10:
                            c5p5.Image = Properties.Resources.copa10;
                            c4p5.Refresh();
                            break;
                        case 11:
                            c5p5.Image = Properties.Resources.copa11;
                            c5p5.Refresh();
                            break;
                        case 12:
                            c5p5.Image = Properties.Resources.basto12;
                            c5p5.Refresh();
                            break;

                    }
                    break;
                case '6':
                    c6p5.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c6p5.Image = Properties.Resources.culosucio;
                            c6p5.Refresh();
                            break;
                        case 2:
                            c6p5.Image = Properties.Resources.esp2;
                            c6p5.Refresh();
                            break;
                        case 3:
                            c6p5.Image = Properties.Resources.esp3;
                            c6p5.Refresh();
                            break;
                        case 4:
                            c6p5.Image = Properties.Resources.oro4;
                            c6p5.Refresh();
                            break;
                        case 5:
                            c6p5.Image = Properties.Resources.copa5;
                            c6p5.Refresh();
                            break;
                        case 6:
                            c6p5.Image = Properties.Resources.copa6;
                            c6p5.Refresh();
                            break;
                        case 7:
                            c6p5.Image = Properties.Resources.esp7;
                            c6p5.Refresh();
                            break;
                        case 8:
                            c6p5.Image = Properties.Resources.esp8;
                            c6p5.Refresh();
                            break;
                        case 9:
                            c6p5.Image = Properties.Resources.basto9;
                            c6p5.Refresh();
                            break;
                        case 10:
                            c6p5.Image = Properties.Resources.copa10;
                            c6p5.Refresh();
                            break;
                        case 11:
                            c6p5.Image = Properties.Resources.copa11;
                            c6p5.Refresh();
                            break;
                        case 12:
                            c6p5.Image = Properties.Resources.basto12;
                            c6p5.Refresh();
                            break;
                    }
                    break;
                case '7':
                    c7p5.Visible = true;
                    switch (num)
                    {
                        case 1:
                            c7p5.Image = Properties.Resources.culosucio;
                            c7p5.Refresh();
                            break;
                        case 2:
                            c7p5.Image = Properties.Resources.esp2;
                            c7p5.Refresh();
                            break;
                        case 3:
                            c7p5.Image = Properties.Resources.esp3;
                            c7p5.Refresh();
                            break;
                        case 4:
                            c7p5.Image = Properties.Resources.oro4;
                            c7p5.Refresh();
                            break;
                        case 5:
                            c7p5.Image = Properties.Resources.copa5;
                            c7p5.Refresh();
                            break;
                        case 6:
                            c7p5.Image = Properties.Resources.copa6;
                            c7p5.Refresh();
                            break;
                        case 7:
                            c7p5.Image = Properties.Resources.esp7;
                            c7p5.Refresh();
                            break;
                        case 8:
                            c7p5.Image = Properties.Resources.esp8;
                            c7p5.Refresh();
                            break;
                        case 9:
                            c7p5.Image = Properties.Resources.basto9;
                            c7p5.Refresh();
                            break;
                        case 10:
                            c7p5.Image = Properties.Resources.copa10;
                            c7p5.Refresh();
                            break;
                        case 11:
                            c7p5.Image = Properties.Resources.copa11;
                            c7p5.Refresh();
                            break;
                        case 12:
                            c7p5.Image = Properties.Resources.basto12;
                            c7p5.Refresh();
                            break;
                    }
                    break;
            }

        }


        void darvuelta_carta(Byte[] Data, string ID)
        {
            string aux;
            string aux2;
            //!playerN_C
            int num;
            if (ConvertBytesToString(Data).Length == 10)
            {

                aux = ConvertBytesToString(Data);
                aux2 = aux.Substring(8, 1);
                num = int.Parse(aux2);

            }
            else
            {
                //!playerN__C
                aux = ConvertBytesToString(Data);
                aux2 = aux.Substring(8, 2);
                num = int.Parse(aux2);
            }

            char carta = aux[aux.Length - 1];
            if (ConvertBytesToString(Data).Substring(1, 7) == "player1")
            {
                if (aux.Substring(7, 1) == "1" && ID != "elYarol")
                {
                    richTextBox6.AppendText("elYarol tiro un: " + num.ToString() + Environment.NewLine);

                }
                switch_player1(carta, num);
            }
            if (ConvertBytesToString(Data).Substring(1, 7) == "player2")
            {
                if (aux.Substring(7, 1) == "2" && ID != "Baco")
                {
                    richTextBox6.AppendText("Baco tiro un: " + num.ToString() + Environment.NewLine);

                }
                switch_player2(carta, num);
            }
            if (ConvertBytesToString(Data).Substring(1, 7) == "player3")
            {
                if (aux.Substring(7, 1) == "3" && ID != "Ocha")
                {
                    richTextBox6.AppendText("Ocha tiro un: " + num.ToString() + Environment.NewLine);

                }
                switch_player3(carta, num);
            }
            if (ConvertBytesToString(Data).Substring(1, 7) == "player4")
            {
                if (aux.Substring(7, 1) == "4" && ID != "Geda")
                {
                    richTextBox6.AppendText("Geda tiro un: " + num.ToString() + Environment.NewLine);


                }
                switch_player4(carta, num);
            }
            if (ConvertBytesToString(Data).Substring(1, 7) == "player5")
            {
                if (aux.Substring(7, 1) == "5" && ID != "Rombo")
                {
                    richTextBox6.AppendText("Rombo tiro un: " + num.ToString() + Environment.NewLine);

                }
                switch_player5(carta, num);
            }

        }
        void clear_carta(byte[] Data)
        {
            gpp1.Clear();
            gpp2.Clear();
            gpp3.Clear();
            gpp4.Clear();
            gpp5.Clear();
            if (ConvertBytesToString(Data)[1].ToString() == "1")
            {

                c1p1.Image = Properties.Resources.back;
                c1p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p1.Location = new Point(400, 388);
                c1p1.Refresh();
                c1p1.Visible = true;


                c1p2.Image = Properties.Resources.back;
                c1p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p2.Location = new Point(744, 388);
                c1p2.Refresh();
                c1p2.Visible = true;

                c1p3.Image = Properties.Resources.back;
                c1p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p3.Location = new Point(928, 228);
                c1p3.Refresh();
                c1p3.Visible = true;

                c1p4.Image = Properties.Resources.back;
                c1p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p4.Location = new Point(742, 52);
                c1p4.Refresh();
                c1p4.Visible = true;

                c1p5.Image = Properties.Resources.back;
                c1p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p5.Location = new Point(402, 52);
                c1p5.Refresh();
                c1p5.Visible = true;

                c2p5.Visible = false;
                c3p5.Visible = false;
                c4p5.Visible = false;
                c5p5.Visible = false;
                c6p5.Visible = false;
                c7p5.Visible = false;

                c2p4.Visible = false;
                c3p4.Visible = false;
                c4p4.Visible = false;
                c5p4.Visible = false;
                c6p4.Visible = false;
                c7p4.Visible = false;


                c2p1.Visible = false;
                c2p2.Visible = false;
                c2p3.Visible = false;
                c3p1.Visible = false;
                c3p2.Visible = false;
                c3p3.Visible = false;
                c4p1.Visible = false;
                c4p2.Visible = false;
                c4p3.Visible = false;
                c5p1.Visible = false;
                c5p2.Visible = false;
                c5p3.Visible = false;
                c6p1.Visible = false;
                c6p2.Visible = false;
                c6p3.Visible = false;
                c7p1.Visible = false;
                c7p2.Visible = false;
                c7p3.Visible = false;

            }
            if (ConvertBytesToString(Data)[1].ToString() == "3")
            {
                c1p1.Image = Properties.Resources.back;
                c1p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p1.Location = new Point(400, 388);
                c1p1.Refresh();
                c1p1.Visible = true;


                c1p2.Image = Properties.Resources.back;
                c1p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p2.Location = new Point(744, 388);
                c1p2.Refresh();
                c1p2.Visible = true;

                c1p3.Image = Properties.Resources.back;
                c1p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p3.Location = new Point(928, 228);
                c1p3.Refresh();
                c1p3.Visible = true;

                c1p4.Image = Properties.Resources.back;
                c1p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p4.Location = new Point(742, 52);
                c1p4.Refresh();
                c1p4.Visible = true;

                c1p5.Image = Properties.Resources.back;
                c1p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p5.Location = new Point(402, 52);
                c1p5.Refresh();
                c1p5.Visible = true;

                c2p1.Image = Properties.Resources.back;
                c2p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c2p1.Location = new Point(425, 388);
                c2p1.Refresh();
                c2p1.Visible = true;

                c2p2.Image = Properties.Resources.back;
                c2p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c2p2.Location = new Point(744 + 25, 388);
                c2p2.Refresh();
                c2p2.Visible = true;

                c2p3.Image = Properties.Resources.back;
                c2p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c2p3.Location = new Point(928 + 25, 228);
                c2p3.Refresh();
                c2p3.Visible = true;

                c2p4.Image = Properties.Resources.back;
                c2p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c2p4.Location = new Point(742 + 25, 52);
                c2p4.Refresh();
                c2p4.Visible = true;

                c2p5.Image = Properties.Resources.back;
                c2p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c2p5.Location = new Point(402 + 25, 52);
                c2p5.Refresh();
                c2p5.Visible = true;

                c3p1.Image = Properties.Resources.back;
                c3p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c3p1.Location = new Point(450, 388);
                c3p1.Refresh();
                c3p1.Visible = true;

                c3p2.Image = Properties.Resources.back;
                c3p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c3p2.Location = new Point(744 + 50, 388);
                c3p2.Refresh();
                c3p2.Visible = true;

                c3p3.Image = Properties.Resources.back;
                c3p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c3p3.Location = new Point(928 + 50, 228);
                c3p3.Refresh();
                c3p3.Visible = true;

                c3p4.Image = Properties.Resources.back;
                c3p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c3p4.Location = new Point(742 + 50, 52);
                c3p4.Refresh();
                c3p4.Visible = true;

                c3p5.Image = Properties.Resources.back;
                c3p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c3p5.Location = new Point(402 + 50, 52);
                c3p5.Refresh();
                c3p5.Visible = true;

                c4p1.Visible = false;
                c4p2.Visible = false;
                c4p3.Visible = false;
                c5p1.Visible = false;
                c5p2.Visible = false;
                c5p3.Visible = false;
                c6p1.Visible = false;
                c6p2.Visible = false;
                c6p3.Visible = false;
                c7p1.Visible = false;
                c7p2.Visible = false;
                c7p3.Visible = false;

                c4p4.Visible = false;
                c5p4.Visible = false;
                c6p4.Visible = false;
                c7p4.Visible = false;

                c4p5.Visible = false;
                c5p5.Visible = false;
                c6p5.Visible = false;
                c7p5.Visible = false;

            }
            if (ConvertBytesToString(Data)[1].ToString() == "5")
            {
                c1p1.Image = Properties.Resources.back;
                c1p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p1.Location = new Point(400, 388);
                c1p1.Refresh();
                c1p1.Visible = true;


                c1p2.Image = Properties.Resources.back;
                c1p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p2.Location = new Point(744, 388);
                c1p2.Refresh();
                c1p2.Visible = true;

                c1p3.Image = Properties.Resources.back;
                c1p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p3.Location = new Point(928, 228);
                c1p3.Refresh();
                c1p3.Visible = true;

                c1p4.Image = Properties.Resources.back;
                c1p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p4.Location = new Point(742, 52);
                c1p4.Refresh();
                c1p4.Visible = true;

                c1p5.Image = Properties.Resources.back;
                c1p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p5.Location = new Point(402, 52);
                c1p5.Refresh();
                c1p5.Visible = true;

                c2p1.Image = Properties.Resources.back;
                c2p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c2p1.Location = new Point(425, 388);
                c2p1.Refresh();
                c2p1.Visible = true;

                c2p2.Image = Properties.Resources.back;
                c2p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c2p2.Location = new Point(744 + 25, 388);
                c2p2.Refresh();
                c2p2.Visible = true;

                c2p3.Image = Properties.Resources.back;
                c2p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c2p3.Location = new Point(928 + 25, 228);
                c2p3.Refresh();
                c2p3.Visible = true;

                c2p4.Image = Properties.Resources.back;
                c2p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c2p4.Location = new Point(742 + 25, 52);
                c2p4.Refresh();
                c2p4.Visible = true;

                c2p5.Image = Properties.Resources.back;
                c2p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c2p5.Location = new Point(402 + 25, 52);
                c2p5.Refresh();
                c2p5.Visible = true;

                c3p1.Image = Properties.Resources.back;
                c3p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c3p1.Location = new Point(450, 388);
                c3p1.Refresh();
                c3p1.Visible = true;

                c3p2.Image = Properties.Resources.back;
                c3p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c3p2.Location = new Point(744 + 50, 388);
                c3p2.Refresh();
                c3p2.Visible = true;

                c3p3.Image = Properties.Resources.back;
                c3p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c3p3.Location = new Point(928 + 50, 228);
                c3p3.Refresh();
                c3p3.Visible = true;

                c3p4.Image = Properties.Resources.back;
                c3p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c3p4.Location = new Point(742 + 50, 52);
                c3p4.Refresh();
                c3p4.Visible = true;

                c3p5.Image = Properties.Resources.back;
                c3p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c3p5.Location = new Point(402 + 50, 52);
                c3p5.Refresh();
                c3p5.Visible = true;

                c4p1.Image = Properties.Resources.back;
                c4p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c4p1.Location = new Point(475, 388);
                c4p1.Refresh();
                c4p1.Visible = true;

                c4p2.Image = Properties.Resources.back;
                c4p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c4p2.Location = new Point(744 + 75, 388);
                c4p2.Refresh();
                c4p2.Visible = true;

                c4p3.Image = Properties.Resources.back;
                c4p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c4p3.Location = new Point(928 + 75, 228);
                c4p3.Refresh();
                c4p3.Visible = true;

                c4p4.Image = Properties.Resources.back;
                c4p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c4p4.Location = new Point(742 + 75, 52);
                c4p4.Refresh();
                c4p4.Visible = true;

                c4p5.Image = Properties.Resources.back;
                c4p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c4p5.Location = new Point(402 + 75, 52);
                c4p5.Refresh();
                c4p5.Visible = true;

                c5p1.Image = Properties.Resources.back;
                c5p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c5p1.Location = new Point(500, 388);
                c5p1.Refresh();
                c5p1.Visible = true;

                c5p2.Image = Properties.Resources.back;
                c5p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c5p2.Location = new Point(744 + 100, 388);
                c5p2.Refresh();
                c5p2.Visible = true;

                c5p3.Image = Properties.Resources.back;
                c5p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c5p3.Location = new Point(928 + 100, 228);
                c5p3.Refresh();
                c5p3.Visible = true;

                c5p4.Image = Properties.Resources.back;
                c5p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c5p4.Location = new Point(742 + 100, 52);
                c5p4.Refresh();
                c5p4.Visible = true;

                c5p5.Image = Properties.Resources.back;
                c5p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c5p5.Location = new Point(402 + 100, 52);
                c5p5.Refresh();
                c5p5.Visible = true;

                c6p1.Visible = false;
                c6p2.Visible = false;
                c6p3.Visible = false;
                c6p4.Visible = false;
                c6p5.Visible = false;
                c7p1.Visible = false;
                c7p2.Visible = false;
                c7p3.Visible = false;
                c7p4.Visible = false;
                c7p5.Visible = false;


            }

            if (ConvertBytesToString(Data)[1].ToString() == "7")
            {
                c1p1.Image = Properties.Resources.back;
                c1p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p1.Location = new Point(400, 388);
                c1p1.Refresh();
                c1p1.Visible = true;


                c1p2.Image = Properties.Resources.back;
                c1p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p2.Location = new Point(744, 388);
                c1p2.Refresh();
                c1p2.Visible = true;

                c1p3.Image = Properties.Resources.back;
                c1p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p3.Location = new Point(928, 228);
                c1p3.Refresh();
                c1p3.Visible = true;

                c1p4.Image = Properties.Resources.back;
                c1p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p4.Location = new Point(742, 52);
                c1p4.Refresh();
                c1p4.Visible = true;

                c1p5.Image = Properties.Resources.back;
                c1p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c1p5.Location = new Point(402, 52);
                c1p5.Refresh();
                c1p5.Visible = true;

                c2p1.Image = Properties.Resources.back;
                c2p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c2p1.Location = new Point(425, 388);
                c2p1.Refresh();
                c2p1.Visible = true;

                c2p2.Image = Properties.Resources.back;
                c2p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c2p2.Location = new Point(744 + 25, 388);
                c2p2.Refresh();
                c2p2.Visible = true;

                c2p3.Image = Properties.Resources.back;
                c2p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c2p3.Location = new Point(928 + 25, 228);
                c2p3.Refresh();
                c2p3.Visible = true;

                c2p4.Image = Properties.Resources.back;
                c2p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c2p4.Location = new Point(742 + 25, 52);
                c2p4.Refresh();
                c2p4.Visible = true;

                c2p5.Image = Properties.Resources.back;
                c2p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c2p5.Location = new Point(402 + 25, 52);
                c2p5.Refresh();
                c2p5.Visible = true;

                c3p1.Image = Properties.Resources.back;
                c3p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c3p1.Location = new Point(450, 388);
                c3p1.Refresh();
                c3p1.Visible = true;

                c3p2.Image = Properties.Resources.back;
                c3p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c3p2.Location = new Point(744 + 50, 388);
                c3p2.Refresh();
                c3p2.Visible = true;

                c3p3.Image = Properties.Resources.back;
                c3p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c3p3.Location = new Point(928 + 50, 228);
                c3p3.Refresh();
                c3p3.Visible = true;

                c3p4.Image = Properties.Resources.back;
                c3p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c3p4.Location = new Point(742 + 50, 52);
                c3p4.Refresh();
                c3p4.Visible = true;

                c3p5.Image = Properties.Resources.back;
                c3p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c3p5.Location = new Point(402 + 50, 52);
                c3p5.Refresh();
                c3p5.Visible = true;

                c4p1.Image = Properties.Resources.back;
                c4p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c4p1.Location = new Point(475, 388);
                c4p1.Refresh();
                c4p1.Visible = true;

                c4p2.Image = Properties.Resources.back;
                c4p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c4p2.Location = new Point(744 + 75, 388);
                c4p2.Refresh();
                c4p2.Visible = true;

                c4p3.Image = Properties.Resources.back;
                c4p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c4p3.Location = new Point(928 + 75, 228);
                c4p3.Refresh();
                c4p3.Visible = true;

                c4p4.Image = Properties.Resources.back;
                c4p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c4p4.Location = new Point(742 + 75, 52);
                c4p4.Refresh();
                c4p4.Visible = true;

                c4p5.Image = Properties.Resources.back;
                c4p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c4p5.Location = new Point(402 + 75, 52);
                c4p5.Refresh();
                c4p5.Visible = true;

                c5p1.Image = Properties.Resources.back;
                c5p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c5p1.Location = new Point(500, 388);
                c5p1.Refresh();
                c5p1.Visible = true;

                c5p2.Image = Properties.Resources.back;
                c5p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c5p2.Location = new Point(744 + 100, 388);
                c5p2.Refresh();
                c5p2.Visible = true;

                c5p3.Image = Properties.Resources.back;
                c5p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c5p3.Location = new Point(928 + 100, 228);
                c5p3.Refresh();
                c5p3.Visible = true;

                c5p4.Image = Properties.Resources.back;
                c5p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c5p4.Location = new Point(742 + 100, 52);
                c5p4.Refresh();
                c5p4.Visible = true;

                c5p5.Image = Properties.Resources.back;
                c5p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c5p5.Location = new Point(402 + 100, 52);
                c5p5.Refresh();
                c5p5.Visible = true;

                c6p1.Image = Properties.Resources.back;
                c6p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c6p1.Location = new Point(525, 388);
                c6p1.Refresh();
                c6p1.Visible = true;

                c6p2.Image = Properties.Resources.back;
                c6p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c6p2.Location = new Point(744 + 125, 388);
                c6p2.Refresh();
                c6p2.Visible = true;

                c6p3.Image = Properties.Resources.back;
                c6p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c6p3.Location = new Point(928 + 125, 228);
                c6p3.Refresh();
                c6p3.Visible = true;

                c6p4.Image = Properties.Resources.back;
                c6p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c6p4.Location = new Point(742 + 125, 52);
                c6p4.Refresh();
                c6p4.Visible = true;

                c6p5.Image = Properties.Resources.back;
                c6p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c6p5.Location = new Point(402 + 125, 52);
                c6p5.Refresh();
                c6p5.Visible = true;

                c7p3.Image = Properties.Resources.back;
                c7p3.SizeMode = PictureBoxSizeMode.StretchImage;
                c7p3.Location = new Point(928 + 150, 228);
                c7p3.Refresh();
                c7p3.Visible = true;

                c7p4.Image = Properties.Resources.back;
                c7p4.SizeMode = PictureBoxSizeMode.StretchImage;
                c7p4.Location = new Point(742 + 150, 52);
                c7p4.Refresh();
                c7p4.Visible = true;

                c7p5.Image = Properties.Resources.back;
                c7p5.SizeMode = PictureBoxSizeMode.StretchImage;
                c7p5.Location = new Point(402 + 150, 52);
                c7p5.Refresh();
                c7p5.Visible = true;

                c7p2.Image = Properties.Resources.back;
                c7p2.SizeMode = PictureBoxSizeMode.StretchImage;
                c7p2.Location = new Point(744 + 150, 388);
                c7p2.Refresh();
                c7p2.Visible = true;

                c7p1.Image = Properties.Resources.back;
                c7p1.SizeMode = PictureBoxSizeMode.StretchImage;
                c7p1.Location = new Point(550, 388);
                c7p1.Refresh();
                c7p1.Visible = true;

            }



        }
        // hacer para q muestre gano o pierdo
        void msgGanoPierdo(Byte[] Data)
        {
            string aux = ConvertBytesToString(Data);
            char aux2 = aux[1];
            string text = aux.Substring(2);
            switch (aux2)
            {
                case '1': gpp1.Text = text;
                    break;
                case '2': gpp2.Text = text;
                    break;
                case '3': gpp3.Text = text;
                    break;
                case '4': gpp4.Text = text;
                    break;
                case '5': gpp5.Text = text;
                    break;

                    //     case 'T':textBox1.Text = text;
                    //        break;
                    //    case 'B':textBox2.Text = text;                   
                    //      break;
                    //    case 'R': textBox3.Text = text;                  
                    //       break;
                    //    case 'G': textBox11.Text = text;
                    //      break;
                    //   case 'N': textBox22.Text = text;
                    //     break;
                    //  case 'F': textBox33.Text = text;
                    //  break;

            }

        }
        void pasar_dealer(byte[] Data)
        {
            string aux = ConvertBytesToString(Data);


            if (aux == "Reparte elYarol")
            {
                manolabel.Location = new Point(382, 360);
                manolabel.Text = "DEALER1";
            }
            else
            {
                if (aux == "Reparte Baco")
                {
                    manolabel.Location = new Point(703, 365);
                    manolabel.Text = "DEALER2";
                }

                else
                {
                    if (aux == "Reparte Ocha")
                    {
                        manolabel.Location = new Point(842, 314);
                        manolabel.Text = "DEALER3";
                    }
                    else
                    {
                        if (aux == "Reparte Geda")
                        {
                            manolabel.Location = new Point(893, 177);
                            manolabel.Text = "DEALER4";
                        }
                        else
                        {
                            if (aux == "Reparte Rombo")
                            {
                                manolabel.Location = new Point(361, 171);
                                manolabel.Text = "DEALER5";
                            }
                        }
                    }
                }
            }
        }
    

        

        void playZumbido()
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.zumbido);
            simpleSound.Play();
        }
        void playDormischu()
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.dormischu1);
            simpleSound.Play();
        }
        void playLoro()
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.queloro);
            simpleSound.Play();
        }
        void playVuelaUna()
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.vuelauna);
            simpleSound.Play();
        }

        void playGimnasia()
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.gimnasia);
            simpleSound.Play();
        }
        void showGimnasia()
        {
            pictureBox1.Visible = true;
            pictureBox1.Image =  Properties.Resources.wpwAPm;            
            playGimnasia();
        }
        void disableGimnasia()
        {
            pictureBox1.Visible = false;
            
        }

        void enable_ListBox1()
        {
            listBox1.Enabled = true;
        }

        void manage_sounds(Byte[] Data)
        {
            string aux = ConvertBytesToString(Data);
            if (aux[0].ToString() == "&")
            {
                switch (aux)
                {
                    case "&enableSounds": enable_ListBox1();
                    
                        richTextBox6.AppendText( " dddd: " + ConvertBytesToString(Data) + Environment.NewLine); //Updates the richTextBox6 with the current connection state

                        break;
                    case "&dormischu": playDormischu();
                        break;
                    case "&loro": playLoro();
                        break;
                    case "&vuelauna": playVuelaUna();
                        break;
                    case "&zumbido": playZumbido();
                        break;


                }
            }
        }


        void client_DataReceived(byte[] Data, string ID)
        {
            string aux = ConvertBytesToString(Data);
            switch (aux[0].ToString())
            {
                case "*": darvuelta_carta(Data,ID); //caso el host deliverea una carta a cada uno
                    break;
                case "!": darvuelta_carta(Data,ID);
                    //caso el host pide dar velta una carta
                    break;
                case "/": clear_carta(Data);
                    break;
                case "R": string datata = ConvertBytesToString(Data);
                    int index5 = datata.IndexOf(' ');
                    if (datata.Substring(0, index5) == "Reparte")
                    { pasar_dealer(Data); }  
                    break;

                    // el host resetea las imagenes 
                    break;
                case "#": msgGanoPierdo(Data);
                    break;
                case "%":
                    break;
                case "+": displayDormischu();
                    break;
                case "-": hideDormischu();
                    break;
                case "@": showGimnasia();
                    break;
                case "$":disableGimnasia();
                    break;

                case "&":manage_sounds(Data);
                    break;

                default:
                    
                    string clientID = ConvertBytesToString(Data);
                    int index = clientID.IndexOf(' ');
                    if (index > 0 ) 
                    {


                        string result = clientID.Substring(0, index);
                        string result2 = clientID.Substring(index);
                        switch (result)

                        {

                            case "Rombo":
                                richTextBox6.SelectionBackColor = Color.DarkBlue; richTextBox6.AppendText(result);
                                richTextBox6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(238)))), ((int)(((byte)(241)))));
                                richTextBox6.AppendText(result2 + Environment.NewLine);
                                break;
                            case "Ocha":
                                richTextBox6.SelectionBackColor = Color.IndianRed; richTextBox6.AppendText(result);
                                richTextBox6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(238)))), ((int)(((byte)(241)))));
                                richTextBox6.AppendText(result2 + Environment.NewLine);
                                break;
                            case "Geda":
                                richTextBox6.SelectionBackColor = Color.RoyalBlue; richTextBox6.AppendText(result);
                                richTextBox6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(238)))), ((int)(((byte)(241)))));
                                richTextBox6.AppendText(result2 + Environment.NewLine);
                                break;
                            case "elYarol":
                                richTextBox6.SelectionBackColor = Color.SlateBlue; richTextBox6.AppendText(result);
                                richTextBox6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(238)))), ((int)(((byte)(241)))));
                                richTextBox6.AppendText(result2 + Environment.NewLine);
                                break;
                            case "Baco":
                                richTextBox6.SelectionBackColor = Color.GreenYellow; richTextBox6.AppendText(result);
                                richTextBox6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(238)))), ((int)(((byte)(241)))));
                                richTextBox6.AppendText(result2 + Environment.NewLine);
                                break;
                            default:
                                break;
                        }


                      
                    }
                    else
                    {
                        richTextBox6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(238)))), ((int)(((byte)(241)))));
                        richTextBox6.AppendText(clientID + Environment.NewLine);
                    }
                    
                break;
            } 
        }
        void client_Disconnected()
        {
            richTextBox6.AppendText("Disconnected from host!" + Environment.NewLine); //Updates the richTextBox6 with the current connection state
        }

        void client_Connected()
        {
            
            richTextBox6.AppendText("Connected succesfully!" + Environment.NewLine); //Updates the richTextBox6 with the current connection state
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            client.SendData(ConvertStringToBytes(ChatMessage.Text)); //Sends the message to the host
            ChatMessage.Clear(); //Clears the chatmessage textbox text
        }
        private void ChatMessage_Enter(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                //aqui codigo
                client.SendData(ConvertStringToBytes(ChatMessage.Text)); //Sends the message to the host
                ChatMessage.Clear(); //Clears the chatmessage textbox text


            }
        }
        private void Listox_Click(object sender, EventArgs e)
        {
            client.Connect(Ip.Text, int.Parse(Port.Text), Nombre.Text);
        }
        string ConvertBytesToString(byte[] bytes)
        {
            return ASCIIEncoding.ASCII.GetString(bytes);
        }
        byte[] ConvertStringToBytes(string str)
        {
            return ASCIIEncoding.ASCII.GetBytes(str);
        }
        private void send_c1p1(object sender, EventArgs e)
        {
            c1p1.Location = new Point(c1p1.Location.X, c1p1.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c1p1"));
        }
        private void send_c2p1(object sender, EventArgs e)
        {
            c2p1.Location = new Point(c2p1.Location.X, c2p1.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c2p1"));
        }
        private void send_c3p1(object sender, EventArgs e)
        {
            c3p1.Location = new Point(c3p1.Location.X, c3p1.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c3p1"));
        }
        private void send_c4p1(object sender, EventArgs e)
        {
            c4p1.Location = new Point(c4p1.Location.X, c4p1.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c4p1"));
        }
        private void send_c5p1(object sender, EventArgs e)
        {
            c5p1.Location = new Point(c5p1.Location.X, c5p1.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c5p1"));
        }
        private void send_c6p1(object sender, EventArgs e)
        {
            c6p1.Location = new Point(c6p1.Location.X, c6p1.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c6p1"));
        }
        private void send_c7p1(object sender, EventArgs e)
        {
            c7p1.Location = new Point(c7p1.Location.X, c7p1.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c7p1"));
        }
        private void send_c1p2(object sender, EventArgs e)
        {
            c1p2.Location = new Point(c1p2.Location.X, c1p2.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c1p2"));
        }
        private void send_c2p2(object sender, EventArgs e)
        {
            c2p2.Location = new Point(c2p2.Location.X, c2p2.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c2p2"));
        }
        private void send_c3p2(object sender, EventArgs e)
        {
            c3p2.Location = new Point(c3p2.Location.X, c3p2.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c3p2"));
        }
        private void send_c4p2(object sender, EventArgs e)
        {
            c4p2.Location = new Point(c4p2.Location.X, c4p2.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c4p2"));
        }
        private void send_c5p2(object sender, EventArgs e)
        {
            c5p2.Location = new Point(c5p2.Location.X, c5p2.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c5p2"));
        }
        private void send_c6p2(object sender, EventArgs e)
        {
            c6p2.Location = new Point(c6p2.Location.X, c6p2.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c6p2"));
        }
        private void send_c7p2(object sender, EventArgs e)
        {
            c7p2.Location = new Point(c7p2.Location.X, c7p2.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c7p2"));
        }
        private void send_c1p3(object sender, EventArgs e)
        {
            c1p3.Location = new Point(c1p3.Location.X, c1p3.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c1p3"));
        }
        private void send_c2p3(object sender, EventArgs e)
        {
            c2p3.Location = new Point(c2p3.Location.X, c2p3.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c2p3"));
        }
        private void send_c3p3(object sender, EventArgs e)
        {
            c3p3.Location = new Point(c3p3.Location.X, c3p3.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c3p3"));
        }
        private void send_c4p3(object sender, EventArgs e)
        {
            c4p3.Location = new Point(c4p3.Location.X, c4p3.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c4p3"));
        }
        private void send_c5p3(object sender, EventArgs e)
        {
            c5p3.Location = new Point(c5p3.Location.X, c5p3.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c5p3"));
        }
        private void send_c6p3(object sender, EventArgs e)
        {
            c6p3.Location = new Point(c6p3.Location.X, c6p3.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c6p3"));
        }
        private void send_c7p3(object sender, EventArgs e)
        {
            c7p3.Location = new Point(c7p3.Location.X, c7p3.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c7p3"));
        }
        private void send_c1p4(object sender, EventArgs e)
        {
            c1p4.Location = new Point(c1p4.Location.X, c1p4.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c1p4"));
        }
        private void send_c2p4(object sender, EventArgs e)
        {
            c2p4.Location = new Point(c2p4.Location.X, c2p4.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c2p4"));
        }
        private void send_c3p4(object sender, EventArgs e)
        {
            c3p4.Location = new Point(c3p4.Location.X, c3p4.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c3p4"));
        }
        private void send_c4p4(object sender, EventArgs e)
        {
            c4p4.Location = new Point(c4p4.Location.X, c4p4.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c4p4"));
        }
        private void send_c5p4(object sender, EventArgs e)
        {
            c5p4.Location = new Point(c5p4.Location.X, c5p4.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c5p4"));
        }
        private void send_c6p4(object sender, EventArgs e)
        {
            c6p4.Location = new Point(c6p4.Location.X, c6p4.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c6p4"));
        }
        private void send_c7p4(object sender, EventArgs e)
        {
            c7p4.Location = new Point(c7p4.Location.X, c7p4.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c7p4"));
        }
        private void send_c1p5(object sender, EventArgs e)
        {
            c1p5.Location = new Point(c1p5.Location.X, c1p5.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c1p5"));
        }
        private void send_c2p5(object sender, EventArgs e)
        {
            c2p5.Location = new Point(c2p5.Location.X, c2p5.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c2p5"));
        }
        private void send_c3p5(object sender, EventArgs e)
        {
            c3p5.Location = new Point(c3p5.Location.X, c3p5.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c3p5"));
        }
        private void send_c4p5(object sender, EventArgs e)
        {
            c4p5.Location = new Point(c4p5.Location.X, c4p5.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c4p5"));
        }
        private void send_c5p5(object sender, EventArgs e)
        {
            c5p5.Location = new Point(c5p5.Location.X, c5p5.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c5p5"));
        }
        private void send_c6p5(object sender, EventArgs e)
        {
            c6p5.Location = new Point(c6p5.Location.X, c6p5.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c6p5"));
        }
        private void send_c7p5(object sender, EventArgs e)
        {
            c7p5.Location = new Point(c7p5.Location.X, c7p5.Location.Y - 25);
            client.SendData(ConvertStringToBytes("%c7p5"));
        }


        private void gpp2_Enter(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                //aqui codigo
                client.SendData(ConvertStringToBytes("#2" + gpp2.Text));
            }
        }
        private void gpp1_Enter(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                //aqui codigo
                client.SendData(ConvertStringToBytes("#1" + gpp1.Text));
            }
        }
        private void gpp3_Enter(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                client.SendData(ConvertStringToBytes("#3" + gpp3.Text));
            }
        }
        private void gpp4_Enter(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                client.SendData(ConvertStringToBytes("#4" + gpp4.Text));
            }
        }
        private void gpp5_Enter(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                client.SendData(ConvertStringToBytes("#5" + gpp5.Text));
            }
        }


        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

        }






        private void mandar_Sonido(object sender, EventArgs e)
        {
            
            if (listBox1.Enabled == true)
            {
                int selectedindex = listBox1.SelectedIndex;
                switch (selectedindex)
                {
                    case 0:
                        {
                            client.SendData(ConvertStringToBytes("&zumbido"));
                            playZumbido();
                        }
                        break;
                    case 1:
                        {
                            client.SendData(ConvertStringToBytes("&dormischu"));
                            playDormischu();
                        }
                        break;
                    case 2:
                        {
                            client.SendData(ConvertStringToBytes("&loro"));
                            playLoro();
                        }
                        break;
                    case 3:
                        {
                            client.SendData(ConvertStringToBytes("&vuelauna"));
                            playVuelaUna();
                        }
                        break;

                }
            }
        }


    }
}
