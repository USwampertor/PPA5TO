using UnityEngine;
using System.Collections;

public class Mario : MonoBehaviour 
{
	Rigidbody2D rigi;
	public float Velocidad;
	public float FuerzaSalto;

	public Transform Pies;

	public Sprite spr_Idle;
	public Sprite spr_Jump;
	SpriteRenderer sprrender;

	bool IsVolteandoDerecha = true;



	void Start ()
	{
		rigi = gameObject.GetComponent<Rigidbody2D> ();
		sprrender = gameObject.GetComponent<SpriteRenderer> ();
	}

	void Update () 
	{
		Vector2 rigiVelocidad = rigi.velocity;

		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			if(Input.GetKey(KeyCode.LeftShift))
			{
				rigiVelocidad.x= Velocidad * 2f;
			}
			else
			{
				rigiVelocidad.x = Velocidad;
			}



			if(IsVolteandoDerecha == false)
			{
				//UNITY 5.3 gameObject.Getcomponent<SpriteRenderer>().flipX= false;
				transform.localScale = new Vector3(1f, 1f,1f);
				IsVolteandoDerecha = true;
			}
		}
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			if(Input.GetKey(KeyCode.LeftShift))
			{
				rigiVelocidad.x = -Velocidad * 2f;
			}
			else
			{
				rigiVelocidad.x = -Velocidad;
			}

			if(IsVolteandoDerecha == true)
			{
				//UNITY 5.3 gameObject.Getcomponent<SpriteRenderer>().flipX= true;
				transform.localScale = new Vector3(-1f, 1f,1f);
				IsVolteandoDerecha = false;
			}
		}
		if (Input.GetKeyUp (KeyCode.RightArrow)||Input.GetKeyUp (KeyCode.LeftArrow)) 
		{
			rigiVelocidad.x = 0f;
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			RaycastHit2D hit;
			hit = Physics2D.Raycast(Pies.position, Vector2.down, 0.3f);
			if(hit.collider != null)
			{
				rigiVelocidad.y = FuerzaSalto;
				sprrender.sprite = spr_Jump;
			}

							
		}


		rigi.velocity = rigiVelocidad;






	}

	void OnCollisionEnter2D(Collision2D _col)
	{

		if(_col.contacts[0].normal.y > 0f)
		{
			sprrender.sprite= spr_Idle;
		}
	}














































}
