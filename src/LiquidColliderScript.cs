using System;
using UnityEngine;

[Serializable]
public class LiquidColliderScript : MonoBehaviour
{
	private GameObject NewPool;

	public AudioClip SplashSound;

	public GameObject GroundSplash;

	public GameObject Splash;

	public GameObject Pool;

	public bool Bucket;

	public bool Blood;

	public bool Gas;

	public virtual void Start()
	{
		if (this.Bucket)
		{
			this.rigidbody.AddRelativeForce(Vector3.forward * (float)400);
		}
	}

	public virtual void Update()
	{
		if (!this.Bucket)
		{
			if (this.transform.position.y < (float)0)
			{
				UnityEngine.Object.Instantiate(this.GroundSplash, new Vector3(this.transform.position.x, (float)0, this.transform.position.z), Quaternion.identity);
				this.NewPool = (GameObject)UnityEngine.Object.Instantiate(this.Pool, new Vector3(this.transform.position.x, 0.012f, this.transform.position.z), Quaternion.identity);
				this.NewPool.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
				if (this.Blood)
				{
					this.NewPool.transform.parent = GameObject.Find("BloodParent").transform;
				}
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
		else
		{
			float x = this.transform.localScale.x + Time.deltaTime * (float)2;
			Vector3 localScale = this.transform.localScale;
			float num = localScale.x = x;
			Vector3 vector = this.transform.localScale = localScale;
			float y = this.transform.localScale.y + Time.deltaTime * (float)2;
			Vector3 localScale2 = this.transform.localScale;
			float num2 = localScale2.y = y;
			Vector3 vector2 = this.transform.localScale = localScale2;
			float z = this.transform.localScale.z + Time.deltaTime * (float)2;
			Vector3 localScale3 = this.transform.localScale;
			float num3 = localScale3.z = z;
			Vector3 vector3 = this.transform.localScale = localScale3;
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript studentScript = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (studentScript.StudentID == 7)
			{
				AudioSource.PlayClipAtPoint(this.SplashSound, this.transform.position);
				UnityEngine.Object.Instantiate(this.Splash, new Vector3(this.transform.position.x, 1.5f, this.transform.position.z), Quaternion.identity);
				if (this.Blood)
				{
					studentScript.Bloody = true;
				}
				else if (this.Gas)
				{
					studentScript.Gas = true;
				}
				studentScript.GetWet();
			}
		}
	}

	public virtual void Main()
	{
	}
}
