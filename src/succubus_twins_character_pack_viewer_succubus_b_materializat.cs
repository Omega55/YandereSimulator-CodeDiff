using System;
using UnityEngine;

[Serializable]
public class succubus_twins_character_pack_viewer_succubus_b_materialization : MonoBehaviour
{
	public virtual void Update()
	{
		if (!this.GetComponent<Animation>().IsPlaying("succubus_b_appear_float"))
		{
			this.GetComponent<Animation>().wrapMode = WrapMode.Loop;
			this.GetComponent<Animation>().CrossFade("succubus_b_idle_01");
		}
	}

	public virtual void setParticle()
	{
		if (!this.GetComponent<Animation>().IsPlaying("succubus_b_appear_float"))
		{
			this.GetComponent<Animation>().wrapMode = WrapMode.Once;
			this.GetComponent<Animation>().CrossFade("succubus_b_appear_float");
			Vector3 position = this.gameObject.transform.position;
			position.y += 0.01f;
			UnityEngine.Object.Instantiate(Resources.Load("Samples/AddScriptToParticles Prefab/eff_succubus_materialization_00"), position, this.gameObject.transform.rotation);
		}
	}

	public virtual void Main()
	{
	}
}
