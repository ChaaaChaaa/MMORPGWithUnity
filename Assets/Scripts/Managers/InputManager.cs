using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;
    bool pressed = false;
    public void OnUpdate() //누군가가 불러줬을때 실행되도록
    {
        if (Input.anyKey && KeyAction != null)
        {
            KeyAction.Invoke();
        }

        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0)) //왼쪽
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                pressed = true; // 처음 마우스를 누를 경우
            }
            else //마우스 떼면
            {
                if (pressed) //마우스를 한번이라도 눌렀다면
                {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                    pressed = false;
                }
            }
        }
    }
}
