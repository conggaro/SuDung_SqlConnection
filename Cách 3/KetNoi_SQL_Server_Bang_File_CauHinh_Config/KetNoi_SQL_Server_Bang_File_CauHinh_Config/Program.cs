using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using System.Reflection;
using System.Data.Common;


// đọc thông tin kết nối từ file config.

// file config hay còn gọi là file cấu hình.

// bạn có thể lưu chuỗi kết nối
// ở một cấu hình
// sau đó khi chạy chương trình
// nó sẽ đọc và tạo thông tin kết nối.

// có thể sử dụng kỹ thuật Configuration
// để lưu thông tin kết nối ở các định dạng file như json, ini, xml, ...

// giả sử dùng định dạng json, hãy thêm các package như hướng dẫn tại config với json

namespace MyApp
{
    public class Program
    {
        // Lấy chuỗi kết nối từ file config định dạng json,
        // Điểm lưu: csl:ketnoi2
        public static string GetConnectString()
        {
            // cái loại này là đường dẫn lúc nó biên dịch đấy
            // lúc nó run time đấy

            // cụ thể:
            string link = Directory.GetCurrentDirectory();

            // đây là kết quả trả về của link
            // C:\Test Code C#\KetNoi_SQL_Server_Bang_File_CauHinh_Config\KetNoi_SQL_Server_Bang_File_CauHinh_Config\bin\Debug\net6.0

            // tức là file "appconfig.json"
            // phải để như này
            // thì mới đọc được file nhé
            // C:\Test Code C#\KetNoi_SQL_Server_Bang_File_CauHinh_Config\KetNoi_SQL_Server_Bang_File_CauHinh_Config\bin\Debug\net6.0\appconfig.json

            // tức là nó ở trong thư mục net6.0 đấy

            var configBuilder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())      // file config ở thư mục hiện tại
                       .AddJsonFile("appconfig.json");                    // nạp config định dạng JSON
            
            var configurationroot = configBuilder.Build();                // Tạo configurationroot

            // ghi dữ liệu vào biến kết quả
            string ket_qua = configurationroot["csdl:ketnoi2"];

            return ket_qua;
        }

        public static void Main(string[] args)
        {

            string str = GetConnectString();

            // in ra màn hình dữ liệu đọc được
            Console.WriteLine("THONG TIN KET NOI:");
            Console.WriteLine($"\"{str}\"");
            
            // tạo đối tượng kết nối
            var dt_KetNoi = new SqlConnection(str);

            // mặc định là "false"
            // cho phép thu thập thông tin về kết nối
            // thì gán cho nó giá trị "true"
            dt_KetNoi.StatisticsEnabled = true;

            // thuộc tính FireInfoMessageEventOnUserErrors
            // trong .NET là một thuộc tính của lớp SqlConnection

            // khi thiết lập thành true
            // nó cho phép xử lý các lỗi trước đây
            // được xử lý như các sự kiện InfoMessage

            // tất cả các sự kiện
            // sẽ được kích hoạt ngay lập tức
            // và được xử lý bởi trình xử lý sự kiện

            // nếu FireInfoMessageEventOnUserErrors
            // được thiết lập thành false
            // thì các sự kiện InfoMessage
            // sẽ được xử lý ở cuối thủ tục
            
            // thủ tục trong tiếng Anh là procedure

            dt_KetNoi.FireInfoMessageEventOnUserErrors = true;

            // mở kết nối
            dt_KetNoi.Open();

            // tạo đối tượng truy vấn
            DbCommand dt_TruyVan = dt_KetNoi.CreateCommand();

            // viết câu lệnh truy cấn SQL
            dt_TruyVan.CommandText = "select * from SanPham";

            // tạo đối tượng đọc dữ liệu
            var dt_doc = dt_TruyVan.ExecuteReader();

            // in ra màn hình kết quả đọc được
            Console.WriteLine("\n-------------------- DANH SACH SAN PHAM --------------------");

            Console.WriteLine($"{"TEN SAN PHAM",-25} {"GIA",-18} {"SO LUONG",-18}");

            while (dt_doc.Read())
            {
                Console.WriteLine($"{dt_doc["ten_SanPham"],-25} {dt_doc["gia_SanPham"],-18} {dt_doc["so_luong"],-18}");
            }
            
            // đóng kết nối
            dt_KetNoi.Close();
        }
    }
}