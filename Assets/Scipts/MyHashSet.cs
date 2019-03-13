using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ingredientObject
{

}

public class MyHashSet : MonoBehaviour
{

    [System.Serializable]
    public struct Formula
    {

        public GameObject ingredient1;
        public GameObject ingredient2;
        public GameObject composite;
    }

    public List<Formula> formulas;


    Dictionary<HashSet<string>, GameObject> formulaDictionary;

    static MyHashSet instance;

    void Awake()
    {
        formulaDictionary = new Dictionary<HashSet<string>, GameObject>();

        instance = this;
        foreach (Formula f in formulas)
        {
            HashSet<string> set = new HashSet<string>();
            set.Add(f.ingredient1.name);
            set.Add(f.ingredient2.name);

            formulaDictionary.Add(set, f.composite);
        }
    }

    public static GameObject GetComposite(GameObject a, GameObject b)
    {
        foreach (HashSet<string> set in instance.formulaDictionary.Keys)
        {

            if (set.Contains(a.name) && set.Contains(b.name))
                return instance.formulaDictionary[set];
        }

        return null;
    }
}
