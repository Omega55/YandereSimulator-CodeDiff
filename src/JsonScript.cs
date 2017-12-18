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
		for (int i = 90; i < 101; i++)
		{
			if (StudentGlobals.GetStudentDead(i))
			{
				StudentGlobals.SetStudentReplaced(i, true);
				StudentGlobals.SetStudentDead(i, false);
				string value = firstNames[UnityEngine.Random.Range(0, firstNames.Length)] + " " + lastNames[UnityEngine.Random.Range(0, lastNames.Length)];
				StudentGlobals.SetStudentName(i, value);
				StudentGlobals.SetStudentBustSize(i, UnityEngine.Random.Range(1f, 1.5f));
				StudentGlobals.SetStudentHairstyle(i, UnityEngine.Random.Range(1, 8).ToString());
				float r = UnityEngine.Random.Range(0f, 1f);
				float g = UnityEngine.Random.Range(0f, 1f);
				float b = UnityEngine.Random.Range(0f, 1f);
				StudentGlobals.SetStudentColor(i, new Color(r, g, b));
				r = UnityEngine.Random.Range(0f, 1f);
				g = UnityEngine.Random.Range(0f, 1f);
				b = UnityEngine.Random.Range(0f, 1f);
				StudentGlobals.SetStudentEyeColor(i, new Color(r, g, b));
				StudentGlobals.SetStudentAccessory(i, UnityEngine.Random.Range(1, 7).ToString());
			}
		}
		for (int j = 90; j < 101; j++)
		{
			if (StudentGlobals.GetStudentReplaced(j))
			{
				StudentJson studentJson = this.students[j];
				studentJson.Name = StudentGlobals.GetStudentName(j);
				studentJson.BreastSize = StudentGlobals.GetStudentBustSize(j);
				studentJson.Hairstyle = StudentGlobals.GetStudentHairstyle(j);
				studentJson.Accessory = StudentGlobals.GetStudentAccessory(j);
				if (j == 97)
				{
					studentJson.Accessory = "7";
				}
				if (j == 90)
				{
					studentJson.Accessory = "8";
				}
			}
		}
	}
}
