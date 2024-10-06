using Subject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Yotube通知推送練習
{
    public partial class Form1 : Form
    {
        public Youtuber MrGao = new Youtuber("MrGao");
        //public Channel Mr_Mrs_Gao = new Channel("Mr_Mrs_Gao");
        //public Channel Mr_and_Mrs = new Channel("Mr_and_Mrs");
        Channel Mr_Mrs_Gao = new Channel("Mr_Mrs_Gao");
        Channel Mr_and_Mrs = new Channel("Mr_and_Mrs");

        //public Subject<News> Form1Subject = new Subject<News>();

        public Form1()
        {
            InitializeComponent();
            MrGao.AddChannel(Mr_Mrs_Gao);
            MrGao.AddChannel(Mr_and_Mrs);

        }
        public void UpdateInfo(FlowLayoutPanel flowLayoutPanel)
        {
            flowLayoutPanel1.Controls.Add(flowLayoutPanel);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            YoutuberForm form = new YoutuberForm(this, MrGao);
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm(this, MrGao);
            form.Show();
        }
    }
}
