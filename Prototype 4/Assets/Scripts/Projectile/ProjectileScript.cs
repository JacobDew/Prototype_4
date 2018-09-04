using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Vector3 m_vDirection = new Vector3(0.0f, 0.0f, 0.0f);

	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
		if (0.0f != m_vDirection.x || 0.0f != m_vDirection.z)
        {
            this.transform.position += m_vDirection * Time.deltaTime;
        }
	}

    public void SetDirection(Vector3 _Direction)
    {
        m_vDirection = _Direction;
    }
}
