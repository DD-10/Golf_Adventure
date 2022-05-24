using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public Transform GolfBallTransform;
    public Transform PlayerTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 LineFromPlayerToBall = GolfBallTransform.position - PlayerTransform.position;

        
        LineFromPlayerToBall.y = 0.0f;

        
        LineFromPlayerToBall.Normalize();

       
        LineFromPlayerToBall *= 4.0f;

        
        transform.position = GolfBallTransform.position + LineFromPlayerToBall;

        float angle = Mathf.Atan2(LineFromPlayerToBall.z, LineFromPlayerToBall.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);

        
        transform.Rotate(new Vector3(90.0f, 180.0f, 0.0f));
    }
}
