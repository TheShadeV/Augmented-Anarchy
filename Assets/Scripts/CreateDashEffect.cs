using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UIElements;

public class CreateDashEffect : MonoBehaviour
{
    private static GameObject dashEffect = Resources.Load<GameObject>("Prefabs/DashFX");

    public static void CreateEffect(Vector3 position, Vector3 direction, float dashSize)
    {

        GameObject dash = Instantiate(dashEffect, position ,Quaternion.LookRotation(direction));
        dashEffect.transform.localScale = new Vector3(dashSize, dashSize, dashSize);
        dashEffect.transform.rotation = Quaternion.LookRotation(direction);
        Destroy(dash, 0.3f);

    }
}
