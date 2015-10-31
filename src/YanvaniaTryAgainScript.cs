using System;
using UnityEngine;

[Serializable]
public class YanvaniaTryAgainScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public GameObject ButtonEffect;

	public Transform Highlight;

	public UISprite Darkness;

	public bool FadeOut;

	public int Selected;

	public YanvaniaTryAgainScript()
	{
		this.Selected = 1;
	}

	public virtual void Start()
	{
		this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
	}

	public virtual void Update()
	{
		if (!this.FadeOut)
		{
			if (this.transform.localScale.x > 0.9f)
			{
				if (this.InputManager.TappedLeft)
				{
					this.Selected = 1;
				}
				if (this.InputManager.TappedRight)
				{
					this.Selected = 2;
				}
				if (this.Selected == 1)
				{
					float x = Mathf.Lerp(this.Highlight.localPosition.x, (float)-100, Time.deltaTime * (float)10);
					Vector3 localPosition = this.Highlight.localPosition;
					float num = localPosition.x = x;
					Vector3 vector = this.Highlight.localPosition = localPosition;
					float x2 = Mathf.Lerp(this.Highlight.localScale.x, (float)-1, Time.deltaTime * (float)10);
					Vector3 localScale = this.Highlight.localScale;
					float num2 = localScale.x = x2;
					Vector3 vector2 = this.Highlight.localScale = localScale;
				}
				else
				{
					float x3 = Mathf.Lerp(this.Highlight.localPosition.x, (float)100, Time.deltaTime * (float)10);
					Vector3 localPosition2 = this.Highlight.localPosition;
					float num3 = localPosition2.x = x3;
					Vector3 vector3 = this.Highlight.localPosition = localPosition2;
					float x4 = Mathf.Lerp(this.Highlight.localScale.x, (float)1, Time.deltaTime * (float)10);
					Vector3 localScale2 = this.Highlight.localScale;
					float num4 = localScale2.x = x4;
					Vector3 vector4 = this.Highlight.localScale = localScale2;
				}
				if (Input.GetButtonDown("A"))
				{
					GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.ButtonEffect, this.Highlight.position, Quaternion.identity);
					gameObject.transform.parent = this.Highlight;
					gameObject.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
					this.FadeOut = true;
				}
			}
		}
		else
		{
			float a = this.Darkness.color.a + Time.deltaTime;
			Color color = this.Darkness.color;
			float num5 = color.a = a;
			Color color2 = this.Darkness.color = color;
			if (this.Darkness.color.a >= (float)1)
			{
				if (this.Selected == 1)
				{
					Application.LoadLevel(Application.loadedLevel);
				}
				else
				{
					Application.LoadLevel("YanvaniaTitleScene");
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
