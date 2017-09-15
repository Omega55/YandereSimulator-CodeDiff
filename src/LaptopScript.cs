using System;
using UnityEngine;

public class LaptopScript : MonoBehaviour
{
	public Camera LaptopCamera;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public DynamicBone Hair;

	public Transform LaptopScreen;

	public AudioClip ShutDown;

	public GameObject SCP;

	public bool React;

	public bool Off;

	public float[] Cues;

	public string[] Subs;

	public int FirstFrame;

	public float Timer;

	public UILabel EventSubtitle;

	private void Start()
	{
		if (SchoolGlobals.SCP)
		{
			this.LaptopScreen.localScale = Vector3.zero;
			this.LaptopCamera.enabled = false;
			this.SCP.SetActive(false);
			base.enabled = false;
		}
		else
		{
			Animation component = this.SCP.GetComponent<Animation>();
			component["f02_scp_00"].speed = 0f;
			component["f02_scp_00"].time = 0f;
		}
	}

	private void Update()
	{
		if (this.FirstFrame == 2)
		{
			this.LaptopCamera.enabled = false;
		}
		this.FirstFrame++;
		if (!this.Off)
		{
			AudioSource component = base.GetComponent<AudioSource>();
			Animation component2 = this.SCP.GetComponent<Animation>();
			if (!this.React)
			{
				if (this.Yandere.transform.position.x > base.transform.position.x + 1f && Vector3.Distance(this.Yandere.transform.position, new Vector3(base.transform.position.x, 4f, base.transform.position.z)) < 2f && this.Yandere.Followers == 0)
				{
					this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
					component2["f02_scp_00"].time = 0f;
					this.LaptopCamera.enabled = true;
					component2.Play();
					this.Hair.enabled = true;
					this.Jukebox.Dip = 0.5f;
					component.Play();
					this.React = true;
				}
			}
			else
			{
				component.pitch = Time.timeScale;
				component.volume = 1f;
				if (this.Yandere.transform.position.y > base.transform.position.y + 3f || this.Yandere.transform.position.y < base.transform.position.y - 3f)
				{
					component.volume = 0f;
				}
				for (int i = 0; i < this.Cues.Length; i++)
				{
					if (component.time > this.Cues[i])
					{
						this.EventSubtitle.text = this.Subs[i];
					}
				}
				if (component.time >= component.clip.length - 1f || component.time == 0f)
				{
					component2["f02_scp_00"].speed = 1f;
					this.Timer += Time.deltaTime;
				}
				else
				{
					component2["f02_scp_00"].time = component.time;
				}
				if (this.Timer > 1f)
				{
					component.clip = this.ShutDown;
					component.Play();
					this.EventSubtitle.text = string.Empty;
					SchoolGlobals.SCP = true;
					this.LaptopCamera.enabled = false;
					this.Jukebox.Dip = 1f;
					this.React = false;
					this.Off = true;
				}
			}
		}
		else if (this.LaptopScreen.localScale.x > 0.1f)
		{
			this.LaptopScreen.localScale = Vector3.Lerp(this.LaptopScreen.localScale, Vector3.zero, Time.deltaTime * 10f);
		}
		else if (base.enabled)
		{
			this.LaptopScreen.localScale = Vector3.zero;
			this.Hair.enabled = false;
			base.enabled = false;
		}
	}
}
