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
        enemy = GameObject.FindGameObjectWithTag("enemy");
    }

	void Update()
	{
        

		if (life <= 0)
		{
			anim.SetBool("Dead", true);
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Destroy(gameObject);
                dead = true;
            }
			//life = maxlife;  	
		}
        
              
	}

    void Spawn()
    {
        if (dead == true)
        {
            Debug.Log("is dead");
            Instantiate(enemy, pos, transform.rotation);
            
            dead = false;
        }
        
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
