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
					if ((double)Vector3.Distance(this.SM.Students[this.ID].transform.position, this.SM.Students[StudentID].transform.position) < 2.5)
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
			if ((double)Vector3.Distance(this.SM.Students[17].transform.position, this.SM.Students[18].transform.position) < 1.4)
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
			if ((double)Vector3.Distance(this.SM.Students[18].transform.position, this.SM.Students[17].transform.position) < 1.4)
			{
				this.SM.Students[18].Alone = false;
			}
			else
			{
				this.SM.Students[18].Alone = true;
			}
		}
	}
}
