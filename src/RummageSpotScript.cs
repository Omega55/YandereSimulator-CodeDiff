using System;
using UnityEngine;

[Serializable]
public class RummageSpotScript : MonoBehaviour
{
	public GameObject AlarmDisc;

	public DoorGapScript DoorGap;

	public SchemesScript Schemes;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public ClockScript Clock;

	public Transform Target;

	public int Phase;

	public int ID;

	public virtual void Start()
	{
		if (this.ID == 1)
		{
			if (PlayerPrefs.GetInt("Scheme_5_Stage") == 100)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.active = false;
			}
			else
			{
				if (PlayerPrefs.GetInt("Scheme_5_Stage") > 4)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
				if (PlayerPrefs.GetInt("Weekday") == 5 && this.Clock.HourTime > 13.5f)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.active = false;
				}
			}
		}
	}

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			this.Yandere.CharacterAnimation.CrossFade("f02_rummage_00");
			this.Yandere.ProgressBar.transform.parent.gameObject.active = true;
			this.Yandere.RummageSpot = this;
			this.Yandere.Rummaging = true;
			this.Yandere.CanMove = false;
			this.audio.Play();
		}
		if (this.Yandere.Rummaging)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.AlarmDisc, this.transform.position, Quaternion.identity);
			((AlarmDiscScript)gameObject.GetComponent(typeof(AlarmDiscScript))).NoScream = true;
			int num = 750;
			Vector3 localScale = gameObject.transform.localScale;
			float num2 = localScale.x = (float)num;
			Vector3 vector = gameObject.transform.localScale = localScale;
			int num3 = 750;
			Vector3 localScale2 = gameObject.transform.localScale;
			float num4 = localScale2.z = (float)num3;
			Vector3 vector2 = gameObject.transform.localScale = localScale2;
		}
		if (this.Yandere.Noticed)
		{
			this.audio.Stop();
		}
	}

	public virtual void GetReward()
	{
		if (this.ID == 1)
		{
			if (this.Phase == 1)
			{
				PlayerPrefs.SetInt("Scheme_5_Stage", 2);
				this.Schemes.UpdateInstructions();
				this.Yandere.Inventory.AnswerSheet = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.DoorGap.Prompt.enabled = true;
				this.Phase++;
			}
			else
			{
				PlayerPrefs.SetInt("Scheme_5_Stage", 5);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.AnswerSheet = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.active = false;
				this.Phase++;
			}
		}
	}

	public virtual void Main()
	{
	}
}
