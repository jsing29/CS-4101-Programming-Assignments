using System;
//testing
//another testing

namespace Assignment_1_1
{


}

public class Program    // This code has just one class and methods Token_lex, expr , factor, term and lex
{


public static int index=1;     // declaration of global variables
public static string[] TOKEN_ARRAY;



    public static void Main()   // MAIN METHOD
    {
        Console.WriteLine("Please enter the string");
        string INPUT = Console.ReadLine();   
        string TOKEN_STREAM = Token_lex(INPUT);   // TOKEN_STREAM is the string of tokens of your input string
        Console.WriteLine("The token stream of {0} is {1}",INPUT, TOKEN_STREAM);

        /////// 

        TOKEN_ARRAY = TOKEN_STREAM.Split(' '); // TOKEN_ARRAY is the array of the tokens of the input string
        if (TOKEN_STREAM == "Unidentified")    // When the input contains some unidentified character
        {
            Console.WriteLine("Your Input is not valid as it contains characters not allowed.");
        }
         else
        {
        Console.WriteLine("The first Token is {0} \n", TOKEN_ARRAY[1] );   
        expr();
        }

        if (index < TOKEN_ARRAY.Length - 1)
        {
          Console.WriteLine("Error: The Input String can not be derived from the grammar.");
        }

        

      
                
    }

    ///////////
    //////////
    //////////
    //////////
    ////////// another method Token_lex


    public static string Token_lex(string INPUT_EXPR)
    {
        string TOKEN_STREAM = null;


        for (int i = 0; i < INPUT_EXPR.Length;)
        {
          if (Char.IsLetter(INPUT_EXPR[i]))
          {
              
              while (Char.IsLetter(INPUT_EXPR[i]) || Char.IsDigit(INPUT_EXPR[i])) 
              {
                  i++;
                  if (i>=INPUT_EXPR.Length)
                  {
                      break;
                  }

              }
           
           TOKEN_STREAM = TOKEN_STREAM + " " + "IDENT" ; 
          }

          else if (Char.IsDigit(INPUT_EXPR[i]))
          {
             
              while (Char.IsDigit(INPUT_EXPR[i]))
              {
                  i++;
                  if (i>=INPUT_EXPR.Length)
                  {
                      break;
                  }   
              }
            
            TOKEN_STREAM = TOKEN_STREAM + " " + "INT_LIT" ;
          }

          else if (Char.IsWhiteSpace(INPUT_EXPR[i]))
          {
              i++;
          }

          else if (INPUT_EXPR[i] == '+')
          {
              i++;
              TOKEN_STREAM = TOKEN_STREAM + " " + "ADD_OP" ;
          }

          else if (INPUT_EXPR[i] == '-')
          {
              i++;
              TOKEN_STREAM = TOKEN_STREAM + " " + "SUB_OP" ;
          }

          else if (INPUT_EXPR[i] == '/')
          {
              i++;
              TOKEN_STREAM = TOKEN_STREAM + " " + "DIV_OP" ;
          }

          else if (INPUT_EXPR[i] == '*')
          {
              i++;
              TOKEN_STREAM = TOKEN_STREAM + " " + "MUL_OP" ;
          }

          else if (INPUT_EXPR[i] == '(')
          {
              i++;
              TOKEN_STREAM = TOKEN_STREAM + " " + "LEFT_PAREN" ;
          }

          else if (INPUT_EXPR[i] == ')')
          {
              i++;
              TOKEN_STREAM = TOKEN_STREAM + " " + "RIGHT_PAREN" ;
          }


        

          else
          {
              string message = "Unidentified";
              return(message);
            
          }
        } 
  
      return(TOKEN_STREAM);

    }



    ////////////////
    ////////////////
    ///////////////
    ////////////////
    //////////////////
    ///////////////// method lex

    public static void lex()
    {
        if (index < TOKEN_ARRAY.Length - 1)
    {
        index++;
        Console.WriteLine("Next Token is {0}", TOKEN_ARRAY[index]);
        Console.WriteLine("\n");
        
    }   
    }

    




    /////////////
    ////////////
    /////////////
    //////////////
    ///////////// another method expr

     public static void expr()
       {
           Console.WriteLine("Enter <expr> \n ");
           term();

           while (TOKEN_ARRAY[index] == "ADD_OP"|| TOKEN_ARRAY[index]== "SUB_OP")
           {
               lex();
               term();
           }
            Console.WriteLine("Exit <expr> \n ");

       }



       /////////////
    ////////////
    /////////////
    //////////////
    ///////////// another method term


       public static void term()
       {
           Console.WriteLine("Enter <term> \n ");
           factor();

           while (TOKEN_ARRAY[index] == "MUL_OP"|| TOKEN_ARRAY[index]== "DIV_OP")
           {
               lex();
               factor();
           }
            Console.WriteLine("Exit <term> \n ");

       }



       /////////////
    ////////////
    /////////////
    //////////////
    ///////////// another method term




        public static void factor() 
       {
             Console.WriteLine("Enter <factor>\n");

             if (TOKEN_ARRAY[index]== "IDENT" || TOKEN_ARRAY[index] == "INT_LIT") 
             {
                lex(); //Get the next token

             }  

             //If the RHS is (<expr>) , call lex to pass over ‘(’, call expr, and check for ‘)’  

             else 
             {     // start of else
               if(TOKEN_ARRAY[index] == "LEFT_PAREN") 
               { 
                   lex(); 
                   expr();
                 
                  if(TOKEN_ARRAY[index] == "RIGHT_PAREN") 
                   {
                   lex();
                   }
               
               
                    else 
                   {
                   Console.WriteLine("Error: Right Paranthesis missing \n "); 
                    }
               } 

                else 
               {
                   Console.WriteLine("Error: Left Paranthesis missing \n "); 
               }

            }//End of else

             Console.WriteLine("Exit <factor> \n");
        }

        
        
   }

        
  

   












