using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BNImageCryptor_CSharp
{
    public partial class Frame : Form
    {

        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();
        Bitmap b;

        public Frame()
        {
            ofd.Filter = "Images(*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp|Files(*.*)|*.*";
            ofd.Title = "Select Image";
            sfd.AddExtension = true;
            sfd.Filter = "Images(*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp|Files(*.*)|*.*";
            sfd.Title = "Select Image";
            InitializeComponent();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {



            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ofd.Dispose();
                b = new Bitmap(ofd.FileName);
                lb_I.Text = "Image Information: Width:" + b.Width+" Height:"+b.Height;

            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (ofd.FileName.Length<=0)
            {
                MessageBox.Show("You need choose a image!", "Error:",MessageBoxButtons.OK,MessageBoxIcon.Error); return;
            }

            if (tb_PW.Text.Length<=0)
            {
                MessageBox.Show("You need input a password!", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            if (tb_W.Text.Length <= 0)
            {
                MessageBox.Show("You need input block Width! This determines the strength of the encryption.", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            if (tb_H.Text.Length <= 0)
            {
                MessageBox.Show("You need input block Height! This determines the strength of the encryption.", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            if (b.Width % Convert.ToInt32(tb_W.Text) != 0) {

                MessageBox.Show(String.Format("{0} mod {0} != 0",b.Width,tb_W), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error); return;

            }

            if (b.Height % Convert.ToInt32(tb_H.Text) != 0)
            {

                MessageBox.Show(String.Format("{0} mod {0} != 0", b.Height, tb_H), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error); return;

            }


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                sfd.Dispose();

                if (rb_E.Checked) { 
                ImageCryptor.encrpyt(tb_PW.Text,Convert.ToInt32(tb_W.Text), Convert.ToInt32(tb_H.Text),b).Save(sfd.FileName);
                }
                else
                {
                ImageCryptor.decrpyt(tb_PW.Text, Convert.ToInt32(tb_W.Text), Convert.ToInt32(tb_H.Text),b).Save(sfd.FileName);
                }


            }
           

        }

        private void number_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
