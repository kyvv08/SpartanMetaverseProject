using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidBody2d;

    public float flapForce = 6f; //점프 힘
    public float forwardSpeed = 3f; //정면 이동 속도
    public bool isDead = false;
    float deathCoolDown = 0f;

    bool isFlap = false;

    public bool godMode = false;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        animator = GetComponentInChildren<Animator>();  //자식 오브젝트까지 검색해서 요소를 가져옴
        rigidBody2d = GetComponent<Rigidbody2D>();

        if(animator == null)
        {
            Debug.LogError("애니메이터 찾을 수 없음\n");
        }
        if(rigidBody2d == null)
        {
            Debug.LogError("리지드바디 찾을 수 없음\n");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCoolDown <= 0f)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))     //마우스 0 - 좌클(스마트폰 터치 포함), 1 우클, 2 휠, 3 / 4 는 각 앞으로 가기, 뒤로가기
                {
                    GameState.Instance.fromMiniGame = true;
                    SceneManager.LoadScene("SampleScene");
                }
            }
            else
            {
                deathCoolDown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))     //마우스 0 - 좌클(스마트폰 터치 포함), 1 우클, 2 휠, 3 / 4 는 각 앞으로 가기, 뒤로가기
            {
                isFlap = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (isDead) return;
        Vector3 velocity = rigidBody2d.velocity;    //가속도 = velocity
        velocity.x = forwardSpeed;
        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }
        rigidBody2d.velocity = velocity;

        float angle = Mathf.Clamp(rigidBody2d.velocity.y * 10f, -90, 90); //매개변수로 전달된 값의 제한을 건다 min/max
        transform.rotation = Quaternion.Euler(0, 0, angle);     //x,y,z

    }

    //collision 충돌은 물리적으로 충돌, 힘을 가해서 부딪히는 충돌  -  trigge 충돌은 충돌 여부만 내려주고 실제로는 부딪히는 효과를 내지 않음
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (isDead) return;

        isDead = true;

        deathCoolDown = 1f;

        animator.SetInteger("isDie", 1);
        gameManager.GameOver();
    }
}
