using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3_1c
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp_pic;
        string img;
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpeg;*.jpg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.img = ofd.FileName;
                    bmp_pic = new Bitmap(this.img);
                }
                pictureBox1.Image = bmp_pic;
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        bool mouse_down = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_down = true;
            if(mouse_down)
            {
                Connected(e.X, e.Y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_down = false;
        }

        //int[] Left_Bound(int x, int y)
        //{
        //    Color col = bmp_pic.GetPixel(x, y);
        //    Color cur_col = col;
        //    int new_x = x;
        //    while(new_x != 1 && cur_col == col)
        //    {
        //        new_x--;
        //        cur_col = bmp_pic.GetPixel(new_x, y);
        //    }
        //    bmp_pic.SetPixel(new_x, y, Color.Black);
        //    int[] coord = new int[2];
        //    coord[0] = new_x;
        //    coord[1] = y;
        //    return coord;
        //}
        //int[] Right_Bound(int x, int y)
        //{
        //    Color col = bmp_pic.GetPixel(x, y);
        //    Color cur_col = col;
        //    int new_x = x;
        //    while (new_x != pictureBox1.Width - 1 && cur_col == col)
        //    {
        //        new_x++;
        //        cur_col = bmp_pic.GetPixel(new_x, y);
        //    }
        //    bmp_pic.SetPixel(new_x, y, Color.Black);
        //    int[] coord = new int[2];
        //    coord[0] = new_x;
        //    coord[1] = y;
        //    return coord;
        //}
        //int[] Up_Bound(int x, int y)
        //{
        //    Color col = bmp_pic.GetPixel(x, y);
        //    Color cur_col = col;
        //    int new_y = y;
        //    while (new_y != 1 && cur_col == col)
        //    {
        //        new_y--;
        //        cur_col = bmp_pic.GetPixel(x, new_y);
        //    }
        //    bmp_pic.SetPixel(x, new_y, Color.Black);
        //    int[] coord = new int[2];
        //    coord[0] = x;
        //    coord[1] = new_y;
        //    return coord;
        //}
        //int[] Down_Bound(int x, int y)
        //{
        //    Color col = bmp_pic.GetPixel(x, y);
        //    Color cur_col = col;
        //    int new_y = y;
        //    while (new_y != pictureBox1.Height - 1 && cur_col == col)
        //    {
        //        new_y++;
        //        cur_col = bmp_pic.GetPixel(x, new_y);
        //    }
        //    bmp_pic.SetPixel(x, new_y, Color.Black);
        //    int[] coord = new int[2];
        //    coord[0] = x;
        //    coord[1] = new_y;
        //    return coord;
        //}

        void Connected(int x, int y)
        {
            Color col = bmp_pic.GetPixel(x, y);
            Color cur_col = col;
            int left_bound = x;
            while(left_bound != 1 && cur_col == col)
            {
                left_bound--;
                cur_col = bmp_pic.GetPixel(left_bound, y);
            }
			left_bound++;
            int x_cur = left_bound;
			int y_cur = y;
            //bmp_pic.SetPixel(x_cur, y_cur+1, Color.Black);
            while (true)
            {
				//MessageBox.Show(" ");
				pictureBox1.Image = bmp_pic;
                //if (x_cur == left_bound+1 && y_cur == y)
                //    break;
                //else
                if (x_cur - 1 != 1 && bmp_pic.GetPixel(x_cur - 1, y_cur) == col && bmp_pic.GetPixel(x_cur, y_cur + 1) != col/* && bmp_pic.GetPixel(x_cur, y_cur -1) != col*/)
				{
					cur_col = bmp_pic.GetPixel(x_cur - 1, y_cur);
					x_cur--;
					while (x_cur != 1 && cur_col == col)
					{

						cur_col = bmp_pic.GetPixel(x_cur, y_cur);
						bmp_pic.SetPixel(x_cur, y_cur, Color.Black);
					}
				}
				
				else if (y_cur - 1 != 1 && bmp_pic.GetPixel(x_cur, y_cur - 1) == col && bmp_pic.GetPixel(x_cur - 1, y_cur) != col)
				{
					cur_col = bmp_pic.GetPixel(x_cur, y_cur - 1);
					y_cur--;
					while (y_cur != 1 && cur_col == col)
					{

						cur_col = bmp_pic.GetPixel(x_cur, y_cur);
						bmp_pic.SetPixel(x_cur, y_cur, Color.Black);
						//MessageBox.Show(" ");
					}
				}
				else
				if (x_cur + 1 != pictureBox1.Width - 1 && bmp_pic.GetPixel(x_cur + 1, y_cur) == col)
				{
					cur_col = bmp_pic.GetPixel(x_cur + 1, y_cur);
					x_cur++;
					while (x_cur != 1 && cur_col == col)
					{

						cur_col = bmp_pic.GetPixel(x_cur, y_cur);
						bmp_pic.SetPixel(x_cur, y_cur, Color.Black);
						//MessageBox.Show(" ");
					}
				}
				else if (y_cur + 1 != pictureBox1.Height - 1 && bmp_pic.GetPixel(x_cur, y_cur + 1) == col)
				{
					cur_col = bmp_pic.GetPixel(x_cur, y_cur + 1);
					y_cur++;
					while (x_cur != 1 && cur_col == col)
					{

						cur_col = bmp_pic.GetPixel(x_cur, y_cur);
						bmp_pic.SetPixel(x_cur, y_cur, Color.Black);
						//MessageBox.Show(" ");
					}
				}
				
				else
                    break;
                pictureBox1.Image = bmp_pic;
            }
            pictureBox1.Image = bmp_pic;
        }
    }
}
