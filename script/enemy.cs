using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform target;
    
    //怪的基本设置
    public float HP;
    public float maxHP;
    public float enemyspeed;
    //怪的ai反应
    public float followDistance;
    public AnimatorStateInfo info;
    public Vector2 direction;//获取方向（不理解）
    //状态
    public bool isHit;


    public Animator EnemyAnim;
    public Rigidbody2D EnemyRB;
    // Start is called before the first frame update
    void Start()
    {
        EnemyAnim = GetComponent<Animator>();
        EnemyRB=GetComponent<Rigidbody2D>();
        HP = maxHP;
        target = GameObject.FindGameObjectWithTag("Player").transform;//从player标签中调取玩家位置

    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        EnemyDie();
    }

    private void FixedUpdate()
    {
        Enemyhit();
    }
    void FollowPlayer()
    {
        if (Mathf.Abs(transform.position.x-target.position.x)<followDistance )
        {
            if(Mathf.Abs(transform.position.y - target.position.y) < followDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, enemyspeed * Time.deltaTime);
                if (transform.position.x - target.position.x > 0)//改变朝向
                    transform.eulerAngles = new Vector3(0, 180, 0);
                else
                    transform.eulerAngles = new Vector3(0, 0, 0);
            } 
        }
    }


    //受击
    void Enemyhit()//难懂部分
    {
        info = EnemyAnim.GetCurrentAnimatorStateInfo(0);//读取动画信息
        if (isHit)
        {
            enemyspeed = 0;
            EnemyRB.velocity = -direction * enemyspeed;//受击后退(or 僵直)？
            if (info.normalizedTime >= .6f)//这里的数字：整数代表循环次数；小数代表动画进度
            {
                isHit = false;
                enemyspeed = 1;
            }
        }
    }
    public void GetEnemyHit(Vector2 direction)
    {
        if (!isHit)
        {
            transform.localScale = new Vector3(direction.x, 1, 1);
            isHit = true;
            this.direction = -direction;
            HP -= 20;
            EnemyAnim.SetTrigger("hit");//设置动画状态
        }
    }
    void EnemyDie()
    {
        if (HP <= 0)
        {
            EnemyAnim.SetTrigger("die");
            Destroy(gameObject);
        }
    }
    


}
