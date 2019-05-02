using System;
using UnityEngine;

public class SmartphoneScript : MonoBehaviour
{
	public Texture SmashedTexture;

	public GameObject PhoneSmash;

	public Renderer MyRenderer;

	public PromptScript Prompt;

	public MeshFilter MyMesh;

	public Mesh SmashedMesh;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, 0f);
			UnityEngine.Object.Instantiate<GameObject>(this.PhoneSmash, base.transform.position, Quaternion.identity);
			this.Prompt.Yandere.Police.PhotoEvidence--;
			this.MyRenderer.material.mainTexture = this.SmashedTexture;
			this.MyMesh.mesh = this.SmashedMesh;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}
}
