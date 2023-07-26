# Chain me

[Codewars URL](https://www.codewars.com/kata/54fb853b2c8785dd5e000957)

## Write a generic function chainer
Write a generic function chainer that takes a starting value, and an array of functions to execute on it (array of symbols for Ruby).

The input for each function is the output of the previous function (except the first function, which takes the starting value as its input). Return the final value after execution is complete.
## Example
```cs
double input = 2;

public static double add(double x) {
  return x + 1;
}

public static double mul(double x) {
   return x * 30;
}
Kata.Chain( input , new[] { (Func<double, double>)add, mul });
//=> returns 90
```