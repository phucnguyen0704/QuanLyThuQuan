using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DTO;
namespace QuanLyThuQuan
{
    class Test
    {
        private DeviceBLL deviceBLL;
        private ReservationBLL reservationBLL;
        private ReservationDetailBLL reservationDetailBLL;

        public void testDevices()
        {
            deviceBLL = new DeviceBLL();
            DeviceDTO deviceDTO = new DeviceDTO()
            {
                DeviceID = 1,
                Name = "Laptop",
                Image = "laptop.jpg",
                Status = 1,
                CreatedAt = DateTime.Now,
            };
            bool result = deviceBLL.create(deviceDTO);
            Console.WriteLine(result ? "Device created successfully." : "Failed to create device.");

            DeviceDTO device = deviceBLL.getByID(1);
            if (device != null)
            {
                Console.WriteLine(device.ToString());
            }
            else
            {
                Console.WriteLine("Device not found.");
            }
        }

        public void testReservations()
        {
            reservationBLL = new ReservationBLL();
            ReservationDTO reservationDTO = new ReservationDTO()
            {
                ReservationID = 1,
                MemberID = 1,
                SeatID = 1,
                ReservationType = 1,
                ReservationTime = DateTime.Now,
                DueTime = DateTime.Now.AddHours(2),
                ReturnTime = DateTime.Now.AddHours(3),
                Status = 1,
                CreatedAt = DateTime.Now,
            };
            bool result = reservationBLL.create(reservationDTO);
            Console.WriteLine(result ? "Reservation created successfully." : "Failed to create reservation.");

            ReservationDTO reservation = reservationBLL.getByID(1);
            if (reservation != null)
            {
                Console.WriteLine(reservation.ToString());
            }
            else
            {
                Console.WriteLine("Reservation not found.");
            }
        }

        public void testReservationDetails()
        {
            reservationDetailBLL = new ReservationDetailBLL();
            ReservationDetailDTO reservationDetailDTO = new ReservationDetailDTO()
            {
                ReservationDetailID = 1,
                ReservationID = 1,
                DeviceID = 1,
                BorrowTime = DateTime.Now,
                DueTime = DateTime.Now.AddHours(2),
                ReturnTime = DateTime.Now.AddHours(3),
                Status = 1,
            };
            bool result = reservationDetailBLL.create(reservationDetailDTO);
            Console.WriteLine(result ? "Reservation detail created successfully." : "Failed to create reservation detail.");

            ReservationDetailDTO reservationDetail = reservationDetailBLL.getByID(1);
            if (reservationDetail != null)
            {
                Console.WriteLine(reservationDetail.ToString());
            }
            else
            {
                Console.WriteLine("Reservation detail not found.");
            }
        }
    }

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fLogin());
            Test test = new Test();
            test.testDevices();
            test.testReservations();
            test.testReservationDetails();
        }
    }
}
