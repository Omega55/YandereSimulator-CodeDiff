using System;
using UnityEngine;

public class DemonScript : MonoBehaviour
{
	public SkinnedMeshRenderer Face;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public UILabel DemonSubtitle;

	public UISprite Darkness;

	public UISprite Button;

	public AudioClip MouthOpen;

	public AudioClip MouthClose;

	public AudioClip[] Clips;

	public string[] Lines;

	public bool Communing;

	public bool Open;

	public float Intensity = 1f;

	public float Value;

	public Color MyColor;

	public int DemonID;

	public int Phase = 1;

	public int ID;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
			this.Yandere.CanMove = false;
			this.Communing = true;
		}
		if (this.DemonID == 1)
		{
			if ((double)Vector3.Distance(this.Yandere.transform.position, base.transform.position) < 2.5)
			{
				if (!this.Open)
				{
					AudioSource.PlayClipAtPoint(this.MouthOpen, base.transform.position);
				}
				this.Open = true;
			}
			else
			{
				if (this.Open)
				{
					AudioSource.PlayClipAtPoint(this.MouthClose, base.transform.position);
				}
				this.Open = false;
			}
			if (this.Open)
			{
				this.Value = Mathf.Lerp(this.Value, 100f, Time.deltaTime * 10f);
			}
			else
			{
				this.Value = Mathf.Lerp(this.Value, 0f, Time.deltaTime * 10f);
			}
			this.Face.SetBlendShapeWeight(0, this.Value);
		}
		if (this.Communing)
		{
			AudioSource component = base.GetComponent<AudioSource>();
			if (this.Phase == 1)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				if (this.Darkness.color.a == 1f)
				{
					this.DemonSubtitle.transform.localPosition = Vector3.zero;
					this.DemonSubtitle.text = this.Lines[this.ID];
					this.DemonSubtitle.color = this.MyColor;
					this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, 0f);
					this.Phase++;
					if (this.Clips[this.ID] != null)
					{
						component.clip = this.Clips[this.ID];
						component.Play();
						return;
					}
				}
			}
			else if (this.Phase == 2)
			{
				Debug.Log("Demon Phase is 2.");
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
				this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, Mathf.MoveTowards(this.Button.color.a, 1f, Time.deltaTime));
				if (this.DemonSubtitle.color.a > 0.9f && Input.GetButtonDown("A"))
				{
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 3)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 0f, Time.deltaTime));
				if (this.DemonSubtitle.color.a == 0f)
				{
					this.ID++;
					if (this.ID >= this.Lines.Length)
					{
						this.Phase++;
						return;
					}
					this.Phase--;
					this.DemonSubtitle.text = this.Lines[this.ID];
					if (this.Clips[this.ID] != null)
					{
						component.clip = this.Clips[this.ID];
						component.Play();
						return;
					}
				}
			}
			else
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, Mathf.MoveTowards(this.Button.color.a, 0f, Time.deltaTime));
				if (this.Darkness.color.a == 0f)
				{
					this.Yandere.CanMove = true;
					this.Communing = false;
					this.Phase = 1;
					this.ID = 0;
					SchoolGlobals.SetDemonActive(this.DemonID, true);
					StudentGlobals.FemaleUniform = 1;
					StudentGlobals.MaleUniform = 1;
					GameGlobals.Paranormal = true;
				}
			}
		}
	}
}
