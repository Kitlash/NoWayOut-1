using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour 
{

	[SerializeField]
	float life = 100f;

	[SerializeField]
	float maxlife = 100f;

	[SerializeField]
	float interval;

    public float timer = 5f;

    private Animator anim;
    private bool dead = false;
    public Vector3 pos;
    private GameObject enemy;

	private bool touched = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        pos = gameObject.transform.position;
    }

	void Update()
	{
        if (life <= 0)
        {
            timer -= Time.deltaTime;
            anim.SetBool("Dead", true);

            if (timer <= 0)
            {               
                Die();
            }   
        }            
	}

    void Die()
    {
        transform.position = pos;
        transform.rotation = Quaternion.identity;
        timer = 5f;
        life = maxlife;
    }


	void OnDamage(float dmg)
	{
		if (touched)
		{
			life -= dmg;
		}
		touched = false;
	}
		
	public bool Touched
	{
		get { return touched; }
		set { touched = value; }
	}

	public float Life
	{
		get { return life; }
	}
}
