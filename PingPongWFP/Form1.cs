using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPongWFP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ChkbOnOff.Click += ChkbOnOff_Click;

        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {

            this.Text = DateTime.Now.TimeOfDay + " " + DateTime.Now.ToLongDateString();
        }

        
        private void NumUpDownPingPongBallSpeed_ValueChanged(object sender, EventArgs e)
        {
         //   this.pingPong1.PingPongBallSpeed((int)this.numUpDownPingPongBallSpeed.Value);
        }

        private void ChkbOnOff_Click(object sender, EventArgs e)
        {
            this.pingPong2.StartStop(true);
        }
    }
}
