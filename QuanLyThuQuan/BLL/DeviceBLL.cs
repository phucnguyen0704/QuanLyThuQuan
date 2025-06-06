﻿using QuanLyThuQuan.DAL;
using QuanLyThuQuan.DTO;
using System.Collections.Generic;

namespace QuanLyThuQuan.BLL
{
    class DeviceBLL
    {
        private DeviceDAL deviceDAL;

        public DeviceBLL()
        {
            deviceDAL = new DeviceDAL();
        }

        public bool create(DeviceDTO device)
        {
            return deviceDAL.create(device);
        }

        public bool update(DeviceDTO device)
        {
            return deviceDAL.update(device);
        }

        public bool delete(int deviceId)
        {
            return deviceDAL.delete(deviceId);
        }

        public List<DeviceDTO> getAll()
        {
            return deviceDAL.getAll();
        }

        public DeviceDTO getByID(int deviceID)
        {
            return deviceDAL.getByID(deviceID);
        }
    }
}
