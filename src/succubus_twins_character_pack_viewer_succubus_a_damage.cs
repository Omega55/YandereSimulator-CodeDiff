using System;
using UnityEngine;

[Serializable]
public class succubus_twins_character_pack_viewer_succubus_a_damage : MonoBehaviour
{
	public virtual void Update()
	{
		if (!this.GetComponent<Animation>().IsPlaying("succubus_a_damage_l"))
		{
			this.GetComponent<Animation>().wrapMode = WrapMode.Loop;
			this.GetComponent<Animation>().CrossFade("succubus_a_idle_01");
		}
	}

	public virtual void setParticle()
	{
		if (!this.GetComponent<Animation>().IsPlaying("succubus_a_damage_l"))
		{
			this.GetComponent<Animation>().wrapMode = WrapMode.Once;
			this.GetComponent<Animation>().CrossFade("succubus_a_damage_l");
			Vector3 position = GameObject.Find("Head").transform.position;
			UnityEngine.Object.Instantiate(Resources.Load("Samples/AddScriptToParticles Prefab/eff_succubus_damage_00"), position, this.gameObject.transform.rotation);
		}
	}

	public virtual void Main()
	{
	}
}
