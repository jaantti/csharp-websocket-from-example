using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        WebSocket ws;
        public Form1()
        {
            InitializeComponent();
            ws = new WebSocket("wss://themis.arti.ee/socket");
            ws.OnMessage += onMessage;
            ws.Connect();

        }

        private void onMessage(object sender, MessageEventArgs e)
        {
            if (!e.IsPing)
            {
                textBox1.Invoke(new Action(() => textBox1.Text += e.Data));                
                Console.WriteLine(e.Data);
            }
        }
    }
}
