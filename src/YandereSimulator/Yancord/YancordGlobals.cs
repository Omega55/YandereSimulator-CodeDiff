using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	public static class YancordGlobals
	{
		private static string _JoinedYancord = "Yancord_JoinedYancord";

		private static string _CurrentConversation = "Yancord_CurrentConversation";

		public static bool JoinedYancord
		{
			get
			{
				return PlayerPrefsHelper.GetBool(YancordGlobals._JoinedYancord);
			}
			set
			{
				PlayerPrefsHelper.SetBool(YancordGlobals._JoinedYancord, value);
			}
		}

		public static int CurrentConversation
		{
			get
			{
				return PlayerPrefs.GetInt(YancordGlobals._CurrentConversation);
			}
			set
			{
				PlayerPrefs.SetInt(YancordGlobals._CurrentConversation, value);
			}
		}
	}
}
