using System;
using UnityEngine;

public class TitleSponsorScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public string[] SponsorURLs;

	public string[] Sponsors;

	public UILabel SponsorName;

	public Transform Highlight;

	public bool Show;

	public int Columns = 2;

	public int Rows = 2;

	public int Column = 1;

	public int Row = 1;

	public int ID;

	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.UpdateHighlight();
	}

	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
		}
		else
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
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
			if (Input.GetButtonDown("A") && !this.SponsorURLs[this.ID].Equals(string.Empty))
			{
				Application.OpenURL(this.SponsorURLs[this.ID]);
			}
		}
	}

	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-640f + (float)this.Column * 256f, 384f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.ID = this.Column + (this.Row - 1) * this.Columns;
		this.SponsorName.text = this.Sponsors[this.ID];
	}
}
