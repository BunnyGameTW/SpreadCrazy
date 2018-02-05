using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public float Speed;
    Transform target;
    Vector3[] path;
    int targetIndex;
    int i;
    bool refindPath = false ;
    public Transform targets;
    AnimationState ani;
	void Start () {
        target = targets.GetChild(Random.Range(0, targets.childCount));     
        ani = GetComponent<AnimationState>();
        InvokeRepeating("FindPath", 1.0f, 1.0f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            FindPath();

        if (refindPath) {
            fpath();
        }
    }
    void FindPath() {
    //    if (ani.GetBoss()) ani.setBool("isWalk", true);

        float dst = Vector3.Distance(transform.position,target.position); //print(dst);
        PathRequestManager.RequsetPath(transform.position, target.position, OnPathFound);
        
         if (dst < 1.0f) {
            target = targets.GetChild(Random.Range(0, targets.childCount));

        }
    }

    public void StopPathing() {
        StopAllCoroutines();
       // ani.SetAniWalkSpeed(0, 0);
      // if(ani.GetBoss()) ani.setBool("isWalk", false);
    }
    public void OnPathFound(Vector3[] newpath, bool pathSuccessful)
    {
        if (pathSuccessful) 
        {
            if (newpath.Length > 0)
            {
                path = newpath;
             //   print("Start wtth" + path.Length);
                StopPathing();
                StartCoroutine(FollowPath());
            }
        }
    }

    IEnumerator FollowPath() {
       

        Vector3 currentWaypoint = path[0];
        targetIndex = 0;
        while (true) {
            if (transform.position == currentWaypoint) {
                targetIndex++;
                if (targetIndex >= path.Length) {
                  //  print("break" + targetIndex);
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            Debug.DrawLine(transform.position, currentWaypoint);
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, Speed * Time.deltaTime);
            Vector3 vec = currentWaypoint - transform.position;
            if (vec.x > vec.y) {
                if (vec.x > 0) ani.SetAniWalkSpeed(Speed, 0);
                else ani.SetAniWalkSpeed(-Speed, 0);
            }
            else {
                if (vec.y > 0) ani.SetAniWalkSpeed(0, Speed);
                else ani.SetAniWalkSpeed(0, -Speed);
            }                       
            yield return null;
        }
    }

    void fpath() {
        Vector3 currentWaypoint = path[targetIndex];

        if (transform.position == currentWaypoint)
        {
            targetIndex++;
            if (targetIndex >= path.Length)
            {
               // print("break" + targetIndex);
                refindPath = false;
                return;
            }
            currentWaypoint = path[targetIndex];
        }
        Debug.DrawLine(transform.position, currentWaypoint);
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, Speed * Time.deltaTime);  
        
    }

    private void OnDrawGizmos()
    {
        
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
      
    }
   
    }
