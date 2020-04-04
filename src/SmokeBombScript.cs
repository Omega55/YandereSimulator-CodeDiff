using System;
using UnityEngine;

public class SmokeBombScript : MonoBehaviour
{
	public StudentScript[] Students;

	public float Timer;

	public int ID;

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 15f)
		{
			foreach (StudentScript studentScript in this.Students)
			{
				if (studentScript != null)
				{
					studentScript.Blind = false;
				}
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				Debug.Log(component.Name + " entered a smoke cloud and became blind.");
				this.Students[this.ID] = component;
				component.Blind = true;
				this.ID++;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				Debug.Log(component.Name + " left a smoke cloud and stopped being blind.");
				component.Blind = false;
			}
		}
	}
}
