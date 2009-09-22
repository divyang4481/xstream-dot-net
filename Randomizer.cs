using System;

namespace Xstream.Tests
{
    internal enum RandomEnumForTest
	{
		Lo, Mid, Hi
	}

	/// <summary>
	/// Creates random primitive and string type values.
	/// </summary>
	internal class TestRandomizer
	{
		public static readonly Random random = new Random();

		public static string GetString()
		{
			return "" + ( random.NextDouble() * 100000 );
		}

		public static int GetInt()
		{
			return random.Next();
		}

		public static long GetLong()
		{
			return (long) int.MaxValue + (long) random.Next();
		}

		public static float GetFloat()
		{
			return Convert.ToSingle( random.NextDouble() );
		}

		public static double GetDouble()
		{
			return random.NextDouble();
		}

		public static short GetShort()
		{
			return Convert.ToInt16( random.Next( 0, 255 ) );
		}

		public static char GetChar()
		{
			return (char) random.Next( 64, 128 );
		}

		public static bool GetBool()
		{
			return ( random.Next( 0, 10 ) > 5 );
		}

		public static byte[] GetBytes()
		{
			byte[] bytes	= new byte[ random.Next( 1, 100 ) ];
			random.NextBytes( bytes );

			return bytes;
		}

		public static decimal GetDecimal()
		{
			return decimal.Parse( GetString() );
		}

		public static Guid GetGuid()
		{
			return Guid.NewGuid();
		}

		public static RandomEnumForTest GetEnum()
		{
			RandomEnumForTest[] enumForTests	= { RandomEnumForTest.Lo, RandomEnumForTest.Mid, RandomEnumForTest.Hi };
			int index			= random.Next( 0, 3 );

			return enumForTests[ index ];
		}

		public static DateTime GetDateTime()
		{
			return DateTime.Now.AddSeconds( random.Next( 0, 86400 ) );
		}
	}
}
