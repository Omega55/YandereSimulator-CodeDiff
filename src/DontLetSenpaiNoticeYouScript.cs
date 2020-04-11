using System;
using UnityEngine;

public class DontLetSenpaiNoticeYouScript : MonoBehaviour
{
	public UILabel[] Letters;

	public Vector3[] Origins;

	public AudioClip Slam;

	public bool Proceed;

	public int ShakeID;

	public int ID;

	private void Start()
	{
		while (this.ID < this.Letters.Length)
		{
			UILabel uilabel = this.Letters[this.ID];
			uilabel.transform.localScale = new Vector3(10f, 10f, 1f);
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0f);
			this.Origins[this.ID] = uilabel.transform.localPosition;
			this.ID++;
		}
		this.ID = 0;
	}

	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Proceed = true;
		}
		if (this.Proceed)
		{
			if (this.ID < this.Letters.Length)
			{
				UILabel uilabel = this.Letters[this.ID];
				uilabel.transform.localScale = Vector3.MoveTowards(uilabel.transform.localScale, Vector3.one, Time.deltaTime * 100f);
				uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, uilabel.color.a + Time.deltaTime * 10f);
				if (uilabel.transform.localScale == Vector3.one)
				{
					base.GetComponent<AudioSource>().PlayOneShot(this.Slam);
					this.ID++;
				}
			}
			this.ShakeID = 0;
			while (this.ShakeID < this.Letters.Length)
			{
				UILabel uilabel2 = this.Letters[this.ShakeID];
				Vector3 vector = this.Origins[this.ShakeID];
				uilabel2.transform.localPosition = new Vector3(vector.x + Random.Range(-5f, 5f), vector.y + Random.Range(-5f, 5f), uilabel2.transform.localPosition.z);
				this.ShakeID++;
			}
		}
	}
}
