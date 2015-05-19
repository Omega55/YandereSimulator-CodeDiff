using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class WeaponMenuScript : MonoBehaviour
{
	public InputDeviceScript InputDevice;

	public PauseScreenScript PauseScreen;

	public YandereScript Yandere;

	public Transform KeyboardMenu;

	public bool KeyboardShow;

	public bool Show;

	public UISprite[] BG;

	public UISprite[] Outline;

	public UISprite[] Item;

	public UISprite[] KeyboardBG;

	public UISprite[] KeyboardOutline;

	public UISprite[] KeyboardItem;

	public int Selected;

	public Color OriginalColor;

	public Transform Button;

	public float Timer;

	public WeaponMenuScript()
	{
		this.Selected = 1;
	}

	public virtual void Start()
	{
		this.KeyboardMenu.localScale = new Vector3((float)0, (float)0, (float)0);
		this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.OriginalColor = this.BG[1].color;
		this.UpdateSprites();
	}

	public virtual void Update()
	{
		if (!this.PauseScreen.Show)
		{
			if (this.Yandere.CanMove && !this.Yandere.Aiming)
			{
				if (Input.GetAxis("DpadX") < -0.5f || Input.GetAxis("DpadX") > 0.5f || Input.GetAxis("DpadY") > 0.5f || Input.GetAxis("DpadY") < -0.5f)
				{
					this.Yandere.EmptyHands();
					if (Input.GetAxis("DpadX") < -0.5f || Input.GetAxis("DpadX") > 0.5f || Input.GetAxis("DpadY") > 0.5f)
					{
						this.KeyboardShow = false;
						this.Show = true;
					}
					if (Input.GetAxis("DpadX") < -0.5f)
					{
						this.Button.localPosition = new Vector3((float)-340, (float)0, (float)0);
						this.Selected = 1;
					}
					else if (Input.GetAxis("DpadX") > 0.5f)
					{
						this.Button.localPosition = new Vector3((float)340, (float)0, (float)0);
						this.Selected = 2;
					}
					else if (Input.GetAxis("DpadY") > 0.5f)
					{
						this.Button.localPosition = new Vector3((float)0, (float)340, (float)0);
						this.Selected = 3;
					}
					else if (Input.GetAxis("DpadY") < 0.5f)
					{
						this.Button.localPosition = new Vector3((float)0, (float)-210, (float)0);
						this.Selected = 4;
					}
					this.UpdateSprites();
				}
				if (Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3") || Input.GetKeyDown("4"))
				{
					this.Yandere.EmptyHands();
					this.KeyboardShow = true;
					this.Show = false;
					this.Timer = (float)0;
					if (Input.GetKeyDown("1"))
					{
						this.Selected = 4;
						if (this.Yandere.Equipped > 0)
						{
							this.Yandere.Unequip();
						}
						if (this.Yandere.PickUp != null)
						{
							this.Yandere.PickUp.Drop();
						}
						this.Yandere.Mopping = false;
					}
					else if (Input.GetKeyDown("2"))
					{
						this.Selected = 1;
						this.Equip();
					}
					else if (Input.GetKeyDown("3"))
					{
						this.Selected = 2;
						this.Equip();
					}
					else if (Input.GetKeyDown("4"))
					{
						this.Selected = 3;
					}
					this.UpdateSprites();
				}
			}
			if (this.Yandere.CanMove)
			{
				if (!this.Show)
				{
					if (Input.GetAxis("DpadY") < -0.5f)
					{
						if (this.Yandere.Equipped > 0)
						{
							this.Yandere.Unequip();
						}
						if (this.Yandere.PickUp != null)
						{
							this.Yandere.PickUp.Drop();
						}
						this.Yandere.Mopping = false;
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						if (this.Selected < 3)
						{
							if (this.Yandere.Weapon[this.Selected] != null)
							{
								this.Equip();
							}
						}
						else if (this.Selected == 4)
						{
							if (this.Yandere.Equipped > 0)
							{
								this.Yandere.Unequip();
							}
							if (this.Yandere.PickUp != null)
							{
								this.Yandere.PickUp.Drop();
							}
							this.Yandere.Mopping = false;
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.Show = false;
					}
				}
			}
		}
		if (!this.Show)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
		else
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			if (!this.Yandere.CanMove || this.Yandere.Aiming || this.PauseScreen.Show || this.InputDevice.Type == 2)
			{
				this.Show = false;
			}
		}
		if (!this.KeyboardShow)
		{
			this.KeyboardMenu.localScale = Vector3.Lerp(this.KeyboardMenu.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
		else
		{
			this.KeyboardMenu.localScale = Vector3.Lerp(this.KeyboardMenu.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)3)
			{
				this.KeyboardShow = false;
			}
			if (!this.Yandere.CanMove || this.Yandere.Aiming || this.PauseScreen.Show || this.InputDevice.Type == 1)
			{
				this.KeyboardShow = false;
			}
		}
	}

	public virtual void Equip()
	{
		if (this.Yandere.Weapon[this.Selected] != null)
		{
			if (this.Yandere.PickUp != null)
			{
				this.Yandere.PickUp.Drop();
			}
			if (this.Yandere.Equipped == 3)
			{
				this.Yandere.Weapon[3].Drop();
			}
			if (this.Yandere.Weapon[1] != null)
			{
				this.Yandere.Weapon[1].active = false;
			}
			if (this.Yandere.Weapon[2] != null)
			{
				this.Yandere.Weapon[2].active = false;
			}
			this.Yandere.Weapon[this.Selected].active = true;
			this.Yandere.Equipped = this.Selected;
			this.Yandere.Armed = true;
			this.Yandere.StudentManager.UpdateStudents();
			this.Yandere.WeaponManager.UpdateLabels();
			if (this.Yandere.Weapon[this.Yandere.Equipped].Suspicious)
			{
				if (!this.Yandere.WeaponWarning)
				{
					this.Yandere.NotificationManager.DisplayNotification("Armed");
					this.Yandere.WeaponWarning = true;
				}
			}
			else
			{
				this.Yandere.WeaponWarning = false;
			}
			this.Show = false;
		}
	}

	public virtual void UpdateSprites()
	{
		for (int i = 1; i < 3; i++)
		{
			if (this.Selected == i)
			{
				this.KeyboardBG[i].color = new Color((float)1, (float)1, (float)1, (float)1);
				this.BG[i].color = new Color((float)1, (float)1, (float)1, (float)1);
			}
			else
			{
				this.KeyboardBG[i].color = this.OriginalColor;
				this.BG[i].color = this.OriginalColor;
			}
			if (this.Yandere.Weapon[i] == null)
			{
				int num = 0;
				Color color = this.Item[i].color;
				float num2 = color.a = (float)num;
				Color color2 = this.Item[i].color = color;
				float a = 0.5f;
				Color color3 = this.BG[i].color;
				float num3 = color3.a = a;
				Color color4 = this.BG[i].color = color3;
				float a2 = 0.5f;
				Color color5 = this.Outline[i].color;
				float num4 = color5.a = a2;
				Color color6 = this.Outline[i].color = color5;
				int num5 = 0;
				Color color7 = this.KeyboardItem[i].color;
				float num6 = color7.a = (float)num5;
				Color color8 = this.KeyboardItem[i].color = color7;
				float a3 = 0.5f;
				Color color9 = this.KeyboardBG[i].color;
				float num7 = color9.a = a3;
				Color color10 = this.KeyboardBG[i].color = color9;
				float a4 = 0.5f;
				Color color11 = this.KeyboardOutline[i].color;
				float num8 = color11.a = a4;
				Color color12 = this.KeyboardOutline[i].color = color11;
			}
			else
			{
				this.Item[i].spriteName = this.Yandere.Weapon[i].SpriteName;
				int num9 = 1;
				Color color13 = this.Item[i].color;
				float num10 = color13.a = (float)num9;
				Color color14 = this.Item[i].color = color13;
				int num11 = 1;
				Color color15 = this.BG[i].color;
				float num12 = color15.a = (float)num11;
				Color color16 = this.BG[i].color = color15;
				int num13 = 1;
				Color color17 = this.Outline[i].color;
				float num14 = color17.a = (float)num13;
				Color color18 = this.Outline[i].color = color17;
				this.KeyboardItem[i].spriteName = this.Yandere.Weapon[i].SpriteName;
				int num15 = 1;
				Color color19 = this.KeyboardItem[i].color;
				float num16 = color19.a = (float)num15;
				Color color20 = this.KeyboardItem[i].color = color19;
				int num17 = 1;
				Color color21 = this.KeyboardBG[i].color;
				float num18 = color21.a = (float)num17;
				Color color22 = this.KeyboardBG[i].color = color21;
				int num19 = 1;
				Color color23 = this.KeyboardOutline[i].color;
				float num20 = color23.a = (float)num19;
				Color color24 = this.KeyboardOutline[i].color = color23;
			}
		}
		if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(this.Yandere, "Container"), null))
		{
			int num21 = 0;
			Color color25 = this.KeyboardItem[3].color;
			float num22 = color25.a = (float)num21;
			Color color26 = this.KeyboardItem[3].color = color25;
			int num23 = 0;
			Color color27 = this.Item[3].color;
			float num24 = color27.a = (float)num23;
			Color color28 = this.Item[3].color = color27;
			if (this.Selected == 3)
			{
				this.KeyboardBG[3].color = new Color((float)1, (float)1, (float)1, (float)1);
				this.BG[3].color = new Color((float)1, (float)1, (float)1, (float)1);
			}
			else
			{
				this.KeyboardBG[3].color = this.OriginalColor;
				this.BG[3].color = this.OriginalColor;
			}
			float a5 = 0.5f;
			Color color29 = this.BG[3].color;
			float num25 = color29.a = a5;
			Color color30 = this.BG[3].color = color29;
			float a6 = 0.5f;
			Color color31 = this.Outline[3].color;
			float num26 = color31.a = a6;
			Color color32 = this.Outline[3].color = color31;
			float a7 = 0.5f;
			Color color33 = this.KeyboardBG[3].color;
			float num27 = color33.a = a7;
			Color color34 = this.KeyboardBG[3].color = color33;
			float a8 = 0.5f;
			Color color35 = this.KeyboardOutline[3].color;
			float num28 = color35.a = a8;
			Color color36 = this.KeyboardOutline[3].color = color35;
		}
		else
		{
			int num29 = 1;
			Color color37 = this.Item[3].color;
			float num30 = color37.a = (float)num29;
			Color color38 = this.Item[3].color = color37;
			this.BG[3].color = this.OriginalColor;
			int num31 = 1;
			Color color39 = this.BG[3].color;
			float num32 = color39.a = (float)num31;
			Color color40 = this.BG[3].color = color39;
			int num33 = 1;
			Color color41 = this.Outline[3].color;
			float num34 = color41.a = (float)num33;
			Color color42 = this.Outline[3].color = color41;
			int num35 = 1;
			Color color43 = this.KeyboardItem[3].color;
			float num36 = color43.a = (float)num35;
			Color color44 = this.KeyboardItem[3].color = color43;
			this.KeyboardBG[3].color = this.OriginalColor;
			int num37 = 1;
			Color color45 = this.KeyboardBG[3].color;
			float num38 = color45.a = (float)num37;
			Color color46 = this.KeyboardBG[3].color = color45;
			int num39 = 1;
			Color color47 = this.KeyboardOutline[3].color;
			float num40 = color47.a = (float)num39;
			Color color48 = this.KeyboardOutline[3].color = color47;
		}
		if (this.Selected == 4)
		{
			this.KeyboardBG[4].color = new Color((float)1, (float)1, (float)1, (float)1);
			this.BG[4].color = new Color((float)1, (float)1, (float)1, (float)1);
		}
		else
		{
			this.KeyboardBG[4].color = this.OriginalColor;
			this.BG[4].color = this.OriginalColor;
		}
	}

	public virtual void Main()
	{
	}
}
