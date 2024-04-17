using Core.Exseptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
   public  class Hotel
    {
        static int id;
        public int HotelId { get; set; }
        public string  Name { get; set; }
       
        public  List<Room> Rooms=new List<Room>();
        public Hotel(string name) {
            HotelId = ++id;
            Name = name;
        }
        public void AddRoom(Room room)

        {
            
            Rooms.Add(room);
        }
        public List<Room> FindAllRoom(Predicate<Room> method)
        {
           return Rooms.FindAll(method);
        }
        public void MakeReservation(int? roomId,int capacity)
        {
          if(roomId == null)
            {
                try
                {

                    throw new NullReferanceException("Room id is null");

                }
                catch (NullReferanceException e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                foreach (Room room in Rooms)
                {
                    if(room.Id == roomId)
                    {
                        if(room.IsAvialable )
                        {
                            if (room.PersonCapacity <= capacity)
                            {
                                room.IsAvialable = true;
                                Console.WriteLine("Rezervasiya elemek mumkun olacaq!");
                            }
                            else
                            {
                                {  room.IsAvialable = false;
                                    Console.WriteLine("Artiq rezervasiya elemek olmayacaq");
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                throw new NotAvailableException("Available is false");
                            }
                            catch (NotAvailableException ex)
                            {

                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }
            }

        }
        public override string ToString()
        {
            return $"Hotel id: {HotelId}; Name: {Name}; Room Counts in hotel:{Rooms.Count}";
        }
    }
}
