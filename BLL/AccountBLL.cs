using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class AccountBLL
    {
        public string Account(string user, string pass)
        {
            AcountAccess Acc = new AcountAccess();
            string kq = Acc.checklogin(user, pass);
            return kq;
        }

        public int DoiMatKhau(string user, string pass)
        {
            AcountAccess Acc = new AcountAccess();
            int kq = Acc.update_matkhau_moi(user, pass);
            return kq;
        }
    }
}
