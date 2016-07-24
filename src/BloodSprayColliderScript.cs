using System;
using UnityEngine;

[Serializable]
public class BloodSprayColliderScript : MonoBehaviour
{
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			YandereScript yandereScript = (YandereScript)other.gameObject.GetComponent(typeof(YandereScript));
			if (yandereScript != null)
			{
				yandereScript.Bloodiness = (float)100;
				yandereScript.UpdateBlood();
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
	}

	public virtual void Main()
	{
	}
}
