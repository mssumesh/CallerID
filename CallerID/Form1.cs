using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace CallerID
    {
    public partial class Form1 : Form
        {
        public Form1()
            {
            InitializeComponent();
            }

        private void button1_Click(object sender, EventArgs e)
            {
            string  cmd1 =  "AT#CID=1";
            string  cmd2 =  "AT+VCID=1";
            string  cmd3 =  "AT#CID=2";
            string  cmd4 =  "AT%CCID=1";
            string  cmd5 =  "AT%CCID=2";
            string  cmd6 =  "AT#CC1";
            string cmd7 = "AT*ID1";

            serialPort1.PortName = "COM"+txtComPort.Text;
            serialPort1.Open();
            serialPort1.WriteLine(cmd1+ System.Environment.NewLine);
            serialPort1.WriteLine(cmd2 + System.Environment.NewLine);
            serialPort1.WriteLine(cmd3 + System.Environment.NewLine);
            serialPort1.WriteLine(cmd4 + System.Environment.NewLine);
            serialPort1.WriteLine(cmd5 + System.Environment.NewLine);
            serialPort1.WriteLine(cmd6 + System.Environment.NewLine);
            serialPort1.WriteLine(cmd7 + System.Environment.NewLine);
            serialPort1.WriteLine(cmd1);
            serialPort1.WriteLine(cmd2);
            serialPort1.WriteLine(cmd3);
            serialPort1.WriteLine(cmd4);
            serialPort1.WriteLine(cmd5);
            serialPort1.WriteLine(cmd6);
            serialPort1.WriteLine(cmd7);
            }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
            {
            string msg = serialPort1.ReadLine();
            //txtResult.Text  = txtResult.Text + msg;
            }

        private void btnStop_Click(object sender, EventArgs e)
            {
            serialPort1.Close();
            }
        }
    }