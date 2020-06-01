using System;
using UnityEngine;

public class KittenScript : MonoBehaviour
{
	public YandereScript Yandere;

	public GameObject Character;

	public string[] AnimationNames;

	public Transform Target;

	public Transform Head;

	public string CurrentAnim = string.Empty;

	public string IdleAnim = string.Empty;

	public bool Wait;

	public float Timer;

	private void LateUpdate()
	{
		if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 5f)
		{
			if (!this.Yandere.Aiming)
			{
				Vector3 b = (this.Yandere.Head.transform.position.x < base.transform.position.x) ? this.Yandere.Head.transform.position : (base.transform.position + base.transform.forward + base.transform.up * 0.139854f);
				this.Target.position = Vector3.Lerp(this.Target.position, b, Time.deltaTime * 5f);
				this.Head.transform.LookAt(this.Target);
				return;
			}
			this.Head.transform.LookAt(this.Yandere.transform.position + Vector3.up * this.Head.position.y);
		}
	}
}
