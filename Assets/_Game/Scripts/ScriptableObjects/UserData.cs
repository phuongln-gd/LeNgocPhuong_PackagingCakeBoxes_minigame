using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[CreateAssetMenu(fileName = "UserData", menuName = "ScriptableObjects/UserData")]
public class UserData : ScriptableObject
{
    [Header("----Data----")]

    public int PlayingLevel = 1;
    public string lastTimePlay;


    #region List

    /// <summary>
    ///  0 = lock , 1 = unlock , 2 = selected
    ///  luu mot danh sach gia tri, key la ten list, id la so thu tu, state la trang thai
    /// </summary>
    /// <param name="key"></param>
    /// <param name="ID"></param>
    /// <param name="state"></param>
    public void SetDataState(string key, int ID, int state)
    {
        PlayerPrefs.SetInt(key + ID, state);
    }

    /// <summary>
    ///  0 = lock , 1 = unlock , 2 = selected
    /// </summary>
    /// <param name="key"></param>
    /// <param name="ID"></param>
    /// <param name="state"></param>
    public int GetDataState(string key, int ID, int defaultID = 0)
    {
        return PlayerPrefs.GetInt(key + ID, defaultID);
    }

    /// <summary>
    ///  0 = lock , 1 = unlock , 2 = selected
    /// </summary>
    /// <param name="key"></param>
    /// <param name="ID"></param>
    /// <param name="state"></param>
    public void SetDataState(string key, int ID, ref List<int> variable, int state)
    {
        variable[ID] = state;
        PlayerPrefs.SetInt(key + ID, state);
    }

    #endregion

    #region Save data

    /// <summary>
    /// Key_Name
    /// if(bool) true == 1
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetIntData(string key, ref int variable, int value)
    {
        variable = value;
        PlayerPrefs.SetInt(key, value);
    }

    public void SetBoolData(string key, ref bool variable, bool value)
    {
        variable = value;
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public void SetFloatData(string key, ref float variable, float value)
    {
        variable = value;
        PlayerPrefs.GetFloat(key, value);
    }

    public void SetStringData(string key, ref string variable, string value)
    {
        variable = value;
        PlayerPrefs.SetString(key, value);
    }

    #endregion

    #region Class

    //public void SetClassData<T>(string key, T t) where T : class
    //{
    //    string s = JsonConvert.SerializeObject(t);
    //    PlayerPrefs.SetString(key, s);
    //}

    //public T GetClassData<T>(string key) where T : class
    //{
    //    string s = PlayerPrefs.GetString(key);
    //    return string.IsNullOrEmpty(s) ? null : JsonConvert.DeserializeObject<T>(s);
    //}

    #endregion

    public void OnInitData()
    {

        PlayingLevel = PlayerPrefs.GetInt(Key_PlayingLevel, 1);
        lastTimePlay = PlayerPrefs.GetString(Key_Last_Time_Play, System.DateTime.Now.ToString(CultureInfo.InvariantCulture));
    }

    public void OnResetData()
    {
        PlayerPrefs.DeleteAll();
        OnInitData();
    }

    public const string Key_PlayingLevel = "Level";
    public const string Key_Last_Time_Play = "Key_Last_Time_Play";
}
