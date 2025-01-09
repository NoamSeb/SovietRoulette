using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quiz", menuName = "Scriptable Objects/Quiz")]
public class Quiz : ScriptableObject
{
    public List<Questions> questions = new();
}
