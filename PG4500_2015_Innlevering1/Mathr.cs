using System;

namespace Robot_support_classes
{
	namespace Mathr
	{
		public class Polar2
		{
			public float Distance
			{
				get;
				set;
			}

			private float Angle
			{
				get;
				set;
			}

			public Polar2(float distance, float angle)
			{
				Distance = distance;
				Angle = angle;
			}

			public static implicit operator Vector2(Polar2 p)
			{
				return new Vector2((float)Math.Cos(p.Angle), (float)Math.Sin(p.Angle)) * p.Distance;
			}

			public static Polar2 operator +(Polar2 p1, Polar2 p2)
			{
				return (Vector2)p1 + (Vector2)p2;
			}

			public static Polar2 operator +(Polar2 p, Vector2 v)
			{
				return (Vector2)p + v;
			}

			public static Polar2 operator *(Polar2 p, float f)
			{
				return new Polar2(p.Distance * f, p.Angle);
			}

			public static Polar2 operator *(float f, Polar2 p)
			{
				return p * f;
			}
		}

		public class Vector2
		{
			public float X
			{
				get;
				set;
			}
			public float Y
			{
				get;
				set;
			}

			public Vector2(float x, float y)
			{
				X = x;
				Y = y;
			}

			public static implicit operator Polar2(Vector2 v)
			{
				return new Polar2((float)Math.Sqrt(v.X * v.X + v.Y * v.Y), (float)Math.Atan2(v.Y, v.X));
			}

			public static Vector2 operator *(Vector2 v, float f)
			{
				return new Vector2(v.X * f, v.Y * f);
			}

			public static Vector2 operator *(float f, Vector2 v)
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
