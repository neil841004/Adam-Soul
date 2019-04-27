using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadercontral : MonoBehaviour
{
    [SerializeField] private Material mm; //crazy材質球(+對應的shader)
    [SerializeField] [Range(0, 2)] float speed = 0.8f;//定義速度取名"speed" 下限與上限0至2
    [SerializeField] [Range(0, 1)] float alpha;//同上 "透明度"
    [SerializeField] [Range(0, 1)] float cc;//"顏色交錯"
    public bool eatUmariluana = false;
    
    // Start is called before the first frame update
    void Start()
    {
        mm.SetFloat("_speed", speed);
        mm.SetFloat("_alpha", alpha);
        mm.SetFloat("_changecolor", cc);
        //對應crazy-shader的命名抓shader的功能
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     //按鍵事件請無視 測個東西
        //     speed -= 0.5f;
        //     mm.SetFloat("_speed", speed);
        // }
        //"給予Abs絕對值限定正數"|sin作為-1~1之曲線"配合遊戲時間"|乘一個數值作為速率
        cc = Mathf.Abs(Mathf.Sin(Time.time)) * 1f;
        mm.SetFloat("_changecolor", cc);
        // alpha = Mathf.Abs(Mathf.Sin(Time.time)) /2f;
        // mm.SetFloat("_alpha", alpha);//效果妥妥的

    }
    public void UmariluanaEnter()
    {
        if(!eatUmariluana){
        StartCoroutine("Crazzy");
        }
    }
    public void UmariluanaOut()
    {

    }
    public IEnumerator Crazzy()
    {
        eatUmariluana = true;
        this.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip);
        if(GameObject.FindWithTag("Woman")){
            GameObject.FindWithTag("Woman").SendMessage("Angry",true);
        }
        while (alpha <= 0.4f)
        {
            alpha += 0.04f;
            mm.SetFloat("_alpha", alpha);//效果妥妥的
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine("CrazzyEnd");
    }
    public IEnumerator CrazzyEnd()
    {
        yield return new WaitForSeconds(5f);
        while (alpha >= 0f)
        {
            alpha -= 0.04f;
            mm.SetFloat("_alpha", alpha);//效果妥妥的
            yield return new WaitForSeconds(0.05f);
        }
        eatUmariluana = false;
        GameObject.FindWithTag("Woman").SendMessage("Angry",false);
        yield break;
    }
}
/* tt += Time.deltaTime;
        if (tt >= 1f)
        {
            float cc = Random.Range(0.0f, 1.0f);
            float alpha = Random.Range(0.0f, 1.0f);
            mm.SetFloat("_changecolor", cc);
            mm.SetFloat("_alpha", alpha);
            tt = 0;
        }*///用亂數效果不好
