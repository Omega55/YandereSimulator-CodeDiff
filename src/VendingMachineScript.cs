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
		}
	}

	public virtual void Main()
	{
	}
}
