using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class LivingRoomCutsceneScript : MonoBehaviour
{
	public ColorCorrectionCurves ColorCorrection;

	public AmbientObscurance Obscurance;

	public Vignetting Vignette;

	public NoiseAndGrain Noise;

	public SkinnedMeshRenderer YandereRenderer;

	public Transform FriendshipCamera;

	public Transform LivingRoomCamera;

	public Transform CutsceneCamera;

	public UIPanel EliminationPanel;

	public UISprite SubDarknessBG;

	public UISprite SubDarkness;

	public UISprite Darkness;

	public UILabel Subtitle;

	public UIPanel Panel;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public AudioClip DramaticBoom;

	public AudioClip RivalProtest;

	public AudioSource Jukebox;

	public GameObject Prologue;

	public GameObject Yandere;

	public GameObject Rival;

	public Transform RightEye;

	public Transform LeftEye;

	public float ShakeStrength;

	public float AnimOffset;

	public float EyeShrink;

	public float xOffset;

	public float zOffset;

	public float Timer;

	public string[] Lines;

	public float[] Times;

	public int Phase;

	public int ID;

	public Texture ZTR;

	public int ZTRID;

	public LivingRoomCutsceneScript()
	{
		this.Phase = 1;
		this.ID = 1;
	}

	public virtual void Start()
	{
		this.Subtitle.text = string.Empty;
		this.RightEyeOrigin = this.RightEye.localPosition;
		this.LeftEyeOrigin = this.LeftEye.localPosition;
		this.EliminationPanel.alpha = (float)0;
		this.Panel.alpha = (float)1;
		this.ColorCorrection.saturation = (float)1;
		this.Noise.intensityMultiplier = (float)0;
		this.Obscurance.intensity = (float)0;
		this.Vignette.enabled = false;
		this.Vignette.intensity = (float)1;
		this.Vignette.blur = (float)1;
		this.Vignette.chromaticAberration = (float)1;
	}

	public virtual void Update()
	{
		if (this.Phase == 1)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)1)
			{
				float a = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
				Color color = this.Darkness.color;
				float num = color.a = a;
				Color color2 = this.Darkness.color = color;
				if (this.Darkness.color.a == (float)0 && Input.GetButtonDown("A"))
				{
					this.Timer = (float)0;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 2)
		{
			float a2 = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
			Color color3 = this.Darkness.color;
			float num2 = color3.a = a2;
			Color color4 = this.Darkness.color = color3;
			if (this.Darkness.color.a == (float)1)
			{
				this.transform.parent = this.LivingRoomCamera;
				this.transform.localPosition = new Vector3(-0.65f, (float)0, (float)0);
				this.transform.localEulerAngles = new Vector3((float)0, (float)-90, (float)0);
				this.Vignette.enabled = true;
				this.Prologue.active = false;
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)1)
			{
				this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, (float)0, Time.deltaTime);
				if (this.Panel.alpha == (float)0)
				{
					this.Yandere.animation["FriendshipYandere"].time = (float)0;
					this.Rival.animation["FriendshipRival"].time = (float)0;
					this.LivingRoomCamera.gameObject.animation.Play();
					this.Timer = (float)0;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 4)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)10)
			{
				this.transform.parent = this.FriendshipCamera;
				this.transform.localPosition = new Vector3(-0.65f, (float)0, (float)0);
				this.transform.localEulerAngles = new Vector3((float)0, (float)-90, (float)0);
				this.FriendshipCamera.gameObject.animation.Play();
				this.audio.Play();
				this.Subtitle.text = this.Lines[0];
				this.Timer = (float)0;
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			if (Input.GetKeyDown("space"))
			{
				this.Timer += (float)10;
				this.audio.time = this.audio.time + (float)10;
				this.FriendshipCamera.gameObject.animation["FriendshipCameraFlat"].time = this.FriendshipCamera.gameObject.animation["FriendshipCameraFlat"].time + (float)10;
			}
			this.Timer += Time.deltaTime;
			if (this.Timer < (float)166)
			{
				this.Yandere.animation["FriendshipYandere"].time = this.audio.time + this.AnimOffset;
				this.Rival.animation["FriendshipRival"].time = this.audio.time + this.AnimOffset;
			}
			if (this.ID < Extensions.get_length(this.Times) && this.audio.time > this.Times[this.ID])
			{
				this.Subtitle.text = this.Lines[this.ID];
				this.ID++;
			}
			if (this.audio.time > (float)54)
			{
				this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, (float)0, Time.deltaTime * (float)1 / (float)5);
				this.audio.volume = Mathf.MoveTowards(this.audio.volume, 0.2f, Time.deltaTime * 0.1f / (float)5);
				this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, (float)1, Time.deltaTime * (float)4 / (float)5);
				this.Vignette.blur = this.Vignette.intensity;
				this.Vignette.chromaticAberration = this.Vignette.intensity;
				this.ColorCorrection.saturation = Mathf.MoveTowards(this.ColorCorrection.saturation, (float)1, Time.deltaTime * (float)1 / (float)5);
				this.Noise.intensityMultiplier = Mathf.MoveTowards(this.Noise.intensityMultiplier, (float)0, Time.deltaTime * (float)3 / (float)5);
				this.Obscurance.intensity = Mathf.MoveTowards(this.Obscurance.intensity, (float)0, Time.deltaTime * (float)3 / (float)5);
				this.ShakeStrength = Mathf.MoveTowards(this.ShakeStrength, (float)0, Time.deltaTime * 0.01f / (float)5);
				this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, (float)0, Time.deltaTime);
				this.EyeShrink = Mathf.MoveTowards(this.EyeShrink, (float)0, Time.deltaTime);
			}
			else if (this.audio.time > (float)42)
			{
				if (!this.Jukebox.isPlaying)
				{
					this.Jukebox.Play();
				}
				this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, (float)1, Time.deltaTime * (float)1 / (float)10);
				this.audio.volume = Mathf.MoveTowards(this.audio.volume, 0.1f, Time.deltaTime * 0.1f / (float)10);
				this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, (float)5, Time.deltaTime * (float)4 / (float)10);
				this.Vignette.blur = this.Vignette.intensity;
				this.Vignette.chromaticAberration = this.Vignette.intensity;
				this.ColorCorrection.saturation = Mathf.MoveTowards(this.ColorCorrection.saturation, (float)0, Time.deltaTime * (float)1 / (float)10);
				this.Noise.intensityMultiplier = Mathf.MoveTowards(this.Noise.intensityMultiplier, (float)3, Time.deltaTime * (float)3 / (float)10);
				this.Obscurance.intensity = Mathf.MoveTowards(this.Obscurance.intensity, (float)3, Time.deltaTime * (float)3 / (float)10);
				this.ShakeStrength = Mathf.MoveTowards(this.ShakeStrength, 0.01f, Time.deltaTime * 0.01f / (float)10);
				this.EyeShrink = Mathf.MoveTowards(this.EyeShrink, 0.9f, Time.deltaTime);
				if (this.audio.time > (float)45)
				{
					if (this.audio.time > (float)54)
					{
						this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, (float)0, Time.deltaTime);
					}
					else
					{
						this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, (float)1, Time.deltaTime);
						if (Input.GetButtonDown("X"))
						{
							this.audio.clip = this.RivalProtest;
							this.audio.volume = (float)1;
							this.audio.Play();
							this.Jukebox.active = false;
							this.Subtitle.text = "Wait, what are you doing?! That's not funny! Stop! Let me go! ...n...NO!!!";
							int num3 = 1;
							Color color5 = this.SubDarknessBG.color;
							float num4 = color5.a = (float)num3;
							Color color6 = this.SubDarknessBG.color = color5;
							this.Phase++;
						}
					}
				}
			}
			if (this.Timer > (float)167)
			{
				this.Yandere.animation["FriendshipYandere"].speed = -0.2f;
				this.Yandere.animation.Play("FriendshipYandere");
				this.Yandere.animation["FriendshipYandere"].time = this.Yandere.animation["FriendshipYandere"].length;
				this.Subtitle.text = string.Empty;
				this.Phase = 10;
			}
		}
		else if (this.Phase == 6)
		{
			if (!this.audio.isPlaying)
			{
				this.audio.clip = this.DramaticBoom;
				this.audio.Play();
				this.Subtitle.text = string.Empty;
				this.Phase++;
			}
		}
		else if (this.Phase == 7)
		{
			if (!this.audio.isPlaying)
			{
				PlayerPrefs.SetInt("Student_32_Kidnapped", 0);
				PlayerPrefs.SetInt("Student_32_Broken", 1);
				PlayerPrefs.SetInt("Student_7_Kidnapped", 1);
				PlayerPrefs.SetFloat("Student_7_Sanity", 100f);
				PlayerPrefs.SetInt("KidnapVictim", 7);
				PlayerPrefs.SetInt("StartInBasement", 1);
				Application.LoadLevel("CalendarScene");
			}
		}
		else if (this.Phase == 10)
		{
			float a3 = Mathf.MoveTowards(this.SubDarkness.color.a, (float)1, Time.deltaTime * 0.2f);
			Color color7 = this.SubDarkness.color;
			float num5 = color7.a = a3;
			Color color8 = this.SubDarkness.color = color7;
			if (this.SubDarkness.color.a == (float)1)
			{
				PlayerPrefs.SetInt("Student_32_Kidnapped", 0);
				PlayerPrefs.SetInt("Student_32_Broken", 1);
				PlayerPrefs.SetInt("KidnapVictim", 0);
				Application.LoadLevel("CalendarScene");
			}
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= (float)1;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += (float)1;
		}
		this.audio.pitch = Time.timeScale;
	}

	public virtual void LateUpdate()
	{
		float x = -0.65f + this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f);
		Vector3 localPosition = this.transform.localPosition;
		float num = localPosition.x = x;
		Vector3 vector = this.transform.localPosition = localPosition;
		float y = this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f);
		Vector3 localPosition2 = this.transform.localPosition;
		float num2 = localPosition2.y = y;
		Vector3 vector2 = this.transform.localPosition = localPosition2;
		float z = this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f);
		Vector3 localPosition3 = this.transform.localPosition;
		float num3 = localPosition3.z = z;
		Vector3 vector3 = this.transform.localPosition = localPosition3;
		float x2 = this.CutsceneCamera.position.x + this.xOffset;
		Vector3 position = this.CutsceneCamera.position;
		float num4 = position.x = x2;
		Vector3 vector4 = this.CutsceneCamera.position = position;
		float z2 = this.CutsceneCamera.position.z + this.zOffset;
		Vector3 position2 = this.CutsceneCamera.position;
		float num5 = position2.z = z2;
		Vector3 vector5 = this.CutsceneCamera.position = position2;
		float z3 = this.LeftEyeOrigin.z - this.EyeShrink * 0.01f;
		Vector3 localPosition4 = this.LeftEye.localPosition;
		float num6 = localPosition4.z = z3;
		Vector3 vector6 = this.LeftEye.localPosition = localPosition4;
		float z4 = this.RightEyeOrigin.z + this.EyeShrink * 0.01f;
		Vector3 localPosition5 = this.RightEye.localPosition;
		float num7 = localPosition5.z = z4;
		Vector3 vector7 = this.RightEye.localPosition = localPosition5;
		float x3 = (float)1 - this.EyeShrink * 0.5f;
		Vector3 localScale = this.LeftEye.localScale;
		float num8 = localScale.x = x3;
		Vector3 vector8 = this.LeftEye.localScale = localScale;
		float y2 = (float)1 - this.EyeShrink * 0.5f;
		Vector3 localScale2 = this.LeftEye.localScale;
		float num9 = localScale2.y = y2;
		Vector3 vector9 = this.LeftEye.localScale = localScale2;
		float x4 = (float)1 - this.EyeShrink * 0.5f;
		Vector3 localScale3 = this.RightEye.localScale;
		float num10 = localScale3.x = x4;
		Vector3 vector10 = this.RightEye.localScale = localScale3;
		float y3 = (float)1 - this.EyeShrink * 0.5f;
		Vector3 localScale4 = this.RightEye.localScale;
		float num11 = localScale4.y = y3;
		Vector3 vector11 = this.RightEye.localScale = localScale4;
	}

	public virtual void Main()
	{
	}
}
