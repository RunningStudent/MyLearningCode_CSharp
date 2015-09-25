using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 播放器
{
    public partial class Form1 : Form
    {

        double allTime;//音乐文件总时间
        double currentTime;//当前播放时间
        List<string> lrc = new List<string>();//储存歌词
        List<double> lrcTimes = new List<double>();//储存每句歌词对应时间
        List<string> path = new List<string>();//存放音乐文件路径
        //每次播放前都要尝试载入歌词
        public Form1()
        {
            InitializeComponent();
        }

        #region groupbox里面的按钮
        private void button1_Click(object sender, EventArgs e)
        {
            Media.Ctlcontrols.play();
        }

        private void pauseBt_Click(object sender, EventArgs e)
        {
            Media.Ctlcontrols.pause();
        }

        private void stopBt_Click(object sender, EventArgs e)
        {
            Media.Ctlcontrols.stop();
        }
        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {
            Media.settings.autoStart = false;
        }

        
        /// <summary>
        /// 播放按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playBt_Click_1(object sender, EventArgs e)
        {
            if (Media.URL == "" && musiclB.SelectedItems.Count == 0)
            { return; }
            if (playBt.Text == "暂停")
            {
                Media.Ctlcontrols.pause();
                playBt.Text = "开始";

            }
            else
            {
                
                //点击播放按钮前有3个可能:1,未选择任何音乐2,选择中同一个音乐3,选择新的音乐
                if (Media.playState== WMPLib.WMPPlayState.wmppsPaused)
                {
                    //判断所选是否是正在播放的音乐文件,如果是则继续播放而不会重新播放
                    if (path[musiclB.SelectedIndex] != Media.currentMedia.sourceURL)
                    {
                        Media.URL = path[musiclB.SelectedIndex];
                        IncludeLrc(path[musiclB.SelectedIndex]);
                    }
                    Media.Ctlcontrols.play();
                }
                else//未选择任何音乐文件时
                {
                    Media.URL = path[musiclB.SelectedIndex];
                    IncludeLrc(path[musiclB.SelectedIndex]);
                    Media.Ctlcontrols.play();
                }
                    playBt.Text = "暂停";
            }
        }
       

        /// <summary>
        /// 打开对话框按钮,音乐文件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog oDial = new OpenFileDialog();
            oDial.InitialDirectory = @"E:\KuGou";
            oDial.Title = "打开文件";
            oDial.Filter = "音乐文件(*.wav,*.mp3)|*.wav;*.mp3|所有文件|*.*";
            oDial.Multiselect = true;
            oDial.ShowDialog();
            string[] str = oDial.FileNames;
            for (int i = 0; i < str.Length; i++)
            {
                path.Add(str[i]);
                musiclB.Items.Add(Path.GetFileNameWithoutExtension(str[i]));
            }
        }

        /// <summary>
        /// 音乐文件的listBox双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void musiclB_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (musiclB.Items.Count == 0)
                {
                    MessageBox.Show("请选择文件");
                    return;
                }
                if (Media.URL == path[musiclB.SelectedIndex]&&Media.playState==WMPLib.WMPPlayState.wmppsPlaying)
                {
                    //如果选中的文件已经在播放则无反应
                    return;
                }
                else
                {
                    Media.URL = path[musiclB.SelectedIndex];
                    IncludeLrc(path[musiclB.SelectedIndex]);
                    Media.Ctlcontrols.play();
                }
            }
            catch { }
        }


        /// <summary>
        /// 上一曲
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (musiclB.Items.Count == 0)
                {
                    MessageBox.Show("请选择文件");
                    return;
                }
                int selectIndex = musiclB.SelectedIndex;
                musiclB.ClearSelected();//列表能多选所以每次都要清除选择项
                selectIndex--;
                if (selectIndex < 0)
                {
                    selectIndex = musiclB.Items.Count - 1;
                }
                musiclB.SelectedIndex = selectIndex;
                Media.URL = path[selectIndex];
                IncludeLrc(path[musiclB.SelectedIndex]);
                Media.Ctlcontrols.play();
            }
            catch { }
        }
        /// <summary>
        /// 下一曲
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (musiclB.Items.Count == 0)
                {
                    MessageBox.Show("请选择文件");
                    return;
                }
                int selectIndex = musiclB.SelectedIndex;
                musiclB.ClearSelected();//列表能多选所以每次都要清除选择项
                selectIndex = (selectIndex + 1) % musiclB.Items.Count;
                musiclB.SelectedIndex = selectIndex;
                Media.URL = path[selectIndex];
                IncludeLrc(path[musiclB.SelectedIndex]);
                Media.Ctlcontrols.play();
            }
            catch { }
        }
        /// <summary>
        /// 停止按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopB_Click(object sender, EventArgs e)
        {
            Media.Ctlcontrols.stop();
        }
        /// <summary>
        /// 右键菜单的删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = musiclB.SelectedItems.Count;
            //SelectedIndex在多选状态下默认为多个选择的第一个
            for (int i = 0; i < count; i++)
            {
                path.RemoveAt(musiclB.SelectedIndex);
                musiclB.Items.RemoveAt(musiclB.SelectedIndex);
            }
        }
        /// <summary>
        /// 静音/放音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            //Tag:自定义的标记
            if (label1.Tag.ToString() == "静音")
            {
                label1.Tag = "放音";
                label1.Image = Image.FromFile(Application.StartupPath + @"\..\..\Resources\放音.png");
                Media.settings.mute = true;
            }
            else
            {
                label1.Tag = "静音";
                label1.Image = Image.FromFile(Application.StartupPath + @"\..\..\Resources\静音.png");
                Media.settings.mute = false;
            }
        }
        /// <summary>
        /// 音量加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volumeUp_Click(object sender, EventArgs e)
        {
            Media.settings.volume++;
        }
        /// <summary>
        /// 音量减
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volumeDown_Click(object sender, EventArgs e)
        {
            Media.settings.volume--;
        }

        
        
        /// <summary>
        /// 1,时间控件在musicInforLB显示歌曲信息
        /// 2,监控播放时间,播放完成自动播放下一曲
        /// 3,这个控件一直运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (Media.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                musicInforLB.Text = "时长:\n" + Media.currentMedia.durationString + "\n"
                                    + "已播放:\n" + Media.Ctlcontrols.currentPositionString;
                allTime= Media.currentMedia.duration;
                currentTime= Media.Ctlcontrols.currentPosition + 1;
                if (currentTime >= allTime)
                {
                    int selectIndex = musiclB.SelectedIndex;
                    musiclB.ClearSelected();//列表能多选所以每次都要清除选择项
                    selectIndex = (selectIndex + 1) % musiclB.Items.Count;
                    musiclB.SelectedIndex = selectIndex;
                    Media.URL = path[selectIndex];
                    IncludeLrc(path[musiclB.SelectedIndex]);
                    Media.Ctlcontrols.play();
                }
            }
            
        }

        /// <summary>
        /// 判断是否存在歌词,并载入歌词
        /// </summary>
        /// <param name="musicPath"></param>
        void IncludeLrc(string musicPath)
        {
            //每次歌词载入前先清空之前的歌词
            lrc.Clear();
            lrcTimes.Clear();
            musicPath += ".lrc";
            if (File.Exists(musicPath))
            {
                timer2.Enabled = true;//歌词存在,则开启这个时间控件
                lrcLb.Text = "";//清空lrcLb残余的文本
                FormatLrc(musicPath);
            }
            else
            {
                lrcLb.Text = "-----找不到歌词----";
                timer2.Enabled = false;
            }
        }
        /// <summary>
        /// 解析歌词并载入歌词和歌词时间
        /// </summary>
        /// <param name="lrcPath"></param>
        void FormatLrc(string lrcPath)
        {
            string[] timeAndLrc = File.ReadAllLines(lrcPath,Encoding.Default);
            for (int i = 0; i < timeAndLrc.Length; i++)
            {
                //[00:15.57]当我和世界不一样
                string[] lrcTemp = timeAndLrc[i].Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                //00:15.57
                //当我和世界不一样
                string[] lrcNewTemp = lrcTemp[0].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                lrc.Add(lrcTemp[1]);
                lrcTimes.Add(double.Parse(lrcNewTemp[0]) * 60 + double.Parse(lrcNewTemp[1]));
            }
        }
        
        /// <summary>
        /// 用于实时显示歌词
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < lrcTimes.Count; i++)
            {
                if (currentTime > lrcTimes[i] && currentTime < lrcTimes[i + 1])
                {
                    lrcLb.Text = lrc[i];
                }
            }
        }

    }
}
