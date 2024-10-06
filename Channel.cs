using Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yotube通知推送練習
{
    public class Channel
    {
        public static string Name;
        public static List<User> UserList = null;
        public static Subject<FlowLayoutPanel> NotifyForm1Sub = new Subject<FlowLayoutPanel>("");
        public static Subject<FlowLayoutPanel> Notifyfollower = new Subject<FlowLayoutPanel>("");
        public static Subject<FlowLayoutPanel> NotifyForm1unSub = new Subject<FlowLayoutPanel>("");

        public Channel(string ChannelName)
        {
            UserList = new List<User>();
            Name = ChannelName;
        }

        public void AddUsers(User user)
        {
            UserList.Add(user);
        }
        public static Channel operator + (Channel channel, User user)
        {
            UserList.Add(user);
            NotifyForm1Sub.Update(GenerateFlowLayoutPanel2(channel, user));
            return channel;
        }

        public void PushInfo()
        {
            foreach (var user in UserList)
            {
                FlowLayoutPanel panel = GenerateFlowLayoutPanel4(this, user);
                NotifyForm1Sub.Update(panel);
            }
        }
        private static FlowLayoutPanel GenerateFlowLayoutPanel2(Channel channel, User user)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Size = new System.Drawing.Size(500, 25);
            Label label = new Label();
            label.Size = new System.Drawing.Size(500, 25);
            label.Text = user.name + " 剛剛訂閱了 " + Name + " 頻道!! ";
            flowLayoutPanel.Controls.Add(label);
            return flowLayoutPanel;
        }

        public void RemoveFollowers(object sender)
        {
            Button btn = (Button)sender;
            User user = (User)btn.Tag;
            UserList.Remove(user);
            FlowLayoutPanel panel = GenerateFlowLayoutPanel3(this, user);
            NotifyForm1Sub.Update(panel);
        }
        public void Remove(User user)
        {
            UserList.Remove(user);
        }

        private static FlowLayoutPanel GenerateFlowLayoutPanel3(Channel channel, User user)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Size = new System.Drawing.Size(500, 25);
            Label label = new Label();
            label.Size = new System.Drawing.Size(500, 25);
            label.Text = user.name + " 剛剛退訂了 " + Name + " 頻道!! ";
            flowLayoutPanel.Controls.Add(label);
            return flowLayoutPanel;
        }

        private static FlowLayoutPanel GenerateFlowLayoutPanel4(Channel channel, User user)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Size = new System.Drawing.Size(500, 25);
            Label label = new Label();
            label.Size = new System.Drawing.Size(500, 25);
            label.Text = user.name + " 剛剛收到了 " + Name + " 頻道的影片更新通知!! ";
            flowLayoutPanel.Controls.Add(label);
            return flowLayoutPanel;
        }
    }
}
