public class Operation {

  public delegate Number Solve_del(params Number[] args); 

  private Solve_del solveFunc;

  private static Solve_del Add = (Number[] args) => args[0] + args[1];
  private static Solve_del Subtract = (Number[] args) => args[0] - args[1];
  private static Solve_del Multiply = (Number[] args) => args[0] * args[1];
  private static Solve_del Divide = (Number[] args) => args[0] / args[1];
  private static Solve_del Sumorial = (Number[] args) => (args[0]*args[0] + args[0])/2;
  private static Solve_del Factorial = (Number[] args) => {
    float sum = 1;
    for (int i = 2; i <= args[0]; i++) {
      sum *= i;
    }

    return sum;
  };

  private static Solve_del Average = (Number[] args) => {
    float sum = 0, count = 0;
    foreach (float i in args) {
      sum += i;
      count++;
    }
    return sum/count;
  };

  public string identifier {get; private set;}
  public int importance {get; private set;}
  public int argCount {get; private set;}
  public bool isFunction {get; private set;}

  public static Operation add = new Operation("+", 0, Add);
  public static Operation subtract = new Operation("~", 0, Subtract);
  public static Operation multiply = new Operation("*", 1, Multiply);
  public static Operation divide = new Operation("/", 1, Divide);
  public static Operation factorial = new Operation("!", 2, Factorial);
  public static Operation sumorial = new Operation("?", 2, Sumorial);
  public static Operation average = new Operation("avg", -1, Average, -1, true);
  public static Operation[] operations = new Operation[] {
    add, 
    subtract, 
    multiply,
    divide,
    factorial,
    sumorial,
    average,
  };

  public Operation(string identifier, int importance, Solve_del func, int argCount = 2, bool isFunction = false) {
    this.identifier = identifier;
    this.importance = importance;
    this.argCount = argCount;
    this.isFunction = isFunction;
    this.solveFunc = func;
  }

  public float Solve(params Number[] args) => solveFunc(args);
  public float SolveArr(Number[] args) => solveFunc(args);

  public static implicit operator string(Operation op) => op.identifier;
}