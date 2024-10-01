using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Camera cam;
    private Vector3 mousepos;
    private Vector2 dir;
    private float flipY;
    private Animator animator;
    public GameObject bulletPrefab;
    private Transform muzzlePos;
    // Start is called before the first frame update
    void Start()
    {
        flipY = transform.localScale.y;
        muzzlePos = transform.Find("Muzzle");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);//����Ļ����ת����unity�ڵ���������
        dir = (mousepos - transform.position).normalized;
        /*  methed1:  float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;//����ǹ����ת�Ƕ�;rad2deg��deg2rad�ǽǻ�����ת���ĺ���
        transform.eulerAngles = new Vector3(0, 0, angle);*/
        transform.right = dir;
        //��ֹǹ��ת
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
            Fire();
        }
    }
 void Fire()
    {
        animator.SetTrigger("Shoot");
        GameObject Bullet = Instantiate(bulletPrefab, muzzlePos.position, Quaternion.identity);
        Bullet.GetComponent<Bullet>().SetSpeed(dir);
     }
}
