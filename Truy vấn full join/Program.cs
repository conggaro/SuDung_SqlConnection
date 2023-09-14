using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string str = "Data Source = localhost; Initial Catalog = Database_Demo; User ID = sa; Password = 123456";

            // tạo đối tượng kết nối
            DbConnection dt_KetNoi = new SqlConnection(str);

            // mở kết nối
            dt_KetNoi.Open();

            // tạo đối tượng truy vấn
            DbCommand dt_TruyVan = dt_KetNoi.CreateCommand();

            // viết câu lệnh truy vấn
            // đây là truy vấn full join
            dt_TruyVan.CommandText = @"
                select		TableA.CODE as CODE_A,
			                TableA.FULL_NAME,
			                TableB.CODE as CODE_B,
			                TableB.ORGANIZATION_NAME

                from		EMPLOYEE as TableA
                full join	ORGANIZATION as TableB
                on			TableA.ORGANIZATION_CODE = TableB.CODE;
            ";

            // tạo đối tượng đọc dữ liệu
            var dt_doc = dt_TruyVan.ExecuteReader();

            // in ra màn hình kết quả đọc được
            Console.WriteLine("Ket qua truy van:");

            Console.WriteLine($"{"Ma nhan vien", -16} {"Ho va ten", -16} {"Ma phong ban",-16} {"Ten phong ban", -16}");

            while (dt_doc.Read())
            {
                Console.WriteLine($"{dt_doc["CODE_A"],-16} {dt_doc["FULL_NAME"],-16} {dt_doc["CODE_B"],-16} {dt_doc["ORGANIZATION_NAME"], -16}");
            }

            // đóng kết nối
            dt_KetNoi.Close();
        }
    }
}