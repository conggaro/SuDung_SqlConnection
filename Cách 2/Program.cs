using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

// cách 2:
// sử dụng SqlConnection
// và SqlConnectionStringBuilder

// SqlConnectionStringBuilder là trình tạo chuỗi kết nối

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // tạo đối tượng
            // để chuẩn bị cho công việc
            // chuyển đối tượng thành chuỗi string
            var dt_ChuanBi = new SqlConnectionStringBuilder();
            dt_ChuanBi["Server"] = "localhost";
            dt_ChuanBi["Database"] = "Web_BanHang_Database";
            dt_ChuanBi["User Id"] = "sa";
            dt_ChuanBi["Password"] = "123456";

            // chuyển đối tượng thành chuỗi string
            // chuỗi string này sẽ được
            // đem đi kết nối
            string str = dt_ChuanBi.ToString();

            // tạo đối tượng kết nối
            var dt_KetNoi = new SqlConnection(str);

            // mở kết nối
            dt_KetNoi.Open();

            // tạo đối tượng truy vấn
            DbCommand dt_TruyVan = dt_KetNoi.CreateCommand();

            // viết câu lệnh truy cấn SQL
            dt_TruyVan.CommandText = "select * from SanPham";

            // tạo đối tượng đọc dữ liệu
            var dt_doc = dt_TruyVan.ExecuteReader();

            // in ra màn hình kết quả đọc được
            Console.WriteLine("-------------------- DANH SACH SAN PHAM --------------------");

            Console.WriteLine($"{"Ma san pham",-16} {"Ten san pham",-25} {"Ten thuong hieu",-18}");

            while (dt_doc.Read())
            {
                Console.WriteLine($"{dt_doc["ma_SanPham"],-16} {dt_doc["ten_SanPham"],-25} {dt_doc["ten_ThuongHieu"],-18}");
            }

            dt_KetNoi.Close();
        }
    }
}