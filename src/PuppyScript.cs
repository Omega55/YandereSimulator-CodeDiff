using System;
using UnityEngine;

[Serializable]
public class PuppyScript : MonoBehaviour
{
	public Transform Yandere;

	public virtual void Update()
	{
		if (this.Yandere.localScale.x != (float)1)
		{
			int num = -100;
			Vector3 position = this.Yandere.transform.position;
			float num2 = position.y = (float)num;
			Vector3 vector = this.Yandere.transform.position = position;
			Application.LoadLevel("AntiModScene");
		}
	}

	public virtual void Main()
	{
	}
}
