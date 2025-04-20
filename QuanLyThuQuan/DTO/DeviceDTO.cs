using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuQuan.DTO
{
    class DeviceDTO
    {
        public int DeviceID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public DeviceDTO()
        {
            DeviceID = 0;
            Name = string.Empty;
            Image = string.Empty;
            Status = 0;
            CreatedAt = DateTime.Now;
        }

        public DeviceDTO(int deviceID, string name, string image, int status, DateTime createdAt)
        {
            DeviceID = deviceID;
            Name = name;
            Image = image;
            Status = status;
            CreatedAt = createdAt;
        }

        public override string ToString()
        {
            return $"ID: {DeviceID}, Name: {Name}, Image: {Image}, Status: {Status}, CreatedAt: {CreatedAt}";
        }
    }
}
