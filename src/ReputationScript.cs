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

	public bool MissionMode;

	public GameObject FlowerVase;

	public GameObject Grafitti;

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("MissionMode") == 1)
		{
			this.MissionMode = true;
		}
		this.Reputation = PlayerPrefs.GetFloat("Reputation");
		this.Bully();
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
		if (!this.MissionMode)
		{
			float x = Mathf.Lerp(this.CurrentRepMarker.localPosition.x, (float)-830 + this.Reputation * 1.5f, Time.deltaTime * (float)10);
			Vector3 localPosition = this.CurrentRepMarker.localPosition;
			float num = localPosition.x = x;
			Vector3 vector = this.CurrentRepMarker.localPosition = localPosition;
			float x2 = Mathf.Lerp(this.PendingRepMarker.localPosition.x, this.CurrentRepMarker.transform.localPosition.x + this.PendingRep * 1.5f, Time.deltaTime * (float)10);
			Vector3 localPosition2 = this.PendingRepMarker.localPosition;
			float num2 = localPosition2.x = x2;
			Vector3 vector2 = this.PendingRepMarker.localPosition = localPosition2;
		}
		else
		{
			float x3 = Mathf.Lerp(this.PendingRepMarker.localPosition.x, (float)-980 + this.PendingRep * (float)-3, Time.deltaTime * (float)10);
			Vector3 localPosition3 = this.PendingRepMarker.localPosition;
			float num3 = localPosition3.x = x3;
			Vector3 vector3 = this.PendingRepMarker.localPosition = localPosition3;
		}
		if (this.CurrentRepMarker.localPosition.x < (float)-980)
		{
			int num4 = -980;
			Vector3 localPosition4 = this.CurrentRepMarker.localPosition;
			float num5 = localPosition4.x = (float)num4;
			Vector3 vector4 = this.CurrentRepMarker.localPosition = localPosition4;
		}
		if (this.PendingRepMarker.localPosition.x < (float)-980)
		{
			int num6 = -980;
			Vector3 localPosition5 = this.PendingRepMarker.localPosition;
			float num7 = localPosition5.x = (float)num6;
			Vector3 vector5 = this.PendingRepMarker.localPosition = localPosition5;
		}
		if (this.CurrentRepMarker.localPosition.x > (float)-680)
		{
			int num8 = -680;
			Vector3 localPosition6 = this.CurrentRepMarker.localPosition;
			float num9 = localPosition6.x = (float)num8;
			Vector3 vector6 = this.CurrentRepMarker.localPosition = localPosition6;
		}
		if (this.PendingRepMarker.localPosition.x > (float)-680)
		{
			int num10 = -680;
			Vector3 localPosition7 = this.PendingRepMarker.localPosition;
			float num11 = localPosition7.x = (float)num10;
			Vector3 vector7 = this.PendingRepMarker.localPosition = localPosition7;
		}
		if (!this.MissionMode)
		{
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
		else if (this.PendingRep < (float)0)
		{
			this.PendingRepLabel.text = string.Empty + this.PendingRep * (float)-1;
		}
		else
		{
			this.PendingRepLabel.text = string.Empty;
		}
	}

	public virtual void Bully()
	{
		int @int = PlayerPrefs.GetInt("Student_7_Reputation");
		this.FlowerVase.active = false;
		this.Grafitti.active = false;
		if (PlayerPrefs.GetInt("Student_7_Dead") == 0)
		{
			if ((float)@int < -33.33333f && (float)@int > -66.66666f)
			{
				this.FlowerVase.active = true;
			}
			else if ((float)@int < -66.66666f)
			{
				this.Grafitti.active = true;
			}
		}
		else
		{
			this.FlowerVase.active = true;
		}
	}

	public virtual void Main()
	{
	}
}
