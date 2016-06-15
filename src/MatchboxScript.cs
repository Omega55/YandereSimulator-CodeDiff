using System;
using UnityEngine;

[Serializable]
public class MatchboxScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public PickUpScript PickUp;

	public GameObject Match;

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
	}

	public virtual void Update()
	{
		if (!this.Prompt.PauseScreen.Show)
		{
			if (this.Yandere.PickUp == this.PickUp)
			{
				if (this.Prompt.HideButton[0])
				{
					this.Yandere.Arc.active = true;
					this.Prompt.HideButton[0] = false;
					this.Prompt.HideButton[3] = true;
				}
				if (this.Prompt.Circle[0].fillAmount == (float)0)
				{
					this.Prompt.Circle[0].fillAmount = (float)1;
					if (!this.Yandere.Flicking)
					{
						GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.Match, this.transform.position, Quaternion.identity);
						gameObject.transform.parent = this.Yandere.ItemParent;
						gameObject.transform.localPosition = new Vector3(0.0159f, 0.0043f, 0.0152f);
						gameObject.transform.localEulerAngles = new Vector3((float)90, (float)0, (float)0);
						gameObject.transform.localScale = new Vector3((float)1, (float)1, (float)1);
						this.Yandere.Match = gameObject;
						this.Yandere.Character.animation.CrossFade("f02_flickingMatch_00");
						this.Yandere.YandereVision = false;
						this.Yandere.Arc.active = false;
						this.Yandere.Flicking = true;
						this.Yandere.CanMove = false;
						this.Prompt.Hide();
						this.Prompt.enabled = false;
					}
				}
			}
			else if (!this.Prompt.HideButton[0])
			{
				this.Yandere.Arc.active = false;
				this.Prompt.HideButton[0] = true;
				this.Prompt.HideButton[3] = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
