using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private Token command;
    private Token Object;

    public Textaction Textaction = new Textaction();
    private void Start()
    {
        Textaction = this.gameObject.GetComponent<Textaction>();
    }
    private void Update()
    {
        Textaction = this.gameObject.GetComponent<Textaction>();
    }
    public bool ExecuteUserCommand(List<Token> tokens)
    {
        foreach (Token t in tokens)
        {

            if (t.TokenType == TokenType.COMMAND)
            {
                command = new Token(TokenType.COMMAND, t.LiteralValue);
                //Debug.Log("your command:" + command.LiteralValue);
                //ExecuteUserCommand(t);
            }
            if (t.TokenType == TokenType.FILLER)
            {
                //Debug.Log("your filler:" + t.LiteralValue);
            }
            if (t.TokenType == TokenType.OBJECT)
            {
                Object = new Token(t.TokenType, t.LiteralValue);

                //Debug.Log("your object:" + t.LiteralValue);
                //Debug.Log("your new object:" + Object.LiteralValue);

            }

        }
        ExecuteUserCommand(command);
        return true;
    }

    private void ExecuteUserCommand(Token t)
    {
        string word = t.LiteralValue;
        switch (word)
        {
            case "walk":
                string temp = Object.LiteralValue;
                //Debug.Log("string value: " + temp + "\n Object value: " + Object.LiteralValue.Trim());
                //Debug.Log(Object.LiteralValue);
                    //Debug.Log("execute object: " + Object.LiteralValue + ", \ngame object: " + GameObject.Find(temp));
                    Textaction.walk(GameObject.Find(temp));
                break;
            case "talk":
                Debug.Log("execute command talk to " + Object.LiteralValue + "");
                Debug.Log("textaction action script = " + Textaction.NPC_inrange);
                Textaction.Talk(GameObject.Find(Object.LiteralValue));
                break;
            case "pick":
                Debug.Log("textaction action script = " + Textaction.Item_inrange);
                Textaction.Pick(GameObject.Find(Object.LiteralValue));
                break;
            default:
               // Debug.LogError("execute command faied no command used");
                break;
        }

    }
}
