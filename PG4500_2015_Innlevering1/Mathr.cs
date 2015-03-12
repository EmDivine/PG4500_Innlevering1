using System;
using Robocode.Util;

namespace Robot_support_classes
{
	namespace Coordinates
	{
		public class Polar2
		{
			private double _distance;
			private double _angle;

			public double Distance
			{
				get
				{
					return _distance;
				}
				set
				{
					if (value < 0)
					{
						value *= -1;
						Angle += 180;
					}
					_distance = value;
				}
			}

			private double Angle
			{
				get
				{
					return _angle;
				}
				set
				{
					_angle = Utils.NormalRelativeAngleDegrees(value);
				}
			}

			public Polar2(double distance, double angle)
			{
				Angle = angle;
				Distance = distance;
			}

			public static implicit operator Vector2(Polar2 p)
			{
				return new Vector2(Math.Cos(p.Angle), Math.Sin(p.Angle)) * p.Distance;
			}

			public static Polar2 operator +(Polar2 p1, Polar2 p2)
			{
				return (Vector2)p1 + (Vector2)p2;
			}

			public static Polar2 operator +(Polar2 p, Vector2 v)
			{
				return (Vector2)p + v;
			}

			public static Polar2 operator *(Polar2 p, double f)
			{
				return new Polar2(p.Distance * f, p.Angle);
			}

			public static Polar2 operator *(double f, Polar2 p)
			{
				return p * f;
			}
		}

		public class Vector2
		{
			public double X
			{
				get;
				set;
			}
			public double Y
			{
				get;
				set;
			}

			public Vector2(double x, double y)
			{
				X = x;
				Y = y;
			}

			public static implicit operator Polar2(Vector2 v)
			{
				return new Polar2(Math.Sqrt(v.X * v.X + v.Y * v.Y), Math.Atan2(v.Y, v.X));
			}

			public static Vector2 operator *(Vector2 v, double f)
			{
				return new Vector2(v.X * f, v.Y * f);
			}

			public static Vector2 operator *(double f, Vector2 v)
			{
				return v * f;
			}

			public static Vector2 operator +(Vector2 v1, Vector2 v2)
			{
				return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
			}

			public static Vector2 operator +(Vector2 v, Polar2 p)
			{
				return v + (Vector2)p;
			}
		}
	}
}
