using System;
using System.Windows.Forms;

abstract class Shape
{
    public abstract double GetArea();
    public abstract double GetPerimeter();
    public abstract string GetName();

    public void PrintInfo()
    {
        Console.WriteLine($"Название: {GetName()}");
        Console.WriteLine($"Периметр: {GetPerimeter():F2}");
        Console.WriteLine($"Площадь: {GetArea():F2}");
    }
}

class Round : Shape
{
    public double Radius { get; private set; }

    public Round(double radius)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public override string GetName()
    {
        return "Круг";
    }
}

class Square : Shape
{
    public double Side { get; private set; }

    public Square(double side)
    {
        Side = side;
    }

    public override double GetArea()
    {
        return Side * Side;
    }

    public override double GetPerimeter()
    {
        return 4 * Side;
    }

    public override string GetName()
    {
        return "Квадрат";
    }
}

class Triangle : Shape
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

    public override double GetArea()
    {
        double p = (A + B + C) / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

    public override double GetPerimeter()
    {
        return A + B + C;
    }

    public override string GetName()
    {
        return "Треугольник";
    }
}


class Program
{
    static void Main()
    {
        Shape[] rounds = new Shape[5];
        Shape[] squares = new Shape[5];
        Shape[] triangles = new Shape[5];

        rounds[0] = new Round(3);
        rounds[1] = new Round(4);
        rounds[2] = new Round(5);
        rounds[3] = new Round(2);
        rounds[4] = new Round(6);

        squares[0] = new Square(3);
        squares[1] = new Square(4);
        squares[2] = new Square(5);
        squares[3] = new Square(2);
        squares[4] = new Square(6);

        triangles[0] = new Triangle(new double[] { 3, 4, 5 });
        triangles[1] = new Triangle(new double[] { 5, 5, 5 });
        triangles[2] = new Triangle(new double[] { 6, 8, 10 });
        triangles[3] = new Triangle(new double[] { 7, 7, 10 });
        triangles[4] = new Triangle(new double[] { 2, 2, 3 });

        SortShapesByAreaDescending(rounds);
        SortShapesByAreaDescending(squares);
        SortShapesByAreaDescending(triangles);

        Console.WriteLine("Круги:");
        PrintShapes(rounds);

        Console.WriteLine("Квадраты:");
        PrintShapes(squares);

        Console.WriteLine("Треугольники:");
        PrintShapes(triangles);

        Shape[] allShapes = CombineArrays(rounds, squares, triangles);

        SortShapesByAreaDescending(allShapes);

        Console.WriteLine("Все фигуры:");
        PrintShapes(allShapes);
    }


    static void SortShapesByAreaDescending(Shape[] shapes)
    {
        for (int i = 0; i < shapes.Length - 1; i++)
        {
            for (int j = 0; j < shapes.Length - i - 1; j++)
            {
                if (shapes[j].GetArea() < shapes[j + 1].GetArea())
                {
                    Shape temp = shapes[j];
                    shapes[j] = shapes[j + 1];
                    shapes[j + 1] = temp;
                }
            }
        }
    }

    static Shape[] CombineArrays(params Shape[][] arrays)
    {
        int totalLength = 0;
        foreach (var array in arrays)
        {
            totalLength += array.Length;
        }

        Shape[] result = new Shape[totalLength];
        int currentIndex = 0;

        foreach (var array in arrays)
        {
            foreach (var shape in array)
            {
                result[currentIndex] = shape;
                currentIndex++;
            }
        }

        return result;
    }

    static void PrintShapes(Shape[] shapes)
    {
        Console.WriteLine($"{"Название",-15} {"Периметр",-15} {"Площадь",-15}");
        Console.WriteLine(new string('-', 45));
        foreach (var shape in shapes)
        {
            string name = shape.GetName();
            string perimeter = $"{shape.GetPerimeter():F2}";
            string area = $"{shape.GetArea():F2}";
            Console.WriteLine($"{name,-15} {perimeter,-15} {area,-15}");
        }
        Console.WriteLine();
    }
}