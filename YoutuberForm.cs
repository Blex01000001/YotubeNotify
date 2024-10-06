using Subject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Yotube通知推送練習
{
    public partial class YoutuberForm : Form
    {
        //Subject<FlowLayoutPanel> YoutuberFormSubject = new Subject<FlowLayoutPanel>("YoutuberForm");
        //Subscription<FlowLayoutPanel> YoutuberFormSubscription;

        Youtuber youtuber;


        public YoutuberForm(Form1 form1, Youtuber youtuber)
        {
            InitializeComponent();
            this.youtuber = youtuber;
            //YoutuberFormSubject.Add("form1", x =>
            //{
            //    form1.UpdateInfo(x);
            //});
        }

        private void button1_Click(object sender, EventArgs e)
        {
            News news = new News(textBox1.Text, textBox2.Text);
            //FlowLayoutPanel panel = GenerateFlowLayoutPanel(youtuber.ChannelList[0]);
            FlowLayoutPanel panel = GenerateFlowLayoutPanel2(youtuber.ChannelList[0], news);
            Channel.Notifyfollower.Update(panel);
            Channel.NotifyForm1Sub.Update(panel);
            youtuber.ChannelList[0].PushInfo();
            //YoutuberFormSubject.Update(panel);
            //youtuber.ChannelList[0].Update(panel);
        }

        private FlowLayoutPanel GenerateFlowLayoutPanel(Channel channels)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Size = new System.Drawing.Size(400, 25);
            Label label = new Label();
            label.Size = new System.Drawing.Size(200, 25);
            label.Text = Channel.Name + " 頻道剛剛發布了新影片!! ";
            flowLayoutPanel.Controls.Add(label);
            return flowLayoutPanel;
        }
        private FlowLayoutPanel GenerateFlowLayoutPanel2(Channel channel, News news)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Size = new System.Drawing.Size(400, 25);
            Label label = new Label();
            label.Size = new System.Drawing.Size(200, 25);
            label.Text = Channel.Name + " 頻道剛剛發布了新影片!! " + "標題: " + news.title + ", 內容: " + news.content;
            flowLayoutPanel.Controls.Add(label);
            return flowLayoutPanel;
        }


    }
}
