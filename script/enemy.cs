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

    private bool cishu = true;//检测次数限制

    // Start is called before the first frame update
    public void Start()
    {
        EnemyAnim = GetComponent<Animator>();
        EnemyRB = GetComponent<Rigidbody2D>();
        HP = maxHP;
        target = GameObject.FindGameObjectWithTag("Player").transform;//从player标签中调取玩家位置

    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        EnemyDie();
    }

    
    void FollowPlayer()
    {
        if (cishu)
        {
            if (Mathf.Abs(transform.position.y - target.position.y) < followDistance & Mathf.Abs(transform.position.x - target.position.x) < followDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, enemyspeed * Time.deltaTime);
                if (transform.position.x - target.position.x > 0)//改变朝向
                    transform.eulerAngles = new Vector3(0, 180, 0);
                else
                    transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            EnemyAnim.SetTrigger("hit");
            HP -= 1;

        }
    }


    void EnemyDie()
    {
        if (HP <=0 & cishu)
        {
            EnemyAnim.SetTrigger("die");
            cishu = false;
            Destroy(gameObject,2f);//这里的数字是“延迟时间”，不延迟会导致动画来不及播就删除实体了
        }
    }
    

}
