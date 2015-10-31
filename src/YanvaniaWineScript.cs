using System;
using UnityEngine;

[Serializable]
public class YanvaniaWineScript : MonoBehaviour
{
	public GameObject Shards;

	public float Rotation;

	public virtual void Update()
	{
		if (this.transform.parent == null)
		{
			this.Rotation += Time.deltaTime * (float)360;
			this.transform.localEulerAngles = new Vector3(this.Rotation, this.Rotation, this.Rotation);
			if (this.transform.position.y < 6.5f)
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.Shards, new Vector3(this.transform.position.x, 6.5f, this.transform.position.z), Quaternion.identity);
				gameObject.transform.localEulerAngles = new Vector3((float)-90, (float)0, (float)0);
				AudioSource.PlayClipAtPoint(this.audio.clip, this.transform.position);
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
	}

	public virtual void Main()
	{
	}
}
