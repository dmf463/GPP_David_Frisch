using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prefab DB")]
public class PrefabDB : ScriptableObject
{

    [SerializeField]
    private GameObject smallRat;
    public GameObject SmallRat { get { return smallRat; } }

    [SerializeField]
    private GameObject determinedRat;
    public GameObject DeterminedRat { get { return determinedRat; } }

}
