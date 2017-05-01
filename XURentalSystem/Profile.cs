using System;

namespace XURentalSystem
{
    public class Profile
    {
        public string Name { get; set; }
        public string Section { get; set; }
        public DateTime Time = DateTime.Now;
        public string IdNumber { get; set; }
        public Boolean CSG { get; set; }
        public string Amount { get; set; }
    }
}