using System;
using UnityEngine;

[Serializable]
public class DemonSlashScript : MonoBehaviour
{
	public GameObject FemaleBloodyScream;

	public GameObject MaleBloodyScream;

	public Collider MyCollider;

	public float Timer;

	public virtual void Update()
	{
		if (this.MyCollider.enabled)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.33333f)
			{
				this.MyCollider.enabled = false;
				this.Timer = (float)0;
			}
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if ((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript)) != null && ((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript))).StudentID != 1 && !((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript))).Dead)
		{
			((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript))).Dead = true;
			if (!((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript))).Male)
			{
				UnityEngine.Object.Instantiate(this.FemaleBloodyScream, other.gameObject.transform.root.transform.position + Vector3.up, Quaternion.identity);
			}
			else
			{
				UnityEngine.Object.Instantiate(this.MaleBloodyScream, other.gameObject.transform.root.transform.position + Vector3.up, Quaternion.identity);
			}
			((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript))).BecomeRagdoll();
			((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript))).Ragdoll.Dismember();
			this.audio.Play();
		}
	}

	public virtual void Main()
	{
	}
}
