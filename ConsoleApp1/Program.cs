using Core.HotelDataBase;
using Core.Models;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
        BasMenu:
            Console.WriteLine("--------------------------------Welcome------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1.Sisteme giris!");
            Console.WriteLine("0.Cixis");
            Console.WriteLine();
            Console.WriteLine("Seciminizi daxil edin: ");
            string choice=Console.ReadLine();
            switch (choice)
            {
                case "1":
                HotelMenu:
                    Console.WriteLine("HotelMenu: ");
                    Console.WriteLine("1.Hotel yarat!(Eyni adli olmaz...)");
                    Console.WriteLine("2.Butun hotelleri gor!");
                    Console.WriteLine("3.Hotel sec! (Hotel adi daxil ederek)");
                    Console.WriteLine("0.Cixis!");
                    Console.WriteLine();
                    Console.WriteLine("Seciminizi daxil edin: ");
                    string choice1=Console.ReadLine();
                   
                    switch (choice1)
                    {
                        
                        case "1":
                            
                            
                            bool RoomName(string name)
                            {
                                foreach (var item in HotelDB.HotelList)
                                {
                                    if (name == item.Name)
                                    {

                                        return false;
                                    }
                                }
                                return true;
                            }
                            string name;
                            do
                            {
                                Console.WriteLine("Hotel adini daxil edin: ");
                                name = Console.ReadLine();
                            } while (!RoomName(name));
                            Hotel hotel=new Hotel(name);
                            HotelDB.HotelList.Add(hotel);
                            Console.WriteLine("Hotel yaradildi!");
                            Console.WriteLine();
                            goto HotelMenu;
                         case "2":
                            if (HotelDB.HotelList.Count == 0)
                            {
                                Console.WriteLine("Hec bir otel yoxdur!");
                                goto HotelMenu;
                            }
                            Console.WriteLine("Oteller: ");
                             HotelDB.HotelList.ForEach(x=>Console.WriteLine(x));
                            Console.WriteLine();
                            goto HotelMenu;
                        case "3":
                            if (HotelDB.HotelList.Count == 0)
                            {
                                Console.WriteLine("Hec bir otel yoxdur!");
                                goto HotelMenu;
                            }
                            Console.WriteLine("Secdiyiniz otelin adini daxil edin: ");
                            string searchName=Console.ReadLine();
                            bool flag =false;
                            foreach (var item in HotelDB.HotelList)
                            {
                                if (searchName == item.Name)
                                {
                                  flag= true;
                                }
                            }
                            if (!flag)
                            {
                                Console.WriteLine("Bu adli otel yoxdur!");
                                goto HotelMenu;
                            }
                            else
                            { 
                                RoomMenu:
                                Console.WriteLine("RoomMenu: ");
                                Console.WriteLine("1.Room yarat!");
                                Console.WriteLine("2.Roomlari gor!");
                                Console.WriteLine("3.Rezervasiya et!");
                                Console.WriteLine("4.Evvelki Menyuya qayit");
                                Console.WriteLine("0.Exit!");
                                Console.WriteLine();
                                Console.WriteLine("Seciminizi daxil edin: ");
                                string choice2=Console.ReadLine();
                                switch (choice2)
                                {
                                    case "1":
                                        Console.WriteLine("Otagin  adini daxil et: ");
                                        string roomName=Console.ReadLine();
                                        double price;
                                        do
                                        {
                                            Console.Write("Otagin qiymetini daxil edin: ");
                                        } while (!double.TryParse(Console.ReadLine(),out price));
                                        Console.WriteLine();
                                        int capacity;
                                        do
                                        {
                                            Console.Write("Otagin tutumunu daxil edin: ");
                                        } while (!int.TryParse(Console.ReadLine(),out capacity));
                                        Console.WriteLine();
                                        Room room=new Room(roomName, price,capacity);
                                        foreach (var item in HotelDB.HotelList)
                                        {
                                            if (searchName == item.Name)
                                            {
                                                item.Rooms.Add(room);
                                            }
                                        }
                                        Console.WriteLine("Otaq yaradildi!");
                                        goto RoomMenu;
                                    case "2":
                                        foreach (var item in HotelDB.HotelList)
                                        {
                                            if (searchName == item.Name)

                                            {
                                                if (item.Rooms.Count == 0)
                                                {
                                                    Console.WriteLine("Otelde otaq yoxdur!");
                                                    goto RoomMenu;
                                                }
                                                Console.WriteLine("Rooms: ");
                                                item.Rooms.ForEach(x=>Console.WriteLine(x));
                                            }
                                        }
                                        goto RoomMenu;
                                    case "3":
                                        foreach (var item in HotelDB.HotelList)
                                        {
                                            if (searchName == item.Name)

                                            {
                                                if (item.Rooms.Count == 0)
                                                {
                                                    Console.WriteLine("Otelde otaq yoxdur!");
                                                    goto RoomMenu;
                                                }
                                           
                                            }
                                        }
                                        int  reserveId;
                                        do
                                        {
                                            Console.WriteLine("Rezervasya etmek istediyiniz otagin idsini daxil edin: ");
                                        } while (!int.TryParse(Console.ReadLine(),out reserveId));
                                        int newCapacity;
                                        do
                                        {
                                            Console.WriteLine("Nece nefer rezervasiya etmek istediyinizi daxil edin: ");
                                        } while (!int.TryParse(Console.ReadLine(), out newCapacity));

                                        bool check = false;
                                        foreach (var item in HotelDB.HotelList)
                                        {
                                            if (searchName == item.Name)

                                            {
                                                
                                                
                                                    foreach (var r in item.Rooms)
                                                    {
                                                        if (r.Id == reserveId)
                                                        {
                                                            check = true;
                                                        }
                                                    }
                                                    if (!check)
                                                    {
                                                  
                                                        Console.WriteLine("Bu nomreli otaq yoxdur!");
                                                        goto RoomMenu;
                                                    }
                                                    else
                                                    {
                                                        foreach (var r in item.Rooms)
                                                        {
                                                            if (r.Id == reserveId)
                                                            {

                                                                item.MakeReservation(reserveId, newCapacity);
                                                                goto RoomMenu;
                                                            }
                                                        }

                                                    }
                                                    goto RoomMenu;
                                                }
                                            }
                                        
                                            goto HotelMenu;
                                    case "4":
                                        goto HotelMenu;
                                    case "0":
                                       Environment.Exit(0);
                                        break;
                                    default:
                                        Console.WriteLine("Duzgun secim daxil edin!");
                                        goto RoomMenu;
                                }

                            }
                            goto HotelMenu;
                            case "0":

                            Environment.Exit(0);
                            break;
                            

                        default:
                            Console.WriteLine("Duzgun secim daxil edin!");
                            Console.WriteLine();
                            goto HotelMenu;
                    }

                    goto BasMenu;
                case "0":
                    break;
                default:
                    Console.WriteLine("Duzgun secim daxil edin!");
                    goto BasMenu;
            }
            
        }
    }
}
