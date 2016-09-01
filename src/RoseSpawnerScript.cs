using System;
using UnityEngine;

[Serializable]
public class RoseSpawnerScript : MonoBehaviour
{
	public Transform DramaGirl;

	public Transform Target;

	public GameObject Rose;

	public float Timer;

	public float ForwardForce;

	public float UpwardForce;

	public virtual void Start()
	{
		this.SpawnRose();
	}

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.1f)
		{
			this.SpawnRose();
		}
	}

	public virtual void SpawnRose()
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.Rose, this.transform.position, Quaternion.identity);
		gameObject.rigidbody.AddForce(this.transform.forward * this.ForwardForce);
		gameObject.rigidbody.AddForce(this.transform.up * this.UpwardForce);
		gameObject.transform.localEulerAngles = new Vector3(UnityEngine.Random.Range((float)0, 360f), UnityEngine.Random.Range((float)0, 360f), UnityEngine.Random.Range((float)0, 360f));
		float x = UnityEngine.Random.Range(-5f, 5f);
		Vector3 position = this.transform.position;
		float num = position.x = x;
		Vector3 vector = this.transform.position = position;
		this.transform.LookAt(this.DramaGirl);
		this.Timer = (float)0;
	}

	public virtual void Main()
	{
	}
}
