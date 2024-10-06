using Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yotube通知推送練習
{
    public class Youtuber
    {
        public List<Channel> ChannelList = new List<Channel>();
        public string YoutuberName;
        public Youtuber(string name)
        {
            this.YoutuberName = name;
        }
        public void AddChannel(Channel channel)
        {
            ChannelList.Add(channel);
        }

    }
}
