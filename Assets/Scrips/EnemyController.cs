using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
 {
    public float enemySpeed = 1;
    private Rigidbody2D enemyRigidbody;
    private bool isMoving;
    
    public float timeBetweenSteps = 5f;
    private float timeBetweenStepsCounter;
    
    public float timeToMakesStep =5f;
    private float timeToMakeStepCounter;
    
    public Vector2 direccionToMakeStep;
    private Animator enemyAnimator;
    
    public const string horizontal = "Horizontal";
    public const string vertical = "Vertical";
    private int[] direccion = { -1, 0, 1 };
   

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        timeBetweenStepsCounter = timeBetweenSteps*Random.Range(0.5f,1.5f);
        timeToMakeStepCounter = timeToMakesStep*Random.Range(0.5f,1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {

            timeToMakeStepCounter -= Time.deltaTime;
           
            enemyRigidbody.velocity = direccionToMakeStep;
            if (timeToMakeStepCounter < 0)
            {
                isMoving = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                enemyRigidbody.velocity = Vector2.zero;
            }
        }
        else {
            timeBetweenStepsCounter  -= Time.deltaTime;
            if (timeBetweenStepsCounter < 0)
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakesStep;
                int x = Random.Range(-1, 2);
                int y = Random.Range(-1, 2);
                print($"pos x = {x} pos y = {y}");



                direccionToMakeStep = new Vector2(x, y)*enemySpeed;
            }
        }
        //hacia a donde apunta el enemigo
        enemyAnimator.SetFloat(horizontal, direccionToMakeStep.x);
        enemyAnimator.SetFloat(vertical, direccionToMakeStep.y);
            
    }
}
