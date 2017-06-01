using System;
using UnityEngine;

[Serializable]
public class YandereKunScript : MonoBehaviour
{
	public Transform ChanItemParent;

	public Transform KunItemParent;

	public Transform ChanHips;

	public Transform ChanSpine;

	public Transform ChanSpine1;

	public Transform ChanSpine2;

	public Transform ChanSpine3;

	public Transform ChanNeck;

	public Transform ChanHead;

	public Transform ChanRightUpLeg;

	public Transform ChanRightLeg;

	public Transform ChanRightFoot;

	public Transform ChanRightToes;

	public Transform ChanLeftUpLeg;

	public Transform ChanLeftLeg;

	public Transform ChanLeftFoot;

	public Transform ChanLeftToes;

	public Transform ChanRightShoulder;

	public Transform ChanRightArm;

	public Transform ChanRightArmRoll;

	public Transform ChanRightForeArm;

	public Transform ChanRightForeArmRoll;

	public Transform ChanRightHand;

	public Transform ChanLeftShoulder;

	public Transform ChanLeftArm;

	public Transform ChanLeftArmRoll;

	public Transform ChanLeftForeArm;

	public Transform ChanLeftForeArmRoll;

	public Transform ChanLeftHand;

	public Transform ChanLeftHandPinky1;

	public Transform ChanLeftHandPinky2;

	public Transform ChanLeftHandPinky3;

	public Transform ChanLeftHandRing1;

	public Transform ChanLeftHandRing2;

	public Transform ChanLeftHandRing3;

	public Transform ChanLeftHandMiddle1;

	public Transform ChanLeftHandMiddle2;

	public Transform ChanLeftHandMiddle3;

	public Transform ChanLeftHandIndex1;

	public Transform ChanLeftHandIndex2;

	public Transform ChanLeftHandIndex3;

	public Transform ChanLeftHandThumb1;

	public Transform ChanLeftHandThumb2;

	public Transform ChanLeftHandThumb3;

	public Transform ChanRightHandPinky1;

	public Transform ChanRightHandPinky2;

	public Transform ChanRightHandPinky3;

	public Transform ChanRightHandRing1;

	public Transform ChanRightHandRing2;

	public Transform ChanRightHandRing3;

	public Transform ChanRightHandMiddle1;

	public Transform ChanRightHandMiddle2;

	public Transform ChanRightHandMiddle3;

	public Transform ChanRightHandIndex1;

	public Transform ChanRightHandIndex2;

	public Transform ChanRightHandIndex3;

	public Transform ChanRightHandThumb1;

	public Transform ChanRightHandThumb2;

	public Transform ChanRightHandThumb3;

	public Transform KunHips;

	public Transform KunSpine;

	public Transform KunSpine1;

	public Transform KunSpine2;

	public Transform KunSpine3;

	public Transform KunNeck;

	public Transform KunHead;

	public Transform KunRightUpLeg;

	public Transform KunRightLeg;

	public Transform KunRightFoot;

	public Transform KunRightToes;

	public Transform KunLeftUpLeg;

	public Transform KunLeftLeg;

	public Transform KunLeftFoot;

	public Transform KunLeftToes;

	public Transform KunRightShoulder;

	public Transform KunRightArm;

	public Transform KunRightArmRoll;

	public Transform KunRightForeArm;

	public Transform KunRightForeArmRoll;

	public Transform KunRightHand;

	public Transform KunLeftShoulder;

	public Transform KunLeftArm;

	public Transform KunLeftArmRoll;

	public Transform KunLeftForeArm;

	public Transform KunLeftForeArmRoll;

	public Transform KunLeftHand;

	public Transform KunLeftHandPinky1;

	public Transform KunLeftHandPinky2;

	public Transform KunLeftHandPinky3;

	public Transform KunLeftHandRing1;

	public Transform KunLeftHandRing2;

	public Transform KunLeftHandRing3;

	public Transform KunLeftHandMiddle1;

	public Transform KunLeftHandMiddle2;

	public Transform KunLeftHandMiddle3;

	public Transform KunLeftHandIndex1;

	public Transform KunLeftHandIndex2;

	public Transform KunLeftHandIndex3;

