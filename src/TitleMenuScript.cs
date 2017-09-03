using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuScript : MonoBehaviour
{
	public ColorCorrectionCurves ColorCorrection;

	public InputManagerScript InputManager;

	public TitleSaveFilesScript SaveFiles;

	public SelectiveGrayscale Grayscale;

	public TitleSponsorScript Sponsors;

	public PromptBarScript PromptBar;

	public SSAOEffect SSAO;

	public JsonScript JSON;

	public UISprite[] MediumSprites;

	public UISprite[] LightSprites;

	public UISprite[] DarkSprites;

	public UILabel SimulatorLabel;

	public UILabel[] ColoredLabels;

	public Color MediumColor;

	public Color LightColor;

	public Color DarkColor;

	public Transform VictimHead;

	public Transform RightHand;

	public Transform TwintailL;

	public Transform TwintailR;

	public Animation LoveSickYandere;

	public GameObject BloodProjector;

	public GameObject LoveSickLogo;

	public GameObject BloodCamera;

	public GameObject Yandere;

	public GameObject Knife;

	public GameObject Logo;

	public GameObject Sun;

	public AudioSource LoveSickMusic;

	public AudioSource CuteMusic;

	public AudioSource DarkMusic;

	public Renderer[] YandereEye;

	public Material CuteSkybox;

	public Material DarkSkybox;

	public Transform Highlight;

	public Transform[] Spine;

	public Transform[] Arm;

	public UISprite Darkness;

	public Vector3 PermaPositionL;

	public Vector3 PermaPositionR;

	public bool LoveSick;

	public bool InEditor;

	public bool FadeOut;

	public bool Turning;

	public bool Fading = true;

	private int SelectionCount = 9;

	public int Selected;

	public float InputTimer;

	public float FadeSpeed = 1f;

	public float LateTimer;

	public float RotationY;

	public float RotationZ;

	public float Volume;

	public float Timer;

	private void Awake()
	{
		Animation component = this.Yandere.GetComponent<Animation>();
		component["f02_yanderePose_00"].layer = 1;
		component.Blend("f02_yanderePose_00");
		component["f02_fist_00"].layer = 2;
		component.Blend("f02_fist_00");
	}

	private void Start()
	{
		if (Globals.LoveSick)
		{
			this.LoveSick = true;
		}
		this.PromptBar.Label[0].text = "Confirm";
		this.PromptBar.Label[1].text = string.Empty;
		this.PromptBar.UpdateButtons();
		this.MediumColor = this.MediumSprites[0].color;
		this.LightColor = this.LightSprites[0].color;
		this.DarkColor = this.DarkSprites[0].color;
		if (!this.LoveSick)
		{
			base.transform.position = new Vector3(base.transform.position.x, 1.2f, base.transform.position.z);
			this.LoveSickLogo.SetActive(false);
			this.LoveSickMusic.volume = 0f;
			this.Grayscale.enabled = false;
			this.SSAO.enabled = false;
			this.Sun.SetActive(true);
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
			this.TurnCute();
			RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, 1f);
			RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
		}
		else
		{
			base.transform.position = new Vector3(base.transform.position.x, 101.2f, base.transform.position.z);
			this.Sun.SetActive(false);
			this.SSAO.enabled = true;
			this.FadeSpeed = 0.2f;
			this.Darkness.color = new Color(0f, 0f, 0f, 1f);
			this.TurnLoveSick();
		}
		Time.timeScale = 1f;
		if (!this.InEditor && this.JSON.Students[33].Name != "Reserved")
		{
			if (Application.CanStreamedLevelBeLoaded("FunScene"))
			{
				SceneManager.LoadScene("FunScene");
			}
			else if (Application.CanStreamedLevelBeLoaded("MoreFunScene"))
			{
				SceneManager.LoadScene("MoreFunScene");
			}
			else
			{
				Application.Quit();
			}
		}
	}

	private void Update()
	{
		if (this.LoveSick)
		{
			this.Timer += Time.deltaTime * 0.001f;
			if (base.transform.position.z > -18f)
			{
				this.LateTimer = Mathf.Lerp(this.LateTimer, this.Timer, Time.deltaTime);
				this.RotationY = Mathf.Lerp(this.RotationY, -22.5f, Time.deltaTime * this.LateTimer);
			}
			this.RotationZ = Mathf.Lerp(this.RotationZ, 22.5f, Time.deltaTime * this.Timer);
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0.33333f, 101.45f, -16.5f), Time.deltaTime * this.Timer);
			base.transform.eulerAngles = new Vector3(0f, this.RotationY, this.RotationZ);
			if (!this.Turning)
			{
				if (base.transform.position.z > -17f)
				{
					this.LoveSickYandere.CrossFade("f02_edgyTurn_00");
					this.VictimHead.parent = this.RightHand;
					this.Turning = true;
				}
			}
			else if (this.LoveSickYandere["f02_edgyTurn_00"].time >= this.LoveSickYandere["f02_edgyTurn_00"].length)
			{
				this.LoveSickYandere.CrossFade("f02_edgyOverShoulder_00");
			}
		}
		if (!this.Sponsors.Show && !this.SaveFiles.Show)
		{
			this.InputTimer += Time.deltaTime;
			if (this.InputTimer > 1f)
			{
				if (this.InputManager.TappedDown)
				{
					this.Selected = ((this.Selected >= this.SelectionCount - 1) ? 0 : (this.Selected + 1));
				}
				if (this.InputManager.TappedUp)
				{
					this.Selected = ((this.Selected <= 0) ? (this.SelectionCount - 1) : (this.Selected - 1));
				}
				bool flag = this.InputManager.TappedUp || this.InputManager.TappedDown;
				if (flag)
				{
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 225f - 75f * (float)this.Selected, this.Highlight.localPosition.z);
				}
				if (Input.GetButtonDown("A"))
				{
					if (this.Selected == 0 || this.Selected == 3 || this.Selected == 6 || this.Selected == 8)
					{
						this.Darkness.color = new Color(0f, 0f, 0f, this.Darkness.color.a);
						this.InputTimer = -10f;
						this.FadeOut = true;
						this.Fading = true;
					}
					if (this.Selected == 1)
					{
						this.PromptBar.Label[0].text = "Load";
						this.PromptBar.Label[1].text = "Back";
						this.PromptBar.Label[2].text = "Delete";
						this.PromptBar.UpdateButtons();
						this.SaveFiles.Show = true;
					}
					if (this.Selected == 2)
					{
						if (!this.LoveSick)
						{
							this.Darkness.color = new Color(1f, 1f, 1f, this.Darkness.color.a);
						}
						this.InputTimer = -10f;
						this.FadeOut = true;
						this.Fading = true;
					}
					if (this.Selected == 4)
					{
						this.PromptBar.Label[0].text = "Visit";
						this.PromptBar.Label[1].text = "Back";
						this.PromptBar.UpdateButtons();
						this.Sponsors.Show = true;
					}
					if (!this.LoveSick)
					{
						this.TurnCute();
					}
				}
				if (Input.GetKeyDown("l"))
				{
					Globals.LoveSick = !Globals.LoveSick;
					SceneManager.LoadScene("TitleScene");
				}
				if (!this.LoveSick)
				{
					if (Input.GetKeyDown("space"))
					{
						this.Timer = 10f;
					}
					this.Timer += Time.deltaTime;
					if (this.Timer > 10f)
					{
						this.TurnDark();
					}
					if (this.Timer > 11f)
					{
						this.TurnCute();
					}
				}
			}
		}
		else
		{
			if (this.Sponsors.Show)
			{
				int sponsorIndex = this.Sponsors.GetSponsorIndex();
				if (this.Sponsors.SponsorHasWebsite(sponsorIndex))
				{
					this.PromptBar.Label[0].text = "Visit";
					this.PromptBar.UpdateButtons();
				}
				else
				{
					this.PromptBar.Label[0].text = string.Empty;
					this.PromptBar.UpdateButtons();
				}
			}
			else if (this.SaveFiles.Show)
			{
				if (this.SaveFiles.SaveDatas[this.SaveFiles.ID].EmptyFile.activeInHierarchy)
				{
					this.PromptBar.Label[0].text = "Create New";
					this.PromptBar.Label[2].text = string.Empty;
					this.PromptBar.UpdateButtons();
				}
				else
				{
					this.PromptBar.Label[0].text = "Load";
					this.PromptBar.Label[2].text = "Delete";
					this.PromptBar.UpdateButtons();
				}
			}
			if (Input.GetButtonDown("B"))
			{
				this.SaveFiles.Show = false;
				this.Sponsors.Show = false;
				this.PromptBar.Label[0].text = "Confirm";
				this.PromptBar.Label[1].text = string.Empty;
				this.PromptBar.Label[2].text = string.Empty;
				this.PromptBar.UpdateButtons();
			}
		}
		if (this.Fading)
		{
			if (!this.FadeOut)
			{
				if (this.Darkness.color.a > 0f)
				{
					this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime * this.FadeSpeed);
					if (this.Darkness.color.a <= 0f)
					{
						this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0f);
						this.Fading = false;
					}
				}
			}
			else if (this.Darkness.color.a < 1f)
			{
				Globals.MissionMode = false;
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
				if (this.Darkness.color.a >= 1f)
				{
					if (this.Selected == 0)
					{
						SceneManager.LoadScene("CalendarScene");
					}
					else if (this.Selected == 1)
					{
						SceneManager.LoadScene("CalendarScene");
					}
					else if (this.Selected == 2)
					{
						Globals.DeleteAll();
						if (this.LoveSick)
						{
							Globals.LoveSick = true;
						}
						SceneManager.LoadScene("SenpaiScene");
					}
					else if (this.Selected == 3)
					{
						SceneManager.LoadScene("MissionModeScene");
					}
					else if (this.Selected == 6)
					{
						SceneManager.LoadScene("CreditsScene");
					}
					else if (this.Selected == 8)
					{
						Application.Quit();
					}
				}
				this.LoveSickMusic.volume -= Time.deltaTime;
				this.CuteMusic.volume -= Time.deltaTime;
			}
		}
		if (this.Timer < 10f)
		{
			Animation component = this.Yandere.GetComponent<Animation>();
			component["f02_yanderePose_00"].weight = 0f;
			component["f02_fist_00"].weight = 0f;
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= 1f;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
		}
	}

	private void LateUpdate()
	{
		if (this.Knife.activeInHierarchy)
		{
			foreach (Transform transform in this.Spine)
			{
				transform.transform.localEulerAngles = new Vector3(transform.transform.localEulerAngles.x + 5f, transform.transform.localEulerAngles.y, transform.transform.localEulerAngles.z);
			}
			Transform transform2 = this.Arm[0];
			transform2.transform.localEulerAngles = new Vector3(transform2.transform.localEulerAngles.x, transform2.transform.localEulerAngles.y, transform2.transform.localEulerAngles.z - 15f);
			Transform transform3 = this.Arm[1];
			transform3.transform.localEulerAngles = new Vector3(transform3.transform.localEulerAngles.x, transform3.transform.localEulerAngles.y, transform3.transform.localEulerAngles.z + 15f);
		}
	}

	private void TurnDark()
	{
		this.SetLayerRecursively(this.Yandere.transform.parent.gameObject, 14);
		Animation component = this.Yandere.GetComponent<Animation>();
		component["f02_yanderePose_00"].weight = 1f;
		component["f02_fist_00"].weight = 1f;
		component.Play("f02_fist_00");
		Renderer renderer = this.YandereEye[0];
		renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 1f);
		Renderer renderer2 = this.YandereEye[1];
		renderer2.material.color = new Color(renderer2.material.color.r, renderer2.material.color.g, renderer2.material.color.b, 1f);
		this.ColorCorrection.enabled = true;
		this.BloodProjector.SetActive(true);
		this.BloodCamera.SetActive(true);
		this.Knife.SetActive(true);
		this.CuteMusic.volume = 0f;
		this.DarkMusic.volume = 1f;
		RenderSettings.ambientLight = new Color(0.5f, 0.5f, 0.5f, 1f);
		RenderSettings.skybox = this.DarkSkybox;
		RenderSettings.fog = true;
		foreach (UISprite uisprite in this.MediumSprites)
		{
			uisprite.color = new Color(1f, 0f, 0f, uisprite.color.a);
		}
		foreach (UISprite uisprite2 in this.LightSprites)
		{
			uisprite2.color = new Color(0f, 0f, 0f, uisprite2.color.a);
		}
		foreach (UISprite uisprite3 in this.DarkSprites)
		{
			uisprite3.color = new Color(0f, 0f, 0f, uisprite3.color.a);
		}
		foreach (UILabel uilabel in this.ColoredLabels)
		{
			uilabel.color = new Color(0f, 0f, 0f, uilabel.color.a);
		}
		this.SimulatorLabel.color = new Color(1f, 0f, 0f, 1f);
	}

	private void TurnCute()
	{
		this.SetLayerRecursively(this.Yandere.transform.parent.gameObject, 9);
		Animation component = this.Yandere.GetComponent<Animation>();
		component["f02_yanderePose_00"].weight = 0f;
		component["f02_fist_00"].weight = 0f;
		component.Stop("f02_fist_00");
		Renderer renderer = this.YandereEye[0];
		renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 0f);
		Renderer renderer2 = this.YandereEye[1];
		renderer2.material.color = new Color(renderer2.material.color.r, renderer2.material.color.g, renderer2.material.color.b, 0f);
		this.ColorCorrection.enabled = false;
		this.BloodProjector.SetActive(false);
		this.BloodCamera.SetActive(false);
		this.Knife.SetActive(false);
		this.CuteMusic.volume = 1f;
		this.DarkMusic.volume = 0f;
		this.Timer = 0f;
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, 1f);
		RenderSettings.skybox = this.CuteSkybox;
		RenderSettings.fog = false;
		foreach (UISprite uisprite in this.MediumSprites)
		{
			uisprite.color = new Color(this.MediumColor.r, this.MediumColor.g, this.MediumColor.b, uisprite.color.a);
		}
		foreach (UISprite uisprite2 in this.LightSprites)
		{
			uisprite2.color = new Color(this.LightColor.r, this.LightColor.g, this.LightColor.b, uisprite2.color.a);
		}
		foreach (UISprite uisprite3 in this.DarkSprites)
		{
			uisprite3.color = new Color(this.DarkColor.r, this.DarkColor.g, this.DarkColor.b, uisprite3.color.a);
		}
		foreach (UILabel uilabel in this.ColoredLabels)
		{
			uilabel.color = new Color(1f, 1f, 1f, uilabel.color.a);
		}
		this.SimulatorLabel.color = this.MediumColor;
	}

	private void TurnLoveSick()
	{
		RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.25f, 1f);
		this.CuteMusic.volume = 0f;
		this.DarkMusic.volume = 0f;
		this.LoveSickMusic.volume = 1f;
		foreach (UISprite uisprite in this.MediumSprites)
		{
			uisprite.color = new Color(0f, 0f, 0f, uisprite.color.a);
		}
		foreach (UISprite uisprite2 in this.LightSprites)
		{
			uisprite2.color = new Color(1f, 0f, 0f, uisprite2.color.a);
		}
		foreach (UISprite uisprite3 in this.DarkSprites)
		{
			uisprite3.color = new Color(1f, 0f, 0f, uisprite3.color.a);
		}
		foreach (UILabel uilabel in this.ColoredLabels)
		{
			uilabel.color = new Color(1f, 0f, 0f, uilabel.color.a);
		}
		this.LoveSickLogo.SetActive(true);
		this.Logo.SetActive(false);
	}

	private void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		IEnumerator enumerator = obj.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj2 = enumerator.Current;
				Transform transform = (Transform)obj2;
				this.SetLayerRecursively(transform.gameObject, newLayer);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}
}
