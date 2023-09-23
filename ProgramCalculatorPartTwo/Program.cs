using ProgramCalculatorPartTwo;

Vector a = new Vector(-1 / Math.Sqrt(2), 0, 1 / Math.Sqrt(2));
Vector b = new Vector(1, 1, 1);
Console.WriteLine(a.IsNormalized());
Console.WriteLine(!b.IsNormalized());