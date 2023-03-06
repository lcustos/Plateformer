//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Pathfinding;
//
//public class Enemy : MonoBehaviour
//{
//
//    [Header("Stats")]
//    [SerializeField] float health ;
//    private float LastPlayerDetectTime; ;
//    public float playerDetectRate = 0.2f;
//    public float chaseRange;
//    bool lookRight;
//
//    [Header("Attack")]
//    [SerializeField] float attackRange;
//    [SerializeField] int damage;
//    [SerializeField] float attackRate;
//    private float lastAttackTime;
//
//    [Header("Components")]
//    Rigidbody2D rb;
//    private PlayerController targetPlayer;
//    Animator anim;
//
//    [Header("Pathfinding")]
//    public float nextWaypointDistance = 2f;
//    Path path;
//    int currentWaypoint = 0;
//    bool reachedEndOfPath = false;
//    Seeker seeker;
//
//
//
//    // Start is called before the first frame update
//    void Start()
//    {
//        seeker = GetComponent<Seeker>();
//        rb = GetComponent<Rigidbody2D>();
//        anim = GetComponent<Animator>();
//        InvokeRepeating("UpdatePath", 0f, .5f);
//    }
//
//    void OnPathComplete(Path p)
//    {
//        if (!p.error)
//        {
//            path = p;
//            currentWaypoint = 0;
//        }
//    }
//
//   void UpdatePath()
//    {
//        if (seeker.IsDone() && targetPlayer != null)
//        {
//            seeker.StartPath(rb.position, targetPlayer.transform.position, OnPathComplete);
//        }
//    }
//
//    private void FixedUpdate()
//    {
//        if (targetPlayer != null)
//        {
//            float distance = Vector2.Distance(transform.position, targetPlayer.transform.position);
//                    if(distance < attackRange && Time.time - lastAttackTime >= attackRate)
//                    {
//                        rb.velocity = Vector2.zero;
//                    }
//                    else if (distance > attackRange)
//                    {
//                        if (path == null)
//                            return;
//                        if (currentWaypoint >= path.vectorPath.Count)
//                        {
//                            reachedEndOfPath = true;
//                        }
//                        else
//                        {
//                            reachedEndOfPath = false;
//                        }
//                        Vector2 direction = ((Vector2))path.vectorPath[currentWaypoint] - rb.position).normalized;
//                        Vector2 force = direction * speed * Time.fixedDeltaTime;
//
//                        rb.velocity = force;
//
//                        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
//
//                        if (distance < nextWaypointDistance)
//                        {
//                            currentWaypoint++;
//                        }
//                    }
//                    else
//                    {
//                        rb.velocity = Vector2.zero;
//                    }
//        }
//        DetectPlayer();
//    }
//
//    private void DetectPlayer()
//    {
//        if (Time.time - LastPlayerDetectTime > playerDetectRate)
//        {
//            playerDetectTime = Time.time;
//
//            foreach (PlayerController player in FindObjectsOfType<PlayerController>())
//            {
//                if(player != null)
//                {
//                    float distance = Vector2.Distance(transform.position, player.transform.position);
//
//                    if (player == targetPlayer)
//                    {
//                        if (distance > chaseRange)
//                        {
//                            targetPlayer = null;
//                        }
//                    }
//                    else if (distance < chaseRange)
//                    {
//                        if (targetPlayer == null)
//                        {
//                            targetPlayer = player;
//                        }
//                    }
//                }
//            }
//    }
//
//
//    // Update is called once per frame
//        void Update()
//        {
//            if(rb.velocity.x >= 0 && lookRight || rb.velocity.x <= 0 && !lookRight)
//            {
//                Flip();
//            }
//
//        }
//
//    void FixedUpdate()
//    {
//        if (targetPlayer != null)
//        {
//            float distance = Vector2.Distance(transform.position, targetPlayer.transform.position);
//            if ( distance < attackRange && Time.time - lastAttackTime >= attackRate)
//            {
//                lastAttackTime = Time.time;
//                anim.SetTrigger("Attack");
//                rb.velocity = Vector2.zero;
//                Debug.Log("]'attack");
//            }
//            else if (distance > attackRange)
//            {
//                if (path == null)
//                    return;
//                if (currentWaypoint >= path.vectorPath.Count)
//                {
//                    reachedEndOfPath = true;
//                    return;
//                }
//                else
//                {
//                    reachedEndOfPath = false;
//                }
//                Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
//                Vector2 force = direction * speed * Time.deltaTime;
//                rb.AddForce(force);
//                float distanceToWaypoint = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
//                if (distanceToWaypoint < nextWaypointDistance)
//                {
//                    currentWaypoint++;
//                }
//            }
//        }
//        else
//        {
//            DetectPlayer();
//        }
//    }
//
//
//    void Flip()
//    {
//        lookRight = !lookRight;
//
//
//        transform.Rotate(0f, 180f, 0f);
//    }
//}
