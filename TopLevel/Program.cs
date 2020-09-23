using System;
using System.Linq;

bool isMultipleOf(int n, int m) => n % m == 0;

var upperBound = int.Parse(args[0]);
var sumOfMultiplesOf3Or5 = Enumerable
    .Range(1, upperBound - 1)
    .Where(n => isMultipleOf(n, 3) || isMultipleOf(n, 5))
    .Sum();

Console.WriteLine($"The sum of all the multiples of 3 or 5 below {upperBound} is {sumOfMultiplesOf3Or5}");