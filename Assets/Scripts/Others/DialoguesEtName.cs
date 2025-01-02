using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialoguesEtName
{
    public string name;

    [TextArea(7, 10)]
    public string[] sentences;
}
