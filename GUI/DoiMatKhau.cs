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

namespace GUI
{
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txtDangNhap.Text = Properties.Settings.Default.username;
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            string mk_cu = txtMatkhaucu.Text;
            string mk_moi = txtMatkhaumoi.Text;
            string nl_mk = txtNhaplaimatkhau.Text;
            string tendn = Properties.Settings.Default.username;
            AccountBLL acc = new AccountBLL();
            string kiemtra_mk = acc.Account(tendn, mk_cu);
            if (kiemtra_mk == null)
            {
                lbTB.Text = "Mật khẩu cũ không chính xác!";
                return;
            }
            if (mk_moi != nl_mk)
            {
                lbTB.Text = "Mật khẩu mới phải trùng nhau!";
                return;
            }

            int ketqua = acc.DoiMatKhau(tendn, mk_moi);
            if(ketqua > 0)
            {
                
                lbTB.Text = "Đổi mật khẩu thành công!";
            }
            else
            {
                lbTB.Text = "Đổi mật khẩu thất bại!";
            }
            txtMatkhaucu.Text = "";
            txtMatkhaumoi.Text = "";
            txtNhaplaimatkhau.Text = "";
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
          
        }
    }
}
