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

	public bool Blood;

	public virtual void Update()
	{
		if (this.transform.position.y < (float)0)
		{
			UnityEngine.Object.Instantiate(this.GroundSplash, new Vector3(this.transform.position.x, (float)0, this.transform.position.z), Quaternion.identity);
			this.NewPool = (GameObject)UnityEngine.Object.Instantiate(this.Pool, new Vector3(this.transform.position.x, 0.012f, this.transform.position.z), Quaternion.identity);
			this.NewPool.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
			this.NewPool.transform.parent = GameObject.Find("BloodParent").transform;
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			AudioSource.PlayClipAtPoint(this.SplashSound, this.transform.position);
			UnityEngine.Object.Instantiate(this.Splash, new Vector3(this.transform.position.x, 1.5f, this.transform.position.z), Quaternion.identity);
			StudentScript studentScript = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (this.Blood)
			{
				studentScript.Bloody = true;
			}
			studentScript.GetWet();
		}
	}

	public virtual void Main()
	{
	}
}
