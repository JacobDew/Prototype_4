using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Vector3 m_vDirection = new Vector3(0.0f, 0.0f, 0.0f);

    private float Speed;

	// Use this for initialization
	void Awake()
    {
        //Speed of Laser Bullet
        Speed = 20f;

    }
	
	// Update is called once per frame
	void Update()
    {
		if (0.0f != m_vDirection.x || 0.0f != m_vDirection.z)
        {
            this.transform.position += m_vDirection * Time.deltaTime * Speed;
        }
	}

    //Collision with Enemey
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Follower")
        {
            Destroy(gameObject);
        }

    }

    public void SetDirection(Vector3 _Direction)
    {
        m_vDirection = _Direction;
    }

    //When Projectile goes offscreen it deletes itself
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
