using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    private float currentSpeed;
    private bool walking = false;
    private Vector2 lastMovement = Vector2.zero;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingSet = "Walking";
    private Animator animator;
    private Rigidbody2D playerRigidbody;
    public static bool playerCreated;
    public string nextPlaceName;
    private const string attackingState = "Attack";
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;



    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        if (!playerCreated)
        {
            playerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
            print($"la pos z es: {this.transform.position.z}");
        }
        else {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        walking = false;
        if (Input.GetMouseButton(0)) {
            attacking = true;
            attackTimeCounter = attackTime;
            playerRigidbody.velocity = Vector2.zero;
            animator.SetBool(attackingState, true);
        }
        if (attacking)
        {

            attackTimeCounter -= Time.deltaTime;
            if (attackTimeCounter < 0)
            {
                attacking = false;
                animator.SetBool(attackingState, false);
            }

        }
        else
        {

            if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
            {
                this.transform.Translate(
                     new Vector3(Input.GetAxisRaw(horizontal) * currentSpeed * Time.deltaTime, 0)
                    );
                /*
                 playerRigidbody.velocity = new Vector2(Input.GetAxisRaw(horizontal) * speed * Time.deltaTime, playerRigidbody.velocity.y);
                  */
                walking = true;
                lastMovement = new Vector2(Input.GetAxisRaw(horizontal), 0);
            }
            if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
            {

                this.transform.Translate(
                     new Vector3(0, Input.GetAxisRaw(vertical) * currentSpeed * Time.deltaTime, 0)
                    );
                /*
               playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Input.GetAxisRaw(vertical) * speed * Time.deltaTime);
   */
                walking = true;
                lastMovement = new Vector2(0, Input.GetAxisRaw(vertical));

            }
           
        }

        //Es para que cuando el player se mueve en diagonal no vaya mas rapido que en una sola direccion
        if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f && Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
        {
            currentSpeed = speed / Mathf.Sqrt(2);
        }
        else {
            currentSpeed = speed;
        }
        if (!walking)
        {
            playerRigidbody.velocity = Vector2.zero;
        }
        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical, Input.GetAxisRaw(vertical));
        animator.SetBool(walkingSet,walking);
        animator.SetFloat(lastHorizontal, lastMovement.x);
        animator.SetFloat(lastVertical, lastMovement.y);
    }
}
