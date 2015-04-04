using System;
using UnityEngine;

[Serializable]
public class ReputationScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public Transform CurrentRepMarker;

	public Transform PendingRepMarker;

	public UILabel PendingRepLabel;

	public ClockScript Clock;

	public float Reputation;

	public float PendingRep;

	public int Phase;

	public virtual void Start()
	{
		this.Reputation = PlayerPrefs.GetFloat("Reputation");
	}

	public virtual void Update()
	{
		if (this.Phase == 1)
		{
			if (this.Clock.PresentTime / (float)60 > 8.5f)
			{
				this.Reputation += this.PendingRep;
				this.PendingRep = (float)0;
				this.Phase++;
				this.StudentManager.WipePendingRep();
			}
		}
		else if (this.Phase == 2)
		{
			if (this.Clock.PresentTime / (float)60 > 13.5f)
			{
				this.Reputation += this.PendingRep;
				this.PendingRep = (float)0;
				this.Phase++;
				this.StudentManager.WipePendingRep();
			}
		}
		else if (this.Phase == 3 && this.Clock.PresentTime / (float)60 > (float)18)
		{
			this.Reputation += this.PendingRep;
			this.PendingRep = (float)0;
			this.Phase++;
			this.StudentManager.WipePendingRep();
		}
		float x = Mathf.Lerp(this.CurrentRepMarker.localPosition.x, (float)-830 + this.Reputation * 1.5f, Time.deltaTime * (float)10);
		Vector3 localPosition = this.CurrentRepMarker.localPosition;
		float num = localPosition.x = x;
		Vector3 vector = this.CurrentRepMarker.localPosition = localPosition;
		float x2 = Mathf.Lerp(this.PendingRepMarker.localPosition.x, this.CurrentRepMarker.transform.localPosition.x + this.PendingRep * 1.5f, Time.deltaTime * (float)10);
		Vector3 localPosition2 = this.PendingRepMarker.localPosition;
		float num2 = localPosition2.x = x2;
		Vector3 vector2 = this.PendingRepMarker.localPosition = localPosition2;
		if (this.CurrentRepMarker.localPosition.x < (float)-980)
		{
			int num3 = -980;
			Vector3 localPosition3 = this.CurrentRepMarker.localPosition;
			float num4 = localPosition3.x = (float)num3;
			Vector3 vector3 = this.CurrentRepMarker.localPosition = localPosition3;
		}
		if (this.PendingRepMarker.localPosition.x < (float)-980)
		{
			int num5 = -980;
			Vector3 localPosition4 = this.PendingRepMarker.localPosition;
			float num6 = localPosition4.x = (float)num5;
			Vector3 vector4 = this.PendingRepMarker.localPosition = localPosition4;
		}
		if (this.CurrentRepMarker.localPosition.x > (float)-680)
		{
			int num7 = -680;
			Vector3 localPosition5 = this.CurrentRepMarker.localPosition;
			float num8 = localPosition5.x = (float)num7;
			Vector3 vector5 = this.CurrentRepMarker.localPosition = localPosition5;
		}
		if (this.PendingRepMarker.localPosition.x > (float)-680)
		{
			int num9 = -680;
			Vector3 localPosition6 = this.PendingRepMarker.localPosition;
			float num10 = localPosition6.x = (float)num9;
			Vector3 vector6 = this.PendingRepMarker.localPosition = localPosition6;
		}
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
		if (Input.GetKeyDown("8"))
		{
			PlayerPrefs.SetFloat("Reputation", (float)34);
			this.Reputation = PlayerPrefs.GetFloat("Reputation");
		}
	}

	public virtual void Main()
	{
	}
}
