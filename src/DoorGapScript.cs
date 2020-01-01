using System;
using UnityEngine;

public class DoorGapScript : MonoBehaviour
{
	public RummageSpotScript RummageSpot;

	public SchemesScript Schemes;

	public PromptScript Prompt;

	public Transform[] Papers;

	public float Timer;

	public int Phase = 1;

	private void Start()
	{
		this.Papers[1].gameObject.SetActive(false);
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.Phase == 1)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Prompt.Yandere.Inventory.AnswerSheet = false;
				this.Papers[1].gameObject.SetActive(true);
				SchemeGlobals.SetSchemeStage(5, 6);
				this.Schemes.UpdateInstructions();
				base.GetComponent<AudioSource>().Play();
			}
			else
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Prompt.Yandere.Inventory.AnswerSheet = true;
				this.Prompt.Yandere.Inventory.DuplicateSheet = true;
				this.Papers[2].gameObject.SetActive(false);
				this.RummageSpot.Prompt.Label[0].text = "     Return Answer Sheet";
				this.RummageSpot.Prompt.enabled = true;
				SchemeGlobals.SetSchemeStage(5, 7);
				this.Schemes.UpdateInstructions();
			}
			this.Phase++;
		}
		if (this.Phase == 2)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 4f)
			{
				this.Prompt.Label[0].text = "     Pick Up Sheets";
				this.Prompt.enabled = true;
				this.Phase = 2;
			}
			else if (this.Timer > 3f)
			{
				Transform transform = this.Papers[2];
				transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Lerp(transform.localPosition.z, -0.166f, Time.deltaTime * 10f));
			}
			else if (this.Timer > 1f)
			{
				Transform transform2 = this.Papers[1];
				transform2.localPosition = new Vector3(transform2.localPosition.x, transform2.localPosition.y, Mathf.Lerp(transform2.localPosition.z, 0.166f, Time.deltaTime * 10f));
			}
		}
	}
}
