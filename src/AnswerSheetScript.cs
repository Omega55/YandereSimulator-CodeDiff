using System;
using UnityEngine;

public class AnswerSheetScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public DoorGapScript DoorGap;

	public PromptScript Prompt;

	public ClockScript Clock;

	public Mesh OriginalMesh;

	public MeshFilter MyMesh;

	public int Phase = 1;

	private void Start()
	{
		this.OriginalMesh = this.MyMesh.mesh;
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.Phase == 1)
			{
				SchemeGlobals.SetSchemeStage(5, 5);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.AnswerSheet = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.DoorGap.Prompt.enabled = true;
				this.MyMesh.mesh = null;
				this.Phase++;
				return;
			}
			SchemeGlobals.SetSchemeStage(5, 8);
			this.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.AnswerSheet = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.MyMesh.mesh = this.OriginalMesh;
			this.Phase++;
		}
	}
}
