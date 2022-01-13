using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class CharacterMovement : MonoBehaviour
{
    [Range(0f,20f)]public float moveSpeed = 5f;
    public bool force = true;

    private Rigidbody rb;
    private LeanFinger fingerTouch;
    private Vector2 startingPos, touchPos;
    private Vector2 direction;
    private Vector3 fixedDirection;
    [HideInInspector] public List<LeanFinger> fingers = new List<LeanFinger>();
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        fingers = LeanTouch.Fingers;
        if(fingers.Count > 0 && force == true)
        {
            fingerTouch = fingers[0];

            if (fingers[0].Down)                    //started to touch
            {
                startingPos = fingers[0].ScreenPosition;
            }
            else if (fingers[0].Set)                //during the touch
            {
                touchPos = fingerTouch.ScreenPosition;
                direction = touchPos - startingPos;
                fixedDirection = new Vector3(direction.x, 0, direction.y);
                Movement();
            }
            else if (fingers[0].Up)                 //touch ended
            {

            }
        }
    }
    private void Movement()
    {
        transform.position = transform.position + (fixedDirection.normalized * moveSpeed * 0.05f);
    }
}
