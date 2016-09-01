using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class FoldingChairScript : MonoBehaviour
{
	public GameObject[] Student;

	public virtual void Start()
	{
		int num = UnityEngine.Random.Range(0, Extensions.get_length(this.Student));
		UnityEngine.Object.Instantiate(this.Student[num], this.transform.position - new Vector3((float)0, 0.4f, (float)0), this.transform.rotation);
	}

	public virtual void Main()
	{
	}
}
