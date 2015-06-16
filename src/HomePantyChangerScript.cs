using System;
using UnityEngine;

[Serializable]
public class HomePantyChangerScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	private GameObject NewPanties;

	public GameObject Panties;

	public UILabel PantyNameLabel;

	public UILabel PantyDescLabel;

	public UILabel PantyBuffLabel;

	public UILabel ButtonLabel;

	public Transform PantyParent;

	public bool DestinationReached;

	public float TargetRotation;

	public float Rotation;

	public int TotalPanties;

	public int Selected;

	private int ID;

	public GameObject[] PantyModels;

	public string[] PantyNames;

	public string[] PantyDescs;

	public string[] PantyBuffs;

	public virtual void Start()
	{
		while (this.ID < this.TotalPanties)
		{
			this.NewPanties = (GameObject)UnityEngine.Object.Instantiate(this.PantyModels[this.ID], new Vector3((float)0, (float)0, (float)-1), Quaternion.identity);
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
		if (this.HomeWindow.Show)
		{
			this.PantyParent.localScale = Vector3.Lerp(this.PantyParent.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			if (this.InputManager.TappedRight)
			{
				this.DestinationReached = false;
				this.TargetRotation += (float)(360 / this.TotalPanties);
				this.Selected++;
				if (this.Selected > this.TotalPanties - 1)
				{
					this.Selected = 0;
				}
				this.UpdatePantyLabels();
			}
			if (this.InputManager.TappedLeft)
			{
				this.DestinationReached = false;
				this.TargetRotation -= (float)(360 / this.TotalPanties);
				this.Selected--;
				if (this.Selected < 0)
				{
					this.Selected = this.TotalPanties - 1;
				}
				this.UpdatePantyLabels();
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
			if (Input.GetButtonDown("B"))
			{
				this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
				this.HomeCamera.Target = this.HomeCamera.Targets[0];
				this.HomeYandere.CanMove = true;
				this.HomeWindow.Show = false;
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
