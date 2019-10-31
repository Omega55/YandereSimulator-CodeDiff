using System;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingImage : MonoBehaviour
{
	[SerializeField]
	private RawImage image;

	[SerializeField]
	private float scrollSpeed;

	private float scroll;

	private void Update()
	{
		this.scroll += Time.deltaTime * this.scrollSpeed;
		if (this.image != null)
		{
			this.image.uvRect = new Rect(this.scroll, this.scroll, 1f, 1f);
		}
	}
}
