using System;
using System.Data.SqlClient;

namespace NhanVien
{
    class Program
    {
        static string connectionString = "Data Source=172.16.7.236;Initial Catalog=ManagementEmployee;User ID=trungdev;Password=Abc1234567;";
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Them thong tin");
                Console.WriteLine("2. Sua thong tin");
                Console.WriteLine("3. Xoa");
                Console.WriteLine("4. Thoat");
                Console.Write("Thao tac: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ThemNhanVien();
                        break;
                    case "2":
                        CapNhatNhanVien();
                        break;
                    case "3":
                        XoaNhanVien();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Khong hop le");
                        break;
                }
            }
        }

        static void ThemNhanVien()
        {
            Console.Write("ID: ");
            string ID = Console.ReadLine();
            Console.Write("Ma nhan vien: ");
            string maNV = Console.ReadLine();
            Console.Write("Ten nhan vien: ");
            string tenNV = Console.ReadLine();
            Console.Write("Ngay sinh: ");
            string ngaySinh = Console.ReadLine();
            Console.Write("Dia chi: ");
            string diaChi = Console.ReadLine();
            Console.Write("Cap bac: ");
            string capBac = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("InsertNhanVien", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", ID);
                command.Parameters.AddWithValue("@MaNV", maNV);
                command.Parameters.AddWithValue("@TenNV", tenNV);
                command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                command.Parameters.AddWithValue("@DiaChi", diaChi);
                command.Parameters.AddWithValue("@CapBac", capBac);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Thanh cong");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Loi: " + ex.Message);
                }
            }
        }

        static void CapNhatNhanVien()
        {
            Console.Write("ID cap nhat: ");
            string ID = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateNhanVien", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", ID);
                Console.Write("Ma nhan vien: ");
                string maNV = Console.ReadLine();
                Console.Write("Ten nhan vien: ");
                string tenNV = Console.ReadLine();
                Console.Write("Ngay sinh: ");
                string ngaySinh = Console.ReadLine();
                Console.Write("Dia chi: ");
                string diaChi = Console.ReadLine();
                Console.Write("Cap bac: ");
                string capBac = Console.ReadLine();
                command.Parameters.AddWithValue("@MaNV", maNV);
                command.Parameters.AddWithValue("@TenNV", tenNV);
                command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                command.Parameters.AddWithValue("@DiaChi", diaChi);
                command.Parameters.AddWithValue("@CapBac", capBac);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Thanh cong");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Loi: " + ex.Message);
                }
            }
        }

        static void XoaNhanVien()
        {
            Console.Write("ID xoa: ");
            string ID = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteNhanVien", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", ID);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Thanh cong.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Loi: " + ex.Message);
                }
            }
        }
    }
}