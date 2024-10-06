using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yotube通知推送練習
{
    public partial class SubscriberControl : UserControl
    {
        Channel channel;
        User user;
        public event EventHandler<User> UnsubscribeNotify;
        public SubscriberControl(Channel channel, User user)
        {
            InitializeComponent();
            this.channel = channel;
            this.user = user;
            label1.Text = user.name + " 剛剛訂閱了 " + Channel.Name + " 頻道!! ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Tag = user;
            //button1.Click += unSubscribe;
            UnsubscribeNotify.Invoke(this, user);
        }
        private void unSubscribe(object sender, EventArgs e)
        {
            channel.RemoveFollowers(sender);
        }

    }
}
