using MySql.Data.MySqlClient;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuQuan.DAL
{
    class ReservationDAL: BaseDAL
    {
        public ReservationDAL() : base() { }

        public bool create(ReservationDTO reservation)
        {
            try
            {
                try
                {
                    string sql = @"
                        INSERT INTO reservation (member_id, seat_id, reservation_type, reservation_time, due_time, return_time, status, created_at)
                        VALUES (@member_id, @seat_id, @reservation_type, @reservation_time, @due_time, @return_time, @status, @created_at);
                    ";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@member_id", reservation.MemberID);
                    command.Parameters.AddWithValue("@seat_id", reservation.SeatID);
                    command.Parameters.AddWithValue("@reservation_type", reservation.ReservationType);
                    command.Parameters.AddWithValue("@reservation_time", reservation.ReservationTime);
                    command.Parameters.AddWithValue("@due_time", reservation.DueTime);
                    command.Parameters.AddWithValue("@return_time", reservation.ReturnTime);
                    command.Parameters.AddWithValue("@status", reservation.Status);
                    command.Parameters.AddWithValue("@created_at", reservation.CreatedAt);

                    OpenConnection();
                    command.ExecuteNonQuery();
                    return true;

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi thêm đặt chỗ: " + ex.Message);
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

        public bool update(ReservationDTO reservation)
        {
            try
            {
                try
                {
                    string sql = @"
                        UPDATE reservation 
                        SET member_id = @member_id, seat_id = @seat_id, reservation_type = @reservation_type, reservation_time = @reservation_time, due_time = @due_time, return_time = @return_time, status = @status, created_at = @created_at 
                        WHERE reservation_id = @reservation_id;
                    ";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@reservation_id", reservation.ReservationID);
                    command.Parameters.AddWithValue("@member_id", reservation.MemberID);
                    command.Parameters.AddWithValue("@seat_id", reservation.SeatID);
                    command.Parameters.AddWithValue("@reservation_type", reservation.ReservationType);
                    command.Parameters.AddWithValue("@reservation_time", reservation.ReservationTime);
                    command.Parameters.AddWithValue("@due_time", reservation.DueTime);
                    command.Parameters.AddWithValue("@return_time", reservation.ReturnTime);
                    command.Parameters.AddWithValue("@status", reservation.Status);
                    command.Parameters.AddWithValue("@created_at", reservation.CreatedAt);

                    OpenConnection();
                    command.ExecuteNonQuery();
                    return true;

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi cập nhật đặt chỗ: " + ex.Message);
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

        public bool delete(int reservationID)
        {
            try
            {
                try
                {
                    string sql = @"
                        DELETE FROM reservation 
                        WHERE reservation_id = @reservation_id;
                    ";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@reservation_id", reservationID);

                    OpenConnection();
                    command.ExecuteNonQuery();
                    return true;

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi xóa đặt chỗ: " + ex.Message);
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

        public List<ReservationDTO> getAll()
        {
            List<ReservationDTO> reservations = new List<ReservationDTO>();
            try
            {
                try
                {
                    string sql = @"
                        SELECT * FROM reservation;
                    ";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());

                    OpenConnection();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ReservationDTO reservation = new ReservationDTO(
                            reader.GetInt32("reservation_id"),
                            reader.GetInt32("member_id"),
                            reader.GetInt32("seat_id"),
                            reader.GetInt32("reservation_type"),
                            reader.GetDateTime("reservation_time"),
                            reader.GetDateTime("due_time"),
                            reader.GetDateTime("return_time"),
                            reader.GetInt32("status"),
                            reader.GetDateTime("created_at")
                        );
                        reservations.Add(reservation);
                    }

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi lấy danh sách đặt chỗ: " + ex.Message);
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
            return reservations;
        }

        // Update the nullable reference type usage to be compatible with C# 7.3 by removing the nullable annotation.
        public ReservationDTO getByID(int reservationID)
        {
            ReservationDTO reservation = null; // Remove the nullable reference type '?'.
            try
            {
                try
                {
                    string sql = @"
                        SELECT * FROM reservation 
                        WHERE reservation_id = @reservation_id;
                    ";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@reservation_id", reservationID);

                    OpenConnection();
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        reservation = new ReservationDTO(
                            reader.GetInt32("reservation_id"),
                            reader.GetInt32("member_id"),
                            reader.GetInt32("seat_id"),
                            reader.GetInt32("reservation_type"),
                            reader.GetDateTime("reservation_time"),
                            reader.GetDateTime("due_time"),
                            reader.GetDateTime("return_time"),
                            reader.GetInt32("status"),
                            reader.GetDateTime("created_at")
                        );
                    }
                    return reservation;

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi lấy đặt chỗ theo ID: " + ex.Message);
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
