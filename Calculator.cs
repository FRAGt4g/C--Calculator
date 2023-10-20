using System;

public class Calculator {
  private string equation;
  public string GetEquation() => equation;

  //Initializer
  public Calculator(string input = "") => equation = input;
  

  public string Evaluate()
  {
    //Go through string and make equations out of it
      //Delete string that has already been converted
    //Solve highest ranked equations first
    Simplify(out equation);
    
    return equation;
  }

  public bool HasNextOperation(out int index, out Operation operation) {
    for (int i = 0; i < equation.Length; i++) {
      //if (equation[i].isNumber()) continue;

      foreach (Operation op in Operation.operations) {
        if (equation.Substring(i, ((string)op).Length) == op) {
          index = i;
          operation = op;
          return true;
        }
      }
    }

    index = -1;
    operation = null;
    return false;
  }

  void Simplify(out string input) {
    input = input.Replace(" ", "");

    //Stabalizing Subtraction
    char lastC = '\0';
    for (int i = 0; i < input.Length; i++) {
      if (input[i] == '-') {
        if (lastC < '9' && lastC > '0')
          input = input.Substring(0, i) + "~" + input.Substring(i + 1);
      }
      lastC = input[i];
    }
  }

  public string GetInput() {
    equation = Console.ReadLine();
    return equation;
  }

  public double ToNumLeft(int input) => Convert.ToDouble(equation.Substring(0, input));
  public double ToNumRight(int input) => Convert.ToDouble(equation.Substring(input));
}