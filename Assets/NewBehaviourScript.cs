using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof (Text))]
public class NewBehaviourScript : MonoBehaviour {

    string s = "中共中央政治局4月23日下午就《共产党宣言》及其时代意义举行第五次集体学习。中共中央总书记习近平在主持学习时强调，学习马克思主义基本理论是共产党人的必修课。我们重温《共产党宣言》，就是要深刻感悟和把握马克思主义真理力量，坚定马克思主义信仰，追溯马克思主义政党保持先进性和纯洁性的理论源头，提高全党运用马克思主义基本原理解决当代中国实际问题的能力和水平，把《共产党宣言》蕴含的科学原理和科学精神运用到统揽伟大斗争、伟大工程、伟大事业、伟大梦想的实践中去，不断谱写新时代坚持和发展中国特色社会主义新篇章。";

    Text text;
    [SerializeField]
    int NumOfCharEveryLane;


    LinkedList<char> theChar = new LinkedList<char>();
    LinkedList<char> addChar = new LinkedList<char>();
    LinkedList<char> NewChar = new LinkedList<char>();
    void Start() {
        text = this.GetComponent<Text>();
        TextAlignment(s);
    }

    public void TextAlignment(string _s)
    {
        string ss = new string(PunctuationCheck(NumOfCharEveryLane, AddStringToTheCharList(_s), AddStringToAddCharList()));
        text.text = null;
        text.text = ss;
        NewChar.Clear();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            TextAlignment(s);
        }
    }

    LinkedList<char> AddStringToTheCharList(string _s) {
        string stext;
        theChar.Clear();
        stext = _s;
        char[] _char = stext.ToCharArray();
        for (int i = 0; i < _char.Length; i++)
        {
            theChar.AddLast(_char[i]);
        }
        return theChar;
    }

    LinkedList<char> AddStringToAddCharList() {
        string s = "\n";
        addChar.Clear();
        char[] _Schar = s.ToCharArray();
        for (int i = 0; i < _Schar.Length; i++)
        {
            addChar.AddLast(_Schar[i]);
        }
        return addChar;
    }


    char[] PunctuationCheck(int num, LinkedList<char> _theChar,LinkedList<char> addFirst)
    {
        int currentNum = 1;
       
        IEnumerator<char> enumerator = _theChar.GetEnumerator();
        //Debug.Log(enumerator.MoveNext());
        LinkedList<char> row = new LinkedList<char>();
        while (enumerator.MoveNext())
        {
            //添加文字到ROW
            row.AddLast(enumerator.Current);
            if (currentNum % num == 0)//换行字数
            {          
                LinkedListNode<char> Node = _theChar.Find(enumerator.Current);
                if (Char.IsPunctuation(Node.Next.Value)) {//若换行后第一个为标点，缩进标点
                    //添加标点
                    row.AddLast(Node.Next.Value);
                    //添加\N
                    InsertLinkedList(row, addFirst);
                    //LinkedListNode<char> RowLastNode = row.Last;
                    //IEnumerator<char> addenumerator = addFirst.GetEnumerator();
                    //while (addenumerator.MoveNext())
                    //{
                    //    row.AddAfter(RowLastNode, addenumerator.Current);
                    //}
                    //检查第一个是否是标点
                    if (Char.IsPunctuation(row.First.Value)){
                        row.RemoveFirst();
                    }

                    //将row添加到NewChar
                    InsertLinkedList(NewChar, row);
                    //LinkedListNode<char> NewCharLastNode = NewChar.Last;

                    //IEnumerator<char> rowenumerator = row.GetEnumerator();
                    //while (rowenumerator.MoveNext())
                    //{
                    //    NewChar.AddLast(rowenumerator.Current);
                    //}
                    row.Clear();

                }
                else {
                    InsertLinkedList(row, addFirst);

                    if (Char.IsPunctuation(row.First.Value))
                    {
                        row.RemoveFirst();
                    }

                    InsertLinkedList(NewChar, row);
                    row.Clear();

                }
            }
            currentNum++;
        }

        //检查最后一行是否第一个是标点
        if (Char.IsPunctuation(row.First.Value))
        {
            row.RemoveFirst();
        }
        InsertLinkedList(NewChar, row);
        row.Clear();

        // IEnumerator<char> addenumerator = addFirst.GetEnumerator();

        Debug.Log(NewChar.ToArray());
        return NewChar.ToArray();


    }


    void InsertLinkedList(LinkedList<char> target, LinkedList<char> mylist) {
        IEnumerator<char> enumerator = mylist.GetEnumerator();
        while (enumerator.MoveNext())
        {
            target.AddLast(enumerator.Current);
        }
    }

}
