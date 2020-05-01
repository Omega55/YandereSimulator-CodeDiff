using System;

[Serializable]
public struct SerializedComponent
{
	public string OwnerID;

	public string TypePath;

	public ValueDict PropertyValues;

	public ReferenceDict PropertyReferences;

	public ValueDict FieldValues;

	public ReferenceDict FieldReferences;
}
