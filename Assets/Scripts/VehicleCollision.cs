using UnityEngine;

/// <summary>
///     <para> Handles the collisions of the bike </para>
///     <author> @TeodorHMX1 </author>
/// </summary>
public class VehicleCollision : MonoBehaviour
{
	public bool IsGrounded { get; private set; }

	/// <summary>
	///     <para> When the player enter the collision </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	/// <param name="collision"></param>
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("floor")) IsGrounded = true;
	}

	/// <summary>
	///     <para> When the player exits the collision </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	/// <param name="collision"></param>
	private void OnCollisionExit(Collision collision)
	{
		if (collision.collider.CompareTag("floor")) IsGrounded = false;
	}
}