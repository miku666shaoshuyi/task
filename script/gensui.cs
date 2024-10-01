using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public Transform playertarget;
    public float movetime;
    private void LateUpdate()//��update��ִ��
    {
        if (playertarget!=null)
        {
            if (playertarget.position!=transform.position)  //transform�����ñ���Ҳ���������λ�ò���
            {
                //��������ڵ�λ���ƶ�����ɫλ�ã��ƶ��ٶȵļ��㹫ʽ��a+(b-a)*time
                transform.position = Vector3.Lerp(transform.position, playertarget.position+new Vector3(0.3f,-0.2f,0),movetime*Time.deltaTime);
            }
        }
    }
}
