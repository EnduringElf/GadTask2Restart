using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Dialouge System/Dialouge Object")]
public class DialougeObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] Dialouge;
    [SerializeField] private string[] Speakers;
    [SerializeField] private Response[] responses;
    [SerializeField] private ObjectDiag[] Items;
    public string[] dialouge => Dialouge;
    public string[] speakers => Speakers;

    public bool Hasresponses => Responses != null && Responses.Length > 0;
    public bool HasObjects => Items != null && Items.Length > 0;
    public Response[] Responses => responses;

    public ObjectDiag[] objectDiags => Items;


    
}
