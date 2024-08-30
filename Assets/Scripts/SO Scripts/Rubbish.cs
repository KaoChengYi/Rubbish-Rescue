using UnityEngine;

public enum RubbishType
{
	NonRecycable,
	Glass,
	Paper,
	Plastic,
}

[CreateAssetMenu(fileName = "New Rubbish", menuName = "Rubbish")]
public class Rubbish : ScriptableObject
{
	public RubbishType type;

	public string rubbishName;
	public Sprite sprite;
}