using System.Collections;
using UnityEngine;

//  RequireComponent ?
//  typeof(클래스 컴포넌트 이름)가 없으면 자동으로 추가해준다.
[RequireComponent(typeof(PawnAnimation))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed; //  캐릭터 이동속도
    [SerializeField] private float m_JumpSpeed; //  캐릭터 점프 가중치
    private PawnAnimation m_PawnAnimation;      //  캐릭터 애니메이션 컴포넌트
    private float m_JumpPower = 0;              //  캐릭터 점프 물리 힘

    public bool IsLeft { get; private set; } = false;       //  캐릭터 방향이 왼쪽인가?
    public bool IsMoveLock { get; private set; } = false;   //  캐릭터가 움직일 수 있는가?

    private void Awake()
    {
        //  GetComponent ?
        //  이 객체가 가지고 있는 컴포넌트 중에 해당 <타입> 컴포넌트를 가져온다
        //  만약 없다면 null을 반환한다
        m_PawnAnimation = GetComponent<PawnAnimation>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (!IsLeft)
            {
                transform.Rotate(Vector3.up * 180f);
                IsLeft = true;
            }

            Vector3 speed = Vector3.right * m_MoveSpeed * Time.deltaTime;
            transform.Translate(speed);

            m_PawnAnimation.Move = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (IsLeft)
            {
                transform.Rotate(Vector3.up * 180f);
                IsLeft = false;
            }

            Vector3 speed = Vector3.right * m_MoveSpeed * Time.deltaTime;
            transform.Translate(speed);

            m_PawnAnimation.Move = true;
        }
        else
            m_PawnAnimation.Move = false;
    }

    private void FixedUpdate()
    {
        
    }
}