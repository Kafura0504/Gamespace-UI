using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteChange", menuName = "Scriptable Objects/SpriteChange")]
public class SpriteChange : ScriptableObject
{
    public Sprite sprite;
    public string name;
}
