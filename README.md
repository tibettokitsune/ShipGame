Pirate Ships: Naval Battle (Top-Down)

🏴‍☠️ Управляйте пиратскими кораблями, сражайтесь и захватывайте добычу в открытом море!

![Gameplay Screenshot](/screen.png)
🎮 Основные механики
    
    Движение кораблей на основе физики Unity (Rigidbody + силы).
    
    Влияние ветра – меняет скорость и манёвренность.
    
    Артиллерийские дуэли – стрельба ядрами с баллистической траекторией.
    
    Система наград – золото за победы

🛠 Технологии 
    
    Zenject
    UniRx
    DoTween
    UniTask

Чтобы запустить проект откройте сцену Assets/Game/Scenes/Boot

Проект инициализируется с бутстрапа BootInstaller - инициализация сервисов и всего, что понадобится на уровне всего проекта
После в игровой сцене уже инициализируется GameSceneInstaller
Точка входа в игровую сцену по сути GameManager
Геймплей построен на MVP архитектуре

Для управления парусом используйте слайдер справа (вниз - опустить паруса, дать больше скорости кораблю)
Для управления направлением используйте руль по середине экрана внизу (вправо влево соответственно поворачивает кораблик)
Стрельба происходит автоматически, при попадании врага в зону поражения