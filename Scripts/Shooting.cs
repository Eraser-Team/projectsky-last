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
