using System;
using UnityEngine;

public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	public YanvaniaYanmontScript Yanmont;

	public GameObject BossBattleWall;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			this.BossBattleWall.SetActive(true);
			this.Yanmont.EnterCutscene = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
