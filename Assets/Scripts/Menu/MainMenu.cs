using System;
using UnityEngine;

namespace Menu
{
	/// <summary>
	///     <para> MainMenu </para>
	///     <author> @TeodorHMX1 </author>
	/// </summary>
	public class MainMenu : MonoBehaviour
	{
		public GameObject mainMenu;
		public GameObject optionsMenu;
		public GameObject instructionsMenu;
		public GameObject creditsScreen;

		/// <summary>
		///     <para> Start </para>
		///     <author> @TeodorHMX1 </author>
		/// </summary>
		private void Start()
		{
			mainMenu.SetActive(true);
			optionsMenu.SetActive(false);
			instructionsMenu.SetActive(false);
			creditsScreen.SetActive(false);
		}

		/// <summary>
		///     <para> Update </para>
		///     <author> @TeodorHMX1 </author>
		/// </summary>
		private void Update()
		{
			if (!creditsScreen.activeSelf) return;
			
			mainMenu.SetActive(true);
			optionsMenu.SetActive(false);
			instructionsMenu.SetActive(false);
			creditsScreen.SetActive(false);
		}

		/// <summary>
		///     <para> IOnMainMenu </para>
		///     <author> @TeodorHMX1 </author>
		/// </summary>
		public void IOnMainMenu()
		{
			mainMenu.SetActive(true);
			optionsMenu.SetActive(false);
			creditsScreen.SetActive(false);
			instructionsMenu.SetActive(false);
		}

		/// <summary>
		///     <para> IOnOptions </para>
		///     <author> @TeodorHMX1 </author>
		/// </summary>
		public void IOnOptions()
		{
			mainMenu.SetActive(false);
			optionsMenu.SetActive(true);
			creditsScreen.SetActive(false);
			instructionsMenu.SetActive(false);
		}

		/// <summary>
		///     <para> IOnPlay </para>
		///     <author> @TeodorHMX1 </author>
		/// </summary>
		public void IOnPlay()
		{
			mainMenu.SetActive(false);
			optionsMenu.SetActive(false);
			creditsScreen.SetActive(false);
			instructionsMenu.SetActive(false);
		}

		/// <summary>
		///     <para> IOnCreditsScreen </para>
		///     <author> @TeodorHMX1 </author>
		/// </summary>
		public void IOnCreditsScreen()
		{
			mainMenu.SetActive(false);
			optionsMenu.SetActive(false);
			creditsScreen.SetActive(true);
			instructionsMenu.SetActive(false);
		}

		/// <summary>
		///     <para> IOnInstructionsScreen </para>
		///     <author> @TeodorHMX1 </author>
		/// </summary>
		public void IOnInstructionsScreen()
		{
			mainMenu.SetActive(false);
			optionsMenu.SetActive(false);
			creditsScreen.SetActive(true);
			instructionsMenu.SetActive(true);
		}
	}
}