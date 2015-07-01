using UnityEngine;
using System.Collections;

public sealed class SoundManage : MonoBehaviour {
    #region 單例腳本建構
    private static SoundManage _instance;
    public static SoundManage Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManage>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    _instance = obj.AddComponent<SoundManage>();
                }
            }
            return _instance;
        }
    }
    #endregion
    
    public AudioSource Menu;
	public AudioSource Fight;
	public AudioSource Shoot;
	public AudioSource Bomb;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

	void SetSound( bool isSound ){
		float volume = (isSound ? 1f : 0f);
        Menu.volume = volume;
        Fight.volume = volume;
		Shoot.volume = volume/5f;
		Bomb.volume = volume;
	}
}
