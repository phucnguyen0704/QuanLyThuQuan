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
            string insertViolationSql = @"INSERT INTO violation (member_id, regulation_id, reservation_id, penalty, due_time, status) 
                         VALUES (@member_id, @regulation_id, @reservation_id, @penalty, @due_time, @status)";

            string updateMemberStatusSql = @"UPDATE member SET status = 3 WHERE member_id = @member_id";

            MySqlConnection conn = GetConnection();
            MySqlTransaction transaction = null;

            try
            {
                OpenConnection();
                transaction = conn.BeginTransaction();

                MySqlCommand insertCmd = new MySqlCommand(insertViolationSql, conn, transaction);
                insertCmd.Parameters.AddWithValue("@member_id", violation.MemberID);
                insertCmd.Parameters.AddWithValue("@regulation_id", violation.RegulationID);
                insertCmd.Parameters.AddWithValue("@reservation_id", violation.ReservationID);
                insertCmd.Parameters.AddWithValue("@penalty", violation.Penalty);
                insertCmd.Parameters.AddWithValue("@due_time", violation.DueTime.HasValue ? (object)violation.DueTime : DBNull.Value);
                insertCmd.Parameters.AddWithValue("@status", violation.Status);

                insertCmd.ExecuteNonQuery();

                if (violation.Status == 2 && violation.DueTime.HasValue)
                {
                    MySqlCommand updateCmd = new MySqlCommand(updateMemberStatusSql, conn, transaction);
                    updateCmd.Parameters.AddWithValue("@member_id", violation.MemberID);
                    updateCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tạo violation và cập nhật member: " + ex.Message);
                try { transaction?.Rollback(); } catch { }
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool Update(ViolationDTO violation)
        {
            string updateViolationSql = @"UPDATE violation 
                                  SET member_id = @member_id, regulation_id = @regulation_id, 
                                      reservation_id = @reservation_id, penalty = @penalty, 
                                      due_time = @due_time, status = @status 
                                  WHERE violation_id = @id";

            string updateMemberStatusSql = @"UPDATE member SET status = 3 WHERE member_id = @member_id";

            MySqlConnection conn = GetConnection();
            MySqlTransaction transaction = null;

            try
            {
                OpenConnection();
                transaction = conn.BeginTransaction();

                MySqlCommand updateViolationCmd = new MySqlCommand(updateViolationSql, conn, transaction);
                updateViolationCmd.Parameters.AddWithValue("@member_id", violation.MemberID);
                updateViolationCmd.Parameters.AddWithValue("@regulation_id", violation.RegulationID);
                updateViolationCmd.Parameters.AddWithValue("@reservation_id", violation.ReservationID);
                updateViolationCmd.Parameters.AddWithValue("@penalty", violation.Penalty);
                updateViolationCmd.Parameters.AddWithValue("@due_time", violation.DueTime.HasValue ? (object)violation.DueTime : DBNull.Value);
                updateViolationCmd.Parameters.AddWithValue("@status", violation.Status);
                updateViolationCmd.Parameters.AddWithValue("@id", violation.ViolationID);

                updateViolationCmd.ExecuteNonQuery();

                if (violation.Status == 2 && violation.DueTime.HasValue)
                {
                    MySqlCommand updateMemberCmd = new MySqlCommand(updateMemberStatusSql, conn, transaction);
                    updateMemberCmd.Parameters.AddWithValue("@member_id", violation.MemberID);
                    updateMemberCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật violation và member: " + ex.Message);
                try { transaction?.Rollback(); } catch { }
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
                            reader.GetUInt32("member_id"),
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
                            reader.GetUInt32("member_id"),
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

        public List<ViolationDTO> GetByMemberId(uint memberId)
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
                            reader.GetUInt32("member_id"),
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
                            reader.GetUInt32("member_id"),
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
