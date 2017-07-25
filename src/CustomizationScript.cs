using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizationScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public Renderer FacialHairRenderer;

	public SkinnedMeshRenderer YandereRenderer;

	public SkinnedMeshRenderer SenpaiRenderer;

	public Renderer HairRenderer;

	public Renderer EyeR;

	public Renderer EyeL;

	public Transform UniformHighlight;

	public Transform ApologyWindow;

	public Transform Highlight;

	public Transform Yandere;

	public Transform Senpai;

	public UIPanel CustomizePanel;

	public UIPanel UniformPanel;

	public UIPanel FinishPanel;

	public UIPanel GenderPanel;

	public UIPanel WhitePanel;

	public UILabel FacialHairStyleLabel;

	public UILabel FemaleUniformLabel;

	public UILabel MaleUniformLabel;

	public UILabel SkinColorLabel;

	public UILabel HairStyleLabel;

	public UILabel HairColorLabel;

	public UILabel EyeColorLabel;

	public UILabel EyeWearLabel;

	public GameObject CensorCloud;

	public GameObject BigCloud;

	public GameObject Cloud;

	public UISprite White;

	public bool Apologize;

	public bool FadeOut;

	public float Timer;

	public int FemaleUniform = 1;

	public int MaleUniform = 1;

	public int FacialHair;

	public int SkinColor = 3;

	public int HairStyle = 1;

	public int HairColor = 1;

	public int EyeColor = 1;

	public int EyeWear;

	public int Selected = 1;

	public int Phase = 1;

	public Texture[] FemaleUniformTextures;

	public Texture[] MaleUniformTextures;

	public Texture[] FaceTextures;

	public Texture[] SkinTextures;

	public GameObject[] FacialHairstyles;

	public GameObject[] Hairstyles;

	public GameObject[] Eyewears;

	public Mesh[] FemaleUniforms;

	public Mesh[] MaleUniforms;

	public Texture FemaleFace;

	public string HairColorName = string.Empty;

	public string EyeColorName = string.Empty;

	private void Start()
	{
		this.Senpai.gameObject.SetActive(false);
		this.Senpai.position = new Vector3(0f, -3f, 2.1f);
		this.Yandere.position = new Vector3(0.5f, -3f, 2.1f);
		this.ApologyWindow.localPosition = new Vector3(1360f, this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
		this.CustomizePanel.alpha = 0f;
		this.UniformPanel.alpha = 0f;
		this.Yandere.gameObject.SetActive(false);
		this.FinishPanel.alpha = 0f;
		this.GenderPanel.alpha = 0f;
		this.WhitePanel.alpha = 1f;
		this.UpdateFacialHair();
		this.UpdateHairStyle();
		this.UpdateEyes();
		this.UpdateSkin();
	}

	private void Update()
	{
		if (this.Phase == 1)
		{
			if (this.WhitePanel.alpha == 0f)
			{
				this.GenderPanel.alpha = Mathf.MoveTowards(this.GenderPanel.alpha, 1f, Time.deltaTime * 2f);
				if (this.GenderPanel.alpha == 1f)
				{
					if (Input.GetButtonDown("A"))
					{
						this.Cloud.SetActive(true);
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
			if (this.GenderPanel.alpha == 0f)
			{
				this.Senpai.gameObject.SetActive(true);
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			this.CustomizePanel.alpha = Mathf.MoveTowards(this.CustomizePanel.alpha, 1f, Time.deltaTime * 2f);
			if (this.CustomizePanel.alpha == 1f)
			{
				this.Senpai.localEulerAngles = new Vector3(this.Senpai.localEulerAngles.x, this.Senpai.localEulerAngles.y - Input.GetAxis("RS") - Input.GetAxis("Mouse X"), this.Senpai.localEulerAngles.z);
				if (Input.GetButtonDown("A"))
				{
					this.Senpai.localEulerAngles = new Vector3(this.Senpai.localEulerAngles.x, 180f, this.Senpai.localEulerAngles.z);
					this.Phase++;
				}
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected > 6)
					{
						this.Selected = 1;
					}
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 650f - (float)this.Selected * 150f, this.Highlight.localPosition.z);
				}
				else if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = 6;
					}
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 650f - (float)this.Selected * 150f, this.Highlight.localPosition.z);
				}
				if (this.InputManager.TappedRight)
				{
					if (this.Selected == 1)
					{
						this.SkinColor++;
						this.UpdateSkin();
					}
					else if (this.Selected == 2)
					{
						this.HairStyle++;
						this.UpdateHairStyle();
					}
					else if (this.Selected == 3)
					{
						this.HairColor++;
						this.UpdateColor();
					}
					else if (this.Selected == 4)
					{
						this.EyeColor++;
						this.UpdateEyes();
					}
					else if (this.Selected == 5)
					{
						this.EyeWear++;
						this.UpdateEyewear();
					}
					else if (this.Selected == 6)
					{
						this.FacialHair++;
						this.UpdateFacialHair();
					}
				}
				if (this.InputManager.TappedLeft)
				{
					if (this.Selected == 1)
					{
						this.SkinColor--;
						this.UpdateSkin();
					}
					else if (this.Selected == 2)
					{
						this.HairStyle--;
						this.UpdateHairStyle();
					}
					else if (this.Selected == 3)
					{
						this.HairColor--;
						this.UpdateColor();
					}
					else if (this.Selected == 4)
					{
						this.EyeColor--;
						this.UpdateEyes();
					}
					else if (this.Selected == 5)
					{
						this.EyeWear--;
						this.UpdateEyewear();
					}
					else if (this.Selected == 6)
					{
						this.FacialHair--;
						this.UpdateFacialHair();
					}
				}
			}
			if (this.Selected == 1)
			{
				this.Senpai.position = new Vector3(this.Senpai.position.x, Mathf.Lerp(this.Senpai.position.y, -1f, Time.deltaTime * 10f), Mathf.Lerp(this.Senpai.position.z, 2.1f, Time.deltaTime * 10f));
			}
			else
			{
				this.Senpai.position = new Vector3(this.Senpai.position.x, Mathf.Lerp(this.Senpai.position.y, -1.6f, Time.deltaTime * 10f), Mathf.Lerp(this.Senpai.position.z, 0.4f, Time.deltaTime * 10f));
			}
		}
		else if (this.Phase == 4)
		{
			this.Senpai.position = new Vector3(this.Senpai.position.x, Mathf.Lerp(this.Senpai.position.y, -0.6333333f, Time.deltaTime * 10f), Mathf.Lerp(this.Senpai.position.z, 2.1f, Time.deltaTime * 10f));
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
					this.BigCloud.SetActive(true);
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
				this.UpdateFemaleUniform();
				this.UpdateMaleUniform();
				this.CensorCloud.SetActive(false);
				this.Yandere.gameObject.SetActive(true);
				this.Selected = 1;
				this.Phase++;
			}
		}
		else if (this.Phase == 7)
		{
			this.UniformPanel.alpha = Mathf.MoveTowards(this.UniformPanel.alpha, 1f, Time.deltaTime * 2f);
			this.Senpai.position = new Vector3(Mathf.Lerp(this.Senpai.position.x, -0.5f, Time.deltaTime * 10f), Mathf.Lerp(this.Senpai.position.y, -1f, Time.deltaTime * 10f), this.Senpai.position.z);
			this.Yandere.position = new Vector3(Mathf.Lerp(this.Yandere.position.x, 0.5f, Time.deltaTime * 10f), Mathf.Lerp(this.Yandere.position.y, -1f, Time.deltaTime * 10f), this.Yandere.position.z);
			if (this.UniformPanel.alpha == 1f)
			{
				if (this.Selected == 1)
				{
					this.Senpai.localEulerAngles = new Vector3(this.Senpai.localEulerAngles.x, this.Senpai.localEulerAngles.y - Input.GetAxis("RS") - Input.GetAxis("Mouse X"), this.Senpai.localEulerAngles.z);
				}
				else
				{
					this.Yandere.localEulerAngles = new Vector3(this.Yandere.localEulerAngles.x, this.Yandere.localEulerAngles.y - Input.GetAxis("RS") - Input.GetAxis("Mouse X"), this.Yandere.localEulerAngles.z);
				}
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
						this.MaleUniform++;
						this.UpdateMaleUniform();
					}
					else if (this.Selected == 2)
					{
						this.FemaleUniform++;
						this.UpdateFemaleUniform();
					}
				}
				if (this.InputManager.TappedLeft)
				{
					if (this.Selected == 1)
					{
						this.MaleUniform--;
						this.UpdateMaleUniform();
					}
					else if (this.Selected == 2)
					{
						this.FemaleUniform--;
						this.UpdateFemaleUniform();
					}
				}
			}
		}
		else if (this.Phase == 8)
		{
			this.Senpai.position = new Vector3(this.Senpai.position.x, Mathf.Lerp(this.Senpai.position.y, -0.6333333f, Time.deltaTime * 10f), this.Senpai.position.z);
			this.Yandere.position = new Vector3(this.Yandere.position.x, Mathf.Lerp(this.Yandere.position.y, -0.6333333f, Time.deltaTime * 10f), this.Yandere.position.z);
			this.UniformPanel.alpha = Mathf.MoveTowards(this.UniformPanel.alpha, 0f, Time.deltaTime * 2f);
			if (this.UniformPanel.alpha == 0f)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 9)
		{
			this.Senpai.position = new Vector3(this.Senpai.position.x, Mathf.Lerp(this.Senpai.position.y, -0.6333333f, Time.deltaTime * 10f), this.Senpai.position.z);
			this.Yandere.position = new Vector3(this.Yandere.position.x, Mathf.Lerp(this.Yandere.position.y, -0.6333333f, Time.deltaTime * 10f), this.Yandere.position.z);
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
		if (this.FadeOut)
		{
			this.WhitePanel.alpha = Mathf.MoveTowards(this.WhitePanel.alpha, 1f, Time.deltaTime);
			base.GetComponent<AudioSource>().volume = 1f - this.WhitePanel.alpha;
			if (this.WhitePanel.alpha == 1f)
			{
				PlayerPrefs.SetInt("CustomSenpai", 1);
				PlayerPrefs.SetInt("SenpaiSkinColor", this.SkinColor);
				PlayerPrefs.SetInt("SenpaiHairStyle", this.HairStyle);
				PlayerPrefs.SetString("SenpaiHairColor", this.HairColorName);
				PlayerPrefs.SetString("SenpaiEyeColor", this.EyeColorName);
				PlayerPrefs.SetInt("SenpaiEyeWear", this.EyeWear);
				PlayerPrefs.SetInt("SenpaiFacialHair", this.FacialHair);
				PlayerPrefs.SetInt("MaleUniform", this.MaleUniform);
				PlayerPrefs.SetInt("FemaleUniform", this.FemaleUniform);
				SceneManager.LoadScene("IntroScene");
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
		if (Input.GetKeyDown("left ctrl"))
		{
			this.GenderPanel.alpha = 0f;
			this.Senpai.gameObject.SetActive(true);
			this.Phase = 6;
		}
	}

	private void UpdateSkin()
	{
		if (this.SkinColor > 5)
		{
			this.SkinColor = 1;
		}
		else if (this.SkinColor < 1)
		{
			this.SkinColor = 5;
		}
		this.SenpaiRenderer.materials[1].mainTexture = this.FaceTextures[this.SkinColor];
		this.SenpaiRenderer.materials[0].mainTexture = this.SkinTextures[this.SkinColor];
		this.SkinColorLabel.text = "Skin Color " + this.SkinColor.ToString();
	}

	private void UpdateHairStyle()
	{
		if (this.HairStyle > this.Hairstyles.Length - 1)
		{
			this.HairStyle = 0;
		}
		else if (this.HairStyle < 0)
		{
			this.HairStyle = this.Hairstyles.Length - 1;
		}
		for (int i = 1; i < this.Hairstyles.Length; i++)
		{
			this.Hairstyles[i].SetActive(false);
		}
		if (this.HairStyle > 0)
		{
			this.HairRenderer = this.Hairstyles[this.HairStyle].GetComponent<Renderer>();
			this.Hairstyles[this.HairStyle].SetActive(true);
		}
		this.HairStyleLabel.text = "Hair Style " + this.HairStyle.ToString();
		this.UpdateColor();
	}

	private void UpdateFacialHair()
	{
		if (this.FacialHair > this.FacialHairstyles.Length - 1)
		{
			this.FacialHair = 0;
		}
		else if (this.FacialHair < 0)
		{
			this.FacialHair = this.FacialHairstyles.Length - 1;
		}
		for (int i = 1; i < this.FacialHairstyles.Length; i++)
		{
			this.FacialHairstyles[i].SetActive(false);
		}
		if (this.FacialHair > 0)
		{
			this.FacialHairRenderer = this.FacialHairstyles[this.FacialHair].GetComponent<Renderer>();
			this.FacialHairstyles[this.FacialHair].SetActive(true);
		}
		this.FacialHairStyleLabel.text = "Facial Hair " + this.FacialHair.ToString();
		this.UpdateColor();
	}

	private void UpdateColor()
	{
		if (this.HairColor > 10)
		{
			this.HairColor = 1;
		}
		else if (this.HairColor < 1)
		{
			this.HairColor = 10;
		}
		Color color = default(Color);
		if (this.HairColor == 1)
		{
			color = new Color(0.5f, 0.5f, 0.5f);
			this.HairColorName = "Black";
		}
		else if (this.HairColor == 2)
		{
			color = new Color(1f, 0f, 0f);
			this.HairColorName = "Red";
		}
		else if (this.HairColor == 3)
		{
			color = new Color(1f, 1f, 0f);
			this.HairColorName = "Yellow";
		}
		else if (this.HairColor == 4)
		{
			color = new Color(0f, 1f, 0f);
			this.HairColorName = "Green";
		}
		else if (this.HairColor == 5)
		{
			color = new Color(0f, 1f, 1f);
			this.HairColorName = "Cyan";
		}
		else if (this.HairColor == 6)
		{
			color = new Color(0f, 0f, 1f);
			this.HairColorName = "Blue";
		}
		else if (this.HairColor == 7)
		{
			color = new Color(1f, 0f, 1f);
			this.HairColorName = "Purple";
		}
		else if (this.HairColor == 8)
		{
			color = new Color(1f, 0.5f, 0f);
			this.HairColorName = "Orange";
		}
		else if (this.HairColor == 9)
		{
			color = new Color(0.5f, 0.25f, 0f);
			this.HairColorName = "Brown";
		}
		else if (this.HairColor == 10)
		{
			color = new Color(1f, 1f, 1f);
			this.HairColorName = "White";
		}
		if (this.HairStyle > 0)
		{
			this.HairRenderer = this.Hairstyles[this.HairStyle].GetComponent<Renderer>();
			this.HairRenderer.material.color = color;
		}
		if (this.FacialHair > 0)
		{
			this.FacialHairRenderer = this.FacialHairstyles[this.FacialHair].GetComponent<Renderer>();
			this.FacialHairRenderer.material.color = color;
			if (this.FacialHairRenderer.materials.Length > 1)
			{
				this.FacialHairRenderer.materials[1].color = color;
			}
		}
		this.HairColorLabel.text = "Hair Color " + this.HairColor.ToString();
	}

	private void UpdateEyes()
	{
		if (this.EyeColor > 10)
		{
			this.EyeColor = 1;
		}
		else if (this.EyeColor < 1)
		{
			this.EyeColor = 10;
		}
		Color color = default(Color);
		if (this.EyeColor == 1)
		{
			color = new Color(0.5f, 0.5f, 0.5f);
			this.EyeColorName = "Black";
		}
		else if (this.EyeColor == 2)
		{
			color = new Color(1f, 0f, 0f);
			this.EyeColorName = "Red";
		}
		else if (this.EyeColor == 3)
		{
			color = new Color(1f, 1f, 0f);
			this.EyeColorName = "Yellow";
		}
		else if (this.EyeColor == 4)
		{
			color = new Color(0f, 1f, 0f);
			this.EyeColorName = "Green";
		}
		else if (this.EyeColor == 5)
		{
			color = new Color(0f, 1f, 1f);
			this.EyeColorName = "Cyan";
		}
		else if (this.EyeColor == 6)
		{
			color = new Color(0f, 0f, 1f);
			this.EyeColorName = "Blue";
		}
		else if (this.EyeColor == 7)
		{
			color = new Color(1f, 0f, 1f);
			this.EyeColorName = "Purple";
		}
		else if (this.EyeColor == 8)
		{
			color = new Color(1f, 0.5f, 0f);
			this.EyeColorName = "Orange";
		}
		else if (this.EyeColor == 9)
		{
			color = new Color(0.5f, 0.25f, 0f);
			this.EyeColorName = "Brown";
		}
		else if (this.EyeColor == 10)
		{
			color = new Color(1f, 1f, 1f);
			this.EyeColorName = "White";
		}
		this.EyeR.material.color = color;
		this.EyeL.material.color = color;
		this.EyeColorLabel.text = "Eye Color " + this.EyeColor.ToString();
	}

	private void UpdateEyewear()
	{
		if (this.EyeWear > 5)
		{
			this.EyeWear = 0;
		}
		else if (this.EyeWear < 0)
		{
			this.EyeWear = 5;
		}
		for (int i = 1; i < this.Eyewears.Length; i++)
		{
			this.Eyewears[i].SetActive(false);
		}
		if (this.EyeWear > 0)
		{
			this.Eyewears[this.EyeWear].SetActive(true);
		}
		this.EyeWearLabel.text = "Eye Wear " + this.EyeWear.ToString();
	}

	private void UpdateMaleUniform()
	{
		if (this.MaleUniform > this.MaleUniforms.Length - 1)
		{
			this.MaleUniform = 1;
		}
		else if (this.MaleUniform < 1)
		{
			this.MaleUniform = this.MaleUniforms.Length - 1;
		}
		this.SenpaiRenderer.sharedMesh = this.MaleUniforms[this.MaleUniform];
		if (this.MaleUniform == 1)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.SkinTextures[this.SkinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.MaleUniformTextures[this.MaleUniform];
			this.SenpaiRenderer.materials[2].mainTexture = this.FaceTextures[this.SkinColor];
		}
		else if (this.MaleUniform == 2)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.MaleUniformTextures[this.MaleUniform];
			this.SenpaiRenderer.materials[1].mainTexture = this.FaceTextures[this.SkinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.SkinTextures[this.SkinColor];
		}
		else if (this.MaleUniform == 3)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.MaleUniformTextures[this.MaleUniform];
			this.SenpaiRenderer.materials[1].mainTexture = this.FaceTextures[this.SkinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.SkinTextures[this.SkinColor];
		}
		else if (this.MaleUniform == 4)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[this.SkinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[this.SkinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[this.MaleUniform];
		}
		else if (this.MaleUniform == 5)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[this.SkinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[this.SkinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[this.MaleUniform];
		}
		else if (this.MaleUniform == 6)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[this.SkinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[this.SkinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[this.MaleUniform];
		}
		this.MaleUniformLabel.text = "Male Uniform " + this.MaleUniform.ToString();
	}

	private void UpdateFemaleUniform()
	{
		if (this.FemaleUniform > this.FemaleUniforms.Length - 1)
		{
			this.FemaleUniform = 1;
		}
		else if (this.FemaleUniform < 1)
		{
			this.FemaleUniform = this.FemaleUniforms.Length - 1;
		}
		this.YandereRenderer.sharedMesh = this.FemaleUniforms[this.FemaleUniform];
		this.YandereRenderer.materials[0].mainTexture = this.FemaleUniformTextures[this.FemaleUniform];
		this.YandereRenderer.materials[1].mainTexture = this.FemaleUniformTextures[this.FemaleUniform];
		this.YandereRenderer.materials[2].mainTexture = this.FemaleFace;
		this.YandereRenderer.materials[3].mainTexture = this.FemaleFace;
		this.FemaleUniformLabel.text = "Female Uniform " + this.FemaleUniform.ToString();
	}
}
