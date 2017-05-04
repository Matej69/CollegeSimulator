using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterStatus))]
public class SelfController : AController {

    Rigidbody2D rigid;

    public class PathInfo
    {
        public enum E_PATH_DIR
        {
            TO_BUILDING,
            TO_CROSS
        }
        public E_PATH_DIR curDir;
        public Transform targetPoint = null;
        public int curIndex = 0;
        public Pathways.Pathway curPathway;
    }
    PathInfo pathInfo;

    float radius = 0.2f;

    private float movementSpeed = 30;
    

    void Awake()
    {
        characterStats = GetComponent<CharacterStatus>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        pathInfo = new PathInfo();
        SetRandomPath();
        SetRandomSpeed();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (characterStats.controlType == E_CHAR_CONTROLER.SELF_CONTROL)
            HandleMovement();
    }




    override public void HandleMovement()
    {
        //turn sprite depending on rigid.velocity
        if (rigid.velocity.x > 0)
            Rotate(E_SIDE.RIGHT);
        else
            Rotate(E_SIDE.LEFT);

        if (pathInfo.targetPoint != null)
        {
            Vector2 dir = (pathInfo.targetPoint.position - transform.position).normalized;
            rigid.velocity = dir * movementSpeed * Time.deltaTime;
            //if reached set new target point
            if (IsTargetPointReached())
            {
                SetNextTarget();
            }
        }
    }
    
    private bool IsTargetPointReached()
    {
        if (Vector2.Distance(transform.position, pathInfo.targetPoint.position) < radius)
            return true;
        return false;
    }

    private void SetNextTarget()
    {
        if(pathInfo.curDir == PathInfo.E_PATH_DIR.TO_BUILDING)
        {
            //if building point is target point
            if (pathInfo.targetPoint == pathInfo.curPathway.IsEntrance(pathInfo.targetPoint))
            {
                pathInfo.curDir = PathInfo.E_PATH_DIR.TO_CROSS;
                pathInfo.curIndex = --pathInfo.curIndex;
                pathInfo.targetPoint = pathInfo.curPathway.path[pathInfo.curIndex];                
            }                                
            else
            {
                pathInfo.curIndex++;
                pathInfo.targetPoint = pathInfo.curPathway.path[pathInfo.curIndex];
            }
        }
        else if(pathInfo.curDir == PathInfo.E_PATH_DIR.TO_CROSS)
        {
            //pick new pathway route
            if (pathInfo.curDir == PathInfo.E_PATH_DIR.TO_CROSS && pathInfo.curPathway.IsCross(pathInfo.targetPoint))
            {
                SetRandomPath();
            }            
            else
            {
                pathInfo.curIndex--;
                pathInfo.targetPoint = pathInfo.curPathway.path[pathInfo.curIndex];
            }

        }
    }


    private void SetRandomSpeed()
    {
        movementSpeed = Random.Range(65f, 120f);
        if (movementSpeed < 100f)
            characterStats.SetActionState(CharacterInfo.E_CHAR_ACTION.WALKING);
        else
            characterStats.SetActionState(CharacterInfo.E_CHAR_ACTION.RUNNING);
    }

    private void SetRandomPath()
    {
        pathInfo.curPathway = Pathways.instance.pathways[Random.Range(0, (int)Pathways.Pathway.E_ID.SIZE)];
        pathInfo.curIndex = 0;
        pathInfo.targetPoint = pathInfo.curPathway.cross;
        pathInfo.curDir = PathInfo.E_PATH_DIR.TO_BUILDING;
    }








}
