using System.Text.Json;

public class Fraction
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public Fraction(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public void Simplify()
    {
        int gcd = GCD(Numerator, Denominator);
        Numerator /= gcd;
        Denominator /= gcd;
    }

    public Fraction Add(Fraction other)
    {
        int resultNumerator = Numerator * other.Denominator + other.Numerator * Denominator;
        int resultDenominator = Denominator * other.Denominator;
        return new Fraction(resultNumerator, resultDenominator);
    }

    public Fraction Subtract(Fraction other)
    {
        int resultNumerator = Numerator * other.Denominator - other.Numerator * Denominator;
        int resultDenominator = Denominator * other.Denominator;
        return new Fraction(resultNumerator, resultDenominator);
    }

    public Fraction Multiply(Fraction other)
    {
        int resultNumerator = Numerator * other.Numerator;
        int resultDenominator = Denominator * other.Denominator;
        return new Fraction(resultNumerator, resultDenominator);
    }

    public Fraction Divide(Fraction other)
    {
        int resultNumerator = Numerator * other.Denominator;
        int resultDenominator = Denominator * other.Numerator;
        return new Fraction(resultNumerator, resultDenominator);
    }

    public bool IsEqual(Fraction other)
    {
        Simplify();
        other.Simplify();
        return Numerator == other.Numerator && Denominator == other.Denominator;
    }

    public bool IsProper()
    {
        return Math.Abs(Numerator) < Denominator;
    }

    private int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }

    public void SerializeToJson(string filePath)
    {
        string json = JsonSerializer.Serialize(this);
        File.WriteAllText(filePath, json);
    }

    public static Fraction DeserializeFromJson(string filePath)
    {
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Fraction>(json);
    }
}