using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public enum State
    {
        monsterLeft,
        monsterRight
    }
    public State state;
    public int generateAmount = 3;
    private GameObject player;
    public GameObject escapeUI;
    bool isRange;

    float AiMovetime;
    float AiMovetimer;
    float AiMovetimeMax = 5f;
    float AiMovetimeMin = 2f;

    public float uHeight = 1f;

    int aiX;
    int aiZ;
    public int aiRange = 3;
    bool aiState = true;
    public float speed = 2.0f;
    public int runSpeed = 3;
    public bool haveWalkAnimation;
    Animator animator;
    GameObject g;
    public float direction;
    PlayerMovement playermove;
    int escapeCount = 0;
    // Use this for initialization
    void Start()
    {
        state = State.monsterLeft;
        isRange = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playermove = player.GetComponent<PlayerMovement>();
        AiMovetime = Random.Range(AiMovetimeMin, AiMovetimeMax);
        AiMovetimer = 0;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isRange && playermove.isAttack && gameObject.CompareTag("Animal"))
        {
            Move();
        }
        if (escapeCount <= 32 && escapeCount >= 1)
        {
            Escape();
        }
        if ((!isRange || !playermove.isAttack) && escapeCount == 0)
        {
            AiMove();
        }
        if (aiX > 0)
        {
            //SetMonsterState(State.monsterRight);
            Vector3 lTemp = transform.localScale;
            lTemp.x = -direction;
            transform.localScale = lTemp;
        }
        if (aiX < 0)
        {
            //SetMonsterState(State.monsterLeft);
            Vector3 lTemp = transform.localScale;
            lTemp.x = direction;
            transform.localScale = lTemp;
        }
    }

    void Move()
    {
        transform.position += (player.transform.position - transform.position).normalized * speed * Time.deltaTime;
    }
    void Escape()
    {
        if (player.transform.position.x > transform.position.x) { aiX = -4; }
        if (player.transform.position.x <= transform.position.x) { aiX = 4; }
        transform.Translate(aiX * Time.deltaTime, 0, 0);

        Vector3 v3 = new Vector3(transform.position.x, transform.position.y, transform.position.z + uHeight);
        if (escapeCount == 1) { g = Instantiate(escapeUI, v3, transform.rotation, this.transform); }
        Destroy(g, 1f);
        escapeCount++;
        animator.SetInteger("walk", 1);

        if (escapeCount >= 30)
        {
            escapeCount = 0;
        }
    }

    void AiMove()
    {
        AiMovetimer += Time.deltaTime;
        transform.Translate(aiX * Time.deltaTime, aiZ * Time.deltaTime, 0);
        if (AiMovetimer > AiMovetime)
        {
            int walkOrStop;
            walkOrStop = Random.Range(0, 2);
            if (walkOrStop == 0)
            {
                aiX = 0;
                aiZ = 0;
                if (haveWalkAnimation)
                {
                    animator.SetInteger("walk", walkOrStop);
                }
            }
            if (walkOrStop == 1)
            {
                aiX = Random.Range(-runSpeed, runSpeed);
                aiZ = Random.Range(-runSpeed, runSpeed);
                if (haveWalkAnimation)
                {
                    animator.SetInteger("walk", walkOrStop);
                }
            }
            AiMovetimer = 0;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Detect"))
        {
            isRange = true;
            if (playermove.isAttack && gameObject.CompareTag("Xattack") && escapeCount == 0)
            {
                escapeCount = 1;
                this.GetComponent<AudioSource>().Play();
            }
        }
    }


    private void OnCollisionStay(Collision other)
    {
        if (!other.collider.CompareTag("Player"))
        {
            escapeCount = 0;
        }
        if (gameObject.name != "fish" && gameObject.name != "Loch Ness Monster")
        {
            if (other.collider.name == "wall_up" || other.collider.name == "RiverWall_down")
            {
                aiZ = -Mathf.Abs(aiZ);
            }
            if (other.collider.name == "wall_down")
            {
                aiZ = Mathf.Abs(aiZ);
            }
            if (other.collider.name == "wall_left" || other.collider.name == "RiverWall_right")
            {
                aiX = Mathf.Abs(aiX);
            }
            if (other.collider.name == "wall_right")
            {
                aiX = -Mathf.Abs(aiX);
            }
        }
        if (gameObject.name == "fish" || gameObject.name == "Loch Ness Monster")
        {
            if (other.collider.name == "wall_up")
            {
                aiZ = -Mathf.Abs(aiZ);
            }
            if (other.collider.name == "wall_down" || other.collider.name == "RiverWall_down")
            {
                aiZ = Mathf.Abs(aiZ);
            }
            if (other.collider.name == "wall_left")
            {
                aiX = Mathf.Abs(aiX);
            }
            if (other.collider.name == "wall_right" || other.collider.name == "RiverWall_right")
            {
                aiX = -Mathf.Abs(aiX);
            }
        }
        if (gameObject.name == "Woman" && other.collider.CompareTag("Player"))
        {
            aiX = 0;
            aiZ = 0;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if ((other.collider.CompareTag("static") || other.collider.CompareTag("Player") || other.collider.CompareTag("Set")) && escapeCount == 0 )
        {
            aiX = -aiX;
            aiZ = -aiZ;
        }
        if (!other.collider.CompareTag("Player"))
        {
            escapeCount = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Detect"))
        {
            isRange = false;
        }
    }


    void SetMonsterState(State newState)
    {
        if (newState != state)
        {
            Vector3 vS = this.transform.localScale;
            vS.x *= -1;
            this.transform.localScale = vS;
            state = newState;
        }
    }

}
