using System;
using UnityEngine;

[Serializable]
public class BlasterScript : MonoBehaviour
{
	public Transform Skull;

	public GameObject[] Eyes;

	public Transform Beam;

	public float Size;

	public virtual void Start()
	{
		this.Skull.localScale = new Vector3((float)0, (float)0, (float)0);
		this.Beam.localScale = new Vector3((float)0, (float)0, (float)0);
	}

	public virtual void Update()
	{
		if (this.animation["Blast"].time > (float)1)
		{
			this.Beam.localScale = Vector3.Lerp(this.Beam.localScale, new Vector3((float)1000, (float)1, (float)1), Time.deltaTime * (float)10);
			this.Eyes[0].active = true;
			this.Eyes[1].active = true;
		}
		if (this.animation["Blast"].time >= this.animation["Blast"].length)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void LateUpdate()
	{
		if (this.animation["Blast"].time < 1.5f)
		{
			this.Size = Mathf.Lerp(this.Size, (float)2, Time.deltaTime * (float)5);
		}
		else
		{
			this.Size = Mathf.Lerp(this.Size, (float)0, Time.deltaTime * (float)10);
		}
		this.Skull.localScale = new Vector3(this.Size, this.Size, this.Size);
	}

	public virtual void Main()
	{
	}
}
