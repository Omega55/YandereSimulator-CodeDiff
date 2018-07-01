using System;
using UnityEngine;

public class SentenceScript : MonoBehaviour
{
	public UILabel Sentence;

	public string[] Words;

	public int ID;

	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Sentence.text = this.Words[this.ID];
			this.ID++;
		}
	}
}
