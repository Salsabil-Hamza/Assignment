namespace Assignment1 {
    public class MvvPriceCalculcator {
        #pragma warning disable 0414
        private static bool Math = false;
        #pragma warning restore 0414

        /// define variables that will hold the data for the ticket fares. I recommend to use double as datatypes and use arrays if needed. Evaluate the use of static, readonly and const!
        /// The values are provided inside the MvvFareData.txt file. For quick parsing, you can copy & paste the data and replace wrong characters with the replace function (VS: ctrl + H). 
        /// To get rid of unnecessary lines, you can use the regex statement \s+ . While doing this, make sure to enable the regex support (VS: 3rd box in the replace dialog).
        //----------------------------------------------------
        // TODO: write  your variables here
        //----------------------------------------------------      

        /// <summary>
        /// This function will create a customer. Use your own customer classes.
        /// </summary>
        /// <param name="ticketType"></param>
        /// <param name="lowerRing"></param>
        /// <param name="upperRing"></param>
        /// <param name="isStudent"></param>
        /// <returns></returns>
        public static Person CreateCustomer(TicketType ticketType, int lowerRing, int upperRing, bool isStudent) {
            //----------------------------------------------------
            // TODO: write your code here
            //----------------------------------------------------
        }

        /// <summary>
        /// This methods calculates the customers personal price. You are not allowed to change the function signature. I recommend to use a switch statement to differ the cases. 
        /// Please note that handeling the single fares may be a little bit more complicate than relying on the ring definition. They will be priced by the ZONE your crossing on your journey.
        /// A zone in munich consists of 4 rings. Zone 1: 1-4, Zone 2: 5-8, Zone 3: 9-12, Zone 4: 13-16. 
        /// Example: (1) traveling ring 3 -> 4 will cost 1 x the price, traveling from ring 4 -> 5 will cost 2 x the price (since it will pass 2 zones).     
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns>The price of your fantastic journey</returns>
        public static double PersonalPrice(Person Customer) {
            //----------------------------------------------------
            // TODO: write your code here
            //----------------------------------------------------
        }

        /// <summary>
        /// Write a function that handels a group of customers. And return the prize that this particular group needs to pay.
        /// </summary>
        /// <param name="Customers"></param>
        /// <returns></returns>
        public static double PersonalPrice(Person[] Customers) {
            //----------------------------------------------------
            // TODO: write your code here
            //----------------------------------------------------
        }

        /// <summary>
        /// This function calculates the actual discount. The discount is a fixed percentage of the ticket price and will be payed by the land of bavaria. The discounted price will be 3/4 of the orignal price.
        /// The result will be rounded to one digit after the decimal point (xx.x0).          
        /// If you do not know how to start: Remember the propertys of integers while dividing.
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        private static double CalculateDiscount(Person Customer, double fullPrice) {
            //----------------------------------------------------
            // TODO: write your code here
            //----------------------------------------------------
        }

        /// <summary>
        /// This function should calculate the number of rings that needs to be payed and check if you cross any zone borders.  
        /// </summary>
        /// <param name="ringTotal"></param>
        /// <param name="lowerRing"></param>
        /// <param name="upperRing"></param>
        /// <param name="crossesZoneBorder"></param>
        private static void RingsToCross(ref int ringTotal, int lowerRing, int upperRing, out bool crossesZoneBorder) {
            //----------------------------------------------------
            // TODO: write your code here
            //----------------------------------------------------
        }

    }
}