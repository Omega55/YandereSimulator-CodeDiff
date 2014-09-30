using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ClassStudyWindowScript : MonoBehaviour
{
	public ClassManagerScript ClassManager;

	public UILabel StudyPointsLabel;

	public UILabel SubjectNameLabel;

	public UILabel SubjectDescLabel;

	public GameObject AcceptButton;

	public GameObject Arrow;

	public bool DPadTappedLR;

	public bool TappedLR;

	public bool DPadTappedUD;

	public bool TappedUD;

	public bool TappedA;

	public bool Grow;

	public int StudyPoints;

	public int Selected;

	public int ID;

	public string[] SubjectNames;

	public string[] SubjectDescs;

	public Transform[] Bars;

	public ClassStudyWindowScript()
	{
		this.StudyPoints = 5;
	}

	public virtual void Start()
	{
		this.UpdateText();
		this.UpdateBars();
		this.AcceptButton.active = false;
	}

	public virtual void Update()
	{
		if (this.Grow)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
		}
		else
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			if (this.transform.localScale.x < 0.1f && this.TappedA)
			{
				this.ClassManager.FadeOut = true;
				this.AcceptButton.active = false;
				this.TappedA = false;
				int num = 350;
				Vector3 localPosition = this.Arrow.transform.localPosition;
				float num2 = localPosition.y = (float)num;
				Vector3 vector = this.Arrow.transform.localPosition = localPosition;
				this.StudyPoints = 5;
				this.Selected = 0;
				this.UpdateText();
				this.UpdateBars();
			}
		}
		if (!this.TappedUD)
		{
			if (Input.GetAxis("DpadY") > 0.5f || Input.GetAxis("Vertical") > 0.5f)
			{
				if (Input.GetAxis("DpadY") > 0.5f)
				{
					this.DPadTappedUD = true;
				}
				this.TappedUD = true;
				if (this.Arrow.transform.localPosition.y < (float)350)
				{
					float y = this.Arrow.transform.localPosition.y + (float)100;
					Vector3 localPosition2 = this.Arrow.transform.localPosition;
					float num3 = localPosition2.y = y;
					Vector3 vector2 = this.Arrow.transform.localPosition = localPosition2;
					this.Selected--;
					this.UpdateText();
				}
			}
			if (Input.GetAxis("DpadY") < -0.5f || Input.GetAxis("Vertical") < -0.5f)
			{
				if (Input.GetAxis("DpadY") < -0.5f)
				{
					this.DPadTappedUD = true;
				}
				this.TappedUD = true;
				if (this.Arrow.transform.localPosition.y > (float)-50)
				{
					float y2 = this.Arrow.transform.localPosition.y - (float)100;
					Vector3 localPosition3 = this.Arrow.transform.localPosition;
					float num4 = localPosition3.y = y2;
					Vector3 vector3 = this.Arrow.transform.localPosition = localPosition3;
					this.Selected++;
					this.UpdateText();
				}
			}
		}
		else if (this.DPadTappedUD)
		{
			if (Input.GetAxis("DpadY") > -0.5f && Input.GetAxis("DpadY") < 0.5f)
			{
				this.DPadTappedUD = false;
				this.TappedUD = false;
			}
		}
		else if (Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Vertical") < 0.5f)
		{
			this.TappedUD = false;
		}
		if (!this.TappedLR)
		{
			if (Input.GetAxis("DpadX") > 0.5f || Input.GetAxis("Horizontal") > 0.5f)
			{
				if (Input.GetAxis("DpadX") > 0.5f)
				{
					this.DPadTappedLR = true;
				}
				this.TappedLR = true;
				if (this.StudyPoints > 0)
				{
					this.StudyPoints--;
					PlayerPrefs.SetInt("Subject_" + (this.Selected + 1) + "_Points", PlayerPrefs.GetInt("Subject_" + (this.Selected + 1) + "_Points") + 1);
					this.UpdateBars();
					if (this.StudyPoints == 0)
					{
						this.AcceptButton.active = true;
					}
				}
			}
			if (Input.GetAxis("DpadX") < -0.5f || Input.GetAxis("Horizontal") < -0.5f)
			{
				if (Input.GetAxis("DpadX") < -0.5f)
				{
					this.DPadTappedLR = true;
				}
				this.TappedLR = true;
				if (this.StudyPoints < 5 && PlayerPrefs.GetInt("Subject_" + (this.Selected + 1) + "_Points") > PlayerPrefs.GetInt("Subject_" + (this.Selected + 1) + "_Minimum"))
				{
					this.StudyPoints++;
					PlayerPrefs.SetInt("Subject_" + (this.Selected + 1) + "_Points", PlayerPrefs.GetInt("Subject_" + (this.Selected + 1) + "_Points") - 1);
					this.UpdateBars();
					if (this.StudyPoints > 0)
					{
						this.AcceptButton.active = false;
					}
				}
			}
		}
		else if (this.DPadTappedLR)
		{
			if (Input.GetAxis("DpadX") > -0.5f && Input.GetAxis("DpadX") < 0.5f)
			{
				this.DPadTappedLR = false;
				this.TappedLR = false;
			}
		}
		else if (Input.GetAxis("Horizontal") > -0.5f && Input.GetAxis("Horizontal") < 0.5f)
		{
			this.TappedLR = false;
		}
		if (this.AcceptButton.active && Input.GetButtonDown("A"))
		{
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Bars))
			{
				PlayerPrefs.SetInt("Subject_" + (this.ID + 1) + "_Minimum", PlayerPrefs.GetInt("Subject_" + (this.ID + 1) + "_Points"));
				this.ID++;
			}
			this.TappedA = true;
			this.Grow = false;
		}
	}

	public virtual void UpdateText()
	{
		this.SubjectNameLabel.text = this.SubjectNames[this.Selected];
		this.SubjectDescLabel.text = this.SubjectDescs[this.Selected];
	}

	public virtual void UpdateBars()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Bars))
		{
			float x = (float)PlayerPrefs.GetInt("Subject_" + (this.ID + 1) + "_Points") * 1f / 100f;
			Vector3 localScale = this.Bars[this.ID].localScale;
			float num = localScale.x = x;
			Vector3 vector = this.Bars[this.ID].localScale = localScale;
			this.ID++;
		}
		this.StudyPointsLabel.text = "Study Points Remaining: " + this.StudyPoints;
	}

	public virtual void Main()
	{
	}
}
