using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindMatching
{
    public partial class Form1 : Form
    {
        private const int buttonCount = 4;

        private int countselect = 0;
        private int time;
        Button clickedButton1;
        Button clickedButton2;
        Button button;
        PictureBox pictureBox;
        Label lblheart1 = new Label();
        Label lbltime = new Label();
        Label lblheart = new Label();
        Label sign = new Label();

        private int heart;
        const int imagesArrayLength = 16;
        
        List<string> imagesList = new List<string>
        {
            "pokemon/1.png",
            "pokemon/2.png",
            "pokemon/3.png",
            "pokemon/4.png",
            "pokemon/5.png",
            "pokemon/6.png",
            "pokemon/7.png",
            "pokemon/8.png",
         
        };
        List<string> images = new List<string>
        { };

        private void imagesMix()
        {
            List<string> imagesrnd = new List<string> { };
            int value;
            images.Clear();
            Controls.Clear();
            Random rnd = new Random();
            int count;
            for (int i = 0; i < imagesArrayLength; i++)
            {
                count = 0;
                value =rnd.Next(0, imagesArrayLength/2);

                foreach (var item in imagesrnd)
                {
                    if (item == imagesList[value]) { count++; } 
                }

                if (count <2)
                {
                    imagesrnd.Add(imagesList[value]);
                }
                else { i--; }
                
            }
          
            images = imagesrnd;
            
        }
        public Form1()
        {
            //var Random = new Random();

            InitializeComponent();
        }

        private void gameLoad()
        {

            imagesMix();
            time = 15;
            heart = 3;
            int j = 0;
            for (int i = 0; i < buttonCount; i++)
            {
                for (int k = 0; k < buttonCount; k++)
                {
                    button = new Button();
                    button.Width = 100;
                    button.Height = 100;
                    button.Left = i * 105;
                    button.Top = k * 105;
                    button.Text = "";
                    button.Click += Button_Click;
                    button.Tag = images[j];
                    button.BringToFront();
                    button.Visible = true;
                    button.TabStop = false;
                    button.BackColor = Color.LightCyan;
                    Controls.Add(button);


                    pictureBox = new PictureBox();
                    pictureBox.Width = 100;
                    pictureBox.Height = 100;
                    pictureBox.Left = i * 105;
                    pictureBox.Top = k * 105;
                    pictureBox.SendToBack();
                    pictureBox.Image = Image.FromFile(images[j]);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    Controls.Add(pictureBox);

                    j++;
                }
            }

            lbltime.Top = 50;
            lbltime.Left = 550;
            lbltime.Text = time.ToString();
            lbltime.Font = new Font("Verdana", 18);
            Controls.Add(lbltime);

            lblheart1.Top = 100;
            lblheart1.Left = 550;
            lblheart1.Text = "Heart : ";
            lblheart1.Font = new Font("Verdana", 18);
            Controls.Add(lblheart1);


            lblheart.Top = 100;
            lblheart.Left = 650;
            lblheart.Text = heart.ToString();
            lblheart.Font = new Font("Verdana", 18);
            Controls.Add(lblheart);

            sign.Top = 350;
            sign.Width = 600;
            sign.Left = 475;
            sign.Text = "Eyyüb TEZCAN www.eyyub.com";
            sign.Font = new Font("Verdana", 10);
            Controls.Add(sign);

            Button btnReset;
            btnReset = new Button();
            btnReset.Width = 200;
            btnReset.Height = 100;
            btnReset.Left = 500;
            btnReset.Top = 200;
            btnReset.Text = "Start Game Again";
            btnReset.Click += BtnReset_Click;
            btnReset.Font = new Font("Verdana", 18);
            Controls.Add(btnReset);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            gameLoad();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            //Width = 328;
            //Height = 350;
            gameLoad();

        }
        private void Button_Click(object sender, EventArgs e)
        {

            var clickedButton = (Button)sender;
            clickedButton.Visible = false;

            if (countselect == 0)
            {
                clickedButton1 = clickedButton;
                countselect++;
            }
            else if (countselect == 1)
            {
                timer1.Start();
                clickedButton2 = clickedButton;


                if (clickedButton1.Tag != clickedButton2.Tag)
                {
                    clickedButton1.Visible = true;
                    clickedButton2.Visible = true;
                    heart--;

                    lblheart.Text = heart.ToString();
                    if (heart == 0)
                    {
                        MessageBox.Show("Kaybettiniz.");
                        MessageBox.Show("Oyun Yeniden Başlıyor...");
                      
                        gameLoad();
                    }
                }
                countselect = 0;
                clickedButton1 = null;
                clickedButton2 = null;
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            lbltime.Text = time.ToString();
            if (time == 0)
            {
                timer1.Stop();
                MessageBox.Show("Kaybettiniz... Oyun Yeniden başlıyor.");
              
                gameLoad();
            }
        }
    }
}
