using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{

    [Header("Stored fluid values")]
    public int bvpMaxHp;
    public int bvpHp;
    public int bvpMaxFuel;
    public int bvpFuel;
    public int bvpMaxElectricity;
    public int bvpElectricity;


    [Header("Stored fixed values")]
    public float bvpCanonDmg;
    public float bvpSpeedMult;


    [Header("Input values")]
    public float bvpMoveVerticalInput;
    public float bvpMoveHorizontalInput;

    [Header("Status bools")]
    public bool bvpEngineStatus;
    public bool bvpElectricityStatus;
    public bool bvpLightsStatus;






}
