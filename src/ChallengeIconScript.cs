using System;
using UnityEngine;

public class ChallengeIconScript : MonoBehaviour
{
	public UITexture LargeIcon;

	public UISprite IconFrame;

	public UISprite NameFrame;

	public UITexture Icon;

	public UILabel Name;

	public float Dark;

	private void Update()
	{
		if (base.transform.position.x > -0.125f && base.transform.position.x < 0.125f)
		{
			if (this.Icon != null)
			{
				this.LargeIcon.mainTexture = this.Icon.mainTexture;
			}
			this.Dark -= Time.deltaTime * 10f;
			if (this.Dark < 0f)
			{
				this.Dark = 0f;
			}
		}
		else
		{
			this.Dark += Time.deltaTime * 10f;
			if (this.Dark > 1f)
			{
				this.Dark = 1f;
			}
		}
		this.IconFrame.color = new Color(this.Dark, this.Dark, this.Dark, 1f);
		this.NameFrame.color = new Color(this.Dark, this.Dark, this.Dark, 1f);
		this.Name.color = new Color(this.Dark, this.Dark, this.Dark, 1f);
	}
}
