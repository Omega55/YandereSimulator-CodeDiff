using System;
using UnityEngine;

public class SecuritySystemScript : MonoBehaviour
{
	public PromptScript Prompt;

	public bool Evidence;

	public bool Masked;

	public SecurityCameraScript[] Cameras;

	public MetalDetectorScript[] Detectors;

	private void Start()
	{
		if (!SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			for (int i = 0; i < this.Cameras.Length; i++)
			{
				this.Cameras[i].transform.parent.transform.parent.gameObject.GetComponent<AudioSource>().Stop();
				this.Cameras[i].gameObject.SetActive(false);
			}
			for (int i = 0; i < this.Detectors.Length; i++)
			{
				this.Detectors[i].MyCollider.enabled = false;
				this.Detectors[i].enabled = false;
			}
			base.GetComponent<AudioSource>().Play();
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Evidence = false;
			base.enabled = false;
		}
	}
}
