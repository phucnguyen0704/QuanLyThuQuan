using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuQuan.DAL
{
    public class LogDAL : BaseDAL
    {
        public LogDAL() : base() { }

        public bool create(LogDTO log)
        {
            try
            {
                string sql = @"INSERT INTO log (member_id, checkin_time) VALUES (@memberId, @checkinTime)";
                OpenConnection();
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                command.Parameters.AddWithValue("@memberId", log.memberId);
                command.Parameters.AddWithValue("@checkinTime", log.checkinTime);
                command.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi MySQL: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khác: " + ex.Message);
                return false;
            }
            finally { 
                CloseConnection();
            }
            
        }

        public bool update(LogDTO log) {
            try
            {
                string sql = @"UPDATE log
                            SET member_id = @memberId, checkin_time = @checkinTime
                            WHERE log_id = @logId";
                OpenConnection();
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                command.Parameters.AddWithValue("@memberId", log.memberId);
                command.Parameters.AddWithValue("@checkinTime", log.checkinTime);
                command.Parameters.AddWithValue("@logId", log.logId);
                command.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi MySQL: " + ex.Message);
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

        public bool delete(int logId) {
            try
            {
                try
                {
                    string sql = @"
                            UPDATE log
                            SET status = 0
                            WHERE log_id = @logId";
                    OpenConnection();
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@logId", logId);
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Loi: " + ex.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi khac: " + ex.Message);
                return false;

            }
            finally
            {
                CloseConnection();
            }
        }

        public List<LogDTO> getAll() { 
            List<LogDTO> logs =  new List<LogDTO>();
            try
            {
                string sql = @"SELECT * FROM log where status = 1";
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                OpenConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    LogDTO log = new LogDTO(
                        reader.GetInt32("log_id"),
                        reader.GetString("member_id"),
                        reader.GetDateTime("checkin_time"),
                        reader.GetInt32("status"),
                        reader.GetDateTime("created_at")
                    );
                    logs.Add(log);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return logs;
        }

        public LogDTO getById(int id) {
            LogDTO log = null;
            try
            {
                try
                {
                    string sql = @"Select * from log where log_id = @id";
                    OpenConnection();
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        log = new LogDTO(
                            reader.GetInt32("log_id"),
                            reader.GetString("member_id"),
                            reader.GetDateTime("checkin_time"),
                            reader.GetInt32("status"),
                            reader.GetDateTime("created_at")
                            );
                    }
                    return log;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Loi: " + ex.Message);
                    return null;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi khac: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }


    }
}
