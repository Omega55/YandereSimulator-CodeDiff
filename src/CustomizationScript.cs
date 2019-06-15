﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizationScript : MonoBehaviour
{
	private class CustomizationData
	{
		public global::RangeInt skinColor;

		public global::RangeInt hairstyle;

		public global::RangeInt hairColor;

		public global::RangeInt eyeColor;

		public global::RangeInt eyewear;

		public global::RangeInt facialHair;

		public global::RangeInt maleUniform;

		public global::RangeInt femaleUniform;
	}

	[SerializeField]
	private CustomizationScript.CustomizationData Data;

	[SerializeField]
	private InputManagerScript InputManager;

	[SerializeField]
	private Renderer FacialHairRenderer;

	[SerializeField]
	private SkinnedMeshRenderer YandereRenderer;

	[SerializeField]
	private SkinnedMeshRenderer SenpaiRenderer;

	[SerializeField]
	private Renderer HairRenderer;

	[SerializeField]
	private AudioSource MyAudio;

	[SerializeField]
	private Renderer EyeR;

	[SerializeField]
	private Renderer EyeL;

	[SerializeField]
	private Transform UniformHighlight;

	[SerializeField]
	private Transform ApologyWindow;

	[SerializeField]
	private Transform YandereHead;

	[SerializeField]
	private Transform YandereNeck;

	[SerializeField]
	private Transform SenpaiHead;

	[SerializeField]
	private Transform Highlight;

	[SerializeField]
	private Transform Yandere;

	[SerializeField]
	private Transform Senpai;

	[SerializeField]
	private Transform[] Corridor;

	[SerializeField]
	private UIPanel CustomizePanel;

	[SerializeField]
	private UIPanel UniformPanel;

	[SerializeField]
	private UIPanel FinishPanel;

	[SerializeField]
	private UIPanel GenderPanel;

	[SerializeField]
	private UIPanel WhitePanel;

	[SerializeField]
	private UILabel FacialHairStyleLabel;

	[SerializeField]
	private UILabel FemaleUniformLabel;

	[SerializeField]
	private UILabel MaleUniformLabel;

	[SerializeField]
	private UILabel SkinColorLabel;

	[SerializeField]
	private UILabel HairStyleLabel;

	[SerializeField]
	private UILabel HairColorLabel;

	[SerializeField]
	private UILabel EyeColorLabel;

	[SerializeField]
	private UILabel EyeWearLabel;

	[SerializeField]
	private GameObject LoveSickCamera;

	[SerializeField]
	private GameObject CensorCloud;

	[SerializeField]
	private GameObject BigCloud;

	[SerializeField]
	private GameObject Hearts;

	[SerializeField]
	private GameObject Cloud;

	[SerializeField]
	private UISprite Black;

	[SerializeField]
	private UISprite White;

	[SerializeField]
	private bool Apologize;

	[SerializeField]
	private bool LoveSick;

	[SerializeField]
	private bool FadeOut;

	[SerializeField]
	private float ScrollSpeed;

	[SerializeField]
	private float Timer;

	[SerializeField]
	private int Selected = 1;

	[SerializeField]
	private int Phase = 1;

	[SerializeField]
	private Texture[] FemaleUniformTextures;

	[SerializeField]
	private Texture[] MaleUniformTextures;

	[SerializeField]
	private Texture[] FaceTextures;

	[SerializeField]
	private Texture[] SkinTextures;

	[SerializeField]
	private GameObject[] FacialHairstyles;

	[SerializeField]
	private GameObject[] Hairstyles;

	[SerializeField]
	private GameObject[] Eyewears;

	[SerializeField]
	private Mesh[] FemaleUniforms;

	[SerializeField]
	private Mesh[] MaleUniforms;

	[SerializeField]
	private Texture FemaleFace;

	[SerializeField]
	private string HairColorName = string.Empty;

	[SerializeField]
	private string EyeColorName = string.Empty;

	[SerializeField]
	private AudioClip LoveSickIntro;

	[SerializeField]
	private AudioClip LoveSickLoop;

	public float AbsoluteRotation;

	public float Adjustment;

	public float Rotation;

	private static readonly KeyValuePair<Color, string>[] ColorPairs = new KeyValuePair<Color, string>[]
	{
		new KeyValuePair<Color, string>(default(Color), string.Empty),
		new KeyValuePair<Color, string>(new Color(0.5f, 0.5f, 0.5f), "Black"),
		new KeyValuePair<Color, string>(new Color(1f, 0f, 0f), "Red"),
		new KeyValuePair<Color, string>(new Color(1f, 1f, 0f), "Yellow"),
		new KeyValuePair<Color, string>(new Color(0f, 1f, 0f), "Green"),
		new KeyValuePair<Color, string>(new Color(0f, 1f, 1f), "Cyan"),
		new KeyValuePair<Color, string>(new Color(0f, 0f, 1f), "Blue"),
		new KeyValuePair<Color, string>(new Color(1f, 0f, 1f), "Purple"),
		new KeyValuePair<Color, string>(new Color(1f, 0.5f, 0f), "Orange"),
		new KeyValuePair<Color, string>(new Color(0.5f, 0.25f, 0f), "Brown"),
		new KeyValuePair<Color, string>(new Color(1f, 1f, 1f), "White")
	};

	private void Awake()
	{
		this.Data = new CustomizationScript.CustomizationData();
		this.Data.skinColor = new global::RangeInt(3, this.MinSkinColor, this.MaxSkinColor);
		this.Data.hairstyle = new global::RangeInt(1, this.MinHairstyle, this.MaxHairstyle);
		this.Data.hairColor = new global::RangeInt(1, this.MinHairColor, this.MaxHairColor);
		this.Data.eyeColor = new global::RangeInt(1, this.MinEyeColor, this.MaxEyeColor);
		this.Data.eyewear = new global::RangeInt(0, this.MinEyewear, this.MaxEyewear);
		this.Data.facialHair = new global::RangeInt(0, this.MinFacialHair, this.MaxFacialHair);
		this.Data.maleUniform = new global::RangeInt(1, this.MinMaleUniform, this.MaxMaleUniform);
		this.Data.femaleUniform = new global::RangeInt(1, this.MinFemaleUniform, this.MaxFemaleUniform);
	}

	private void Start()
	{
		Time.timeScale = 1f;
		this.LoveSick = GameGlobals.LoveSick;
		this.ApologyWindow.localPosition = new Vector3(1360f, this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
		this.CustomizePanel.alpha = 0f;
		this.UniformPanel.alpha = 0f;
		this.FinishPanel.alpha = 0f;
		this.GenderPanel.alpha = 0f;
		this.WhitePanel.alpha = 1f;
		this.UpdateFacialHair(this.Data.facialHair.Value);
		this.UpdateHairStyle(this.Data.hairstyle.Value);
		this.UpdateEyes(this.Data.eyeColor.Value);
		this.UpdateSkin(this.Data.skinColor.Value);
		if (this.LoveSick)
		{
			this.LoveSickColorSwap();
			this.WhitePanel.alpha = 0f;
			this.Data.femaleUniform.Value = 5;
			this.Data.maleUniform.Value = 5;
			RenderSettings.fogColor = new Color(0f, 0f, 0f, 1f);
			this.LoveSickCamera.SetActive(true);
			this.Black.color = Color.black;
			this.MyAudio.loop = false;
			this.MyAudio.clip = this.LoveSickIntro;
			this.MyAudio.Play();
		}
		else
		{
			this.Data.femaleUniform.Value = this.MinFemaleUniform;
			this.Data.maleUniform.Value = this.MinMaleUniform;
			RenderSettings.fogColor = new Color(1f, 0.5f, 1f, 1f);
			this.Black.color = new Color(0f, 0f, 0f, 0f);
			this.LoveSickCamera.SetActive(false);
		}
		this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
		this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
		this.Senpai.position = new Vector3(0f, -1f, 2f);
		this.Senpai.gameObject.SetActive(true);
		this.Senpai.GetComponent<Animation>().Play("newWalk_00");
		this.Yandere.position = new Vector3(1f, -1f, 4.5f);
		this.Yandere.gameObject.SetActive(true);
		this.Yandere.GetComponent<Animation>().Play("f02_newWalk_00");
		this.CensorCloud.SetActive(false);
		this.Hearts.SetActive(false);
	}

	private int MinSkinColor
	{
		get
		{
			return 1;
		}
	}

	private int MaxSkinColor
	{
		get
		{
			return 5;
		}
	}

	private int MinHairstyle
	{
		get
		{
			return 0;
		}
	}

	private int MaxHairstyle
	{
		get
		{
			return this.Hairstyles.Length - 1;
		}
	}

	private int MinHairColor
	{
		get
		{
			return 1;
		}
	}

	private int MaxHairColor
	{
		get
		{
			return CustomizationScript.ColorPairs.Length - 1;
		}
	}

	private int MinEyeColor
	{
		get
		{
			return 1;
		}
	}

	private int MaxEyeColor
	{
		get
		{
			return CustomizationScript.ColorPairs.Length - 1;
		}
	}

	private int MinEyewear
	{
		get
		{
			return 0;
		}
	}

	private int MaxEyewear
	{
		get
		{
			return 5;
		}
	}

	private int MinFacialHair
	{
		get
		{
			return 0;
		}
	}

	private int MaxFacialHair
	{
		get
		{
			return this.FacialHairstyles.Length - 1;
		}
	}

	private int MinMaleUniform
	{
		get
		{
			return 1;
		}
	}

	private int MaxMaleUniform
	{
		get
		{
			return this.MaleUniforms.Length - 1;
		}
	}

	private int MinFemaleUniform
	{
		get
		{
			return 1;
		}
	}

	private int MaxFemaleUniform
	{
		get
		{
			return this.FemaleUniforms.Length - 1;
		}
	}

	private float CameraSpeed
	{
		get
		{
			return Time.deltaTime * 10f;
		}
	}

	private void Update()
	{
		if (!this.MyAudio.loop && !this.MyAudio.isPlaying)
		{
			this.MyAudio.loop = true;
			this.MyAudio.clip = this.LoveSickLoop;
			this.MyAudio.Play();
		}
		for (int i = 1; i < 3; i++)
		{
			Transform transform = this.Corridor[i];
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * this.ScrollSpeed);
			if (transform.position.z > 36f)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 72f);
			}
		}
		if (this.Phase == 1)
		{
			if (this.WhitePanel.alpha == 0f)
			{
				this.GenderPanel.alpha = Mathf.MoveTowards(this.GenderPanel.alpha, 1f, Time.deltaTime * 2f);
				if (this.GenderPanel.alpha == 1f)
				{
					if (Input.GetButtonDown("A"))
					{
						this.Phase++;
					}
					if (Input.GetButtonDown("B"))
					{
						this.Apologize = true;
					}
					if (Input.GetButtonDown("X"))
					{
						this.White.color = new Color(0f, 0f, 0f, 1f);
						this.FadeOut = true;
						this.Phase = 0;
					}
				}
			}
		}
		else if (this.Phase == 2)
		{
			this.GenderPanel.alpha = Mathf.MoveTowards(this.GenderPanel.alpha, 0f, Time.deltaTime * 2f);
			this.Black.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Black.color.a, 0f, Time.deltaTime * 2f));
			if (this.GenderPanel.alpha == 0f)
			{
				this.Senpai.gameObject.SetActive(true);
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			this.Adjustment += Input.GetAxis("Mouse X") * Time.deltaTime * 10f;
			if (this.Adjustment > 3f)
			{
				this.Adjustment = 3f;
			}
			else if (this.Adjustment < 0f)
			{
				this.Adjustment = 0f;
			}
			this.CustomizePanel.alpha = Mathf.MoveTowards(this.CustomizePanel.alpha, 1f, Time.deltaTime * 2f);
			if (this.CustomizePanel.alpha == 1f)
			{
				if (Input.GetButtonDown("A"))
				{
					this.Senpai.localEulerAngles = new Vector3(this.Senpai.localEulerAngles.x, 180f, this.Senpai.localEulerAngles.z);
					this.Phase++;
				}
				bool tappedDown = this.InputManager.TappedDown;
				bool tappedUp = this.InputManager.TappedUp;
				if (tappedDown || tappedUp)
				{
					if (tappedDown)
					{
						this.Selected = ((this.Selected < 6) ? (this.Selected + 1) : 1);
					}
					else if (tappedUp)
					{
						this.Selected = ((this.Selected > 1) ? (this.Selected - 1) : 6);
					}
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 650f - (float)this.Selected * 150f, this.Highlight.localPosition.z);
				}
				if (this.InputManager.TappedRight)
				{
					if (this.Selected == 1)
					{
						this.Data.skinColor.Value = this.Data.skinColor.Next;
						this.UpdateSkin(this.Data.skinColor.Value);
					}
					else if (this.Selected == 2)
					{
						this.Data.hairstyle.Value = this.Data.hairstyle.Next;
						this.UpdateHairStyle(this.Data.hairstyle.Value);
					}
					else if (this.Selected == 3)
					{
						this.Data.hairColor.Value = this.Data.hairColor.Next;
						this.UpdateColor(this.Data.hairColor.Value);
					}
					else if (this.Selected == 4)
					{
						this.Data.eyeColor.Value = this.Data.eyeColor.Next;
						this.UpdateEyes(this.Data.eyeColor.Value);
					}
					else if (this.Selected == 5)
					{
						this.Data.eyewear.Value = this.Data.eyewear.Next;
						this.UpdateEyewear(this.Data.eyewear.Value);
					}
					else if (this.Selected == 6)
					{
						this.Data.facialHair.Value = this.Data.facialHair.Next;
						this.UpdateFacialHair(this.Data.facialHair.Value);
					}
				}
				if (this.InputManager.TappedLeft)
				{
					if (this.Selected == 1)
					{
						this.Data.skinColor.Value = this.Data.skinColor.Previous;
						this.UpdateSkin(this.Data.skinColor.Value);
					}
					else if (this.Selected == 2)
					{
						this.Data.hairstyle.Value = this.Data.hairstyle.Previous;
						this.UpdateHairStyle(this.Data.hairstyle.Value);
					}
					else if (this.Selected == 3)
					{
						this.Data.hairColor.Value = this.Data.hairColor.Previous;
						this.UpdateColor(this.Data.hairColor.Value);
					}
					else if (this.Selected == 4)
					{
						this.Data.eyeColor.Value = this.Data.eyeColor.Previous;
						this.UpdateEyes(this.Data.eyeColor.Value);
					}
					else if (this.Selected == 5)
					{
						this.Data.eyewear.Value = this.Data.eyewear.Previous;
						this.UpdateEyewear(this.Data.eyewear.Value);
					}
					else if (this.Selected == 6)
					{
						this.Data.facialHair.Value = this.Data.facialHair.Previous;
						this.UpdateFacialHair(this.Data.facialHair.Value);
					}
				}
			}
			this.Rotation = Mathf.Lerp(this.Rotation, 45f - this.Adjustment * 30f, Time.deltaTime * 10f);
			this.AbsoluteRotation = 45f - Mathf.Abs(this.Rotation);
			if (this.Selected == 1)
			{
				this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, -1.5f + this.Adjustment, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 0.5f - this.AbsoluteRotation * 0.015f, this.CameraSpeed));
			}
			else
			{
				this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, -0.5f + this.Adjustment * 0.33333f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 1.5f - this.AbsoluteRotation * 0.015f * 0.33333f, this.CameraSpeed));
			}
			this.LoveSickCamera.transform.eulerAngles = new Vector3(0f, this.Rotation, 0f);
			base.transform.eulerAngles = this.LoveSickCamera.transform.eulerAngles;
			base.transform.position = this.LoveSickCamera.transform.position;
		}
		else if (this.Phase == 4)
		{
			this.Adjustment = Mathf.Lerp(this.Adjustment, 0f, Time.deltaTime * 10f);
			this.Rotation = Mathf.Lerp(this.Rotation, 45f, Time.deltaTime * 10f);
			this.AbsoluteRotation = 45f - Mathf.Abs(this.Rotation);
			this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, -1.5f + this.Adjustment, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 0.5f - this.AbsoluteRotation * 0.015f, this.CameraSpeed));
			this.LoveSickCamera.transform.eulerAngles = new Vector3(0f, this.Rotation, 0f);
			base.transform.eulerAngles = this.LoveSickCamera.transform.eulerAngles;
			base.transform.position = this.LoveSickCamera.transform.position;
			this.CustomizePanel.alpha = Mathf.MoveTowards(this.CustomizePanel.alpha, 0f, Time.deltaTime * 2f);
			if (this.CustomizePanel.alpha == 0f)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 1f, Time.deltaTime * 2f);
			if (this.FinishPanel.alpha == 1f)
			{
				if (Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
				if (Input.GetButtonDown("B"))
				{
					this.Selected = 1;
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 650f - (float)this.Selected * 150f, this.Highlight.localPosition.z);
					this.Phase = 100;
				}
			}
		}
		else if (this.Phase == 6)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0f, Time.deltaTime * 2f);
			if (this.FinishPanel.alpha == 0f)
			{
				this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
				this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
				this.CensorCloud.SetActive(false);
				this.Yandere.gameObject.SetActive(true);
				this.Selected = 1;
				this.Phase++;
			}
		}
		else if (this.Phase == 7)
		{
			this.UniformPanel.alpha = Mathf.MoveTowards(this.UniformPanel.alpha, 1f, Time.deltaTime * 2f);
			if (this.UniformPanel.alpha == 1f)
			{
				if (Input.GetButtonDown("A"))
				{
					this.Yandere.localEulerAngles = new Vector3(this.Yandere.localEulerAngles.x, 180f, this.Yandere.localEulerAngles.z);
					this.Senpai.localEulerAngles = new Vector3(this.Senpai.localEulerAngles.x, 180f, this.Senpai.localEulerAngles.z);
					this.Phase++;
				}
				if (this.InputManager.TappedDown || this.InputManager.TappedUp)
				{
					this.Selected = ((this.Selected != 1) ? 1 : 2);
					this.UniformHighlight.localPosition = new Vector3(this.UniformHighlight.localPosition.x, 650f - (float)this.Selected * 150f, this.UniformHighlight.localPosition.z);
				}
				if (this.InputManager.TappedRight)
				{
					if (this.Selected == 1)
					{
						this.Data.maleUniform.Value = this.Data.maleUniform.Next;
						this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
					}
					else if (this.Selected == 2)
					{
						this.Data.femaleUniform.Value = this.Data.femaleUniform.Next;
						this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
					}
				}
				if (this.InputManager.TappedLeft)
				{
					if (this.Selected == 1)
					{
						this.Data.maleUniform.Value = this.Data.maleUniform.Previous;
						this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
					}
					else if (this.Selected == 2)
					{
						this.Data.femaleUniform.Value = this.Data.femaleUniform.Previous;
						this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
					}
				}
			}
		}
		else if (this.Phase == 8)
		{
			this.UniformPanel.alpha = Mathf.MoveTowards(this.UniformPanel.alpha, 0f, Time.deltaTime * 2f);
			if (this.UniformPanel.alpha == 0f)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 9)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 1f, Time.deltaTime * 2f);
			if (this.FinishPanel.alpha == 1f)
			{
				if (Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
				if (Input.GetButtonDown("B"))
				{
					this.Selected = 1;
					this.UniformHighlight.localPosition = new Vector3(this.UniformHighlight.localPosition.x, 650f - (float)this.Selected * 150f, this.UniformHighlight.localPosition.z);
					this.Phase = 99;
				}
			}
		}
		else if (this.Phase == 10)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0f, Time.deltaTime * 2f);
			if (this.FinishPanel.alpha == 0f)
			{
				this.White.color = new Color(0f, 0f, 0f, 1f);
				this.FadeOut = true;
				this.Phase = 0;
			}
		}
		else if (this.Phase == 99)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0f, Time.deltaTime * 2f);
			if (this.FinishPanel.alpha == 0f)
			{
				this.Phase = 7;
			}
		}
		else if (this.Phase == 100)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0f, Time.deltaTime * 2f);
			if (this.FinishPanel.alpha == 0f)
			{
				this.Phase = 3;
			}
		}
		if (this.Phase > 3 && this.Phase < 100)
		{
			if (this.Phase < 6)
			{
				this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, -1.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 0.5f, this.CameraSpeed));
				base.transform.position = this.LoveSickCamera.transform.position;
			}
			else
			{
				this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, 0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 0f, this.CameraSpeed));
				this.LoveSickCamera.transform.eulerAngles = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.eulerAngles.x, 15f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.eulerAngles.y, 0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.eulerAngles.z, 0f, this.CameraSpeed));
				base.transform.eulerAngles = this.LoveSickCamera.transform.eulerAngles;
				base.transform.position = this.LoveSickCamera.transform.position;
				this.Yandere.position = new Vector3(Mathf.Lerp(this.Yandere.position.x, 1f, Time.deltaTime * 10f), Mathf.Lerp(this.Yandere.position.y, -1f, Time.deltaTime * 10f), Mathf.Lerp(this.Yandere.position.z, 3.5f, Time.deltaTime * 10f));
			}
		}
		if (this.FadeOut)
		{
			this.WhitePanel.alpha = Mathf.MoveTowards(this.WhitePanel.alpha, 1f, Time.deltaTime);
			base.GetComponent<AudioSource>().volume = 1f - this.WhitePanel.alpha;
			if (this.WhitePanel.alpha == 1f)
			{
				SenpaiGlobals.CustomSenpai = true;
				SenpaiGlobals.SenpaiSkinColor = this.Data.skinColor.Value;
				SenpaiGlobals.SenpaiHairStyle = this.Data.hairstyle.Value;
				SenpaiGlobals.SenpaiHairColor = this.HairColorName;
				SenpaiGlobals.SenpaiEyeColor = this.EyeColorName;
				SenpaiGlobals.SenpaiEyeWear = this.Data.eyewear.Value;
				SenpaiGlobals.SenpaiFacialHair = this.Data.facialHair.Value;
				StudentGlobals.MaleUniform = this.Data.maleUniform.Value;
				StudentGlobals.FemaleUniform = this.Data.femaleUniform.Value;
				SceneManager.LoadScene("NewIntroScene");
			}
		}
		else
		{
			this.WhitePanel.alpha = Mathf.MoveTowards(this.WhitePanel.alpha, 0f, Time.deltaTime);
		}
		if (this.Apologize)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer < 1f)
			{
				this.ApologyWindow.localPosition = new Vector3(Mathf.Lerp(this.ApologyWindow.localPosition.x, 0f, Time.deltaTime * 10f), this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
			}
			else
			{
				this.ApologyWindow.localPosition = new Vector3(Mathf.Abs((this.ApologyWindow.localPosition.x - Time.deltaTime) * 0.01f) * (Time.deltaTime * 1000f), this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
				if (this.ApologyWindow.localPosition.x < -1360f)
				{
					this.ApologyWindow.localPosition = new Vector3(1360f, this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
					this.Apologize = false;
					this.Timer = 0f;
				}
			}
		}
	}

	private void LateUpdate()
	{
		this.YandereHead.LookAt(this.SenpaiHead.position);
	}

	private void UpdateSkin(int skinColor)
	{
		this.UpdateMaleUniform(this.Data.maleUniform.Value, skinColor);
		this.SkinColorLabel.text = "Skin Color " + skinColor.ToString();
	}

	private void UpdateHairStyle(int hairstyle)
	{
		for (int i = 1; i < this.Hairstyles.Length; i++)
		{
			this.Hairstyles[i].SetActive(false);
		}
		if (hairstyle > 0)
		{
			this.HairRenderer = this.Hairstyles[hairstyle].GetComponent<Renderer>();
			this.Hairstyles[hairstyle].SetActive(true);
		}
		this.HairStyleLabel.text = "Hair Style " + hairstyle.ToString();
		this.UpdateColor(this.Data.hairColor.Value);
	}

	private void UpdateFacialHair(int facialHair)
	{
		for (int i = 1; i < this.FacialHairstyles.Length; i++)
		{
			this.FacialHairstyles[i].SetActive(false);
		}
		if (facialHair > 0)
		{
			this.FacialHairRenderer = this.FacialHairstyles[facialHair].GetComponent<Renderer>();
			this.FacialHairstyles[facialHair].SetActive(true);
		}
		this.FacialHairStyleLabel.text = "Facial Hair " + facialHair.ToString();
		this.UpdateColor(this.Data.hairColor.Value);
	}

	private void UpdateColor(int hairColor)
	{
		KeyValuePair<Color, string> keyValuePair = CustomizationScript.ColorPairs[hairColor];
		Color key = keyValuePair.Key;
		this.HairColorName = keyValuePair.Value;
		if (this.Data.hairstyle.Value > 0)
		{
			this.HairRenderer = this.Hairstyles[this.Data.hairstyle.Value].GetComponent<Renderer>();
			this.HairRenderer.material.color = key;
		}
		if (this.Data.facialHair.Value > 0)
		{
			this.FacialHairRenderer = this.FacialHairstyles[this.Data.facialHair.Value].GetComponent<Renderer>();
			this.FacialHairRenderer.material.color = key;
			if (this.FacialHairRenderer.materials.Length > 1)
			{
				this.FacialHairRenderer.materials[1].color = key;
			}
		}
		this.HairColorLabel.text = "Hair Color " + hairColor.ToString();
	}

	private void UpdateEyes(int eyeColor)
	{
		KeyValuePair<Color, string> keyValuePair = CustomizationScript.ColorPairs[eyeColor];
		Color key = keyValuePair.Key;
		this.EyeColorName = keyValuePair.Value;
		this.EyeR.material.color = key;
		this.EyeL.material.color = key;
		this.EyeColorLabel.text = "Eye Color " + eyeColor.ToString();
	}

	private void UpdateEyewear(int eyewear)
	{
		for (int i = 1; i < this.Eyewears.Length; i++)
		{
			this.Eyewears[i].SetActive(false);
		}
		if (eyewear > 0)
		{
			this.Eyewears[eyewear].SetActive(true);
		}
		this.EyeWearLabel.text = "Eye Wear " + eyewear.ToString();
	}

	private void UpdateMaleUniform(int maleUniform, int skinColor)
	{
		this.SenpaiRenderer.sharedMesh = this.MaleUniforms[maleUniform];
		if (maleUniform == 1)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.SkinTextures[skinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.MaleUniformTextures[maleUniform];
			this.SenpaiRenderer.materials[2].mainTexture = this.FaceTextures[skinColor];
		}
		else if (maleUniform == 2)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.MaleUniformTextures[maleUniform];
			this.SenpaiRenderer.materials[1].mainTexture = this.FaceTextures[skinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.SkinTextures[skinColor];
		}
		else if (maleUniform == 3)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.MaleUniformTextures[maleUniform];
			this.SenpaiRenderer.materials[1].mainTexture = this.FaceTextures[skinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.SkinTextures[skinColor];
		}
		else if (maleUniform == 4)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[skinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[skinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[maleUniform];
		}
		else if (maleUniform == 5)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[skinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[skinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[maleUniform];
		}
		else if (maleUniform == 6)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[skinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[skinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[maleUniform];
		}
		this.MaleUniformLabel.text = "Male Uniform " + maleUniform.ToString();
	}

	private void UpdateFemaleUniform(int femaleUniform)
	{
		this.YandereRenderer.sharedMesh = this.FemaleUniforms[femaleUniform];
		this.YandereRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
		this.YandereRenderer.materials[1].mainTexture = this.FemaleUniformTextures[femaleUniform];
		this.YandereRenderer.materials[2].mainTexture = this.FemaleFace;
		this.YandereRenderer.materials[3].mainTexture = this.FemaleFace;
		this.FemaleUniformLabel.text = "Female Uniform " + femaleUniform.ToString();
	}

	private void LoveSickColorSwap()
	{
		GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
		foreach (GameObject gameObject in array)
		{
			UISprite component = gameObject.GetComponent<UISprite>();
			if (component != null && component.color != Color.black && component.transform.parent != this.Highlight && component.transform.parent != this.UniformHighlight)
			{
				component.color = new Color(1f, 0f, 0f, component.color.a);
			}
			UITexture component2 = gameObject.GetComponent<UITexture>();
			if (component2 != null)
			{
				component2.color = new Color(1f, 0f, 0f, component2.color.a);
			}
			UILabel component3 = gameObject.GetComponent<UILabel>();
			if (component3 != null && component3.color != Color.black)
			{
				component3.color = new Color(1f, 0f, 0f, component3.color.a);
			}
		}
	}
}
