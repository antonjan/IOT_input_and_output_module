using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelayModule_Dingtian
{
    public partial class Form1 : Form
    {
        public string globalIP = "";
        public Form1()
        {
            InitializeComponent();
        }

        // Function to Get Status of Relays
        public string GetStatus(string ipaddress)
        {
            try
            {
                Int32 port = 60001;
                TcpClient client = new TcpClient(ipaddress, port);
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("00");
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                data = new Byte[256];
                String responseData = String.Empty;
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                stream.Close();
                client.Close();
                return responseData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to connect to relay board. Error details: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        // Function to send TCP Packet using Dingtian String commands
        public bool SendTcpPacket(string relaynumber, string status, string ipaddress)
        {
            try
            {
                string text = "";
                Int32 port = 60001;
                TcpClient client = new TcpClient(ipaddress, port);

                if (relaynumber == "1")
                {
                    if (status == "on")
                    {
                        text = "11";
                    }
                    else
                    {
                        text = "21";
                    }

                }
                if (relaynumber == "2")
                {
                    if (status == "on")
                    {
                        text = "12";
                    }
                    else
                    {
                        text = "22";
                    }

                }
                if (relaynumber == "3")
                {
                    if (status == "on")
                    {
                        text = "13";
                    }
                    else
                    {
                        text = "23";
                    }

                }
                if (relaynumber == "4")
                {
                    if (status == "on")
                    {
                        text = "14";
                    }
                    else
                    {
                        text = "24";
                    }

                }
                if (relaynumber == "5")
                {
                    if (status == "on")
                    {
                        text = "15";
                    }
                    else
                    {
                        text = "25";
                    }

                }
                if (relaynumber == "6")
                {
                    if (status == "on")
                    {
                        text = "16";
                    }
                    else
                    {
                        text = "26";
                    }

                }
                if (relaynumber == "7")
                {
                    if (status == "on")
                    {
                        text = "17";
                    }
                    else
                    {
                        text = "27";
                    }

                }
                if (relaynumber == "8")
                {
                    if (status == "on")
                    {
                        text = "18";
                    }
                    else
                    {
                        text = "28";
                    }

                }
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(text);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                client.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to connect to relay board. Error details: " + ex.ToString(),"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
        }
        
        // Handle Buttons Press (ON / OFF of each Relay)
        private void button1_Click(object sender, EventArgs e)
        {
            SendTcpPacket("1", "on", globalIP);
            button17.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendTcpPacket("1", "off", globalIP);
            button17.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SendTcpPacket("2", "on", globalIP);
            button17.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SendTcpPacket("2", "off", globalIP);
            button17.PerformClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SendTcpPacket("3", "on", globalIP);
            button17.PerformClick();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SendTcpPacket("3", "off", globalIP);
            button17.PerformClick();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SendTcpPacket("4", "on", globalIP);
            button17.PerformClick();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SendTcpPacket("4", "off", globalIP);
            button17.PerformClick();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SendTcpPacket("5", "on", globalIP);
            button17.PerformClick();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SendTcpPacket("5", "off", globalIP);
            button17.PerformClick();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SendTcpPacket("6", "on", globalIP);
            button17.PerformClick();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SendTcpPacket("6", "off", globalIP);
            button17.PerformClick();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SendTcpPacket("7", "on", globalIP);
            button17.PerformClick();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SendTcpPacket("7", "off", globalIP);
            button17.PerformClick();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SendTcpPacket("8", "on", globalIP);
            button17.PerformClick();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SendTcpPacket("8", "off", globalIP);
            button17.PerformClick();
        }


        // Update status of all Relays 
        // Call this method always a status change to make sure we have latest status
        private void button17_Click(object sender, EventArgs e)
        {
            var responseData = GetStatus(globalIP);
            // Get Status
            if (responseData.Substring(0, 1) == "1")
            {
                pictureBox1.Image = global::RelayModule_Dingtian.Properties.Resources.on;
            }
            else
            {
                pictureBox1.Image = global::RelayModule_Dingtian.Properties.Resources.off;
            }
            if (responseData.Substring(1, 1) == "1")
            {
                pictureBox2.Image = global::RelayModule_Dingtian.Properties.Resources.on;
            }
            else
            {
                pictureBox2.Image = global::RelayModule_Dingtian.Properties.Resources.off;
            }
            if (responseData.Substring(2, 1) == "1")
            {
                pictureBox3.Image = global::RelayModule_Dingtian.Properties.Resources.on;
            }
            else
            {
                pictureBox3.Image = global::RelayModule_Dingtian.Properties.Resources.off;
            }
            if (responseData.Substring(3, 1) == "1")
            {
                pictureBox4.Image = global::RelayModule_Dingtian.Properties.Resources.on;
            }
            else
            {
                pictureBox4.Image = global::RelayModule_Dingtian.Properties.Resources.off;
            }
            if (responseData.Substring(4, 1) == "1")
            {
                pictureBox5.Image = global::RelayModule_Dingtian.Properties.Resources.on;
            }
            else
            {
                pictureBox5.Image = global::RelayModule_Dingtian.Properties.Resources.off;
            }
            if (responseData.Substring(5, 1) == "1")
            {
                pictureBox6.Image = global::RelayModule_Dingtian.Properties.Resources.on;
            }
            else
            {
                pictureBox6.Image = global::RelayModule_Dingtian.Properties.Resources.off;
            }
            if (responseData.Substring(6, 1) == "1")
            {
                pictureBox7.Image = global::RelayModule_Dingtian.Properties.Resources.on;
            }
            else
            {
                pictureBox7.Image = global::RelayModule_Dingtian.Properties.Resources.off;
            }
            if (responseData.Substring(7, 1) == "1")
            {
                pictureBox8.Image = global::RelayModule_Dingtian.Properties.Resources.on;
            }
            else
            {
                pictureBox8.Image = global::RelayModule_Dingtian.Properties.Resources.off;
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            string AppName = "";
            string IPAddress = "";
            string Sensor1 = "";
            string Sensor2 = "";
            string Sensor3 = "";
            string Sensor4 = "";
            string Sensor5 = "";
            string Sensor6 = "";
            string Sensor7 = "";
            string Sensor8 = "";
            try
            {
                AppName = ConfigurationManager.AppSettings["AppName"];
                IPAddress = ConfigurationManager.AppSettings["IPAddress"];
                Sensor1 = ConfigurationManager.AppSettings["Sensor1"];
                Sensor2 = ConfigurationManager.AppSettings["Sensor2"];
                Sensor3 = ConfigurationManager.AppSettings["Sensor3"];
                Sensor4 = ConfigurationManager.AppSettings["Sensor4"];
                Sensor5 = ConfigurationManager.AppSettings["Sensor5"];
                Sensor6 = ConfigurationManager.AppSettings["Sensor6"];
                Sensor7 = ConfigurationManager.AppSettings["Sensor7"];
                Sensor8 = ConfigurationManager.AppSettings["Sensor8"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("App.Config not found in same folder as executable, verify why the file is missing and try again.");
                Application.Exit();
            }

            if (AppName != "")
            {
                label1.Text = AppName;
                this.Text = AppName;
            }
            if (Sensor1 != "")
            {
                label2.Text = Sensor1;
            }
            if (Sensor2 != "")
            {
                label3.Text = Sensor2;
            }
            if (Sensor3 != "")
            {
                label4.Text = Sensor3;
            }
            if (Sensor4 != "")
            {
                label5.Text = Sensor4;
            }
            if (Sensor5 != "")
            {
                label6.Text = Sensor5;
            }
            if (Sensor6 != "")
            {
                label7.Text = Sensor6;
            }
            if (Sensor7 != "")
            {
                label8.Text = Sensor7;
            }
            if (Sensor8 != "")
            {
                label9.Text = Sensor8;
            }


            globalIP = IPAddress;
            button17.PerformClick();
        }
    }
}
