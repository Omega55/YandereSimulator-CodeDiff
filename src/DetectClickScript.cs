using System;
using UnityEngine;

public class DetectClickScript : MonoBehaviour
{
	public Vector3 OriginalPosition;

	public Color OriginalColor;

	public Collider MyCollider;

	public Camera GUICamera;

	public UISprite Sprite;

	public UILabel Label;

	public bool Clicked;

	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalColor = this.Sprite.color;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = this.GUICamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit, 100f) && raycastHit.collider == this.MyCollider && this.Label.color.a == 1f)
			{
				this.Sprite.color = new Color(1f, 1f, 1f, 1f);
				this.Clicked = true;
			}
		}
	}

	private void OnTriggerEnter()
	{
		if (this.Label.color.a == 1f)
		{
			this.Sprite.color = Color.white;
		}
	}

	private void OnTriggerExit()
	{
		this.Sprite.color = this.OriginalColor;
	}
}
