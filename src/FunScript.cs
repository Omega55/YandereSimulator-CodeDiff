using System;
using System.IO;
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
		string a = File.ReadAllText(Application.streamingAssetsPath + "/Fun.txt");
		if (a == "0")
		{
			this.Label.text = this.Lines[0];
		}
		else if (a == "1")
		{
			this.Label.text = this.Lines[1];
		}
		else if (a == "2")
		{
			this.Label.text = this.Lines[2];
		}
		else if (a == "3")
		{
			this.Label.text = this.Lines[3];
		}
		else if (a == "4")
		{
			this.Label.text = this.Lines[4];
		}
		else if (a == "5")
		{
			this.Label.text = this.Lines[5];
		}
		else if (a == "6")
		{
			this.Label.text = this.Lines[6];
		}
		else if (a == "7")
		{
			this.Label.text = this.Lines[7];
		}
		else if (a == "8")
		{
			this.Label.text = this.Lines[8];
		}
		else if (a == "9")
		{
			this.Label.text = this.Lines[9];
		}
		else if (a == "10")
		{
			this.Label.text = this.Lines[10];
		}
		else if (a == "666")
		{
			this.Label.text = "Your idea of ''fun''" + "\n" + "seems" + "\n" + "very" + "\n" + "very" + "\n" + "interesting. ";
			this.Girl.color = new Color((float)1, (float)0, (float)0, (float)0);
			this.Label.color = new Color((float)1, (float)0, (float)0, (float)1);
		}
		else
		{
			Application.LoadLevel("WelcomeScene");
		}
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
			float a = Mathf.MoveTowards(this.Girl.color.a, (float)1, Time.deltaTime);
			Color color = this.Girl.color;
			float num3 = color.a = a;
			Color color2 = this.Girl.color = color;
		}
	}

	public virtual void Main()
	{
	}
}
