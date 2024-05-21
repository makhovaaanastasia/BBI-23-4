using System;

struct Triangle
{
    public double A { get; private set; }
    public double B { get; private set; }
    public double C { get; private set; }

    public Triangle(double[] sides)
    {
        if (sides.Length != 3)
            throw new ArgumentException("Массив должен содержать ровно 3 элемента.");

        A = sides[0];
        B = sides[1];
        C = sides[2];

        if (!IsValidTriangle())
            throw new ArgumentException("Стороны не могут образовать треугольник.");
    }

    private bool IsValidTriangle()
    {
        return (A + B > C) && (A + C > B) && (B + C > A);
    }

    public string GetTriangleType()
    {
        if (A == B && B == C)
            return "Равносторонний";
        else if (A == B || A == C || B == C)
            return "Равнобедренный";
        else
            return "Разносторонний";
    }

    public double GetArea()
    {
        double p = (A + B + C) / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Стороны: {A}, {B}, {C}");
        Console.WriteLine($"Тип: {GetTriangleType()}");
        Console.WriteLine($"Площадь: {GetArea():F2}");
    }
}

class Program
{
    static void Main()
    {
        Triangle[] triangles = new Triangle[5];
        triangles[0] = new Triangle(new double[] { 3, 4, 5 });
        triangles[1] = new Triangle(new double[] { 5, 5, 5 });
        triangles[2] = new Triangle(new double[] { 6, 8, 10 });
        triangles[3] = new Triangle(new double[] { 7, 7, 10 });
        triangles[4] = new Triangle(new double[] { 2, 2, 3 });

        for (int i = 0; i < triangles.Length - 1; i++)
        {
            for (int j = 0; j < triangles.Length - i - 1; j++)
            {
                if (triangles[j].GetArea() < triangles[j + 1].GetArea())
                {
                    Triangle temp = triangles[j];
                    triangles[j] = triangles[j + 1];
                    triangles[j + 1] = temp;
                }
            }
        }


        Console.WriteLine($"{"Стороны",-20} {"Тип",-15} {"Площадь",-10}");
        Console.WriteLine(new string('-', 45));
        foreach (var triangle in triangles)
        {
            string sides = $"{triangle.A}, {triangle.B}, {triangle.C}";
            string type = triangle.GetTriangleType();
            string area = $"{triangle.GetArea():F1}";
            Console.WriteLine($"{sides,-20} {type,-15} {area,-10}");
        }
    }
}