using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parser : MonoBehaviour
{
    public List<Token> Tokens { get; set; }
    public Parser()
    {
        Tokens = new List<Token>();
    }

    public void Parse(string code)
    {
        string[] temp = code.Trim().Split(' ');
        
        //Debug.Log(temp.Length);
        foreach (string word in temp)
        {
            //Debug.Log(word);
            Token t = new Token(TokenType.NONE, "");
            switch (word)
            {
                case "walk":
                case "talk":
                case "pick":
                    t.TokenType = TokenType.COMMAND; t.LiteralValue = word; break;
                case "to":
                case "up":
                    t.TokenType = TokenType.FILLER; t.LiteralValue = word; break;
                case "FixedNpc":
                case "npc":
                case "item":
                case "FixedItem":
                    t.TokenType = TokenType.OBJECT; t.LiteralValue = word;
                    //Debug.Log("added object token"); 
                    break;
                default:
                    t.TokenType = TokenType.NONE; t.LiteralValue = word; break;

            }
            Tokens.Add(t);
        }
    }
}
