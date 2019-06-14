using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ASTest : MonoBehaviour
{
    private AudioSource _as = null;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _as.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _as.Play();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            _as.Pause();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            _as.UnPause();
        }
        /* isPlaying：
         *  AudioClip是否正在播放
         *  只读
         *  注意：暂停中为false——AudioSource.Pause()，false；AudioSource.Play()或AudioSource.UnPause()，true；
         */
        if (_as.isPlaying)
        {
            Debug.Log(string.Format("time/length={0}/{1} ; timeSamples={2}", _as.time, _as.clip.length, _as.timeSamples));
        }
    }
}