using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Room
    {
        static int id;
        public int Id { get; set; }
        public string Name { get; set; }
        public double  Price { get; set; }
        public int PersonCapacity { get; set; }
        public bool IsAvialable = true;
        public Room(string name,double price,int personCapacity)
        {
            Id = ++id;
            Name = name;
            Price = price;
            PersonCapacity = personCapacity;
        

            
        }
        public override string ToString()
        {
            return $"Id: {Id}; Name: {Name}; Price: {Price}; PersonCapacity: {PersonCapacity}; IsAvialable: {IsAvialable}";
        }
       
    }
}
