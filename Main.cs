using System;

class Program
{
  public static void Main(string[] args)
  {
    Console.WriteLine("Welcome to my calculator!\n");
    StartCalc();
  } 

  public static void StartCalc()
  {
    Calculator calculator = new Calculator();
    Equation a = new Equation(5, "a");
    Equation b = new Equation(Operation.add, "b", a, 30.1f);
    Equation c = new Equation(Operation.subtract, "c", b, 30.1f);
    Equation d = new Equation(Operation.factorial, "d", 5);
    Equation e = new Equation(Operation.average, "e", c, d, 12);
    Equation f = new Equation(Operation.sumorial, "f", e);
    Console.WriteLine(f.id + ": " + f.SolveAll() + "\n============================\n");
    
    Console.Write("\nEquation:");
    
    while (calculator.GetInput() != "exit")
    {      
      print("Result: " + calculator.Evaluate());
      Console.WriteLine("------------");
      Console.Write("\nEquation: ");
    }
  }

  public static void print(string input) => Console.WriteLine(input);
}