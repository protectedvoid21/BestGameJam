using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInput
{
    public static Vector3 GetWorldPointerPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }

        return Vector3.negativeInfinity;
    }
}
