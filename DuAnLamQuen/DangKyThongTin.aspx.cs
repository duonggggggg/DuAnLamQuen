using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DuAnLamQuen
{
    public partial class DangKyThongTin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //code khởi tạo dữ liệu cho các điều kiện
            if(!Page.IsPostBack)
            {
                //khởi tạo cho ddlTrinhDo
                ddlTrinhDo.Items.Add(new ListItem("Trung cấp"));
                ddlTrinhDo.Items.Add(new ListItem("Cao Đẳng"));
                //...

                //Khởi tạo lstNgheNghiep
                lstNgheNghiep.Items.Add(new ListItem("Công nhân"));
                lstNgheNghiep.Items.Add(new ListItem("Phục Vụ"));
                lstNgheNghiep.Items.Add(new ListItem("Văn Phòng"));


                //khỏi tạo chp chukListSoThich
                chkListSoThich.Items.Add(new ListItem("Mua sắm"));
                chkListSoThich.Items.Add(new ListItem("Xem phim"));
                chkListSoThich.Items.Add(new ListItem("Du lịch"));
                chkListSoThich.Items.Add(new ListItem("thể thao"));
                chkListSoThich.Items.Add(new ListItem("cướp"));
            }
        }

        protected void btGui_Click(object sender, EventArgs e)
        {
            string kq = "";
            kq += "<h2> Thông tin đăng ký của bạn</h2>";
            kq += "<ul>";
            //lấy thông tin họ tên
            kq += $"<li>Họ tên {txtHoTen.Text}</li>";
            //tương tự cho các thông tin khác
            kq += string.Format("<li> Ngày sinh: {0} </li>", txtNgaySinh.Text);
            if (rdNam.Checked)
            {
                kq += $"<li> Giới Tính {rdNam.Text} </li>";
            }  
            else
            {
                kq += $"<li> Giới Tính {rdNu.Text} </li>";
            }
            kq += $"<li> Trình độ {ddlTrinhDo.SelectedItem.Text}</li>";
            kq += $"<li> Nghề nghiệp {lstNgheNghiep.SelectedItem.Text}</li>";

            //xử lý uploads hình (nếu có)
            if(FHinh.HasFile)
            {
                //lấy về đường dẫn tuyệt đối của thư mục trên sever
                string path = Server.MapPath("~/Uploads");
                //ssao chép tập tin từ người dùng lên server
                FHinh.SaveAs(path + "/" + FHinh.FileName);
                kq += $"<li>Ảnh: <img src='Uploads/{FHinh.FileName}'></li>";
            }
            string sothich = "";
            foreach (ListItem x in chkListSoThich.Items)
            {
                if (x.Selected)
                {
                    sothich += x.Text + ";";
                }    
            }
            kq += $"<li>Sở thích: {sothich}</li>";

            kq += "<ul>";

            //b2. trả kết quả về client
            lbKetQua.Text = kq;
        }
    }
}