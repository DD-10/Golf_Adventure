using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    
    private float MovementSpeed = 65.0f;
    public float Sensitivity = 2.0f;
    private bool isMoving = true;
    private Vector2 mouseAbsolute;
    private Animator animator;
    private Vector3 tempPos;
    public ball ballObject;

    private bool posCheck = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
      

        if (isMoving == false)
        {

           if(posCheck == false)
            {
                
               
                transform.position = tempPos;
                
                
                posCheck = true;
                ballObject.activateFunction();


            }

            

            Vector3 Forward = transform.forward;
            Forward.y = 0.0f;
            Forward.Normalize();
            Forward = Forward * Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;

            //Debug.Log(Input.GetAxis("Vertical"));

            Vector3 Right = transform.right * Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;

            transform.position += Forward + Right;

            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            mouseDelta *= Sensitivity;

            mouseAbsolute += mouseDelta;

            mouseAbsolute.y = Mathf.Clamp(mouseAbsolute.y, -89.9f, 89.9f);

            transform.localRotation = Quaternion.AngleAxis(-mouseAbsolute.y, Vector3.right);

            Quaternion yRotation = Quaternion.AngleAxis(mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
            transform.localRotation *= yRotation;

            RaycastHit hit;
           
            int layerMask = 1 << 9;
            
            
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 15.0f, layerMask))
            {
                

                Debug.DrawRay(transform.position, Vector3.down * 10, Color.yellow);

                transform.position = hit.point + new Vector3(0.0f, 7.0f, 0.0f);
            }

            
            





        }

    }


   

    public void animationEnded()
    {
        isMoving = false;
        tempPos = transform.position;


        Destroy(animator);
        

    }
}