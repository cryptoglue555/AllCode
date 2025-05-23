using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object" , menuName = "KitchenObjectSO")]
public class KitchenObjectSo : ScriptableObject
{
    public Transform prefab;
    public Sprite sprite;
    public string objectName;
}
