using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2
{
    public class Program  // this program has one class only
    {
        // Global variables defined
        // Action Matrix defined

            public static string[,] Action_Matrix = new string [12,6]{ {"S5", "1N", "1N", "S4", "1N", "1N"},   
                                                        {"1N", "S6", "1N", "1N", "1N", "*ACCEPT"},
                                                        {"1N", "R2", "S7", "1N", "R2", "R2"},
                                                        {"1N", "R4", "R4", "1N", "R4", "R4"},
                                                        {"S5", "1N", "1N", "S4", "1N", "1N"},
                                                        {"1N", "R6", "R6", "1N", "R6", "R6"},
                                                        {"S5", "1N", "1N", "S4", "1N", "1N"},
                                                        {"S5", "1N", "1N", "S4", "1N", "1N"},
                                                        {"1N", "S6", "1N", "1N", "S11", "1N"},
                                                        {"1N", "R1", "S7", "1N", "R1", "R1"},
                                                        {"1N", "R3", "R3", "1N", "R3", "R3"},
                                                        {"1N", "R5", "R5", "1N", "R5", "R5"} };

           // GoTo Matrix defined                                             

        public static int[,] GoTo_Matrix = new int [12,3]{{1,2,3}, {-1,-1,-1}, {-1,-1,-1},{-1,-1,-1}, {8,2,3}, 
                                              {-1,-1,-1},{-1,9,3},{-1,-1,10},{-1,-1,-1},{-1,-1,-1},
                                              {-1,-1,-1},{-1,-1,-1}};



            //defined a dictionary for the columns of Action Table
        public static Dictionary <string, int> Action_Table_dict = new Dictionary<string, int>()
                                            {
                                                {"id", 0},
                                                {"+", 1},
                                                {"*", 2},
                                                {"(", 3},
                                                {")",4},
                                                {"$",5}
                                            };

            //defined a dictionary for the columns of Action Table
        public static Dictionary <string, int> GoTo_Table_dict = new Dictionary<string, int>()
                                            {
                                                {"E", 0},
                                                {"T", 1},
                                                {"F", 2}
                                            };   


                                                                         


        public static void Main()  // Main Method
        {
            Console.WriteLine("Please enter the string");
            string INPUT = Console.ReadLine(); 
            string Token_String = Lexer(INPUT);  // Token String of the Input

            Console.WriteLine("The token stream of {0} is {1}",INPUT, Token_String);

            List<string> Input_Buffer = Token_String.Split(' ').ToList(); // makes a list from the Token String
            Input_Buffer.Add("$");
            Input_Buffer.RemoveAt(0);   // removes the first entry of Input Buffer list which is a whitespace

            Stack myStack = new Stack(); // initialises the stack
            myStack.Push(0);
            string Stack_string = "0" ;
            Console.WriteLine("The intial Stack is {0}", 0);

           
            
            
            while(Char.IsLetter(Action_Matrix[int.Parse(string.Format("{0}",
                  myStack.Peek())),Action_Table_dict[Input_Buffer[0]]][0]))  

            // enters the loop if the entry in the action matrix is a digit, S_digit or R_digit 

            //int.Parse(string.Format("{0}",myStack.Peek()))  is the top of the stack which we convert to integer

            // int j = Action_Table_dict[Input_Buffer[0]] is the first entry of the list Input_Buffer
                                                           
            {

                int i = int.Parse(string.Format("{0}",myStack.Peek()));
                int j = Action_Table_dict[Input_Buffer[0]];
               

                if (Action_Matrix[i,j][0] =='S' && Action_Matrix[i,j].Length == 2) // just excluded the case of S11
                {
                    Console.WriteLine(Action_Matrix[i,j]);

                    myStack.Push(Input_Buffer[0]); 
                    // pushes the first entry of Input_Buffer to myStack

                    Stack_string = Stack_string + Input_Buffer[0];

                    Input_Buffer.RemoveAt(0);          // removes the first entry of Input_Buffer

                    myStack.Push(Action_Matrix[i,j][1]); // pushes the number in front of S in the Action_Matrix to stack

                    Stack_string = Stack_string + Action_Matrix[i,j][1];

                    Console.WriteLine("The updated stack is {0}", Stack_string);
                    
                    
                }

                else if (Action_Matrix[i,j] == "S11")  // just included the S11 case separately
                {
                     Console.WriteLine(Action_Matrix[i,j]);
                     myStack.Push(Input_Buffer[0]);     // pushes the first entry of Input_Buffer to myStack
                     Stack_string = Stack_string + Input_Buffer[0];
                     Input_Buffer.RemoveAt(0);          // removes the first entry of Input_Buffer

                     myStack.Push(11);
                     Stack_string = Stack_string + "11";
                     Console.WriteLine("The updated stack is {0}", Stack_string);

                }

               
                

                else if (Action_Matrix[i,j][0] == 'R')
                {
                  Console.WriteLine(Action_Matrix[i,j]);

                  //int Top_stack_entry = int.Parse(string.Format("{0}",myStack.Peek())); // converts the top stack
                                                                                        // into an integer & stores
                                                                                        // it in Top_stack_entry
                  
                 string Removed_entry = myStack.Pop().ToString();  // removes the top entry of stack

                 Stack_string = Stack_string.Remove(Stack_string.Length -Removed_entry.Length); 
                  // remove the last entries of "appropriate" length from Stack_string

                  if (Action_Matrix[i,j][1] == '6')
                  {
                      // replace id with F 
                      myStack.Pop();
                      Stack_string = Stack_string.Remove(Stack_string.Length -2);
                      myStack.Push("F");
                      Stack_string = Stack_string + "F" ;
                  }

                  else if (Action_Matrix[i,j][1] == '5')
                  {
                      // replace (E) with F 
                      
                      while (myStack.Peek().ToString() != "(")
                      {
                         string Removed_entry2 = myStack.Pop().ToString();  // removes the top entry of stack
                         Stack_string = Stack_string.Remove(Stack_string.Length -Removed_entry2.Length); 
                      }

                      myStack.Pop();
                      Stack_string = Stack_string.Remove(Stack_string.Length -1);
                      myStack.Push("F");
                      Stack_string = Stack_string + "F" ;

                  }

                  else if (Action_Matrix[i,j][1] == '4')
                  {
                      // replace F with T
                      myStack.Pop();
                      Stack_string = Stack_string.Remove(Stack_string.Length -1);
                      myStack.Push("T");
                      Stack_string = Stack_string + "T" ;
                  }

                  else if (Action_Matrix[i,j][1] == '3')
                  {
                      // replace T*F with T 

                      while (myStack.Peek().ToString() != "T")
                       {
                           string Removed_entry3 = myStack.Pop().ToString();  // removes the top entry of stack
                           Stack_string = Stack_string.Remove(Stack_string.Length -Removed_entry3.Length); 
                       }

                  }

                  else if (Action_Matrix[i,j][1] == '2')
                  {
                      // replace T with E
                      myStack.Pop();
                      Stack_string = Stack_string.Remove(Stack_string.Length -1);
                      myStack.Push("E");
                      Stack_string = Stack_string + "E" ;
                  }

                  else if (Action_Matrix[i,j][1] == '1')
                  {
                      // replace E+T with E

                      while (myStack.Peek().ToString() != "E")
                      {
                          string Removed_entry4 = myStack.Pop().ToString();  // removes the top entry of stack
                          Stack_string = Stack_string.Remove(Stack_string.Length -Removed_entry4.Length); 
                      }

                      // we don't need to do that extra step here
                  }


                 int Column_GoTo = GoTo_Table_dict[myStack.Peek().ToString()]; 
                 // converts the top of stack to a string first and then uses the GoTo_Table_dict to get an integer
                 
                 object Top_entry = myStack.Peek(); // stores the top before removing it
                 myStack.Pop();         // removes the top, that is, Column_GoTo
                                        // did this to access second top entry

                 int Row_GoTo = int.Parse(string.Format("{0}",myStack.Peek())); 

                 myStack.Push(Top_entry);   // need to restore the stack to original

                 if (GoTo_Matrix[Row_GoTo,Column_GoTo]== -1)
                 {
                     // error
                     Console.WriteLine("There is an error");
                 }

                 else
                 {
                     myStack.Push(GoTo_Matrix[Row_GoTo,Column_GoTo]);

                     Stack_string = Stack_string + GoTo_Matrix[Row_GoTo,Column_GoTo] ;

                     Console.WriteLine("The updated stack is {0}", Stack_string);
                     
                 }




                  
                
                

                
                
                
                
                
                
                }
                
            }  // end of while loop

            if (Action_Matrix[int.Parse(string.Format("{0}",
            myStack.Peek())),Action_Table_dict[Input_Buffer[0]]][0] == '*')
            {

                Console.WriteLine("Accepted");

            }

            else
            {
                Console.WriteLine("Rejected");
            }


            

            
            





           

            
        }








        // A method named Lexer which outputs token string of the input string
        // fix the error 5ahag type



        public static string Lexer(string INPUT_EXPR)  // needs work
       {
        string TOKEN_STREAM = null;
        
        for (int i = 0; i < INPUT_EXPR.Length;)  // starts reading the Input string
        {
          if (Char.IsLetter(INPUT_EXPR[i]))      // enters this IF loop if the character is a letter
          {
              
              while (Char.IsLetter(INPUT_EXPR[i]) || Char.IsDigit(INPUT_EXPR[i])) 
              {
                  i++;
                  if (i>=INPUT_EXPR.Length)   // makes sure that the index i doesn't exceed the array length
                  {
                      break;
                  }

              }
           
           TOKEN_STREAM = TOKEN_STREAM + " " + "id" ; 
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

             if (i < INPUT_EXPR.Length)
             {
              if (Char.IsLetter(INPUT_EXPR[i]))    
              {
                  string message = "Unidentified";
                  return(message);
              }
             }
            
            TOKEN_STREAM = TOKEN_STREAM + " " + "id" ;
          }

          else if (Char.IsWhiteSpace(INPUT_EXPR[i]))
          {
              i++;
          }

          else if (INPUT_EXPR[i] == '+')
          {
              i++;
              TOKEN_STREAM = TOKEN_STREAM + " " + "+" ;
          }

          else if (INPUT_EXPR[i] == '*')
          {
              i++;
              TOKEN_STREAM = TOKEN_STREAM + " " + "*" ;
          }

          else if (INPUT_EXPR[i] == '(')
          {
              i++;
              TOKEN_STREAM = TOKEN_STREAM + " " + "(" ;
          }

          else if (INPUT_EXPR[i] == ')')
          {
              i++;
              TOKEN_STREAM = TOKEN_STREAM + " " + ")" ;
          }


        

          else
          {
              string message = "Unidentified";
              return(message);
            
          }
        } 
  
      return(TOKEN_STREAM);

    }


















    }
}




