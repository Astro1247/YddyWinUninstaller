using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace YddyWinUninstaller
{
    public enum MonitorState
    {
        MonitorStateOn = -1,
        MonitorStateOff = 2,
        MonitorStateStandBy = 1
    }
    public partial class MainForm : Form, IMessageFilter
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN &&
                controlsToMove.Contains(Control.FromHandle(m.HWnd)))
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                return true;
            }
            return false;
        }


        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);

        public MainForm()
        {
            InitializeComponent();
            //Application.AddMessageFilter(this);

            //controlsToMove.Add(this);
            
            //controlsToMove.Add(this.label1);
            //controlsToMove.Add(this.label2);
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;


        }

        void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            SetMonitorInState(MonitorState.MonitorStateOff);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            this.button1.Enabled = false;
            say("О, нет..\nЧто же ты наделал..\nТы слышишь это?...\nЧто-то происходит...", 4500);
            this.label1.Visible = false;
            this.label2.Visible = false;
            say("Куда все делось?\nЧто происходит?...\nМне страшно :(", 6500);
            
            this.WindowState = FormWindowState.Maximized;
            this.progressBar1.Visible = true;
            button1.Scale(1, 0.3f);
            for (int i = 0; i < 100; i++)
            {
                switchButton();
                this.BackColor = Color.Blue;
                button1.BackColor = Color.Red;
                delay(rnd.Next(3,400));
                switchButton();
                this.BackColor = Color.Red;
                button1.BackColor = Color.Blue;
                delay(rnd.Next(3, 400));
                this.progressBar1.Value = i;
                switchButton();
            }
            this.button1.Visible = false;
            this.button1.Update();
            this.BackColor = Color.FromArgb(33, 33, 33);
            this.progressBar1.Visible = false;
            //this.WindowState = FormWindowState.Normal;
            controlsToMove.Add(this);
            delay(5000);

            centerlabel.Visible = true;
            sayc("Хм, кажется это закончилось?", 2000);
            sayc("", 4000);
            sayc("Интересно, а WINDOWS еще работает?...", 3000);
            sayc("", 4000);
            sayc("О, нет...", 2000);
            sayc("Я просто кое-что вижу...", 3000);
            sayc("Ты пока не видишь, да?...", 4000);
            sayc("Тут кое-что приближается..", 4000);
            sayc("Прости...", 2500);
            sayc("", 4000);
            for (int i = 0; i < 35; i++)
            {
                this.BackColor = Color.FromArgb(33, 33, 33);
                delay(rnd.Next(1, 250));
                this.BackColor = Color.FromArgb(255, 215, 50);
                delay(rnd.Next(1, 250));
                this.BackColor = Color.FromArgb(250, 250, 250);
                delay(rnd.Next(1, 250));
                this.BackColor = Color.FromArgb(253, 167, 59);
                delay(rnd.Next(1, 250));
            }

            this.BackColor = Color.FromArgb(33, 33, 33);
            sayc("", 10000);
            sayc("Эмм... Ты еще тут??", 4000);
            sayc("", 4000);
            sayc("Странно..", 4000);
            sayc("", 4000);
            sayc("А, вижу, вот теперь мне становится страшно...", 4000);
            sayc("", 4000);
            sayc("Прощай", 2000);
            sayc("", 4000);
            sayc("А, еще кое что, помни, движение мышки тебе поможет!", 4000);
            sayc("", 4000);

            for (int i = 0; i < 150; i++)
            {
                SetMonitorInState(MonitorState.MonitorStateOff);
                Thread.Sleep(50);
            }
            sayc("", 10000);
            sayc("Фух, еле пронесло, а ты там как?", 5000);
            sayc("Пора бы заканчивать эти шутки...", 4000);
            sayc("Я поищу кнопку...", 4000);
            sayc("", 6000);
            sayc("Кажется нашел, сейчас попробую показать ее", 5000);
            sayc("", 2000);
            sayc("Видишь кнопку выхода?", 2500);
            sayc("Как нет?..", 2000);
            sayc("Блин, погоди...", 2500);
            sayc("", 4000);
            button2.Visible = true;
            button2.Update();
            sayc("Жми быстрее!!!", 2000);
            sayc("", 4000);
            sayc("Эм, ты почему не вышел?", 4000);
            sayc("", 4000);
            sayc("В смысле не нажимается?...", 2500);
            sayc("Секунду...", 2000);
            sayc("", 4000);
            button2.Enabled = true;
            button2.Update();
            sayc("Пробуй", 4000);
        }

        public int state = 1;

        public void switchButton()
        {
            switch (state)
            {
                case 1:
                    say("Удаляем WINDOWS.");
                    state++;
                    break;
                case 2:
                    say("Удаляем WINDOWS. .");
                    state++;
                    break;
                case 3:
                    say("Удаляем WINDOWS. . .");
                    state++;
                    break;
                case 4:
                    say("Удаляем WINDOWS. . . .");
                    state++;
                    break;
                case 5:
                    say("Удаляем WINDOWS. . .");
                    state++;
                    break;
                case 6:
                    say("Удаляем WINDOWS. .");
                    state++;
                    break;
                case 7:
                    say("Удаляем WINDOWS.");
                    state++;
                    break;
                case 8:
                    say(".Удаляем WINDOWS");
                    state++;
                    break;
                case 9:
                    say(". .Удаляем WINDOWS");
                    state++;
                    break;
                case 10:
                    say(". . .Удаляем WINDOWS");
                    state++;
                    break;
                case 11:
                    say(". . . .Удаляем WINDOWS");
                    state++;
                    break;
                case 12:
                    say(". . .Удаляем WINDOWS");
                    state++;
                    break;
                case 13:
                    say(". .Удаляем WINDOWS");
                    state++;
                    break;
                case 14:
                    say(".Удаляем WINDOWS");
                    state = 1;
                    break;
                default:
                    state = 1;
                    break;
            }
        }

        public void say(string text, int delay = 0)
        {
            this.button1.Text = text;
            this.button1.Update();
            if (delay != 0) MainForm.delay(delay);
        }

        public void sayc(string text, int delay = 0)
        {
            centerlabel.Text = text;
            centerlabel.Update();
            if(delay != 0) MainForm.delay(delay);
        }

        public void wait(int msec)
        {
            Thread.Sleep(msec);
        }



        public static void delay(int seconds)
        {
            if (seconds < 1) return;
            DateTime _desired = DateTime.Now.AddMilliseconds(seconds);
            while (DateTime.Now < _desired)
            {
                Thread.Sleep(1);
                System.Windows.Forms.Application.DoEvents();
            }
        }



        private void SetMonitorInState(MonitorState state)
        {
            SendMessage(0xFFFF, 0x112, 0xF170, (int)state);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
