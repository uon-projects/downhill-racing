using System;
using UnityEngine;

/// <summary>
///     <para> The vehicle controller </para>
///     <author> @TeodorHMX1 </author>
/// </summary>
[RequireComponent(typeof(VehicleCollision))]
public class VehicleController : MonoBehaviour
{
	public GameObject pivot;
	public Rigidbody rb;
	public float force = 200;
	private const float RotateSpeed = 90;
	private const float Speed = 160;
	private VehicleCollision _vehicleCollision;

	/// <summary>
	///     <para> Start - event function </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	private void Start()
	{
		_vehicleCollision = GetComponent<VehicleCollision>();
	}

	/// <summary>
	///     <para> FixedUpdate - event function </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	private void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.D))
		{
			if (!_vehicleCollision.IsGrounded)
			{
				StabilizeVehicle(Vector3.back);
			}
			else
			{
				MoveVehicle(1);
			}
		}
		else if (Input.GetKey(KeyCode.A))
		{
			if (!_vehicleCollision.IsGrounded)
			{
				StabilizeVehicle(Vector3.forward);
			}
			else
			{
				MoveVehicle(-1);
			}
		}
	}

	/// <summary>
	///     <para> Handles the rotation of the wheel </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	public void OnThrottle()
	{
		if (!_vehicleCollision.IsGrounded)
		{
			StabilizeVehicle(Vector3.forward);
		}
		else
		{
			MoveVehicle(1);
		}
	}

	/// <summary>
	///     <para> Handles the rotation of the wheel </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	public void OnBreak()
	{
		if (!_vehicleCollision.IsGrounded)
		{
			StabilizeVehicle(Vector3.back);
		}
		else
		{
			MoveVehicle(-1);
		}
	}

	/// <summary>
	///     <para> Handles the rotation of the wheel </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	/// <param name="rotateAxis"></param>
	private void StabilizeVehicle(Vector3 rotateAxis)
	{
		transform.RotateAround(pivot.transform.position, rotateAxis, RotateSpeed * Time.deltaTime);
	}

	/// <summary>
	///     <para> Moves the player vehicle forward or backwards </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	/// <param name="direction"></param>
	private void MoveVehicle(int direction)
	{
		rb.AddForce(direction * force * Speed * Time.smoothDeltaTime, 0, 0);
	}
	
}