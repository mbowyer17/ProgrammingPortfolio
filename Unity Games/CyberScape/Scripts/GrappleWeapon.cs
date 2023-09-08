//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrappleWeapon : MonoBehaviour
{
    [SerializeField] GameObject grappleObject;
    [SerializeField] GameObject playerObject;
    [SerializeField] const float grappleRange = 30;
    [SerializeField] PlayerInventory inventory;
    [SerializeField] Transform grappleSpawnPosition;
    [SerializeField] Vector3 TargetPoint;
    [SerializeField] GameObject camObject;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject grappleHookPoint;
    [SerializeField] LineRenderer line;
    [SerializeField] float coolDownTimer;
    [SerializeField] float lineTimer = 1f;
    [SerializeField] LayerMask grappleLayer;
    [SerializeField] AudioSource gunaudio;
    RaycastHit raycastHit;
    SpringJoint spring;
    private float grappleHookSize;
 
    private bool resetColor;

    private void Start()
    {
        spring = GetComponent<SpringJoint>();
        line.enabled = false;
    }
    private void Update()
    {
        DrawGrappleHook(raycastHit.point);
        if (resetColor)
        {
            lineTimer -= Time.deltaTime;
           
            if(lineTimer <= 0f)
            {
                line.enabled = false;
                resetColor = false;
                lineTimer = 1f;
            }
        }
        coolDownTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && coolDownTimer <= 0)
        {
            GrappleFired();
            resetColor = true;
            coolDownTimer = 2f;
            gunaudio.Play();

        }
        
        }
    private void LateUpdate()
    {
        DrawGrappleHook(raycastHit.point);
    }


    void GrappleFired()
    {
        line.enabled = true;
        Ray viewpoint = camObject.transform.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));

        if (Physics.Raycast(viewpoint, out raycastHit, grappleRange, grappleLayer))
        {
            TargetPoint = raycastHit.point;
            spring = playerObject.AddComponent<SpringJoint>();
            spring.autoConfigureConnectedAnchor = false;
            spring.connectedAnchor = TargetPoint;
            spring.spring = 100f;
            spring.damper = 7f;
            spring.massScale = 2f;
            Destroy(playerObject.GetComponent<SpringJoint>(), 1f);
            GameObject steve = Instantiate(grappleObject, raycastHit.point, Quaternion.identity);
            Destroy(steve, 1f);
            DrawGrappleHook(raycastHit.point);
        }
    }

    private void DrawGrappleHook(Vector3 point)
    {
        if (!spring)
        {
            return;
        }
        line.SetPosition(0, grappleHookPoint.transform.position);
        line.SetPosition(1, point);
       /* grappleHook.transform.LookAt(point);
        float grappleHookSpeed = 5f;
        grappleHookSize += grappleHookSpeed * Time.deltaTime;
        //grappleHook.transform.localScale = new Vector3(0.6f, 0.6f, grappleHookSize);
        grappleHook.transform.position = new Vector3(point.x, point.y, point.z) ;
        */
    }

    public float GetCooldown()
    {
        return coolDownTimer;
    }
}
