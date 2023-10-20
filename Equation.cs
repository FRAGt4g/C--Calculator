using System;

public class Equation {
  public string id;
  public Equation[] args;

  Operation operation;
  public Number result {get; private set;}

  public Equation(Operation operation, string id = "", params Equation[] equations) {
    args = equations;
    this.operation = operation;
    result = new Number(float.NaN);
    this.id = id;
  }

  public Equation(Operation operation, params Equation[] equations) {
    args = equations;
    this.operation = operation;
    result = new Number(float.NaN);
    this.id = "";
  }

  public Equation(Number number, string id="") {
    result = number;
    operation = null;
    args = null;
    this.id = id;
  }

  public float Solve() {
    Number[] array= new Number[args.Length];
    for (int i = 0; i < args.Length; i++)
      array[i] = args[i];

    result = new Number(operation.SolveArr(array));
    return result;
  }

  public float SolveAll() {
    Console.WriteLine(id + " is solving all");
    Number[] array= new Number[args.Length];
    for (int i = 0; i < args.Length; i++) {
      Console.Write("| " + args[i].id + " equals ");
      Console.WriteLine(args[i].result);
      if (float.IsNaN(args[i].result)) {
        Console.WriteLine("is null");
        array[i] = args[i].SolveAll();
      }

      array[i] = args[i];
    }

    result = new Number(operation.SolveArr(array));
    Console.WriteLine(id + " has been solved and equals: " + result);
    return result;
  }

  public void SetToNumber(Number number) => result = number;
  public void ChangeOperation(Operation operation) => this.operation = operation;
  public void ResetAllArgs(params Equation[] args) => this.args = args;
  public void SetArgAt(int index, Equation arg) => args[index] = arg;

  public static implicit operator float(Equation eq) => eq.result;
  public static implicit operator Equation(float f) => new Equation(f);
  public static implicit operator Number(Equation e) => new Number(e);
}