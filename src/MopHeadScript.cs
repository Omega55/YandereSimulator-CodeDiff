using System;
using UnityEngine;

[Serializable]
public class MopHeadScript : MonoBehaviour
{
	public MopScript Mop;

	public virtual void OnTriggerStay(Collider other)
	{
		if (this.Mop.Bloodiness < (float)100 && other.tag == "Blood")
		{
			if (other.gameObject.name == "BloodPool(Clone)")
			{
				((BloodPoolScript)other.gameObject.GetComponent(typeof(BloodPoolScript))).Grow = false;
				other.transform.localScale = other.transform.localScale - new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
				if (other.transform.localScale.x < 0.1f)
				{
					UnityEngine.Object.Destroy(other.gameObject);
				}
			}
			else
			{
				UnityEngine.Object.Destroy(other.gameObject);
			}
			this.Mop.Bloodiness = this.Mop.Bloodiness + Time.deltaTime * (float)10;
			this.Mop.UpdateBlood();
		}
	}

	public virtual void Main()
	{
	}
}
