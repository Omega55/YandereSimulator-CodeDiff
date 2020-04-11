using System;
using UnityEngine;

public class ReputationScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public ArmDetectorScript ArmDetector;

	public PortalScript Portal;

	public Transform CurrentRepMarker;

	public Transform PendingRepMarker;

	public UILabel PendingRepLabel;

	public ClockScript Clock;

	public float Reputation;

	public float PendingRep;

	public int CheckedRep = 1;

	public int Phase;

	public bool MissionMode;

	public GameObject FlowerVase;

	public GameObject Grafitti;

	private void Start()
	{
		if (MissionModeGlobals.MissionMode)
		{
			this.MissionMode = true;
		}
		this.Reputation = PlayerGlobals.Reputation;
		this.Bully();
	}

	private void Update()
	{
		if (this.Phase == 1)
		{
			if (this.Clock.PresentTime / 60f > 8.5f)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			if (this.Clock.PresentTime / 60f > 13.5f)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 3 && this.Clock.PresentTime / 60f > 18f)
		{
			this.Phase++;
		}
		if (this.PendingRep < 0f)
		{
			this.StudentManager.TutorialWindow.ShowRepMessage = true;
		}
		if (this.CheckedRep < this.Phase && !this.StudentManager.Yandere.Struggling && !this.StudentManager.Yandere.DelinquentFighting && !this.StudentManager.Yandere.Pickpocketing && !this.StudentManager.Yandere.Noticed && !this.ArmDetector.SummonDemon)
		{
			this.UpdateRep();
			if (this.Reputation <= -100f)
			{
				this.Portal.EndDay();
			}
		}
		if (!this.MissionMode)
		{
			this.CurrentRepMarker.localPosition = new Vector3(Mathf.Lerp(this.CurrentRepMarker.localPosition.x, -830f + this.Reputation * 1.5f, Time.deltaTime * 10f), this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
			this.PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(this.PendingRepMarker.localPosition.x, this.CurrentRepMarker.transform.localPosition.x + this.PendingRep * 1.5f, Time.deltaTime * 10f), this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
		}
		else
		{
			this.PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(this.PendingRepMarker.localPosition.x, -980f + this.PendingRep * -3f, Time.deltaTime * 10f), this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
		}
		if (this.CurrentRepMarker.localPosition.x < -980f)
		{
			this.CurrentRepMarker.localPosition = new Vector3(-980f, this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
		}
		if (this.PendingRepMarker.localPosition.x < -980f)
		{
			this.PendingRepMarker.localPosition = new Vector3(-980f, this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
		}
		if (this.CurrentRepMarker.localPosition.x > -680f)
		{
			this.CurrentRepMarker.localPosition = new Vector3(-680f, this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
		}
		if (this.PendingRepMarker.localPosition.x > -680f)
		{
			this.PendingRepMarker.localPosition = new Vector3(-680f, this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
		}
		if (!this.MissionMode)
		{
			if (this.PendingRep > 0f)
			{
				this.PendingRepLabel.text = "+" + this.PendingRep.ToString();
				return;
			}
			if (this.PendingRep < 0f)
			{
				this.PendingRepLabel.text = this.PendingRep.ToString();
				return;
			}
			this.PendingRepLabel.text = string.Empty;
			return;
		}
		else
		{
			if (this.PendingRep < 0f)
			{
				this.PendingRepLabel.text = (-this.PendingRep).ToString();
				return;
			}
			this.PendingRepLabel.text = string.Empty;
			return;
		}
	}

	private void Bully()
	{
		this.FlowerVase.SetActive(false);
	}

	public void UpdateRep()
	{
		this.Reputation += this.PendingRep;
		this.PendingRep = 0f;
		this.CheckedRep++;
		if (ClubGlobals.Club == ClubType.Delinquent && this.Reputation > -33.33333f)
		{
			this.Reputation = -33.33333f;
		}
		this.StudentManager.WipePendingRep();
	}
}
