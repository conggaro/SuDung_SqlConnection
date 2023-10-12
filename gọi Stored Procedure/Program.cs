using System;
using System.Data;
using System.Data.SqlClient;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // tạo biến chứa chuỗi kết nối
                string connection_str = @"
                    Server = localhost;
                    Database = StudentDB;
                    User ID = sa;
                    Password = 123456
                ";


                // tạo đối tượng có kiểu "SqlConnection"
                SqlConnection dt_KetNoi = new SqlConnection(connection_str);


                // tạo đối tượng có kiểu "SqlCommand"
                // để gọi stored procedure trong SQL Server
                SqlCommand dt_SqlCommand = new SqlCommand("spGetStudents", dt_KetNoi);


                // chỉ định loại lệnh là "StoredProcedure"
                dt_SqlCommand.CommandType = CommandType.StoredProcedure;


                /*
                    mặc định SqlCommand sẽ coi
                    nội dung trong thuộc tính CommandText
                    là câu lệnh SQL

                    vì nó đã thiết lập CommandType
                    bằng CommandType.Text

                    nếu muốn gọi đến Procedure
                    thì thiết lập nó
                    bằng CommandType.StoredProcedure
                */


                // mở kết nối
                dt_KetNoi.Open();


                // tạo đối tượng có kiểu "SqlDataReader"
                // tôi gọi nó là "đối tượng đọc"
                SqlDataReader dt_doc = dt_SqlCommand.ExecuteReader();


                // sử dụng vòng lặp while
                // để đọc dữ liệu trả về
                while (dt_doc.Read())
                {
                    // in dữ liệu ra màn hình
                    Console.WriteLine(
                        $"{dt_doc["Id"], -10}"
                        + $"{dt_doc["Name"], -15}"
                        + $"{dt_doc["Email"], -35}"
                        + $"{dt_doc["Mobile"], -15}"
                    );
                }


                // đóng chuỗi kết nối
                dt_KetNoi.Close();
            }
            catch (
                // tạo đối tượng ex
                // có kiểu dữ liệu "Exception"
                Exception ex
            )
            {
                // "Exception Occurred" là xảy ra ngoại lệ
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
        }
    }
}