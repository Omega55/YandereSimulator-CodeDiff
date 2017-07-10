using System;
using UnityEngine;

public class CountdownScript : MonoBehaviour
{
	public UISprite Sprite;

	private void Update()
	{
		this.Sprite.fillAmount -= Time.deltaTime * 0.1f;
	}
}
