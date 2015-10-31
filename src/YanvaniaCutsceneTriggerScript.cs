using System;
using UnityEngine;

[Serializable]
public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	public YanvaniaYanmontScript Yanmont;

	public GameObject BossBattleWall;

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.active = true;
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
