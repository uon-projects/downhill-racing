using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///     <para> Handles the level content on the canvas as well as the level design </para>
///     <author> @TeodorHMX1 </author>
/// </summary>
public class GameManager : MonoBehaviour
{
	[Header("Informations")] public Text DistanceTXT;

	public Text RecordTXT;
	public Text CoinTXT;
	public Text FuelTXT;
	public Text LastRecord;

	[Header("Sliders")] public Slider FuelSlider;

	public Slider DitanceSlider;
	[Header("Vehicle")] public GameObject vehicle;

	[Header("Fuel")] public float TotalFuel = 100f;

	public float FuelTime = .6f;

	[Header("Coins And Awards")] public AudioSource coinSound;

	public GameObject coinAwardedBox;
	public Text awardedText;
	public Animator awardAnimator;

	[Header("Complete Level")] public GameObject youWinMenu;

	public GameObject youLostMenu;
	public int winnerAwardedCoins = 30000;
	public int targetDistance;

	[HideInInspector] public bool isDead;

	[HideInInspector] public bool fuelFinished;

	private int _coins;
	private float _distanceTemp;
	private const float FuelVal = .35f;
	private Transform _player;
	private bool _started, _finished;

	/// <summary>
	///     <para> Start </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	private void Start()
	{
		Application.targetFrameRate = 60;
		DitanceSlider.gameObject.SetActive(true);
		DitanceSlider.maxValue = targetDistance;
		_coins = PlayerPrefs.GetInt("Coins");
		_player = vehicle.transform;
		_started = true;
		_finished = false;
	}

	/// <summary>
	///     <para> Update </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	private void Update()
	{
		if (!_started) return;
		if (!(_player.position.x >= _distanceTemp)) return;
		var position = _player.position;
		DistanceTXT.text = Mathf.Floor(position.x).ToString(CultureInfo.InvariantCulture);
		_distanceTemp = position.x;
		DitanceSlider.value = position.x;

		TotalFuel -= FuelVal;
		FuelSlider.value = TotalFuel;
		if (TotalFuel >= 0)
			FuelTXT.text = Mathf.Floor(TotalFuel).ToString(CultureInfo.InvariantCulture);
		if (!(TotalFuel < 0)) return;
		fuelFinished = true;
		// StartFuelFinish();
	}

	/// <summary>
	///     <para> OnCoin picked up add it to the player </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	public void AddCoin(int value)
	{
		StartCoroutine(TakeCoins());

		var transform1 = CoinTXT.transform;
		var localScale = transform1.localScale;
		localScale = new Vector3(localScale.x,
			localScale.y + 0.7f,
			localScale.z);
		transform1.localScale = localScale;

		if (coinSound)
			coinSound.Play();
		_coins += value;
		CoinTXT.text = _coins.ToString();
		PlayerPrefs.SetInt("Coins", _coins);
	}
	
	/// <summary>
	///     <para> Remove coin from level </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	private IEnumerator TakeCoins()
	{
		yield return new WaitForSeconds(0.03f);
		var transform1 = CoinTXT.transform;
		var localScale = transform1.localScale;
		localScale = new Vector3(localScale.x,
			localScale.y - 0.7f,
			localScale.z);
		transform1.localScale = localScale;
	}
	
	/// <summary>
	///     <para> Add fuel to the player </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	public void AddFuel(int value)
	{
		if (coinSound)
			coinSound.Play();
		TotalFuel = value;
	}
	
	private void StartFuelFinish()
	{
		StartCoroutine(DeadFuel());
	}

	public void StartDead()
	{
		StartCoroutine(Dead());
	}

	private IEnumerator Dead()
	{
		yield return new WaitForSeconds(3f);
		if (!isDead) yield break;
		#pragma warning disable 618
		PlayerPrefs.SetInt("BestDistance" + (Application.loadedLevel - 1), Mathf.CeilToInt(_player.position.x));
		#pragma warning restore 618
		youLostMenu.SetActive(true);
		Time.timeScale = 0;
	}

	private IEnumerator DeadFuel()
	{
		yield return new WaitForSeconds(3f);
		if (!fuelFinished) yield break;
		youLostMenu.SetActive(true);
		Time.timeScale = 0;
	}
}