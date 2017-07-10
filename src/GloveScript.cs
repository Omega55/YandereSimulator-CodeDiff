using System;
using UnityEngine;

public class GloveScript : MonoBehaviour
{
	public PromptScript Prompt;

	public PickUpScript PickUp;

	public Collider MyCollider;

	public Projector Blood;

	private void Start()
	{
		YandereScript component = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		Physics.IgnoreCollision(component.GetComponent<Collider>(), this.MyCollider);
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			base.transform.parent = this.Prompt.Yandere.transform;
			base.transform.localPosition = new Vector3(0f, 1f, 0.25f);
			this.Prompt.Yandere.Gloves = this;
			this.Prompt.Yandere.WearGloves();
			base.gameObject.SetActive(false);
		}
		this.Prompt.HideButton[0] = (this.Prompt.Yandere.Schoolwear != 1 || this.Prompt.Yandere.ClubAttire);
	}
}
