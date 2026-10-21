using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SyncPhysicsObjects : MonoBehaviour
{
    Rigidbody rigidbody3D;
    ConfigurableJoint joint;

    [SerializeField]
    Rigidbody animatedRigidbody3D;

    [SerializeField]
    bool syncAnimation = false;

    //Keep track for starting rotation
    Quaternion startLocalRotation;

    void Awake()
    {
        rigidbody3D = GetComponent<Rigidbody>();
        joint = GetComponent<ConfigurableJoint>();

        //Store the starting local rotation
        startLocalRotation = transform.localRotation;
    }

    public void UpdateJointFromAnimation()
    {
        if (!syncAnimation)
            return;

        ConfigurableJointExtensions.SetTargetRotationLocal(joint, animatedRigidbody3D.transform.localRotation, startLocalRotation);

    }

    //Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
}
