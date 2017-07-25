using System;
using UnityEngine;

public class TypingSpeedScript : MonoBehaviour
{
	public Animation CharacterAnimation;

	public GameObject YouTube;

	public GameObject Mail;

	public int Phase;

	private void Start()
	{
		this.CharacterAnimation["YandereDevTyping"].speed = 5f;
		this.CharacterAnimation["YandereDevType"].speed = 0f;
		Camera.main.transform.position = new Vector3(1f, 1.33333f, -1f);
		Camera.main.transform.eulerAngles = new Vector3(15f, 135f, 0f);
	}

	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			if (this.Phase == 1)
			{
				this.CharacterAnimation.Play("YandereDevType");
				this.YouTube.active = false;
				this.Phase++;
			}
			else if (this.Phase == 2)
			{
				this.CharacterAnimation["YandereDevType"].speed = 5f;
				this.Phase++;
			}
			else if (this.Phase == 3)
			{
				this.Mail.active = true;
				this.Phase++;
			}
			else if (this.Phase == 4)
			{
				Camera.main.transform.position = new Vector3(1.879f, 1.4f, -2f);
				Camera.main.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			}
		}
	}
}
