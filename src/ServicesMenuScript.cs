using System;
using UnityEngine;

[Serializable]
public class ServicesMenuScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public GameObject FavorMenu;

	public GameObject MainMenu;

	public Transform Highlight;

	public UILabel PantyShots;

	public UILabel DescLabel;

	public UILabel[] FavorLabels;

	public string[] DescText;

	public int ID;

	public Transform TextMessages;

	public GameObject ServicesScreen;

	public GameObject NewMessage;

	public GameObject Message;

	public int MessageHeight;

	public string MessageText;

	public ServicesMenuScript()
	{
		this.ID = 1;
		this.MessageText = string.Empty;
	}

	public virtual void Start()
	{
		this.DescLabel.text = this.DescText[this.ID];
	}

	public virtual void Update()
	{
		if (this.ServicesScreen.active)
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
			if (Input.GetButtonDown("A") && this.FavorLabels[this.ID].color.a == (float)1 && this.ID == 4)
			{
				PlayerPrefs.SetInt("PantyShots", PlayerPrefs.GetInt("PantyShots") - 10);
				PlayerPrefs.SetInt("DarkSecret", 1);
				this.SpawnMessage();
			}
		}
		if (Input.GetButtonDown("B"))
		{
			if (this.TextMessages.gameObject.active)
			{
				this.TextMessages.gameObject.active = false;
				this.PauseScreen.ExitPhone();
				UnityEngine.Object.Destroy(this.NewMessage);
			}
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[5].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.FavorMenu.active = true;
			this.active = false;
		}
	}

	public virtual void UpdatePantyShots()
	{
		this.PantyShots.text = string.Empty + PlayerPrefs.GetInt("PantyShots");
		if (PlayerPrefs.GetInt("PantyShots") >= 8)
		{
			if (PlayerPrefs.GetInt("DarkSecret") == 0)
			{
				int num = 1;
				Color color = this.FavorLabels[4].color;
				float num2 = color.a = (float)num;
				Color color2 = this.FavorLabels[4].color = color;
			}
			else
			{
				float a = 0.5f;
				Color color3 = this.FavorLabels[4].color;
				float num3 = color3.a = a;
				Color color4 = this.FavorLabels[4].color = color3;
			}
		}
		else
		{
			float a2 = 0.5f;
			Color color5 = this.FavorLabels[4].color;
			float num4 = color5.a = a2;
			Color color6 = this.FavorLabels[4].color = color5;
		}
	}

	public virtual void SpawnMessage()
	{
		this.TextMessages.gameObject.active = true;
		this.PauseScreen.Sideways = false;
		this.ServicesScreen.active = false;
		if (this.NewMessage != null)
		{
			UnityEngine.Object.Destroy(this.NewMessage);
		}
		this.NewMessage = (GameObject)UnityEngine.Object.Instantiate(this.Message);
		this.NewMessage.transform.parent = this.TextMessages;
		this.NewMessage.transform.localPosition = new Vector3((float)-225, (float)-275, (float)0);
		this.NewMessage.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		this.NewMessage.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.MessageText = "You're going to love this. I've got video footage of Kokona selling used panties to a boy from another school. Enjoy.";
		this.MessageHeight = 5;
		((UISprite)this.NewMessage.GetComponent(typeof(UISprite))).height = 36 + 36 * this.MessageHeight;
		((TextMessageScript)this.NewMessage.GetComponent(typeof(TextMessageScript))).Label.text = this.MessageText;
	}

	public virtual void Main()
	{
	}
}
