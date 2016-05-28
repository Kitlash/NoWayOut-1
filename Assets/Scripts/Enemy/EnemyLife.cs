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

    private Animator anim;

	private bool touched = false;

	void Update()
	{
		if (life <= 0)
		{
			anim.SetBool("Dead", true);
			Destroy(gameObject);
			//life = maxlife;
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
}
