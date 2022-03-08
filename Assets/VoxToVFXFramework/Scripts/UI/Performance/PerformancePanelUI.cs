using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VoxToVFXFramework.Scripts.Managers;

public class PerformancePanelUI : MonoBehaviour
{
	#region ScriptParamaters

	[SerializeField] private TextMeshProUGUI ForceLevelLODText;
	[SerializeField] private Slider ForceLevelLODSlider;

	[SerializeField] private TextMeshProUGUI VoxelScaleTitle;
	[SerializeField] private Slider VoxelScaleSlider;

	[SerializeField] private Toggle ShowLODToggle;

	#endregion

	#region UnityMethods

	private void OnEnable()
	{
		ForceLevelLODSlider.onValueChanged.AddListener(OnForceLevelLODValueChanged);
		VoxelScaleSlider.onValueChanged.AddListener(OnVoxelScaleValueChanged);
		ShowLODToggle.onValueChanged.AddListener(OnShowLODValueChanged);
		RefreshValues();
	}

	private void OnDisable()
	{
		ForceLevelLODSlider.onValueChanged.RemoveListener(OnForceLevelLODValueChanged);
		VoxelScaleSlider.onValueChanged.RemoveListener(OnVoxelScaleValueChanged);
		ShowLODToggle.onValueChanged.RemoveListener(OnShowLODValueChanged);
	}

	#endregion

	#region PrivateMethods

	private void RefreshValues()
	{
		ForceLevelLODText.text = "Force Level LOD: " + RuntimeVoxManager.Instance.ForcedLevelLod;
		ForceLevelLODSlider.SetValueWithoutNotify(RuntimeVoxManager.Instance.ForcedLevelLod);

		VoxelScaleTitle.text = "Voxel Scale: " + RuntimeVoxManager.Instance.VoxelScale;
		VoxelScaleSlider.SetValueWithoutNotify(RuntimeVoxManager.Instance.VoxelScale);

		ShowLODToggle.SetIsOnWithoutNotify(RuntimeVoxManager.Instance.DebugLod);
	}

	private void OnForceLevelLODValueChanged(float value)
	{
		RuntimeVoxManager.Instance.SetForceLODValue((int)value);
		ForceLevelLODText.text = "Force Level LOD: " + value;
	}

	private void OnVoxelScaleValueChanged(float value)
	{
		RuntimeVoxManager.Instance.SetVoxelScaleValue(value);
		VoxelScaleTitle.text = "Voxel Scale: " + value;
	}

	private void OnShowLODValueChanged(bool value)
	{
		RuntimeVoxManager.Instance.SetDebugLodValue(value);
	}

	#endregion
}
