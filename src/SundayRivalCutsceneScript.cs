using System;
using UnityEngine;

public class SundayRivalCutsceneScript : MonoBehaviour
{
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Sunday)
		{
			base.gameObject.SetActive(false);
		}
	}
}
