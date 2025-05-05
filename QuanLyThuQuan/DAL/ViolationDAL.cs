using MySql.Data.MySqlClient;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyThuQuan.DAL
{
    public class ViolationDAL : BaseDAL
    {
        public ViolationDAL() : base() { }

        public bool Create(ViolationDTO violation)
        {
            string sql = @"INSERT INTO violation (member_id, regulation_id, reservation_id, penalty, due_time, status) 
                           VALUES (@member_id, @regulation_id, @reservation_id, @penalty, @due_time, @status)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@member_id", violation.MemberID);
            cmd.Parameters.AddWithValue("@regulation_id", violation.RegulationID);
            cmd.Parameters.AddWithValue("@reservation_id", violation.ReservationID);
            cmd.Parameters.AddWithValue("@penalty", violation.Penalty);
            cmd.Parameters.AddWithValue("@due_time", violation.DueTime.HasValue ? (object)violation.DueTime : DBNull.Value);
            cmd.Parameters.AddWithValue("@status", violation.Status);

            try
            {
                OpenConnection();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi MySQL khi tạo violation: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi không xác định khi tạo violation: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool Update(ViolationDTO violation)
        {
            string sql = @"UPDATE violation SET member_id = @member_id, regulation_id = @regulation_id, 
                           reservation_id = @reservation_id, penalty = @penalty, due_time = @due_time, 
                           status = @status WHERE violation_id = @id";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@member_id", violation.MemberID);
            cmd.Parameters.AddWithValue("@regulation_id", violation.RegulationID);
            cmd.Parameters.AddWithValue("@reservation_id", violation.ReservationID);
            cmd.Parameters.AddWithValue("@penalty", violation.Penalty);
            cmd.Parameters.AddWithValue("@due_time", violation.DueTime.HasValue ? (object)violation.DueTime : DBNull.Value);
            cmd.Parameters.AddWithValue("@status", violation.Status);
            cmd.Parameters.AddWithValue("@id", violation.ViolationID);

            try
            {
                OpenConnection();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi MySQL khi cập nhật violation: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi không xác định khi cập nhật violation: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool UpdateStatus(int violationId, int newStatus)
        {
            string sql = "UPDATE violation SET status = @status WHERE violation_id = @id";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@status", newStatus);
            cmd.Parameters.AddWithValue("@id", violationId);

            try
            {
                OpenConnection();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi MySQL khi cập nhật status violation: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi không xác định khi cập nhật status violation: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool Delete(int violationId)
        {
            string sql = @"DELETE FROM violation WHERE violation_id = @id";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", violationId);

            try
            {
                OpenConnection();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi MySQL khi xóa violation: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi không xác định khi xóa violation: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<ViolationDTO> GetAll()
        {
            List<ViolationDTO> violations = new List<ViolationDTO>();
            string sql = @"SELECT * FROM violation ORDER BY violation_id DESC";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                OpenConnection();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        violations.Add(new ViolationDTO(
                            reader.GetInt32("violation_id"),
                            reader.GetInt32("member_id"),
                            reader.GetInt32("regulation_id"),
                            reader.IsDBNull(reader.GetOrdinal("reservation_id")) ? (int?) null : reader.GetInt32("reservation_id"),
                            reader.IsDBNull(reader.GetOrdinal("penalty")) ? string.Empty : reader.GetString("penalty"),
                            reader.GetDateTime("created_at"),
                            reader.IsDBNull(reader.GetOrdinal("due_time")) ? (DateTime?)null : reader.GetDateTime("due_time"),
                            reader.GetInt32("status")

                        ));
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi MySQL khi lấy tất cả violations: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi không xác định khi lấy tất cả violations: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return violations;
        }

        public ViolationDTO GetById(int violationId)
        {
            ViolationDTO violation = null;
            string sql = @"SELECT * FROM violation WHERE violation_id = @id";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", violationId);

            try
            {
                OpenConnection();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        violation = new ViolationDTO(
                            reader.GetInt32("violation_id"),
                            reader.GetInt32("member_id"),
                            reader.GetInt32("regulation_id"),
                            reader.IsDBNull(reader.GetOrdinal("reservation_id")) ? (int?)null : reader.GetInt32("reservation_id"),
                            reader.IsDBNull(reader.GetOrdinal("penalty")) ? string.Empty : reader.GetString("penalty"),
                            reader.GetDateTime("created_at"),
                            reader.IsDBNull(reader.GetOrdinal("due_time")) ? (DateTime?)null : reader.GetDateTime("due_time"),
                            reader.GetInt32("status")
                        );
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi MySQL khi lấy violation theo ID: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi không xác định khi lấy violation theo ID: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return violation;
        }

        public List<ViolationDTO> GetByMemberId(int memberId)
        {
            List<ViolationDTO> results = new List<ViolationDTO>();
            string sql = @"SELECT * FROM violation WHERE member_id = @member_id ORDER BY violation_id DESC";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@member_id", memberId);

            try
            {
                OpenConnection();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new ViolationDTO(
                            reader.GetInt32("violation_id"),
                            reader.GetInt32("member_id"),
                            reader.GetInt32("regulation_id"),
                            reader.IsDBNull(reader.GetOrdinal("reservation_id")) ? (int?)null : reader.GetInt32("reservation_id"),
                            reader.IsDBNull(reader.GetOrdinal("penalty")) ? string.Empty : reader.GetString("penalty"),
                            reader.GetDateTime("created_at"),
                            reader.IsDBNull(reader.GetOrdinal("due_time")) ? (DateTime?)null : reader.GetDateTime("due_time"),
                            reader.GetInt32("status")
                        ));
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi MySQL khi tìm violation theo member_id: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi không xác định khi tìm violation theo member_id: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return results;
        }

        public List<ViolationDTO> GetByMemberIdLikeAndOptionalStatus(string partialMemberId, int? status)
        {
            List<ViolationDTO> violations = new List<ViolationDTO>();
            string sql = "SELECT * FROM violation WHERE 1=1";

            if (!string.IsNullOrEmpty(partialMemberId))
            {
                sql += " AND CAST(member_id AS CHAR) LIKE @memberId";
            }

            if (status.HasValue)
            {
                sql += " AND status = @status";
            }

            sql += " ORDER BY violation_id DESC";

            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            if (!string.IsNullOrEmpty(partialMemberId))
            {
                cmd.Parameters.AddWithValue("@memberId", "%" + partialMemberId + "%");
            }

            if (status.HasValue)
            {
                cmd.Parameters.AddWithValue("@status", status.Value);
            }

            try
            {
                OpenConnection();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var violation = new ViolationDTO(
                            reader.GetInt32("violation_id"),
                            reader.GetInt32("member_id"),
                            reader.GetInt32("regulation_id"),
                            reader.IsDBNull(reader.GetOrdinal("reservation_id")) ? (int?)null : reader.GetInt32("reservation_id"),
                            reader.IsDBNull(reader.GetOrdinal("penalty")) ? string.Empty : reader.GetString("penalty"),
                            reader.GetDateTime("created_at"),
                            reader.IsDBNull(reader.GetOrdinal("due_time")) ? (DateTime?)null : reader.GetDateTime("due_time"),
                            reader.GetInt32("status")
                        );
                        violations.Add(violation);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi MySQL khi lấy violation: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi không xác định khi lấy violation: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return violations;
        }


    }
}
