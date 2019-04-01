using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] monster;
    public GameObject[] record = new GameObject[36];
    [System.Serializable]
    public struct RecordGarbage
    {
        public string garbageA;
        public string garbageB;
    }
    public RecordGarbage[] recordGarbage = new RecordGarbage[50];
    public GameObject potUI;
    public int iRecord = 0;
    Vector3 vector3;
    bool born = true;
    GameObject a;
    GameObject b;
    public GameObject parent;
    public GameObject mixObject;
    Animator aniTeach;
    public int iGarbage = 0;

    // Use this for initialization

    // Update is called once per frame
    void Start()
    {
        aniTeach = GameObject.Find("teach_move").GetComponent<Animator>();
    }
    void Update()
    {
        a = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().animal_1;
        b = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().animal_2;
        if (born)
        {
            Spawn();
            born = false;
        }
    }
    void Spawn()
    {
        //Random.RandomRange(1, 3.5f)
        for (float i = 0; i < 2; i += 1)
        {
            for (int j = 0; j < 3; j += 1)
            {
                int targetX = Random.Range(-16, 16);
                int targetZ = Random.Range(-9, 9);
                vector3 = new Vector3(transform.position.x + targetX, 0, transform.position.z + targetZ);
                GameObject g = Instantiate(monster[j], vector3, transform.rotation);
                g.name = monster[j].name;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Mix();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            potUI.SendMessage("FlashStart");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            potUI.SendMessage("EndShow");
        }
    }
    private void Mix()
    {
        mixObject = MyHashSet.GetComposite(a, b);
        haveRecord();
        if (mixObject && haveRecord() == 0 && a.name != b.name)
        {
            if (mixObject.tag == "Woman")
            {
                GameObject.FindWithTag("MixAni").GetComponent<Animator>().SetBool("womanEnd", true);
            }
            if (mixObject.tag == "Man")
            {
                GameObject.FindWithTag("MixAni").GetComponent<MixAnimation>().manEnd = true;
                GameObject.FindWithTag("MixAni").GetComponent<Animator>().SetBool("manEnd", true);
            }
            GameObject.FindWithTag("MixAni").GetComponent<MixAnimation>().startAni = 1;
            aniTeach.SetBool("mixStop", true);
            mixRecord(mixObject);
            iRecord++;
            GameObject.FindWithTag("UI").SendMessage("MixItemDestroy");
        }
        HaveGarbage();
        if (mixObject == null && a.name != b.name && HaveGarbage() ==0)
        {
            GameObject.FindWithTag("MixAni").GetComponent<MixAnimation>().startAni = 1;
            GameObject.FindWithTag("UI").SendMessage("MixItemDestroy");
            recordGarbage[iGarbage].garbageA = a.name;
            recordGarbage[iGarbage].garbageB = b.name;
            
        }
        if (GameObject.Find("nana"))
        {
            GameObject.FindObjectOfType<OnPS>().SendMessage("OpenPs4");
        }
    }
    void Generate(GameObject obj)
    {
        GameObject g = Instantiate(obj, obj.transform.position, obj.transform.rotation);
        g.name = obj.name;
        g.gameObject.SetActive(true);
    }
    void RandomGenerate(GameObject obj)
    {
        int targetX = Random.Range(-16, 16);
        int targetZ = Random.Range(-9, 9);
        Vector3 v3 = new Vector3(transform.position.x + targetX, 0, transform.position.z + targetZ);
        GameObject g = Instantiate(obj, v3, obj.transform.rotation);
        g.name = obj.name;
        g.gameObject.SetActive(true);
    }
    void mixRecord(GameObject obj)
    {
        record[iRecord] = obj;
    }
    int haveRecord()
    {
        for (int i = 0; i < iRecord; i++)
        {
            if (record[i] == mixObject)
            {
                GameObject.FindWithTag("potUI").GetComponent<PotUI>().haveMix = true;

                return 1;
            }
        }
        return 0;
    }
    void AnimalGenerate()
    {
        if (mixObject)
        {
            if (mixObject.tag == "static")
            {
                Generate(mixObject);
                if (a.name != "fish")
                {
                    RandomGenerate(a);
                    Destroy(a);
                }
                if (a.name == "fish")
                {
                    GameObject g = Instantiate(a, a.transform.position, a.transform.rotation);
                    g.name = a.name;
                    g.gameObject.SetActive(true);
                    Destroy(a);
                }
                if (b.name != "fish")
                {
                    RandomGenerate(b);
                    Destroy(b);
                }
                if (b.name == "fish")
                {
                    GameObject g = Instantiate(b, b.transform.position, b.transform.rotation);
                    g.name = b.name;
                    g.gameObject.SetActive(true);
                    Destroy(b);
                }
            }
            if (mixObject.tag == "Set")
            {
                Generate(mixObject);
                if (a.name != "fish")
                {
                    RandomGenerate(a);
                    Destroy(a);
                }
                if (a.name == "fish")
                {
                    GameObject g = Instantiate(a, a.transform.position, a.transform.rotation);
                    g.name = a.name;
                    g.gameObject.SetActive(true);
                    Destroy(a);
                }
                if (b.name != "fish")
                {
                    RandomGenerate(b);
                    Destroy(b);
                }
                if (b.name == "fish")
                {
                    GameObject g = Instantiate(b, b.transform.position, b.transform.rotation);
                    g.name = b.name;
                    g.gameObject.SetActive(true);
                    Destroy(b);
                }
            }
            if (mixObject.tag == "Animal" && mixObject.name != "fish" && mixObject.name != "Loch Ness Monster")
            {
                int amount = mixObject.GetComponent<Animal>().generateAmount;
                for (int i = 0; i < amount; i++)
                {
                    RandomGenerate(mixObject);
                }
                if (a.name != "fish")
                {
                    RandomGenerate(a);
                    Destroy(a);
                }
                if (a.name == "fish")
                {
                    GameObject g = Instantiate(a, a.transform.position, a.transform.rotation);
                    g.name = a.name;
                    g.gameObject.SetActive(true);
                    Destroy(a);
                }
                if (b.name != "fish")
                {
                    RandomGenerate(b);
                    Destroy(b);
                }
                if (b.name == "fish")
                {
                    GameObject g = Instantiate(b, b.transform.position, b.transform.rotation);
                    g.name = b.name;
                    g.gameObject.SetActive(true);
                    Destroy(b);
                }
            }
            if (mixObject.tag == "Xattack" && mixObject.name != "Loch Ness Monster")
            {
                int amount = mixObject.GetComponent<Animal>().generateAmount;
                for (int i = 0; i < amount; i++)
                {
                    RandomGenerate(mixObject);
                }
                if (a.name != "fish")
                {
                    RandomGenerate(a);
                    Destroy(a);
                }
                if (a.name == "fish")
                {
                    GameObject g = Instantiate(a, a.transform.position, a.transform.rotation);
                    g.name = a.name;
                    g.gameObject.SetActive(true);
                    Destroy(a);
                }
                if (b.name != "fish")
                {
                    RandomGenerate(b);
                    Destroy(b);
                }
                if (b.name == "fish")
                {
                    GameObject g = Instantiate(b, b.transform.position, b.transform.rotation);
                    g.name = b.name;
                    g.gameObject.SetActive(true);
                    Destroy(b);
                }
            }

            if (mixObject.name == "Loch Ness Monster")
            {
                Generate(mixObject);
                if (a.name != "fish")
                {
                    RandomGenerate(a);
                    Destroy(a);
                }
                if (a.name == "fish")
                {
                    GameObject g = Instantiate(a, a.transform.position, a.transform.rotation);
                    g.name = a.name;
                    g.gameObject.SetActive(true);
                    Destroy(a);
                }
                if (b.name != "fish")
                {
                    RandomGenerate(b);
                    Destroy(b);
                }
                if (b.name == "fish")
                {
                    GameObject g = Instantiate(b, b.transform.position, b.transform.rotation);
                    g.name = b.name;
                    g.gameObject.SetActive(true);
                    Destroy(b);
                }
            }
            if (mixObject.name == "fish")
            {
                for (int i = 0; i < 3; i++)
                {
                    int targetX = Random.Range(-16, -4);
                    int targetZ = Random.Range(8, 10);
                    Vector3 vector3 = new Vector3(transform.position.x + targetX, 0, transform.position.z + targetZ);
                    GameObject g = Instantiate(mixObject, vector3, mixObject.transform.rotation);
                    g.name = mixObject.name;
                }
                RandomGenerate(a);
                Destroy(a);
                RandomGenerate(b);
                Destroy(b);
            }
            if (mixObject.tag == "Woman")
            {
                Generate(mixObject);
                RandomGenerate(a);
                Destroy(a);
                RandomGenerate(b);
                Destroy(b);
                GameObject.FindWithTag("MixAni").GetComponent<Animator>().SetBool("womanEnd", true);
            }
            if (mixObject.tag == "Man")
            {
                RandomGenerate(a);
                Destroy(a);
                RandomGenerate(b);
                Destroy(b);
            }
        }
        if (mixObject == null)
        {
            RandomGenerate(a);
            Destroy(a);
            RandomGenerate(b);
            Destroy(b);
            GameObject.FindWithTag("garbage").gameObject.transform.GetChild(iGarbage).gameObject.SetActive(true);
            iGarbage++;
        }
    }
    int HaveGarbage(){
        for (int i = 0; i < iGarbage; i++)
        {
            if ((recordGarbage[i].garbageA == a.name && recordGarbage[i].garbageB == b.name)||(recordGarbage[i].garbageA == b.name && recordGarbage[i].garbageB == a.name) )
            {
                GameObject.FindWithTag("potUI").GetComponent<PotUI>().haveMix = true;

                return 1;
            }
        }
        return 0;
    }
}