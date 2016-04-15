using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
    public int dyingState;
    public int locomotionState;
    public int deadBool;
    public int speedFloat;
    public int playerInSightBool;
    public int shotFloat;
    public int aimWeightFloat;
    public int angularSpeedFloat;
    public int openBool;

    // Use this for initialization
    void Start()
    {
        dyingState = Animator.StringToHash("Base Layer.Dying");
        locomotionState = Animator.StringToHash("Base Layer.Locomotion");
        deadBool = Animator.StringToHash("Dead");
        speedFloat = Animator.StringToHash("Speed");
        playerInSightBool = Animator.StringToHash("PlayerInSight");
        shotFloat = Animator.StringToHash("Shot");
        aimWeightFloat = Animator.StringToHash("Aimweight");
        angularSpeedFloat = Animator.StringToHash("AbgularSpeed");
        openBool = Animator.StringToHash("Open");
    }


}
