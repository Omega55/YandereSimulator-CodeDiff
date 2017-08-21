using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivingRoomCutsceneScript : MonoBehaviour
{
	public ColorCorrectionCurves ColorCorrection;

	public CosmeticScript YandereCosmetic;

	public AmbientObscurance Obscurance;

	public Vignetting Vignette;

	public NoiseAndGrain Noise;

	public SkinnedMeshRenderer YandereRenderer;

	public Renderer RightEyeRenderer;

	public Renderer LeftEyeRenderer;

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

	public int Phase = 1;

	public int ID = 1;

	public Texture ZTR;

	public int ZTRID;

	private void Start()
	{
		this.YandereCosmetic.SetFemaleUniform();
		this.ID = 0;
		while (this.ID < this.YandereCosmetic.FemaleHair.Length)
		{
			GameObject gameObject = this.YandereCosmetic.FemaleHair[this.ID];
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
			this.ID++;
		}
		this.ID = 0;
		this.YandereCosmetic.FemaleHair[1].SetActive(true);
		this.Subtitle.text = string.Empty;
		this.RightEyeRenderer.material.color = new Color(0.33f, 0.33f, 0.33f, 1f);
		this.LeftEyeRenderer.material.color = new Color(0.33f, 0.33f, 0.33f, 1f);
		this.RightEyeOrigin = this.RightEye.localPosition;
		this.LeftEyeOrigin = this.LeftEye.localPosition;
		this.EliminationPanel.alpha = 0f;
		this.Panel.alpha = 1f;
		this.ColorCorrection.saturation = 1f;
		this.Noise.intensityMultiplier = 0f;
		this.Obscurance.intensity = 0f;
		this.Vignette.enabled = false;
		this.Vignette.intensity = 1f;
		this.Vignette.blur = 1f;
		this.Vignette.chromaticAberration = 1f;
	}

	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (this.Phase == 1)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				if (this.Darkness.color.a == 0f && Input.GetButtonDown("A"))
				{
					this.Timer = 0f;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 2)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			if (this.Darkness.color.a == 1f)
			{
				base.transform.parent = this.LivingRoomCamera;
				base.transform.localPosition = new Vector3(-0.65f, 0f, 0f);
				base.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
				this.Vignette.enabled = true;
				this.Prologue.SetActive(false);
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 0f, Time.deltaTime);
				if (this.Panel.alpha == 0f)
				{
					this.Yandere.GetComponent<Animation>()["FriendshipYandere"].time = 0f;
					this.Rival.GetComponent<Animation>()["FriendshipRival"].time = 0f;
					this.LivingRoomCamera.gameObject.GetComponent<Animation>().Play();
					this.Timer = 0f;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 4)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 10f)
			{
				base.transform.parent = this.FriendshipCamera;
				base.transform.localPosition = new Vector3(-0.65f, 0f, 0f);
				base.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
				this.FriendshipCamera.gameObject.GetComponent<Animation>().Play();
				component.Play();
				this.Subtitle.text = this.Lines[0];
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			if (Input.GetKeyDown("space"))
			{
				this.Timer += 10f;
				component.time += 10f;
				this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time += 10f;
			}
			this.Timer += Time.deltaTime;
			if (this.Timer < 166f)
			{
				this.Yandere.GetComponent<Animation>()["FriendshipYandere"].time = component.time + this.AnimOffset;
				this.Rival.GetComponent<Animation>()["FriendshipRival"].time = component.time + this.AnimOffset;
			}
			if (this.ID < this.Times.Length)
			{
				Debug.Log(component.time);
				if (component.time > this.Times[this.ID])
				{
					this.Subtitle.text = this.Lines[this.ID];
					this.ID++;
				}
			}
			if (component.time > 54f)
			{
				this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0f, Time.deltaTime / 5f);
				component.volume = Mathf.MoveTowards(component.volume, 0.2f, Time.deltaTime * 0.1f / 5f);
				this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, 1f, Time.deltaTime * 4f / 5f);
				this.Vignette.blur = this.Vignette.intensity;
				this.Vignette.chromaticAberration = this.Vignette.intensity;
				this.ColorCorrection.saturation = Mathf.MoveTowards(this.ColorCorrection.saturation, 1f, Time.deltaTime / 5f);
				this.Noise.intensityMultiplier = Mathf.MoveTowards(this.Noise.intensityMultiplier, 0f, Time.deltaTime * 3f / 5f);
				this.Obscurance.intensity = Mathf.MoveTowards(this.Obscurance.intensity, 0f, Time.deltaTime * 3f / 5f);
				this.ShakeStrength = Mathf.MoveTowards(this.ShakeStrength, 0f, Time.deltaTime * 0.01f / 5f);
				this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, 0f, Time.deltaTime);
				this.EyeShrink = Mathf.MoveTowards(this.EyeShrink, 0f, Time.deltaTime);
			}
			else if (component.time > 42f)
			{
				if (!this.Jukebox.isPlaying)
				{
					this.Jukebox.Play();
				}
				this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 1f, Time.deltaTime / 10f);
				component.volume = Mathf.MoveTowards(component.volume, 0.1f, Time.deltaTime * 0.1f / 10f);
				this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, 5f, Time.deltaTime * 4f / 10f);
				this.Vignette.blur = this.Vignette.intensity;
				this.Vignette.chromaticAberration = this.Vignette.intensity;
				this.ColorCorrection.saturation = Mathf.MoveTowards(this.ColorCorrection.saturation, 0f, Time.deltaTime / 10f);
				this.Noise.intensityMultiplier = Mathf.MoveTowards(this.Noise.intensityMultiplier, 3f, Time.deltaTime * 3f / 10f);
				this.Obscurance.intensity = Mathf.MoveTowards(this.Obscurance.intensity, 3f, Time.deltaTime * 3f / 10f);
				this.ShakeStrength = Mathf.MoveTowards(this.ShakeStrength, 0.01f, Time.deltaTime * 0.01f / 10f);
				this.EyeShrink = Mathf.MoveTowards(this.EyeShrink, 0.9f, Time.deltaTime);
				if (component.time > 45f)
				{
					if (component.time > 54f)
					{
						this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, 0f, Time.deltaTime);
					}
					else
					{
						this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, 1f, Time.deltaTime);
						if (Input.GetButtonDown("X"))
						{
							component.clip = this.RivalProtest;
							component.volume = 1f;
							component.Play();
							this.Jukebox.gameObject.SetActive(false);
							this.Subtitle.text = "Wait, what are you doing?! That's not funny! Stop! Let me go! ...n...NO!!!";
							this.SubDarknessBG.color = new Color(this.SubDarknessBG.color.r, this.SubDarknessBG.color.g, this.SubDarknessBG.color.b, 1f);
							this.Phase++;
						}
					}
				}
			}
			if (this.Timer > 167f)
			{
				Animation component2 = this.Yandere.GetComponent<Animation>();
				component2["FriendshipYandere"].speed = -0.2f;
				component2.Play("FriendshipYandere");
				component2["FriendshipYandere"].time = component2["FriendshipYandere"].length;
				this.Subtitle.text = string.Empty;
				this.Phase = 10;
			}
		}
		else if (this.Phase == 6)
		{
			if (!component.isPlaying)
			{
				component.clip = this.DramaticBoom;
				component.Play();
				this.Subtitle.text = string.Empty;
				this.Phase++;
			}
		}
		else if (this.Phase == 7)
		{
			if (!component.isPlaying)
			{
				Globals.SetStudentKidnapped(32, false);
				Globals.SetStudentBroken(32, true);
				Globals.SetStudentKidnapped(7, true);
				Globals.SetStudentSanity(7, 100f);
				Globals.KidnapVictim = 7;
				Globals.StartInBasement = true;
				SceneManager.LoadScene("CalendarScene");
			}
		}
		else if (this.Phase == 10)
		{
			this.SubDarkness.color = new Color(this.SubDarkness.color.r, this.SubDarkness.color.g, this.SubDarkness.color.b, Mathf.MoveTowards(this.SubDarkness.color.a, 1f, Time.deltaTime * 0.2f));
			if (this.SubDarkness.color.a == 1f)
			{
				Globals.SetStudentKidnapped(32, false);
				Globals.SetStudentBroken(32, true);
				Globals.KidnapVictim = 0;
				SceneManager.LoadScene("CalendarScene");
			}
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= 1f;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
		}
		component.pitch = Time.timeScale;
	}

	private void LateUpdate()
	{
		if (this.Phase > 2)
		{
			base.transform.localPosition = new Vector3(-0.65f + this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f), this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f), this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f));
			this.CutsceneCamera.position = new Vector3(this.CutsceneCamera.position.x + this.xOffset, this.CutsceneCamera.position.y, this.CutsceneCamera.position.z + this.zOffset);
			this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
			this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
			this.LeftEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.LeftEye.localScale.z);
			this.RightEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.RightEye.localScale.z);
		}
	}
}
