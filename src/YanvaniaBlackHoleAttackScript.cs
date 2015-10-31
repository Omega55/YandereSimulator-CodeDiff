using System;
using UnityEngine;

[Serializable]
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	public YanvaniaYanmontScript Yanmont;

	public GameObject BlackExplosion;

	public virtual void Start()
	{
		this.Yanmont = (YanvaniaYanmontScript)GameObject.Find("YanmontChan").GetComponent(typeof(YanvaniaYanmontScript));
	}

	public virtual void Update()
	{
		this.transform.position = Vector3.MoveTowards(this.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(this.transform.position, this.Yanmont.transform.position) > (float)10 || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			UnityEngine.Object.Instantiate(this.BlackExplosion, this.transform.position, Quaternion.identity);
			this.Yanmont.TakeDamage(20);
		}
		if (other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate(this.BlackExplosion, this.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
