using System;
using UnityEngine;

public class MatchboxScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public PickUpScript PickUp;

	public GameObject Match;

	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	private void Update()
	{
		if (!this.Prompt.PauseScreen.Show)
		{
			if (this.Yandere.PickUp == this.PickUp)
			{
				if (this.Prompt.HideButton[0])
				{
					this.Yandere.Arc.SetActive(true);
					this.Prompt.HideButton[0] = false;
					this.Prompt.HideButton[3] = true;
				}
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.Prompt.Circle[0].fillAmount = 1f;
					if (!this.Yandere.Chased && this.Yandere.Chasers == 0 && this.Yandere.CanMove && !this.Yandere.Flicking)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Match, base.transform.position, Quaternion.identity);
						gameObject.transform.parent = this.Yandere.ItemParent;
						gameObject.transform.localPosition = new Vector3(0.0159f, 0.0043f, 0.0152f);
						gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
						gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
						this.Yandere.Match = gameObject;
						this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_flickingMatch_00");
						this.Yandere.YandereVision = false;
						this.Yandere.Arc.SetActive(false);
						this.Yandere.Flicking = true;
						this.Yandere.CanMove = false;
						this.Prompt.Hide();
						this.Prompt.enabled = false;
					}
				}
			}
			else if (!this.Prompt.HideButton[0])
			{
				this.Yandere.Arc.SetActive(false);
				this.Prompt.HideButton[0] = true;
				this.Prompt.HideButton[3] = false;
			}
		}
	}
}
