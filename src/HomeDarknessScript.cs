using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeDarknessScript : MonoBehaviour
{
	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeExitScript HomeExit;

	public UILabel BasementLabel;

	public UISprite Sprite;

	public bool FadeSlow;

	public bool FadeOut;

	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 1f);
	}

	private void Update()
	{
		if (this.FadeOut)
		{
			this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, this.Sprite.color.a + Time.deltaTime * ((!this.FadeSlow) ? 1f : 0.2f));
			if (this.Sprite.color.a >= 1f)
			{
				if (this.HomeCamera.ID != 2)
				{
					if (this.HomeCamera.ID == 5)
					{
						SceneManager.LoadScene("YanvaniaTitleScene");
					}
					else if (this.HomeCamera.ID == 9)
					{
						SceneManager.LoadScene("CalendarScene");
					}
					else if (this.HomeCamera.ID == 10)
					{
						PlayerPrefs.SetInt("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Kidnapped", 0);
						PlayerPrefs.SetInt("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Slave", 1);
						SceneManager.LoadScene("LoadingScene");
					}
					else if (this.HomeCamera.ID == 11)
					{
						PlayerPrefs.SetInt("KidnapConversation", 1);
						SceneManager.LoadScene("PhoneScene");
					}
					else if (this.HomeExit.ID == 1)
					{
						SceneManager.LoadScene("LoadingScene");
					}
					else if (this.HomeExit.ID != 2)
					{
						if (this.HomeExit.ID == 3)
						{
							if (this.HomeYandere.transform.position.y > -5f)
							{
								this.HomeYandere.transform.position = new Vector3(-2f, -10f, -2f);
								this.HomeYandere.transform.eulerAngles = new Vector3(0f, 90f, 0f);
								this.HomeYandere.CanMove = true;
								this.FadeOut = false;
								this.HomeCamera.Destinations[0].position = new Vector3(2.425f, -8f, 0f);
								this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
								this.HomeCamera.transform.position = this.HomeCamera.Destination.position;
								this.HomeCamera.Target = this.HomeCamera.Targets[0];
								this.HomeCamera.Focus.position = this.HomeCamera.Target.position;
								this.BasementLabel.text = "Upstairs";
								this.HomeCamera.DayLight.SetActive(true);
							}
							else
							{
								this.HomeYandere.transform.position = new Vector3(-1.6f, 0f, -1.6f);
								this.HomeYandere.transform.eulerAngles = new Vector3(0f, 45f, 0f);
								this.HomeYandere.CanMove = true;
								this.FadeOut = false;
								this.HomeCamera.Destinations[0].position = new Vector3(-2.0615f, 2f, 2.418f);
								this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
								this.HomeCamera.transform.position = this.HomeCamera.Destination.position;
								this.HomeCamera.Target = this.HomeCamera.Targets[0];
								this.HomeCamera.Focus.position = this.HomeCamera.Target.position;
								this.BasementLabel.text = "Basement";
								if (PlayerPrefs.GetInt("Night") == 1)
								{
									this.HomeCamera.DayLight.SetActive(false);
								}
							}
						}
					}
				}
				else
				{
					SceneManager.LoadScene("CalendarScene");
				}
			}
		}
		else
		{
			this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, this.Sprite.color.a - Time.deltaTime);
			if (this.Sprite.color.a < 0f)
			{
				this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
			}
		}
	}
}
