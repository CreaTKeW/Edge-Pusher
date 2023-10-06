using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] Transform rayStart;
    [SerializeField] float speed = 1f;
    private Animator anim;
    private bool rightTurn = true;
    private Rigidbody rb;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }
        else { anim.SetTrigger("gameStarted"); }
        rb.transform.position = transform.position + transform.forward * speed * Time.deltaTime;       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchSides();
        }

        RaycastHit hit;
        if(!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            anim.SetTrigger("isDead");
        }
    }

    void SwitchSides()
    {
        rightTurn = !rightTurn;
        if(rightTurn)
        {
            rb.transform.rotation = Quaternion.Euler(0f, 45f, 0f);
        }
        else 
        {
            rb.transform.rotation = Quaternion.Euler(0f, -45f, 0f);
        }
        
    }
}
