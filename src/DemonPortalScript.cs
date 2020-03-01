using System;
using UnityEngine;

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

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
			this.Yandere.CanMove = false;
			UnityEngine.Object.Instantiate<GameObject>(this.DarkAura, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
			this.Timer += Time.deltaTime;
		}
		this.DemonRealmAudio.volume = Mathf.MoveTowards(this.DemonRealmAudio.volume, (this.Yandere.transform.position.y <= 1000f) ? 0f : 0.5f, Time.deltaTime * 0.1f);
		if (this.Timer > 0f)
		{
			if (this.Yandere.transform.position.y > 1000f)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 4f)
				{
					this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
					if (this.Darkness.color.a == 1f)
					{
						this.Yandere.transform.position = new Vector3(12f, 0f, 28f);
						this.Yandere.Character.SetActive(true);
						this.Yandere.SetAnimationLayers();
						this.HeartbeatCamera.SetActive(true);
						this.FPS.SetActive(true);
						this.HUD.SetActive(true);
					}
				}
				else if (this.Timer > 1f)
				{
					this.Yandere.Character.SetActive(false);
				}
			}
			else
			{
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0.5f, Time.deltaTime * 0.5f);
				if (this.Jukebox.Volume == 0.5f)
				{
					this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
					if (this.Darkness.color.a == 0f)
					{
						base.transform.parent.gameObject.SetActive(false);
						this.Darkness.enabled = false;
						this.Yandere.CanMove = true;
						this.Clock.StopTime = false;
						this.Timer = 0f;
					}
				}
			}
		}
	}
}
