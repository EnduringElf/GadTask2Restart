using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class TextaxtionHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text Usertext;
    private string _mText;
    public TMP_Text Textasset => Usertext;

    Parser p = new Parser();
    interperter interperter;

    public bool textactioninrange;

    private Action command;

    private void Start()
    {
        command = this.gameObject.GetComponent<Action>();
    }

    private void Update()
    {
        _mText = Usertext.text;
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            //Debug.Log(_mText);

            p.Parse(_mText);

            //foreach(Token t in p.Tokens)
            //{
            //    t.addedToken(t);
            //}
            
            Interpret();
            Debug.Log("finsihed interpreting");
            textactioninrange = command.Textaction.NPC_inrange;
        }
        
    }

    private void Interpret()
    {
        
        textactioninrange = command.Textaction.NPC_inrange;
        //textactioninrange = command.Textaction.NPC_inrange;
        interperter = new interperter();
        interperter.AddCommandMethods("walk",command.ExecuteUserCommand);
        interperter.AddCommandMethods("talk", command.ExecuteUserCommand);
        interperter.AddCommandMethods("pick", command.ExecuteUserCommand);
        interperter.Interpert(p.Tokens);

    }
}
