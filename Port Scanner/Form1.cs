using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Port_Scanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("You must introduce an IP Address");
            }
            else
            {
                listBox1.Items.Clear();
                if (radioButton1.Checked)
                {
                    progressBar1.Visible = true;
                    progressBar1.Maximum = 1024;
                    progressBar1.Value = 0;
                    //Recoge la direccion ip del textbox1
                    string ip = textBox1.Text;
                    //65535

                    for (int actualPort = 0; actualPort < 1024; actualPort++)
                    {
                        progressBar1.Step = 1;
                        progressBar1.Visible = true;
                        progressBar1.PerformStep();

                        try
                        {
                            TcpClient client = new TcpClient(ip, actualPort);
                            listBox1.Items.Add("IP: " + ip + "  PORT: " + actualPort + " STATUS: OPEN");
                    
                        }
                        catch (Exception ex)
                        {
                            //listBox1.Items.Add("IP: " + ip + "  PORT: " + actualPort + "STATUS: CLOSED");
                        }
                    }

                }
                else if (radioButton2.Checked)
                {

                    if (String.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("You must introduce a Port");

                    }
                    else
                    {

                        progressBar1.Maximum = 1;
                        //Recoge la direccion ip del textbox1
                        string ip = textBox1.Text;

                        //Recoge el puerto indicado
                        int ipPort = int.Parse(textBox2.Text);


                        try
                        {
                            TcpClient client = new TcpClient(ip, ipPort);
                            listBox1.Items.Add("IP: " + ip + "  PORT: " + ipPort + "   STATUS: OPEN");
                            progressBar1.Step = 1;
                            progressBar1.PerformStep();
                        }
                        catch (Exception ex)
                        {
                            listBox1.Items.Add("IP: " + ip + "  PORT: " + ipPort + "   STATUS: CLOSED");
                            progressBar1.Step = 1;
                            progressBar1.PerformStep();
                        }


                    }
             
                }

            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/antonio-castillo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            System.Environment.Exit(0);

        }
    }
}
