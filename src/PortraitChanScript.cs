using System;
using UnityEngine;

[Serializable]
public class PortraitChanScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public JsonScript JSON;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer PigtailR;

	public Renderer PigtailL;

	public Renderer Drills;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform Ponytail;

	public Transform HairL;

	public Transform HairR;

	public Texture DrillTexture;

	public Texture HairTexture;

	public bool HidePony;

	public bool Teacher;

	public bool Male;

	public float BreastSize;

	public string Hairstyle;

	public int StudentID;

	public int Club;

	public Mesh TeacherMesh;

	public Texture TeacherTexture;

	public PortraitChanScript()
	{
		this.Hairstyle = string.Empty;
	}

	public virtual void Start()
	{
		this.Club = this.JSON.StudentClubs[this.StudentID];
		this.BreastSize = this.JSON.StudentBreasts[this.StudentID];
		this.Hairstyle = this.JSON.StudentHairstyles[this.StudentID];
		if (!this.Male)
		{
			this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.UpdateHair();
		}
		if (this.Club == 9)
		{
			this.BecomeTeacher();
		}
		this.SetColors();
	}

	public virtual void SetColors()
	{
		string a = this.JSON.StudentColors[this.StudentID];
		if (!this.Male)
		{
			if (a == "Red")
			{
				this.HairTexture = this.StudentManager.Colors[0];
			}
			else if (a == "Yellow")
			{
				this.HairTexture = this.StudentManager.Colors[1];
			}
			else if (a == "Green")
			{
				this.HairTexture = this.StudentManager.Colors[2];
			}
			else if (a == "Cyan")
			{
				this.HairTexture = this.StudentManager.Colors[3];
			}
			else if (a == "Blue")
			{
				this.HairTexture = this.StudentManager.Colors[4];
			}
			else if (a == "Purple")
			{
				this.HairTexture = this.StudentManager.Colors[5];
				this.DrillTexture = this.StudentManager.Colors[6];
			}
			else if (a == "Brown")
			{
				this.HairTexture = this.StudentManager.Colors[7];
			}
			else if (a == "Pippi")
			{
				this.HairTexture = this.StudentManager.Colors[8];
			}
			if (!this.Teacher)
			{
				this.MyRenderer.materials[1].mainTexture = this.HairTexture;
				this.MyRenderer.materials[3].mainTexture = this.HairTexture;
			}
			else
			{
				this.MyRenderer.materials[1].mainTexture = this.HairTexture;
				this.MyRenderer.materials[2].mainTexture = this.HairTexture;
			}
		}
		else
		{
			if (a == "Red")
			{
				this.HairTexture = this.StudentManager.MaleColors[0];
			}
			else if (a == "Yellow")
			{
				this.HairTexture = this.StudentManager.MaleColors[1];
			}
			else if (a == "Green")
			{
				this.HairTexture = this.StudentManager.MaleColors[2];
			}
			else if (a == "Cyan")
			{
				this.HairTexture = this.StudentManager.MaleColors[3];
			}
			else if (a == "Blue")
			{
				this.HairTexture = this.StudentManager.MaleColors[4];
			}
			else if (a == "Purple")
			{
				this.HairTexture = this.StudentManager.MaleColors[5];
			}
			else if (a == "Black")
			{
				this.HairTexture = this.StudentManager.MaleColors[6];
			}
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
			this.MyRenderer.materials[3].mainTexture = this.HairTexture;
		}
		if (!this.Male)
		{
			this.PigtailR.material.mainTexture = this.HairTexture;
			this.PigtailL.material.mainTexture = this.HairTexture;
			if (this.DrillTexture != null)
			{
				this.Drills.materials[0].mainTexture = this.DrillTexture;
				this.Drills.materials[1].mainTexture = this.DrillTexture;
				this.Drills.materials[2].mainTexture = this.DrillTexture;
			}
		}
	}

	public virtual void UpdateHair()
	{
		this.PigtailR.active = false;
		this.PigtailL.active = false;
		this.Drills.active = false;
		if (!(this.Hairstyle == "PonyTail"))
		{
			if (this.Hairstyle == "RightTail")
			{
				this.PigtailR.active = true;
				this.HidePony = true;
			}
			else if (this.Hairstyle == "LeftTail")
			{
				this.PigtailL.active = true;
				this.HidePony = true;
			}
			else if (this.Hairstyle == "PigTails")
			{
				this.PigtailR.active = true;
				this.PigtailL.active = true;
				this.HidePony = true;
			}
			else if (this.Hairstyle == "TriTails")
			{
				this.PigtailR.active = true;
				this.PigtailL.active = true;
				this.PigtailR.transform.localScale = new Vector3((float)1, (float)1, (float)1);
				this.PigtailL.transform.localScale = new Vector3((float)1, (float)1, (float)1);
			}
			else if (this.Hairstyle == "TwinTails")
			{
				this.PigtailR.active = true;
				this.PigtailL.active = true;
				this.HidePony = true;
				this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
				this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
			}
			else if (this.Hairstyle == "Drills")
			{
				this.Drills.active = true;
				this.HidePony = true;
			}
			else if (this.Hairstyle == "Short")
			{
				this.PigtailR.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
				this.PigtailL.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			}
		}
		if (this.HidePony)
		{
			this.Ponytail.parent.transform.localScale = new Vector3((float)1, (float)1, 0.93f);
			this.Ponytail.localScale = new Vector3((float)0, (float)0, (float)0);
			this.HairR.localScale = new Vector3((float)0, (float)0, (float)0);
			this.HairL.localScale = new Vector3((float)0, (float)0, (float)0);
		}
	}

	public virtual void BecomeTeacher()
	{
		this.MyRenderer.sharedMesh = this.TeacherMesh;
		this.Teacher = true;
		this.MyRenderer.materials[0].mainTexture = this.TeacherTexture;
		this.MyRenderer.materials[3].mainTexture = this.TeacherTexture;
	}

	public virtual void Main()
	{
	}
}
