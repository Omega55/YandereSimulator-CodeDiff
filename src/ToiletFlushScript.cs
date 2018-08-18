using System;
using System.Linq;
using UnityEngine;

internal class ToiletFlushScript : MonoBehaviour
{
	[Header("=== Toilet Related ===")]
	public GameObject Toilet;

	private GameObject toilet;

	private static System.Random random = new System.Random();

	private StudentManagerScript StudentManager;

	private void Start()
	{
		this.StudentManager = UnityEngine.Object.FindObjectOfType<StudentManagerScript>();
		this.Toilet = this.StudentManager.Students[11].gameObject;
		this.toilet = this.Toilet;
	}

	private void Update()
	{
		this.Flush(this.toilet);
	}

	private void Flush(GameObject toilet)
	{
		if (this.Toilet != null)
		{
			this.Toilet = null;
		}
		if (toilet.activeInHierarchy)
		{
			int length = UnityEngine.Random.Range(1, 15);
			toilet.name = this.RandomSound(length);
			base.name = this.RandomSound(length);
			toilet.SetActive(false);
		}
	}

	private string RandomSound(int Length)
	{
		return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ", Length)
		select s[ToiletFlushScript.random.Next(s.Length)]).ToArray<char>());
	}
}
