using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeVideoGamesScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public HomeDarknessScript HomeDarkness;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public PromptBarScript PromptBar;

	public Texture[] TitleScreens;

	public UITexture TitleScreen;

	public GameObject Controller;

	public Transform Highlight;

	public UILabel[] GameTitles;

	public Transform TV;

	public int ID = 1;

	private void Start()
	{
		if (TaskGlobals.GetTaskStatus(14) == 0)
		{
			this.TitleScreens[1] = this.TitleScreens[2];
			UILabel uilabel = this.GameTitles[1];
			uilabel.text = this.GameTitles[2].text;
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
		}
		this.TitleScreen.mainTexture = this.TitleScreens[1];
	}

	private void Update()
	{
		if (this.HomeCamera.Destination == this.HomeCamera.Destinations[5])
		{
			if (Input.GetKeyDown("y"))
			{
				TaskGlobals.SetTaskStatus(14, 1);
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
			this.TV.localScale = Vector3.Lerp(this.TV.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (!this.HomeYandere.CanMove)
			{
				if (!this.HomeDarkness.FadeOut)
				{
					if (this.InputManager.TappedDown)
					{
						this.ID++;
						if (this.ID > 5)
						{
							this.ID = 1;
						}
						this.TitleScreen.mainTexture = this.TitleScreens[this.ID];
						this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 150f - (float)this.ID * 50f, this.Highlight.localPosition.z);
					}
					if (this.InputManager.TappedUp)
					{
						this.ID--;
						if (this.ID < 1)
						{
							this.ID = 5;
						}
						this.TitleScreen.mainTexture = this.TitleScreens[this.ID];
						this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 150f - (float)this.ID * 50f, this.Highlight.localPosition.z);
					}
					if (Input.GetButtonDown("A") && this.GameTitles[this.ID].color.a == 1f)
					{
						Transform transform = this.HomeCamera.Targets[5];
						transform.localPosition = new Vector3(transform.localPosition.x, 1.153333f, transform.localPosition.z);
						this.HomeDarkness.Sprite.color = new Color(this.HomeDarkness.Sprite.color.r, this.HomeDarkness.Sprite.color.g, this.HomeDarkness.Sprite.color.b, -1f);
						this.HomeDarkness.FadeOut = true;
						this.HomeWindow.Show = false;
						this.PromptBar.Show = false;
						this.HomeCamera.ID = 5;
					}
					if (Input.GetButtonDown("B"))
					{
						this.Quit();
					}
				}
				else
				{
					Transform transform2 = this.HomeCamera.Destinations[5];
					Transform transform3 = this.HomeCamera.Targets[5];
					transform2.position = new Vector3(Mathf.Lerp(transform2.position.x, transform3.position.x, Time.deltaTime * 0.75f), Mathf.Lerp(transform2.position.y, transform3.position.y, Time.deltaTime * 10f), Mathf.Lerp(transform2.position.z, transform3.position.z, Time.deltaTime * 10f));
				}
			}
		}
		else
		{
			this.TV.localScale = Vector3.Lerp(this.TV.localScale, Vector3.zero, Time.deltaTime * 10f);
		}
	}

	public void Quit()
	{
		this.Controller.transform.localPosition = new Vector3(0.20385f, 0.0595f, 0.0215f);
		this.Controller.transform.localEulerAngles = new Vector3(-90f, -90f, 0f);
		this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
		this.HomeCamera.Target = this.HomeCamera.Targets[0];
		this.HomeYandere.CanMove = true;
		this.HomeYandere.enabled = true;
		this.HomeWindow.Show = false;
		this.HomeCamera.PlayMusic();
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
	}
}
