using UnityEngine;
using UnityEngine.UI;

public enum SoundsGame
{
    explosionSound,
    blackholeSound,
    pickUpSound,

    buttonPressSound,
    soundButtonPressSound,
    menuMovingSound,
    newHighscoreSound,

    deathMobSound,

    rockContactSound,
    bounceContactSound,
    stickyContactSound,
    fallingIntoLavaSound,
}

public class SoundController : MonoBehaviour
{
    public AudioClip soundExplosion;
    public AudioClip soundBlackhole;
    public AudioClip soundPickUp;

    public AudioClip soundButtonPress;
    public AudioClip soundSoundButtonPress;
    public AudioClip soundMenuMoving;
    public AudioClip soundNewHighscore;

    public AudioClip soundDeathMob;

    public AudioClip soundRockContact;
    public AudioClip soundBounceContact;
    public AudioClip soundStickyContact;
    public AudioClip soundFallingIntoLava;

    public AudioSource lavaFlowingAudioSource;
    public AudioSource musicSource;

    public Toggle sfxToggle;
    public Toggle musicToggle;

    public bool sfx = true;
    public bool music = true;
    private bool firstTime = true;

    private float volumeLava;
    private float volumeMusic;

    //Singleton
    private static SoundController _instance;

    public static SoundController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SoundController>();
                if (_instance == null)
                {
                    _instance = new GameObject("Instance of " + typeof(SoundController)).AddComponent<SoundController>();
                }
            }
            return _instance;
        }
    }

    //Clean up singleton
    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        sfx = (PlayerPrefs.GetInt("sfx") != 0);
        music = (PlayerPrefs.GetInt("music") != 0);

        volumeLava = lavaFlowingAudioSource.volume;
        volumeMusic = musicSource.volume;

        if (!sfx)
        {
            sfxToggle.isOn = false;
            lavaFlowingAudioSource.volume = 0;
        }

        if (music)
        {
            musicToggle.isOn = true;
            musicSource.volume = 0;
        }

        firstTime = false;
    }

    public void SwitchSfx()
    {
        if (!firstTime)
        {
            sfx = !sfx;

            if (sfx) {
                lavaFlowingAudioSource.volume = volumeLava;
            }
            else
            {
                lavaFlowingAudioSource.volume = 0;
            }
            SoundController.Instance.PlaySound(SoundsGame.soundButtonPressSound);
            PlayerPrefs.SetInt("sfx", (sfx ? 1 : 0));
        }
    }

    public void SwitchMusic()
    {
        if (!firstTime)
        {
            music = !music;

            if (!music)
            {
                musicSource.volume = volumeMusic;
            }
            else
            {
                musicSource.volume = 0;
            }

            SoundController.Instance.PlaySound(SoundsGame.soundButtonPressSound);
            PlayerPrefs.SetInt("music", (music ? 1 : 0));
        }
    }

    public void PlaySound(SoundsGame currentSound)
    {

        if (!_instance.sfx)
        {
            return;
        }

        switch (currentSound)
        {
            case SoundsGame.explosionSound:
                {
                    _instance.GetComponent<AudioSource>().PlayOneShot(_instance.soundExplosion, 0.4f);
                }
                break;
            case SoundsGame.blackholeSound:
                {
                    _instance.GetComponent<AudioSource>().PlayOneShot(_instance.soundBlackhole,0.2f);
                }
                break;
            case SoundsGame.pickUpSound:
                {
                    _instance.GetComponent<AudioSource>().PlayOneShot(_instance.soundPickUp,0.5f);
                }
                break;
            case SoundsGame.buttonPressSound:
                {
                    _instance.GetComponent<AudioSource>().PlayOneShot(_instance.soundButtonPress);
                }
                break;
            case SoundsGame.soundButtonPressSound:
                {
                    _instance.GetComponent<AudioSource>().PlayOneShot(_instance.soundSoundButtonPress,0.2f);
                }
                break;
            case SoundsGame.menuMovingSound:
                {
                    _instance.GetComponent<AudioSource>().PlayOneShot(_instance.soundMenuMoving);
                }
                break;
            case SoundsGame.newHighscoreSound:
                {
                    _instance.GetComponent<AudioSource>().PlayOneShot(_instance.soundNewHighscore);
                }
                break;
            case SoundsGame.deathMobSound:
                {
                    _instance.GetComponent<AudioSource>().PlayOneShot(_instance.soundDeathMob);
                }
                break;
            case SoundsGame.rockContactSound:
                {
                    _instance.GetComponent<AudioSource>().PlayOneShot(_instance.soundRockContact,0.1f);
                }
                break;
            case SoundsGame.bounceContactSound:
                {
                    _instance.GetComponent<AudioSource>().PlayOneShot(_instance.soundBounceContact, 0.1f);
                }
                break;
            case SoundsGame.stickyContactSound:
                {
                    _instance.GetComponent<AudioSource>().PlayOneShot(_instance.soundStickyContact, 0.1f);
                }
                break;
            case SoundsGame.fallingIntoLavaSound:
                {
                    _instance.GetComponent<AudioSource>().PlayOneShot(_instance.soundFallingIntoLava,0.2f);
                }
                break;
        }
    }
}
