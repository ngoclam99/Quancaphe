using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using GUI;

namespace GUI
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtDangNhap.Text;
            string pass = txtMatkhau.Text;
            if (user == "" && pass == "")
            {
                lbTK.Visible = true;
                lbMK.Visible = true;
                lbTB.Visible = false;
                return;
            }
           
            if (user == "")
            {
                lbTK.Visible = true;
                lbTB.Visible = false;
                return;
            }
            else
            {
                lbTK.Visible = false;
            }
            if (pass == "")
            {
                lbMK.Visible = true;
                lbTB.Visible = false;
                return;
            }
            else
            {
                lbMK.Visible = false;
            }
            
                 account = new AccountBLL();
            string kiemtra = account.Account(user, pass);
            if(kiemtra == null)
            {
                lbTB.Visible = true;
            }
            else
            {
                string[] arr = kiemtra.Split('_');
                Properties.Settings.Default.username = arr[0];
                Properties.Settings.Default.manv = arr[1];
                Properties.Settings.Default.bophan = arr[2];
                Properties.Settings.Default.nameuser = arr[3];
                DialogResult = DialogResult.OK;
                lbTB.Visible = false;
            }
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
