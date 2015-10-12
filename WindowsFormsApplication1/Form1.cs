using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  public partial class Form1 : Form
  {
    Synth synth = new Synth();
		Timer MyTimer = new Timer();
		

		public Form1()
    {
      InitializeComponent();

			MyTimer.Interval = (5);
			MyTimer.Tick += new EventHandler(MyTimer_Tick);

			trackBar1.Maximum = 2000;
			trackBar1.Minimum = 30;
			trackBar1.TickFrequency = 5;
      trackBar1.LargeChange = 20;
      trackBar1.SmallChange = 2;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
			 
    }

    private void button1_Click(object sender, EventArgs e)
    {
      synth.StartStopSineWave();
    }

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
		}
		
		private void trackBar1_MouseDown(object sender, EventArgs e)
		{
			MyTimer.Start();
		}

		private void trackBar1_MouseUp(object sender, EventArgs e)
		{
			MyTimer.Stop();
		}
		
		private void MyTimer_Tick(object sender, EventArgs e)
		{
			synth.setFrequency((float)this.trackBar1.Value);
		}
	}
}
