using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixAnimation : MonoBehaviour
{

    [System.Serializable]
    public struct MixGameObject
    {
        public GameObject newThing;
        public GameObject image;
        public GameObject text;
    }
    public GameObject potIcon;
    public Text completion;
    public Text completionRate;
    GameObject mixObject;
    GameObject obj;
    GameObject objNew;
    GameObject objText;
    public GameObject newIcon;
    public MixGameObject[] mixGameObjects = new MixGameObject[36];
    Animator animator;
    public int startAni = 0;
    public bool playing = false;
    bool iconFade;
    Color objColor;
    Color objNewColor;
    Color objTextColor;
    Color completionColor;
    Color completionRateColor;
    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startAni >= 1)
        {
            playing = true;
            animator.SetBool("MixStart", true);
            startAni++;
            if (startAni >= 5)
            {
                startAni = 0;
            }
        }
        if (startAni == 0)
        {
            animator.SetBool("MixStart", false);
        }
        AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateinfo.IsName("WhiteFade"))
        {
            if (stateinfo.normalizedTime >= 0.8f)
            {
                playing = false;
            }
        }
        if (iconFade && objColor.a <= 1 && objNewColor.a <= 1 && playing)
        {
            objColor.a += 0.03f;
            objNewColor.a += 0.03f;
            objTextColor.a += 0.03f;
            completionColor.a += 0.03f;
            completionRateColor.a += 0.03f;
            obj.GetComponent<Image>().color = objColor;
            objNew.GetComponent<Image>().color = objNewColor;
            objText.GetComponent<Image>().color = objTextColor;
            completion.color = completionColor;
            completionRate.color = completionRateColor;
        }
        if (!iconFade && objColor.a >= 0 && objNewColor.a >= 0 && playing)
        {
            objColor.a -= 0.055f;
            objNewColor.a -= 0.055f;
            objTextColor.a -= 0.055f;
            completionColor.a -= 0.055f;
            completionRateColor.a -= 0.055f;
            obj.GetComponent<Image>().color = objColor;
            objNew.GetComponent<Image>().color = objNewColor;
            objText.GetComponent<Image>().color = objTextColor;
            completion.color = completionColor;
            completionRate.color = completionRateColor;
        }
        if (!iconFade && objColor.a <= 0 && objNewColor.a <= 0 && !playing)
        {
            Destroy(obj);
            Destroy(objNew);
            Destroy(objText);

        }
        if (playing)
        {
            float iRecord = GameObject.FindWithTag("pot").GetComponent<Spawner>().iRecord;
            iRecord = iRecord * 10 / 3.1f;
            completion.text = "地球復甦率";
            completionRate.text = iRecord.ToString("0.0") + "%";
            potIcon.SendMessage("EndShow");
            potIcon.GetComponent<PotUI>().haveMix = false;
            potIcon.GetComponent<PotUI>().currentIcon = 1;
        }

    }
    public void CallMix()
    {
        GameObject.FindWithTag("pot").gameObject.SendMessage("AnimalGenerate");
    }
    public void ShowIcon()
    {
        mixObject = GameObject.FindWithTag("pot").GetComponent<Spawner>().mixObject;
        for (int i = 0; i < 36; i++)
        {
            if (mixGameObjects[i].newThing.name == mixObject.name)
            {
                objNew = Instantiate(newIcon, transform.position, transform.rotation, this.transform);
                obj = Instantiate(mixGameObjects[i].image, transform.position, transform.rotation, this.transform);
                objText = Instantiate(mixGameObjects[i].text, transform.position, transform.rotation, this.transform);
                objColor = obj.GetComponent<Image>().color;
                objNewColor = objNew.GetComponent<Image>().color;
                objTextColor = objText.GetComponent<Image>().color;
                completionColor = completion.color;
                completionRateColor = completionRate.color;
                iconFade = true;
            }
        }
    }
    public void EndShowIcon()
    {
        iconFade = false;
    }
    public void ShowIpotIcon()
    {
        potIcon.SendMessage("FlashStart");
    }
}