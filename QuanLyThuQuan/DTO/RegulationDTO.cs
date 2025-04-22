using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuQuan.DTO
{
    public class RegulationDTO
    {
        public int RegulationID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public RegulationDTO(string name, string type, string description)
        {
            Name = name;
            Type = type;
            Description = description;
        }

        public RegulationDTO(int regulationID, string name, string type, string description, DateTime createdAt)
        {
            RegulationID = regulationID;
            Name = name;
            Type = type;
            Description = description;
            CreatedAt = createdAt;
        }

        public override string ToString()
        {
            return $"RegulationID: {RegulationID}, Name: {Name}, Type: {Type}, Description: {Description}, CreatedAt: {CreatedAt:dd-MM-yyyy}";
        }
    }
}

