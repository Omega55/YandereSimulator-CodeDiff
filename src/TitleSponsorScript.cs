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

	public int Columns;

	public int Rows;

	private int Column;

	private int Row;

	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
		this.UpdateHighlight();
	}

	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
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
				this.Row = ((this.Row <= 0) ? (this.Rows - 1) : (this.Row - 1));
			}
			if (this.InputManager.TappedDown)
			{
				this.Row = ((this.Row >= this.Rows - 1) ? 0 : (this.Row + 1));
			}
			if (this.InputManager.TappedRight)
			{
				this.Column = ((this.Column >= this.Columns - 1) ? 0 : (this.Column + 1));
			}
			if (this.InputManager.TappedLeft)
			{
				this.Column = ((this.Column <= 0) ? (this.Columns - 1) : (this.Column - 1));
			}
			bool flag = this.InputManager.TappedUp || this.InputManager.TappedDown || this.InputManager.TappedRight || this.InputManager.TappedLeft;
			if (flag)
			{
				this.UpdateHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				int sponsorIndex = this.GetSponsorIndex();
				if (this.SponsorHasWebsite(sponsorIndex))
				{
					Application.OpenURL(this.SponsorURLs[sponsorIndex]);
				}
			}
		}
	}

	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}
}
