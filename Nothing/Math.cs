using System;
using Microsoft.Xna.Framework;

namespace Nothing
{
    public class Math
    {
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