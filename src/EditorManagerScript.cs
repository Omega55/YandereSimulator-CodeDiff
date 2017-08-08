using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditorManagerScript : MonoBehaviour
{
	[SerializeField]
	private UIPanel mainPanel;

	[SerializeField]
	private UIPanel[] editorPanels;

	[SerializeField]
	private UILabel cursorLabel;

	[SerializeField]
	private PromptBarScript promptBar;

	private int buttonIndex;

	private const int ButtonCount = 3;

	private InputManagerScript inputManager;

	private void Awake()
	{
		this.buttonIndex = 0;
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	private void Start()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	private void OnEnable()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	public static Dictionary<string, object>[] DeserializeJson(string filename)
	{
		string path = Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", filename));
		string value = File.ReadAllText(path);
		return JsonReader.Deserialize<Dictionary<string, object>[]>(value);
	}

	private void HandleInput()
	{
		bool buttonDown = Input.GetButtonDown("B");
		if (buttonDown)
		{
			SceneManager.LoadScene("TitleScene");
		}
		bool tappedUp = this.inputManager.TappedUp;
		bool tappedDown = this.inputManager.TappedDown;
		if (tappedUp)
		{
			this.buttonIndex = ((this.buttonIndex <= 0) ? 2 : (this.buttonIndex - 1));
		}
		else if (tappedDown)
		{
			this.buttonIndex = ((this.buttonIndex >= 2) ? 0 : (this.buttonIndex + 1));
		}
		bool flag = tappedUp || tappedDown;
		if (flag)
		{
			Transform transform = this.cursorLabel.transform;
			transform.localPosition = new Vector3(transform.localPosition.x, 100f - (float)this.buttonIndex * 100f, transform.localPosition.z);
		}
		bool buttonDown2 = Input.GetButtonDown("A");
		if (buttonDown2)
		{
			this.editorPanels[this.buttonIndex].gameObject.SetActive(true);
			this.mainPanel.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		this.HandleInput();
	}
}
