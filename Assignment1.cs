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
        /// 


        public static int IntegerAbfragen(int Minimum, int Maximum)
        {
            ConsoleKeyInfo key;
            string currentNumberText = "";
            int pressedNumber = 1;
            int possibleNumber = 1;
            int Number = 1;

            do
            {
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        bool validKey = Int32.TryParse(key.KeyChar.ToString(), out pressedNumber);
                        if (validKey)
                        {
                            Int32.TryParse(Number.ToString() + key.KeyChar.ToString(), out possibleNumber);      

                            if (!(currentNumberText.Length == 0 && pressedNumber == 0) && currentNumberText.Length < Maximum.ToString().Length && possibleNumber <= Maximum)       // inverse the bool
                            {
                                currentNumberText += key.KeyChar;        // Hänge das mit der Taste verbundene Zeichen an
                                Console.Write(key.KeyChar);
                            }
                        }
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && currentNumberText.Length > 0)
                        {
                            currentNumberText = currentNumberText.Substring(0, (currentNumberText.Length - 1));        // verkürze string
                            Console.Write("\b \b");     // \b is a backslash
                        }
                    }
                    Int32.TryParse(currentNumberText, out Number);
                }
                while (Number <= Minimum - 1);
            }
            while (key.Key != ConsoleKey.Enter);
            return Number;
        }
        
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
            
            ConsoleKeyInfo key;

            int numberOfCustomers = 1;
            
            // ----------------------------- Traveling alone or in a group? ----------------------------- 

            Console.WriteLine(String.Format("Are you traveling alone or in a group?\n -1: Alone\n -2: Group\n"));
            do
            {
                key = Console.ReadKey(true);
            }
            while (key.KeyChar != '1' && key.KeyChar != '2');

            Console.WriteLine(key.KeyChar);

            // ----------------------------- Number of people, if in a group ----------------------------- 

            if (key.KeyChar == '2')
            {
                Console.WriteLine(String.Format("\nEnter the number of people (Minimum 2, Maximum 100).\n Varify your choice by pressing 'Enter'\n"));
                numberOfCustomers = IntegerAbfragen(2, 100);
                Console.WriteLine();
            }

            // ----------------------------- Collect the data for each traveler -----------------------------
            
            Person[] Customers = new Person[numberOfCustomers];


            for (int i = 0; i <numberOfCustomers; i++)
            {
                Console.WriteLine(String.Format("\nPerson " + (i+1).ToString()));

                // Rings:
                
                Console.WriteLine(String.Format("\nEnter the number of the lower ring (Minimum 1, Maximum 13).\n Varify your choice by pressing 'Enter'\n"));
                int lowerRing = IntegerAbfragen(1, 16);
                Console.WriteLine(String.Format("\n\nEnter the number of the upper ring (Minimum {0}, Maximum 13).\n Varify your choice by pressing 'Enter'\n", lowerRing));
                int upperRing = IntegerAbfragen(lowerRing, 16);
                
                // Ticket type wanted:
                Console.WriteLine(String.Format("\n\nChoose the ticket type by entering the number of the following options:\n -1: Single Fare\n -2: Weekly Ticket\n -3: Monthly Ticket\n"));

                do
                {
                    key = Console.ReadKey(true);
                }
                while (key.KeyChar != '1' && key.KeyChar != '2' && key.KeyChar != '3');

                Console.WriteLine(key.KeyChar);

                TicketType ticketType = TicketType.SingleFare;
                switch (key.KeyChar)
                {
                    case '1':
                        ticketType = TicketType.SingleFare; 
                        break;
                    case '2':
                        ticketType = TicketType.WeeklyTicket;
                        break;
                    case '3':
                        ticketType = TicketType.MonthlyTicket;
                        break;
                }

                // Student or not?

                Console.WriteLine(String.Format("\nIs this person a student?\n -1: Yes\n -2: No\n"));

                do
                {
                    key = Console.ReadKey(true);
                }
                while (key.KeyChar != '1' && key.KeyChar != '2');

                Console.WriteLine(key.KeyChar);
                
                bool isStudent = false;
                
                if (key.KeyChar == '1')
                {
                    isStudent = true;
                }
                
                // Erstelle Array

                Customers[i] = MvvPriceCalculcator.CreateCustomer(ticketType, lowerRing, upperRing, isStudent);
            }

            // Compute with your Array
            
            PersonalPrice = MvvPriceCalculcator.PersonalPrice(Customers);

            //----------------------------------------------------

            Console.WriteLine(String.Format("\n###################################################\n" +
                                              "###      Your personal price is: {0:C}  \t###\n" +
                                              "###################################################\n", PersonalPrice));
            Console.ReadLine();
        }
    } 
}