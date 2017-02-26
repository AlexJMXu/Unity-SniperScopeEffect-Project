using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour {

	public Animator animator;
	public GameObject scopeOverlay;
	public GameObject weaponCamera;
	public Camera mainCamera;

	private bool isScoped = false;

	public float scopedFOV = 15f;
	private float normalFOV;

	void Update () {
		if (Input.GetButtonDown ("Fire2")) {
			isScoped = !isScoped;
			animator.SetBool("isScoped", isScoped);
			if (isScoped) {
				StartCoroutine(OnScoped());
			} else {
				OnUnscoped();
			}
		}
	}

	void OnUnscoped() {
		scopeOverlay.SetActive(false);
		weaponCamera.SetActive(true);

		mainCamera.fieldOfView = normalFOV;
	}

	IEnumerator OnScoped() {
		yield return new WaitForSeconds(0.15f);

		scopeOverlay.SetActive(true);
		weaponCamera.SetActive(false);

		normalFOV = mainCamera.fieldOfView;
		mainCamera.fieldOfView = scopedFOV;
	}
}
