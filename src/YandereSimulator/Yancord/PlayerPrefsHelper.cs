using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	public static class PlayerPrefsHelper
	{
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, (!flag) ? 0 : 1);
		}

		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
