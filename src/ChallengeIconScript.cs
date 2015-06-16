using System;
using UnityEngine;

[Serializable]
public class ChallengeIconScript : MonoBehaviour
{
	public UITexture LargeIcon;

	public UISprite IconFrame;

	public UISprite NameFrame;

	public UITexture Icon;

	public UILabel Name;

	public float Dark;

	public virtual void Update()
	{
		if (this.transform.position.x > -0.125f && this.transform.position.x < 0.125f)
		{
			if (this.Icon != null)
			{
				this.LargeIcon.mainTexture = this.Icon.mainTexture;
			}
			this.Dark -= Time.deltaTime * (float)10;
			if (this.Dark < (float)0)
			{
				this.Dark = (float)0;
			}
		}
		else
		{
			this.Dark += Time.deltaTime * (float)10;
			if (this.Dark > (float)1)
			{
				this.Dark = (float)1;
			}
		}
		this.IconFrame.color = new Color(this.Dark, this.Dark, this.Dark, (float)1);
		this.NameFrame.color = new Color(this.Dark, this.Dark, this.Dark, (float)1);
		this.Name.color = new Color(this.Dark, this.Dark, this.Dark, (float)1);
	}

	public virtual void Main()
	{
	}
}
