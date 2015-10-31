using System;
using UnityEngine;

[Serializable]
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

	public Transform TV;

	public int ID;

	public HomeVideoGamesScript()
	{
		this.ID = 1;
	}

	public virtual void Update()
	{
		if (this.HomeCamera.Destination == this.HomeCamera.Destinations[5])
		{
			this.TV.localScale = Vector3.Lerp(this.TV.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
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
						int num = 150 - this.ID * 50;
						Vector3 localPosition = this.Highlight.localPosition;
						float num2 = localPosition.y = (float)num;
						Vector3 vector = this.Highlight.localPosition = localPosition;
					}
					if (this.InputManager.TappedUp)
					{
						this.ID--;
						if (this.ID < 1)
						{
							this.ID = 5;
						}
						this.TitleScreen.mainTexture = this.TitleScreens[this.ID];
						int num3 = 150 - this.ID * 50;
						Vector3 localPosition2 = this.Highlight.localPosition;
						float num4 = localPosition2.y = (float)num3;
						Vector3 vector2 = this.Highlight.localPosition = localPosition2;
					}
					if (Input.GetButtonDown("A") && this.ID == 1)
					{
						float y = 1.153333f;
						Vector3 localPosition3 = this.HomeCamera.Targets[5].localPosition;
						float num5 = localPosition3.y = y;
						Vector3 vector3 = this.HomeCamera.Targets[5].localPosition = localPosition3;
						int num6 = -1;
						Color color = this.HomeDarkness.Sprite.color;
						float num7 = color.a = (float)num6;
						Color color2 = this.HomeDarkness.Sprite.color = color;
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
					float x = Mathf.Lerp(this.HomeCamera.Destinations[5].position.x, this.HomeCamera.Targets[5].position.x, Time.deltaTime * 0.75f);
					Vector3 position = this.HomeCamera.Destinations[5].position;
					float num8 = position.x = x;
					Vector3 vector4 = this.HomeCamera.Destinations[5].position = position;
					float y2 = Mathf.Lerp(this.HomeCamera.Destinations[5].position.y, this.HomeCamera.Targets[5].position.y, Time.deltaTime * (float)10);
					Vector3 position2 = this.HomeCamera.Destinations[5].position;
					float num9 = position2.y = y2;
					Vector3 vector5 = this.HomeCamera.Destinations[5].position = position2;
					float z = Mathf.Lerp(this.HomeCamera.Destinations[5].position.z, this.HomeCamera.Targets[5].position.z, Time.deltaTime * (float)10);
					Vector3 position3 = this.HomeCamera.Destinations[5].position;
					float num10 = position3.z = z;
					Vector3 vector6 = this.HomeCamera.Destinations[5].position = position3;
				}
			}
		}
		else
		{
			this.TV.localScale = Vector3.Lerp(this.TV.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
	}

	public virtual void Quit()
	{
		this.Controller.transform.localPosition = new Vector3(0.203f, 0.0595f, 0.0215f);
		this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
		this.HomeCamera.Target = this.HomeCamera.Targets[0];
		this.HomeYandere.CanMove = true;
		this.HomeYandere.enabled = true;
		this.HomeWindow.Show = false;
		this.HomeCamera.PlayMusic();
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
	}

	public virtual void Main()
	{
	}
}
