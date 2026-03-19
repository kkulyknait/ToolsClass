using System.IO;
using UnityEngine;

//  Add new option to Unity's right-click Create menu!
[CreateAssetMenu(fileName = "NewAlienStats", menuName = "Space/Alien Stats")]
public class AlienStats : ScriptableObject
{
    [Header("Alien Stats")]
    public string AlienName;
    public float MovementSpeed;
    public float FireRate;
    public int ScoreValue;
}
