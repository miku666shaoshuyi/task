using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    
    }
    void PlayerMove()
    {
        float movex = Input.GetAxis("Horizontal");
        float movey = Input.GetAxis("Vertical");
        //创建二维向量来计算移动方向(normalized是将向量设为单位向量)
        Vector2 movedir = new Vector2(movex, movey).normalized;
        //刚体速度=方向*移动速度
        rb.velocity = movedir * moveSpeed;
        //改变动画的run的值，使得可以通过run的变化来刻画从idle到run的变化
        //注意：1、要*movex即输入值，不能只有速度值；2、由于输入值有正负，因此最好这里用加绝对值来解决这个问题
        playerAnim.SetFloat("run", Mathf.Abs(moveSpeed*movex));
        //改变朝向
        float faceNum = Input.GetAxisRaw("Horizontal")*3;//有raw是【-1，0，1】变化，无则是连续的变化
        if (faceNum != 0)
        {
            //小写的t代表最直接调用角色本身的组件;scale本身因为有三个方向，因而要三维向量
            transform.localScale = new Vector3(faceNum, transform.localScale.y,transform.localScale.z);
        }
    }
}
