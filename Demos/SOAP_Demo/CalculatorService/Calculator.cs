using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Calculator : ICalculator

    {
        double ICalculator.Add(double x, double y)
        {
            Console.WriteLine($"In Service ADD => Received {x} and {y}.");
            double z = x + y;
            Console.WriteLine($"{x} + {y} = {z}");
            Console.WriteLine("Returning result.........");
            return z;
        }

        double ICalculator.Divide(double x, double y)
        {
            Console.WriteLine($"In Calculator Service SUBTRACT => Received {x} and {y}.");
            double z = x - y;
            Console.WriteLine($"{x} - {y} = {z}");
            Console.WriteLine("Returning result.........");
            return z;
        }

        double ICalculator.Multiply(double x, double y)
        {
            Console.WriteLine($"In Calcultor Service MULTIPLY => Received {x} and {y}.");
            double z = x * y;
            Console.WriteLine($"{x} * {y} = {z}");
            Console.WriteLine("Returning result.........");
            return z;
        }

        double ICalculator.Subtract(double x, double y)
        {
            Console.WriteLine($"In Caluclutor Service DIVIDE => Received {x} and {y}.");
            double z = x / y;
            Console.WriteLine($"{x} / {y} = {z}");
            Console.WriteLine("Returning result.........");
            return z;
        }
    }
}
