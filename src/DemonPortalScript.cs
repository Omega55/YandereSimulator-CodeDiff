using System;
using UnityEngine;

[Serializable]
public class DemonPortalScript : MonoBehaviour
{
	public YandereScript Yandere;

	public JukeboxScript Jukebox;

	public PromptScript Prompt;

	public ClockScript Clock;

	public AudioSource DemonRealmAudio;

	public GameObject HeartbeatCamera;

	public GameObject DarkAura;

	public GameObject FPS;

	public GameObject HUD;

	public UISprite Darkness;

	public float Timer;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.Character.animation.CrossFade(this.Yandere.IdleAnim);
			this.Yandere.CanMove = false;
			UnityEngine.Object.Instantiate(this.DarkAura, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
			this.Timer += Time.deltaTime;
		}
		if (this.Yandere.transform.position.y > (float)1000)
		{
			this.DemonRealmAudio.volume = Mathf.MoveTowards(this.DemonRealmAudio.volume, (float)1, Time.deltaTime * 0.1f);
		}
		else
		{
			this.DemonRealmAudio.volume = Mathf.MoveTowards(this.DemonRealmAudio.volume, (float)0, Time.deltaTime * 0.1f);
		}
		if (this.Timer > (float)0)
		{
			if (this.Yandere.transform.position.y > (float)1000)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)4)
				{
					float a = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
					Color color = this.Darkness.color;
					float num = color.a = a;
					Color color2 = this.Darkness.color = color;
					if (this.Darkness.color.a == (float)1)
					{
						this.Yandere.transform.position = new Vector3((float)12, (float)0, (float)28);
						this.Yandere.Character.active = true;
						this.HeartbeatCamera.active = true;
						this.FPS.active = true;
						this.HUD.active = true;
					}
				}
				else if (this.Timer > (float)1)
				{
					this.Yandere.Character.active = false;
				}
			}
			else
			{
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0.5f, Time.deltaTime * 0.5f);
				if (this.Jukebox.Volume == 0.5f)
				{
					float a2 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
					Color color3 = this.Darkness.color;
					float num2 = color3.a = a2;
					Color color4 = this.Darkness.color = color3;
					if (this.Darkness.color.a == (float)0)
					{
						this.Yandere.CanMove = true;
						this.Clock.StopTime = false;
						this.Timer = (float)0;
					}
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
