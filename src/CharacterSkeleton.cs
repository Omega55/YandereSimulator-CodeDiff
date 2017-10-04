using System;
using UnityEngine;

[Serializable]
public class CharacterSkeleton
{
	[SerializeField]
	private Transform head;

	[SerializeField]
	private Transform neck;

	[SerializeField]
	private Transform chest;

	[SerializeField]
	private Transform stomach;

	[SerializeField]
	private Transform pelvis;

	[SerializeField]
	private Transform rightShoulder;

	[SerializeField]
	private Transform leftShoulder;

	[SerializeField]
	private Transform rightUpperArm;

	[SerializeField]
	private Transform leftUpperArm;

	[SerializeField]
	private Transform rightElbow;

	[SerializeField]
	private Transform leftElbow;

	[SerializeField]
	private Transform rightLowerArm;

	[SerializeField]
	private Transform leftLowerArm;

	[SerializeField]
	private Transform rightPalm;

	[SerializeField]
	private Transform leftPalm;

	[SerializeField]
	private Transform rightUpperLeg;

	[SerializeField]
	private Transform leftUpperLeg;

	[SerializeField]
	private Transform rightKnee;

	[SerializeField]
	private Transform leftKnee;

	[SerializeField]
	private Transform rightLowerLeg;

	[SerializeField]
	private Transform leftLowerLeg;

	[SerializeField]
	private Transform rightFoot;

	[SerializeField]
	private Transform leftFoot;

	public Transform Head
	{
		get
		{
			return this.head;
		}
	}

	public Transform Neck
	{
		get
		{
			return this.neck;
		}
	}

	public Transform Chest
	{
		get
		{
			return this.chest;
		}
	}

	public Transform Stomach
	{
		get
		{
			return this.stomach;
		}
	}

	public Transform Pelvis
	{
		get
		{
			return this.pelvis;
		}
	}

	public Transform RightShoulder
	{
		get
		{
			return this.rightShoulder;
		}
	}

	public Transform LeftShoulder
	{
		get
		{
			return this.leftShoulder;
		}
	}

	public Transform RightUpperArm
	{
		get
		{
			return this.rightUpperArm;
		}
	}

	public Transform LeftUpperArm
	{
		get
		{
			return this.leftUpperArm;
		}
	}

	public Transform RightElbow
	{
		get
		{
			return this.rightElbow;
		}
	}

	public Transform LeftElbow
	{
		get
		{
			return this.leftElbow;
		}
	}

	public Transform RightLowerArm
	{
		get
		{
			return this.rightLowerArm;
		}
	}

	public Transform LeftLowerArm
	{
		get
		{
			return this.leftLowerArm;
		}
	}

	public Transform RightPalm
	{
		get
		{
			return this.rightPalm;
		}
	}

	public Transform LeftPalm
	{
		get
		{
			return this.leftPalm;
		}
	}

	public Transform RightUpperLeg
	{
		get
		{
			return this.rightUpperLeg;
		}
	}

	public Transform LeftUpperLeg
	{
		get
		{
			return this.leftUpperLeg;
		}
	}

	public Transform RightKnee
	{
		get
		{
			return this.rightKnee;
		}
	}

	public Transform LeftKnee
	{
		get
		{
			return this.leftKnee;
		}
	}

	public Transform RightLowerLeg
	{
		get
		{
			return this.rightLowerLeg;
		}
	}

	public Transform LeftLowerLeg
	{
		get
		{
			return this.leftLowerLeg;
		}
	}

	public Transform RightFoot
	{
		get
		{
			return this.rightFoot;
		}
	}

	public Transform LeftFoot
	{
		get
		{
			return this.leftFoot;
		}
	}
}
