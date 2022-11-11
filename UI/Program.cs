﻿using Dapper;
using MySqlConnector;
internal class Program
{

    static RoomManager roomManager = new();
    static CustomerManager customerManager = new();
    //static EmployeeManager employeeManager = new();
    static bool isLogIn = true;



    private static void Main(string[] args)
    {

        Console.WriteLine("Employee Press [1]\nCustomer Press [2]");
        string answer = Console.ReadLine();

        if (answer == "1")
        {
            //Employee();
            Console.Clear();
            EmployeeLog();
            if (isLogIn)
            {
                GetEmployeeInput();
            }
        }
        else if (answer == "2")
        {
            // Customer();
            Console.Clear();
            CustomerLog();
            if (isLogIn)
            {
                GetCustomerInput(); ;
            }
        }

    }
    // static void Employee()
    // {
    //      Console.Clear();
    //         EmployeeLog();
    //         if (isLogIn)
    //         {
    //             GetEmployeeInput();
    //         }
    // }

    // static void Customer()
    // {
    //     Console.Clear();
    //     CustomerLog();
    //     if (isLogIn)
    //     {
    //         GetCustomerInput(); ;
    //     }
    // }

    private static void EmployeeLog()
    {
        int temp = 0;
        while (temp < 3)
        {
            //Employee employee = new();
            int employeeID;
            string employeePass;
            try
            {
                GetID(out employeeID, out employeePass);
            }
            catch (System.Exception)
            {

                throw;
            }
            // GetID(out employeeID, out employeePass);
            //employeeID== employee.employee_id && employeeID!=null

            if (employeeID == 1 && employeePass == "1")
            {
                isLogIn = true;
                break;
            }
            else
            {
                if (temp < 2)
                    LoginWrongMessage();
                else
                    NoTryMessage();
            }
            temp++;

        }


    }

    private static void GetID(out int employeeID, out string employeePass)
    {
        Console.WriteLine("Please enter your ID: "); //For-loop i<3?
        employeeID = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter password");
        employeePass = Console.ReadLine();
    }

    private static void NoTryMessage()
    {
        Console.Write("\nNO more try. Bye!");
    }

    private static void LoginWrongMessage()
    {
        Console.Write("\nLoggin unsucced, try again!");
    }

