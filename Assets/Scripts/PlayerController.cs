using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // public float collisionOffset = 0.05f;
    // public ContactFilter2D movementFilter;
    // public SwordAtk swordAtk;
    // List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    bool IsMoving{
        set {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }
    bool canMove = true;
    public float moveSpeed = 150f;
    public float maxSpeed = 8f;
    Vector2 moveInput = Vector2.zero;
    Rigidbody2D rb;
    Collider2D swordCollider;
    Animator animator;
    public GameObject swordHitbox;
    SpriteRenderer spriteRenderer;
    public float idleFriction = 0.9f;
    bool isMoving = false;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        swordCollider = swordHitbox.GetComponent<Collider2D>();
    }
    // private void FixedUpdate()
    // {
    //     if(canMove)
    //     {
    //         if(movementInput != Vector2.zero)
    //         {
    //             bool success = TryMove(movementInput);
    //             if(!success /*&& movementInput.x > 0*/)
    //             {
    //                 success = TryMove(new Vector2(movementInput.x, 0));
    //             }
    //             if(!success /*&& movementInput.y > 0*/)
    //             {
    //                 success = TryMove(new Vector2(0, movementInput.y));
    //             }
    //             animator.SetBool("isMoving", success);
    //         }else
    //         {
    //             animator.SetBool("isMoving", false);
    //         }
    //         if(movementInput.x < 0)
    //         {
    //             spriteRenderer.flipX = true;
    //             //swordAtk.atkDirection = SwordAtk.AtkDirection.left;
    //         }else if(movementInput.x > 0)
    //         {
    //             spriteRenderer.flipX = false;
    //             //swordAtk.atkDirection = SwordAtk.AtkDirection.right;
    //         }
    //     }
        
    // }
    // private bool TryMove(Vector2 direction)
    // {
    // if(direction != Vector2.zero)
    // {
    //         int count = rb.Cast(
    //             direction,
    //             movementFilter,
    //             castCollisions,
    //             moveSpeed * Time.fixedDeltaTime + collisionOffset);

    //     if(count == 0)
    //     {
    //         rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    //         return true;
    //     }else
    //     {
    //         return false;
    //     }
    //     }else
    //     {
    //         return false;
    //     }
    // }
    // void OnMove(InputValue movementValue)
    // {
    //     movementInput = movementValue.Get<Vector2>();
    // }
    // void OnFire()
    // {
    //     animator.SetTrigger("swordAtk");
    // }
    // public void SwordAtk()
    // {
    //     LockMovement();
    //     if(spriteRenderer.flipX == true)
    //     {
    //         swordAtk.AtkLeft();
    //     }else{
    //         swordAtk.AtkRight();
    //     }
    // }
    // public void EndSwordAtk()
    // {
    //     UnLockMovement();
    //     swordAtk.StopAtk();
    // }
    // public void LockMovement()
    // {
    //     canMove = false;
    // }
    // public void UnLockMovement()
    // {
    //     canMove = true;
    // }
    void FixedUpdate(){
        if(canMove == true && moveInput != Vector2.zero){
            rb.velocity = Vector2.ClampMagnitude(rb.velocity + (moveInput * moveSpeed * Time.deltaTime), maxSpeed);
        if(moveInput.x >0){
            spriteRenderer.flipX = false;
        }else if(moveInput.x < 0){
            spriteRenderer.flipX = true;
        }

        isMoving = true;

        }else{
            //rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            isMoving = false;
        }
    }
    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }
    void UpdateAnimatorParameters() {
        animator.SetBool("isMoving", isMoving);
    }
    void OnFire(){
        animator.SetTrigger("swordAttack");
    }
    void LockMovement(){
        canMove = false;
    }
    void UnLockMovement(){
        canMove = true;
    }
}

