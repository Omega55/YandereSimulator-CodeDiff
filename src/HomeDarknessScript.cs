using System;
using UnityEngine;

[Serializable]
public class HomeDarknessScript : MonoBehaviour
{
	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeExitScript HomeExit;

	public UILabel BasementLabel;

	public UISprite Sprite;

	public bool FadeOut;

	public virtual void Start()
	{
		int num = 1;
		Color color = this.Sprite.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Sprite.color = color;
	}

	public virtual void Update()
	{
		if (this.FadeOut)
		{
			float a = this.Sprite.color.a + Time.deltaTime;
			Color color = this.Sprite.color;
			float num = color.a = a;
			Color color2 = this.Sprite.color = color;
			if (this.Sprite.color.a >= (float)1)
			{
				if (this.HomeCamera.ID != 2)
				{
					if (this.HomeExit.ID == 1)
					{
						Application.LoadLevel("SchoolScene");
					}
					else if (this.HomeExit.ID == 2)
					{
						Application.LoadLevel("TownScene");
					}
					else if (this.HomeExit.ID == 3)
					{
						if (this.HomeYandere.transform.position.y > (float)-5)
						{
							this.HomeYandere.transform.position = new Vector3((float)-2, (float)-10, (float)-2);
							this.HomeYandere.transform.eulerAngles = new Vector3((float)0, (float)90, (float)0);
							this.HomeYandere.CanMove = true;
							this.FadeOut = false;
							this.HomeCamera.Destinations[0].position = new Vector3(2.425f, (float)-8, (float)0);
							this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
							this.HomeCamera.transform.position = this.HomeCamera.Destination.position;
							this.HomeCamera.Target = this.HomeCamera.Targets[0];
							this.HomeCamera.Focus.position = this.HomeCamera.Target.position;
							this.BasementLabel.text = "Upstairs";
							this.HomeCamera.DayLight.active = true;
						}
						else
						{
							this.HomeYandere.transform.position = new Vector3(-1.6f, (float)0, -1.6f);
							this.HomeYandere.transform.eulerAngles = new Vector3((float)0, (float)45, (float)0);
							this.HomeYandere.CanMove = true;
							this.FadeOut = false;
							this.HomeCamera.Destinations[0].position = new Vector3(-2.0615f, (float)2, 2.418f);
							this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
							this.HomeCamera.transform.position = this.HomeCamera.Destination.position;
							this.HomeCamera.Target = this.HomeCamera.Targets[0];
							this.HomeCamera.Focus.position = this.HomeCamera.Target.position;
							this.BasementLabel.text = "Basement";
							if (PlayerPrefs.GetInt("Night") == 1)
							{
								this.HomeCamera.DayLight.active = false;
							}
						}
					}
				}
				else
				{
					Application.LoadLevel("CalendarScene");
				}
			}
		}
		else
		{
			float a2 = this.Sprite.color.a - Time.deltaTime;
			Color color3 = this.Sprite.color;
			float num2 = color3.a = a2;
			Color color4 = this.Sprite.color = color3;
			if (this.Sprite.color.a < (float)0)
			{
				int num3 = 0;
				Color color5 = this.Sprite.color;
				float num4 = color5.a = (float)num3;
				Color color6 = this.Sprite.color = color5;
			}
		}
	}

	public virtual void Main()
	{
	}
}
