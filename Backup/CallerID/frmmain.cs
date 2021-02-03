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
    public partial class frmmain : Form
        {

        string comport = "input only the port number";

        public frmmain()
            {
            InitializeComponent();
            }

        private void frmmain_Load(object sender, EventArgs e)
            {
            this.Width = this.BackgroundImage.Width;
            this.Height = this.BackgroundImage.Height;

            //Declare A GraphicsPath Object, Which Is Used To Draw The Shape Of The Button 
            System.Drawing.Drawing2D.GraphicsPath CirclePath = new System.Drawing.Drawing2D.GraphicsPath();

            //Create A 60 x 60 Circle Path 
            CirclePath.AddEllipse(new Rectangle(0, 0, 53, 34));

            //Size Of The Button 
            btnExit.Size = new System.Drawing.Size(53, 34);

            //if (blnCircleClicked)
            //  {
            //If The Button Is Selected To Draw, Change The Color 
            btnExit.BackColor = Color.Black;
            btnExit.ForeColor = Color.White;
            //}
            //else
            //  {
            //If The Button Is Not Selected To Draw With, Change Back To Original Color 
            //btnOptions.BackColor = Color.Aquamarine;
            //}

            //Create The Circular Shaped Button, Based On The Graphics Path 
            btnExit.Region = new Region(CirclePath);

            //Release All Resources Owned By The Graphics Path Object 
            CirclePath.Dispose();

                
             

            ///////////////////

            string cmd1 = "AT#CID=1";
            string cmd2 = "AT+VCID=1";
            string cmd3 = "AT#CID=2";
            string cmd4 = "AT%CCID=1";
            string cmd5 = "AT%CCID=2";
            string cmd6 = "AT#CC1";
            string cmd7 = "AT*ID1";
            string cmd8 = "AT#CLS=8#CID=1";

            //if (comport.GetType == System.Int32)
            //    {
            if (InputBox("Enter COM Port#", "Enter the COM Port number to which modem is connected. (eg:1)", ref comport) == DialogResult.OK)
                {
            
                serialPort1.PortName = "COM" + comport;
                serialPort1.Open();
                serialPort1.WriteLine(cmd1 + System.Environment.NewLine);
                serialPort1.WriteLine(cmd2 + System.Environment.NewLine);
                serialPort1.WriteLine(cmd3 + System.Environment.NewLine);
                serialPort1.WriteLine(cmd4 + System.Environment.NewLine);
                serialPort1.WriteLine(cmd5 + System.Environment.NewLine);
                serialPort1.WriteLine(cmd6 + System.Environment.NewLine);
                serialPort1.WriteLine(cmd7 + System.Environment.NewLine);
                serialPort1.WriteLine(cmd8 + System.Environment.NewLine);
                serialPort1.WriteLine(cmd1);
                serialPort1.WriteLine(cmd2);
                serialPort1.WriteLine(cmd3);
                serialPort1.WriteLine(cmd4);
                serialPort1.WriteLine(cmd5);
                serialPort1.WriteLine(cmd6);
                serialPort1.WriteLine(cmd7);
                serialPort1.WriteLine(cmd8);
        }
            //    }
            //else
            //    MessageBox.Show("Invalid COM port format. Please input only the COM Port numbe");

            }



        private void btnExit_Click(object sender, EventArgs e)
            {
            serialPort1.Close();

            Environment.Exit(0);
            }

        public static DialogResult InputBox(string title, string promptText, ref string value)
            {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
            }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
            {
            string msg = serialPort1.ReadLine();
            string replace;
            int pt;
            msg = msg.ToUpper();
            if (msg.Contains("NAME"))
                {
                
                pt = msg.IndexOf("=");
                replace = msg.Substring(pt + 1);
                lblName.Text = replace;
                lblName.Visible = true;
                }
            if (msg.Contains("NMBR"))
                {
                pt = msg.IndexOf("=");
                replace = msg.Substring(pt + 1);
                lblName.Text = replace;
                lblPh.Visible = true;
                }
            }



        private void timer1_Tick(object sender, EventArgs e)
            {
            string tim = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            string dte = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

            lblTime.Text = tim;
            lblDate.Text = dte;
            
            }


        }
    }