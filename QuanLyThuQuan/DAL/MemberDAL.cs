using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using QuanLyThuQuan.DTO;

namespace QuanLyThuQuan.DAL
{
    public class MemberDAL
    {
        string connectionString = "server=localhost;port=3306;user=root;password=;database=librarydb;SslMode=none;";
        public List<MemberDTO> LayDanhSachThanhVien()
        {
            List<MemberDTO> danhSach = new List<MemberDTO>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, HoVaTen, Email, NgayDangKy FROM thanhvien";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MemberDTO member = new MemberDTO
                    {
                        MemberId = Convert.ToInt32(reader["Id"]),
                        FullName = reader["HoVaTen"].ToString(),
                        Email = reader["Email"].ToString(),
                        Birthday = Convert.ToDateTime(reader["NgayDangKy"])
                    };
                    danhSach.Add(member);
                }
            }

            return danhSach;
        }

        public bool ThemThanhVien(MemberDTO member)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO thanhvien (Id, HoVaTen, Email, NgayDangKy) VALUES (@MemberId, @FullName, @Email, @Birthday)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MemberId", member.MemberId);
                cmd.Parameters.AddWithValue("@FullName", member.FullName);
                cmd.Parameters.AddWithValue("@Email", member.Email);
                cmd.Parameters.AddWithValue("@Birthday", member.Birthday);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool XoaThanhVien(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM thanhvien WHERE Id = @MemberId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MemberId", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool CapNhatThanhVien(MemberDTO member)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE thanhvien SET HoVaTen = @FullName, Email = @Email, NgayDangKy = @Birthday WHERE Id = @MemberId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", member.FullName);
                cmd.Parameters.AddWithValue("@Email", member.Email);
                cmd.Parameters.AddWithValue("@Birthday", member.Birthday);
                cmd.Parameters.AddWithValue("@MemberId", member.MemberId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
