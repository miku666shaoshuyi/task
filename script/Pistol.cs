using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Camera cam;
    private Vector3 mousepos;
    private Vector2 dir;
 
    private Animator animator;
    public GameObject bulletPrefab;
    private float flipY;
    private Transform muzzlePos;//枪口位
    //射击相关参数
    public int bulletMax;
    public int bulletHave;
    private float timer;
    public float interval;//射击间隔
    // Start is called before the first frame update
    void Start()
    {
        flipY = transform.localScale.y;
        muzzlePos = transform.Find("Muzzle");
        animator = GetComponent<Animator>();
        bulletHave = bulletMax;
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);//将屏幕坐标转换成unity内的世界坐标
        dir = (mousepos - transform.position).normalized;
        /*  methed1:  float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;  
             计算枪口旋转角度;rad2deg与deg2rad是角弧互相转换的函数
             transform.eulerAngles = new Vector3(0, 0, angle);*/
        transform.right = dir;
        //防止枪反转
        if (transform.position.x > mousepos.x)
        {
            transform.localScale = new Vector3(flipY, -flipY,1);
        }
        else
        {
            transform.localScale = new Vector3(flipY, flipY, 1);
        }
        Shoot();
    }
    void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            if (timer != 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                    timer = 0;
            }
            
            if (timer == 0 && bulletHave>0)
            {
                Fire();
                timer = interval;
                bulletHave -= 1;
            }
        }
    }
 void Fire()
    {
        animator.SetTrigger("Shoot");
        GameObject Bullet = Instantiate(bulletPrefab, muzzlePos.position, Quaternion.identity);
        Bullet.GetComponent<Bullet>().SetSpeed(dir);
     }
}