    private static void GetEmployeeInput()
    {
        bool quit = true;
        while (quit)
        {

            foreach (string c in Enum.GetNames(typeof(MenuChoiceStaff)))
                Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceStaff), Enum.Parse(typeof(MenuChoiceStaff), c), "d"));

            Console.WriteLine("Select one of the options:");
            int employeeInput = int.Parse(Console.ReadLine());
            MenuChoiceStaff choice = (MenuChoiceStaff)employeeInput;

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
                    Console.ReadKey();
                    break;

                case MenuChoiceStaff.CheckIn:
                Console.WriteLine("Show AllCustomer!");
                 foreach (var item in customerManager.ShowAllCustomers())
                    {
                        Console.WriteLine(item);
                    }
                   
                    Console.ReadKey();
               
                //     Console.WriteLine("Check in/Check out");
                //     Console.WriteLine("Job Title ID: "); //LÄGGA DETTA I PROGRAM
                //     int addJobTitleId = int.Parse(Console.ReadLine());
                //     Console.WriteLine("First name: ");
                //     string addEmployeeFName = Console.ReadLine();
                //     Console.WriteLine("Last name: ");
                //     string addEmployeeLName = Console.ReadLine();
                //     Console.WriteLine("Phone: ");
                //     int addEmployeePhone = int.Parse(Console.ReadLine());
                //     Console.WriteLine("Email: ");
                //     string addEmployeeEmail = Console.ReadLine();
                //    int eId= employeeManager.AddEmployee(addJobTitleId,addEmployeeFName,addEmployeeLName,addEmployeePhone,addEmployeeEmail);
                //    Console.WriteLine (eId);

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
                    Console.WriteLine("Do you want a receipt? Y/N");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "y")
                    {
                        Console.WriteLine("Your receipt");//Console.WriteLine("Receipt\n" + "Check in date: " + date_in + "\nCheck out date: " + check_out + "\nCustomer name: " + customer_fname + customer_lname + "\nRoom: " + room_id + "\nTotal Price: " + Price +"\nHotellet\nTel: 033-106600\nAllégatan 13 \nBorås");
                        quit = false;
                    }
                    else if (answer == "n")
                    {
                        Console.WriteLine("No receipt chosen!");
                        quit = false;
                    }
                    else
                    {
                        Console.WriteLine("your choice does not exist!");

                    }
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
                    roomManager.UpdateRoomStatusID(roomToUpdate, newRoomStatus);
                    break;

                case MenuChoiceStaff.Quit:
                    Console.WriteLine("You have chosen to quit the program");
                    quit = false;
                    break;

                default:
                    break;
            }
        }
    }

    private static void CustomerLog()
    {
        int temp = 0;
        while (temp < 3)
        {
            Customer customer = new();
            Console.WriteLine("Please enter your ID: "); //For-loop i<3?
            int customerID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter password");
            string customerPass = Console.ReadLine();
            //employeeID== employee.employee_id && employeeID!=null

            if (customerID == 2 && customerPass == "2")
            {
                isLogIn = true;
                break;
            }
            else
            {
                if (temp < 2)
                    Console.Write("\nLoggin unsucced, try again!");
                else
                    Console.Write("\nNO more try. Bye!");

            }
            temp++;

        }


    }

    private static void GetCustomerInput()
    {
        bool quit = true;
        while (quit)
        {
            foreach (string c in Enum.GetNames(typeof(MenuChoiceCustomer)))
                Console.WriteLine("{0,-11}= {1}", c, Enum.Format(typeof(MenuChoiceCustomer), Enum.Parse(typeof(MenuChoiceCustomer), c), "d"));

            Console.WriteLine("Select one of the options:");
            int CustomerInput = int.Parse(Console.ReadLine());
            MenuChoiceCustomer CustomerChoice = (MenuChoiceCustomer)CustomerInput;


            switch (CustomerChoice)
            {

                case MenuChoiceCustomer.ViewRoom:
                    Console.WriteLine("Add customer!");
                    Console.WriteLine("First name: ");
                    string addCustomerFName = Console.ReadLine();
                    Console.WriteLine("Last name: ");
                    string addCustomerLName = Console.ReadLine();
                    Console.WriteLine("Phone: ");
                    int addCustomerPhone = int.Parse(Console.ReadLine());
                    Console.WriteLine("Email: ");
                    string addCustomerEmail = Console.ReadLine();
                    Console.WriteLine("City: ");
                    string addCustomerCity = Console.ReadLine();
                    Console.WriteLine("Country: ");
                    string addCustomerCountry = Console.ReadLine();
                    Console.WriteLine("Address: ");
                    string addCustomerAddress = Console.ReadLine();
                    int addId = customerManager.AddCustomer(addCustomerFName, addCustomerLName, addCustomerPhone, addCustomerEmail, addCustomerCity, addCustomerCountry, addCustomerAddress);
                    Console.WriteLine(addId);

                    Console.WriteLine("All rooms!");

                    // foreach (var item in roomManager.ShowAllRooms())
                    // {
                    //     Console.WriteLine(item);
                    // }
                    // Console.WriteLine("Available rooms!");
                    // foreach (var item in roomManager.ShowAvailableRoom())
                    // {
                    //     Console.WriteLine(item);
                    // }
                    // Console.ReadKey();
                    break;

                case MenuChoiceCustomer.ViewReviews:
                    Console.WriteLine("View Reviews");
                    break;

                case MenuChoiceCustomer.BookRoom:
                    Console.WriteLine("Book Room");
                    break;

                case MenuChoiceCustomer.WriteReview:
                    Console.WriteLine("Please, Write your review, make sure to add your account:");
                    string review = Console.ReadLine();
                    break;

                case MenuChoiceCustomer.Quit:
                    Console.WriteLine("You have chosen to quit the program");
                    quit = false;
                    break;

                default:
                    break;

            }
        }
    }

    private static void AddRoomMenyInput()
    {
        Console.WriteLine("TYPE ID: ");
        int id2 = int.Parse(Console.ReadLine());
        Console.WriteLine("STATUS ID");
        int id3 = int.Parse(Console.ReadLine());
        Console.WriteLine("price");
        double p = double.Parse(Console.ReadLine());
        Console.WriteLine("Added room ID:");
        Console.WriteLine(roomManager.AddRoom(id2, id3, p));//id1,
        Console.ReadLine();
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

    //   static void Employee()
    // {
    //     Console.Clear();

    //     int employeeID = GetID();

    //     // if (employeeID != 1 || employeeID != 2 || employeeID != 3) //Hämta från databasen
    //     {
    //         Console.WriteLine("ID not recognized! Try again");
    //     }



    //     GetEmployeeInput();

}
