using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyThuQuan.DTO;

namespace QuanLyThuQuan.DAL
{
    public class MemberDAL
    {
       private string connectionString = "server=localhost;port=3306;user=root;password=;database=librarydb;SslMode=none;";

        // Thêm thành viên vào cơ sở dữ liệu
        public void AddMember(MemberDTO member)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Member (FullName, Birthday, PhoneNumber, Email, Department, Major, Class, Password, Role, Status, CreatedAt) " +
                               "VALUES (@FullName, @Birthday, @PhoneNumber, @Email, @Department, @Major, @Class, @Password, @Role, @Status, @CreatedAt)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", member.FullName);
                cmd.Parameters.AddWithValue("@Birthday", member.Birthday);
                cmd.Parameters.AddWithValue("@PhoneNumber", member.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", member.Email);
                cmd.Parameters.AddWithValue("@Department", member.Department);
                cmd.Parameters.AddWithValue("@Major", member.Major);
                cmd.Parameters.AddWithValue("@Class", member.Class);
                cmd.Parameters.AddWithValue("@Password", member.Password);
                cmd.Parameters.AddWithValue("@Role", member.Role);
                cmd.Parameters.AddWithValue("@Status", member.Status);
                cmd.Parameters.AddWithValue("@CreatedAt", member.CreatedAt);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Cập nhật thông tin thành viên
        public void UpdateMember(MemberDTO member)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Member SET FullName = @FullName, Birthday = @Birthday, PhoneNumber = @PhoneNumber, Email = @Email, " +
                               "Department = @Department, Major = @Major, Class = @Class, Password = @Password, Role = @Role, Status = @Status, " +
                               "CreatedAt = @CreatedAt WHERE MemberId = @MemberId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", member.FullName);
                cmd.Parameters.AddWithValue("@Birthday", member.Birthday);
                cmd.Parameters.AddWithValue("@PhoneNumber", member.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", member.Email);
                cmd.Parameters.AddWithValue("@Department", member.Department);
                cmd.Parameters.AddWithValue("@Major", member.Major);
                cmd.Parameters.AddWithValue("@Class", member.Class);
                cmd.Parameters.AddWithValue("@Password", member.Password);
                cmd.Parameters.AddWithValue("@Role", member.Role);
                cmd.Parameters.AddWithValue("@Status", member.Status);
                cmd.Parameters.AddWithValue("@CreatedAt", member.CreatedAt);
                cmd.Parameters.AddWithValue("@MemberId", member.MemberId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Lấy danh sách tất cả thành viên
        public List<MemberDTO> GetAllMembers()
        {
            List<MemberDTO> members = new List<MemberDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Member";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MemberDTO member = new MemberDTO
                    {
                        MemberId = (int)reader["MemberId"],
                        FullName = reader["FullName"].ToString(),
                        Birthday = (DateTime)reader["Birthday"],
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        Department = reader["Department"].ToString(),
                        Major = reader["Major"].ToString(),
                        Class = reader["Class"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = reader["Role"].ToString(),
                        Status = (int)reader["Status"],
                        CreatedAt = (DateTime)reader["CreatedAt"]
                    };

                    members.Add(member);
                }
            }

            return members;
        }

        // Lấy thông tin thành viên theo ID
        public MemberDTO GetMemberById(int memberId)
        {
            MemberDTO member = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Member WHERE MemberId = @MemberId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MemberId", memberId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    member = new MemberDTO
                    {
                        MemberId = (int)reader["MemberId"],
                        FullName = reader["FullName"].ToString(),
                        Birthday = (DateTime)reader["Birthday"],
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        Department = reader["Department"].ToString(),
                        Major = reader["Major"].ToString(),
                        Class = reader["Class"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = reader["Role"].ToString(),
                        Status = (int)reader["Status"],
                        CreatedAt = (DateTime)reader["CreatedAt"]
                    };
                }
            }

            return member;
        }

        // Xóa thành viên
        public void DeleteMember(int memberId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Member WHERE MemberId = @MemberId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MemberId", memberId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
