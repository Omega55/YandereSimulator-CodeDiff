using System;
using UnityEngine;

public class SchemeManagerScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public ClockScript Clock;

	public bool ClockCheck;

	public float Timer;

	private void Update()
	{
		if (this.Clock.HourTime > 15.5f)
		{
			SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, 100);
			this.Clock.Yandere.NotificationManager.CustomText = "Scheme failed! You were too slow.";
			this.Clock.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			this.Schemes.UpdateInstructions();
			base.enabled = false;
		}
		if (this.ClockCheck && this.Clock.HourTime > 8.25f)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.Timer = 0f;
				if (SchemeGlobals.GetSchemeStage(5) == 1)
				{
					Debug.Log("It's past 8:15 AM, so we're advancing to Stage 2 of Scheme 5.");
					SchemeGlobals.SetSchemeStage(5, 2);
					this.Schemes.UpdateInstructions();
					this.ClockCheck = false;
				}
			}
		}
	}
}
