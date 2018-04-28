using System;
using UnityEngine;

public class ConvoManagerScript : MonoBehaviour
{
	public StudentManagerScript SM;

	public int ID;

	public void CheckMe(int StudentID)
	{
		if (StudentID > 1 && StudentID < 14)
		{
			this.ID = 2;
			while (this.ID < 14)
			{
				if (this.ID != StudentID && this.SM.Students[this.ID] != null)
				{
					if (this.SM.Students[this.ID].Routine && (double)Vector3.Distance(this.SM.Students[this.ID].transform.position, this.SM.Students[StudentID].transform.position) < 2.5)
					{
						this.SM.Students[StudentID].Alone = false;
						break;
					}
					this.SM.Students[StudentID].Alone = true;
				}
				this.ID++;
			}
		}
		else if (StudentID == 17)
		{
			if (this.SM.Students[18].Routine && (double)Vector3.Distance(this.SM.Students[17].transform.position, this.SM.Students[18].transform.position) < 1.4)
			{
				this.SM.Students[17].Alone = false;
			}
			else
			{
				this.SM.Students[17].Alone = true;
			}
		}
		else if (StudentID == 18)
		{
			if (this.SM.Students[17].Routine && (double)Vector3.Distance(this.SM.Students[18].transform.position, this.SM.Students[17].transform.position) < 1.4)
			{
				this.SM.Students[18].Alone = false;
			}
			else
			{
				this.SM.Students[18].Alone = true;
			}
		}
		else if (StudentID > 20 && StudentID < 26)
		{
			this.ID = 21;
			while (this.ID < 26)
			{
				if (this.ID != StudentID && this.SM.Students[this.ID] != null)
				{
					if (this.SM.Students[this.ID].Routine && (double)Vector3.Distance(this.SM.Students[this.ID].transform.position, this.SM.Students[StudentID].transform.position) < 2.5)
					{
						this.SM.Students[StudentID].Alone = false;
						break;
					}
					this.SM.Students[StudentID].Alone = true;
				}
				this.ID++;
			}
		}
		else if (StudentID > 25 && StudentID < 32)
		{
			this.ID = 26;
			while (this.ID < 32)
			{
				if (this.ID != StudentID && this.SM.Students[this.ID] != null)
				{
					if (this.SM.Students[this.ID].Routine && (double)Vector3.Distance(this.SM.Students[this.ID].transform.position, this.SM.Students[StudentID].transform.position) < 2.5)
					{
						this.SM.Students[StudentID].Alone = false;
						break;
					}
					this.SM.Students[StudentID].Alone = true;
				}
				this.ID++;
			}
		}
		else if (StudentID == 33)
		{
			if (this.SM.Students[34].Routine && (double)Vector3.Distance(this.SM.Students[33].transform.position, this.SM.Students[34].transform.position) < 1.4)
			{
				this.SM.Students[33].Alone = false;
			}
			else
			{
				this.SM.Students[33].Alone = true;
			}
		}
		else if (StudentID == 34)
		{
			if (this.SM.Students[33].Routine && (double)Vector3.Distance(this.SM.Students[34].transform.position, this.SM.Students[33].transform.position) < 1.4)
			{
				this.SM.Students[34].Alone = false;
			}
			else
			{
				this.SM.Students[34].Alone = true;
			}
		}
		else if (StudentID > 75 && StudentID < 81)
		{
			this.ID = 76;
			while (this.ID < 81)
			{
				if (this.ID != StudentID && this.SM.Students[this.ID] != null)
				{
					if ((double)Vector3.Distance(this.SM.Students[this.ID].transform.position, this.SM.Students[StudentID].transform.position) < 2.5)
					{
						this.SM.Students[StudentID].TrueAlone = false;
						if (this.SM.Students[this.ID].Routine)
						{
							this.SM.Students[StudentID].Alone = false;
							break;
						}
						this.SM.Students[StudentID].Alone = true;
					}
					else
					{
						this.SM.Students[StudentID].TrueAlone = true;
						this.SM.Students[StudentID].Alone = true;
					}
				}
				this.ID++;
			}
		}
		else if (StudentID > 80 && StudentID < 86)
		{
			this.ID = 81;
			while (this.ID < 86)
			{
				if (this.ID != StudentID && this.SM.Students[this.ID] != null)
				{
					if (this.SM.Students[this.ID].Routine && (double)Vector3.Distance(this.SM.Students[this.ID].transform.position, this.SM.Students[StudentID].transform.position) < 2.5)
					{
						this.SM.Students[StudentID].Alone = false;
						break;
					}
					this.SM.Students[StudentID].Alone = true;
				}
				this.ID++;
			}
		}
	}
}
