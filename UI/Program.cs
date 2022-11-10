﻿using Dapper;
using MySqlConnector;
internal class Program
{
    static Database newDatabase = new Database();
    static RoomManager roomManager = new();


    private static void Main(string[] args)
    {
        Database newDatabase = new Database();
        RoomManager roomManager = new();



        Console.WriteLine("Employee Press [1]\nCustomer Press [2]");
        string answer = Console.ReadLine();
        if (answer == "1")
        {
            Employee();
        }
        else if (answer == "2")
        {
            Customer();
        }
    }

    static void Employee()
    {
        Console.Clear();

        int employeeID = GetID();

        // if (employeeID != 1 || employeeID != 2 || employeeID != 3) //Hämta från databasen
        {
            Console.WriteLine("ID not recognized! Try again");
        }


        foreach (string c in Enum.GetNames(typeof(MenuChoiceStaff)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceStaff), Enum.Parse(typeof(MenuChoiceStaff), c), "d"));

        GetEmployeeInput();

    }

    private static void GetEmployeeInput()
    {
        Console.WriteLine("Select one of the options:");
        int input = int.Parse(Console.ReadLine());
        MenuChoiceStaff choice = (MenuChoiceStaff)input;

        switch (choice)
        {
            case MenuChoiceStaff.ShowRoom:
                Console.WriteLine("All rooms!");
                foreach (var item in roomManager.ShowAllRooms())
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Available rooms!");
                foreach (var item in roomManager.ShowAvailableRoom())
                {
                    Console.WriteLine(item);
                }
                // Console.WriteLine (newDatabase.GetRoomList());   
                //RoomManager.ShowAvailableRoom();  //Behöver ändra dessa till anrop
                break;

            case MenuChoiceStaff.CheckIn:
                Console.WriteLine("Check in/Check out");
                break;

            case MenuChoiceStaff.AddRoom: // and also RemoveRoom()
                AddRoomMenyInput();

                break;
            case MenuChoiceStaff.RemoveRoom:

                Console.WriteLine("room Id: ");
                int id = int.Parse(Console.ReadLine());
                roomManager.RemoveRoom(id);
                break;

            case MenuChoiceStaff.Receipt:
                Console.WriteLine("Print Receipt");
                break;

            case MenuChoiceStaff.Update:
                Console.WriteLine("Update room status");
                foreach (var item in roomManager.ShowAllRooms())
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Choose room to update: ");
                string roomToUpdate = Console.ReadLine();
                Console.WriteLine("Choose room status: \n [1] checked in \n [2] check out \n [3] reserved \n [4] not in use");
                string newRoomStatus = Console.ReadLine();

                break;

            case MenuChoiceStaff.Quit:
                Console.WriteLine("Quit");
                break;

            default:
                break;
        }
    }

    static void Customer()
    {
        foreach (string c in Enum.GetNames(typeof(MenuChoiceCustomer)))
            Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceCustomer), Enum.Parse(typeof(MenuChoiceCustomer), c), "d"));
        GetCustomerInput();

    }

    private static void GetCustomerInput()
    {
        Console.WriteLine("Select one of the options:");
        int CustomerInput = int.Parse(Console.ReadLine());
        MenuChoiceCustomer CustomerChoice = (MenuChoiceCustomer)CustomerInput;


        switch (CustomerChoice)
        {
            case MenuChoiceCustomer.ViewRoom:
                Console.WriteLine("View Available Rooms");
                break;

            case MenuChoiceCustomer.ViewReviews:
                Console.WriteLine("View Reviews");
                break;

            case MenuChoiceCustomer.BookRoom:
                Console.WriteLine("Book Room");
                break;

            case MenuChoiceCustomer.WriteReview:
                Console.WriteLine("Write Review");
                break;

            case MenuChoiceCustomer.Quit:
                Console.WriteLine("Quit");
                break;


            default:
                break;
        }
    }



    private static void AddRoomMenyInput()
    {
        Console.WriteLine("room Id: ");
        int id1 = int.Parse(Console.ReadLine());
        Console.WriteLine("TYPE ID: ");
        int id2 = int.Parse(Console.ReadLine());
        Console.WriteLine("STATUS ID");
        int id3 = int.Parse(Console.ReadLine());
        Console.WriteLine("price");
        double p = double.Parse(Console.ReadLine());
        roomManager.AddRoom(id1, id2, id3, p);
    }

    // static void Login()
    // {
    //     int temp = 0;
    // while (temp < 3)
    // {

    //   Console.Write("\nEnter socialsercurity number: ");
    //   SocialSecurityNumber = Console.ReadLine();
    //   Console.Write("\nEnter Password: ");
    //   string userPassword = Console.ReadLine();
      
    //     if (SocialSecurityNumber == "1" && userPassword  == "2")
    //     {          
    //        isLoggedIn =true ;  
    //        break;                          
    //     }      
      
    //    else 
    //     {
    //        if(temp<2)
    //        Console.Write("\nLoggin unsucced, try again!");
    //        else
    //        Console.Write("\nNO more try. Bye!");
    //     }
    //       temp++;
    //     }
    // }
}