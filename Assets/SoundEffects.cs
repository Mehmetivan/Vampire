using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static SoundEffects Instance;

    [SerializeField] private AudioSource sfxSource;     // for one-shot sounds
    [SerializeField] private AudioSource musicSource;   // for looping music

    [SerializeField] private AudioClip background, mainMenu;
    [SerializeField]
    private AudioClip enemyDeath, playerDeath, playerAttack, enemyAttack,enemyTakeDamage, playerTakeDamage,
                                        levelUp, pressPlay, uiSelect, dash,explosion;

    private void Awake()
    {
        Instance = this;
    }

    // One-shots
    public void PlayEnemyDeath() => sfxSource.PlayOneShot(enemyDeath);
    public void PlayPlayerDeath() => sfxSource.PlayOneShot(playerDeath);
    public void PlayPlayerAttack() => sfxSource.PlayOneShot(playerAttack);
    public void PlayEnemyAttack() => sfxSource.PlayOneShot(enemyAttack);

    public void PlayEnemyTakeDamage() => sfxSource.PlayOneShot(enemyTakeDamage);

    public void PlayPlayerTakeDamage() => sfxSource.PlayOneShot(playerTakeDamage);

    public void PlayExplosion() => sfxSource.PlayOneShot(explosion);

    public void PlayDash() => sfxSource.PlayOneShot(dash);

    public void PlayLevelUp() => sfxSource.PlayOneShot(levelUp);
    public void PlayPressPlay() => sfxSource.PlayOneShot(pressPlay);
    public void PlayUiSelect() => sfxSource.PlayOneShot(uiSelect);

    // Music
    public void PlayBackground() => PlayMusic(background);
    public void PlayMainMenu() => PlayMusic(mainMenu);

    private void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip && musicSource.isPlaying) return;
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }
}