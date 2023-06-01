using UnityEngine;
using VContainer;

namespace UI
{
    public class GameUIController : MonoBehaviour
    {
        [SerializeField] private GameUIModel gameUIModel;
        private GameUIView _gameUIView;
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void Awake()
        {
            _gameManager.OnGameStartedEvent += OnGameStarted;
            _gameManager.OnGameOverEvent += OnGameOver;
            _gameManager.OnGameWinEvent += OnGameWin;
            _gameUIView = new(gameUIModel.mainMenu, gameUIModel.shop, gameUIModel.inGameMenu, gameUIModel.winMenu, gameUIModel.gameOverMenu);
            Init();
        }

        public void StartGame() => _gameManager.StartGame();

        public void RestartGame() => _gameManager.RestartGame();

        public void OpenShop()
        {
            _gameUIView.ShowShop();
            _gameUIView.HideMainMenu();
        }

        public void CloseShop()
        {
            _gameUIView.HideShop();
            _gameUIView.ShowMainMenu();
        }

        private void Init()
        {
            _gameUIView.ShowMainMenu();
            _gameUIView.HideInGameMenu();
            _gameUIView.HideWinGameMenu();
            _gameUIView.HideGameOverMenu();
        }

        private void OnGameStarted()
        {
            _gameUIView.HideMainMenu();
            _gameUIView.ShowInGameMenu();
            _gameUIView.HideWinGameMenu();
            _gameUIView.HideGameOverMenu();
        }

        private void OnGameOver()
        {
            _gameUIView.HideInGameMenu();
            _gameUIView.ShowGameOverMenu();
        }

        private void OnGameWin()
        {
            _gameUIView.ShowWinGameMenu();
        }


        private void OnDestroy()
        {
            _gameManager.OnGameStartedEvent -= OnGameStarted;
            _gameManager.OnGameOverEvent -= OnGameOver;
            _gameManager.OnGameWinEvent -= OnGameWin;
        }
    }
}