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

	private SkinnedMeshRenderer[] visibleMesh;

	NavMeshAgent nav;

	private bool touched = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        pos = gameObject.transform.position;
		visibleMesh = GetComponentsInChildren<SkinnedMeshRenderer> ();
		nav = GetComponent<NavMeshAgent> ();
    }

	void Update()
	{
        if (life <= 0)
        {
            //timer -= Time.deltaTime;
            anim.SetBool("Dead", true);

            //if (timer <= 0)
            //{               
                Die();
            //}   
        }            
	}

    void Die()
    {
		foreach (var grap in visibleMesh) {
			grap.enabled = false;
		}
		nav.enabled = false;
		StartCoroutine (RespTimer ());
    }

	IEnumerator RespTimer(){
		yield return new WaitForSeconds (3f);
		Respawn ();
	}

	void Respawn()
	{
		foreach (var graph in visibleMesh) {
			graph.enabled = true;
		}

		transform.position = pos;
		transform.rotation = Quaternion.identity;
		timer = 5f;
		life = maxlife;
		nav.enabled = true;
		anim.StartPlayback ();
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
