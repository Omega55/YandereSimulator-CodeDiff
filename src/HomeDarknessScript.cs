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
						this.HomeYandere.transform.position = new Vector3(3.833333f, (float)-10, (float)-1);
						this.HomeYandere.transform.eulerAngles = new Vector3((float)0, (float)-90, (float)0);
						this.HomeYandere.CanMove = true;
						this.FadeOut = false;
						this.HomeCamera.Destinations[0].position = new Vector3(0.01f, (float)-8, -0.01f);
						this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
						this.HomeCamera.transform.position = this.HomeCamera.Destination.position;
						this.HomeCamera.Target = this.HomeCamera.Targets[0];
						this.HomeCamera.Focus.position = this.HomeCamera.Target.position;
						this.BasementLabel.text = "Upstairs";
					}
					else
					{
						this.HomeYandere.transform.position = new Vector3(-2.271312f, (float)0, (float)1);
						this.HomeYandere.transform.eulerAngles = new Vector3((float)0, (float)0, (float)0);
						this.HomeYandere.CanMove = true;
						this.FadeOut = false;
						this.HomeCamera.Destinations[0].position = new Vector3(-2.271312f, (float)2, 3.5f);
						this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
						this.HomeCamera.transform.position = this.HomeCamera.Destination.position;
						this.HomeCamera.Target = this.HomeCamera.Targets[0];
						this.HomeCamera.Focus.position = this.HomeCamera.Target.position;
						this.BasementLabel.text = "Basement";
					}
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
