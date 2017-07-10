using System;
using UnityEngine;

public class TextMessageScript : MonoBehaviour
{
	public UILabel Label;

	public GameObject Image;

	public bool Attachment;

	private void Start()
	{
		if (!this.Attachment && this.Image != null)
		{
			this.Image.SetActive(false);
		}
	}

	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}
}
