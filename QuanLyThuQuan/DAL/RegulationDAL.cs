using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            using (MySqlConnection conn = GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", regulation.Name);
                cmd.Parameters.AddWithValue("@type", regulation.Type);
                cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(regulation.Description) ? (object)DBNull.Value : regulation.Description);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi MySQL: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Update(RegulationDTO regulation)
        {
            string sql = @"UPDATE regulation SET name = @name, type = @type, description = @description WHERE regulation_id = @id";

            using (MySqlConnection conn = GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", regulation.Name);
                cmd.Parameters.AddWithValue("@type", regulation.Type);
                cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(regulation.Description) ? (object)DBNull.Value : regulation.Description);
                cmd.Parameters.AddWithValue("@id", regulation.RegulationID);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi MySQL: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Delete(int regulationId)
        {
            string sql = @"DELETE FROM regulation WHERE regulation_id = @id";

            using (MySqlConnection conn = GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", regulationId);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi MySQL: " + ex.Message);
                    return false;
                }
            }
        }

        public List<RegulationDTO> GetAll()
        {
            List<RegulationDTO> regulations = new List<RegulationDTO>();
            string sql = @"SELECT * FROM regulation";

            using (MySqlConnection conn = GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                try
                {
                    conn.Open();
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
                    Console.WriteLine("Lỗi MySQL: " + ex.Message);
                }
            }
            return regulations;
        }

        public RegulationDTO GetById(int regulationId)
        {
            RegulationDTO regulation = null;
            string sql = @"SELECT * FROM regulation WHERE regulation_id = @id";
            using (MySqlConnection conn = GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", regulationId);
                try
                {
                    conn.Open();
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
                    Console.WriteLine("Lỗi MySQL: " + ex.Message);
                }
            }
            return regulation;
        }

        public List<RegulationDTO> GetByName(string name)
        {
            List<RegulationDTO> results = new List<RegulationDTO>();
            string sql = @"SELECT * FROM regulation WHERE name LIKE @name";

            using (MySqlConnection conn = GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", "%" + name + "%");

                try
                {
                    conn.Open();
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
                    Console.WriteLine("Lỗi MySQL: " + ex.Message);
                }
            }
            return results;
        }
    }
}