	public Transform KunLeftHandThumb1;

	public Transform KunLeftHandThumb2;

	public Transform KunLeftHandThumb3;

	public Transform KunRightHandPinky1;

	public Transform KunRightHandPinky2;

	public Transform KunRightHandPinky3;

	public Transform KunRightHandRing1;

	public Transform KunRightHandRing2;

	public Transform KunRightHandRing3;

	public Transform KunRightHandMiddle1;

	public Transform KunRightHandMiddle2;

	public Transform KunRightHandMiddle3;

	public Transform KunRightHandIndex1;

	public Transform KunRightHandIndex2;

	public Transform KunRightHandIndex3;

	public Transform KunRightHandThumb1;

	public Transform KunRightHandThumb2;

	public Transform KunRightHandThumb3;

	public SkinnedMeshRenderer SecondRenderer;

	public SkinnedMeshRenderer MyRenderer;

	public bool Kizuna;

	public int ID;

	public virtual void Start()
	{
		if (!this.Kizuna)
		{
			this.KunHips.parent = this.ChanHips;
			this.KunSpine.parent = this.ChanSpine;
			this.KunSpine1.parent = this.ChanSpine1;
			this.KunSpine2.parent = this.ChanSpine2;
			this.KunSpine3.parent = this.ChanSpine3;
			this.KunNeck.parent = this.ChanNeck;
			this.KunHead.parent = this.ChanHead;
			this.KunRightUpLeg.parent = this.ChanRightUpLeg;
			this.KunRightLeg.parent = this.ChanRightLeg;
			this.KunRightFoot.parent = this.ChanRightFoot;
			this.KunRightToes.parent = this.ChanRightToes;
			this.KunLeftUpLeg.parent = this.ChanLeftUpLeg;
			this.KunLeftLeg.parent = this.ChanLeftLeg;
			this.KunLeftFoot.parent = this.ChanLeftFoot;
			this.KunLeftToes.parent = this.ChanLeftToes;
			this.KunRightShoulder.parent = this.ChanRightShoulder;
			this.KunRightArm.parent = this.ChanRightArm;
			this.KunRightArmRoll.parent = this.ChanRightArmRoll;
			this.KunRightForeArm.parent = this.ChanRightForeArm;
			this.KunRightForeArmRoll.parent = this.ChanRightForeArmRoll;
			this.KunRightHand.parent = this.ChanRightHand;
			this.KunLeftShoulder.parent = this.ChanLeftShoulder;
			this.KunLeftArm.parent = this.ChanLeftArm;
			this.KunLeftArmRoll.parent = this.ChanLeftArmRoll;
			this.KunLeftForeArmRoll.parent = this.ChanLeftForeArmRoll;
			this.KunLeftForeArm.parent = this.ChanLeftForeArm;
			this.KunLeftHand.parent = this.ChanLeftHand;
			this.KunLeftHandPinky1.parent = this.ChanLeftHandPinky1;
			this.KunLeftHandPinky2.parent = this.ChanLeftHandPinky2;
			this.KunLeftHandPinky3.parent = this.ChanLeftHandPinky3;
			this.KunLeftHandRing1.parent = this.ChanLeftHandRing1;
			this.KunLeftHandRing2.parent = this.ChanLeftHandRing2;
			this.KunLeftHandRing3.parent = this.ChanLeftHandRing3;
			this.KunLeftHandMiddle1.parent = this.ChanLeftHandMiddle1;
			this.KunLeftHandMiddle2.parent = this.ChanLeftHandMiddle2;
			this.KunLeftHandMiddle3.parent = this.ChanLeftHandMiddle3;
			this.KunLeftHandIndex1.parent = this.ChanLeftHandIndex1;
			this.KunLeftHandIndex2.parent = this.ChanLeftHandIndex2;
			this.KunLeftHandIndex3.parent = this.ChanLeftHandIndex3;
			this.KunLeftHandThumb1.parent = this.ChanLeftHandThumb1;
			this.KunLeftHandThumb2.parent = this.ChanLeftHandThumb2;
			this.KunLeftHandThumb3.parent = this.ChanLeftHandThumb3;
			this.KunRightHandPinky1.parent = this.ChanRightHandPinky1;
			this.KunRightHandPinky2.parent = this.ChanRightHandPinky2;
			this.KunRightHandPinky3.parent = this.ChanRightHandPinky3;
			this.KunRightHandRing1.parent = this.ChanRightHandRing1;
			this.KunRightHandRing2.parent = this.ChanRightHandRing2;
			this.KunRightHandRing3.parent = this.ChanRightHandRing3;
			this.KunRightHandMiddle1.parent = this.ChanRightHandMiddle1;
			this.KunRightHandMiddle2.parent = this.ChanRightHandMiddle2;
			this.KunRightHandMiddle3.parent = this.ChanRightHandMiddle3;
			this.KunRightHandIndex1.parent = this.ChanRightHandIndex1;
			this.KunRightHandIndex2.parent = this.ChanRightHandIndex2;
			this.KunRightHandIndex3.parent = this.ChanRightHandIndex3;
			this.KunRightHandThumb1.parent = this.ChanRightHandThumb1;
			this.KunRightHandThumb2.parent = this.ChanRightHandThumb2;
			this.KunRightHandThumb3.parent = this.ChanRightHandThumb3;
		}
		this.MyRenderer.enabled = true;
		if (this.SecondRenderer != null)
		{
			this.SecondRenderer.enabled = true;
		}
		this.active = false;
	}

