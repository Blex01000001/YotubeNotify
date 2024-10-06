using Subject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Reflection.Emit;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Yotube通知推送練習
{

    public partial class UserForm : Form
    {
        //Subject<FlowLayoutPanel> UserFormSubject = new Subject<FlowLayoutPanel>("UserForm");
        //Subscription<FlowLayoutPanel> UserFormSubscription;
        Form1 form1;
        Youtuber youtuber;
        public UserForm(Form1 form1, Youtuber youtuber)
        {
            InitializeComponent();
            this.youtuber = youtuber;
            this.form1 = form1;
            Channel.NotifyForm1Sub.Add("", x =>
            {
                form1.UpdateInfo(x);
            });
            Channel.Notifyfollower.Add("", x =>
            {
                form1.UpdateInfo(x);
                Console.WriteLine("info to followers");
            });
            Channel.NotifyForm1unSub.Add("", x =>
            {
                this.flowLayoutPanel1.Controls.Add(x);
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            User follower = new User(textBox1.Text);
            SubscriberControl subscriberControl = new SubscriberControl(youtuber.ChannelList[0], follower);
            FlowLayoutPanel panel = GenerateFlowLayoutPanel(youtuber.ChannelList[0], follower);
            FlowLayoutPanel panel2 = GenerateFlowLayoutPanel2(youtuber.ChannelList[0], follower);
            FlowLayoutPanel panel3 = GenerateFlowLayoutPanel3(youtuber.ChannelList[0], follower);
            //youtuber.ChannelList[0].AddUsers(follower);
            youtuber.ChannelList[0] += follower;
            //youtuber.ChannelList[0].NotifyForm1unSub.Update(panel);
            //youtuber.ChannelList[0].NotifyForm1Sub.Update(panel);
            flowLayoutPanel1.Controls.Add(subscriberControl);
            subscriberControl.UnsubscribeNotify += unSubscribe;
            textBox1.Text = "";
        }
        private  FlowLayoutPanel GenerateFlowLayoutPanel(Channel channel, User user)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Size = new System.Drawing.Size(500, 25);
            Label label = new Label();
            label.Size = new System.Drawing.Size(500, 25);
            label.Text = user.name + " 剛剛訂閱了 " + Channel.Name + " 頻道!! ";
            flowLayoutPanel.Controls.Add(label);
            return flowLayoutPanel;
        }

        private void unSubscribe(object sender, User e)
        {
            youtuber.ChannelList[0].Remove(e);
            flowLayoutPanel1.Controls.Remove((SubscriberControl)sender);
        }
        private FlowLayoutPanel GenerateFlowLayoutPanel2(Channel channel, User user)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Size = new System.Drawing.Size(400, 25);
            Label label = new Label();
            label.Size = new System.Drawing.Size(200, 25);
            label.Text = user.name + " 收到了 " + Channel.Name + " 頻道的上片通知 ";
            flowLayoutPanel.Controls.Add(label);
            return flowLayoutPanel;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private FlowLayoutPanel GenerateFlowLayoutPanel3(Channel channel, User user)
        {
            Button btn = new Button();
            btn.Text = "unSubscribe";
            btn.Size = new System.Drawing.Size(100, 30);
            //btn.Click += unSubscribe;
            btn.Tag = user;
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Size = new System.Drawing.Size(500, 25);
            Label label = new Label();
            label.Size = new System.Drawing.Size(300, 25);
            label.Text = user.name + " 剛剛訂閱了 " + Channel.Name + " 頻道!! ";
            flowLayoutPanel.Controls.Add(label);
            flowLayoutPanel.Controls.Add(btn);
            return flowLayoutPanel;
        }

    }
}
