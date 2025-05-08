using MySql.Data.MySqlClient;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuQuan.DAL
{
    class SeatDAL : BaseDAL
    {
        public SeatDAL() : base()
        {

        }
        public bool create(SeatDTO seat)
        {
            try
            {
                string sql = @"INSERT INTO seat (name) VALUES (@seatName)";
                OpenConnection();
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                command.Parameters.AddWithValue("@seatName", seat.seatName);
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


        public bool update(SeatDTO seat)
        {
            try
            {
                try
                {
                    //MessageBox.Show("$" + seat.seatId);
                    string sql = @"
                            UPDATE seat
                            SET name = @seatName
                            WHERE seat_id = @seatId";
                    OpenConnection();
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@seatName", seat.seatName);
                    command.Parameters.AddWithValue("@seatId", seat.seatId);
                    OpenConnection();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
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

        public bool delete(int seatId)
        {
            try
            {
                try
                {
                    string sql = @"
                            UPDATE seat
                            SET status = 0
                            WHERE seat_id = @seatId";
                    OpenConnection();
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@seatId", seatId);
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
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

        public List<SeatDTO> getAll()
        {
            List<SeatDTO> seats = new List<SeatDTO>();
            try
            {
                string sql = @"SELECT * FROM seat where status <> 0";
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                OpenConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SeatDTO seat = new SeatDTO(
                        reader.GetInt32("seat_id"),
                        reader.GetString("name"),
                        reader.GetInt32("status")
                        );
                    seats.Add(seat);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khác: " + ex.Message);

                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return seats;
        }

        public SeatDTO getById(int id)
        {
            SeatDTO seat = null;
            try
            {
                try
                {
                    string sql = @"Select * from seat where seat_id = @id";
                    OpenConnection();
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        seat = new SeatDTO(
                            reader.GetInt32("seat_id"),
                            reader.GetString("name"),
                            reader.GetInt32("status")
                            );
                    }
                    return seat;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
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

        public SeatDTO getByName(string seatName)
        {
            SeatDTO seat = null;
            try
            {
                try
                {
                    string sql = @"Select * from seat where name=@seatName";
                    OpenConnection();
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@seatName", seatName);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        seat = new SeatDTO(
                            reader.GetInt32("seat_id"),
                            reader.GetString("name"),
                            reader.GetInt32("status")
                            );
                    }
                    return seat;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
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

        public bool checkName(string name)
        {
            if (getByName(name) == null)
            {
                return false;
            }
            return true;
        }

    }
}