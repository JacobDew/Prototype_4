using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private GameObject m_Player;

    private Vector3 m_vForward;
    private Vector3 m_vPlanePoint;
    private Vector3 m_vPlaneNormal;


    private float m_fFireDelay;
    private float m_fLastShot;

    private short m_sWeapon;

    //  0: Semi-Auto.
    //  1: Full-Auto.
    private short m_sFireType;


	// Use this for initialization
	void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        //  Add Plane Point.
        m_vPlaneNormal = new Vector3(0.0f, 1.0f, 0.0f);
        m_vForward = new Vector3(0.0f, 0.0f, 1.0f);
        m_fFireDelay = 0.2f;
        m_fLastShot = 0.0f;
        m_sWeapon = 0;
        m_sFireType = 0;
    }
	
	// Update is called once per frame
	void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        
        if (Input.GetMouseButton(0))
		{
			Debug.Log("Pressed left click.");
            if (0.0f > m_fLastShot)
            {
                Debug.Log(m_fLastShot);
                m_fLastShot = m_fFireDelay;
                RaycastHit HitPos;
                if (Physics.Raycast(ray, out HitPos))
                {
                    Debug.Log("Raycast");
                    if (null != HitPos.point)
                    {
                        Debug.Log("Hit!");
                        GameObject TempObject = Instantiate(Resources.Load<GameObject>("Cube"), m_Player.transform.position, transform.rotation);
                        TempObject.GetComponent<ProjectileScript>().SetDirection(Vector3.Normalize(new Vector3(HitPos.point.x - m_Player.transform.position.x,
                            0.0f, HitPos.point.z - m_Player.transform.position.z)));
                    }
                }
            }
        }

		if (Input.GetMouseButton(1)) {
			Debug.Log("Pressed right click.");
		}

		if (Input.GetMouseButton(2))
		{
			Debug.Log("Pressed middle click.");
		}
        m_fLastShot -= Time.deltaTime;
    }
}