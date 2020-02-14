using System;
using UnityEngine;

public class CrackScript : MonoBehaviour
{
	public UITexture Texture;

	private void Update()
	{
		this.Texture.fillAmount += Time.deltaTime * 10f;
	}
}
