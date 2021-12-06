using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField]
    private float Speed = 50f;
    public Coroutine run(string text,TMP_Text textlabel)
    {
       return StartCoroutine(routine: TypeText( text,  textlabel));
    }

    private IEnumerator TypeText(string text, TMP_Text textlabel)
    {
        float t = 0;
        int charIndex = 0;

        while(charIndex < text.Length)
        {
            t += Time.deltaTime * Speed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, text.Length);

            textlabel.text = text.Substring(0, charIndex);
            yield return null;
        }

        textlabel.text = text;
    }

}
