using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	
    private GameObject m_Player;
    private GameObject[] m_Followers;

    private float m_fDistance;
    private Vector3 m_vTarget;
    private Vector3 m_vForward;
    private System.Random m_rRandom;
    private float m_fDelay;
    private bool m_bArraySet;

    private float m_fSpeed;

    private const float c_fMaxSpeed = 5.0f;
    private const float c_fForce = 0.15f;


    // Use this for initialization
    void Start()
    {
        m_fSpeed = 0.0f;
        m_bArraySet = false;
        m_fDelay = 0.0f;
        m_vForward = new Vector3(1.0f, 0.0f, 0.0f);
        m_Player = GameObject.FindGameObjectsWithTag("Player")[0];
        m_rRandom = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        m_vTarget = m_Player.transform.position - this.transform.position;
        m_fDistance = Vector3.Magnitude(m_vTarget);
        if (20.0f > m_fDistance)
        {
            m_fSpeed = c_fMaxSpeed;
        }
        else
        {
            m_fSpeed = c_fMaxSpeed;
        }
        m_vForward += ((Vector3.Normalize(m_vTarget - m_vForward) * c_fMaxSpeed) - m_vForward) * c_fForce;
        Vector3 Temp = ((m_vForward * m_fSpeed) * Time.deltaTime);
        this.transform.Translate(Temp.x, 0.0f, Temp.z);
        m_vTarget -= Temp;


        if (false == m_bArraySet)
        {
            m_fDelay += Time.deltaTime;
            if (1.0f < m_fDelay && false == m_bArraySet)
            {
                m_Followers = GameObject.FindGameObjectsWithTag("Follower");
                m_bArraySet = true;
            }
        }
        else
        {
            for (short sX = 0; sX < m_Followers.Length; sX++)
            {
                if (this != m_Followers[sX])
                {
                    Vector3 TempVec = this.transform.position - m_Followers[sX].transform.position;
                    if (3.0f > Vector3.Magnitude(TempVec))
                    {
                        Steer(TempVec, c_fForce);
                    }
                }
            }
        }
	}

    void Steer(Vector3 _Direction, float _Force)
    {
	    m_vForward += ((Vector3.Normalize(_Direction - m_vForward) * c_fMaxSpeed) - m_vForward) * _Force;
    }
}
