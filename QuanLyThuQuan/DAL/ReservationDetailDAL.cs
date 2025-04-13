using MySql.Data.MySqlClient;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuQuan.DAL
{
    class ReservationDetailDAL: BaseDAL
    {
        public ReservationDetailDAL() : base() { }

        public bool create(ReservationDetailDTO reservationDetail)
        {
            try
            {
                try
                {
                    string sql = @"
                        INSERT INTO reservation_detail (reservation_id, device_id, borrow_time, due_time, return_time, status)
                        VALUES (@reservation_id, @device_id, @borrow_time, @due_time, @return_time, @status);
                    ";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@reservation_id", reservationDetail.ReservationID);
                    command.Parameters.AddWithValue("@device_id", reservationDetail.DeviceID);
                    command.Parameters.AddWithValue("@borrow_time", reservationDetail.BorrowTime);
                    command.Parameters.AddWithValue("@due_time", reservationDetail.DueTime);
                    command.Parameters.AddWithValue("@return_time", reservationDetail.ReturnTime);
                    command.Parameters.AddWithValue("@status", reservationDetail.Status);

                    OpenConnection();
                    command.ExecuteNonQuery();
                    return true;

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi thêm chi tiết đặt chỗ: " + ex.Message);
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

        public bool update(ReservationDetailDTO reservationDetail)
        {
            try
            {
                try
                {
                    string sql = @"
                        UPDATE reservation_detail 
                        SET reservation_id = @reservation_id, device_id = @device_id, borrow_time = @borrow_time, due_time = @due_time, return_time = @return_time, status = @status
                        WHERE reservation_detail_id = @reservation_detail_id;
                    ";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@reservation_detail_id", reservationDetail.ReservationDetailID);
                    command.Parameters.AddWithValue("@reservation_id", reservationDetail.ReservationID);
                    command.Parameters.AddWithValue("@device_id", reservationDetail.DeviceID);
                    command.Parameters.AddWithValue("@borrow_time", reservationDetail.BorrowTime);
                    command.Parameters.AddWithValue("@due_time", reservationDetail.DueTime);
                    command.Parameters.AddWithValue("@return_time", reservationDetail.ReturnTime);
                    command.Parameters.AddWithValue("@status", reservationDetail.Status);

                    OpenConnection();
                    command.ExecuteNonQuery();
                    return true;

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi cập nhật chi tiết đặt chỗ: " + ex.Message);
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

        public bool delete(int reservationDetailID)
        {
            try
            {
                try
                {
                    string sql = @"
                        DELETE FROM reservation_detail 
                        WHERE reservation_detail_id = @reservation_detail_id;
                    ";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@reservation_detail_id", reservationDetailID);

                    OpenConnection();
                    command.ExecuteNonQuery();
                    return true;

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi xóa chi tiết đặt chỗ: " + ex.Message);
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

        public List<ReservationDetailDTO> getAll()
        {
            List<ReservationDetailDTO> reservationDetails = new List<ReservationDetailDTO>();
            try
            {
                try
                {
                    string sql = @"
                        SELECT * FROM reservation_detail;
                    ";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());

                    OpenConnection();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ReservationDetailDTO reservationDetail = new ReservationDetailDTO(
                            reader.GetInt32("reservation_detail_id"),
                            reader.GetInt32("reservation_id"),
                            reader.GetInt32("device_id"),
                            reader.GetDateTime("borrow_time"),
                            reader.GetDateTime("due_time"),
                            reader.GetDateTime("return_time"),
                            reader.GetInt32("status")
                        );
                        reservationDetails.Add(reservationDetail);
                    }

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi lấy danh sách chi tiết đặt chỗ: " + ex.Message);
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
            return reservationDetails;
        }

        public ReservationDetailDTO getByID(int reservationDetailID)
        {
            ReservationDetailDTO reservationDetail = null;
            try
            {
                try
                {
                    string sql = @"
                        SELECT * FROM reservation_detail 
                        WHERE reservation_detail_id = @reservation_detail_id;
                    ";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@reservation_detail_id", reservationDetailID);

                    OpenConnection();
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        reservationDetail = new ReservationDetailDTO(
                            reader.GetInt32("reservation_detail_id"),
                            reader.GetInt32("reservation_id"),
                            reader.GetInt32("device_id"),
                            reader.GetDateTime("borrow_time"),
                            reader.GetDateTime("due_time"),
                            reader.GetDateTime("return_time"),
                            reader.GetInt32("status")
                        );
                    }
                    return reservationDetail;

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi lấy chi tiết đặt chỗ: " + ex.Message);
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
