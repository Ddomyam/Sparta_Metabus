using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    //인스펙터에 공개
    [SerializeField] private SpriteRenderer characterRenderer;

    //0. 0 으로 설정
    protected Vector2 movementDirection = Vector2.zero;
    //읽기전용
    public Vector2 MovementDirection { get {return movementDirection;} }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get {return lookDirection;} }   

    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0f;

    protected AnimationHandler animationHandler;
    protected StatHandler statHandler;
    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
        if(knockbackDuration > 0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    protected virtual void HandleAction()
    {

    }

    private void Movement(Vector2 direction)
    {
        //스탯에서 스피드값을 가져옴
        direction = direction * statHandler.Speed;
        if(knockbackDuration > 0.0f)
        {
            direction *= 0.2f;
            direction += knockback;
        }

        _rigidbody.velocity = direction;
        //direction의 Vector2값 반환
        animationHandler.Move(direction);
    }

    private void Jump()
    {

    }

    private void Rotate(Vector2 direction)
    {
        //라디안 값을 구함
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;
    }
    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        //벡터의 값을 구함. 방향만 구하기 위해 normalized 
        knockback = -(other.position - transform.position).normalized * power;
    }
}
