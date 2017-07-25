using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuScript : MonoBehaviour
{
	public ColorCorrectionCurves ColorCorrection;

	public InputManagerScript InputManager;

	public TitleSponsorScript Sponsors;

	public PromptBarScript PromptBar;

	public UISprite[] MediumSprites;

	public UISprite[] LightSprites;

	public UISprite[] DarkSprites;

	public UILabel SimulatorLabel;

	public UILabel[] Labels;

	public Color MediumColor;

	public Color LightColor;

	public Color DarkColor;

	public GameObject BloodProjector;

	public GameObject BloodCamera;

	public GameObject Yandere;

	public GameObject Knife;

	public AudioSource CuteMusic;

	public AudioSource DarkMusic;

	public Renderer[] YandereEye;

	public Material CuteSkybox;

	public Material DarkSkybox;

	public Transform Highlight;

	public Transform[] Spine;

	public Transform[] Arm;

	public AudioSource Jukebox;

	public UISprite Darkness;

	public bool FadeOut;

	public bool Fading = true;

	private int SelectionCount = 9;

	private int Selected;

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
		this.PromptBar.Label[0].text = "Confirm";
		this.PromptBar.Label[1].text = string.Empty;
		this.PromptBar.UpdateButtons();
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
		Time.timeScale = 1f;
		this.MediumColor = this.MediumSprites[0].color;
		this.LightColor = this.LightSprites[0].color;
		this.DarkColor = this.DarkSprites[0].color;
		this.TurnCute();
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, 1f);
		RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
	}

	private void Update()
	{
		if (!this.Sponsors.Show)
		{
			if (!this.Fading)
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
						this.Darkness.color = new Color(0f, 0f, 0f, 0f);
						this.FadeOut = true;
						this.Fading = true;
					}
					if (this.Selected == 2)
					{
						this.Darkness.color = new Color(1f, 1f, 1f, 0f);
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
					this.TurnCute();
				}
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
			else if (!this.FadeOut)
			{
				if (this.Darkness.color.a > 0f)
				{
					this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime);
					if (this.Darkness.color.a <= 0f)
					{
						this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0f);
						this.Fading = false;
					}
				}
			}
			else if (this.Darkness.color.a < 1f)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
				if (this.Darkness.color.a >= 1f)
				{
					if (this.Selected == 0)
					{
						PlayerPrefs.SetInt("MissionMode", 0);
						SceneManager.LoadScene("CalendarScene");
					}
					else if (this.Selected == 2)
					{
						PlayerPrefs.DeleteAll();
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
				this.Jukebox.volume -= Time.deltaTime;
			}
		}
		else
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
			if (Input.GetButtonDown("B"))
			{
				this.Sponsors.Show = false;
				this.PromptBar.Label[0].text = "Confirm";
				this.PromptBar.Label[1].text = string.Empty;
				this.PromptBar.UpdateButtons();
			}
		}
		if (this.Timer < 10f)
		{
			Animation component = this.Yandere.GetComponent<Animation>();
			component["f02_yanderePose_00"].weight = 0f;
			component["f02_fist_00"].weight = 0f;
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
		foreach (UILabel uilabel in this.Labels)
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
		foreach (UILabel uilabel in this.Labels)
		{
			uilabel.color = new Color(1f, 1f, 1f, uilabel.color.a);
		}
		this.SimulatorLabel.color = this.MediumColor;
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
