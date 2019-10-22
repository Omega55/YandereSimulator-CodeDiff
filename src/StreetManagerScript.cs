using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StreetManagerScript : MonoBehaviour
{
	public StreetShopInterfaceScript StreetShopInterface;

	public Transform BinocularCamera;

	public Transform Yandere;

	public Transform Hips;

	public Transform Sun;

	public Animation MaidAnimation;

	public Animation Gossip1;

	public Animation Gossip2;

	public AudioSource CurrentlyActiveJukebox;

	public AudioSource JukeboxNight;

	public AudioSource JukeboxDay;

	public AudioSource Yakuza;

	public HomeClockScript Clock;

	public Animation[] Civilian;

	public GameObject Couple;

	public UISprite Darkness;

	public Renderer Stars;

	public bool Threatened;

	public bool GoToCafe;

	public bool FadeOut;

	public bool Day;

	public float Rotation;

	public float Timer;

	public float DesiredValue;

	public float StarAlpha;

	public float Alpha;

	private void Start()
	{
		this.MaidAnimation["f02_faceCouncilGrace_00"].layer = 1;
		this.MaidAnimation.Play("f02_faceCouncilGrace_00");
		this.MaidAnimation["f02_faceCouncilGrace_00"].weight = 1f;
		this.Gossip1["f02_socialSit_00"].layer = 1;
		this.Gossip1.Play("f02_socialSit_00");
		this.Gossip1["f02_socialSit_00"].weight = 1f;
		this.Gossip2["f02_socialSit_00"].layer = 1;
		this.Gossip2.Play("f02_socialSit_00");
		this.Gossip2["f02_socialSit_00"].weight = 1f;
		for (int i = 2; i < 5; i++)
		{
			this.Civilian[i]["f02_smile_00"].layer = 1;
			this.Civilian[i].Play("f02_smile_00");
			this.Civilian[i]["f02_smile_00"].weight = 1f;
		}
		this.Darkness.color = new Color(1f, 1f, 1f, 1f);
		this.CurrentlyActiveJukebox = this.JukeboxNight;
		this.Alpha = 1f;
		if (StudentGlobals.GetStudentDead(30) || StudentGlobals.GetStudentBroken(81))
		{
			this.Couple.SetActive(false);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown("m"))
		{
			PlayerGlobals.Money += 1f;
			this.Clock.UpdateMoneyLabel();
			if (this.JukeboxNight.isPlaying)
			{
				this.JukeboxNight.Stop();
				this.JukeboxDay.Stop();
			}
			else
			{
				this.JukeboxNight.Play();
				this.JukeboxDay.Stop();
			}
		}
		if (Input.GetKeyDown("f"))
		{
			PlayerGlobals.FakeID = !PlayerGlobals.FakeID;
			this.StreetShopInterface.UpdateFakeID();
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			if (this.Alpha == 1f)
			{
				this.JukeboxNight.volume = 0.5f;
				this.JukeboxNight.Play();
				this.JukeboxDay.volume = 0f;
				this.JukeboxDay.Play();
			}
			if (!this.FadeOut)
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
				this.Darkness.color = new Color(1f, 1f, 1f, this.Alpha);
			}
			else
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
				this.CurrentlyActiveJukebox.volume = (1f - this.Alpha) * 0.5f;
				if (this.GoToCafe)
				{
					this.Darkness.color = new Color(1f, 1f, 1f, this.Alpha);
					if (this.Alpha == 1f)
					{
						SceneManager.LoadScene("MaidMenuScene");
					}
				}
				else
				{
					this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
					if (this.Alpha == 1f)
					{
						SceneManager.LoadScene("HomeScene");
					}
				}
			}
		}
		if (!this.FadeOut && !this.BinocularCamera.gameObject.activeInHierarchy)
		{
			if (Vector3.Distance(this.Yandere.position, this.Yakuza.transform.position) > 5f)
			{
				this.DesiredValue = 0.5f;
			}
			else
			{
				this.DesiredValue = Vector3.Distance(this.Yandere.position, this.Yakuza.transform.position) * 0.1f;
			}
			if (this.Day)
			{
				this.JukeboxDay.volume = Mathf.Lerp(this.JukeboxDay.volume, this.DesiredValue, Time.deltaTime * 10f);
				this.JukeboxNight.volume = Mathf.Lerp(this.JukeboxNight.volume, 0f, Time.deltaTime * 10f);
			}
			else
			{
				this.JukeboxDay.volume = Mathf.Lerp(this.JukeboxDay.volume, 0f, Time.deltaTime * 10f);
				this.JukeboxNight.volume = Mathf.Lerp(this.JukeboxNight.volume, this.DesiredValue, Time.deltaTime * 10f);
			}
			if (Vector3.Distance(this.Yandere.position, this.Yakuza.transform.position) < 1f && !this.Threatened)
			{
				this.Threatened = true;
				this.Yakuza.Play();
			}
		}
		if (Input.GetKeyDown("space"))
		{
			this.Day = !this.Day;
			if (this.Day)
			{
				this.Clock.HourLabel.text = "12:00 PM";
			}
			else
			{
				this.Clock.HourLabel.text = "8:00 PM";
			}
		}
		if (this.Day)
		{
			this.CurrentlyActiveJukebox = this.JukeboxDay;
			this.Rotation = Mathf.Lerp(this.Rotation, 45f, Time.deltaTime * 10f);
			this.StarAlpha = Mathf.Lerp(this.StarAlpha, 0f, Time.deltaTime * 10f);
		}
		else
		{
			this.CurrentlyActiveJukebox = this.JukeboxNight;
			this.Rotation = Mathf.Lerp(this.Rotation, -45f, Time.deltaTime * 10f);
			this.StarAlpha = Mathf.Lerp(this.StarAlpha, 1f, Time.deltaTime * 10f);
		}
		this.Sun.transform.eulerAngles = new Vector3(this.Rotation, this.Rotation, 0f);
		this.Stars.material.SetColor("_TintColor", new Color(1f, 1f, 1f, this.StarAlpha));
	}

	private void LateUpdate()
	{
		this.Hips.LookAt(this.BinocularCamera.position);
	}
}
