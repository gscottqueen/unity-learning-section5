using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [Header("Movemtne Parameters")]
    public Vector3 movementAxis;
    public float movementSpeed;
    public float movmentDistance;

    [Header("Movement Positions")]
    public Vector3 startingPosition;
    public Vector3 posEnd;
    public Vector3 negEnd;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        // precompute start, posEnd, negEnd, direction
        // The direction of movment
        direction = movementAxis.normalized;

        // Precompute positions
        startingPosition = transform.position;
        posEnd = transform.position + (direction * movmentDistance);
        negEnd = transform.position - (direction * movmentDistance);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if we reach the bounds of the movement, reverse the direction of vector
        if (
            Vector3.Distance(transform.position, posEnd) < 0.01f || 
            Vector3.Distance(transform.position, negEnd) < 0.01f
            )
        direction *= -1;
        // move the platform
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }
}
