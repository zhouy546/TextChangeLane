using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
    [SerializeField]
    Text text;

    [SerializeField]
    int NumOfCharEveryLane=20;

    string stext;
    LinkedList<char> theChar = new LinkedList<char>();
    LinkedList<char> addChar = new LinkedList<char>();
    void Start() {
        stext = text.text;
        char[] _char = stext.ToCharArray();
        for (int i = 0; i < _char.Length; i++)
        {
            theChar.AddLast(_char[i]);
        }

        string s = "\n";
        char[] _Schar = s.ToCharArray();
        for (int i = 0; i < _Schar.Length; i++)
        {
            addChar.AddLast(_Schar[i]);
        }
        string ss = new string(PunctuationCheck(NumOfCharEveryLane, theChar, addChar));
        text.text = ss;
    }

    char[] PunctuationCheck(int num, LinkedList<char> _theChar,LinkedList<char> addFirst)
    {
        int currentNum = 0;
       
        IEnumerator<char> enumerator = _theChar.GetEnumerator();
        Debug.Log(enumerator.MoveNext());
        while (enumerator.MoveNext())
        {

            if (currentNum % num == 0)
            {



            }
            currentNum++;
        }
        LinkedListNode<char> listNode = _theChar.First;
        IEnumerator<char> addenumerator = addFirst.GetEnumerator();

        while (addenumerator.MoveNext())
        {
            _theChar.AddBefore(listNode, addenumerator.Current);
        }
        return _theChar.ToArray();
    }

}
