using System;
using UnityEngine;

[Serializable]
public class succubus_twins_character_pack_viewer_succubus_b_seduce : MonoBehaviour
{
	public virtual void Update()
	{
		if (!this.GetComponent<Animation>().IsPlaying("succubus_b_charm_02"))
		{
			this.GetComponent<Animation>().wrapMode = WrapMode.Loop;
			this.GetComponent<Animation>().CrossFade("succubus_b_idle_01");
		}
	}

	public virtual void setParticle()
	{
		if (!this.GetComponent<Animation>().IsPlaying("succubus_b_charm_02"))
		{
			this.GetComponent<Animation>().wrapMode = WrapMode.Once;
			this.GetComponent<Animation>().CrossFade("succubus_b_charm_02");
			UnityEngine.Object.Instantiate(Resources.Load("Samples/ParticleGenerate Prefab/seduce_particle_instance"), new Vector3((float)0, (float)0, (float)0), Quaternion.identity);
		}
	}

	public virtual void Main()
	{
	}
}
