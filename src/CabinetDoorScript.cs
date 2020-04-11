using System;
using UnityEngine;

public class CabinetDoorScript : MonoBehaviour
{
	public PromptScript Prompt;

	public bool Locked;

	public bool Open;

	public float Timer;

	private void Update()
	{
		if (this.Timer < 2f)
		{
			this.Timer += Time.deltaTime;
			if (this.Open)
			{
				base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0.41775f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
				return;
			}
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
		}
	}
}
