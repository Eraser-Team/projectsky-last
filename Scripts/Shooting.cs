/*
 * Project Sky - da
 * Copyright (C) 2024 Eraser-Team
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Shooting : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 50f;
	public AudioSource shootingAudioSource;
	public AudioClip shootingSound;
    public int maxAmmo = 12;
    [SyncVar(hook = nameof(OnAmmoChanged))] private int currentAmmo;
    public Text ammoText;
    public KeyCode shootKey = KeyCode.Mouse0;
    private bool isReloading = false;

    private void Start()
    {
        currentAmmo = maxAmmo;

        if (isLocalPlayer)
        {
            ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
            UpdateAmmoText();
        }
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (isReloading)
            return;

        if (Input.GetKeyDown(shootKey) && currentAmmo > 0)
        {
            CmdShoot();
        }

        if (currentAmmo == 0 || (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo))
        {
            StartCoroutine(Reload());
        }
    }

	[Command]
	void CmdShoot()
	{
		if (currentAmmo > 0)
		{
			currentAmmo--;
			GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
			Rigidbody rb = bullet.GetComponent<Rigidbody>();
			rb.velocity = firePoint.right * bulletSpeed;
			NetworkServer.Spawn(bullet);
	
			UpdateAmmoText();
	
			// Воспроизводим звук выстрела
			if (shootingAudioSource && shootingSound)
			{
				shootingAudioSource.PlayOneShot(shootingSound);
			}
		}
	}


    [Client]
    void OnAmmoChanged(int oldValue, int newValue)
    {
        if (isLocalPlayer)
        {
            UpdateAmmoText();
        }
    }

    IEnumerator Reload()
    {
        if (currentAmmo < maxAmmo)
        {
            isReloading = true;
            Debug.Log("Reloading...");

            yield return new WaitForSeconds(1.5f);

            currentAmmo = maxAmmo;
            isReloading = false;

            UpdateAmmoText();
        }
    }

    void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + currentAmmo.ToString() + " / " + maxAmmo.ToString();
    }
}
