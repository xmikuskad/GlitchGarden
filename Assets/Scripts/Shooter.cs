using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";


    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
        CreateProjectileParent();
    }

    public void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= (0.25 + Mathf.Epsilon));
            if(isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        return true;
    }

    public void Fire()
    {
       GameObject projectile = Instantiate(projectilePrefab, gun.transform.position, Quaternion.identity) as GameObject;
        projectile.transform.parent = projectileParent.transform;
    }

}
