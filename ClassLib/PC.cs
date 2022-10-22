using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public enum Status { on, off}
    [Serializable] // но почему то работает без него
    public class PC
    {
        public string Brand { get; set; }
        public string SerialNumber { get; set; }
        public int Price { get; set; }
        
        public PC()
        {
                
        }
        public PC(string brand, string serialNumber, int price)
        {
            Brand = brand;
            SerialNumber = serialNumber;
            Price = price;
        }

        public void StatusPC(Status status)
        {
            Console.WriteLine(status.ToString());
        }
    }
}
