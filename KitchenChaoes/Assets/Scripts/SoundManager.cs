using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClipRefsSO AudioClipRefsSO;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManagerOnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManagerOnRecipeFailed;
        CuttingCounter.OnAnyCut += CuttingCounterOnAnyCut;
        Player.Instance.OnPickedSomething += PlayerOnPickedSomething;
        BaseCounter.OnAnyObjectPlacedHere += BaseCounterOnAnyObjectPlacedHere;
        TrashCounter.OnAnyObjectTrashed += TrashCounterOnAnyObjectTrashed;
    }

    private void TrashCounterOnAnyObjectTrashed(object sender, System.EventArgs e)
    {
        TrashCounter trashCounter = sender as TrashCounter;
        PlaySound(AudioClipRefsSO.trash, trashCounter.transform.position);
    }

    private void BaseCounterOnAnyObjectPlacedHere(object sender, System.EventArgs e)
    {
        BaseCounter baseCounter = sender as BaseCounter;
        PlaySound(AudioClipRefsSO.objectDrop,  baseCounter.transform.position);
    }

    private void PlayerOnPickedSomething(object sender, System.EventArgs e)
    {
        PlaySound(AudioClipRefsSO.objectPickup, Player.Instance.transform.position);
    }

    private void CuttingCounterOnAnyCut(object sender, System.EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound(AudioClipRefsSO.chop, cuttingCounter.transform.position);

    }

    private void DeliveryManagerOnRecipeFailed(object sender, System.EventArgs e)
    {
        PlaySound(AudioClipRefsSO.deliveryFail, DeliveryCounter.Instance.transform.position);
    }

    private void DeliveryManagerOnRecipeSuccess(object sender, System.EventArgs e)
    {
        PlaySound(AudioClipRefsSO.deliverySuccess, DeliveryCounter.Instance.transform.position);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }

    public void PlayFootstepsSound(Vector3 position, float volume = 1f)
    {
        Debug.Log("PlayFootstepsSound...");
        PlaySound(AudioClipRefsSO.footstep, position, volume);
    }
}