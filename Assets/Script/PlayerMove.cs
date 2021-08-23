using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float xAxis;
    float zAxis;
    Vector3 moveVec;

    Rigidbody rigid;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float jumpForce;

    public bool isControl = false;
    public bool isEnd = true;
    public bool isCount = false;
    public int hits;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        StartJump();
    }

    void Update()
    { 
        GetInput();
        Move();
        Jump();
        Turn();
    }

    void GetInput()
    {
        zAxis = Input.GetAxis("Vertical");
        xAxis = Input.GetAxis("Horizontal");

    }

    
    void Move()
    {
        if (isControl)
        {
            moveVec = new Vector3(xAxis, 0, zAxis).normalized;
            transform.position += moveVec * Time.deltaTime * moveSpeed;
        }
    }

    void Turn() 
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Jump() 
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void StartJump() 
    {
        rigid.AddForce(0, 5, 0, ForceMode.Impulse);
        StartCoroutine(IsControl());
    }

    IEnumerator IsControl()
    {
        yield return new WaitForSeconds (1f);
        isControl = true;
        isCount = true;

    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag) 
        {
            case "Wall":
                if (isCount == true)
                    hits ++;
                break;
            case "EndPoint":
                isEnd = true;
                break;
        }
            
    }

}
