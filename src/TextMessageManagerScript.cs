using System;
using UnityEngine;

[Serializable]
public class TextMessageManagerScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public GameObject ServicesMenu;

	private GameObject NewMessage;

	public GameObject Message;

	public int MessageHeight;

	public string MessageText;

	public TextMessageManagerScript()
	{
		this.MessageText = string.Empty;
	}

	public virtual void Update()
	{
		if (Input.GetButtonDown("B"))
		{
			UnityEngine.Object.Destroy(this.NewMessage);
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[5].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.PauseScreen.Sideways = true;
			this.ServicesMenu.active = true;
			this.active = false;
		}
	}

	public virtual void SpawnMessage()
	{
		this.PromptBar.ClearButtons();
		this.PromptBar.Label[1].text = "Exit";
		this.PromptBar.UpdateButtons();
		this.PauseScreen.Sideways = false;
		this.ServicesMenu.active = false;
		this.active = true;
		if (this.NewMessage != null)
		{
			UnityEngine.Object.Destroy(this.NewMessage);
		}
		this.NewMessage = (GameObject)UnityEngine.Object.Instantiate(this.Message);
		this.NewMessage.transform.parent = this.transform;
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
