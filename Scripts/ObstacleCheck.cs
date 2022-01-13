using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCheck : MonoBehaviour
{
    private MeshRenderer obsRender, plyRender;
    private Material obsMat, plyMat;

    private GameObject player;
    private CharacterMovement movReference;
    void Start()
    {
        obsRender = GetComponent<MeshRenderer>();
        obsMat = obsRender.sharedMaterial;
    }


    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            player = collision.collider.gameObject;
            movReference = player.GetComponent<CharacterMovement>();
            plyRender = player.GetComponent<MeshRenderer>();
            plyMat = plyRender.sharedMaterial;
            if(plyMat == obsMat)
            {
                Debug.Log("hit successful.");
            }
            else if(plyMat != obsMat)
            {
                movReference.force = false;
                Debug.Log("you hit forbidden treasure!");
            }
        }
    }
}
