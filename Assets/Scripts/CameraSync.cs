using UnityEngine;

/// <summary>
///     <para> Script that makes the camera to follow the player </para>
///     <author> @TeodorHMX1 </author>
/// </summary>
public class CameraSync : MonoBehaviour
{

	#region Public Variables

	/// <summary>
	///     <para> The vehicle's object from the level </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	public GameObject vehicle;
	[Space(3)]
	public Vector2 position = new Vector2 (0.3f, 0.5f);

	#endregion

	#region Variables
	
	private Vector3 _velocity = Vector3.zero;
	private Transform _target;
	private Camera _camera;

	#endregion

	/// <summary>
	///     <para> Start Method - is called at runtime </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	private void Start()
	{
		_camera = GetComponent<Camera>();
	}

	/// <summary>
	///     <para> Update Method - is called each frame </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	private void Update()
	{
		_target = vehicle.transform;
		if (!_target) return;

		var position2 = _target.position;
		var point = _camera.WorldToViewportPoint(position2);
		var delta = position2 - _camera.ViewportToWorldPoint(new Vector3(position.x, position.y,point.z)); //(new Vector3(0.5, 0.5, point.z));

		var position1 = transform.position;
		var destination = position1 + delta;
		position1 = Vector3.SmoothDamp(position1, destination, ref _velocity, 0);
		transform.position = position1;
	}
}