using System;
using UnityEngine;

[Serializable]
public class KeyboardInventoryScript : MonoBehaviour
{
	public ControllerInventoryScript OtherInventory;

	public UIPanel Panel;

	public UISprite Box1;

	public UISprite Box2;

	public UISprite Box3;

	public UISprite Box4;

	public UISprite Box5;

	public UISprite Box6;

	public UISprite Box7;

	public UISprite Box1Icon;

	public UISprite Box2Icon;

	public UISprite Box3Icon;

	public UISprite Box4Icon;

	public UISprite Box5Icon;

	public UISprite Box6Icon;

	public UISprite Box7Icon;

	public UISprite SelectedBox;

	public int Stabbing;

	public int Slashing;

	public int Clubbing;

	public float Timer;

	public bool Show;

	public virtual void Start()
	{
		this.Panel.alpha = (float)0;
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3") || Input.GetKeyDown("4") || Input.GetKeyDown("5") || Input.GetKeyDown("6") || Input.GetKeyDown("7"))
		{
			this.OtherInventory.Show = false;
			this.Show = true;
			this.Timer = (float)5;
			this.UpdateSelection();
		}
		if (this.Show)
		{
			this.Panel.alpha = this.Panel.alpha + Time.deltaTime * (float)10;
		}
		else
		{
			this.Panel.alpha = this.Panel.alpha - Time.deltaTime * (float)10;
		}
		if (this.Timer > (float)0)
		{
			this.Timer -= Time.deltaTime;
		}
		else
		{
			this.Show = false;
		}
	}

	public virtual void UpdateSelection()
	{
		if (Input.GetKeyDown("1"))
		{
			this.SelectedBox = this.Box1;
		}
		if (Input.GetKeyDown("2") && this.Stabbing > 0)
		{
			this.SelectedBox = this.Box2;
		}
		if (Input.GetKeyDown("3") && this.Stabbing > 1)
		{
			this.SelectedBox = this.Box3;
		}
		if (Input.GetKeyDown("4") && this.Slashing > 0)
		{
			this.SelectedBox = this.Box4;
		}
		if (Input.GetKeyDown("5") && this.Slashing > 1)
		{
			this.SelectedBox = this.Box5;
		}
		if (Input.GetKeyDown("6") && this.Clubbing > 0)
		{
			this.SelectedBox = this.Box6;
		}
		if (Input.GetKeyDown("7") && this.Clubbing > 1)
		{
			this.SelectedBox = this.Box7;
		}
		if (this.Stabbing < 1)
		{
			int num = 0;
			Color color = this.Box2Icon.color;
			float num2 = color.a = (float)num;
			Color color2 = this.Box2Icon.color = color;
		}
		else
		{
			int num3 = 1;
			Color color3 = this.Box2Icon.color;
			float num4 = color3.a = (float)num3;
			Color color4 = this.Box2Icon.color = color3;
		}
		if (this.Stabbing < 2)
		{
			int num5 = 0;
			Color color5 = this.Box3Icon.color;
			float num6 = color5.a = (float)num5;
			Color color6 = this.Box3Icon.color = color5;
		}
		else
		{
			int num7 = 1;
			Color color7 = this.Box3Icon.color;
			float num8 = color7.a = (float)num7;
			Color color8 = this.Box3Icon.color = color7;
		}
		if (this.Slashing < 1)
		{
			int num9 = 0;
			Color color9 = this.Box4Icon.color;
			float num10 = color9.a = (float)num9;
			Color color10 = this.Box4Icon.color = color9;
		}
		else
		{
			int num11 = 1;
			Color color11 = this.Box4Icon.color;
			float num12 = color11.a = (float)num11;
			Color color12 = this.Box4Icon.color = color11;
		}
		if (this.Slashing < 2)
		{
			int num13 = 0;
			Color color13 = this.Box5Icon.color;
			float num14 = color13.a = (float)num13;
			Color color14 = this.Box5Icon.color = color13;
		}
		else
		{
			int num15 = 1;
			Color color15 = this.Box5Icon.color;
			float num16 = color15.a = (float)num15;
			Color color16 = this.Box5Icon.color = color15;
		}
		if (this.Clubbing < 1)
		{
			int num17 = 0;
			Color color17 = this.Box6Icon.color;
			float num18 = color17.a = (float)num17;
			Color color18 = this.Box6Icon.color = color17;
		}
		else
		{
			int num19 = 1;
			Color color19 = this.Box6Icon.color;
			float num20 = color19.a = (float)num19;
			Color color20 = this.Box6Icon.color = color19;
		}
		if (this.Clubbing < 2)
		{
			int num21 = 0;
			Color color21 = this.Box7Icon.color;
			float num22 = color21.a = (float)num21;
			Color color22 = this.Box7Icon.color = color21;
		}
		else
		{
			int num23 = 1;
			Color color23 = this.Box7Icon.color;
			float num24 = color23.a = (float)num23;
			Color color24 = this.Box7Icon.color = color23;
		}
		this.Box1.color = new Color((float)0, (float)0, (float)0, (float)1);
		this.Box2.color = new Color((float)0, (float)0, (float)0, (float)1);
		this.Box3.color = new Color((float)0, (float)0, (float)0, (float)1);
		this.Box4.color = new Color((float)0, (float)0, (float)0, (float)1);
		this.Box5.color = new Color((float)0, (float)0, (float)0, (float)1);
		this.Box6.color = new Color((float)0, (float)0, (float)0, (float)1);
		this.Box7.color = new Color((float)0, (float)0, (float)0, (float)1);
		if (this.SelectedBox != null)
		{
			this.SelectedBox.color = new Color((float)1, (float)1, (float)1, (float)1);
		}
	}

	public virtual void Main()
	{
	}
}
