using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyThuQuan.DAL
{
    class ReservationDAL: BaseDAL
    {
        public ReservationDAL() : base() { }

        private int getSeatStatusFromReservationStatus(int reservationStatus) 
        {
                int seatStatus = 0;

                switch (reservationStatus)
                {
                    case 1: // Đang sử dụng
                        seatStatus = 3;
                        break;
                    case 2: // Đã trả
                        seatStatus = 1;
                        break;
                    case 3: // Vi phạm
                        seatStatus = 1;
                        break;
                }
            return seatStatus;
        }

        private int getDeviceStatusFromReservationStatus(int reservationStatus)
        {
            int deviceStatus = 0;
            switch (reservationStatus)
            {
                case 1: // Đang sử dụng
                    deviceStatus = 2; // Đang mượn
                    break;
                case 2: // Đã trả
                    deviceStatus = 1; // Còn
                    break;
                case 3: // Vi phạm
                    deviceStatus = 2;
                    break;
            }

            return deviceStatus;
        }

        public bool create(ReservationDTO reservation)
        {
            MySqlConnection conn = GetConnection();
            MySqlTransaction transaction = null;

            try
            {
                OpenConnection();
                transaction = conn.BeginTransaction();

                string insertSql = @"
            INSERT INTO reservation (member_id, seat_id, reservation_type, reservation_time, due_time, return_time, status, created_at)
            VALUES (@member_id, @seat_id, @reservation_type, @reservation_time, @due_time, @return_time, @status, @created_at);
        ";

                using (MySqlCommand insertCmd = new MySqlCommand(insertSql, conn, transaction))
                {
                    insertCmd.Parameters.AddWithValue("@member_id", reservation.MemberID);
                    insertCmd.Parameters.AddWithValue("@seat_id", reservation.SeatID);
                    insertCmd.Parameters.AddWithValue("@reservation_type", reservation.ReservationType);
                    insertCmd.Parameters.AddWithValue("@reservation_time", reservation.ReservationTime);
                    insertCmd.Parameters.AddWithValue("@due_time", reservation.DueTime);
                    insertCmd.Parameters.AddWithValue("@return_time", reservation.ReturnTime);
                    insertCmd.Parameters.AddWithValue("@status", reservation.Status);
                    insertCmd.Parameters.AddWithValue("@created_at", reservation.CreatedAt);

                    insertCmd.ExecuteNonQuery();
                }

                // Update trạng thái ghế thành
                string updateSeatSql = "UPDATE seat SET status = 3 WHERE seat_id = @seat_id";
                using (MySqlCommand updateSeatCmd = new MySqlCommand(updateSeatSql, conn, transaction))
                {
                    updateSeatCmd.Parameters.AddWithValue("@seat_id", reservation.SeatID);
                    updateSeatCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tạo reservation + update seat: " + ex.Message);
                try { transaction?.Rollback(); } catch { }
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool create(ReservationDTO reservation, List<ReservationDetailDTO> details)
        {
            MySqlConnection conn = GetConnection();
            MySqlTransaction transaction = null;

            try
            {
                OpenConnection();
                transaction = conn.BeginTransaction();

                // Thêm reservation
                string insertReservationSql = @"
            INSERT INTO reservation (member_id, seat_id, reservation_type, reservation_time, due_time, return_time, status, created_at)
            VALUES (@member_id, @seat_id, @reservation_type, @reservation_time, @due_time, @return_time, @status, @created_at);
            SELECT LAST_INSERT_ID();";

                int insertedReservationID;

                using (MySqlCommand reservationCmd = new MySqlCommand(insertReservationSql, conn, transaction))
                {
                    reservationCmd.Parameters.AddWithValue("@member_id", reservation.MemberID);
                    reservationCmd.Parameters.AddWithValue("@seat_id", reservation.SeatID);
                    reservationCmd.Parameters.AddWithValue("@reservation_type", reservation.ReservationType);
                    reservationCmd.Parameters.AddWithValue("@reservation_time", reservation.ReservationTime);
                    reservationCmd.Parameters.AddWithValue("@due_time", reservation.DueTime);
                    reservationCmd.Parameters.AddWithValue("@return_time", reservation.ReturnTime);
                    reservationCmd.Parameters.AddWithValue("@status", reservation.Status);
                    reservationCmd.Parameters.AddWithValue("@created_at", reservation.CreatedAt);

                    insertedReservationID = Convert.ToInt32(reservationCmd.ExecuteScalar());
                }

                // Cập nhật trạng thái ghế
                string updateSeatSql = "UPDATE seat SET status = 3 WHERE seat_id = @seat_id";
                using (MySqlCommand updateSeatCmd = new MySqlCommand(updateSeatSql, conn, transaction))
                {
                    updateSeatCmd.Parameters.AddWithValue("@seat_id", reservation.SeatID);
                    updateSeatCmd.ExecuteNonQuery();
                }

                // Thêm từng ReservationDetail và cập nhật trạng thái thiết bị
                string insertDetailSql = @"
            INSERT INTO reservation_detail (reservation_id, device_id, status)
            VALUES (@reservation_id, @device_id, @status)";
                string updateDeviceSql = "UPDATE device SET status = 2 WHERE device_id = @device_id";

                foreach (var detail in details)
                {
                    using (MySqlCommand detailCmd = new MySqlCommand(insertDetailSql, conn, transaction))
                    {
                        detailCmd.Parameters.AddWithValue("@reservation_id", insertedReservationID);
                        detailCmd.Parameters.AddWithValue("@device_id", detail.DeviceID);
                        detailCmd.Parameters.AddWithValue("@status", detail.Status);
                        detailCmd.ExecuteNonQuery();
                    }

                    using (MySqlCommand updateDeviceCmd = new MySqlCommand(updateDeviceSql, conn, transaction))
                    {
                        updateDeviceCmd.Parameters.AddWithValue("@device_id", detail.DeviceID);
                        updateDeviceCmd.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm reservation kèm detail: " + ex.Message);
                try { transaction?.Rollback(); } catch { }
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool update(ReservationDTO reservation)
        {
            MySqlConnection conn = GetConnection();
            MySqlTransaction transaction = null;

            try
            {
                OpenConnection();
                transaction = conn.BeginTransaction();

                // Cập nhật thông tin Reservation
                string updateReservationSql = @"
            UPDATE reservation 
            SET member_id = @member_id, seat_id = @seat_id, reservation_type = @reservation_type,
                reservation_time = @reservation_time, due_time = @due_time, return_time = @return_time,
                status = @status, created_at = @created_at
            WHERE reservation_id = @reservation_id AND status <> 4;
        ";

                using (MySqlCommand updateReservationCmd = new MySqlCommand(updateReservationSql, conn, transaction))
                {
                    updateReservationCmd.Parameters.AddWithValue("@reservation_id", reservation.ReservationID);
                    updateReservationCmd.Parameters.AddWithValue("@member_id", reservation.MemberID);
                    updateReservationCmd.Parameters.AddWithValue("@seat_id", reservation.SeatID);
                    updateReservationCmd.Parameters.AddWithValue("@reservation_type", reservation.ReservationType);
                    updateReservationCmd.Parameters.AddWithValue("@reservation_time", reservation.ReservationTime);
                    updateReservationCmd.Parameters.AddWithValue("@due_time", reservation.DueTime);
                    updateReservationCmd.Parameters.AddWithValue("@return_time", reservation.ReturnTime);
                    updateReservationCmd.Parameters.AddWithValue("@status", reservation.Status);
                    updateReservationCmd.Parameters.AddWithValue("@created_at", reservation.CreatedAt);

                    updateReservationCmd.ExecuteNonQuery();
                }

                // Cập nhật trạng thái ghế
                if (reservation.SeatID.HasValue)
                {
                    int seatStatus = getSeatStatusFromReservationStatus(reservation.Status);

                    string updateSeatSql = "UPDATE seat SET status = @status WHERE seat_id = @seat_id";
                    using (MySqlCommand updateSeatCmd = new MySqlCommand(updateSeatSql, conn, transaction))
                    {
                        updateSeatCmd.Parameters.AddWithValue("@status", seatStatus);
                        updateSeatCmd.Parameters.AddWithValue("@seat_id", reservation.SeatID);
                        updateSeatCmd.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật reservation và seat: " + ex.Message);
                try { transaction?.Rollback(); } catch { }
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool update(ReservationDTO reservation, List<ReservationDetailDTO> details)
        {
            MySqlConnection conn = GetConnection();
            MySqlTransaction transaction = null;

            try
            {
                OpenConnection();
                transaction = conn.BeginTransaction();

                // Cập nhật reservation
                string updateReservationSql = @"
            UPDATE reservation 
            SET member_id = @member_id, seat_id = @seat_id, reservation_type = @reservation_type,
                reservation_time = @reservation_time, due_time = @due_time, return_time = @return_time,
                status = @status, created_at = @created_at
            WHERE reservation_id = @reservation_id AND status <> 4;";

                using (MySqlCommand updateReservationCmd = new MySqlCommand(updateReservationSql, conn, transaction))
                {
                    updateReservationCmd.Parameters.AddWithValue("@reservation_id", reservation.ReservationID);
                    updateReservationCmd.Parameters.AddWithValue("@member_id", reservation.MemberID);
                    updateReservationCmd.Parameters.AddWithValue("@seat_id", reservation.SeatID);
                    updateReservationCmd.Parameters.AddWithValue("@reservation_type", reservation.ReservationType);
                    updateReservationCmd.Parameters.AddWithValue("@reservation_time", reservation.ReservationTime);
                    updateReservationCmd.Parameters.AddWithValue("@due_time", reservation.DueTime);
                    updateReservationCmd.Parameters.AddWithValue("@return_time", reservation.ReturnTime);
                    updateReservationCmd.Parameters.AddWithValue("@status", reservation.Status);
                    updateReservationCmd.Parameters.AddWithValue("@created_at", reservation.CreatedAt);

                    updateReservationCmd.ExecuteNonQuery();
                }

                // Cập nhật trạng thái ghế (seat)
                if (reservation.SeatID.HasValue)
                {
                    int seatStatus = getSeatStatusFromReservationStatus(reservation.Status);

                    string updateSeatStatusSql = @"
                                                UPDATE seat 
                                                SET status = @seat_status
                                                WHERE seat_id = @seat_id;";

                    using (MySqlCommand updateSeatStatusCmd = new MySqlCommand(updateSeatStatusSql, conn, transaction))
                    {
                        updateSeatStatusCmd.Parameters.AddWithValue("@seat_status", seatStatus);
                        updateSeatStatusCmd.Parameters.AddWithValue("@seat_id", reservation.SeatID.Value);
                        updateSeatStatusCmd.ExecuteNonQuery();
                    }
                }

                // Cập nhật reservation_detail và trạng thái của các thiết bị
                string updateDetailSql = @"
            UPDATE reservation_detail
            SET reservation_id = @reservation_id, device_id = @device_id, status = @status
            WHERE reservation_detail_id = @reservation_detail_id;";

                foreach (var detail in details)
                {
                    // Cập nhật trạng thái thiết bị (device)
                    string updateDeviceStatusSql = @"
                UPDATE device
                SET status = @device_status
                WHERE device_id = @device_id;";

                    using (MySqlCommand updateDeviceStatusCmd = new MySqlCommand(updateDeviceStatusSql, conn, transaction))
                    {
                        updateDeviceStatusCmd.Parameters.AddWithValue("@device_status", getDeviceStatusFromReservationStatus(reservation.Status));
                        updateDeviceStatusCmd.Parameters.AddWithValue("@device_id", detail.DeviceID);

                        updateDeviceStatusCmd.ExecuteNonQuery();
                    }

                    // Cập nhật reservation_detail
                    using (MySqlCommand updateDetailCmd = new MySqlCommand(updateDetailSql, conn, transaction))
                    {
                        updateDetailCmd.Parameters.AddWithValue("@reservation_detail_id", detail.ReservationDetailID);
                        updateDetailCmd.Parameters.AddWithValue("@reservation_id", reservation.ReservationID);
                        updateDetailCmd.Parameters.AddWithValue("@device_id", detail.DeviceID);
                        updateDetailCmd.Parameters.AddWithValue("@status", detail.Status);

                        updateDetailCmd.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật reservation và detail: " + ex.Message);
                try { transaction?.Rollback(); } catch { }
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
                        SELECT * FROM reservation WHERE status <> 4 ORDER BY reservation_id DESC;
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
