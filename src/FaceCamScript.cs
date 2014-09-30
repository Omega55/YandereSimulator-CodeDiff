using System;
using UnityEngine;

[Serializable]
public class FaceCamScript : MonoBehaviour
{
	public Transform Head;

	public virtual void Update()
	{
		this.Head = GameObject.Find("Head").transform;
		if (this.Head != null)
		{
			this.transform.parent = this.Head;
			this.transform.localPosition = new Vector3((float)0, 0.02f, 0.2f);
			this.transform.localEulerAngles = new Vector3((float)0, (float)-180, (float)0);
		}
	}

	public virtual void Main()
	{
	}
}
