using System;
using UnityEngine;

[Serializable]
public class ConfessionSceneScript : MonoBehaviour
{
	public Transform[] CameraDestinations;

	public StudentManagerScript StudentManager;

	public PromptBarScript PromptBar;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public ClockScript Clock;

	public Bloom BloomEffect;

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

	public int TextPhase;

	public int Phase;

	public float Timer;

	public ConfessionSceneScript()
	{
		this.TextPhase = 1;
		this.Phase = 1;
	}

	public virtual void Update()
	{
		if (this.Phase == 1)
		{
			float a = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
			Color color = this.Darkness.color;
			float num = color.a = a;
			Color color2 = this.Darkness.color = color;
			this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, (float)0, Time.deltaTime);
			this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, (float)0, Time.deltaTime);
			if (this.Darkness.color.a == (float)1)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)1)
				{
					this.BloomEffect.bloomIntensity = (float)1;
					this.BloomEffect.bloomThreshhold = (float)0;
					this.BloomEffect.bloomBlurIterations = 1;
					this.StudentManager.Students[7].transform.position = this.RivalSpot.position;
					this.StudentManager.Students[7].transform.eulerAngles = this.RivalSpot.eulerAngles;
					this.StudentManager.Students[13].Cosmetic.MyRenderer.materials[this.StudentManager.Students[13].Cosmetic.FaceID].SetFloat("_BlendAmount", (float)1);
					this.StudentManager.Students[13].transform.eulerAngles = this.StudentManager.SuitorConfessionSpot.eulerAngles;
					this.StudentManager.Students[13].transform.position = this.StudentManager.SuitorConfessionSpot.position;
					this.StudentManager.Students[13].Character.animation.Play(this.StudentManager.Students[13].IdleAnim);
					this.MythBlossoms.emissionRate = (float)100;
					this.HeartBeatCamera.active = false;
					this.ConfessionBG.active = true;
					this.audio.Play();
					this.MainCamera.position = this.CameraDestinations[1].position;
					this.MainCamera.eulerAngles = this.CameraDestinations[1].eulerAngles;
					this.Timer = (float)0;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 2)
		{
			float a2 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
			Color color3 = this.Darkness.color;
			float num2 = color3.a = a2;
			Color color4 = this.Darkness.color = color3;
			if (this.Darkness.color.a == (float)0)
			{
				if (!this.ShowLabel)
				{
					float a3 = Mathf.MoveTowards(this.Label.color.a, (float)0, Time.deltaTime);
					Color color5 = this.Label.color;
					float num3 = color5.a = a3;
					Color color6 = this.Label.color = color5;
					if (this.Label.color.a == (float)0)
					{
						if (this.TextPhase < 5)
						{
							this.MainCamera.position = this.CameraDestinations[this.TextPhase].position;
							this.MainCamera.eulerAngles = this.CameraDestinations[this.TextPhase].eulerAngles;
							if (this.TextPhase == 4 && !this.Kissing)
							{
								this.StudentManager.Students[13].Hearts.enableEmission = true;
								this.StudentManager.Students[13].Hearts.emissionRate = (float)10;
								this.StudentManager.Students[13].Hearts.Play();
								this.StudentManager.Students[7].Hearts.enableEmission = true;
								this.StudentManager.Students[7].Hearts.emissionRate = (float)10;
								this.StudentManager.Students[7].Hearts.Play();
								this.StudentManager.Students[13].Character.transform.localScale = new Vector3((float)1, (float)1, (float)1);
								this.StudentManager.Students[13].Character.animation.Play("kiss_00");
								this.StudentManager.Students[13].transform.position = this.KissSpot.position;
								this.StudentManager.Students[7].Character.animation[this.StudentManager.Students[7].ShyAnim].weight = (float)0;
								this.StudentManager.Students[7].Character.animation.Play("f02_kiss_00");
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
					float a4 = Mathf.MoveTowards(this.Label.color.a, (float)1, Time.deltaTime);
					Color color7 = this.Label.color;
					float num4 = color7.a = a4;
					Color color8 = this.Label.color = color7;
					if (this.Label.color.a == (float)1)
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
			float a5 = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
			Color color9 = this.Darkness.color;
			float num5 = color9.a = a5;
			Color color10 = this.Darkness.color = color9;
			if (this.Darkness.color.a == (float)1)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)1)
				{
					PlayerPrefs.SetInt("SuitorProgress", 2);
					this.StudentManager.Students[13].Character.transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);
					this.PromptBar.ClearButtons();
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = false;
					this.ConfessionBG.active = false;
					this.Yandere.FixCamera();
					this.Phase++;
				}
			}
		}
		else
		{
			float a6 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
			Color color11 = this.Darkness.color;
			float num6 = color11.a = a6;
			Color color12 = this.Darkness.color = color11;
			this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, (float)1, Time.deltaTime);
			if (this.Darkness.color.a == (float)0)
			{
				this.Yandere.RPGCamera.enabled = true;
				this.Yandere.CanMove = true;
				this.HeartBeatCamera.active = true;
				this.MythBlossoms.emissionRate = (float)20;
				this.Clock.StopTime = false;
				this.enabled = false;
			}
		}
		if (this.Kissing && this.StudentManager.Students[13].Character.animation["kiss_00"].time >= this.StudentManager.Students[13].Character.animation["kiss_00"].length)
		{
			this.StudentManager.Students[13].Character.animation.CrossFade(this.StudentManager.Students[13].IdleAnim);
			this.StudentManager.Students[7].Character.animation.CrossFade(this.StudentManager.Students[7].IdleAnim);
			this.Kissing = false;
		}
	}

	public virtual void Main()
	{
	}
}
