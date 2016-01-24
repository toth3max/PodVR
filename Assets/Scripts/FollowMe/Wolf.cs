using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wolf : MonoBehaviour
{
    public float LethalRange;
    public float PreyRange;

    public float StrollSpeed;
    public float AttackSpeed;

    public bool HasTarget;

    public Vector3 StrollTarget;
    public Follower AttackTarget;

    public float MaxAttackLength;
    private float CurrentAttachLength;

    private Rigidbody RigidBody;

    private Follower[] Followers;

	// Use this for initialization
	void Start ()
    {
        RigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Followers == null) {
            GetFollowers();
        }

        if (AttackTarget != null) {

            CurrentAttachLength -= Time.deltaTime;
            if (CurrentAttachLength <= 0) {
                AquireNewTarget();
            }else{
                var distance = Vector3.Distance(AttackTarget.transform.position, transform.position);
                if (distance <= LethalRange) {
                    AttackTarget.Kill();
                    AttackTarget = null;
                } else {
                    var direction = (AttackTarget.transform.position - transform.position).normalized;
                    RigidBody.MovePosition(transform.position + direction * AttackSpeed * Time.deltaTime);
                    transform.rotation = Quaternion.LookRotation(direction);
                }
            }
        } else {
            var closestTarget = FindClosesTarget();
            if (closestTarget != null) {
                var range = Vector3.Distance(closestTarget.transform.position, transform.position);
                if (range <= PreyRange) {
                    closestTarget.IsAttacked(transform.position);
                    AttackTarget = closestTarget;
                }
            }
        }
	}

    public void AquireNewTarget( )
    {
        var closestTarget = FindClosesTarget();
        if (closestTarget != null) {
            var range = Vector3.Distance(closestTarget.transform.position, transform.position);
            if (range <= PreyRange) {
                closestTarget.IsAttacked(transform.position);
                AttackTarget = closestTarget;
                CurrentAttachLength = MaxAttackLength;
            }
        }
    }

    public void GetFollowers()
    {
        Followers = GameObject.FindObjectsOfType<Follower>();
    }

    public Follower FindClosesTarget()
    {
        Follower result = null;
        var closestDistance = float.MaxValue;

        foreach (var follower in Followers) {
            if (follower != null) {
                var distance = Vector3.Distance(transform.position, follower.transform.position);
                if (result == null) {
                    closestDistance = distance;
                    result = follower;
                } else {
                    if (distance < closestDistance) {
                        result = follower;
                        closestDistance = distance;
                    }
                }
            }
        }

        return result;
    }
}
