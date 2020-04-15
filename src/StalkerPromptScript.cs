using System;
using UnityEngine;

public class StalkerPromptScript : MonoBehaviour
{
	public StalkerYandereScript Yandere;

	public UISprite MySprite;

	public float Alpha;

	public int ID;

	private void Update()
	{
		base.transform.LookAt(this.Yandere.MainCamera.transform);
		if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 5f)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
			if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 2f && Input.GetButtonDown("A") && this.ID == 1)
			{
				this.Yandere.MyAnimation.CrossFade("f02_climbTrellis_00");
				this.Yandere.Climbing = true;
				this.Yandere.CanMove = false;
				UnityEngine.Object.Destroy(base.gameObject);
				UnityEngine.Object.Destroy(this.MySprite);
			}
		}
		else
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
		}
		this.MySprite.color = new Color(1f, 1f, 1f, this.Alpha);
	}
}
