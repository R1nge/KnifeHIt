using UnityEngine;

namespace UI
{
    public class GameUIView
    {
        private readonly GameObject _mainMenu, _shop, _inGameMenu, _winMenu, _gameOverMenu;

        public GameUIView(GameObject mainMenu, GameObject shop, GameObject inGameMenu, GameObject winMenu, GameObject gameOverMenu)
        {
            _mainMenu = mainMenu;
            _shop = shop;
            _inGameMenu = inGameMenu;
            _winMenu = winMenu;
            _gameOverMenu = gameOverMenu;
        }

        public void ShowMainMenu() => _mainMenu.SetActive(true);

        public void ShowInGameMenu() => _inGameMenu.SetActive(true);

        public void ShowWinGameMenu() => _winMenu.SetActive(true);

        public void ShowGameOverMenu() => _gameOverMenu.SetActive(true);

        public void HideMainMenu() => _mainMenu.SetActive(false);

        public void HideInGameMenu() => _inGameMenu.SetActive(false);

        public void HideWinGameMenu() => _winMenu.SetActive(false);

        public void HideGameOverMenu() => _gameOverMenu.SetActive(false);

        public void ShowShop() => _shop.SetActive(true);

        public void HideShop() => _shop.SetActive(false);
    }
}