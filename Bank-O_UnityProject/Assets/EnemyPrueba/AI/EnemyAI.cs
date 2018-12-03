using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    enum States
    {
        walk,
        die,
        damage
    }

    [HideInInspector]
    public string actualBeen;
    [HideInInspector]
    public string secondBeen;

    [System.Serializable]
    public class Stats
    {
        public float maxHealth;
        [HideInInspector]
        public float health;
        public float movementSpeed;
        public float chasingSpeed;
        public float damage;
    }

    public Stats stats = new Stats();
    public Image healthImage;
    public Canvas canvas;
    public NavMeshAgent agent;
    [HideInInspector]
    public GameObject player;
    public GameObject patrolPoint;
    public float fsfdf;
    public float visionRange;
    private bool isChasing;
    private bool isWaiting;
    private bool isGoingToPatroPoint;
    private float xPos;
    private float zPos;

    public float waitTime;
    private float currentTime;
    private Vector3 targetPos;
    private Vector3 patrolPointPos;

    private bool alive;

    // Use this for initialization
    void Start()
    {
        stats.health = stats.maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        isWaiting = true;
        alive = true;
        //setPatrolPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            RotateHealth();
            ShowUI();
            CheckDistance();



            if (player != null && isChasing)
            {
                if (agent)
                {
                    agent.SetDestination(player.transform.position);
                }
            }
            else if (player != null && !isChasing)
            {
                Waiting();
                Patrol();
                GoToTargetPoint();
                if (!patrolPoint.GetComponent<PatrolPoint>().isColliding)
                {
                    patrolPoint.transform.position = targetPos;
                }
            }
        }
        
        die();
    }

    private void Patrol()
    {
        if (transform.position.x == targetPos.x && transform.position.z == targetPos.z)
        {
            isWaiting = true;
            isGoingToPatroPoint = false;
            if (agent)
            {
                agent.isStopped = true;
            }
        }
        else
        {
            if (currentTime >= waitTime)
            {
                isWaiting = false;
                isGoingToPatroPoint = true;
            }
        }
    }
    private void Waiting()
    {

        if (isWaiting)
        {
            if (currentTime == 0)
            {
                setPatrolPoint();
            }
            if (currentTime < waitTime)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                isWaiting = false;
                currentTime = 0;
                agent.isStopped = false;
            }
        }
    }
    private void setPatrolPoint()
    {
        GenerateRandomPos();
        patrolPoint.transform.position = new Vector3(xPos, transform.position.y, zPos) + transform.position;
        patrolPointPos = patrolPoint.transform.position;
        if (patrolPoint.GetComponent<PatrolPoint>().isColliding)
        {
            GenerateRandomPos();
        }
        else
        {
            targetPos = new Vector3(xPos, transform.position.y, zPos) + transform.position;
        }
        isWaiting = true;
    }
    private void GenerateRandomPos()
    {
        xPos = Random.Range(-visionRange * 100, visionRange * 100);
        zPos = Random.Range(-visionRange * 100, visionRange * 100);
        xPos = xPos / 100;
        zPos = zPos / 100;
    }
    private void CheckDistance()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= visionRange)
        {
            if(Vector3.Distance(transform.position, player.transform.position) <= (visionRange / 3)*2)
            {
                secondBeen = States.damage.ToString();
            }
            if (agent)
            {
                agent.isStopped = false;
            }
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }
        if (visionRange == 0)
        {
            isChasing = true;
        }
    }
    private void GoToTargetPoint()
    {
        if (isGoingToPatroPoint)
        {
            actualBeen = States.walk.ToString();
            if (patrolPoint.GetComponent<PatrolPoint>().isColliding)
            {
                setPatrolPoint();
            }
            agent.isStopped = false;
            agent.SetDestination(targetPos);
        }
    }

    public void die()
    {
        
        if(stats.health <= 0)
        {
            alive = false;
            canvas.gameObject.SetActive(false);
            actualBeen = States.die.ToString();
        }
    }

    private void ShowUI()
    {
        healthImage.transform.localScale = new Vector3(stats.health / stats.maxHealth, 1, 1);
    }
    private void RotateHealth()
    {
        canvas.transform.LookAt(player.transform);
    }
    public void SetDamage(float damage)
    {
        stats.health -= damage;
    }

}
