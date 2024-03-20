using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json; 

namespace FractionCalculator
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // Приклад використання
            Fraction fraction1 = new Fraction(2, 3);
            Fraction fraction2 = new Fraction(3, 4);

            Fraction sum = fraction1.Add(fraction2);
            Fraction difference = fraction1.Subtract(fraction2);
            Fraction product = fraction1.Multiply(fraction2);
            Fraction quotient = fraction1.Divide(fraction2);
            bool isEqual = fraction1.IsEqual(fraction2);
            bool isProper = fraction1.IsProper();

            Console.WriteLine("сума: " + sum.Numerator + "/" + sum.Denominator);
            Console.WriteLine("Різниця: " + difference.Numerator + "/" + difference.Denominator);
            Console.WriteLine("Добуток: " + product.Numerator + "/" + product.Denominator);
            Console.WriteLine("Частка: " + quotient.Numerator + "/" + quotient.Denominator);
            Console.WriteLine("чи рівні дроби?  " + isEqual);
            Console.WriteLine("Чи правильний дріб? " + isProper);

            // Серіалізація та десеріалізація
            fraction1.SerializeToJson("fraction.json");
            Fraction deserializedFraction = Fraction.DeserializeFromJson("fraction.json");
            Console.WriteLine("Десеріалізований дріб: " + deserializedFraction.Numerator + "/" + deserializedFraction.Denominator);
        }
    }
}
