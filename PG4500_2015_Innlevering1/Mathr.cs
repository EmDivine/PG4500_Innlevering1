using System;

namespace Robot_support_classes
{
	class Mathr
	{
		public class PolarCoordinate
		{
			public float distance
			{
				get;
				set;
			}
			private float angle
			{
				get;
				set;
			}
			public PolarCoordinate(float distance, float angle)
			{
				this.distance = distance;
				this.angle = angle;
			}

			public static implicit operator Vector2(PolarCoordinate p)
			{
				return new Vector2((float)Math.Cos(p.angle), (float)Math.Sin(p.angle)) * p.distance;
			}
		}

		public class Vector2
		{
			public float x
			{
				get;
				set;
			}
			public float y
			{
				get;
				set;
			}

			public Vector2(float x, float y)
			{
				this.x = x;
				this.y = y;
			}

			public static Vector2 operator *(Vector2 v, float f)
			{
				return new Vector2(v.x * f, v.y * f);
			}

			public static implicit operator PolarCoordinate(Vector2 v)
			{
				return new PolarCoordinate((float)Math.Sqrt(v.x * v.x + v.y * v.y), (float)Math.Atan2(v.y, v.x));
			}
		}
	}
}
