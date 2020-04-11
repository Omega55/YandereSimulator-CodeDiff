using System;
using UnityEngine;

public class TitleSaveFilesScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public TitleSaveDataScript[] SaveDatas;

	public GameObject ConfirmationWindow;

	public TitleMenuScript Menu;

	public Transform Highlight;

	public bool Show;

	public int ID = 1;

	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.UpdateHighlight();
	}

	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
		if (!this.ConfirmationWindow.activeInHierarchy)
		{
			if (this.InputManager.TappedDown)
			{
				this.ID++;
				if (this.ID > 3)
				{
					this.ID = 1;
				}
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedUp)
			{
				this.ID--;
				if (this.ID < 1)
				{
					this.ID = 3;
				}
				this.UpdateHighlight();
			}
		}
		if (base.transform.localPosition.x < 50f)
		{
			if (!this.ConfirmationWindow.activeInHierarchy)
			{
				if (Input.GetButtonDown("A"))
				{
					GameGlobals.Profile = this.ID;
					Globals.DeleteAll();
					GameGlobals.Profile = this.ID;
					this.Menu.FadeOut = true;
					this.Menu.Fading = true;
					return;
				}
				if (Input.GetButtonDown("X"))
				{
					this.ConfirmationWindow.SetActive(true);
					return;
				}
			}
			else
			{
				if (Input.GetButtonDown("A"))
				{
					PlayerPrefs.SetInt("ProfileCreated_" + this.ID, 0);
					this.ConfirmationWindow.SetActive(false);
					this.SaveDatas[this.ID].Start();
					return;
				}
				if (Input.GetButtonDown("B"))
				{
					this.ConfirmationWindow.SetActive(false);
				}
			}
		}
	}

	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(0f, 700f - 350f * (float)this.ID, 0f);
	}
}
