using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

// cách 1:
// sử dụng DbConnection
// và SqlConnection

// cách này thì sử dụng chuỗi string
// để kết nối dữ liệu với Database

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // viết chuỗi string
            // Data Source là tên máy, hoặc là địa chỉ IP, hoặc là localhost.
            // Initial Catalog là tên cơ sở dữ liệu trong SQL Server
            // User ID là tên tài khoản
            // Password là mật khẩu
            string str = "Data Source = localhost; Initial Catalog = QLNV; User ID = sa; Password = 123456";

            // tạo đối tượng kết nối
            DbConnection dt_KetNoi = new SqlConnection(str);

            // mở kết nối
            dt_KetNoi.Open();

            // tạo đối tượng để truy vấn
            // Command dịch ra tiếng Việt là lệnh
            DbCommand dt_TruyVan = dt_KetNoi.CreateCommand();

            // viết câu lệnh truy cấn SQL
            dt_TruyVan.CommandText = "select * from TaiKhoan";

            // tạo đối tượng đọc dữ liệu
            var dt_doc = dt_TruyVan.ExecuteReader();

            // in ra màn hình kết quả đọc được
            Console.WriteLine("---------- DANH SACH TAI KHOAN ----------");

            Console.WriteLine($"{"STT", -6} {"Ten dang nhap", -16} {"Mat khau", -10}");

            while (dt_doc.Read())
            {
                Console.WriteLine($"{dt_doc["stt"], -6} {dt_doc["ten_dang_nhap"], -16} {dt_doc["mat_khau"], -10}");
            }

            // đóng kết nối
            dt_KetNoi.Close();
        }
    }
}