using System;
using UnityEngine;

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

	private void Start()
	{
		if (this.ID == 1)
		{
			if (SchemeGlobals.GetSchemeStage(5) == 100)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.gameObject.SetActive(false);
			}
			else
			{
				if (SchemeGlobals.GetSchemeStage(5) > 4)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
				if (DateGlobals.Weekday == DayOfWeek.Friday && this.Clock.HourTime > 13.5f)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					base.gameObject.SetActive(false);
				}
			}
		}
	}

	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				this.Yandere.CharacterAnimation.CrossFade("f02_rummage_00");
				this.Yandere.ProgressBar.transform.parent.gameObject.SetActive(true);
				this.Yandere.RummageSpot = this;
				this.Yandere.Rummaging = true;
				this.Yandere.CanMove = false;
				this.Yandere.EmptyHands();
				component.Play();
			}
		}
		if (this.Yandere.Rummaging)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position, Quaternion.identity);
			gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
			gameObject.transform.localScale = new Vector3(750f, gameObject.transform.localScale.y, 750f);
		}
		if (this.Yandere.Noticed)
		{
			component.Stop();
		}
	}

	public void GetReward()
	{
		if (this.ID == 1)
		{
			if (this.Phase == 1)
			{
				SchemeGlobals.SetSchemeStage(5, 2);
				this.Schemes.UpdateInstructions();
				this.Yandere.Inventory.AnswerSheet = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.DoorGap.Prompt.enabled = true;
				this.Phase++;
			}
			else
			{
				SchemeGlobals.SetSchemeStage(5, 5);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.AnswerSheet = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.gameObject.SetActive(false);
				this.Phase++;
			}
		}
	}
}
