using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class DoorScript : MonoBehaviour
{
	public PromptScript Prompt;

	public float[] ClosedPositions;

	public float[] OpenPositions;

	public Transform[] Doors;

	public bool Open;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (!this.Open)
			{
				this.OpenDoor();
			}
			else
			{
				this.Prompt.Label[0].text = "     " + "Open";
				this.Open = false;
			}
		}
		if (!this.Open)
		{
			for (int i = 0; i < Extensions.get_length(this.Doors); i++)
			{
				float x = Mathf.Lerp(this.Doors[i].localPosition.x, this.ClosedPositions[i], Time.deltaTime * (float)10);
				Vector3 localPosition = this.Doors[i].localPosition;
				float num = localPosition.x = x;
				Vector3 vector = this.Doors[i].localPosition = localPosition;
			}
		}
		else
		{
			for (int i = 0; i < Extensions.get_length(this.Doors); i++)
			{
				float x2 = Mathf.Lerp(this.Doors[i].localPosition.x, this.OpenPositions[i], Time.deltaTime * (float)10);
				Vector3 localPosition2 = this.Doors[i].localPosition;
				float num2 = localPosition2.x = x2;
				Vector3 vector2 = this.Doors[i].localPosition = localPosition2;
			}
		}
	}

	public virtual void OpenDoor()
	{
		this.Prompt.Label[0].text = "     " + "Close";
		this.Open = true;
	}

	public virtual void Main()
	{
	}
}
