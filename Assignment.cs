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
            //----------------------------------------------------

            Console.WriteLine(String.Format("\n###################################################\n" +
                                              "###      Your personal price is: {0:C}  \t###\n" +
                                              "###################################################\n", PersonalPrice));
            Console.ReadLine();
        }
    } 
}