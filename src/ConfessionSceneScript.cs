using System;
using UnityEngine;

public class ConfessionSceneScript : MonoBehaviour
{
	public Transform[] CameraDestinations;

	public StudentManagerScript StudentManager;

	public PromptBarScript PromptBar;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public ClockScript Clock;

	public Bloom BloomEffect;

	public StudentScript Suitor;

	public StudentScript Rival;

	public ParticleSystem MythBlossoms;

	public GameObject HeartBeatCamera;

	public GameObject ConfessionBG;

	public Transform MainCamera;

	public Transform RivalSpot;

	public Transform KissSpot;

	public string[] Text;

	public UISprite Darkness;

	public UILabel Label;

	public UIPanel Panel;

	public bool ShowLabel;

	public bool Kissing;

	public int TextPhase = 1;

	public int Phase = 1;

	public float Timer;

	private void Update()
	{
		if (this.Phase == 1)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 0f, Time.deltaTime);
			this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0f, Time.deltaTime);
			if (this.Darkness.color.a == 1f)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					this.BloomEffect.bloomIntensity = 1f;
					this.BloomEffect.bloomThreshhold = 0f;
					this.BloomEffect.bloomBlurIterations = 1;
					this.Suitor = this.StudentManager.Students[13];
					this.Rival = this.StudentManager.Students[7];
					this.Rival.transform.position = this.RivalSpot.position;
					this.Rival.transform.eulerAngles = this.RivalSpot.eulerAngles;
					this.Suitor.Cosmetic.MyRenderer.materials[this.Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
					this.Suitor.transform.eulerAngles = this.StudentManager.SuitorConfessionSpot.eulerAngles;
					this.Suitor.transform.position = this.StudentManager.SuitorConfessionSpot.position;
					this.Suitor.Character.GetComponent<Animation>().Play(this.Suitor.IdleAnim);
					this.MythBlossoms.emission.rateOverTime = 100f;
					this.HeartBeatCamera.SetActive(false);
					this.ConfessionBG.SetActive(true);
					base.GetComponent<AudioSource>().Play();
					this.MainCamera.position = this.CameraDestinations[1].position;
					this.MainCamera.eulerAngles = this.CameraDestinations[1].eulerAngles;
					this.Timer = 0f;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 2)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
			if (this.Darkness.color.a == 0f)
			{
				if (!this.ShowLabel)
				{
					this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, 0f, Time.deltaTime));
					if (this.Label.color.a == 0f)
					{
						if (this.TextPhase < 5)
						{
							this.MainCamera.position = this.CameraDestinations[this.TextPhase].position;
							this.MainCamera.eulerAngles = this.CameraDestinations[this.TextPhase].eulerAngles;
							if (this.TextPhase == 4 && !this.Kissing)
							{
								ParticleSystem.EmissionModule emission = this.Suitor.Hearts.emission;
								emission.enabled = true;
								emission.rateOverTime = 10f;
								this.Suitor.Hearts.Play();
								ParticleSystem.EmissionModule emission2 = this.Rival.Hearts.emission;
								emission2.enabled = true;
								emission2.rateOverTime = 10f;
								this.Rival.Hearts.Play();
								this.Suitor.Character.transform.localScale = new Vector3(1f, 1f, 1f);
								this.Suitor.Character.GetComponent<Animation>().Play("kiss_00");
								this.Suitor.transform.position = this.KissSpot.position;
								this.Rival.Character.GetComponent<Animation>()[this.Rival.ShyAnim].weight = 0f;
								this.Rival.Character.GetComponent<Animation>().Play("f02_kiss_00");
								this.Kissing = true;
							}
							this.Label.text = this.Text[this.TextPhase];
							this.ShowLabel = true;
						}
						else
						{
							this.Phase++;
						}
					}
				}
				else
				{
					this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, 1f, Time.deltaTime));
					if (this.Label.color.a == 1f)
					{
						if (!this.PromptBar.Show)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Continue";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
						}
						if (Input.GetButtonDown("A"))
						{
							this.TextPhase++;
							this.ShowLabel = false;
						}
					}
				}
			}
		}
		else if (this.Phase == 3)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			if (this.Darkness.color.a == 1f)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					PlayerPrefs.SetInt("SuitorProgress", 2);
					this.Suitor.Character.transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);
					this.PromptBar.ClearButtons();
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = false;
					this.ConfessionBG.SetActive(false);
					this.Yandere.FixCamera();
					this.Phase++;
				}
			}
		}
		else
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
			this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 1f, Time.deltaTime);
			if (this.Darkness.color.a == 0f)
			{
				this.Yandere.RPGCamera.enabled = true;
				this.Yandere.CanMove = true;
				this.HeartBeatCamera.SetActive(true);
				this.MythBlossoms.emission.rateOverTime = 20f;
				this.Clock.StopTime = false;
				base.enabled = false;
				this.Suitor.CoupleID = 7;
				this.Suitor.Couple = true;
				this.Rival.CoupleID = 13;
				this.Rival.Couple = true;
			}
		}
		if (this.Kissing)
		{
			Animation component = this.Suitor.Character.GetComponent<Animation>();
			if (component["kiss_00"].time >= component["kiss_00"].length)
			{
				component.CrossFade(this.Suitor.IdleAnim);
				this.Rival.Character.GetComponent<Animation>().CrossFade(this.Rival.IdleAnim);
				this.Kissing = false;
			}
		}
	}
}
