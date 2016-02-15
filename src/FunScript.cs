using System;
using UnityEngine;

[Serializable]
public class FunScript : MonoBehaviour
{
	public TypewriterEffect Typewriter;

	public UITexture Girl;

	public UILabel Label;

	public string[] Lines;

	public float OutroTimer;

	public float Timer;

	public virtual void Start()
	{
		int num = 0;
		Color color = this.Girl.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Girl.color = color;
		this.Label.text = "But nobody came. ";
		this.Label.gameObject.active = false;
	}

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)3)
		{
			if (this.Label == null)
			{
				Application.Quit();
			}
			else
			{
				this.Label.gameObject.active = true;
				if (!this.Typewriter.mActive)
				{
					this.OutroTimer += Time.deltaTime;
					if (this.OutroTimer > 2.5f)
					{
						UnityEngine.Object.Destroy(this.Label.gameObject);
						int num = 0;
						Vector3 localPosition = this.Girl.transform.localPosition;
						float num2 = localPosition.y = (float)num;
						Vector3 vector = this.Girl.transform.localPosition = localPosition;
						this.Girl.transform.localScale = new Vector3((float)2, (float)2, (float)2);
					}
				}
			}
		}
		else if (this.Timer > (float)1)
		{
		}
	}

	public virtual void Main()
	{
	}
}
