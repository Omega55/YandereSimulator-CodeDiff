using System;
using UnityEngine;

[Serializable]
public class AnswerSheetScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public DoorGapScript DoorGap;

	public PromptScript Prompt;

	public ClockScript Clock;

	public Mesh OriginalMesh;

	public MeshFilter MyMesh;

	public int Phase;

	public AnswerSheetScript()
	{
		this.Phase = 1;
	}

	public virtual void Start()
	{
		this.OriginalMesh = this.MyMesh.mesh;
		if (PlayerPrefs.GetInt("Scheme_7_Stage") == 100)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.active = false;
		}
		else
		{
			if (PlayerPrefs.GetInt("Scheme_7_Stage") > 4)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
			if (PlayerPrefs.GetInt("Weekday") == 5 && this.Clock.HourTime > 13.5f)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.active = false;
			}
		}
	}

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			if (this.Phase == 1)
			{
				PlayerPrefs.SetInt("Scheme_7_Stage", 2);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.AnswerSheet = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.DoorGap.Prompt.enabled = true;
				this.MyMesh.mesh = null;
				this.Phase++;
			}
			else
			{
				PlayerPrefs.SetInt("Scheme_7_Stage", 5);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.AnswerSheet = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.MyMesh.mesh = this.OriginalMesh;
				this.Phase++;
			}
		}
	}

	public virtual void Main()
	{
	}
}
