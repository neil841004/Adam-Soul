using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum State
    {
        playerUp,
        playerDown,
        playerLeft,
        playerRight
    }
    
    public State state;
    float speed = 6f;
    public float speedOringin = 6f;
    public GameObject animal_1 = null;
    public GameObject animal_2 = null;
    public GameObject charSound;
    private Vector3 movement;
    private Rigidbody playerRb;
    Animator animator;
    Animator aniTeach;
    public bool isAttack;
    public bool isMove = false;
    public bool isThrow = false;
    bool isMix = false;
    bool onRiver = false;
    bool slowSpeed = false;
    private int curstate;
    public int count = 0;
    int throwDistance = 2;
    GameObject obj;
    private int[] chooseani = new int[2];
    public GameObject detect;
    bool playingMixAnimation = false;
    // Use this for initialization
    void Start()
    {
        state = State.playerRight;
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        aniTeach = GameObject.Find("teach_move").GetComponent<Animator>();
        isAttack = false;
        Physics.IgnoreLayerCollision(8, 10);
        obj = GameObject.FindWithTag("UI");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3 = transform.position;
        playingMixAnimation = GameObject.FindWithTag("MixAni").GetComponent<MixAnimation>().playing;
        if (!animal_2 && !playingMixAnimation)
        {
            if (Input.GetKey("space"))
            {
                isAttack = true;
                charSound.SendMessage("PlaySound",2);
            }
            if (!Input.GetKey("space"))
            {
                if(isAttack){
                charSound.SendMessage("StopSound",2);
                isAttack = false;
                }
            }
        }
        if (animal_2)
        {
            if(isAttack){
                charSound.SendMessage("StopSound",2);
                isAttack = false;
                }
        }
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (isAttack)
        {
            slowSpeed = true;
            speed = speedOringin * 0.6f;
        }
        if (isThrow)
        {
            slowSpeed = true;
            speed = 0;
            aniTeach.SetBool("throw", isThrow);
        }
        if (!isAttack && !isThrow)
        {
            slowSpeed = false;
        }
        if (!isAttack && !isThrow && !onRiver)
        {
            speed = speedOringin;
        }
        if (!playingMixAnimation)
        {
            Move(h, v);
            if (!isAttack)
            {
                Throw();
            }
            StateMachine();
        }
        if (playingMixAnimation)
        {
            animator.SetBool("move", false);
            playerRb.velocity = new Vector3(0, 0, 0);
            StopSound();
        }
    }
    void Move(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed;
        playerRb.velocity = movement;
        // transform.Translate(movement * Time.deltaTime);
        if (!slowSpeed)
        {
            if (h == 1)
            {
                SetPlayerState(State.playerRight);
                throwDistance = 2;
            }
            else if (h == -1)
            {
                SetPlayerState(State.playerLeft);
                throwDistance = -2;
            }
        }
        if (h == 0 && v == 0)
        {
            if (isMove)
            {
                StopSound();
                isMove = false;
            }
        }
        else if (h != 0 || v != 0)
        {
            isMove = true;
            aniTeach.SetBool("move", isMove);
            if(!isThrow)
            PlaySound();
            if(isThrow)
            StopSound();
        }
    }
    void SetPlayerState(State newState)
    {
        if (newState != state)
        {
            Vector3 vS = this.transform.localScale;
            vS.x *= -1;
            this.transform.localScale = vS;
            state = newState;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("River"))
        {
            speed = speedOringin * 0.6f;
            onRiver = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("River"))
        {
            speed = speedOringin;
            onRiver = false;
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (isAttack)
        {
            if (other.collider.CompareTag("Animal"))
            {
                GameObject.FindWithTag("UI").SendMessage("Flash");
                aniTeach.SetBool("attack", isAttack);
                {
                    if (!animal_1)
                    {
                        animal_1 = other.gameObject;
                        animal_1.gameObject.SetActive(false);
                        obj.SendMessage("Item1");
                    }
                    else if (animal_1)
                    {
                        animal_2 = other.gameObject;
                        animal_2.gameObject.SetActive(false);
                        obj.SendMessage("Item2");
                        aniTeach.SetBool("mix", true);
                    }
                }
            }
            if (other.collider.CompareTag("Woman"))
            {

            }
        }

    }
    private void Throw()
    {
        if (Input.GetKeyDown(KeyCode.R) && isThrow == false)
        {
            charSound.SendMessage("PlaySound",1);
            if (!animal_2)
            {
                isThrow = true;
                animator.SetBool("throw", isThrow);
                animal_1.gameObject.SetActive(true);
                Vector3 vector3 = this.transform.position;
                vector3.x += throwDistance;
                animal_1.transform.position = vector3;
                animal_1 = null;
            }
            else if (animal_2)
            {
                isThrow = true;
                animator.SetBool("throw", isThrow);
                animal_2.gameObject.SetActive(true);
                Vector3 vector3 = this.transform.position;
                vector3.x += throwDistance;
                animal_2.transform.position = vector3;
                animal_2 = null;
            }
            GameObject.FindWithTag("UI").SendMessage("ItemDestroy");
            GameObject.FindWithTag("potUI").GetComponent<PotUI>().haveMix = false;
        }
    }
    private void StateMachine()
    {
        animator.SetBool("move", isMove);
        animator.SetBool("attack", isAttack);
    }
    public void EndThrow()
    {
        isThrow = false;
        animator.SetBool("throw", isThrow);
    }
    void TakeJoint()
    {

    }
    void PlaySound()
    {
        
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
                this.GetComponent<AudioSource>().loop = true;
                this.GetComponent<AudioSource>().Play();
        }
    }
    void StopSound()
    {
        this.GetComponent<AudioSource>().Stop();
    }
}

