using System;
using UnityEngine;

[Serializable]
public class Questions
{
    [TextArea] public string question;

    public Answer answer_A;
    public Answer answer_B;
}
