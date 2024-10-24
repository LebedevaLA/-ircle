using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace training2
{
    public partial class Form1 : Form
    {
        private int n;
        private int m;
        private List<List<bool>> space;
        private Point curr;
        private int h;
        public Form1()
        {
            InitializeComponent();
            panel1.BackColor = Color.White;
            panel1.Height = 240;
            panel1.Width = 240;
            n = 8;
            m = 8;
            h = 0;
            space = new List<List<bool>>();
            for(int i = 0; i < n; i++)
            {
                List<bool> tmp=new List<bool>();
                for(int j = 0; j < m; j++)
                {
                    tmp.Add(false);   
                }
                space.Add(tmp);
            }
            listBox1.Enabled = false;
            button6.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            curr.X = -1;
            curr.Y = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics Draw_space = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Gray);
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if (space[i][j] == true)
                    {
                        Draw_space.FillRectangle(brush, i * 30, j * 30, 30, 30);
                    }
                }
            }
            if (curr.X != -1 && curr.Y != -1 && timer1.Enabled==false)
            {
                SolidBrush brush1 = new SolidBrush(Color.Red);
                Draw_space.FillEllipse(brush1, curr.X * 30, curr.Y * 30, 30, 30);
            }
            if (timer1.Enabled == true && listBox1.Items.Count!=0)
            {
                
               
                if (listBox1.Items[h].ToString() == "Вверх")
                {
                    curr.Y -= 1;
                }
                if (listBox1.Items[h].ToString() == "Вниз")
                {
                    curr.Y += 1;
                }
                if (listBox1.Items[h].ToString() == "Вправо")
                {
                    curr.X += 1;
                }
                if (listBox1.Items[h].ToString() == "Влево")
                {
                    curr.X -= 1;
                }
                h++;
                if (space[curr.X][curr.Y] == true)
                {
                    timer1.Stop();
                    h = 0;
                    Draw_space.Clear(Color.White);
                    MessageBox.Show("Game Over");
                    //Draw_space.Clear(Color.White);
                }
                if (h == listBox1.Items.Count)
                {
                    timer1.Stop();
                    button6.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    //space.Clear();
                    h = 0;
                }
                SolidBrush brush1 = new SolidBrush(Color.Red);
                Draw_space.FillEllipse(brush1, curr.X * 30, curr.Y * 30, 30, 30);
                
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = "Вверх";
            listBox1.Items.Add(text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string text = "Вниз";
            listBox1.Items.Add(text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = "Вправо";
            listBox1.Items.Add(text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = "Влево";
            listBox1.Items.Add(text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int count = rnd.Next(5,12);
            int i;
            int j;
            int c=rnd.Next(0,n);
            int d=rnd.Next(0,m);
            for(int k = 0; k < count; k++)
            {
                i = rnd.Next(0, n);
                j = rnd.Next(0, m);
                space[i][j] = true;
            }
            while (space[c][d] == true)
            {
                c = rnd.Next(0, 8);
                d = rnd.Next(0, 8);
            }
            curr = new Point(c, d);
            listBox1.Enabled = true;
            button6.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            panel1.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //start
            listBox1.Enabled = false;
            timer1.Start(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            panel1.Refresh();
        }
    }
}

