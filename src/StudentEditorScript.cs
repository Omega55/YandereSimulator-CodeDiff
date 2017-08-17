using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StudentEditorScript : MonoBehaviour
{
	private class StudentAttendanceInfo
	{
		public int classNumber;

		public int seatNumber;

		public int club;

		public static StudentEditorScript.StudentAttendanceInfo Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentAttendanceInfo
			{
				classNumber = TFUtils.LoadInt(dict, "Class"),
				seatNumber = TFUtils.LoadInt(dict, "Seat"),
				club = TFUtils.LoadInt(dict, "Club")
			};
		}
	}

	private class StudentPersonality
	{
		public PersonaType persona;

		public int crush;

		public static StudentEditorScript.StudentPersonality Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentPersonality
			{
				persona = (PersonaType)TFUtils.LoadInt(dict, "Persona"),
				crush = TFUtils.LoadInt(dict, "Crush")
			};
		}
	}

	private class StudentStats
	{
		public int strength;

		public static StudentEditorScript.StudentStats Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentStats
			{
				strength = TFUtils.LoadInt(dict, "Strength")
			};
		}
	}

	private class StudentCosmetics
	{
		public float breastSize;

		public string hairstyle;

		public string color;

		public string eyes;

		public string stockings;

		public string accessory;

		public static StudentEditorScript.StudentCosmetics Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentCosmetics
			{
				breastSize = TFUtils.LoadFloat(dict, "BreastSize"),
				hairstyle = TFUtils.LoadString(dict, "Hairstyle"),
				color = TFUtils.LoadString(dict, "Color"),
				eyes = TFUtils.LoadString(dict, "Eyes"),
				stockings = TFUtils.LoadString(dict, "Stockings"),
				accessory = TFUtils.LoadString(dict, "Accessory")
			};
		}
	}

	private class StudentData
	{
		public int id;

		public string name;

		public bool isMale;

		public StudentEditorScript.StudentAttendanceInfo attendanceInfo;

		public StudentEditorScript.StudentPersonality personality;

		public StudentEditorScript.StudentStats stats;

		public StudentEditorScript.StudentCosmetics cosmetics;

		public ScheduleBlock[] scheduleBlocks;

		public string info;

		public static StudentEditorScript.StudentData Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentData
			{
				id = TFUtils.LoadInt(dict, "ID"),
				name = TFUtils.LoadString(dict, "Name"),
				isMale = (TFUtils.LoadInt(dict, "Gender") == 1),
				attendanceInfo = StudentEditorScript.StudentAttendanceInfo.Deserialize(dict),
				personality = StudentEditorScript.StudentPersonality.Deserialize(dict),
				stats = StudentEditorScript.StudentStats.Deserialize(dict),
				cosmetics = StudentEditorScript.StudentCosmetics.Deserialize(dict),
				scheduleBlocks = StudentEditorScript.DeserializeScheduleBlocks(dict),
				info = TFUtils.LoadString(dict, "Info")
			};
		}
	}

	[SerializeField]
	private UIPanel mainPanel;

	[SerializeField]
	private UIPanel studentPanel;

	[SerializeField]
	private UILabel bodyLabel;

	[SerializeField]
	private Transform listLabelsOrigin;

	[SerializeField]
	private UILabel studentLabelTemplate;

	[SerializeField]
	private PromptBarScript promptBar;

	private StudentEditorScript.StudentData[] students;

	private int studentIndex;

	private InputManagerScript inputManager;

	private void Awake()
	{
		Dictionary<string, object>[] array = EditorManagerScript.DeserializeJson("Students.json");
		this.students = new StudentEditorScript.StudentData[array.Length];
		for (int i = 0; i < this.students.Length; i++)
		{
			this.students[i] = StudentEditorScript.StudentData.Deserialize(array[i]);
		}
		Array.Sort<StudentEditorScript.StudentData>(this.students, (StudentEditorScript.StudentData a, StudentEditorScript.StudentData b) => a.id - b.id);
		for (int j = 0; j < this.students.Length; j++)
		{
			StudentEditorScript.StudentData studentData = this.students[j];
			UILabel uilabel = UnityEngine.Object.Instantiate<UILabel>(this.studentLabelTemplate, this.listLabelsOrigin);
			uilabel.text = "(" + studentData.id.ToString() + ") " + studentData.name;
			Transform transform = uilabel.transform;
			transform.localPosition = new Vector3(transform.localPosition.x + (float)(uilabel.width / 2), transform.localPosition.y - (float)(j * uilabel.height), transform.localPosition.z);
			uilabel.gameObject.SetActive(true);
		}
		this.studentIndex = 0;
		this.bodyLabel.text = StudentEditorScript.GetStudentText(this.students[this.studentIndex]);
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.UpdateButtons();
	}

	private static ScheduleBlock[] DeserializeScheduleBlocks(Dictionary<string, object> dict)
	{
		string[] array = TFUtils.LoadString(dict, "ScheduleTime").Split(new char[]
		{
			'_'
		});
		string[] array2 = TFUtils.LoadString(dict, "ScheduleDestination").Split(new char[]
		{
			'_'
		});
		string[] array3 = TFUtils.LoadString(dict, "ScheduleAction").Split(new char[]
		{
			'_'
		});
		ScheduleBlock[] array4 = new ScheduleBlock[array.Length];
		for (int i = 0; i < array4.Length; i++)
		{
			array4[i] = new ScheduleBlock(float.Parse(array[i]), array2[i], array3[i]);
		}
		return array4;
	}

	private static string GetStudentText(StudentEditorScript.StudentData data)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(string.Concat(new object[]
		{
			data.name,
			" (",
			data.id,
			"):\n"
		}));
		stringBuilder.Append("- Gender: " + ((!data.isMale) ? "Female" : "Male") + "\n");
		stringBuilder.Append("- Class: " + data.attendanceInfo.classNumber + "\n");
		stringBuilder.Append("- Seat: " + data.attendanceInfo.seatNumber + "\n");
		stringBuilder.Append("- Club: " + data.attendanceInfo.club + "\n");
		stringBuilder.Append("- Persona: " + data.personality.persona + "\n");
		stringBuilder.Append("- Crush: " + data.personality.crush + "\n");
		stringBuilder.Append("- Breast size: " + data.cosmetics.breastSize + "\n");
		stringBuilder.Append("- Strength: " + data.stats.strength + "\n");
		stringBuilder.Append("- Hairstyle: " + data.cosmetics.hairstyle + "\n");
		stringBuilder.Append("- Color: " + data.cosmetics.color + "\n");
		stringBuilder.Append("- Eyes: " + data.cosmetics.eyes + "\n");
		stringBuilder.Append("- Stockings: " + data.cosmetics.stockings + "\n");
		stringBuilder.Append("- Accessory: " + data.cosmetics.accessory + "\n");
		stringBuilder.Append("- Schedule blocks: ");
		foreach (ScheduleBlock scheduleBlock in data.scheduleBlocks)
		{
			stringBuilder.Append(string.Concat(new object[]
			{
				"[",
				scheduleBlock.time,
				", ",
				scheduleBlock.destination,
				", ",
				scheduleBlock.action,
				"]"
			}));
		}
		stringBuilder.Append("\n");
		stringBuilder.Append("- Info: \"" + data.info + "\"\n");
		return stringBuilder.ToString();
	}

	private void HandleInput()
	{
		bool buttonDown = Input.GetButtonDown("B");
		if (buttonDown)
		{
			this.mainPanel.gameObject.SetActive(true);
			this.studentPanel.gameObject.SetActive(false);
		}
		int num = 0;
		int num2 = this.students.Length - 1;
		bool tappedUp = this.inputManager.TappedUp;
		bool tappedDown = this.inputManager.TappedDown;
		if (tappedUp)
		{
			this.studentIndex = ((this.studentIndex <= num) ? num2 : (this.studentIndex - 1));
		}
		else if (tappedDown)
		{
			this.studentIndex = ((this.studentIndex >= num2) ? num : (this.studentIndex + 1));
		}
		bool flag = tappedUp || tappedDown;
		if (flag)
		{
			this.bodyLabel.text = StudentEditorScript.GetStudentText(this.students[this.studentIndex]);
		}
	}

	private void Update()
	{
		this.HandleInput();
	}
}
