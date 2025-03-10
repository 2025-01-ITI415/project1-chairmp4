using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //alows to be editted from within unity inspector
public class Dialogue
{
    // passes public variables to be editted in unity inspector for creating dialogue
    public string       charactername;
    [TextArea(3, 10)] // assigns character space for text that can be modified within the inspector
    public string[]     sentences;
}
