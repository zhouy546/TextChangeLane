using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
    [SerializeField]
    Text text;

    string stext;
    char[] theChar;
    void Start() {
        stext = text.text;
        theChar = stext.ToCharArray();
        PunctuationCheck(theChar);
    }

    void PunctuationCheck(char[] _char)
    {
        for (int i = 0; i < _char.Length; i++)
        {
            if (Char.IsPunctuation(_char[i])) {
                Debug.Log(_char[i].ToString());
            }
        }

    }

}
