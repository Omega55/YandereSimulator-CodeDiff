using System;
using UnityEngine;

public class TagScript : MonoBehaviour
{
	public UISprite Sprite;

	public Camera UICamera;

	public Transform MainCamera;

	public Transform Target;

	private void Start()
	{
		this.Sprite.color = new Color(1f, 0f, 0f, 0f);
	}

	private void Update()
	{
		if (this.Target != null)
		{
			float num = Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position);
			if (num > 90f)
			{
				Vector2 vector = Camera.main.WorldToScreenPoint(this.Target.position);
				base.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
			}
		}
	}
}
