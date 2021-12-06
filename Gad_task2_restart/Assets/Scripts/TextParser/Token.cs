using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public TokenType TokenType { get; set; }
    public string LiteralValue { get; set; }
    public Token(TokenType token, string text)
    {
        TokenType = token;
        LiteralValue = text;

    }
    public void addedToken(Token token)
    {
        Debug.Log("token added :" + token.TokenType + ", " + token.LiteralValue);
    }

}
public enum TokenType
{
    NONE,
    COMMAND,
    FILLER,
    OBJECT,
}
