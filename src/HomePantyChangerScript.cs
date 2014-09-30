using System;
using UnityEngine;

[Serializable]
public class HomePantyChangerScript : MonoBehaviour
{
	public Transform PantyParent;

	private GameObject NewPanties;

	public GameObject Panties;

	public UILabel PantyNameLabel;

	public UILabel PantyDescLabel;

	public UILabel PantyBuffLabel;

	public UILabel ButtonLabel;

	public float TargetRotation;

	public float Rotation;

	public int TotalPanties;

	public int Selected;

	public bool DestinationReached;

	public bool DPadTapped;

	public bool Tapped;

	public bool Show;

	private int ID;

	public GameObject[] PantyModels;

	public Texture[] PantyTextures;

	public Color[] PantyColors;

	public string[] PantyNames;

	public string[] PantyDescs;

	public string[] PantyBuffs;

	public virtual void Start()
	{
		while (this.ID < this.TotalPanties)
		{
			this.NewPanties = (GameObject)UnityEngine.Object.Instantiate(this.PantyModels[this.ID], new Vector3((float)0, (float)0, (float)-1), Quaternion.identity);
			this.NewPanties.renderer.material.mainTexture = this.PantyTextures[this.ID];
			this.NewPanties.renderer.material.color = this.PantyColors[this.ID];
			this.NewPanties.transform.parent = this.PantyParent;
			((HomePantiesScript)this.NewPanties.GetComponent(typeof(HomePantiesScript))).ID = this.ID;
			float y = this.PantyParent.transform.localEulerAngles.y + (float)(360 / this.TotalPanties);
			Vector3 localEulerAngles = this.PantyParent.transform.localEulerAngles;
			float num = localEulerAngles.y = y;
			Vector3 vector = this.PantyParent.transform.localEulerAngles = localEulerAngles;
			this.ID++;
		}
		int num2 = 0;
		Vector3 localEulerAngles2 = this.PantyParent.transform.localEulerAngles;
		float num3 = localEulerAngles2.y = (float)num2;
		Vector3 vector2 = this.PantyParent.transform.localEulerAngles = localEulerAngles2;
		float z = 1.8f;
		Vector3 localPosition = this.PantyParent.transform.localPosition;
		float num4 = localPosition.z = z;
		Vector3 vector3 = this.PantyParent.transform.localPosition = localPosition;
		this.UpdatePantyLabels();
		this.PantyParent.transform.localScale = new Vector3((float)0, (float)0, (float)0);
	}

	public virtual void Update()
	{
		if (this.Show)
		{
			this.PantyParent.localScale = Vector3.Lerp(this.PantyParent.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			if (!this.Tapped)
			{
				if (Input.GetAxis("DpadX") > 0.5f || Input.GetAxis("Horizontal") > 0.5f)
				{
					if (Input.GetAxis("DpadX") > 0.5f)
					{
						this.DPadTapped = true;
					}
					this.DestinationReached = false;
					this.Tapped = true;
					this.TargetRotation += (float)(360 / this.TotalPanties);
					this.Selected++;
					if (this.Selected > this.TotalPanties - 1)
					{
						this.Selected = 0;
					}
					this.UpdatePantyLabels();
				}
				if (Input.GetAxis("DpadX") < -0.5f || Input.GetAxis("Horizontal") < -0.5f)
				{
					if (Input.GetAxis("DpadX") < -0.5f)
					{
						this.DPadTapped = true;
					}
					this.DestinationReached = false;
					this.Tapped = true;
					this.TargetRotation -= (float)(360 / this.TotalPanties);
					this.Selected--;
					if (this.Selected < 0)
					{
						this.Selected = this.TotalPanties - 1;
					}
					this.UpdatePantyLabels();
				}
			}
			else if (this.DPadTapped)
			{
				if (Input.GetAxis("DpadX") > -0.5f && Input.GetAxis("DpadX") < 0.5f)
				{
					this.DPadTapped = false;
					this.Tapped = false;
				}
			}
			else if (Input.GetAxis("Horizontal") > -0.5f && Input.GetAxis("Horizontal") < 0.5f)
			{
				this.Tapped = false;
			}
			this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime * (float)10);
			float rotation = this.Rotation;
			Vector3 localEulerAngles = this.PantyParent.localEulerAngles;
			float num = localEulerAngles.y = rotation;
			Vector3 vector = this.PantyParent.localEulerAngles = localEulerAngles;
			if (Input.GetButtonDown("A"))
			{
				PlayerPrefs.SetInt("PantiesEquipped", this.Selected);
				this.UpdatePantyLabels();
			}
		}
		else
		{
			this.PantyParent.localScale = Vector3.Lerp(this.PantyParent.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
	}

	public virtual void UpdatePantyLabels()
	{
		this.PantyNameLabel.text = this.PantyNames[this.Selected];
		this.PantyDescLabel.text = this.PantyDescs[this.Selected];
		this.PantyBuffLabel.text = this.PantyBuffs[this.Selected];
		if (this.Selected == PlayerPrefs.GetInt("PantiesEquipped"))
		{
			this.ButtonLabel.text = "Equipped";
		}
		else
		{
			this.ButtonLabel.text = "Wear";
		}
	}

	public virtual void Main()
	{
	}
}
