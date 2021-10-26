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
		Vector3 desiredPosition = Vector3.zero;
		if (FollowBoth)
        {
			bothdistance = Vector3.Distance(player1Spine.position, player2Spine.position) * distanceScale;
			desiredPosition = new Vector3((player1Spine.position.x + player2Spine.position.x) / 2, (player1Spine.position.y + player2Spine.position.y) / 2, bothdistance) + offset;
			 

		}
		else
        {
			if (Player1)
			{

			}
            else
            {
				if (Player2)
				{

				}
                else
                {
					desiredPosition = target.position + offset;
				}
			}
		}





		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		//transform.LookAt(target);


	}
		
	}

	

