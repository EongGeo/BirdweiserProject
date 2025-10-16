using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //state
    private StateMachine stateMachine;
    public StateIdle stateIdle;
    public StateJump stateJump;
    public StateTransition stateTransition;
    public StateDeath stateDeath;

    //component
    public PlayerAnim anim;
    public PlayerMove move;
    public PlayerInput input;
    public PlayerData data;

    //Inspector
    [Header("속도제어")]
    public float maxVelocityUP = 10.0f;
    [Header("점프 Force 제어")]
    public float jumpForce = 7.0f;
    public float jumpForceRateAtLowRise = 0.7f;
    public float jumpForceRateAtMiddleRise = 0.6f;
    public float jumpForceRateAtHighRise = 0.5f;
    [Header("속도에 따른 점프 구간")]
    public float lowRangeVelocityY = 1.0f;
    public float middleRangeVelocityY = 5.0f;


    public bool IsRotate { get; set; } = true;

    private bool isDeathTriggered = false;
    private bool justOnce = false;

    public PipePool pipePool;
    public GroundMove[] groundMoves;

    private void Awake()
    {
        anim = GetComponent<PlayerAnim>();
        move = GetComponent<PlayerMove>();
        input = GetComponent<PlayerInput>();
        data = GetComponent<PlayerData>();

        stateMachine = new StateMachine();
        stateIdle = new StateIdle(this, stateMachine);
        stateJump = new StateJump(this, stateMachine);
        stateTransition = new StateTransition(this, stateMachine);
        stateDeath = new StateDeath(this, stateMachine);

        pipePool = FindObjectOfType<PipePool>(); //씬에 있는 PipePool 가져옴
        groundMoves = FindObjectsOfType<GroundMove>(); //씬에있는 그라운드무브 가져옴
    }
    void Start()
    {
        stateMachine.ChangeState(stateIdle);
    }
    private void Update()
    {
        if (isDeathTriggered && !justOnce)
        {
            justOnce = true;    //Triggered가 여러번 감지되는 것을 방지
            isDeathTriggered = false; //한번만 실행되도록 초기화
            stateMachine.ChangeState(stateDeath);
        }
        stateMachine.Update();

        //============== 테스트용 리로드 ===================
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
        //================================================
        if (IsRotate) RotateTransformAsVelocityY();
    }
    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
        move.MaxVelocityControl(maxVelocityUP);
    }

    private void RotateTransformAsVelocityY()
    {
        float vel = move.GetVelocityY();
        float minVel = -maxVelocityUP;
        float maxVel = maxVelocityUP;

        float angle = Mathf.Lerp(-90f, 90f, Mathf.InverseLerp(minVel, maxVel, vel));

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    //충돌감지 trigger, collision 둘다 사용
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Pipe"))
        {
            isDeathTriggered = true;
        }
        if (collision.CompareTag("DeadZone"))
        {
            isDeathTriggered = true;
        }
        if (collision.CompareTag("ScoreZone"))
        {
            data.AddScore();
            Debug.Log("Score: " + data.Score);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            isDeathTriggered = true;
        }
        if (collision.gameObject.CompareTag("ScoreZone"))
        {
            data.AddScore();
            Debug.Log("Score: " + data.Score);
        }
    }
}
