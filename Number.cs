public struct Number {
  public float value;
  public string variable;
  public float exponent;

  public Number(string input, string variable="", float exponent = 1) {
    if (!float.TryParse(input, out value)) {
      value = float.NaN;
    }
    this.variable = variable; 
    this.exponent = exponent;
  }

  public Number(float input, string variable="", float exponent = 1) {
    value = input;
    this.variable = variable;
    this.exponent = exponent;
  }

  public static Number operator +(Number a, Number b) {
    return a.value + b.value;
  }

  public static implicit operator Number(string input) => new Number(input);
  public static implicit operator Number(float input) => new Number(input);
  public static implicit operator float(Number input) => input.value;
}