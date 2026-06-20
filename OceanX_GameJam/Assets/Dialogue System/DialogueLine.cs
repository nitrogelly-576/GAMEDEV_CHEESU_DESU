using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

[Serializable]
public class DialogueLine
{
    public CharacterData Character;

    [TextArea]
    public string Text;
}
