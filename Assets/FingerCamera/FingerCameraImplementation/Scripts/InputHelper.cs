using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputHelper
{
    public enum TouchNumber
    {
        First,Last
    }
    public static bool GetTouch(TouchNumber touchNumber,out Vector3 position,out Vector2 delta,out int inputCount)
    {
        delta = Vector2.zero;
        position = Vector3.zero;
        inputCount = 0;

        if (Input.touchCount > 0)
        {
            Touch touch = touchNumber == TouchNumber.First ? Input.touches.First() : Input.touches.Last();

            position = touch.position;                   
            delta = touch.deltaPosition;
            inputCount = Input.touchCount;
            return true;
        }
        else if(Input.GetMouseButton(0))
        {
            position = Input.mousePosition;                  //If on pc, lets simulate the mouse
            inputCount = 1;
            return false;
        }
        return false;
    }
    public static bool GetTouch(TouchNumber touchNumber, out Vector3 position)
    {
        return GetTouch(touchNumber, out position, out Vector2 delta, out int inputCount);
    }
        
}
