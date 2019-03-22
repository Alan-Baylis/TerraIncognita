using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WearponController : MonoBehaviour {
    public float dmg = 5.0f;
    public float weaponRange = 100.0f;
    public float fireRate = 10.0f;
    public float reloadTime = 1.0f;
    public int maxAmmo = 100;
    public Camera gameCamera;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public Text ammoText;
    public Animator weponAnim;
    private int currentAmmo;
    private bool reloading = false;
    private float nextFire = 0f;
    public AudioClip fireSound;
    public AudioClip reloadSound;
    AudioSource audioPlayer;

    void Start() {
        currentAmmo = maxAmmo;
        ammoText.text = currentAmmo.ToString() + "/" + maxAmmo.ToString();
        audioPlayer = GetComponent<AudioSource>();
    }

    void OnEnable() {
        reloading = false;
    }

    void Update() {
        if (PlayerController.playerHealth > 0) {
            if (reloading)
                return;
            if (currentAmmo <= 0) {
                StartCoroutine(Reload());
                return;
            }
            if (Input.GetButton("Fire1") && Time.time >= nextFire) {
                muzzleFlash.Play();
                nextFire = Time.time + 1.0f / fireRate;
                Fire();
                currentAmmo -= 1;
            }
            if (Input.GetButtonUp("Fire1")) {
                weponAnim.SetBool("IsShooting", false);
            }

            ammoText.text = currentAmmo.ToString() + "/" + maxAmmo.ToString();
        }
    }
        IEnumerator Reload() {
            reloading = true;
            weponAnim.SetBool("Reloading", true);
            yield return new WaitForSeconds(reloadTime - 0.25f);
            weponAnim.SetBool("Reloading", false);
            yield return new WaitForSeconds(0.25f);
            currentAmmo = maxAmmo;
            reloading = false;

            audioPlayer.PlayOneShot(reloadSound, 1.0f);

        }

    

    void Fire() {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hit, weaponRange)) {
            Enemy target = hit.transform.GetComponent<Enemy>();
            audioPlayer.PlayOneShot(fireSound, 1.0f);
            if (target != null) {
                target.TakeDamage(dmg);
            }
            GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 1.0f);
            weponAnim.SetBool("IsShooting", true);
        }
    }
}