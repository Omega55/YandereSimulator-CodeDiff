using System;
using UnityEngine;

[Serializable]
public class CountdownScript : MonoBehaviour
{
	public UISprite Sprite;

	public virtual void Update()
	{
		this.Sprite.fillAmount = this.Sprite.fillAmount - Time.deltaTime * 0.1f;
	}

	public virtual void Main()
	{
	}
}
