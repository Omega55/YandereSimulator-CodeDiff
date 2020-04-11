using System;
using UnityEngine;

public class EmptyHuskScript : MonoBehaviour
{
	public StudentScript TargetStudent;

	public Animation MyAnimation;

	public GameObject DarkAura;

	public Transform Mouth;

	public float[] BloodTimes;

	public int EatPhase;

	private void Update()
	{
		if (this.EatPhase < this.BloodTimes.Length && this.MyAnimation["f02_sixEat_00"].time > this.BloodTimes[this.EatPhase])
		{
			Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.Mouth.position, Quaternion.identity).GetComponent<RandomStabScript>().Biting = true;
			this.EatPhase++;
		}
		if (this.MyAnimation["f02_sixEat_00"].time >= this.MyAnimation["f02_sixEat_00"].length)
		{
			if (this.DarkAura != null)
			{
				Object.Instantiate<GameObject>(this.DarkAura, base.transform.position + Vector3.up * 0.81f, Quaternion.identity);
			}
			Object.Destroy(base.gameObject);
		}
	}
}
