using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ball : MonoBehaviour
{
    public Rigidbody RB;
    public float Force;
    public Transform PlayerTransform;
    public MeshRenderer ArrowMeshRenderer;
    private bool isOn = false;
    private bool isBlocked = false;
    public  Text ForceText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isOn == true)
        {
            if (isBlocked == false)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    
                    if (Force < 15000)
                    {
                        Force += Time.deltaTime * 5000.0f;
                        int tempForce = (int)Force / 500;
                        ForceText.text = "Force: " + tempForce.ToString();
                    }
                }

                if (Input.GetKeyUp(KeyCode.Space))
                {




                    Vector3 LineFromPlayerToBall = transform.position - PlayerTransform.position;
                    LineFromPlayerToBall.y = 0.0f;

                    LineFromPlayerToBall.Normalize();

                    RB.AddForce(LineFromPlayerToBall * Force);
                    
                    
                    score.IncrementScore(1);
                    Force = 0.0f;
                }
            }
           

            if (RB.IsSleeping())
                
            {
                isBlocked = false;
                ArrowMeshRenderer.enabled = true;
            }
            else
            {
                isBlocked = true;
                ArrowMeshRenderer.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "hole")
        {
            SceneManager.LoadScene("Lvl2");
        }
        if(collider.tag == "holelvl2")
        {
            SceneManager.LoadScene("Lvl3");
        }
        if(collider.tag == "holelvl3")
        {
            SceneManager.LoadScene("menu");
        }
    }

    public void activateFunction()
    {
        isOn = true;
    }
}
