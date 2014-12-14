using System;
using UnityEngine;

[Serializable]
public class PauseScreenScript : MonoBehaviour
{
	public PassTimeScript PassTime;

	public RPG_Camera RPGCamera;

	public Blur ScreenBlur;

	public GameObject MainMenu;

	public Transform Highlight;

	public int Selected;

	public bool Show;

	public PauseScreenScript()
	{
		this.Selected = 1;
	}

	public virtual void Start()
	{
		this.transform.localPosition = new Vector3((float)1250, (float)0, (float)0);
		this.transform.localScale = new Vector3(0.585f, 0.585f, 0.585f);
	}

	public virtual void Update()
	{
		if (!this.Show)
		{
			this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3((float)1250, (float)0, (float)0), 0.166666672f);
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(0.585f, 0.585f, 0.585f), 0.166666672f);
			if (Time.timeScale < 0.9f)
			{
				Time.timeScale = Mathf.Lerp(Time.timeScale, (float)1, 0.166666672f);
				if (Time.timeScale > 0.9f)
				{
					Time.timeScale = (float)1;
				}
			}
			if (Input.GetButtonDown("Start"))
			{
				this.ScreenBlur.enabled = true;
				this.RPGCamera.enabled = false;
				this.Show = true;
			}
		}
		else
		{
			this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3((float)0, (float)0, (float)0), 0.166666672f);
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), 0.166666672f);
			Time.timeScale = Mathf.Lerp(Time.timeScale, (float)0, 0.166666672f);
			if (this.MainMenu.active)
			{
				if (Input.GetKeyDown("up"))
				{
					float y = this.Highlight.localPosition.y + (float)75;
					Vector3 localPosition = this.Highlight.localPosition;
					float num = localPosition.y = y;
					Vector3 vector = this.Highlight.localPosition = localPosition;
					this.Selected--;
					if (this.Selected < 1)
					{
						int num2 = -225;
						Vector3 localPosition2 = this.Highlight.localPosition;
						float num3 = localPosition2.y = (float)num2;
						Vector3 vector2 = this.Highlight.localPosition = localPosition2;
						this.Selected = 7;
					}
				}
				if (Input.GetKeyDown("down"))
				{
					float y2 = this.Highlight.localPosition.y - (float)75;
					Vector3 localPosition3 = this.Highlight.localPosition;
					float num4 = localPosition3.y = y2;
					Vector3 vector3 = this.Highlight.localPosition = localPosition3;
					this.Selected++;
					if (this.Selected > 7)
					{
						int num5 = 225;
						Vector3 localPosition4 = this.Highlight.localPosition;
						float num6 = localPosition4.y = (float)num5;
						Vector3 vector4 = this.Highlight.localPosition = localPosition4;
						this.Selected = 1;
					}
				}
				if (Input.GetButtonDown("A") || Input.GetKeyDown("e"))
				{
					if (this.Selected == 1)
					{
						this.ScreenBlur.enabled = false;
						this.RPGCamera.enabled = true;
						this.Show = false;
					}
					else if (this.Selected == 2)
					{
						this.MainMenu.active = false;
						this.PassTime.active = true;
						this.PassTime.GetCurrentTime();
					}
					else if (this.Selected == 7)
					{
						Application.Quit();
					}
				}
				if (Input.GetButtonDown("Start"))
				{
					this.ScreenBlur.enabled = false;
					this.RPGCamera.enabled = true;
					this.Show = false;
				}
			}
			if ((Input.GetButtonDown("B") || Input.GetKeyDown("q")) && this.PassTime.active)
			{
				this.MainMenu.active = true;
				this.PassTime.active = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
