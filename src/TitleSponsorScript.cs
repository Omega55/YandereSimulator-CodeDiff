using System;
using UnityEngine;

[Serializable]
public class TitleSponsorScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public string[] SponsorURLs;

	public string[] Sponsors;

	public UILabel SponsorName;

	public Transform Highlight;

	public bool Show;

	public int Columns;

	public int Rows;

	public int Column;

	public int Row;

	public int ID;

	public TitleSponsorScript()
	{
		this.Columns = 2;
		this.Rows = 2;
		this.Column = 1;
		this.Row = 1;
	}

	public virtual void Start()
	{
		int num = 1050;
		Vector3 localPosition = this.transform.localPosition;
		float num2 = localPosition.x = (float)num;
		Vector3 vector = this.transform.localPosition = localPosition;
		this.UpdateHighlight();
	}

	public virtual void Update()
	{
		if (!this.Show)
		{
			float x = Mathf.Lerp(this.transform.localPosition.x, (float)1050, Time.deltaTime * (float)10);
			Vector3 localPosition = this.transform.localPosition;
			float num = localPosition.x = x;
			Vector3 vector = this.transform.localPosition = localPosition;
		}
		else
		{
			float x2 = Mathf.Lerp(this.transform.localPosition.x, (float)0, Time.deltaTime * (float)10);
			Vector3 localPosition2 = this.transform.localPosition;
			float num2 = localPosition2.x = x2;
			Vector3 vector2 = this.transform.localPosition = localPosition2;
			if (this.InputManager.TappedUp)
			{
				this.Row--;
				if (this.Row < 1)
				{
					this.Row = this.Rows;
				}
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedDown)
			{
				this.Row++;
				if (this.Row > this.Rows)
				{
					this.Row = 1;
				}
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedRight)
			{
				this.Column++;
				if (this.Column > this.Columns)
				{
					this.Column = 1;
				}
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedLeft)
			{
				this.Column--;
				if (this.Column < 1)
				{
					this.Column = this.Columns;
				}
				this.UpdateHighlight();
			}
			if (Input.GetButtonDown("A") && this.SponsorURLs[this.ID] != string.Empty)
			{
				Application.OpenURL(this.SponsorURLs[this.ID]);
			}
		}
	}

	public virtual void UpdateHighlight()
	{
		int num = -640 + this.Column * 256;
		Vector3 localPosition = this.Highlight.localPosition;
		float num2 = localPosition.x = (float)num;
		Vector3 vector = this.Highlight.localPosition = localPosition;
		int num3 = 384 - this.Row * 256;
		Vector3 localPosition2 = this.Highlight.localPosition;
		float num4 = localPosition2.y = (float)num3;
		Vector3 vector2 = this.Highlight.localPosition = localPosition2;
		this.ID = this.Column + (this.Row - 1) * this.Columns;
		this.SponsorName.text = this.Sponsors[this.ID];
	}

	public virtual void Main()
	{
	}
}
