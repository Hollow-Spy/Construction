using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public bool FollowBoth,Player1,Player2;
	

	public Transform target;
	public Transform player1Spine, player2Spine;
	[SerializeField] float distanceScale;
	 float bothdistance;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void FixedUpdate()
	{
		if(CheckpointManager.isPlayer1Alive && CheckpointManager.isPlayer2Alive)
        {
			if (!player1Spine)
			{
				var player = GameObject.Find("Player1");
				if (player != null)
				{

					player1Spine = GameObject.Find("Player1").GetComponentInChildren<PlayerController>().torso.transform;

				}

			}
			if (!player2Spine)
			{
				var player = GameObject.Find("Player2");
				if (player != null)
				{
					player2Spine = GameObject.Find("Player2").GetComponentInChildren<PlayerController>().torso.transform;

				}
			}

			Vector3 desiredPosition = Vector3.zero;
			if (FollowBoth && player1Spine && player2Spine)
			{
				bothdistance = Vector3.Distance(player1Spine.position, player2Spine.position) * distanceScale;
				desiredPosition = new Vector3((player1Spine.position.x + player2Spine.position.x) / 2, (player1Spine.position.y + player2Spine.position.y) / 2, bothdistance) + offset;


			}
			else
			{
				if (Player1)
				{
					desiredPosition = player1Spine.position + offset;
				}
				else
				{
					if (Player2)
					{
						desiredPosition = player2Spine.position + offset;


					}
					else
					{
						if (target)
						{
							desiredPosition = target.position + offset;

						}
					}
				}
			}





			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
			transform.position = smoothedPosition;
		}
		

		//transform.LookAt(target);


	}
		
	}

	

