using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;


namespace WestminsterRentals
{
    class WestminsterRentalVehicle : IRentalVehicleCustomer, IRentalVehicleManager
    {
        //create a dictionary to manage booking details
        //Dictionary<int, Booking> bookingRepo = new Dictionary<int, Booking>();
        List<Booking> bookingRepo = new List<Booking>();
        //create a Dictionary to manage vehicle details
        Dictionary<string, Vehicle> VehicleRepo = new Dictionary<string, Vehicle>();
        //create a Dictionary to manage customer details
        Dictionary<string, Customer> UserRepo = new Dictionary<string, Customer>();
        //List of available vehicles in a specific Time Period
        List<Vehicle> vehicleAvailableList = new List<Vehicle>();



        static void Main(string[] args)
        {
            //create a WestminsterRentalVehicle object to view
            WestminsterRentalVehicle view = new WestminsterRentalVehicle();
            view.customerMenu();
        }
        //method defines customer menu
        public void customerMenu()
        {
            //initialize customer menu attributes to create customer objects and Shedule Objects
            string cusID;
            string cusName;
            string cusAddress;
            string cusLicense;
            int cusContact;
            bool check = true;
            string vehNo;
            DateTime pick;
            DateTime drop;
            Schedule tempShedule;

            //Print the customer options menu to select options
            Console.WriteLine("************************Customer Menu*******************************");
            Console.WriteLine("Option 1 : List of available Vehicles");
            Console.WriteLine("Option 2 : Rent a vehicle");
            Console.WriteLine("Option 3 : Shift to the Admin Menu");
            Console.WriteLine("Option 4 : Exit from the system");
            int customerOption = Convert.ToInt32(Console.ReadLine());

            //switch case to select customer options 
            switch (customerOption)
            {
                case 1:
                    try
                    {
                        //prompt to receive the pickup and dropoff dates
                        //Do while is used to retake the pickup and dropoff dates until the pickup date is before the dropoff date 
                        do
                        {
                            Console.Write(" Enter the pickup date (mm/dd/yyyy) : ");
                            pick = Convert.ToDateTime(Console.ReadLine());
                            Console.Write(" Enter the drop off date (mm/dd/yyyy) : ");
                            drop = Convert.ToDateTime(Console.ReadLine());
                        } while (drop < pick);
                        //create a temporary shedule object
                        tempShedule = new Schedule(pick, drop);
                        //Print the available categories of vehicles and obtain the vehicle type need to be Listed 
                        Console.WriteLine("*Car\n*Van\n*Motor bike\n*Electric car");
                        Console.Write("Select the vehicle type you need to add : ");
                        string vehicleSelect = Console.ReadLine().ToUpper();
                        //switch case to call the listavailable function based on the vehicle type need to be listed
                        switch (vehicleSelect)
                        {
                            case "CAR":
                                Console.WriteLine("Make\tRegistration Number\tmodel");
                                listAvailableVehicles(tempShedule, VehicleType.Cars);
                                break;
                            case "VAN":
                                listAvailableVehicles(tempShedule, VehicleType.Vans);
                                break;
                            case "MOTOR BIKE":
                            case "MOTORBIKE":
                                listAvailableVehicles(tempShedule, VehicleType.MotorBikes);
                                break;
                            case "ELECTRIC CAR":
                            case "ELECTRICCAR":
                                listAvailableVehicles(tempShedule, VehicleType.ElectricCars);
                                break;
                            default:
                                Console.WriteLine("Invalid selection");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid Argument. Please try again ");
                    }
                    customerMenu();
                    break;
                case 2:
                    
                    //prompt to obtain customer ID
                    Console.Write(" Type the customer ID : ");
                    cusID = Console.ReadLine();
                    try
                    {
                        //prompt to receive the pickup and dropoff dates
                        //Do while is used to retake the pickup and dropoff dates until the pickup date is before the dropoff date 
                        do
                        {
                            Console.Write(" Enter the pickup date (mm/dd/yyyy) : ");
                            pick = Convert.ToDateTime(Console.ReadLine());
                            Console.Write(" Enter the drop off date (mm/dd/yyyy) : ");
                            drop = Convert.ToDateTime(Console.ReadLine());
                        } while (drop < pick);

                        //create a temporary Schedule as user request
                        tempShedule = new Schedule(pick, drop);

                        //prompt and request the vehicle No
                        Console.Write(" Enter the Vehicle number : ");
                        vehNo = Console.ReadLine().ToUpper();

                        //bool variable to initialize the vehicle is not detected as overlapping
                        bool vehicleDetect = false;

                        //check the exsistance of the vehicle in the vehicle Repository
                        //itterate through each vehicle registration number in vehicle repository
                        foreach (string keyValue in VehicleRepo.Keys)
                        {
                            //recognize the availability of the vehicle in the repository
                            //if condition to check whether the given registration number exist in the vehicle repository
                            if (keyValue.Equals(vehNo))
                            {
                                vehicleDetect = true;
                                //check whether vehicle no overlaps within the wanted shedule
                                //if it overlaps it returns true else it returns false
                                if (rentVehicle(vehNo, tempShedule))
                                {
                                    //Display the senario of two shedules are overlapping
                                    Console.WriteLine("Two Shedules Overlaps. please select a seperate vehicle or try another date");
                                }
                                else
                                {
                                    //since the sheduled is not overlapped the reservation can be done
                                    //recognize the customer details by customer ID from the User Repository

                                    //itterate through customer repository to obtain the customer ID
                                    foreach (string key in UserRepo.Keys)
                                    {
                                        //if condition if the given customer id equals to a customer Id in the user repository
                                        if (key.Equals(cusID))
                                        {
                                            //create a temporary Booking object
                                            Booking tempBooking = new Booking(tempShedule, VehicleRepo[keyValue], UserRepo[key]);
                                            //add the booking object to the booking repository
                                            bookingRepo.Add(tempBooking);
                                            Console.WriteLine("Booking was done successfully");
                                            check = false;
                                            break;
                                        }
                                    }
                                    //case the Customer details are not recognized
                                    //add the customer details if the customer doesn't exsis based on customer ID
                                    if (check)
                                    {
                                        Console.Write(" Enetr the customer name : ");
                                        cusName = Console.ReadLine();
                                        Console.Write(" Enter the customer address : ");
                                        cusAddress = Console.ReadLine();
                                        Console.Write(" Enter the customer License Number : ");
                                        cusLicense = Console.ReadLine();
                                        Console.Write(" Enter the customer Contact number : ");
                                        cusContact = Convert.ToInt32(Console.ReadLine());
                                        Customer tempuser = new Customer(cusID, cusName, cusAddress, cusLicense, cusContact);
                                        UserRepo.Add(tempuser.getUserId(), tempuser);
                                        Booking tempBooking = new Booking(tempShedule, VehicleRepo[keyValue], tempuser);
                                        bookingRepo.Add(tempBooking);
                                        Console.WriteLine("Booking was done successfully");

                                    }

                                }
                                break;
                            }
                        }
                        //if condition if the vehicle is not detected 
                        if (!vehicleDetect)
                        {
                            Console.WriteLine("Vehicle is not in the Repository");
                        }

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid Argument. Please try again ");
                    }
                    
                    customerMenu();
                    break;
                case 3:
                    //call method adminmenu to return to the admin menu
                    adminMenu();
                    break;
                case 4:
                    //condition to break from the system
                    break;
                default:
                    //call method customerMenu to return to the customerMenu
                    customerMenu();
                    break;
            }
        }
        //method defines admin menu
        public void adminMenu()
        {
            //define attributes to create different types ofvehicle objects
            string regNo;
            string make;
            string model;
            int capacity;
            bool aircon;
            bool fridge;
            bool helmet;

            //Print the customer options menu to select options
            Console.WriteLine("************************Admin Menu*******************************");
            Console.WriteLine("Option 1 : Add a vehicle");
            Console.WriteLine("Option 2 : Delete a vehicle");
            Console.WriteLine("Option 3 : List all the vehicles");
            Console.WriteLine("Option 4 : List all the ordered vehicles");
            Console.WriteLine("Option 5 : Generate a report");
            Console.WriteLine("Option 6 : Shift to the customer Menu");
            Console.WriteLine("Option 7 : Exit from the system");
            Console.Write("Select the option number from the above list : ");
            int adminOption = Convert.ToInt32(Console.ReadLine());


            //switch case to select admin options 
            switch (adminOption)
            {
                case 1:
                    //obtain user inputs to create different types of vehical objects
                    Console.WriteLine("*Car\n*Van\n*Motor bike\n*Electric car");
                    Console.Write("Select the vehicle type you need to add : ");
                    string vehicleSelect = Console.ReadLine().ToUpper();
                    Console.Write("\nType the Registration number without space : ");
                    regNo = (Console.ReadLine()).ToUpper();
                    Console.Write("Type the Model of the Vehicle : ");
                    make = Console.ReadLine().ToUpper();
                    Console.Write("Type the make of the Vehicle : ");
                    model = Console.ReadLine().ToUpper();
                    try
                    {
                        Console.Write("Type the passenger capacity of the Vehicle : ");
                        capacity = Convert.ToInt32(Console.ReadLine());
                        //Switch case to create vehicles based on type of vehicle(car,van,motorbike.electric car)
                        switch (vehicleSelect)
                        {
                            case "CAR":
                                //obtain user inputs whether the vehicle is a AC vehicle
                                Console.WriteLine("If it is a AC Car type yes. else type any other key");
                                string ac = Console.ReadLine().ToUpper();
                                //switch case to specify aircon variable by checking the status of the ac
                                switch (ac)
                                {
                                    case "YES":
                                        aircon = true;
                                        break;
                                    default:
                                        aircon = false;
                                        break;
                                }
                                //create the tempcar object
                                Cars tempCar = new Cars(regNo, make, model, capacity, aircon);
                                //call addVehiclemethod by inputting the tempcar object
                                addVehicle(tempCar);
                                break;
                            case "VAN":
                                //obtain user inputs whether the vehicle is a AC vehicle and whether it has a minifridge
                                Console.WriteLine("If it is a AC Van type yes. else type any other key");
                                ac = Console.ReadLine().ToUpper();
                                Console.WriteLine("If it has a minifridge type yes. else type any other key");
                                string minifridge = Console.ReadLine().ToUpper();
                                //switch case to specify aircon variable by checking the status of the ac
                                switch (ac)
                                {
                                    case "YES":
                                        aircon = true;
                                        break;
                                    default:
                                        aircon = false;
                                        break;
                                }
                                //switch case to specify fridge variable by checking the status of the minifridge
                                switch (minifridge)
                                {
                                    case "YES":
                                        fridge = true;
                                        break;
                                    default:
                                        fridge = false;
                                        break;
                                }
                                //create the tempVan object
                                Van tempVan = new Van(regNo, make, model, capacity, aircon, fridge);
                                //call addVehiclemethod by inputting the tempVan object
                                addVehicle(tempVan);
                                break;
                            case "MOTOR BIKE":
                            case "MOTORBIKE":
                                //obtain user inputs whether the vehicle consist of a helmet
                                Console.WriteLine("Type yes if the helmet is available. ");
                                string optionHelmet = Console.ReadLine().ToUpper();
                                //switch case to specify helmet variable by checking the status of the optionHelmet
                                switch (optionHelmet)
                                {
                                    case "YES":
                                        helmet = true;
                                        break;
                                    default:
                                        helmet = false;
                                        break;
                                }
                                //create the tempBike object
                                MotorBikes tempBike = new MotorBikes(regNo, make, model, capacity, helmet);
                                //call addVehiclemethod by inputting the tempVan object
                                addVehicle(tempBike);
                                break;
                            case "ELECTRIC CAR":
                            case "ELECTRICCAR":
                                //obtain user inputs whether the vehicle is a ac vehicle and the range of the vehicle
                                Console.WriteLine("If it is a AC car type yes. else type any other key");
                                ac = Console.ReadLine().ToUpper();
                                Console.WriteLine("Type the km range of the electric car");
                                int kmRange = Convert.ToInt32(Console.ReadLine());
                                //switch case to specify aircon variable by checking the status of the ac
                                switch (ac)
                                {
                                    case "YES":
                                        aircon = true;
                                        break;
                                    default:
                                        aircon = false;
                                        break;
                                }
                                //create the tempECCars object
                                ElectricCars tempECCars = new ElectricCars(regNo, make, model, capacity, aircon, kmRange);
                                //call addVehiclemethod by inputting the tempECCars object
                                addVehicle(tempECCars);
                                break;
                            default:
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid arguments--- Please try again ");
                    }

                    //call the method adminMenu
                    adminMenu();
                    break;
                case 2:
                    //obtain the registration number of the vehicle user need to be deleted
                    Console.Write("Type the vehicle registration number you need to delete : ");
                    regNo = (Console.ReadLine()).ToUpper();
                    //call delete vehcile method by inputting registration number
                    deleteVehicle(regNo);
                    //call the method adminMenu
                    adminMenu();
                    break;
                case 3:
                    //call the  list vehicle method
                    listVehicles();
                    //call the method adminMenu
                    adminMenu();
                    break;
                case 4:
                    //call the  list vehicle ordered method
                    listVehiclesOrdered();
                    //call the method adminMenu
                    adminMenu();
                    break;
                case 5:
                    //obtain the filename of the report need to be generated
                    Console.Write("Enter a name for the file to be saved : ");
                    string fName = Console.ReadLine();
                    //create the generateReport method
                    generateReport(fName);
                    adminMenu();
                    break;
                case 6:
                    //call the customer menu
                    customerMenu();
                    break;
                case 7:
                    //break condition to break from the system
                    break;
                default:
                    //call the method adminMenu
                    adminMenu();
                    break;

            }
        }
        //method to add a vehicle to a the vehicle repository if that vehicle doesn't exist in the repository
        public bool addVehicle(Vehicle V)
        {
            //first check whether the vehicle is available in the repository
            bool noRepeat = true;
            //itterate through each registration number in vehicle repository
            foreach (string keyValue in VehicleRepo.Keys)
            {
                //if condition to detect the availability of the vehicle registration number in the vehicle repository
                if (keyValue.Equals(V.getRegistrationNumber()))
                {
                    noRepeat = false;
                }
            }
            //if condition checks whether the number of vehicles are less than 50 and the same vehicle is not repeated
            if (VehicleRepo.Count <= 50 && noRepeat)
            {
                //add the vehicle tothe vehicle repository
                VehicleRepo.Add(V.getRegistrationNumber(), V);

                Console.WriteLine("Successfully added a vehicle");
                Console.WriteLine("available parking lots : " + (50 - VehicleRepo.Count));
                return true;
            }
            //else if condition if the registration number is repeated
            else if(!noRepeat) 
            {
                Console.WriteLine("Registration number has been repeated");
                return false;
            }
            //else condition that the vehicle limit has been exceeded
            else
            {
                Console.WriteLine("Vehicle limit has been exceeded ");
                return false;
            }
            // returns true if the vehicle was added successfully. else returns false

        }
        //Method to delete the vehicle when vehical registration number is provided
        public bool deleteVehicle(string RegistrationNumber)
        {
            bool status = false;
            //itterate through each vehicle registration number in the vehicle repository 
            foreach (string keyValue in VehicleRepo.Keys)
            {
                //if condition to obtain the senario vehicle registration numbers matches
                if (keyValue.Equals(RegistrationNumber))
                {
                    //remove the vehicle from the vehicle repository
                    VehicleRepo.Remove(keyValue);
                    Console.WriteLine("The Vehicle of registration No : " + RegistrationNumber + " has been deleted");
                    status = true;
                    break;
                }
            }
            // if condition to print if the vehicle is not in the vehicle repository
            if (!status) { Console.WriteLine("No vehicle with that registration number"); }
            
            return status;
        }
        
        //Print the list of vehicles in the vehicle repository with there booking shedules
        public void listVehicles()
        {
            //print the headings of the list
            bool test;
            string vehic;
            Console.WriteLine("Registration Number\tType\t\tPickUp\t\t\t\tDrop Off");
            

            //itterate through the vehicle repository to obtain the each registration number
            foreach (string keyValue in VehicleRepo.Keys)
            {
                test = true;
                //itterate through booking repository to check are there any bookings 
                //recognize the type of the vehicle
                if (VehicleRepo[keyValue].GetType() == typeof(Cars)){vehic = "Car\t"; }
                else if(VehicleRepo[keyValue].GetType() == typeof(Van)){ vehic = "Van\t"; }
                else if (VehicleRepo[keyValue].GetType() == typeof(MotorBikes)) { vehic = "Motor Bike"; }
                else { vehic = "Electric Car"; }

                //itterate through booking repository to obtain each booking
                foreach (Booking book in bookingRepo)
                {
                    //if conditions to capture the situations of identical registration numbers 
                    if (keyValue.Equals(book.getVehicle().getRegistrationNumber()))
                    {
                        //print the details of the vehicle
                        Console.Write(book.getVehicle().getRegistrationNumber() + "\t\t\t" + vehic+ "\t");
                        Console.WriteLine(book.getSchedule().getPickUp() + "\t"+ book.getSchedule().getDropOff());
                        
                        test = false;
                    }
                }
                if (test)
                {
                    //print the details of the vehicle
                    Console.WriteLine(VehicleRepo[keyValue].getRegistrationNumber() + "\t\t\t" + vehic + " \tNULL\t\t\t\tNULL");
                    
                }
            }
        }
        //list the vehicles ordered and sort alphabatically according to the make
        public void listVehiclesOrdered()
        {
            string vehic;
            //sort the booking repository alphabatically according to the make
            bookingRepo.Sort();

            Console.WriteLine("Registration Number\tType\t\tPickUp\t\t\t\tDrop Off");
            //itterate through each booking in the booking repository
            foreach (Booking MarkValue in bookingRepo)
            {
                //recognize the type of the vehicle
                if (MarkValue.getVehicle().GetType() == typeof(Cars)) { vehic = "Car\t"; }
                else if (MarkValue.getVehicle().GetType() == typeof(Van)) { vehic = "Van\t"; }
                else if (MarkValue.getVehicle().GetType() == typeof(MotorBikes)) { vehic = "Motor Bike"; }
                else { vehic = "Electric Car"; }


                //print the details of the vehicle
                Console.Write(MarkValue.getVehicle().getRegistrationNumber() + "\t\t\t" + vehic + "\t");
                Console.WriteLine(MarkValue.getSchedule().getPickUp() + "\t" + MarkValue.getSchedule().getDropOff());
            }

        }
        //save all the details of the vehicles in the vehicle repository in a text file
        public void generateReport(string filename)
        {
            string fileName = filename + (".txt");
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            
            bool test;
            string vehic;
            //print the headings of the list
            streamWriter.WriteLine("Registration Number\tType\t\tmake\t\tmodel\t\tPickUp\t\t\t\tDrop Off");
            
            //itterate through the vehicle repository to obtain the each registration number
            foreach (string keyValue in VehicleRepo.Keys)
            {
                test = true;
                //itterate through booking repository to check are there any bookings 
                //recognize the type of the vehicle
                if (VehicleRepo[keyValue].GetType() == typeof(Cars)) { vehic = "Car\t"; }
                else if (VehicleRepo[keyValue].GetType() == typeof(Van)) { vehic = "Van\t"; }
                else if (VehicleRepo[keyValue].GetType() == typeof(MotorBikes)) { vehic = "Motor Bike"; }
                else { vehic = "Electric Car"; }

                //itterate through booking repository to obtain each booking
                foreach (Booking book in bookingRepo)
                {
                    //if conditions to capture the situations of identical registration numbers 
                    if (keyValue.Equals(book.getVehicle().getRegistrationNumber()))
                    {
                        //print the details of the vehicle
                        streamWriter.Write(book.getVehicle().getRegistrationNumber() + "\t\t\t" + vehic + "\t");
                        streamWriter.Write(book.getVehicle().getMake() + "\t" + book.getVehicle().getModel() + "\t");
                        streamWriter.WriteLine(book.getSchedule().getPickUp() + "\t" + book.getSchedule().getDropOff());
                        test = false;
                    }
                }
                if (test)
                {
                    //print the details of the vehicle
                    streamWriter.Write(VehicleRepo[keyValue].getRegistrationNumber() + "\t\t\t" + vehic+ "\t");
                    streamWriter.Write(VehicleRepo[keyValue].getMake() + "\t" + VehicleRepo[keyValue].getModel() + "\t");
                    streamWriter.WriteLine("NULL\t\t\t\tNULL");
                }
            }
            //create the file
            streamWriter.Close();
            fileStream.Close();
            //streamWriter.Dispose();
        }
        //Method to list a specific type of available vehicles in a given scheduled 
        public void listAvailableVehicles(Schedule wantedSchedule, VehicleType type)
        {
            //clear the items of the list vehicleAvailableList before adding new data to the list 
            vehicleAvailableList.Clear();
            //if condition to check whether the user request a car
            if (type.Equals(VehicleType.Cars))
            {
                Console.WriteLine("************************Cars*******************************");
                //itterate through each vehicle object in the vehicle repository
                 foreach (Vehicle Value in VehicleRepo.Values)
                 {
                    //Check whether the vehicle object is obtained from the car class
                    if (Value.GetType() == typeof(Cars))
                    {
                        //if condition to check the car object availability on the given shedule
                        if (!rentVehicle(Value.getRegistrationNumber(), wantedSchedule))
                        {
                            //print and add infommation to the list
                            Value.printInfo();
                            vehicleAvailableList.Add(Value);
                        }
                    }
                 }
              
            }
            //elseif condition to check whether the user request a van
            else if (type.Equals(VehicleType.Vans))
            {
                Console.WriteLine("************************Vans*******************************");
                //itterate through each vehicle object in the vehicle repository
                foreach (Vehicle Value in VehicleRepo.Values)
                {
                    //Check whether the vehicle object is obtained from the Van class
                    if (Value.GetType() == typeof(Van))
                    {
                        //if condition to check the van object availability on the given shedule
                        if (!rentVehicle(Value.getRegistrationNumber(), wantedSchedule))
                        {
                            //print and add infommation to the list
                            Value.printInfo();
                            vehicleAvailableList.Add(Value);
                        }
                    }
                }
            }
            //elseif condition to check whether the user request a MotorBike
            else if (type.Equals(VehicleType.MotorBikes))
            {
                Console.WriteLine("************************MotorBikes*******************************");
                //itterate through each vehicle object in the vehicle repository
                foreach (Vehicle Value in VehicleRepo.Values)
                {
                    //Check whether the vehicle object is obtained from the MotorBikes class
                    if (Value.GetType() == typeof(MotorBikes))
                    {
                        //if condition to check the MotorBikes object availability on the given shedule
                        if (!rentVehicle(Value.getRegistrationNumber(), wantedSchedule))
                        {
                            //print and add infommation to the list
                            Value.printInfo();
                            vehicleAvailableList.Add(Value);
                        }
                    }
                }

            }
            //elseif condition to check whether the user request a Electric Car
            else if (type.Equals(VehicleType.ElectricCars))
            {
                Console.WriteLine("************************MotorBikes*******************************");
                //itterate through each vehicle object in the vehicle repository
                foreach (Vehicle Value in VehicleRepo.Values)
                {
                    //Check whether the vehicle object is obtained from the ElectricCars class
                    if (Value.GetType() == typeof(ElectricCars))
                    {
                        //if condition to check the ElectricCars object availability on the given shedule
                        if (!rentVehicle(Value.getRegistrationNumber(), wantedSchedule))
                        {
                            //print and add infommation to the list
                            Value.printInfo();
                            vehicleAvailableList.Add(Value);
                        }
                    }
                }

            }
        }
        //method to rent a vehicle when the registration number and the schedule was mentioned
        public bool rentVehicle(string RegistrationNumber, Schedule wantedSchedule)
        {
            bool status = false;
            //itterate through each booking 
            foreach (Booking markValue in bookingRepo)
            {
                if (((markValue.getVehicle()).getRegistrationNumber()).Equals(RegistrationNumber))
                {
                    //This if condition is specifically has defined to overcome unnecessary iterations after detecting the overlap of time
                    if (markValue.getSchedule().Overlaps(wantedSchedule))
                    {
                        status = markValue.getSchedule().Overlaps(wantedSchedule);
                        break;
                    }  
                }

            }
            //return true if two shedules overlaps , return i false if the shedules are not overlapping
            return status;
        }
    }   
} 

