using System;
using UnityEngine;

[Serializable]
public class TextMessageScript : MonoBehaviour
{
	public UILabel Label;

	public virtual void Update()
	{
		this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
	}

	public virtual void Main()
	{
	}
}
