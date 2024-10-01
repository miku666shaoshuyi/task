using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public Transform playertarget;
    public float movetime;
    private void LateUpdate()//在update后执行
    {
        if (playertarget!=null)
        {
            if (playertarget.position!=transform.position)  //transform即调用本身也就是相机的位置参数
            {
                //从相机现在的位置移动到角色位置，移动速度的计算公式：a+(b-a)*time
                transform.position = Vector3.Lerp(transform.position, playertarget.position+new Vector3(0.3f,-0.2f,0),movetime*Time.deltaTime);
            }
        }
    }
}
