using System;

public class Point
{
    public double X { get; private set; }
    public double Y { get; private set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Унарные операторы (инкремент/декремент)
    public static Point operator ++(Point p)
    {
        p.X += 1;
        return p;
    }

    public static Point operator --(Point p)
    {
        p.X -= 1;
        return p;
    }

    // Бинарные операторы (сложение и вычитание)
    public static Point operator +(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y);
    }

    public static Point operator -(Point a, Point b)
    {
        return new Point(a.X - b.X, a.Y - b.Y);
    }

    // Сложение точки с числом (сдвиг по X)
    public static Point operator +(Point p, double value)
    {
        return new Point(p.X + value, p.Y);
    }

    // Вычитание числа из точки (сдвиг по X)
    public static Point operator -(Point p, double value)
    {
        return new Point(p.X - value, p.Y);
    }

    // Расстояние между точками (можно оставить как метод, а не оператор)
    public double DistanceTo(Point other)
    {
        double dx = X - other.X;
        double dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    // Приведение типов
    public static explicit operator int(Point p) => (int)p.X;
    public static implicit operator double(Point p) => p.Y;

    public override string ToString()
    {
        return $"({X}; {Y})";
    }
}
