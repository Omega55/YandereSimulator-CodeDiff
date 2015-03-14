using System;
using UnityEngine;

[Serializable]
public class FavorMenuScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public GameObject MainMenu;

	public Transform Highlight;

	public UILabel PantyShots;

	public UILabel DescLabel;

	public string[] DescText;

	public int ID;

	public FavorMenuScript()
	{
		this.ID = 1;
	}

	public virtual void Start()
	{
		this.DescLabel.text = this.DescText[this.ID];
	}

	public virtual void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.ID--;
			if (this.ID < 1)
			{
				this.ID = 8;
			}
			int num = 225 - 50 * this.ID;
			Vector3 localPosition = this.Highlight.localPosition;
			float num2 = localPosition.y = (float)num;
			Vector3 vector = this.Highlight.localPosition = localPosition;
			this.DescLabel.text = this.DescText[this.ID];
		}
		if (this.InputManager.TappedDown)
		{
			this.ID++;
			if (this.ID > 8)
			{
				this.ID = 1;
			}
			int num3 = 225 - 50 * this.ID;
			Vector3 localPosition2 = this.Highlight.localPosition;
			float num4 = localPosition2.y = (float)num3;
			Vector3 vector2 = this.Highlight.localPosition = localPosition2;
			this.DescLabel.text = this.DescText[this.ID];
		}
		if (Input.GetButtonDown("B"))
		{
			this.PauseScreen.Sideways = false;
			this.MainMenu.active = true;
			this.active = false;
		}
	}

	public virtual void UpdatePantyShots()
	{
		this.PantyShots.text = string.Empty + PlayerPrefs.GetInt("PantyShots");
	}

	public virtual void Main()
	{
	}
}
