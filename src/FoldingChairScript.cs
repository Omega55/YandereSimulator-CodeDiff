using System;
using UnityEngine;

public class FoldingChairScript : MonoBehaviour
{
	public GameObject[] Student;

	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.Student.Length);
		UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
	}
}
