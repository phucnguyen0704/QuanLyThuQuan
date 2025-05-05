using MySql.Data.MySqlClient;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyThuQuan.DAL
{
    class MemberDAL : BaseDAL
    {
        public MemberDAL() : base() { }

        public bool create(MemberDTO member)
        {
            try
            {
                string sql = @"
                    INSERT INTO member 
                        (member_id,full_name, birthday, phone_number, email, department, major, class, password, role, status, created_at) 
                    VALUES 
                        (@member_id, @full_name, @birthday, @phone_number, @email, @department, @major, @class, @password, @role, @status, @created_at);
                ";
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                command.Parameters.AddWithValue("@member_id", member.MemberId);
                command.Parameters.AddWithValue("@full_name", member.FullName);
                command.Parameters.AddWithValue("@birthday", member.Birthday);
                command.Parameters.AddWithValue("@phone_number", member.PhoneNumber);
                command.Parameters.AddWithValue("@email", member.Email);
                command.Parameters.AddWithValue("@department", member.Department);
                command.Parameters.AddWithValue("@major", member.Major);
                command.Parameters.AddWithValue("@class", member.Class);
                command.Parameters.AddWithValue("@password", member.Password);
                command.Parameters.AddWithValue("@role", member.Role);
                command.Parameters.AddWithValue("@status", member.Status);
                command.Parameters.AddWithValue("@created_at", member.CreatedAt);

                OpenConnection();
                command.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi thêm thành viên: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khác: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool update(MemberDTO member)
        {
            try
            {
                string sql = @"
                    UPDATE member 
                    SET 
                        full_name = @full_name, birthday = @birthday, phone_number = @phone_number, 
                        email = @email, department = @department, major = @major, class = @class,
                        password = @password, role = @role, status = @status, created_at = @created_at
                    WHERE member_id = @member_id AND status <> 2;
                ";
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                command.Parameters.AddWithValue("@member_id", member.MemberId);
                command.Parameters.AddWithValue("@full_name", member.FullName);
                command.Parameters.AddWithValue("@birthday", member.Birthday);
                command.Parameters.AddWithValue("@phone_number", member.PhoneNumber ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@email", member.Email);
                command.Parameters.AddWithValue("@department", member.Department);
                command.Parameters.AddWithValue("@major", member.Major);
                command.Parameters.AddWithValue("@class", member.Class);
                command.Parameters.AddWithValue("@password", member.Password);
                command.Parameters.AddWithValue("@role", member.Role);
                command.Parameters.AddWithValue("@status", member.Status);
                command.Parameters.AddWithValue("@created_at", member.CreatedAt);

                OpenConnection();
                command.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi cập nhật thành viên: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khác: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool delete(int memberId)
        {
            try
            {
                string sql = @"
                    UPDATE member 
                    SET status = 2
                    WHERE member_id = @member_id AND status <> 2;
                ";
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                command.Parameters.AddWithValue("@member_id", memberId);

                OpenConnection();
                command.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi xóa thành viên: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khác: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<MemberDTO> getAll()
        {
            List<MemberDTO> members = new List<MemberDTO>();
            try
            {
                string sql = @"
                    SELECT * FROM member WHERE status <> 2;
                ";
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                OpenConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MemberDTO member = new MemberDTO
                    {
                        MemberId = reader.GetInt32("member_id"),
                        FullName = reader.GetString("full_name"),
                        Birthday = reader.GetDateTime("birthday"),
                        PhoneNumber = reader.IsDBNull(reader.GetOrdinal("phone_number")) ? null : reader.GetString("phone_number"),
                        Email = reader.GetString("email"),
                        Department = reader.GetString("department"),
                        Major = reader.GetString("major"),
                        Class = reader.GetString("class"),
                        Password = reader.GetString("password"),
                        Role = reader.GetString("role"),
                        Status = reader.GetInt32("status"),
                        CreatedAt = reader.GetDateTime("created_at")
                    };
                    members.Add(member);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi lấy danh sách thành viên: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khác: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return members;
        }

        public MemberDTO getByID(int memberId)
        {
            MemberDTO member = null;
            try
            {
                string sql = @"
                    SELECT * FROM member 
                    WHERE member_id = @member_id AND status <> 2;
                ";
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                command.Parameters.AddWithValue("@member_id", memberId);
                OpenConnection();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    member = new MemberDTO
                    {
                        MemberId = reader.GetInt32("member_id"),
                        FullName = reader.GetString("full_name"),
                        Birthday = reader.GetDateTime("birthday"),
                        PhoneNumber = reader.IsDBNull(reader.GetOrdinal("phone_number")) ? null : reader.GetString("phone_number"),
                        Email = reader.GetString("email"),
                        Department = reader.GetString("department"),
                        Major = reader.GetString("major"),
                        Class = reader.GetString("class"),
                        Password = reader.GetString("password"),
                        Role = reader.GetString("role"),
                        Status = reader.GetInt32("status"),
                        CreatedAt = reader.GetDateTime("created_at")
                    };
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi lấy thành viên theo ID: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khác: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return member;
        }

        public MemberDTO getByPhone(string phone)
        {
            MemberDTO member = null;
            try
            {
                string sql = @"
                    SELECT * FROM member 
                    WHERE phone_number = @phone_number AND status <> 2;
                ";
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                command.Parameters.AddWithValue("@phone_number", phone);
                OpenConnection();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    member = new MemberDTO
                    {
                        MemberId = reader.GetInt32("member_id"),
                        FullName = reader.GetString("full_name"),
                        Birthday = reader.GetDateTime("birthday"),
                        PhoneNumber = reader.IsDBNull(reader.GetOrdinal("phone_number")) ? null : reader.GetString("phone_number"),
                        Email = reader.GetString("email"),
                        Department = reader.GetString("department"),
                        Major = reader.GetString("major"),
                        Class = reader.GetString("class"),
                        Password = reader.GetString("password"),
                        Role = reader.GetString("role"),
                        Status = reader.GetInt32("status"),
                        CreatedAt = reader.GetDateTime("created_at")
                    };
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi lấy thành viên theo Phone: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khác: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return member;
        }

        public MemberDTO getByEmail(string email)
        {
            MemberDTO member = null;
            try
            {
                string sql = @"
                    SELECT * FROM member 
                    WHERE email = @email AND status <> 2;
                ";
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                command.Parameters.AddWithValue("@email", email);
                OpenConnection();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    member = new MemberDTO
                    {
                        MemberId = reader.GetInt32("member_id"),
                        FullName = reader.GetString("full_name"),
                        Birthday = reader.GetDateTime("birthday"),
                        PhoneNumber = reader.IsDBNull(reader.GetOrdinal("phone_number")) ? null : reader.GetString("phone_number"),
                        Email = reader.GetString("email"),
                        Department = reader.GetString("department"),
                        Major = reader.GetString("major"),
                        Class = reader.GetString("class"),
                        Password = reader.GetString("password"),
                        Role = reader.GetString("role"),
                        Status = reader.GetInt32("status"),
                        CreatedAt = reader.GetDateTime("created_at")
                    };
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi lấy thành viên theo Email: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khác: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return member;
        }

        // Thêm phương thức lấy lịch sử mượn thiết bị
        public DataTable getReservationHistory(int memberId)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"
                    SELECT 
                        r.reservation_id, 
                        r.reservation_type,
                        r.reservation_time, 
                        r.due_time, 
                        r.return_time,
                        s.name AS seat_name,
                        r.status
                    FROM 
                        reservation r
                    LEFT JOIN 
                        seat s ON r.seat_id = s.seat_id
                    WHERE 
                        r.member_id = @member_id AND r.status <> 4
                    ORDER BY 
                        r.reservation_time DESC;
                ";
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                command.Parameters.AddWithValue("@member_id", memberId);

                OpenConnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi lấy lịch sử mượn: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khác: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        // Thêm phương thức lấy chi tiết mượn thiết bị
        public DataTable getReservationDetails(int reservationId)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"
                    SELECT 
                        rd.reservation_detail_id,
                        d.device_id,
                        d.name AS device_name,
                        d.image,
                        rd.status
                    FROM 
                        reservation_detail rd
                    JOIN 
                        device d ON rd.device_id = d.device_id
                    WHERE 
                        rd.reservation_id = @reservation_id;
                ";
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                command.Parameters.AddWithValue("@reservation_id", reservationId);

                OpenConnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi lấy chi tiết mượn: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khác: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        // Thêm phương thức lấy lịch sử vi phạm
        public DataTable getViolationHistory(int memberId)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"
                    SELECT 
                        v.violation_id,
                        v.member_id,
                        r.regulation_id,
                        r.name AS regulation_name,
                        r.description,
                        v.reservation_id,
                        v.penalty,
                        v.created_at,
                        v.due_time,
                        v.status
                    FROM 
                        violation v
                    JOIN 
                        regulation r ON v.regulation_id = r.regulation_id
                    WHERE 
                        v.member_id = @member_id AND v.status <> 2
                    ORDER BY 
                        v.created_at DESC;
                ";
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                command.Parameters.AddWithValue("@member_id", memberId);

                OpenConnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi lấy lịch sử vi phạm: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khác: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        // Thêm phương thức lấy lịch sử check-in
        public DataTable getCheckInHistory(int memberId)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"
                    SELECT 
                        log_id,
                        checkin_time,
                        status,
                        created_at
                    FROM 
                        log
                    WHERE 
                        member_id = @member_id AND status <> 2
                    ORDER BY 
                        checkin_time DESC;
                ";
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                command.Parameters.AddWithValue("@member_id", memberId);

                OpenConnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi lấy lịch sử check-in: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khác: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }
    }
}
