using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] private float attackRate = 1f;
    [SerializeField] private float attackSpeed = 1f;
    
    private Animator _animator;
    private static readonly int AttackRight = Animator.StringToHash("AttackRight");
    private static readonly int AttackLeft = Animator.StringToHash("AttackLeft");
    private static readonly int Idle = Animator.StringToHash("Idle");

    private float _attackTimer = 0;
    
    private bool _isAttacking = false;

    private void Start()
    {
        if (TryGetComponent(out Animator animator))
        {
            _animator = animator;
            _animator.speed = attackSpeed;
        }
    }

    private void Update()
    {
        HandleAttack();
    }
    
    private void HandleAttack()
    {
        _attackTimer += Time.deltaTime;
        
        if (_isAttacking) return;

        float horizontal = Input.GetAxis("Horizontal");

        
        if (_attackTimer >= attackRate)
        {
            if (horizontal > 0)
            {
                _isAttacking = true;
                _animator.SetTrigger(AttackRight);
                _attackTimer = 0;
            }
            else if (horizontal < 0)
            {
                _isAttacking = true;
                _animator.SetTrigger(AttackLeft);
                _attackTimer = 0;
            }
        }
    }

    private void EndAttack()
    {
        // print("Attack ended");
        // _animator.SetTrigger(Idle);
        _isAttacking = false;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        print( other.gameObject.name );
        if (other.gameObject.CompareTag("Barrel"))
        {
            Destroy(other.gameObject);
        }
    }
}
