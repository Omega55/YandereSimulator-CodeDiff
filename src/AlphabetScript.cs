using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphabetScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public GameObject BodyHidingLockers;

	public GameObject SmokeBombBox;

	public GameObject PuzzleCube;

	public GameObject SuperRobot;

	public GameObject SmokeBomb;

	public UILabel ChallengeFailed;

	public UILabel TargetLabel;

	public Transform LocalArrow;

	public Transform Yandere;

	public int CurrentTarget;

	public float Timer;

	public int[] IDs;

	private void Start()
	{
		if (GameGlobals.AlphabetMode)
		{
			this.TargetLabel.text = string.Concat(new object[]
			{
				"(",
				this.CurrentTarget,
				"/77) Current Target: ",
				this.StudentManager.JSON.Students[this.IDs[this.CurrentTarget]].Name
			});
			this.TargetLabel.transform.parent.gameObject.SetActive(true);
			this.BodyHidingLockers.SetActive(true);
			this.SmokeBombBox.SetActive(true);
			this.SuperRobot.SetActive(true);
			this.PuzzleCube.SetActive(true);
			ClassGlobals.PhysicalGrade = 5;
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		if (this.CurrentTarget < this.IDs.Length)
		{
			if ((Input.GetButtonDown("LS") || Input.GetKeyDown(KeyCode.T)) && this.StudentManager.Yandere.Inventory.SmokeBomb)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.SmokeBomb, this.Yandere.position, Quaternion.identity);
				this.StudentManager.Yandere.Inventory.SmokeBomb = false;
			}
			this.LocalArrow.LookAt(this.StudentManager.Students[this.IDs[this.CurrentTarget]].transform.position);
			base.transform.eulerAngles = this.LocalArrow.eulerAngles - new Vector3(0f, this.StudentManager.MainCamera.transform.eulerAngles.y, 0f);
			if ((this.StudentManager.Yandere.Attacking && this.StudentManager.Yandere.TargetStudent.StudentID != this.IDs[this.CurrentTarget]) || this.StudentManager.Police.Show)
			{
				this.ChallengeFailed.enabled = true;
			}
			if (!this.StudentManager.Students[this.IDs[this.CurrentTarget]].Alive)
			{
				this.CurrentTarget++;
				if (this.CurrentTarget > 77)
				{
					this.TargetLabel.text = "Challenge Complete!";
					SceneManager.LoadScene("OsanaJokeScene");
				}
				else
				{
					this.TargetLabel.text = string.Concat(new object[]
					{
						"(",
						this.CurrentTarget,
						"/77) Current Target: ",
						this.StudentManager.Students[this.IDs[this.CurrentTarget]].Name
					});
				}
			}
			if (this.ChallengeFailed.enabled)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 3f)
				{
					SceneManager.LoadScene("LoadingScene");
				}
			}
		}
	}
}
