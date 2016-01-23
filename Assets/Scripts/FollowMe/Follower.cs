using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour
{
    private Rigidbody RigidBody;
    public Vector3 TargetPosition;

    public bool HasSetPosition;
    public float LooseInterestTimer;
    public float LooseInterestDistance;
    public float MovementSpeed = 0.2f;
    public Vector2 RandomDistance = new Vector2(0.1f, 0.5f);

    public Vector2 RandomSoundEffectTimer;

    private AudioSource audioSource;
    private float CurrentInterestTimer;
    private System.Random RandomGenerator;
    private float TimeTilNextSoundEffect;

	// Use this for initialization
	void Start ()
    {
        RandomGenerator = new System.Random(GetHashCode());
        TimeTilNextSoundEffect = RandomFloat(RandomSoundEffectTimer);

        SetTarget(transform.position);
        RigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if ((TargetPosition - transform.position).sqrMagnitude < 0.01f) {
            HasSetPosition = false;
        }

        if (!HasSetPosition) {
            CurrentInterestTimer -= Time.deltaTime;

            if (CurrentInterestTimer <= 0) {
                SetTarget(GenerateNewRandomTarget());
            }
        } else {
            var direction = (TargetPosition - transform.position).normalized;
            RigidBody.MovePosition(transform.position + direction * MovementSpeed * Time.deltaTime);
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);

        }

        TimeTilNextSoundEffect -= Time.deltaTime;
        if (TimeTilNextSoundEffect <= 0) {
            TimeTilNextSoundEffect = RandomFloat(RandomSoundEffectTimer);
            Debug.Log(TimeTilNextSoundEffect);
            audioSource.PlayOneShot(audioSource.clip);
        }
	}


    public float RandomFloat(Vector2 values)
    {
        var result = RandomGenerator.NextDouble() * (values.y - values.x);
        result += values.x;
        return (float)result;
    }

    public Vector3 GenerateNewRandomTarget()
    {
        float randomAngle = (float)Random.Range(0, 360) * Mathf.Deg2Rad;
        var randomDirection = new Vector3(Mathf.Sin(randomAngle), 0, Mathf.Cos(randomAngle));
        var result = transform.position + randomDirection * RandomFloat(RandomDistance);
        return result;
    }

    public void SetPlayerTarget(Vector3 position)
    {
        if ((position - transform.position).magnitude < LooseInterestDistance) {
            SetTarget(position);
        }
    }

    public void SetTarget(Vector3 position)
    {
        TargetPosition = position;
        HasSetPosition = true;
        CurrentInterestTimer = LooseInterestTimer;
    }
}
