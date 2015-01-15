using System;
using UnityEngine;

[Serializable]
public class ReputationScript : MonoBehaviour
{
	public Transform CurrentRepMarker;

	public Transform PendingRepMarker;

	public UILabel PendingRepLabel;

	public ClockScript Clock;

	public float Reputation;

	public float PendingRep;

	public int Phase;

	public virtual void Update()
	{
		if (this.Phase == 1)
		{
			if (this.Clock.PresentTime / (float)60 > 8.5f)
			{
				this.Reputation += this.PendingRep;
				this.PendingRep = (float)0;
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			if (this.Clock.PresentTime / (float)60 > 13.5f)
			{
				this.Reputation += this.PendingRep;
				this.PendingRep = (float)0;
				this.Phase++;
			}
		}
		else if (this.Phase == 3 && this.Clock.PresentTime / (float)60 > (float)18)
		{
			this.Reputation += this.PendingRep;
			this.PendingRep = (float)0;
			this.Phase++;
		}
		if (this.Reputation > (float)100)
		{
			this.Reputation = (float)100;
		}
		if (this.Reputation < (float)-100)
		{
			this.Reputation = (float)-100;
		}
		float x = Mathf.Lerp(this.CurrentRepMarker.localPosition.x, (float)-850 + this.Reputation * 1.5f, Time.deltaTime * (float)10);
		Vector3 localPosition = this.CurrentRepMarker.localPosition;
		float num = localPosition.x = x;
		Vector3 vector = this.CurrentRepMarker.localPosition = localPosition;
		if (this.Reputation + this.PendingRep > (float)100)
		{
			this.PendingRep = (float)100 - this.Reputation;
		}
		if (this.Reputation + this.PendingRep < (float)-100)
		{
			this.PendingRep = (float)-100 - this.Reputation;
		}
		float x2 = Mathf.Lerp(this.PendingRepMarker.localPosition.x, this.CurrentRepMarker.transform.localPosition.x + this.PendingRep * 1.5f, Time.deltaTime * (float)10);
		Vector3 localPosition2 = this.PendingRepMarker.localPosition;
		float num2 = localPosition2.x = x2;
		Vector3 vector2 = this.PendingRepMarker.localPosition = localPosition2;
		if (this.PendingRep > (float)0)
		{
			this.PendingRepLabel.text = "+" + this.PendingRep;
		}
		else if (this.PendingRep < (float)0)
		{
			this.PendingRepLabel.text = string.Empty + this.PendingRep;
		}
		else
		{
			this.PendingRepLabel.text = string.Empty;
		}
	}

	public virtual void Main()
	{
	}
}
