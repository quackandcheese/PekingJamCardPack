using System;
using UnityEngine;

namespace Photon.Compression
{
	[Serializable]
	public abstract class LiteCrusher
	{
		[SerializeField]
		protected int bits;

		public static int GetBitsForMaxValue(uint maxvalue)
		{
			for (int i = 0; i < 32; i++)
			{
				if (maxvalue >> i == 0)
				{
					return i;
				}
			}
			return 32;
		}
	}
	[Serializable]
	public abstract class LiteCrusher<TComp, T> : LiteCrusher where TComp : struct where T : struct
	{
		public abstract TComp Encode(T val);

		public abstract T Decode(uint val);

		public abstract TComp WriteValue(T val, byte[] buffer, ref int bitposition);

		public abstract void WriteCValue(uint val, byte[] buffer, ref int bitposition);

		public abstract T ReadValue(byte[] buffer, ref int bitposition);

		public abstract TComp ReadCValue(byte[] buffer, ref int bitposition);
	}
}
