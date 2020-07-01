using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivingRoomCutsceneScript : MonoBehaviour
{
	public ColorCorrectionCurves ColorCorrection;

	public CosmeticScript YandereCosmetic;

	public AmbientObscurance Obscurance;

	public RivalDataScript RivalData;

	public Vignetting Vignette;

	public NoiseAndGrain Noise;

	public SkinnedMeshRenderer YandereRenderer;

	public Renderer RightEyeRenderer;

	public Renderer LeftEyeRenderer;

	public Transform KettleCameraDestination;

	public Transform KettleCameraOrigin;

	public Transform FriendshipCamera;

	public Transform LivingRoomCamera;

	public Transform CutsceneCamera;

	public Transform TeaCamera;

	public UIPanel EliminationPanel;

	public UIPanel Panel;

	public UISprite SubDarknessBG;

	public UISprite SubDarkness;

	public UISprite Darkness;

	public UILabel PrologueLabel;

	public UILabel Subtitle;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public AudioClip DramaticBoom;

	public AudioClip RivalProtest;

	public AudioSource Jukebox;

	public AudioSource MyAudio;

	public GameObject TeaSteam;

	public GameObject CatStuff;

	public GameObject Prologue;

	public GameObject Yandere;

	public GameObject TeaSet;

	public GameObject Rival;

	public Transform RightEye;

	public Transform LeftEye;

	public float ShakeStrength;

	public float AnimOffset;

	public float EyeShrink;

	public float xOffset;

	public float zOffset;

	public float Timer;

	public float Speed;

	public bool OsanaCutscene;

	public bool DecisionMade;

	public bool DruggedTea;

	public string[] Lines;

	public float[] Times;

	public int Branch = 1;

	public int Phase = 1;

	public int ID = 1;

	public Texture ZTR;

	public int ZTRID;

	private void Start()
	{
		this.YandereCosmetic.SetFemaleUniform();
		this.YandereCosmetic.RightWristband.SetActive(false);
		this.YandereCosmetic.LeftWristband.SetActive(false);
		this.YandereCosmetic.ThickBrows.SetActive(false);
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
		while (this.ID < this.YandereCosmetic.TeacherHair.Length)
		{
			GameObject gameObject2 = this.YandereCosmetic.TeacherHair[this.ID];
			if (gameObject2 != null)
			{
				gameObject2.SetActive(false);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < this.YandereCosmetic.FemaleAccessories.Length)
		{
			GameObject gameObject3 = this.YandereCosmetic.FemaleAccessories[this.ID];
			if (gameObject3 != null)
			{
				gameObject3.SetActive(false);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < this.YandereCosmetic.TeacherAccessories.Length)
		{
			GameObject gameObject4 = this.YandereCosmetic.TeacherAccessories[this.ID];
			if (gameObject4 != null)
			{
				gameObject4.SetActive(false);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < this.YandereCosmetic.ClubAccessories.Length)
		{
			GameObject gameObject5 = this.YandereCosmetic.ClubAccessories[this.ID];
			if (gameObject5 != null)
			{
				gameObject5.SetActive(false);
			}
			this.ID++;
		}
		foreach (GameObject gameObject6 in this.YandereCosmetic.Scanners)
		{
			if (gameObject6 != null)
			{
				gameObject6.SetActive(false);
			}
		}
		foreach (GameObject gameObject7 in this.YandereCosmetic.Flowers)
		{
			if (gameObject7 != null)
			{
				gameObject7.SetActive(false);
			}
		}
		foreach (GameObject gameObject8 in this.YandereCosmetic.PunkAccessories)
		{
			if (gameObject8 != null)
			{
				gameObject8.SetActive(false);
			}
		}
		foreach (GameObject gameObject9 in this.YandereCosmetic.RedCloth)
		{
			if (gameObject9 != null)
			{
				gameObject9.SetActive(false);
			}
		}
		foreach (GameObject gameObject10 in this.YandereCosmetic.Kerchiefs)
		{
			if (gameObject10 != null)
			{
				gameObject10.SetActive(false);
			}
		}
		for (int j = 0; j < 10; j++)
		{
			this.YandereCosmetic.Fingernails[j].gameObject.SetActive(false);
		}
		this.ID = 0;
		this.YandereCosmetic.FemaleHair[1].SetActive(true);
		this.YandereCosmetic.MyRenderer.materials[2].mainTexture = this.YandereCosmetic.DefaultFaceTexture;
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
					if (this.OsanaCutscene)
					{
						this.Yandere.GetComponent<Animation>()["FriendshipYandere"].speed = 0f;
						this.Rival.GetComponent<Animation>()["FriendshipRival"].speed = 0f;
					}
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
				this.MyAudio.Play();
				this.Subtitle.text = this.Lines[0];
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			if (Input.GetKeyDown(KeyCode.Z))
			{
				this.Timer += 2f;
				this.MyAudio.time += 2f;
				if (this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed > 0f)
				{
					this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time += 2f;
				}
			}
			this.Timer += Time.deltaTime;
			if (this.Timer < 166f && !this.OsanaCutscene)
			{
				this.Yandere.GetComponent<Animation>()["FriendshipYandere"].time = this.MyAudio.time + this.AnimOffset;
				this.Rival.GetComponent<Animation>()["FriendshipRival"].time = this.MyAudio.time + this.AnimOffset;
			}
			if (this.ID < this.Times.Length)
			{
				if (this.MyAudio.time > this.Times[this.ID])
				{
					if (this.OsanaCutscene)
					{
						this.Yandere.GetComponent<Animation>()["FriendshipYandere"].time = this.MyAudio.time + this.AnimOffset;
						this.Rival.GetComponent<Animation>()["FriendshipRival"].time = this.MyAudio.time + this.AnimOffset;
					}
					this.Subtitle.text = this.Lines[this.ID];
					this.ID++;
				}
				else if (this.OsanaCutscene && this.Branch == 1)
				{
					if (!this.DruggedTea)
					{
						this.Lines = this.RivalData.OsanaBefriendLines;
						this.Times = this.RivalData.OsanaBefriendTimes;
						this.MyAudio.clip = this.RivalData.OsanaBefriend;
						this.MyAudio.Play();
						this.Branch = 2;
					}
					else
					{
						this.Branch = 3;
					}
				}
			}
			if (this.OsanaCutscene)
			{
				if (this.Branch == 1)
				{
					if (this.ID == 12)
					{
						if (!this.TeaSteam.activeInHierarchy)
						{
							base.transform.parent = null;
							base.transform.position = this.KettleCameraOrigin.position;
							base.transform.rotation = this.KettleCameraOrigin.rotation;
							this.TeaSteam.SetActive(true);
						}
						else
						{
							this.Speed += Time.deltaTime * 0.2f;
							base.transform.position = Vector3.Lerp(base.transform.position, this.KettleCameraDestination.position, Time.deltaTime * this.Speed);
						}
					}
					else if (this.ID > 12 && this.ID < 16)
					{
						base.transform.position = new Vector3(-6f, 1f, 3f);
						base.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
					}
					else if (this.ID > 17 && this.ID < 24 && !this.DecisionMade)
					{
						if (!this.TeaSet.activeInHierarchy)
						{
							base.transform.parent = null;
							base.transform.position = this.TeaCamera.position;
							base.transform.rotation = this.TeaCamera.rotation;
							this.TeaSet.SetActive(true);
							this.Yandere.SetActive(false);
							this.AnimOffset += 2f;
						}
						if (Input.GetButtonDown("A"))
						{
							this.DecisionMade = true;
						}
						if (Input.GetButtonDown("B"))
						{
							this.DecisionMade = true;
							this.DruggedTea = true;
						}
					}
					else
					{
						base.transform.parent = this.FriendshipCamera;
						base.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
						if (this.ID == 16 && this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time < 44f)
						{
							this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time = 44f;
							this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 0f;
						}
					}
				}
				else
				{
					int branch = this.Branch;
				}
			}
			if (!this.OsanaCutscene)
			{
				if (this.MyAudio.time > 54f)
				{
					this.DecreaseYandereEffects();
				}
				else if (this.MyAudio.time > 42f)
				{
					this.IncreaseYandereEffects();
				}
			}
			else if (this.DecisionMade || this.MyAudio.time > 60f)
			{
				this.DecreaseYandereEffects();
			}
			else if (this.MyAudio.time > 43f)
			{
				this.IncreaseYandereEffects();
			}
			if (this.Timer > 167f)
			{
				Animation component = this.Yandere.GetComponent<Animation>();
				component["FriendshipYandere"].speed = -0.2f;
				component.Play("FriendshipYandere");
				component["FriendshipYandere"].time = component["FriendshipYandere"].length;
				this.Subtitle.text = string.Empty;
				this.Phase = 10;
			}
		}
		else if (this.Phase == 6)
		{
			if (!this.MyAudio.isPlaying)
			{
				this.MyAudio.clip = this.DramaticBoom;
				this.MyAudio.Play();
				this.Subtitle.text = string.Empty;
				this.Phase++;
			}
		}
		else if (this.Phase == 7)
		{
			if (!this.MyAudio.isPlaying)
			{
				StudentGlobals.SetStudentKidnapped(81, false);
				StudentGlobals.SetStudentBroken(81, true);
				StudentGlobals.SetStudentKidnapped(30, true);
				StudentGlobals.SetStudentSanity(30, 100f);
				SchoolGlobals.KidnapVictim = 30;
				HomeGlobals.StartInBasement = true;
				SceneManager.LoadScene("CalendarScene");
			}
		}
		else if (this.Phase == 10)
		{
			this.SubDarkness.color = new Color(this.SubDarkness.color.r, this.SubDarkness.color.g, this.SubDarkness.color.b, Mathf.MoveTowards(this.SubDarkness.color.a, 1f, Time.deltaTime * 0.2f));
			if (this.SubDarkness.color.a == 1f)
			{
				StudentGlobals.SetStudentKidnapped(81, false);
				StudentGlobals.SetStudentBroken(81, true);
				SchoolGlobals.KidnapVictim = 0;
				SceneManager.LoadScene("CalendarScene");
			}
		}
		if (Input.GetKeyDown(KeyCode.Minus))
		{
			Time.timeScale -= 1f;
		}
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			Time.timeScale += 1f;
		}
		this.MyAudio.pitch = Time.timeScale;
	}

	private void LateUpdate()
	{
		if (this.Phase > 2)
		{
			if (base.transform.parent != null)
			{
				if (this.FriendshipCamera.position.z > 2.4f)
				{
					base.transform.localPosition = new Vector3(-1.4f + this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f), this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f), this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f));
				}
				else
				{
					base.transform.localPosition = new Vector3(-0.65f + this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f), this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f), this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f));
				}
			}
			this.CutsceneCamera.position = new Vector3(this.CutsceneCamera.position.x + this.xOffset, this.CutsceneCamera.position.y, this.CutsceneCamera.position.z + this.zOffset);
			this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
			this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
			this.LeftEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.LeftEye.localScale.z);
			this.RightEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.RightEye.localScale.z);
		}
	}

	private void IncreaseYandereEffects()
	{
		if (!this.Jukebox.isPlaying)
		{
			this.Jukebox.Play();
		}
		this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0.1f, Time.deltaTime * 0.1f);
		this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, 5f, Time.deltaTime * 4f / 10f);
		this.Vignette.blur = this.Vignette.intensity;
		this.Vignette.chromaticAberration = this.Vignette.intensity;
		this.ColorCorrection.saturation = Mathf.MoveTowards(this.ColorCorrection.saturation, 0f, Time.deltaTime / 10f);
		this.Noise.intensityMultiplier = Mathf.MoveTowards(this.Noise.intensityMultiplier, 3f, Time.deltaTime * 3f / 10f);
		this.Obscurance.intensity = Mathf.MoveTowards(this.Obscurance.intensity, 3f, Time.deltaTime * 3f / 10f);
		if (!this.OsanaCutscene)
		{
			this.ShakeStrength = Mathf.MoveTowards(this.ShakeStrength, 0.01f, Time.deltaTime * 0.01f / 10f);
		}
		this.EyeShrink = Mathf.MoveTowards(this.EyeShrink, 0.9f, Time.deltaTime);
		if (this.MyAudio.time > 45f)
		{
			if (this.MyAudio.time > 54f)
			{
				this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, 0f, Time.deltaTime);
				return;
			}
			if (!this.OsanaCutscene)
			{
				this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, 1f, Time.deltaTime);
				if (Input.GetButtonDown("X"))
				{
					this.MyAudio.clip = this.RivalProtest;
					this.MyAudio.volume = 1f;
					this.MyAudio.Play();
					this.Jukebox.gameObject.SetActive(false);
					this.Subtitle.text = "Wait, what are you doing?! That's not funny! Stop! Let me go! ...n...NO!!!";
					this.SubDarknessBG.color = new Color(this.SubDarknessBG.color.r, this.SubDarknessBG.color.g, this.SubDarknessBG.color.b, 1f);
					this.Phase++;
				}
			}
		}
	}

	private void DecreaseYandereEffects()
	{
		this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0f, Time.deltaTime / 5f);
		this.MyAudio.volume = Mathf.MoveTowards(this.MyAudio.volume, 1f, Time.deltaTime * 0.1f / 5f);
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
}
