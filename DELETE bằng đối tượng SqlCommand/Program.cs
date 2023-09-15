using System;
using System.Data.Common;
using System.Data.SqlClient;

// sử dụng SqlCommand trong C#
// để truy vấn và cập nhật
// cơ sở dữ liệu SQL Server

// thực hiện với các phương thức
// 1. ExecuteNonQuery()
// 2. ExecuteScalar()
// 3. ExecuteReader()

// lớp SqlCommand được triển khai từ DbCommand
// cho phép tạo ra đối tượng
// có thể thi hành các lệnh SQL
// để tương tác với SQL Server

// nó có thể:
// 1. SELECT
// 2. INSERT
// 3. UPDATE
// 4. DELETE
// 5. CREATE TABLE
// 6. cho phép thực thi các hàm của Database SQL Server
// 7. cho phép thực thi các stored procedure

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
                Các cách thực thi SqlCommand và lấy kết quả truy vấn
                
                1. ExecuteNonQuery()
                - Nó thực thi câu lệnh truy vấn
                - Không cần trả về dữ liệu gì
                - Phù hợp thực hiện các truy vấn như Insert, Update, Delete

                2. ExecuteReader()
                - Nó thực thi câu lệnh truy vấn
                - Trả về đối tượng giao diện IDataReader như SqlDataReader
                - Từ đó đọc được dữ liệu trả về

                3. ExecuteScalar()
                - Nó thực thi và trả về 1 giá trị duy nhất
                - Ở hàng đầu tiên, cột đầu tiên

                Chú ý:
                - Nếu gọi procedure thì có kết quả trả về
                => Suy ra, dùng ExecuteReader() cho procedure thì hợp lý
            */



            // viết code chuỗi kết nối
            string chuoi_ket_noi = @"
                Server = localhost;
                Database = Database_Demo;
                User ID = sa;
                Password = 123456
            ";

            // tạo đối tượng kết nối
            var dt_KetNoi = new SqlConnection(chuoi_ket_noi);

            // mở chuỗi kết nối
            dt_KetNoi.Open();

            // tạo đối tượng truy vấn
            SqlCommand dt_TruyVan = new SqlCommand();

            // gán đối tượng kết nối
            // vào thuộc tính Connection
            dt_TruyVan.Connection = dt_KetNoi;

            // các tham số
            // được lưu trong đối tượng có kiểu SqlParameter
            dt_TruyVan.Parameters.AddWithValue("@so_luong", 2);

            // viết code câu lệnh truy vấn
            string cau_lenh_TruyVan = @"
                delete from Table_Demo
                where Table_ID >= @so_luong
            ";

            // ghi câu truy vấn vào CommandText
            dt_TruyVan.CommandText = cau_lenh_TruyVan;

            // thực thi câu lệnh DELETE
            var rows_affected = dt_TruyVan.ExecuteNonQuery();

            // vì nó trả về số dòng
            // nên tôi sẽ in ra màn hình
            // số dòng ảnh hưởng
            Console.WriteLine($"So dong anh huong (DELETE): {rows_affected}");

            // đóng chuỗi kết nối
            dt_KetNoi.Close();
        }
    }
}