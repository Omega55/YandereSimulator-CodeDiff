using System;
using UnityEngine;

public class EventEditorScript : MonoBehaviour
{
	[SerializeField]
	private UIPanel mainPanel;

	[SerializeField]
	private UIPanel eventPanel;

	[SerializeField]
	private UILabel titleLabel;

	[SerializeField]
	private PromptBarScript promptBar;

	private InputManagerScript inputManager;

	private void Awake()
	{
		this.inputManager = Object.FindObjectOfType<InputManagerScript>();
	}

	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.eventPanel.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		this.HandleInput();
	}
}
