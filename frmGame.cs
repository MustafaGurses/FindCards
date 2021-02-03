using Bul_Beni.Class;
using Bul_Beni.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bul_Beni
{
    public partial class frmGame : Form
    {
        public frmGame()
        {
            InitializeComponent();
            clearButton = new ClearButton();
            setPath = new SetPath();
            btn2 = new List<Button>();
            BGWControlGame = new BackgroundWorker();
            BGWControlGame.DoWork += BGWControlGame_DoWork;
            CheckForIllegalCrossThreadCalls = false;
            points = new List<Point>();
        }
        ClearButton clearButton;
        int i_ = 0;
        List<Button> btn2;
        SetPath setPath;
        List<GeneratePath> generatePaths = new List<GeneratePath>();
        BackgroundWorker BGWControlGame;
        List<Point> points;
        private void frmGame_Load(object sender, EventArgs e)
        {
            clearButton.Clear(GetALL_Button());
            for(int i=0; i<Controls.Count; i++)
            {
                points.Add(Controls[i].Location);
            }
        }
        Button senderButton;
        private void Button_Click(object sender, EventArgs e)
        {
            generatePaths = setPath.Set(GetALL_Button());
            senderButton = sender as Button;
            if (!BGWControlGame.IsBusy)
                BGWControlGame.RunWorkerAsync();
        }
        private void BGWControlGame_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!btn2.Contains(senderButton))
            {
                btn2.Add(senderButton);
                var btn_ = generatePaths.Where(x => x.FileButton1 == senderButton).Select(x => x.FilePath1);
                senderButton.BackgroundImage = Image.FromFile(btn_.Select(x => x.ToString()).FirstOrDefault());
                i_++;
            }
            if (i_ == 2)
            {
                i_ = 0;
                if (clearButton.Control(generatePaths,btn2[0], btn2[1]))
                {
                    Thread.Sleep(1000);
                    this.Controls.Remove(btn2[0]);
                    this.Controls.Remove(btn2[1]);
                    UserManager.Puan += 10;
                    Text = UserManager.s + UserManager.Puan;
                    btn2.Clear();
                }
                else
                {
                    Thread.Sleep(1000);
                    this.Controls[btn2[0].Name].BackgroundImage = clearButton.Default_Image;
                    this.Controls[btn2[1].Name].BackgroundImage = clearButton.Default_Image;
                    btn2.Clear();
                }
            }
        }
        private List<Button> GetALL_Button()
        {
            List<Button> temp_ = new List<Button>();
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is Button)
                    temp_.Add((Button)Controls[i]);
            }
            return temp_;
        }

        private void frmGame_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (Controls.Count == 0)
            {
                var result = MessageBox.Show("Tebrikler! Oyunu kazandınız.\n\nYeni bir oyuna ne dersin?", "Oyun Bitti", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Process.Start(Application.StartupPath + @"\Bul Beni.exe");
                    Application.Exit();
                }
                else
                    Application.Exit();
            }
        }
    }
}
