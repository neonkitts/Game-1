using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace GameCore.ExperienceSystem
{
    public class ExperienceUIUpdater : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _expText;
        [SerializeField] private Image _image;
        
        private ExperienceSystem _experienceSystem;

        private void OnEnable() => _experienceSystem.OnExperiencePickup += UpdateExperienceBar;

        private void OnDisable() => _experienceSystem.OnExperiencePickup -= UpdateExperienceBar;

        private void Start()
        {
            _image.fillAmount = 0f;
            _expText.text = "1 LVL";
        }

        private void UpdateExperienceBar(float experience)
        {
            _image.fillAmount = _experienceSystem.CurrentExperience / _experienceSystem.ExperienceToUp;
            _image.fillAmount = Mathf.Clamp01(_image.fillAmount);
            _expText.text = $"{_experienceSystem.CurrentLevel} LVL";
        }

        [Inject]
        private void Construct(ExperienceSystem experienceSystem) => 
            _experienceSystem = experienceSystem;
    }
}