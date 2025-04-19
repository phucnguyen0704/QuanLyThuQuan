using MySql.Data.MySqlClient;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyThuQuan.DAL
{
    class DeviceDAL : BaseDAL
    {
        public DeviceDAL() : base() { }

        public bool create(DeviceDTO device)
        {
            try
            {
                try
                {
                    string sql = @"
                        INSERT INTO device (name, image, status, created_at) 
                        VALUES (@name, @image, @status, @created_at);
                    ";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@name", device.Name);
                    command.Parameters.AddWithValue("@image", device.Image);
                    command.Parameters.AddWithValue("@status", device.Status);
                    command.Parameters.AddWithValue("@created_at", device.CreatedAt);

                    OpenConnection();
                    command.ExecuteNonQuery();
                    return true;

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi thêm thiết bị: " + ex.Message);
                    return false;
                }
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

        public bool update(DeviceDTO device)
        {
            try
            {
                try
                {
                    string sql = @"
                        UPDATE device 
                        SET name = @name, image = @image, status = @status, created_at = @created_at 
                        WHERE device_id = @device_id;
                    ";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@device_id", device.DeviceID);
                    command.Parameters.AddWithValue("@name", device.Name);
                    command.Parameters.AddWithValue("@image", device.Image);
                    command.Parameters.AddWithValue("@status", device.Status);
                    command.Parameters.AddWithValue("@created_at", device.CreatedAt);

                    OpenConnection();
                    command.ExecuteNonQuery();
                    return true;

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi cập nhật thiết bị: " + ex.Message);
                    return false;
                }
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

        public bool delete(int deviceID)
        {
            try
            {
                try
                {
                    string sql = @"
                        UPDATE device 
                        SET status = 2 
                        WHERE device_id = @device_id;
                    ";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@device_id", deviceID);

                    OpenConnection();
                    command.ExecuteNonQuery();
                    return true;

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi xóa thiết bị: " + ex.Message);
                    return false;
                }
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

        public List<DeviceDTO> getAll()
        {
            List<DeviceDTO> devices = new List<DeviceDTO>();
            try
            {
                try
                {
                    string sql = @"
                        SELECT * FROM device;
                    ";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    OpenConnection();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DeviceDTO device = new DeviceDTO(
                            reader.GetInt32("device_id"),
                            reader.GetString("name"),
                            reader.GetString("image"),
                            reader.GetInt32("status"),
                            reader.GetDateTime("created_at")
                        );
                        devices.Add(device);
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi lấy danh sách thiết bị: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khác: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return devices;
        }

        public DeviceDTO getByID(int deviceID)
        {
            DeviceDTO device = null;
            try
            {
                try
                {
                    string sql = @"
                        SELECT * FROM device 
                        WHERE device_id = @device_id;
                    ";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@device_id", deviceID);
                    OpenConnection();
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        device = new DeviceDTO(
                            reader.GetInt32("device_id"),
                            reader.GetString("name"),
                            reader.GetString("image"),
                            reader.GetInt32("status"),
                            reader.GetDateTime("created_at")
                        );
                    }
                    return device;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi lấy thiết bị theo ID: " + ex.Message);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khác: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
