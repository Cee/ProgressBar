using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lab_5
{
    public partial class Form1 : Form
    {

        bool click = false;
        private System.Threading.Timer timer;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            this.label1.Text = this.progressBar1.Value.ToString() + "%";
            this.label2.Text = this.progressBar2.Value.ToString() + "%";
            this.label3.Text = this.progressBar3.Value.ToString() + "%";
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 100;
            this.progressBar1.Step = 1;
            this.progressBar2.Minimum = 0;
            this.progressBar2.Maximum = 100;
            this.progressBar2.Step = 1;
            this.progressBar3.Minimum = 0;
            this.progressBar3.Maximum = 100;
            this.progressBar3.Step = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!click)
            {
                click = true;
                timer = new System.Threading.Timer(new TimerCallback(Counting), null, 0, 50);
            }
        }


        void Counting(Object state)
        {
            MethodInvoker mi1 = new MethodInvoker(ThreadingBar1);
            this.progressBar1.BeginInvoke(mi1);
        }

        public void ThreadingBar1()
        {

            if (progressBar1.Value >= 99)
            {
                progressBar1.Value = 0;
            }
            else
            {
                progressBar1.PerformStep();
            }
            //Console.WriteLine("bar1:" + progressBar1.Value);
            this.label1.Text = this.progressBar1.Value.ToString() + "%";
            if (progressBar1.Value % 10 == 0)
            {
                MethodInvoker mi2 = new MethodInvoker(ThreadingBar2);
                this.progressBar2.BeginInvoke(mi2);
            }
            
        }

        public void ThreadingBar2()
        {
            if (progressBar2.Value >= 99)
            {
                progressBar2.Value = 0;
            }
            else
            {
                progressBar2.PerformStep();
            }
            //Console.WriteLine("bar2:" + progressBar2.Value);
            this.label2.Text = this.progressBar2.Value.ToString() + "%";
            if (progressBar2.Value % 10 == 0)
            {
                MethodInvoker mi3 = new MethodInvoker(ThreadingBar3);
                this.progressBar3.BeginInvoke(mi3);
            }
        }

        public void ThreadingBar3()
        {
            progressBar3.PerformStep();
            //Console.WriteLine("bar3:" + progressBar3.Value);
            this.label3.Text = this.progressBar3.Value.ToString() + "%";
        }
    }
}
