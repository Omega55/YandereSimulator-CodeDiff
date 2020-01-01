using System;
using UnityEngine;

public class SchemeManagerScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public ClockScript Clock;

	public float Timer;

	private void Update()
	{
		if (this.Clock.HourTime > 8.25f)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.Timer = 0f;
				if (SchemeGlobals.GetSchemeStage(5) == 1)
				{
					SchemeGlobals.SetSchemeStage(5, 2);
					this.Schemes.UpdateInstructions();
					base.enabled = false;
				}
			}
		}
	}
}
