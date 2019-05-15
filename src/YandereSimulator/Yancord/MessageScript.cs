using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	public class MessageScript : MonoBehaviour
	{
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		[Space(20f)]
		public UILabel NameLabel;

		public UILabel MessageLabel;

		public UITexture ProfilPictureTexture;

		public void Awake()
		{
			if (this.MyProfile != null)
			{
				if (this.NameLabel != null)
				{
					this.NameLabel.text = this.MyProfile.FirstName + " " + this.MyProfile.LastName;
				}
				if (this.ProfilPictureTexture != null)
				{
					this.ProfilPictureTexture.mainTexture = this.MyProfile.ProfilePicture;
				}
				base.gameObject.name = this.MyProfile.FirstName + "_Message";
			}
		}
	}
}
