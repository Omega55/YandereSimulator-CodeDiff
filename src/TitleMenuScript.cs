using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
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

	public bool FirstCute;

	public bool Inactive;

	public bool FadeOut;

	public bool Fading;

	public int Selected;

	public float Timer;

	public TitleMenuScript()
	{
		this.Fading = true;
		this.Selected = 1;
	}

	public virtual void Start()
	{
		this.PromptBar.Label[0].text = "Confirm";
		this.PromptBar.Label[1].text = string.Empty;
		this.PromptBar.UpdateButtons();
		int num = 1;
		Color color = this.Darkness.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Darkness.color = color;
		this.MediumColor = this.MediumSprites[0].color;
		this.LightColor = this.LightSprites[0].color;
		this.DarkColor = this.DarkSprites[0].color;
		this.TurnCute();
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, (float)1);
		RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
	}

	public virtual void Update()
	{
		if (!this.Inactive)
		{
			if (!this.Fading)
			{
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected > 7)
					{
						this.Selected = 1;
					}
					int num = 300 - 75 * this.Selected;
					Vector3 localPosition = this.Highlight.localPosition;
					float num2 = localPosition.y = (float)num;
					Vector3 vector = this.Highlight.localPosition = localPosition;
				}
				if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = 7;
					}
					int num3 = 300 - 75 * this.Selected;
					Vector3 localPosition2 = this.Highlight.localPosition;
					float num4 = localPosition2.y = (float)num3;
					Vector3 vector2 = this.Highlight.localPosition = localPosition2;
				}
				if (Input.GetButtonDown("A"))
				{
					if (this.Selected == 1 || this.Selected == 7)
					{
						this.Darkness.color = new Color((float)0, (float)0, (float)0, (float)0);
						this.FadeOut = true;
						this.Fading = true;
					}
					if (this.Selected == 4)
					{
						this.PromptBar.Label[0].text = "Visit";
						this.PromptBar.Label[1].text = "Back";
						this.PromptBar.UpdateButtons();
						this.Sponsors.Show = true;
						this.Inactive = true;
					}
					this.TurnCute();
				}
				if (Input.GetKeyDown("space"))
				{
					this.Timer = (float)10;
				}
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)10)
				{
					this.TurnDark();
				}
				if (this.Timer > (float)11)
				{
					this.TurnCute();
				}
			}
			else if (!this.FadeOut)
			{
				if (this.Darkness.color.a > (float)0)
				{
					float a = this.Darkness.color.a - Time.deltaTime;
					Color color = this.Darkness.color;
					float num5 = color.a = a;
					Color color2 = this.Darkness.color = color;
					if (this.Darkness.color.a <= (float)0)
					{
						int num6 = 0;
						Color color3 = this.Darkness.color;
						float num7 = color3.a = (float)num6;
						Color color4 = this.Darkness.color = color3;
						this.Fading = false;
					}
				}
			}
			else if (this.Darkness.color.a < (float)1)
			{
				float a2 = this.Darkness.color.a + Time.deltaTime;
				Color color5 = this.Darkness.color;
				float num8 = color5.a = a2;
				Color color6 = this.Darkness.color = color5;
				if (this.Darkness.color.a >= (float)1)
				{
					if (this.Selected == 1)
					{
						Application.LoadLevel("CalendarScene");
					}
					if (this.Selected == 7)
					{
						Application.Quit();
					}
				}
				this.Jukebox.volume = this.Jukebox.volume - Time.deltaTime;
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			this.Sponsors.Show = false;
			this.PromptBar.Label[0].text = "Confirm";
			this.PromptBar.Label[1].text = string.Empty;
			this.PromptBar.UpdateButtons();
			this.Inactive = false;
		}
		if (this.Timer < (float)10)
		{
			this.Yandere.animation["f02_yanderePose_00"].weight = (float)0;
			this.Yandere.animation["f02_fist_00"].weight = (float)0;
		}
	}

	public virtual void LateUpdate()
	{
		if (this.Knife.active)
		{
			for (int i = 0; i < this.Spine.Length; i++)
			{
				float x = this.Spine[i].transform.localEulerAngles.x + (float)5;
				Vector3 localEulerAngles = this.Spine[i].transform.localEulerAngles;
				float num = localEulerAngles.x = x;
				Vector3 vector = this.Spine[i].transform.localEulerAngles = localEulerAngles;
			}
			float z = this.Arm[0].transform.localEulerAngles.z - (float)15;
			Vector3 localEulerAngles2 = this.Arm[0].transform.localEulerAngles;
			float num2 = localEulerAngles2.z = z;
			Vector3 vector2 = this.Arm[0].transform.localEulerAngles = localEulerAngles2;
			float z2 = this.Arm[1].transform.localEulerAngles.z + (float)15;
			Vector3 localEulerAngles3 = this.Arm[1].transform.localEulerAngles;
			float num3 = localEulerAngles3.z = z2;
			Vector3 vector3 = this.Arm[1].transform.localEulerAngles = localEulerAngles3;
		}
	}

	public virtual void TurnDark()
	{
		this.SetLayerRecursively(this.Yandere.transform.parent.gameObject, 14);
		this.Yandere.animation["f02_yanderePose_00"].weight = (float)1;
		this.Yandere.animation["f02_fist_00"].weight = (float)1;
		int num = 1;
		Color color = this.YandereEye[0].material.color;
		float num2 = color.a = (float)num;
		Color color2 = this.YandereEye[0].material.color = color;
		int num3 = 1;
		Color color3 = this.YandereEye[1].material.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.YandereEye[1].material.color = color3;
		this.ColorCorrection.enabled = true;
		this.BloodProjector.active = true;
		this.BloodCamera.active = true;
		this.Knife.active = true;
		this.CuteMusic.pitch = 0.75f;
		RenderSettings.ambientLight = new Color(0.5f, 0.5f, 0.5f, (float)1);
		RenderSettings.skybox = this.DarkSkybox;
		RenderSettings.fog = true;
		for (int i = 0; i < Extensions.get_length(this.MediumSprites); i++)
		{
			int num5 = 1;
			Color color5 = this.MediumSprites[i].color;
			float num6 = color5.r = (float)num5;
			Color color6 = this.MediumSprites[i].color = color5;
			int num7 = 0;
			Color color7 = this.MediumSprites[i].color;
			float num8 = color7.g = (float)num7;
			Color color8 = this.MediumSprites[i].color = color7;
			int num9 = 0;
			Color color9 = this.MediumSprites[i].color;
			float num10 = color9.b = (float)num9;
			Color color10 = this.MediumSprites[i].color = color9;
		}
		for (int i = 0; i < Extensions.get_length(this.LightSprites); i++)
		{
			int num11 = 0;
			Color color11 = this.LightSprites[i].color;
			float num12 = color11.r = (float)num11;
			Color color12 = this.LightSprites[i].color = color11;
			int num13 = 0;
			Color color13 = this.LightSprites[i].color;
			float num14 = color13.g = (float)num13;
			Color color14 = this.LightSprites[i].color = color13;
			int num15 = 0;
			Color color15 = this.LightSprites[i].color;
			float num16 = color15.b = (float)num15;
			Color color16 = this.LightSprites[i].color = color15;
		}
		for (int i = 0; i < Extensions.get_length(this.DarkSprites); i++)
		{
			int num17 = 0;
			Color color17 = this.DarkSprites[i].color;
			float num18 = color17.r = (float)num17;
			Color color18 = this.DarkSprites[i].color = color17;
			int num19 = 0;
			Color color19 = this.DarkSprites[i].color;
			float num20 = color19.g = (float)num19;
			Color color20 = this.DarkSprites[i].color = color19;
			int num21 = 0;
			Color color21 = this.DarkSprites[i].color;
			float num22 = color21.b = (float)num21;
			Color color22 = this.DarkSprites[i].color = color21;
		}
		for (int i = 0; i < Extensions.get_length(this.Labels); i++)
		{
			int num23 = 0;
			Color color23 = this.Labels[i].color;
			float num24 = color23.r = (float)num23;
			Color color24 = this.Labels[i].color = color23;
			int num25 = 0;
			Color color25 = this.Labels[i].color;
			float num26 = color25.g = (float)num25;
			Color color26 = this.Labels[i].color = color25;
			int num27 = 0;
			Color color27 = this.Labels[i].color;
			float num28 = color27.b = (float)num27;
			Color color28 = this.Labels[i].color = color27;
		}
		this.SimulatorLabel.color = new Color((float)1, (float)0, (float)0, (float)1);
	}

	public virtual void TurnCute()
	{
		this.SetLayerRecursively(this.Yandere.transform.parent.gameObject, 9);
		this.Yandere.animation["f02_yanderePose_00"].weight = (float)0;
		this.Yandere.animation["f02_fist_00"].weight = (float)0;
		int num = 0;
		Color color = this.YandereEye[0].material.color;
		float num2 = color.a = (float)num;
		Color color2 = this.YandereEye[0].material.color = color;
		int num3 = 0;
		Color color3 = this.YandereEye[1].material.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.YandereEye[1].material.color = color3;
		this.ColorCorrection.enabled = false;
		this.BloodProjector.active = false;
		this.BloodCamera.active = false;
		this.Knife.active = false;
		this.CuteMusic.pitch = (float)1;
		this.Timer = (float)0;
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, (float)1);
		RenderSettings.skybox = this.CuteSkybox;
		RenderSettings.fog = false;
		for (int i = 0; i < Extensions.get_length(this.MediumSprites); i++)
		{
			float r = this.MediumColor.r;
			Color color5 = this.MediumSprites[i].color;
			float num5 = color5.r = r;
			Color color6 = this.MediumSprites[i].color = color5;
			float g = this.MediumColor.g;
			Color color7 = this.MediumSprites[i].color;
			float num6 = color7.g = g;
			Color color8 = this.MediumSprites[i].color = color7;
			float b = this.MediumColor.b;
			Color color9 = this.MediumSprites[i].color;
			float num7 = color9.b = b;
			Color color10 = this.MediumSprites[i].color = color9;
		}
		for (int i = 0; i < Extensions.get_length(this.LightSprites); i++)
		{
			float r2 = this.LightColor.r;
			Color color11 = this.LightSprites[i].color;
			float num8 = color11.r = r2;
			Color color12 = this.LightSprites[i].color = color11;
			float g2 = this.LightColor.g;
			Color color13 = this.LightSprites[i].color;
			float num9 = color13.g = g2;
			Color color14 = this.LightSprites[i].color = color13;
			float b2 = this.LightColor.b;
			Color color15 = this.LightSprites[i].color;
			float num10 = color15.b = b2;
			Color color16 = this.LightSprites[i].color = color15;
		}
		for (int i = 0; i < Extensions.get_length(this.DarkSprites); i++)
		{
			float r3 = this.DarkColor.r;
			Color color17 = this.DarkSprites[i].color;
			float num11 = color17.r = r3;
			Color color18 = this.DarkSprites[i].color = color17;
			float g3 = this.DarkColor.g;
			Color color19 = this.DarkSprites[i].color;
			float num12 = color19.g = g3;
			Color color20 = this.DarkSprites[i].color = color19;
			float b3 = this.DarkColor.b;
			Color color21 = this.DarkSprites[i].color;
			float num13 = color21.b = b3;
			Color color22 = this.DarkSprites[i].color = color21;
		}
		for (int i = 0; i < Extensions.get_length(this.Labels); i++)
		{
			int num14 = 1;
			Color color23 = this.Labels[i].color;
			float num15 = color23.r = (float)num14;
			Color color24 = this.Labels[i].color = color23;
			int num16 = 1;
			Color color25 = this.Labels[i].color;
			float num17 = color25.g = (float)num16;
			Color color26 = this.Labels[i].color = color25;
			int num18 = 1;
			Color color27 = this.Labels[i].color;
			float num19 = color27.b = (float)num18;
			Color color28 = this.Labels[i].color = color27;
		}
		this.SimulatorLabel.color = this.MediumColor;
	}

	public virtual void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(obj.transform);
		while (enumerator.MoveNext())
		{
			object obj2 = enumerator.Current;
			object obj4;
			object obj3 = obj4 = obj2;
			if (!(obj3 is Transform))
			{
				obj4 = RuntimeServices.Coerce(obj3, typeof(Transform));
			}
			Transform transform = (Transform)obj4;
			this.SetLayerRecursively(transform.gameObject, newLayer);
			UnityRuntimeServices.Update(enumerator, transform);
		}
	}

	public virtual void Main()
	{
		this.Yandere.animation["f02_yanderePose_00"].layer = 1;
		this.Yandere.animation.Blend("f02_yanderePose_00");
		this.Yandere.animation["f02_fist_00"].layer = 2;
		this.Yandere.animation.Blend("f02_fist_00");
	}
}
