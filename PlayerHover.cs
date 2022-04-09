using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHover : MonoBehaviour
{
    public float MaxSpeed = 10f;
    public float DistanceFromGround = 2f;
    public float AngleSpeed = 15f;

    private Vector3 DeskUp = Vector3.zero;

    private void Update()
    {
        float Hor = Input.GetAxis("Horizontal");
        float Ver = Input.GetAxis("Vertical");

        Vector3 newPos = transform.position;
        newPos += transform.forward * Hor * MaxSpeed * Time.deltaTime;
        newPos += transform.right * Ver * MaxSpeed * Time.deltaTime;

        RaycastHit hit;

        if(Physics.Raycast(transform.position,Vector3.down,out hit))
        {
            newPos.y = (hit.point + Vector3.up * DistanceFromGround).y;
            DeskUp = hit.normal;
        }

        transform.position = newPos;
        transform.up = Vector3.Slerp(transform.up, DeskUp, AngleSpeed * Time.deltaTime);
    }
}
