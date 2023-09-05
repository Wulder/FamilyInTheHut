using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Player/Movement")]
public class PlayerMovementConfig : ScriptableObject
{
    [Header("Walking")]
    public float WalkSpeed;
    public float WalkRotationSpeed;

    [Header("Sprinting")]
    public float SprintSpeed;
    public float SprintRotationSpeed;

    [Header("Global")]
    public float GravityScale;
    public float ToCursorRotationSpeed;


  

}
