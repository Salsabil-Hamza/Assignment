/// This exercise repeats the basics of C#. It is your task to complete the code missing in the functions. 
/// You task will write a function that returns the price of an mvv ticket: http://www.mvv-muenchen.de/en/tickets-fares/fares/index.html
/// For the sake of this exercise it is sufficent to implement the ticket types given in the enum TicketType. The prices are given in the MvvFareData.txt (they are from last year!)
/// 
/// To complete this task take a look at the tasks in Customers.cs & MvvPriceCalculator.cs . There are several functions defined that you HAVE TO use. 
/// Additionally you can define extra functions if you want to.
/// Please note that it is not needed and therefore forbidden to import further librarys (this includes Math!). Be sure to implement all functions given and be as DRY as possible.
/// If you hit a wall do not be shy and ask for help. You can use the moodle forum or come by personally (please schedule a meeting!).
/// 
/// Happy coding!
/// 
using System;

namespace Assignment1 {

    public class ConsoleMVVApplication {

        /// <summary>
        /// This function manages the user input. The programm should ask for (in this order!):
        ///     -> Are you traveling alone or in a group?
        ///     -> if your are traveling in a group how many people are there?
        ///     
        ///     Collect the data for each traveler (only once if you travel alone!):
        ///     -> ring of the original station
        ///     -> ring of the destination
        ///     -> ticket type wanted
        ///     -> if the user is a student 
        ///     
        /// 
        /// You can use Console.WriteLine("") & string str = Console.ReadLine() to write and read data. It should not be possible to break the programm with wrong input.
        /// Also the user should be requestioned if the input was not accepted. To parse a string to int you can use the function: (static bool) int.TryParse(str, out i).
        /// 
        /// </summary>
        static void Main() {
            var PersonalPrice = 0.0;

            // Enables the console to display the € sign
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("" +
                "\n#######################################################" +
                "\n###       Calculate the price of your journey!      ###" +
                "\n#######################################################\n");

            //----------------------------------------------------
            // TODO: write your code here !
            int numberCustomers = 0;
            int numberStudents = 0;
            int numberPersons = 0;
            bool inputPersons = false;
            while (inputPersons == false)
            {
                Console.WriteLine("Are you traveling alone or in a group?[alone/group]");
                string group = Console.ReadLine();
                if (group == "group" || group == "Group" || group == "GROUP")
                {
                    Console.WriteLine("How many people are there?");
                    numberCustomers = int.Parse(Console.ReadLine());
                    inputPersons = true;
                }
                else if (group == "alone" || group == "Alone" || group == "ALONE")
                {
                    numberCustomers = 1;
                    inputPersons = true;
                }
                else
                {
                    Console.WriteLine("I cannot understand you. Please, try again...");
                    inputPersons = false;
                }
            }
            Console.WriteLine("Travelling persons: {0}", numberCustomers);
            Console.WriteLine("Please, input information about travellers.");

            Person[] Customers = new Person[numberCustomers];
            Student[] CustomersS = new Student[numberCustomers];
            for (int i = 0; i < numberCustomers; i++)
            {
                Console.WriteLine("Creating customer: {0}",i+1);

                var newCustomerS = new Student();
                var newCustomer = new Person();
                bool ringLowTrue = false;
                bool _ringLo = false;
                while (ringLowTrue == false)
                {
                        Console.WriteLine("Ring of the original station?");
                        string input = (Console.ReadLine());
                        _ringLo = int.TryParse(input, out int digitTrue);
                        while (_ringLo == false)
                        {
                            Console.WriteLine("This is not a number. Ring of the original station?");
                            input = (Console.ReadLine());
                            _ringLo = int.TryParse(input, out digitTrue);
                        }
                            newCustomer.lowerRing = digitTrue;

                        if (newCustomer.lowerRing > 16 || newCustomer.lowerRing < 1)
                        {
                            Console.WriteLine("You wrote unexisted ring. Try again.");
                            ringLowTrue = false;
                        }
                        else
                        {
                            ringLowTrue = true;
                        }
                    
                }
                bool ringHighTrue = false;
                bool _ringHi = false;
                int ring = 0;
                while (ringHighTrue == false)
                {
                        
                        Console.WriteLine("Ring of the destination?");
                        string input = (Console.ReadLine());
                        _ringHi = int.TryParse(input, out int digitTrue);
                        while (_ringHi == false)
                        {
                            Console.WriteLine("This is not a number. Ring of the destination?");
                            input = (Console.ReadLine());
                            _ringHi = int.TryParse(input, out digitTrue);
                        }
                        ring = digitTrue;
                                       
                    if (ring > 16 || ring < 1)
                    {
                        ringHighTrue = false;
                        Console.WriteLine("You wrote unexisted ring. Try again.");
                    }
                    else
                    {
                        ringHighTrue = true;
                        if (ring < newCustomer.lowerRing)
                        {
                            newCustomer.upperRing = newCustomer.lowerRing;
                            newCustomer.lowerRing = ring;
                        }
                        else 
                        {
                            newCustomer.upperRing = ring;
                        }
                    }
                }
                bool typeTikTrue = false;
                bool ticketT = false;
                while (typeTikTrue == false)
                {
                    Console.WriteLine("Which ticket type you want?(please type the number!)\n 0: SingleFare\n 1: WeeklyTicket\n 2: MonthlyTicket\n");
                    string inputTT = Console.ReadLine();
                    ticketT = int.TryParse(inputTT, out int _ticket);
                    while (ticketT == false)
                    {
                        Console.WriteLine("You put wrong value.\n Which ticket type you want?(please type the number!)\n 0: SingleFare\n 1: WeeklyTicket\n 2: MonthlyTicket\n");
                        inputTT = Console.ReadLine();
                        ticketT = int.TryParse(inputTT, out _ticket);
                    }
                    newCustomer.ticketType = (TicketType)_ticket;
                    if (newCustomer.ticketType == TicketType.SingleFare || newCustomer.ticketType == TicketType.WeeklyTicket || newCustomer.ticketType == TicketType.MonthlyTicket)
                    {
                        typeTikTrue = true;
                    }
                    else
                    {
                        Console.WriteLine("You wrote wrong number. \n Which ticket type you want?(please type the number!)\n 0: SingleFare\n 1: WeeklyTicket\n 2: MonthlyTicket\n");
                        typeTikTrue = false;
                    }
                }

                bool studTrue = false;
                while (studTrue == false)
                {
                    Console.WriteLine("Are you a student? (yes/no)");
                    string studAns = Console.ReadLine();
                    if (studAns == "yes" || studAns == "YES" || studAns == "Yes")
                    {
                        newCustomerS.lowerRing = newCustomer.lowerRing;
 
                        newCustomerS.upperRing = newCustomer.upperRing;

                        newCustomerS.ticketType = newCustomer.ticketType;

                        newCustomerS.isStudent = true;
                        studTrue = true;
                        CustomersS[numberStudents] = newCustomerS;
                        numberStudents++;
                    }
                    else if (studAns == "no" || studAns == "NO" || studAns == "No")
                    {
                        newCustomer.isStudent = false;
                        studTrue = true;
                        Customers[numberPersons] = newCustomer;
                        numberPersons++;
                    }
                    else
                    {
                        Console.WriteLine("I cannot understand you. Please, try again...");
                        studTrue = false;
                    }
                }
            }
            Console.WriteLine("All customers are created. Thank you.");
            double PersonalPriceStu = 0;
            double PersonalPriceCust = 0;

            if (numberStudents != 0)
            {
                for (int j = 0; j < numberStudents; j++)
                {
                    PersonalPriceStu += MvvPriceCalculcator.PersonalPrice(CustomersS[j]);
                }
            }
            if (numberPersons != 0)
            {
                for (int k = 0; k < numberPersons; k++)
                {
                    PersonalPriceCust += MvvPriceCalculcator.PersonalPrice(Customers[k]);
                }
            }
            PersonalPrice = PersonalPriceCust + PersonalPriceStu;
            //----------------------------------------------------

            Console.WriteLine(String.Format("\n###################################################\n" +
                                              "###      Your personal price is: {0:C}  \t###\n" +
                                              "###################################################\n", PersonalPrice));
            Console.ReadLine();
        }
    } 
}