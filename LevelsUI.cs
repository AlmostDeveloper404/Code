using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelsUI : MonoBehaviour
{
    [Header("PlayerLevel")]
    [SerializeField] private TMP_Text _level;
    [SerializeField] private Image _progressBar;
    [SerializeField] private TMP_Text _progressExp;

    private void OnEnable()
    {
        PlayerStats.OnScoreValueChanged += UpdateData;
        UpdateData();
    }

    private void UpdateData()
    {
        _level.text = PlayerStats.Instance.GetPlayerLevel().ToString();
        _progressBar.fillAmount = PlayerStats.Instance.GetPlayerExp() / PlayerStats.Instance.GetCurrentExpBorder();
        _progressExp.text = $"{PlayerStats.Instance.GetPlayerExp()}/{PlayerStats.Instance.GetCurrentExpBorder()}";
    }

    private void OnDisable()
    {
        PlayerStats.OnScoreValueChanged -= UpdateData;
    }
}
