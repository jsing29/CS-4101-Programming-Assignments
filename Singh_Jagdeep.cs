using System;

namespace Assignment_4
{

     public class Program
    {
     static void Main(string[] args)        // Main method
    { 
 
            Employee[] emps = {new Employee("Robert", "John", 6611 ),
                               new Faculty("Sara", "Brown", 2010, "CSC"),
                               new Instructor("Steven", "Hank", 3344, "ECE", 20)}; 
 
 
            foreach (Employee e in emps)
            e.Print();

           
            Console.WriteLine("-----------------------------------------");  
            emps[0].EmployeeNumber = 331;             
            Console.WriteLine(emps[0].EmployeeName + ": " + emps[0].EmployeeID); 
 
        } 

    }



   ///// end of main method 
   /////
   /////
   //////
   //////
   

        

        
 

     public class Employee      // parent class Employee
    {
     private string firstname;
     private string lastname;        // declaration of the private attributes
     private int number;

     private string id;
    





     public Employee(string firstname, string lastname, int number)  // constructor for the class Employee
     {
         this.firstname = firstname;
         this.lastname=lastname;
         this.number= number;
     } 


     public string EmployeeName
     {
        get {return firstname + lastname;}     // gettter for the EmployeeName

                                          
     }


     

     public int EmployeeNumber 
     {
         get {return this.number;} // gettter for the attribute Employeenumber

         set{
             if (value.ToString().Length == 4 )
             {this.number= value;}

            else
            {
            Console.WriteLine("Cannot Change Number. The Employee Number should be exactly 4 digits.");
            } 
             
             
             } 
     }

     


     public string EmployeeID
     {
        get {return firstname[0].ToString().ToLower() + lastname[0].ToString().ToLower() + 
                   lastname[1].ToString() + lastname[2].ToString() + number ;}     

        set{this.id = value;}           
                                          
     }


     public virtual void Print()    // Print method of Employee to be overriden in the subclasses
     {
         Console.WriteLine("-----------------------------------------");
         Console.WriteLine("Employee name : {0} {1}", firstname, lastname);
         Console.WriteLine("Employee ID : {0}", this.EmployeeID);
         Console.WriteLine("-----------------------------------------");

     }



      
    }


    // End of class Employee
    ///
    ////
    /////


   
    public class Faculty : Employee
    {
        private string code;
        
        public Faculty(string firstname, string lastname, int number, string code) :  
                       base(firstname,lastname,number)
                       {this.code = code;}                // constructor for the subclass Faculty
    


    public string Code 
    {
        get {return this.code;}
        set {this.code = value;}

    }

    public override void Print()
    {
        Console.WriteLine("Employee name : {0}", this.EmployeeName);
        Console.WriteLine("Employee name : {0}", this.EmployeeID);
        Console.WriteLine("Department code : {0}", code);
        Console.WriteLine("-----------------------------------------");

    }


    }

    // End of class Faculty
    ////
    /////
    /////
    //////




     public class Instructor : Faculty
    {
        private decimal rate;
        
        public Instructor(string firstname, string lastname, int number, string code, decimal rate) :  
                       base(firstname,lastname,number,code)
                       {this.rate = rate;}                // constructor for the subclass Instructor
    


    public override void Print()
    {
        Console.WriteLine("Employee name : {0}", this.EmployeeName);
        Console.WriteLine("Employee name : {0}", this.EmployeeID);
        Console.WriteLine("Department code : {0}", this.Code);
        Console.WriteLine("Rate : {0} $/hour", rate);

    }


    }

    // End of class Instructor
    ////
    /////
    /////
    //////



    

    









}
