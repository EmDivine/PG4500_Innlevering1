using System;
using Robocode.Util;

namespace Robot
{
	namespace Coordinates
	{
		public class Polar2
		{
			private double _magnitude;
			private double _angle;

			public double Magnitude
			{
				get
				{
					return _magnitude;
				}
				private set
				{
					if (value < 0)
					{
						value *= -1;
						Angle += 180;
					}
					_magnitude = value;
				}
			}

			public double Angle
			{
				get
				{
					return _angle;
				}
				private set
				{
					_angle = Utils.NormalRelativeAngleDegrees(value);
				}
			}

			public Polar2(double magnitude = 0, double angle = 0)
			{
				Angle = angle;
				Magnitude = magnitude;
			}

			public static implicit operator Vector2(Polar2 p)
			{
				return new Vector2(Math.Cos(Utils.ToRadians(p.Angle)), Math.Sin(Utils.ToRadians(p.Angle))) * p.Magnitude;
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
				return new Polar2(p.Magnitude * f, p.Angle);
			}

			public static Polar2 operator *(double f, Polar2 p)
			{
				return p * f;
			}

			public static Polar2 operator -(Polar2 p)
			{
				return new Polar2(-p.Magnitude, p.Angle);
			}

			public static Polar2 operator -(Polar2 p1, Polar2 p2)
			{
				return (Vector2)p1 - (Vector2)p2;
			}

			public static Polar2 operator -(Polar2 p, Vector2 v)
			{
				return (Vector2)p - v;
			}

			public override string ToString()
			{
				return "[" + Angle + "," + Magnitude + "]";
			}
		}

		public class Vector2
		{
			public double X
			{
				get;
				private set;
			}
			public double Y
			{
				get;
				private set;
			}

			public Vector2(double x = 0, double y = 0)
			{
				X = x;
				Y = y;
			}

			public static implicit operator Polar2(Vector2 v)
			{
				return new Polar2(Math.Sqrt(v.X * v.X + v.Y * v.Y), Utils.ToDegrees(Math.Atan2(v.Y, v.X)));
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

			public static Vector2 operator -(Vector2 v)
			{
				return new Vector2(-v.X, -v.Y);
			}

			public static Vector2 operator -(Vector2 v1, Vector2 v2)
			{
				return new Vector2(v1.X - v2.X, v2.Y - v2.Y);
			}

			public static Vector2 operator -(Vector2 v, Polar2 p)
			{
				return v - (Vector2)p;
			}

			public override string ToString()
			{
				return "[" + X + "," + Y + "]";
			}
		}
	}
}
