using System;
using UnityEngine;

public class SmartphoneScript : MonoBehaviour
{
	public Transform PhoneCrushingSpot;

	public GameObject EmptyGameObject;

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
			this.Prompt.Yandere.CrushingPhone = true;
			this.Prompt.Yandere.PhoneToCrush = this;
			this.Prompt.Yandere.CanMove = false;
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, base.transform.position, Quaternion.identity);
			this.PhoneCrushingSpot = gameObject.transform;
			this.PhoneCrushingSpot.position = new Vector3(this.PhoneCrushingSpot.position.x, this.Prompt.Yandere.transform.position.y, this.PhoneCrushingSpot.position.z);
			this.PhoneCrushingSpot.LookAt(this.Prompt.Yandere.transform.position);
			this.PhoneCrushingSpot.Translate(Vector3.forward * 0.5f);
		}
	}
}
