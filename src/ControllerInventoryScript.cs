using System;
using UnityEngine;

[Serializable]
public class ControllerInventoryScript : MonoBehaviour
{
	private GameObject NewPickUp;

	public KeyboardInventoryScript OtherInventory;

	public YandereScript Yandere;

	public UIPanel Panel;

	public UISprite UpBox1;

	public UISprite UpBox2;

	public UISprite RightBox1;

	public UISprite RightBox2;

	public UISprite LeftBox1;

	public UISprite LeftBox2;

	public UISprite DownBox;

	public UISprite UpBox1Icon;

	public UISprite UpBox2Icon;

	public UISprite RightBox1Icon;

	public UISprite RightBox2Icon;

	public UISprite LeftBox1Icon;

	public UISprite LeftBox2Icon;

	public UISprite SelectedBox;

	public UISprite Button;

	public UISprite DPad;

	public int Selected;

	public bool AcceptingInput;

	public bool Show;

	public int X;

	public int Y;

	public ControllerInventoryScript()
	{
		this.AcceptingInput = true;
	}

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		this.Panel.alpha = (float)0;
		this.UpdateSprites();
	}

	public virtual void Update()
	{
		if (!this.Show)
		{
			this.Panel.alpha = this.Panel.alpha - Time.deltaTime * (float)10;
			if (Input.GetAxis("DpadX") != (float)0 || Input.GetAxis("DpadY") == (float)1)
			{
				this.OtherInventory.Show = false;
				this.Show = true;
				if (Input.GetAxis("DpadY") == (float)1)
				{
					this.Selected = 1;
				}
				else if (Input.GetAxis("DpadX") == (float)1)
				{
					this.Selected = 2;
				}
				else if (Input.GetAxis("DpadX") == (float)-1)
				{
					this.Selected = 4;
				}
				this.UpdateSelection();
			}
		}
		else
		{
			this.Panel.alpha = this.Panel.alpha + Time.deltaTime * (float)10;
			if (this.AcceptingInput)
			{
				if (Input.GetAxis("DpadX") != (float)0 || Input.GetAxis("DpadY") != (float)0)
				{
					if (Input.GetAxis("DpadY") == (float)1)
					{
						this.Selected = 1;
					}
					else if (Input.GetAxis("DpadY") == (float)-1)
					{
						this.Selected = 3;
					}
					else if (Input.GetAxis("DpadX") == (float)1)
					{
						this.Selected = 2;
					}
					else if (Input.GetAxis("DpadX") == (float)-1)
					{
						this.Selected = 4;
					}
					this.UpdateSelection();
				}
			}
			else if (this.X != 0)
			{
				if (Input.GetAxis("DpadY") == (float)1 || Input.GetAxis("DpadY") == (float)-1 || Input.GetAxis("DpadX") == (float)0 || Input.GetAxis("DpadX") == (float)(this.X * -1))
				{
					this.AcceptingInput = true;
					this.X = 0;
				}
			}
			else if (Input.GetAxis("DpadX") == (float)1 || Input.GetAxis("DpadX") == (float)-1 || Input.GetAxis("DpadY") == (float)0 || Input.GetAxis("DpadY") == (float)(this.Y * -1))
			{
				this.AcceptingInput = true;
				this.Y = 0;
			}
			if (Input.GetButtonDown("A"))
			{
				if (this.Selected == 4 && this.Yandere.Item1ID > 0)
				{
					this.Yandere.Armed = true;
					if (this.Yandere.EquippedID > 0)
					{
						if (this.Yandere.EquippedType != 3)
						{
							this.Yandere.Weapons[this.Yandere.EquippedID].active = false;
						}
						else
						{
							this.Yandere.BodyParts[this.Yandere.EquippedID].active = false;
						}
						if (this.Yandere.EquippedSize > 1)
						{
							this.DropItem();
						}
					}
					this.Yandere.Weapons[this.Yandere.Item1ID].active = true;
					this.Yandere.EquippedID = this.Yandere.Item1ID;
					this.Yandere.EquippedName = this.Yandere.Item1Name;
					this.Yandere.EquippedType = this.Yandere.Item1Type;
					this.Yandere.EquippedSize = 1;
					if (this.Yandere.EquippedSize > 1)
					{
						this.DropItem();
					}
				}
				if (this.Selected == 2 && this.Yandere.Item2ID > 0)
				{
					this.Yandere.Armed = true;
					if (this.Yandere.EquippedID > 0)
					{
						if (this.Yandere.EquippedType != 3)
						{
							this.Yandere.Weapons[this.Yandere.EquippedID].active = false;
						}
						else
						{
							this.Yandere.BodyParts[this.Yandere.EquippedID].active = false;
						}
						if (this.Yandere.EquippedSize > 1)
						{
							this.DropItem();
						}
					}
					this.Yandere.Weapons[this.Yandere.Item2ID].active = true;
					this.Yandere.EquippedID = this.Yandere.Item2ID;
					this.Yandere.EquippedName = this.Yandere.Item2Name;
					this.Yandere.EquippedType = this.Yandere.Item2Type;
					this.Yandere.EquippedSize = 1;
				}
				if (this.Selected == 3 && this.Yandere.EquippedID > 0)
				{
					if (this.Yandere.EquippedSize > 1)
					{
						this.DropItem();
					}
					if (this.Yandere.EquippedType != 3)
					{
						this.Yandere.Weapons[this.Yandere.EquippedID].active = false;
					}
					else
					{
						this.Yandere.BodyParts[this.Yandere.EquippedID].active = false;
					}
					this.Yandere.Armed = false;
					this.Yandere.EquippedID = 0;
					this.Yandere.EquippedName = string.Empty;
					this.Yandere.EquippedType = 0;
					this.Yandere.EquippedSize = 0;
					if (this.Yandere.EquippedID == 10)
					{
						int num = 0;
						Color color = this.Yandere.Mop.Button.color;
						float num2 = color.a = (float)num;
						Color color2 = this.Yandere.Mop.Button.color = color;
						int num3 = 0;
						Color color3 = this.Yandere.Mop.Label.color;
						float num4 = color3.a = (float)num3;
						Color color4 = this.Yandere.Mop.Label.color = color3;
					}
				}
				if (this.Selected == 1 && this.Yandere.Item3ID > 0 && this.Yandere.CaseDropArea.Obstacles == 0)
				{
					this.Yandere.Item3Name = string.Empty;
					this.Yandere.Item3Type = 0;
					this.Yandere.Item3ID = 0;
					this.Yandere.Item3.transform.parent = null;
					this.Yandere.Item3.transform.position = this.Yandere.CaseDropArea.transform.position;
					this.Yandere.Item3.transform.eulerAngles = this.Yandere.CaseDropArea.transform.eulerAngles;
					((CaseScript)this.Yandere.Item3.GetComponent(typeof(CaseScript))).Unequip();
					this.UpdateSprites();
				}
				this.Show = false;
			}
			if (Input.GetButtonDown("B"))
			{
				this.Show = false;
				this.Selected = 0;
			}
		}
	}

	public virtual void UpdateSelection()
	{
		this.AcceptingInput = false;
		this.LeftBox2.color = new Color((float)0, (float)0, (float)0, (float)0);
		this.RightBox2.color = new Color((float)0, (float)0, (float)0, (float)0);
		this.UpBox2.color = new Color((float)0, (float)0, (float)0, (float)0);
		int num = 0;
		Color color = this.LeftBox2Icon.color;
		float num2 = color.a = (float)num;
		Color color2 = this.LeftBox2Icon.color = color;
		int num3 = 0;
		Color color3 = this.RightBox2Icon.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.RightBox2Icon.color = color3;
		int num5 = 0;
		Color color5 = this.UpBox2Icon.color;
		float num6 = color5.a = (float)num5;
		Color color6 = this.UpBox2Icon.color = color5;
		if (Input.GetAxis("DpadX") == (float)1 || Input.GetAxis("DpadX") == (float)-1)
		{
			this.X = (int)Input.GetAxis("DpadX");
		}
		else
		{
			this.Y = (int)Input.GetAxis("DpadY");
		}
		this.LeftBox1.color = new Color((float)0, (float)0, (float)0, (float)1);
		this.RightBox1.color = new Color((float)0, (float)0, (float)0, (float)1);
		this.UpBox1.color = new Color((float)0, (float)0, (float)0, (float)1);
		this.DownBox.color = new Color((float)0, (float)0, (float)0, (float)1);
		if (this.Selected == 1)
		{
			this.SelectedBox = this.UpBox1;
		}
		else if (this.Selected == 2)
		{
			this.SelectedBox = this.RightBox1;
		}
		else if (this.Selected == 3)
		{
			this.SelectedBox = this.DownBox;
		}
		else if (this.Selected == 4)
		{
			this.SelectedBox = this.LeftBox1;
		}
		else if (this.Selected == 5)
		{
			this.SelectedBox = this.UpBox2;
		}
		else if (this.Selected == 6)
		{
			this.SelectedBox = this.RightBox2;
		}
		else if (this.Selected == 7)
		{
			this.SelectedBox = this.LeftBox2;
		}
		if (this.SelectedBox != null)
		{
			this.SelectedBox.color = new Color((float)1, (float)1, (float)1, (float)1);
			float x = this.SelectedBox.transform.localPosition.x;
			Vector3 localPosition = this.Button.transform.localPosition;
			float num7 = localPosition.x = x;
			Vector3 vector = this.Button.transform.localPosition = localPosition;
			float y = this.SelectedBox.transform.localPosition.y - (float)50;
			Vector3 localPosition2 = this.Button.transform.localPosition;
			float num8 = localPosition2.y = y;
			Vector3 vector2 = this.Button.transform.localPosition = localPosition2;
		}
	}

	public virtual void UpdateSprites()
	{
		this.UpBox1Icon.spriteName = this.Yandere.Item3Name;
		this.RightBox1Icon.spriteName = this.Yandere.Item2Name;
		this.LeftBox1Icon.spriteName = this.Yandere.Item1Name;
		int num = 1;
		Color color = this.UpBox1Icon.color;
		float num2 = color.a = (float)num;
		Color color2 = this.UpBox1Icon.color = color;
		int num3 = 1;
		Color color3 = this.RightBox1Icon.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.RightBox1Icon.color = color3;
		int num5 = 1;
		Color color5 = this.LeftBox1Icon.color;
		float num6 = color5.a = (float)num5;
		Color color6 = this.LeftBox1Icon.color = color5;
	}

	public virtual void DropItem()
	{
		GameObject gameObject;
		if (this.Yandere.EquippedType != 3)
		{
			gameObject = (GameObject)UnityEngine.Object.Instantiate(this.Yandere.WeaponPickups[this.Yandere.EquippedID], this.Yandere.RightHand.position, Quaternion.identity);
		}
		else
		{
			gameObject = (GameObject)UnityEngine.Object.Instantiate(this.Yandere.BodyPartPickups[this.Yandere.EquippedID], this.Yandere.RightHand.position, Quaternion.identity);
		}
		gameObject.transform.eulerAngles = this.Yandere.RightHand.eulerAngles;
		float y = gameObject.transform.eulerAngles.y - (float)180;
		Vector3 eulerAngles = gameObject.transform.eulerAngles;
		float num = eulerAngles.y = y;
		Vector3 vector = gameObject.transform.eulerAngles = eulerAngles;
	}

	public virtual void Main()
	{
	}
}