	public virtual void LateUpdate()
	{
		if (this.Kizuna)
		{
			this.KunItemParent.localPosition = new Vector3(0.066666f, -0.033333f, 0.02f);
			this.ChanItemParent.position = this.KunItemParent.position;
			this.KunHips.localPosition = this.ChanHips.localPosition;
			this.KunHips.localEulerAngles = this.ChanHips.localEulerAngles;
			this.KunSpine.localEulerAngles = this.ChanSpine.localEulerAngles;
			this.KunSpine1.localEulerAngles = this.ChanSpine1.localEulerAngles;
			this.KunSpine2.localEulerAngles = this.ChanSpine2.localEulerAngles;
			this.KunSpine3.localEulerAngles = this.ChanSpine3.localEulerAngles;
			this.KunNeck.localEulerAngles = this.ChanNeck.localEulerAngles;
			this.KunHead.localEulerAngles = this.ChanHead.localEulerAngles;
			this.KunRightUpLeg.localEulerAngles = this.ChanRightUpLeg.localEulerAngles;
			this.KunRightLeg.localEulerAngles = this.ChanRightLeg.localEulerAngles;
			this.KunRightFoot.localEulerAngles = this.ChanRightFoot.localEulerAngles;
			this.KunRightToes.localEulerAngles = this.ChanRightToes.localEulerAngles;
			this.KunLeftUpLeg.localEulerAngles = this.ChanLeftUpLeg.localEulerAngles;
			this.KunLeftLeg.localEulerAngles = this.ChanLeftLeg.localEulerAngles;
			this.KunLeftFoot.localEulerAngles = this.ChanLeftFoot.localEulerAngles;
			this.KunLeftToes.localEulerAngles = this.ChanLeftToes.localEulerAngles;
			this.KunRightShoulder.localEulerAngles = this.ChanRightShoulder.localEulerAngles;
			this.KunRightArm.localEulerAngles = this.ChanRightArm.localEulerAngles;
			this.KunRightArmRoll.localEulerAngles = this.ChanRightArmRoll.localEulerAngles;
			this.KunRightForeArm.localEulerAngles = this.ChanRightForeArm.localEulerAngles;
			this.KunRightForeArmRoll.localEulerAngles = this.ChanRightForeArmRoll.localEulerAngles;
			this.KunRightHand.localEulerAngles = this.ChanRightHand.localEulerAngles;
			this.KunLeftShoulder.localEulerAngles = this.ChanLeftShoulder.localEulerAngles;
			this.KunLeftArm.localEulerAngles = this.ChanLeftArm.localEulerAngles;
			this.KunLeftArmRoll.localEulerAngles = this.ChanLeftArmRoll.localEulerAngles;
			this.KunLeftForeArmRoll.localEulerAngles = this.ChanLeftForeArmRoll.localEulerAngles;
			this.KunLeftForeArm.localEulerAngles = this.ChanLeftForeArm.localEulerAngles;
			this.KunLeftHand.localEulerAngles = this.ChanLeftHand.localEulerAngles;
			this.KunLeftHandPinky1.localEulerAngles = this.ChanLeftHandPinky1.localEulerAngles;
			this.KunLeftHandPinky2.localEulerAngles = this.ChanLeftHandPinky2.localEulerAngles;
			this.KunLeftHandPinky3.localEulerAngles = this.ChanLeftHandPinky3.localEulerAngles;
			this.KunLeftHandRing1.localEulerAngles = this.ChanLeftHandRing1.localEulerAngles;
			this.KunLeftHandRing2.localEulerAngles = this.ChanLeftHandRing2.localEulerAngles;
			this.KunLeftHandRing3.localEulerAngles = this.ChanLeftHandRing3.localEulerAngles;
			this.KunLeftHandMiddle1.localEulerAngles = this.ChanLeftHandMiddle1.localEulerAngles;
			this.KunLeftHandMiddle2.localEulerAngles = this.ChanLeftHandMiddle2.localEulerAngles;
			this.KunLeftHandMiddle3.localEulerAngles = this.ChanLeftHandMiddle3.localEulerAngles;
			this.KunLeftHandIndex1.localEulerAngles = this.ChanLeftHandIndex1.localEulerAngles;
			this.KunLeftHandIndex2.localEulerAngles = this.ChanLeftHandIndex2.localEulerAngles;
			this.KunLeftHandIndex3.localEulerAngles = this.ChanLeftHandIndex3.localEulerAngles;
			this.KunLeftHandThumb1.localEulerAngles = this.ChanLeftHandThumb1.localEulerAngles;
			this.KunLeftHandThumb2.localEulerAngles = this.ChanLeftHandThumb2.localEulerAngles;
			this.KunLeftHandThumb3.localEulerAngles = this.ChanLeftHandThumb3.localEulerAngles;
			this.KunRightHandPinky1.localEulerAngles = this.ChanRightHandPinky1.localEulerAngles;
			this.KunRightHandPinky2.localEulerAngles = this.ChanRightHandPinky2.localEulerAngles;
			this.KunRightHandPinky3.localEulerAngles = this.ChanRightHandPinky3.localEulerAngles;
			this.KunRightHandRing1.localEulerAngles = this.ChanRightHandRing1.localEulerAngles;
			this.KunRightHandRing2.localEulerAngles = this.ChanRightHandRing2.localEulerAngles;
			this.KunRightHandRing3.localEulerAngles = this.ChanRightHandRing3.localEulerAngles;
			this.KunRightHandMiddle1.localEulerAngles = this.ChanRightHandMiddle1.localEulerAngles;
			this.KunRightHandMiddle2.localEulerAngles = this.ChanRightHandMiddle2.localEulerAngles;
			this.KunRightHandMiddle3.localEulerAngles = this.ChanRightHandMiddle3.localEulerAngles;
			this.KunRightHandIndex1.localEulerAngles = this.ChanRightHandIndex1.localEulerAngles;
			this.KunRightHandIndex2.localEulerAngles = this.ChanRightHandIndex2.localEulerAngles;
			this.KunRightHandIndex3.localEulerAngles = this.ChanRightHandIndex3.localEulerAngles;
			this.KunRightHandThumb1.localEulerAngles = this.ChanRightHandThumb1.localEulerAngles;
			this.KunRightHandThumb2.localEulerAngles = this.ChanRightHandThumb2.localEulerAngles;
			this.KunRightHandThumb3.localEulerAngles = this.ChanRightHandThumb3.localEulerAngles;
			if (Input.GetKeyDown("space"))
			{
				if (this.ID > -1)
				{
					for (int i = 0; i < 32; i++)
					{
						this.SecondRenderer.SetBlendShapeWeight(i, (float)0);
					}
					if (this.ID > 32)
					{
						this.ID = 0;
					}
					this.SecondRenderer.SetBlendShapeWeight(this.ID, (float)100);
				}
				this.ID++;
			}
		}
	}

	public virtual void Main()
	{
	}
}
