using System;

namespace Assignment_3
{

    public static class Globals   // Globals class containing all the global variables
    {
        public static double Input_number;  // The original decimal number we enter

        public static double Fraction ;    // The fraction of the input number in standard rep

        public static int Exponent ;       // The exponent of the input in standard rep

        public static int Sign ;    

        public static string Bit_rep_exponent_single ;   

        public static string Bit_rep_fraction_single ;

        public static string Bit_rep_exponent_double ;   

        public static string Bit_rep_fraction_double ;


       
    }
    public class Program
    { 

         public static void Main()  // main method

        
        {
            Console.WriteLine("Please enter a decimal number");

            string Input_string = Console.ReadLine();     // reads the input 

            Globals.Input_number = Convert.ToDouble(Input_string);  // converts it into a double

            if (Math.Abs(Globals.Input_number) == 0 )
            {
             Console.WriteLine("Single precision bit format : 0 00000000 00000000000000000000000");

             Console.WriteLine("Double precision bit format : 0 00000000000 0000000000000000000000000000000000000000000000000000");
             return;
            }

            else
            {

            if (Math.Abs(Globals.Input_number) >= 1 )
            {
            Standard_rep_1();
            }

            else if (Math.Abs(Globals.Input_number) < 1 && Math.Abs(Globals.Input_number) > 0 )
            {
            Standard_rep_2();

            }

            }

           

            Console.WriteLine("\n");

            Console.WriteLine("Fraction : {0} \nExponent : {1} \n", Globals.Fraction , Globals.Exponent );

            Sign();

            Bit_rep_exponent_single();

            Bit_rep_fraction_single();

            Console.WriteLine("Single precision bit format : {0} {1} {2}", 
            Globals.Sign, Globals.Bit_rep_exponent_single, Globals.Bit_rep_fraction_single);

            Console.WriteLine("\n");

            Bit_rep_exponent_double();

            Bit_rep_fraction_double();

            Console.WriteLine("Double precision bit format : {0} {1} {2}", 
            Globals.Sign, Globals.Bit_rep_exponent_double, Globals.Bit_rep_fraction_double);

            Console.WriteLine("\n");


            

            

           
            

        }




     // method that converts the input number into standard representation if absolute value is greater than 1

        public static void Standard_rep_1()  

        {
            Globals.Fraction = Globals.Input_number;

            Globals.Exponent = 0 ; 

            while (Math.Abs(Globals.Fraction) >= 2 )
            {
                Globals.Fraction = Globals.Fraction/2 ;
                Globals.Exponent++ ; 

            }

        }

    // end of this Standard_rep_1 method


    // method that converts the input number into standard representation if absolute value is less than 1
        public static void Standard_rep_2()  

        {
            Globals.Fraction = Globals.Input_number;

            Globals.Exponent = 0 ; 

            while (Math.Abs(Globals.Fraction) < 1 )
            {
                Globals.Fraction = Globals.Fraction * 2 ;
                Globals.Exponent-- ; 

            }

        }

    // end of this Standard_rep_2 method




    // method that determines the sign 

    public static void Sign()
    {
        if (Globals.Fraction >= 0 )
        {
            Globals.Sign = 0;
        }

        else 
        {
            Globals.Sign = 1;
        }

     //Console.WriteLine(Globals.Sign);   
    }


    // end of Sign() method


    // method that determines the bit represenatation of exponent single precision

    public static void Bit_rep_exponent_single()
    {
        int Biased_Exponent = Globals.Exponent + 127 ;
        int k = 0;

        while(k < 8)
        {
            k++;

            if (Biased_Exponent % 2 == 0)
            {
                Biased_Exponent = Biased_Exponent/2;
                Globals.Bit_rep_exponent_single = 0 + Globals.Bit_rep_exponent_single;
            }

            else
            {
              Biased_Exponent = Biased_Exponent/2 - 1/2;
              Globals.Bit_rep_exponent_single = 1 + Globals.Bit_rep_exponent_single;   
            }
        }

     //Console.WriteLine(Globals.Bit_rep_exponent_single);   

    }

     //end of Bit_rep_exponent()


     // method that determines the bit representation of the fraction single precision

     public static void Bit_rep_fraction_single()
     {
         double Biased_Fraction = Math.Abs(Globals.Fraction) - 1;  // just take the part of the fraction after decimal
         int i = 0;

         while (i < 23)
         {
             i++;
             Biased_Fraction = Biased_Fraction * 2;

             if (Biased_Fraction < 1)
             {
                 Globals.Bit_rep_fraction_single = Globals.Bit_rep_fraction_single + 0;
             }

             else
             {
                 Biased_Fraction = Biased_Fraction - 1 ;
                 Globals.Bit_rep_fraction_single = Globals.Bit_rep_fraction_single + 1;
             }
         }

         
         //Console.WriteLine(Globals.Bit_rep_fraction_single);




     }



     //end of the method



    // method that determines the bit represenatation of exponent double precision

    public static void Bit_rep_exponent_double()
    {
        int Biased_Exponent = Globals.Exponent + 1023 ;
        int k = 0;

        while(k < 11)
        {
            k++;
            if (Biased_Exponent % 2 == 0)
            {
                Biased_Exponent = Biased_Exponent/2;
                Globals.Bit_rep_exponent_double = 0 + Globals.Bit_rep_exponent_double;
            }

            else
            {
              Biased_Exponent = Biased_Exponent/2 - 1/2;
              Globals.Bit_rep_exponent_double = 1 + Globals.Bit_rep_exponent_double;   
            }
        }

     //Console.WriteLine(Globals.Bit_rep_exponent_double);   

    }

     //end of Bit_rep_exponent_double()



      // method that determines the bit representation of the fraction single precision

     public static void Bit_rep_fraction_double()
     {
         double Biased_Fraction = Math.Abs(Globals.Fraction) - 1;  // just take the part of the fraction after decimal
         int i = 0;

         while (i < 52)
         {
             i++;
             Biased_Fraction = Biased_Fraction * 2;

             if (Biased_Fraction < 1)
             {
                 Globals.Bit_rep_fraction_double = Globals.Bit_rep_fraction_double + 0;
             }

             else
             {
                 Biased_Fraction = Biased_Fraction - 1 ;
                 Globals.Bit_rep_fraction_double = Globals.Bit_rep_fraction_double + 1;
             }
         }

         
        //Console.WriteLine(Globals.Bit_rep_fraction_double);




     }



     //end of the method



    }
}
