using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILogin : MonoBehaviour
{
    [Header("账号")]
    public InputField userName;//登录账号和登录密码
    [Header("密码")]
    public InputField passWord;
    public InputField r_userName;
    public InputField r_passWord;
    public InputField cr_passWord;
    public Slider au_silder;
    public Toggle au_toggle;
    public AudioSource au;
    public Text showMusicName;
    string name;//临时存储注册的账号和密码
    string pass;
    public GameObject registerPanel;
    public GameObject settingPanel;
    public List<AudioClip> audioClips = new List<AudioClip>();
    int index = 0;
    public static int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        au = au.GetComponent<AudioSource>();
        showMusicName.text = "正在播放：" + au.clip.name;
    }
    public void UpMusic()
    {

        index--;
        if (index < 0)
        {
            index = audioClips.Count - 1;
        }
        au.clip = audioClips[index];
        au.Play();//一旦切换歌曲，音乐会暂停，需要开启播放
        showMusicName.text = "正在播放：" + au.clip.name;
    }
    public void NextMusic()
    {

        index++;
        if (index > audioClips.Count - 1)
        {
            index = 0;
        }
        au.clip = audioClips[index];
        au.Play();//一旦切换歌曲，音乐会暂停，需要开启播放
        showMusicName.text = "正在播放：" + au.clip.name;
    }


    public void OpenSettingPanel()
    {
        settingPanel.SetActive(true);

    }
    public void CloseSettingPanel()
    {
        settingPanel.SetActive(false);
        print(level);
    }
    public void OpenRegisterPanel()
    {
        registerPanel.SetActive(true);
    }
    public void CloseRegisterPanel()
    {
        registerPanel.SetActive(false);
        r_passWord.text = "";
        r_userName.text = "";
        cr_passWord.text = "";
    }
    /// <summary>
    /// 确认注册
    /// </summary>
    public void ConfirmRegister()
    {
        name = r_userName.text;
        pass = r_passWord.text;
        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(pass) && pass == cr_passWord.text)
        {
            print("注册成功");
            CloseRegisterPanel();

        }
        else
        {
            name = "";
            pass = "";
        }
        r_passWord.text = "";
        r_userName.text = "";
        cr_passWord.text = "";
    }
    public void Login()
    {
        if (userName.text == name && passWord.text == pass && !string.IsNullOrEmpty(name))
        {
            print("登陆成功");
            SceneManager.LoadScene(3);
        }
        else
        {
            print("登陆失败");
        }
        passWord.text = "";
        userName.text = "";

    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        au.mute = au_toggle.isOn;
        au.volume = au_silder.value;
    }
    public void EasyT(bool isSelect)
    {
        if (isSelect)
        {
            level = 1;
        }
    }
    public void CommonT(bool isSelect)
    {
        if (isSelect)
        {
            level = 2;
        }
    }
    public void HardT(bool isSelect)
    {
        if (isSelect)
        {
            level = 3;
        }
    }
}
