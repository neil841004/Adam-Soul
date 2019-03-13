using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VacuumCleaner : MonoBehaviour
{
    GameObject package_1;
    GameObject package_2;
    public GameObject parent1;
    public GameObject parent2;
    GameObject item_1;
    GameObject item_2;
    Animator aniPackageUI;
    int iFlash;
    [System.Serializable]
    public struct package
    {
        public GameObject monster;
        public GameObject image;
    }
    public package[] packages = new package[11];
    int i;
    int j;

    // Use this for initialization  
    void Start()
    {
        aniPackageUI = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iFlash >= 1)
        {
            iFlash++;
            if(iFlash>=5){
                aniPackageUI.SetBool("attack", false);
                iFlash = 0;
            }
        }
    }
    void Item1()
    {
        package_1 = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().animal_1;

        for (i = 0; i < 11; i++)
        {
            if (packages[i].monster.name == package_1.name)
            {
                break;
            }
        }
        item_1 = Instantiate(packages[i].image, parent1.transform.position, parent1.transform.rotation, parent1.transform);
    }
    void Item2()
    {
        package_2 = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().animal_2;
        for (j = 0; j < 11; j++)
        {
            if (packages[j].monster.name == package_2.name)
            {
                break;
            }
        }
        item_2 = Instantiate(packages[j].image, parent2.transform.position, parent2.transform.rotation, parent2.transform);
    }
    void ItemDestroy()
    {
        package_1 = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().animal_1;
        package_2 = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().animal_2;
        if (!package_1)
        {
            Destroy(item_1);
        }
        if (!package_2)
        {
            Destroy(item_2);
        }
    }
    void MixItemDestroy()
    {
        Destroy(item_1);
        Destroy(item_2);
    }

    void Flash()
    {
        if (iFlash == 0)
        {
            aniPackageUI.SetBool("attack", true);
            iFlash++;
        }
    }
}
