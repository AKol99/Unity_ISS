using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upravljanje_rakete : MonoBehaviour
{

    public float speed = 500;
    private bool isMoving = false;
    public Rigidbody rb;

    public float rotationSpeed = 10f;
    public float moveSpeed = 10f;
    private bool isRotating = false;

    private Vector3 direction;

    public Camera kamera;

    public GameObject cilj;
    private bool pratiCilj = false;

    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    

    void Update()
    {
        direction = kamera.transform.forward;

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!pratiCilj)
                StartCoroutine(PratiCiljCor());
        }
        
        if (Input.GetKeyUp(KeyCode.T))
        {
            pratiCilj = false;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            

            if (!isMoving)
            {
                //rb.velocity = new Vector3(0f, 0f, speed);
                rb.velocity = direction * speed;
                isMoving = true;
            }
            else
            {
                rb.velocity = Vector3.zero;
                isMoving = false;
            }
        } 

        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isRotating)
                StartCoroutine(RotateObject1());
        }
        
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isRotating = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!isRotating)
                StartCoroutine(RotateObject2());
        }
        
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isRotating = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!isRotating)
                StartCoroutine(RotateObject3());
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isRotating = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!isRotating)
                StartCoroutine(RotateObject4());
        }
        
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isRotating = false;
        }

        

        //gore = left
        //dole = right
        //lijevo = forward
        //desno = back
        //transform.Rotate(Vector3.forward * rotationSpeed * 1 * Time.deltaTime); 
        /*
        transform.Translate(0f, 0f, moveSpeed*Input.GetAxis("Vertical") * Time.deltaTime);
        */

    }

    private IEnumerator RotateObject1()
        {
            isRotating = true;
            while (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
                yield return null;
            }
            isRotating = false;
        }
    private IEnumerator RotateObject2()
        {
            isRotating = true;
            while (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
                yield return null;
            }
            isRotating = false;
        }
    private IEnumerator RotateObject3()
        {
            isRotating = true;
            while (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                yield return null;
            }
            isRotating = false;
        }
    private IEnumerator RotateObject4()
        {
            isRotating = true;
            while (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
                yield return null;
            }
            isRotating = false;
        }

    private IEnumerator PratiCiljCor()
        {
            pratiCilj = true;
            while(Input.GetKey(KeyCode.T))
            {
                transform.position = Vector3.MoveTowards(transform.position, cilj.transform.position, speed*Time.deltaTime);
                transform.up = cilj.transform.position - transform.position;
                yield return null;
            }
            pratiCilj = false;
        }
}
