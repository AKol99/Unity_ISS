using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{   
    [SerializeField]Transform target;
    [SerializeField]Vector3 defaultDistance = new Vector3(0f, 2f, -10f);
    [SerializeField] float distanceDamp = 10f;


    public Vector3 velocity = Vector3.one;

    Transform myT;
     
    // Start is called before the first frame update
    void Awake()
    {   
        myT = transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 currPos = Vector3.SmoothDamp(myT.position, toPos, ref velocity, distanceDamp);
        myT.position = currPos;

        myT.LookAt(target, target.up);
    }
}
