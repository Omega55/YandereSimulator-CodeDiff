using System;
using UnityEngine;

public class TextMessageScript : MonoBehaviour
{
	public UILabel Label;

	public GameObject Image;

	public bool Attachment;

	public bool Right;

	private void Start()
	{
		if (!this.Attachment && this.Image != null)
		{
			this.Image.SetActive(false);
		}
		if (this.Right && EventGlobals.OsanaConversation)
		{
			base.gameObject.GetComponent<UISprite>().color = new Color(1f, 0.5f, 0f);
			this.Label.color = new Color(1f, 1f, 1f);
		}
	}

	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}
}
