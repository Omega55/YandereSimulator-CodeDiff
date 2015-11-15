using System;
using UnityEngine;

[Serializable]
public class VendingMachineScript : MonoBehaviour
{
	public PromptScript Prompt;

	public Transform CanSpawn;

	public GameObject Can;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.Can, this.CanSpawn.position, Quaternion.identity);
			int num = 90;
			Vector3 eulerAngles = gameObject.transform.eulerAngles;
			float num2 = eulerAngles.x = (float)num;
			Vector3 vector = gameObject.transform.eulerAngles = eulerAngles;
			int num3 = 90;
			Vector3 eulerAngles2 = gameObject.transform.eulerAngles;
			float num4 = eulerAngles2.y = (float)num3;
			Vector3 vector2 = gameObject.transform.eulerAngles = eulerAngles2;
			gameObject.audio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
		}
	}

	public virtual void Main()
	{
	}
}
