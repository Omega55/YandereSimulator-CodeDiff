using System;
using UnityEngine;

[Serializable]
public class CustomizationScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public Renderer SenpaiRenderer;

	public Renderer HairRenderer;

	public Renderer EyeR;

	public Renderer EyeL;

	public Transform ApologyWindow;

	public Transform Highlight;

	public Transform Senpai;

	public UIPanel CustomizePanel;

	public UIPanel FinishPanel;

	public UIPanel GenderPanel;

	public UIPanel WhitePanel;

	public UILabel SkinColorLabel;

	public UILabel HairStyleLabel;

	public UILabel HairColorLabel;

	public UILabel EyeColorLabel;

	public UILabel EyeWearLabel;

	public GameObject Cloud;

	public UISprite White;

	public bool Apologize;

	public bool FadeOut;

	public float Timer;

	public int SkinColor;

	public int HairStyle;

	public int HairColor;

	public int EyeColor;

	public int EyeWear;

	public int Selected;

	public int Phase;

	public GameObject[] Eyewears;

	public GameObject[] Hairstyles;

	public Texture[] FaceTextures;

	public Texture[] SkinTextures;

	public string HairColorName;

	public string EyeColorName;

	public CustomizationScript()
	{
		this.SkinColor = 3;
		this.HairStyle = 1;
		this.HairColor = 1;
		this.EyeColor = 1;
		this.Selected = 1;
		this.Phase = 1;
		this.HairColorName = string.Empty;
		this.EyeColorName = string.Empty;
	}

	public virtual void Start()
	{
		this.Senpai.gameObject.active = false;
		int num = 1360;
		Vector3 localPosition = this.ApologyWindow.localPosition;
		float num2 = localPosition.x = (float)num;
		Vector3 vector = this.ApologyWindow.localPosition = localPosition;
		this.CustomizePanel.alpha = (float)0;
		this.FinishPanel.alpha = (float)0;
		this.GenderPanel.alpha = (float)0;
		this.WhitePanel.alpha = (float)1;
	}

	public virtual void Update()
	{
		if (this.Phase == 1)
		{
			if (this.WhitePanel.alpha == (float)0)
			{
				this.GenderPanel.alpha = Mathf.MoveTowards(this.GenderPanel.alpha, (float)1, Time.deltaTime * (float)2);
				if (this.GenderPanel.alpha == (float)1)
				{
					if (Input.GetButtonDown("A"))
					{
						this.Cloud.active = true;
						this.Phase++;
					}
					if (Input.GetButtonDown("B"))
					{
						this.Apologize = true;
					}
					if (Input.GetButtonDown("X"))
					{
						this.White.color = new Color((float)0, (float)0, (float)0, (float)1);
						this.FadeOut = true;
						this.Phase = 0;
					}
				}
			}
		}
		else if (this.Phase == 2)
		{
			this.GenderPanel.alpha = Mathf.MoveTowards(this.GenderPanel.alpha, (float)0, Time.deltaTime * (float)2);
			if (this.GenderPanel.alpha == (float)0)
			{
				this.Senpai.gameObject.active = true;
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			this.CustomizePanel.alpha = Mathf.MoveTowards(this.CustomizePanel.alpha, (float)1, Time.deltaTime * (float)2);
			if (this.CustomizePanel.alpha == (float)1)
			{
				float y = this.Senpai.localEulerAngles.y - Input.GetAxis("RS");
				Vector3 localEulerAngles = this.Senpai.localEulerAngles;
				float num = localEulerAngles.y = y;
				Vector3 vector = this.Senpai.localEulerAngles = localEulerAngles;
				float y2 = this.Senpai.localEulerAngles.y - Input.GetAxis("Mouse X");
				Vector3 localEulerAngles2 = this.Senpai.localEulerAngles;
				float num2 = localEulerAngles2.y = y2;
				Vector3 vector2 = this.Senpai.localEulerAngles = localEulerAngles2;
				if (Input.GetButtonDown("A"))
				{
					int num3 = 180;
					Vector3 localEulerAngles3 = this.Senpai.localEulerAngles;
					float num4 = localEulerAngles3.y = (float)num3;
					Vector3 vector3 = this.Senpai.localEulerAngles = localEulerAngles3;
					this.Phase++;
				}
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected > 5)
					{
						this.Selected = 1;
					}
					int num5 = 650 - this.Selected * 150;
					Vector3 localPosition = this.Highlight.localPosition;
					float num6 = localPosition.y = (float)num5;
					Vector3 vector4 = this.Highlight.localPosition = localPosition;
				}
				else if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = 5;
					}
					int num7 = 650 - this.Selected * 150;
					Vector3 localPosition2 = this.Highlight.localPosition;
					float num8 = localPosition2.y = (float)num7;
					Vector3 vector5 = this.Highlight.localPosition = localPosition2;
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
						this.UpdateStyle();
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
						this.UpdateStyle();
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
				}
			}
			if (this.Selected == 1)
			{
				float y3 = Mathf.Lerp(this.Senpai.position.y, (float)-1, Time.deltaTime * (float)10);
				Vector3 position = this.Senpai.position;
				float num9 = position.y = y3;
				Vector3 vector6 = this.Senpai.position = position;
				float z = Mathf.Lerp(this.Senpai.position.z, 2.1f, Time.deltaTime * (float)10);
				Vector3 position2 = this.Senpai.position;
				float num10 = position2.z = z;
				Vector3 vector7 = this.Senpai.position = position2;
			}
			else
			{
				float y4 = Mathf.Lerp(this.Senpai.position.y, -1.6f, Time.deltaTime * (float)10);
				Vector3 position3 = this.Senpai.position;
				float num11 = position3.y = y4;
				Vector3 vector8 = this.Senpai.position = position3;
				float z2 = Mathf.Lerp(this.Senpai.position.z, 0.4f, Time.deltaTime * (float)10);
				Vector3 position4 = this.Senpai.position;
				float num12 = position4.z = z2;
				Vector3 vector9 = this.Senpai.position = position4;
			}
		}
		else if (this.Phase == 4)
		{
			float y5 = Mathf.Lerp(this.Senpai.position.y, -0.6333333f, Time.deltaTime * (float)10);
			Vector3 position5 = this.Senpai.position;
			float num13 = position5.y = y5;
			Vector3 vector10 = this.Senpai.position = position5;
			float z3 = Mathf.Lerp(this.Senpai.position.z, 2.1f, Time.deltaTime * (float)10);
			Vector3 position6 = this.Senpai.position;
			float num14 = position6.z = z3;
			Vector3 vector11 = this.Senpai.position = position6;
			this.CustomizePanel.alpha = Mathf.MoveTowards(this.CustomizePanel.alpha, (float)0, Time.deltaTime * (float)2);
			if (this.CustomizePanel.alpha == (float)0)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, (float)1, Time.deltaTime * (float)2);
			if (this.FinishPanel.alpha == (float)1)
			{
				if (Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
				if (Input.GetButtonDown("B"))
				{
					this.Selected = 1;
					int num15 = 650 - this.Selected * 150;
					Vector3 localPosition3 = this.Highlight.localPosition;
					float num16 = localPosition3.y = (float)num15;
					Vector3 vector12 = this.Highlight.localPosition = localPosition3;
					this.Phase = 7;
				}
			}
		}
		else if (this.Phase == 6)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, (float)0, Time.deltaTime * (float)2);
			if (this.FinishPanel.alpha == (float)0)
			{
				this.White.color = new Color((float)0, (float)0, (float)0, (float)1);
				this.FadeOut = true;
			}
		}
		else if (this.Phase == 7)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, (float)0, Time.deltaTime * (float)2);
			if (this.FinishPanel.alpha == (float)0)
			{
				this.Phase = 3;
			}
		}
		if (this.FadeOut)
		{
			this.WhitePanel.alpha = Mathf.MoveTowards(this.WhitePanel.alpha, (float)1, Time.deltaTime);
			this.audio.volume = (float)1 - this.WhitePanel.alpha;
			if (this.WhitePanel.alpha == (float)1)
			{
				PlayerPrefs.SetInt("CustomSenpai", 1);
				PlayerPrefs.SetInt("SenpaiSkinColor", this.SkinColor);
				PlayerPrefs.SetInt("SenpaiHairStyle", this.HairStyle);
				PlayerPrefs.SetString("SenpaiHairColor", this.HairColorName);
				PlayerPrefs.SetString("SenpaiEyeColor", this.EyeColorName);
				PlayerPrefs.SetInt("SenpaiEyeWear", this.EyeWear);
				Application.LoadLevel("IntroScene");
			}
		}
		else
		{
			this.WhitePanel.alpha = Mathf.MoveTowards(this.WhitePanel.alpha, (float)0, Time.deltaTime);
		}
		if (this.Apologize)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer < (float)1)
			{
				float x = Mathf.Lerp(this.ApologyWindow.localPosition.x, (float)0, Time.deltaTime * (float)10);
				Vector3 localPosition4 = this.ApologyWindow.localPosition;
				float num17 = localPosition4.x = x;
				Vector3 vector13 = this.ApologyWindow.localPosition = localPosition4;
			}
			else
			{
				float x2 = this.ApologyWindow.localPosition.x - Time.deltaTime;
				Vector3 localPosition5 = this.ApologyWindow.localPosition;
				float num18 = localPosition5.x = x2;
				Vector3 vector14 = this.ApologyWindow.localPosition = localPosition5;
				float x3 = this.ApologyWindow.localPosition.x - Mathf.Abs(this.ApologyWindow.localPosition.x * 0.01f) * Time.deltaTime * (float)1000;
				Vector3 localPosition6 = this.ApologyWindow.localPosition;
				float num19 = localPosition6.x = x3;
				Vector3 vector15 = this.ApologyWindow.localPosition = localPosition6;
				if (this.ApologyWindow.localPosition.x < (float)-1360)
				{
					int num20 = 1360;
					Vector3 localPosition7 = this.ApologyWindow.localPosition;
					float num21 = localPosition7.x = (float)num20;
					Vector3 vector16 = this.ApologyWindow.localPosition = localPosition7;
					this.Apologize = false;
					this.Timer = (float)0;
				}
			}
		}
	}

	public virtual void UpdateSkin()
	{
		if (this.SkinColor > 5)
		{
			this.SkinColor = 1;
		}
		else if (this.SkinColor < 1)
		{
			this.SkinColor = 5;
		}
		this.SenpaiRenderer.materials[2].mainTexture = this.FaceTextures[this.SkinColor];
		this.SenpaiRenderer.materials[0].mainTexture = this.SkinTextures[this.SkinColor];
		this.SkinColorLabel.text = "Skin Color " + this.SkinColor;
	}

	public virtual void UpdateStyle()
	{
		if (this.HairStyle > 7)
		{
			this.HairStyle = 0;
		}
		else if (this.HairStyle < 0)
		{
			this.HairStyle = 7;
		}
		for (int i = 1; i < this.Hairstyles.Length; i++)
		{
			this.Hairstyles[i].active = false;
		}
		if (this.HairStyle > 0)
		{
			this.HairRenderer = (Renderer)this.Hairstyles[this.HairStyle].GetComponent(typeof(Renderer));
			this.Hairstyles[this.HairStyle].active = true;
		}
		this.HairStyleLabel.text = "Hair Style " + this.HairStyle;
		this.UpdateColor();
	}

	public virtual void UpdateColor()
	{
		if (this.HairColor > 8)
		{
			this.HairColor = 1;
		}
		else if (this.HairColor < 1)
		{
			this.HairColor = 8;
		}
		if (this.HairStyle > 0)
		{
			this.HairRenderer = (Renderer)this.Hairstyles[this.HairStyle].GetComponent(typeof(Renderer));
		}
		if (this.HairRenderer != null)
		{
			if (this.HairColor == 1)
			{
				this.HairRenderer.material.color = new Color((float)1, (float)1, (float)1);
				this.HairColorName = "Default";
			}
			else if (this.HairColor == 2)
			{
				this.HairRenderer.material.color = new Color((float)1, (float)0, (float)0);
				this.HairColorName = "Red";
			}
			else if (this.HairColor == 3)
			{
				this.HairRenderer.material.color = new Color((float)1, (float)1, (float)0);
				this.HairColorName = "Yellow";
			}
			else if (this.HairColor == 4)
			{
				this.HairRenderer.material.color = new Color((float)0, (float)1, (float)0);
				this.HairColorName = "Green";
			}
			else if (this.HairColor == 5)
			{
				this.HairRenderer.material.color = new Color((float)0, (float)1, (float)1);
				this.HairColorName = "Cyan";
			}
			else if (this.HairColor == 6)
			{
				this.HairRenderer.material.color = new Color((float)0, (float)0, (float)1);
				this.HairColorName = "Blue";
			}
			else if (this.HairColor == 7)
			{
				this.HairRenderer.material.color = new Color((float)1, (float)0, (float)1);
				this.HairColorName = "Purple";
			}
			else if (this.HairColor == 8)
			{
				this.HairRenderer.material.color = new Color(0.5f, 0.5f, 0.5f);
				this.HairColorName = "Black";
			}
		}
		this.HairColorLabel.text = "Hair Color " + this.HairColor;
	}

	public virtual void UpdateEyes()
	{
		if (this.EyeColor > 8)
		{
			this.EyeColor = 1;
		}
		else if (this.EyeColor < 1)
		{
			this.EyeColor = 8;
		}
		Color color = default(Color);
		if (this.EyeColor == 1)
		{
			color = new Color((float)1, (float)1, (float)1);
			this.EyeColorName = "Default";
		}
		else if (this.EyeColor == 2)
		{
			color = new Color((float)1, (float)0, (float)0);
			this.EyeColorName = "Red";
		}
		else if (this.EyeColor == 3)
		{
			color = new Color((float)1, (float)1, (float)0);
			this.EyeColorName = "Yellow";
		}
		else if (this.EyeColor == 4)
		{
			color = new Color((float)0, (float)1, (float)0);
			this.EyeColorName = "Green";
		}
		else if (this.EyeColor == 5)
		{
			color = new Color((float)0, (float)1, (float)1);
			this.EyeColorName = "Cyan";
		}
		else if (this.EyeColor == 6)
		{
			color = new Color((float)0, (float)0, (float)1);
			this.EyeColorName = "Blue";
		}
		else if (this.EyeColor == 7)
		{
			color = new Color((float)1, (float)0, (float)1);
			this.EyeColorName = "Purple";
		}
		else if (this.EyeColor == 8)
		{
			color = new Color(0.5f, 0.5f, 0.5f);
			this.EyeColorName = "Black";
		}
		this.EyeR.material.color = color;
		this.EyeL.material.color = color;
		this.EyeColorLabel.text = "Eye Color " + this.EyeColor;
	}

	public virtual void UpdateEyewear()
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
			this.Eyewears[i].active = false;
		}
		if (this.EyeWear > 0)
		{
			this.Eyewears[this.EyeWear].active = true;
		}
		this.EyeWearLabel.text = "Eye Wear " + this.EyeWear;
	}

	public virtual void Main()
	{
	}
}
