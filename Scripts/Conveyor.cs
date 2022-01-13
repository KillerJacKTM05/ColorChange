using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [Range(0f, 20f)] public float ConveyorSpeed = 5f;
    public GameObject Player;

    private CharacterMovement movReference;

    private void Start()
    {
        movReference = Player.GetComponent<CharacterMovement>();
    }
    private void Update()
    {
        if (movReference.force)
        {
            MoveEverything();
        }
    }
    private void MoveEverything()
    {
        transform.position = transform.position + (Vector3.back * ConveyorSpeed * 0.01f);
    }
}
