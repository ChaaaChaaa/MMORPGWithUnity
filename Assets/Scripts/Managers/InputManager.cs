using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;
    bool pressed = false;
    public void OnUpdate() //�������� �ҷ������� ����ǵ���
    {
        if (Input.anyKey && KeyAction != null)
        {
            KeyAction.Invoke();
        }

        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0)) //����
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                pressed = true; // ó�� ���콺�� ���� ���
            }
            else //���콺 ����
            {
                if (pressed) //���콺�� �ѹ��̶� �����ٸ�
                {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                    pressed = false;
                }
            }
        }
    }
}
