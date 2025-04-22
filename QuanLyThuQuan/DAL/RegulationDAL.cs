using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using QuanLyThuQuan.DTO;

namespace QuanLyThuQuan.DAL
{
    public class RegulationDAL : BaseDAL
    {
        public RegulationDAL() : base() { }

        public bool Create(RegulationDTO regulation)
        {
            string sql = @"INSERT INTO regulation (name, type, description) VALUES (@name, @type, @description)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@name", regulation.Name);
            cmd.Parameters.AddWithValue("@type", regulation.Type);
            cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(regulation.Description) ? (object)DBNull.Value : regulation.Description);

            try
            {
                OpenConnection();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("❌ Lỗi MySQL khi tạo quy định: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi không xác định khi tạo quy định: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool Update(RegulationDTO regulation)
        {
            string sql = @"UPDATE regulation SET name = @name, type = @type, description = @description WHERE regulation_id = @id";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@name", regulation.Name);
            cmd.Parameters.AddWithValue("@type", regulation.Type);
            cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(regulation.Description) ? (object)DBNull.Value : regulation.Description);
            cmd.Parameters.AddWithValue("@id", regulation.RegulationID);

            try
            {
                OpenConnection();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("❌ Lỗi MySQL khi cập nhật quy định: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi không xác định khi cập nhật quy định: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool Delete(int regulationId)
        {
            string sql = @"DELETE FROM regulation WHERE regulation_id = @id";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", regulationId);

            try
            {
                OpenConnection();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("❌ Lỗi MySQL khi xóa quy định: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi không xác định khi xóa quy định: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<RegulationDTO> GetAll()
        {
            List<RegulationDTO> regulations = new List<RegulationDTO>();
            string sql = @"SELECT * FROM regulation";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                OpenConnection();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        regulations.Add(new RegulationDTO(
                            reader.GetInt32("regulation_id"),
                            reader.GetString("name"),
                            reader.GetString("type"),
                            reader.IsDBNull(reader.GetOrdinal("description")) ? string.Empty : reader.GetString("description"),
                            reader.GetDateTime("created_at")
                        ));
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("❌ Lỗi MySQL khi lấy tất cả quy định: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi không xác định khi lấy tất cả quy định: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return regulations;
        }

        public RegulationDTO GetById(int regulationId)
        {
            RegulationDTO regulation = null;
            string sql = @"SELECT * FROM regulation WHERE regulation_id = @id";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", regulationId);

            try
            {
                OpenConnection();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        regulation = new RegulationDTO(
                            reader.GetInt32("regulation_id"),
                            reader.GetString("name"),
                            reader.GetString("type"),
                            reader.IsDBNull(reader.GetOrdinal("description")) ? string.Empty : reader.GetString("description"),
                            reader.GetDateTime("created_at")
                        );
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("❌ Lỗi MySQL khi lấy quy định theo ID: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi không xác định khi lấy quy định theo ID: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return regulation;
        }

        public List<RegulationDTO> GetByName(string name)
        {
            List<RegulationDTO> results = new List<RegulationDTO>();
            string sql = @"SELECT * FROM regulation WHERE name LIKE @name";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", "%" + name + "%");

            try
            {
                OpenConnection();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new RegulationDTO(
                            reader.GetInt32("regulation_id"),
                            reader.GetString("name"),
                            reader.GetString("type"),
                            reader.IsDBNull(reader.GetOrdinal("description")) ? string.Empty : reader.GetString("description"),
                            reader.GetDateTime("created_at")
                        ));
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("❌ Lỗi MySQL khi tìm quy định theo tên: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi không xác định khi tìm quy định theo tên: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return results;
        }
    }
}
