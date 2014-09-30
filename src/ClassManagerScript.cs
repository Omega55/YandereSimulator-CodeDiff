using System;
using UnityEngine;

[Serializable]
public class ClassManagerScript : MonoBehaviour
{
	public ScheduleManagerScript ScheduleManager;

	public ClassStudyWindowScript ClassStudyWindow;

	public UISprite Black;

	public bool FadeOut;

	public virtual void Update()
	{
		if (!this.FadeOut)
		{
			if (this.Black.color.a > (float)0)
			{
				float a = this.Black.color.a - Time.deltaTime;
				Color color = this.Black.color;
				float num = color.a = a;
				Color color2 = this.Black.color = color;
				if (this.Black.color.a < (float)0)
				{
					int num2 = 0;
					Color color3 = this.Black.color;
					float num3 = color3.a = (float)num2;
					Color color4 = this.Black.color = color3;
				}
			}
			else if (!this.ClassStudyWindow.TappedA)
			{
				this.ClassStudyWindow.Grow = true;
			}
		}
		else if (this.Black.color.a < (float)1)
		{
			float a2 = this.Black.color.a + Time.deltaTime;
			Color color5 = this.Black.color;
			float num4 = color5.a = a2;
			Color color6 = this.Black.color = color5;
		}
		else
		{
			this.FadeOut = false;
			int num5 = 1;
			Color color7 = this.Black.color;
			float num6 = color7.a = (float)num5;
			Color color8 = this.Black.color = color7;
			this.ScheduleManager.UpdateTime();
		}
	}

	public virtual void Main()
	{
	}
}
