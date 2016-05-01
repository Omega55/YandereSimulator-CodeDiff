using System;
using UnityEngine;

[Serializable]
public class FoldedUniformScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject SteamCloud;

	public bool InPosition;

	public bool Clean;

	public float Timer;

	public FoldedUniformScript()
	{
		this.InPosition = true;
	}

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		if (this.Clean && this.Prompt.Button[0] != null)
		{
			this.Prompt.HideButton[0] = true;
		}
	}

	public virtual void Update()
	{
		if (this.Clean)
		{
			if (this.Yandere.transform.position.x > (float)43 && this.Yandere.transform.position.x < (float)51 && this.Yandere.transform.position.z > (float)2 && this.Yandere.transform.position.z < (float)14)
			{
				this.InPosition = true;
			}
			else
			{
				this.InPosition = false;
			}
			if (this.Yandere.CensorSteam[0].active && this.Yandere.Bloodiness == (float)0 && this.InPosition)
			{
				this.Prompt.HideButton[0] = false;
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
			if (this.Prompt.Circle[0].fillAmount == (float)0)
			{
				UnityEngine.Object.Instantiate(this.SteamCloud, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
				this.Yandere.Character.animation.CrossFade("f02_stripping_00");
				this.Yandere.Stripping = true;
				this.Yandere.CanMove = false;
				this.Timer += Time.deltaTime;
			}
			if (this.Timer > (float)0)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1.5f)
				{
					this.Yandere.Schoolwear = 1;
					this.Yandere.ChangeSchoolwear();
					UnityEngine.Object.Destroy(this.gameObject);
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
