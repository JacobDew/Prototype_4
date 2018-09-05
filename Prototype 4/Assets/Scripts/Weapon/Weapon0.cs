using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon0 : MonoBehaviour
{
    private GameObject m_pPlayer;
    private int m_iWeaponType = 0;


	// Use this for initialization
	void Start()
    {
        m_pPlayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update()
    {
		if (2.0f > Vector3.Distance(this.transform.position, m_pPlayer.transform.position))
        {
            m_pPlayer.GetComponent<Player>().SetWeapon(m_iWeaponType);
            GameObject Temp = Resources.Load<GameObject>("X");
            Vector3 vTemp = this.transform.position;
            short sX = 0;
            while (6 > sX)
            {
                GameObject Temp2 = Instantiate(Temp);
                Temp2.transform.position = this.transform.position + new Vector3(Random.Range(-0.3f, 0.3f), -1.0f, Random.Range(-0.3f, 0.3f));
                Temp2.transform.Rotate(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
                sX++;
            }
            Destroy(this.gameObject);
        }
	}

    public void Initialize(int _Weapon)
    {
        m_iWeaponType = _Weapon;
    }
}
