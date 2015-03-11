using System;

namespace Robot_support_classes
{
	class Mathr
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

			public static Vector2 operator *(Vector2 v, float f)
			{
				return new Vector2(v.X * f, v.Y * f);
			}

			public static implicit operator Polar2(Vector2 v)
			{
				return new Polar2((float)Math.Sqrt(v.X * v.X + v.Y * v.Y), (float)Math.Atan2(v.Y, v.X));
			}
		}
	}
}
