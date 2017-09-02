using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JsonScript : MonoBehaviour
{
	[SerializeField]
	private StudentJson[] students;

	[SerializeField]
	private CreditJson[] credits;

	[SerializeField]
	private TopicJson[] topics;

	private void Start()
	{
		this.students = StudentJson.LoadFromJson(StudentJson.FilePath);
		if (SceneManager.GetActiveScene().name == "SchoolScene")
		{
			this.topics = TopicJson.LoadFromJson(TopicJson.FilePath);
			StudentManagerScript studentManagerScript = UnityEngine.Object.FindObjectOfType<StudentManagerScript>();
			this.ReplaceDeadTeachers(studentManagerScript.FirstNames, studentManagerScript.LastNames);
		}
		else if (SceneManager.GetActiveScene().name == "CreditsScene")
		{
			this.credits = CreditJson.LoadFromJson(CreditJson.FilePath);
		}
	}

	public StudentJson[] Students
	{
		get
		{
			return this.students;
		}
	}

	public CreditJson[] Credits
	{
		get
		{
			return this.credits;
		}
	}

	public TopicJson[] Topics
	{
		get
		{
			return this.topics;
		}
	}

	private void ReplaceDeadTeachers(string[] firstNames, string[] lastNames)
	{
		for (int i = 94; i < 101; i++)
		{
			if (Globals.GetStudentDead(i))
			{
				Globals.SetStudentReplaced(i, true);
				Globals.SetStudentDead(i, false);
				string value = firstNames[UnityEngine.Random.Range(0, firstNames.Length)] + " " + lastNames[UnityEngine.Random.Range(0, lastNames.Length)];
				Globals.SetStudentName(i, value);
				Globals.SetStudentBustSize(i, UnityEngine.Random.Range(1f, 1.5f));
				Globals.SetStudentHairstyle(i, UnityEngine.Random.Range(1, 8).ToString());
				float r = UnityEngine.Random.Range(0f, 1f);
				float g = UnityEngine.Random.Range(0f, 1f);
				float b = UnityEngine.Random.Range(0f, 1f);
				Globals.SetStudentColor(i, new Color(r, g, b));
				r = UnityEngine.Random.Range(0f, 1f);
				g = UnityEngine.Random.Range(0f, 1f);
				b = UnityEngine.Random.Range(0f, 1f);
				Globals.SetStudentEyeColor(i, new Color(r, g, b));
				Globals.SetStudentAccessory(i, UnityEngine.Random.Range(1, 7).ToString());
			}
		}
		for (int j = 94; j < 101; j++)
		{
			if (Globals.GetStudentReplaced(j))
			{
				StudentJson studentJson = this.students[j];
				studentJson.Name = Globals.GetStudentName(j);
				studentJson.BreastSize = Globals.GetStudentBustSize(j);
				studentJson.Hairstyle = Globals.GetStudentHairstyle(j);
				studentJson.Accessory = Globals.GetStudentAccessory(j);
				if (j == 100)
				{
					studentJson.Accessory = "7";
				}
			}
		}
	}
}
