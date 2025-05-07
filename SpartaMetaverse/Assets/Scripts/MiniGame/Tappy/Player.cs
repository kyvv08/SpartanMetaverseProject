using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidBody2d;

    public float flapForce = 6f; //���� ��
    public float forwardSpeed = 3f; //���� �̵� �ӵ�
    public bool isDead = false;
    float deathCoolDown = 0f;

    bool isFlap = false;

    public bool godMode = false;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        animator = GetComponentInChildren<Animator>();  //�ڽ� ������Ʈ���� �˻��ؼ� ��Ҹ� ������
        rigidBody2d = GetComponent<Rigidbody2D>();

        if(animator == null)
        {
            Debug.LogError("�ִϸ����� ã�� �� ����\n");
        }
        if(rigidBody2d == null)
        {
            Debug.LogError("������ٵ� ã�� �� ����\n");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCoolDown <= 0f)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))     //���콺 0 - ��Ŭ(����Ʈ�� ��ġ ����), 1 ��Ŭ, 2 ��, 3 / 4 �� �� ������ ����, �ڷΰ���
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
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))     //���콺 0 - ��Ŭ(����Ʈ�� ��ġ ����), 1 ��Ŭ, 2 ��, 3 / 4 �� �� ������ ����, �ڷΰ���
            {
                isFlap = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (isDead) return;
        Vector3 velocity = rigidBody2d.velocity;    //���ӵ� = velocity
        velocity.x = forwardSpeed;
        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }
        rigidBody2d.velocity = velocity;

        float angle = Mathf.Clamp(rigidBody2d.velocity.y * 10f, -90, 90); //�Ű������� ���޵� ���� ������ �Ǵ� min/max
        transform.rotation = Quaternion.Euler(0, 0, angle);     //x,y,z

    }

    //collision �浹�� ���������� �浹, ���� ���ؼ� �ε����� �浹  -  trigge �浹�� �浹 ���θ� �����ְ� �����δ� �ε����� ȿ���� ���� ����
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
