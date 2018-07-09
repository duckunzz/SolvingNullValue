using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Missing_Data
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            lblHuongDan.Text = "+ Chương trình thực hiện các chức năng: Thêm, Sửa, Xóa trên bộ dữ liệu"
                                + "\n+ Khi thêm hoặc sửa, chương trình sẽ kiểm tra có dữ liệu thiếu trên các ô TextBox hay không?"
                                + "\n+ Nếu có, chương trình sẽ đề xuất để ước lượng giá trị"
                                + "\n+ Đối với giá trị ngày tháng, vì mặc định bộ dữ liệu test liên tục nên sẽ không cần phải Training dữ liệu"
                                + "\n+ Ngược lại các giá trị khác sẽ cần thực hiện Trainging theo hướng dẫn"
                                + "\n+ Sau khi nhấn Training với Rough Set Theory, chúng ta có thể xem quá trình training"
                                + "\n+ Nếu không lựa chọn xem, chương trình sẽ Training và ước lượng"
                                + "\n+ Nếu xem thì một màn hình Console xuất hiện, nhấn 1 để training. Sau khi training xong, nhấn HELP để xem các lựa chọn"
                                + "\n+ Vì còn nhiều hạn chế về kiến thức và kỹ năng nên chương trình chỉ có thể dự đoán được cho 1 trường thiếu"
                                +"\n+ Chưa áp dụng được thuật toán đàn ong để phân lớp dữ liệu";
                                
            lblSVTH.Text = "+ Trần Văn Đức - 57130946"
                           + "\n+ Đặng Duy Phong - 57131234";
            lblNoDung.Text = "+ Xây dựng cây quyết định"
                            +"\n+ Lý thuyết tập thô"
                            + "\n+ Chọn thuộc tính có giá trị Pos lớn nhất để phân nhánh";
        }    
    }
}
