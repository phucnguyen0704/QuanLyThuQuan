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
    public class SeatDAL : BaseDAL
    {
        public SeatDAL() : base()
        {

        }
        public bool create(SeatDTO seat)
        {
            try
            {
                string sql = @"INSERT INTO seat (name) VALUES (@seatName)";
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                command.Parameters.AddWithValue("@seatName", seat.seatName);
                OpenConnection();
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
                    string sql = @"
                            UPDATE seat
                            SET name = @seatName
                            WHERE seat_id = @seatId";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@seatName", seat.seatName);
                    OpenConnection();
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

        public bool delete(int seatId) {
            try
            {
                try
                {
                    string sql = @"
                            UPDATE seat
                            SET status = 0
                            WHERE seat_id = @seatId";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@seatId", seatId);
                    OpenConnection();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Loi: " + ex.Message);
                    return false;
                }
            }
            catch (Exception ex) { 
                Console.WriteLine("Loi khac: "+ ex.Message);
                return false;

            }
            finally
            {
                CloseConnection();
            }
        }

        public List<SeatDTO> getAll() {
            List<SeatDTO> seats = new List<SeatDTO>();
            try
            {
                try
                {
                    string sql = @"SELECT * FROM seat where status = 1";
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
                    Console.WriteLine("Loi: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi khac: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return seats;
        }

        public SeatDTO getById(int id) { 
            SeatDTO seat = null;
            try
            {
                try
                {
                    string sql = @"Select * from seat where seat_id = @id";
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@id", id);
                    OpenConnection();
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
                    Console.WriteLine("Loi: " + ex.Message);
                    return null;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi khac: " + ex.Message);
                return null;
            }
            finally {
                CloseConnection() ;
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
                    MySqlCommand command = new MySqlCommand(sql, GetConnection());
                    command.Parameters.AddWithValue("@seatName", seatName);
                    OpenConnection();
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

        public bool checkName(string name) {
            if (getByName(name) == null) { 
                return false;
            }
            return true;
        }

    }
}
