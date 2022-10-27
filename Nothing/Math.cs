using System;
using Microsoft.Xna.Framework;

namespace Nothing
{
    public class Math
    {
        public static Random random = new Random();

        public static float RandFloat()
        {
            return (float)random.NextDouble();
        }
        public static double RandDouble()
        {
            return random.NextDouble();
        }


        public static int Rand()
        {
            return random.Next();
        }

        public static int Rand(int maxValue)
        {
            return random.Next(maxValue);
        }

        public static int Rand(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        public static bool RectsCollide(Rectangle one, Rectangle two)
        {
            return PointInRect(new Point(one.X, one.Y), two) ||
                PointInRect(new Point(one.X+one.Width, one.Y), two) ||
                PointInRect(new Point(one.X, one.Y+one.Height), two) ||
                PointInRect(new Point(one.X, one.Y+one.Height), two);
        }

        public static bool Vector2InRect(Vector2 vector2, Rectangle rect)
        {
            return PointInRect(vector2.ToPoint(), rect);
        }

        public static bool PointInRect(Point point, Rectangle rect)
        {
            return point.X <= rect.X+rect.Width && point.X >= rect.X &&
                point.Y <= rect.Y+rect.Height && point.Y >= rect.Y;
        }
    }
}