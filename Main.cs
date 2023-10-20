using System;

class Program
{
  public static void Main(string[] args)
  {
    StartCalc();
    Operation x = new Operation();
  } 

  public static void StartCalc()
  { 
    Console.Write("\nEquation:");
    
    while (calculator.GetInput() != "exit")
    {      
      print("Result: " + calculator.Evaluate());
      Console.WriteLine("------------");
      Console.Write("\nEquation: ");
    }
  }

  public static void print(string input) => Console.WriteLine(input);
  public static void print2(Operation input) => Console.WriteLine(input);
  public static void print3() => Console.WriteLine("This is a void check");
}