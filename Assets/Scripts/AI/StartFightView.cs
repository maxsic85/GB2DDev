using UnityEngine;
using UnityEngine.UI;
using Profile;

public class StartFightView : MonoBehaviour
{
    [SerializeField] private Button _startFightBtn;

    public Button StartFightButton => _startFightBtn;

}
public class StartFightController : BaseController
{
    private StartFightView _fightViewInstance;
    private ProfilePlayer _profilePlayer;

    public StartFightController(Transform placeForUI, StartFightView fightView, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _fightViewInstance = GameObject.Instantiate(fightView, placeForUI);
    }

    public void RefreshView()
    {
        _fightViewInstance.StartFightButton.onClick.AddListener(StartFight);
    }

    private void StartFight()
    {
        _profilePlayer.CurrentState.Value = GameState.Fight;
    }

    protected override void OnChildDispose()
    {
        _fightViewInstance.StartFightButton.onClick.RemoveAllListeners();
        GameObject.Destroy(_fightViewInstance.gameObject);
        base.OnChildDispose();
    }
}