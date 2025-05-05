using MySql.Data.MySqlClient;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;

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
                        WHERE reservation_id = @reservation_id AND status <> 4;
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
                        UPDATE reservation SET status = 4
                        WHERE reservation_id = @reservation_id AND status <> 4;
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
                string sql = @"
                        SELECT * FROM reservation WHERE status <> 4;
                    ";
                using (MySqlCommand command = new MySqlCommand(sql, GetConnection()))
                {
                    OpenConnection();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int? seatID = reader.IsDBNull(reader.GetOrdinal("seat_id"))
                                ? (int?)null
                                : reader.GetInt32(reader.GetOrdinal("seat_id"));
                            DateTime? returnTime = reader.IsDBNull(reader.GetOrdinal("return_time"))
                                ? (DateTime?)null
                                : reader.GetDateTime(reader.GetOrdinal("return_time"));

                            ReservationDTO reservation = new ReservationDTO(
                                reader.GetInt32("reservation_id"),
                                reader.GetUInt32("member_id"),
                                seatID,
                                reader.GetInt32("reservation_type"),
                                reader.GetDateTime("reservation_time"),
                                reader.GetDateTime("due_time"),
                                returnTime,
                                reader.GetInt32("status"),
                                reader.GetDateTime("created_at")
                            );
                            reservations.Add(reservation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách đặt chỗ: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return reservations;
        }

        public ReservationDTO getByID(int reservationID)
        {
            try
            {
                string sql = @"
                        SELECT * FROM reservation 
                        WHERE reservation_id = @reservation_id AND status <> 4;
                    ";
                using (MySqlCommand command = new MySqlCommand(sql, GetConnection()))
                {
                    command.Parameters.AddWithValue("@reservation_id", reservationID);

                    OpenConnection();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int? seatID = reader.IsDBNull(reader.GetOrdinal("seat_id"))
                                ? (int?)null
                                : reader.GetInt32(reader.GetOrdinal("seat_id"));
                            DateTime? returnTime = reader.IsDBNull(reader.GetOrdinal("return_time"))
                                ? (DateTime?)null
                                : reader.GetDateTime(reader.GetOrdinal("return_time"));

                            return new ReservationDTO(
                                reader.GetInt32("reservation_id"),
                                reader.GetUInt32("member_id"),
                                seatID,
                                reader.GetInt32("reservation_type"),
                                reader.GetDateTime("reservation_time"),
                                reader.GetDateTime("due_time"),
                                returnTime,
                                reader.GetInt32("status"),
                                reader.GetDateTime("created_at")
                            );
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy đặt chỗ theo ID: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<ReservationDTO> getCurrentViolatedReservationsByMemberID(int memberId)
        {
            List<ReservationDTO> reservations = new List<ReservationDTO>();
            string sql = @"
                            SELECT r.reservation_id, r.member_id, r.seat_id, r.reservation_type,
                                r.reservation_time, r.due_time, r.return_time,
                                r.status, r.created_at
                            FROM reservation r
                            WHERE r.status = 3 AND r.member_id = @memberId
                            AND NOT EXISTS (
                                SELECT 1
                                FROM violation v
                                WHERE v.reservation_id = r.reservation_id
                            );";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@memberId", memberId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int? seatID = reader.IsDBNull(reader.GetOrdinal("seat_id"))
                                ? (int?)null
                                : reader.GetInt32(reader.GetOrdinal("seat_id"));
                            DateTime? returnTime = reader.IsDBNull(reader.GetOrdinal("return_time"))
                                ? (DateTime?)null
                                : reader.GetDateTime(reader.GetOrdinal("return_time"));

                            ReservationDTO reservation = new ReservationDTO(
                                reader.GetInt32("reservation_id"),
                                reader.GetUInt32("member_id"),
                                seatID,
                                reader.GetInt32("reservation_type"),
                                reader.GetDateTime("reservation_time"),
                                reader.GetDateTime("due_time"),
                                returnTime,
                                reader.GetInt32("status"),
                                reader.GetDateTime("created_at")
                            );
                            reservations.Add(reservation);
                        }
                    }
                }
            }

            return reservations;
        }

    }
}
