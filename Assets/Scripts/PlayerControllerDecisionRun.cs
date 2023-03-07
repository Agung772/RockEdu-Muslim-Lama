using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDecisionRun : MonoBehaviour
{
    public float speedPlayer;
    public float gravity;
    float directionY;
    public CharacterController characterController;
    public GroundCheck groundCheck;

    private void Update()
    {
        MovePLayer();
    }

    void MovePLayer()
    {
        float xInput = SimpleInput.GetAxis("Horizontal");

        Vector3 move = new Vector3(xInput, 0, 1);

        directionY += gravity * Time.deltaTime;
        move.y = directionY;
        if (groundCheck.ground) directionY = 0;

        characterController.Move(move * speedPlayer * Time.deltaTime);
    }
}
