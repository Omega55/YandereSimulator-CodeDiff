using System;
using UnityEngine;

[Serializable]
public class TypingSpeedScript : MonoBehaviour
{
	public GameObject YouTube;

	public GameObject Mail;

	public int Phase;

	public virtual void Start()
	{
		Camera.main.transform.position = new Vector3((float)1, 1.33333f, (float)-1);
		Camera.main.transform.eulerAngles = new Vector3((float)15, (float)135, (float)0);
	}

	public virtual void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			if (this.Phase == 1)
			{
				this.animation.Play("YandereDevType");
				this.YouTube.active = false;
				this.Phase++;
			}
			else if (this.Phase == 2)
			{
				this.animation["YandereDevType"].speed = (float)5;
				this.Phase++;
			}
			else if (this.Phase == 3)
			{
				this.Mail.active = true;
				this.Phase++;
			}
			else if (this.Phase == 4)
			{
				Camera.main.transform.position = new Vector3(1.879f, 1.4f, (float)-2);
				Camera.main.transform.eulerAngles = new Vector3((float)0, (float)0, (float)0);
			}
		}
	}

	public virtual void Main()
	{
		this.animation["YandereDevTyping"].speed = (float)5;
		this.animation["YandereDevType"].speed = (float)0;
	}
}
