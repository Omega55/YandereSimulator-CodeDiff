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
		if (SchemeGlobals.GetSchemeStage(5) == 100)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.gameObject.SetActive(false);
		}
		else
		{
			if (SchemeGlobals.GetSchemeStage(5) > 4)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
			if (DateGlobals.Weekday == 5 && this.Clock.HourTime > 13.5f)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.gameObject.SetActive(false);
			}
		}
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.Phase == 1)
			{
				SchemeGlobals.SetSchemeStage(5, 2);
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
				SchemeGlobals.SetSchemeStage(5, 5);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.AnswerSheet = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.MyMesh.mesh = this.OriginalMesh;
				this.Phase++;
			}
		}
	}
}
