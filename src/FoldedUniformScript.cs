using System;
using UnityEngine;

public class FoldedUniformScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject SteamCloud;

	public bool InPosition = true;

	public bool Clean;

	public float Timer;

	public int Type;

	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		if (this.Clean && this.Prompt.Button[0] != null)
		{
			this.Prompt.HideButton[0] = true;
		}
	}

	private void Update()
	{
		if (this.Clean)
		{
			this.InPosition = this.Yandere.StudentManager.LockerRoomArea.bounds.Contains(base.transform.position);
			this.Prompt.HideButton[0] = (!this.Yandere.MyRenderer.sharedMesh == this.Yandere.Towel || this.Yandere.Bloodiness != 0f || !this.InPosition);
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.SteamCloud, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
				this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_stripping_00");
				this.Yandere.Stripping = true;
				this.Yandere.CanMove = false;
				this.Timer += Time.deltaTime;
			}
			if (this.Timer > 0f)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1.5f)
				{
					this.Yandere.Schoolwear = 1;
					this.Yandere.ChangeSchoolwear();
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}
	}
}
