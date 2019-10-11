using System;
using System.Drawing;
using System.Windows.Forms;
using URL.MAP;
using URL.GRID;
using URL.Player;
using System.Windows.Input;
using System.Media;
using URL.PathFinding;
using URL.Enemies;
using URL.BULLET;

namespace URL
{
    public partial class MainGame : Form
    {
        SoundPlayer player = new SoundPlayer();
        SoundPlayer suprise = new SoundPlayer();
        public static PictureBox[,] _pbxGridMain = new PictureBox[14, 22];
        public static PictureBox[,] _pbxGridMini = new PictureBox[4, 4];
        protected PictureBox[] _playerHealthGrid = new PictureBox[Character._playerHealth];
        protected PictureBox[] _enemyHealthGrid = new PictureBox[Enemy._enemyHealth];
        bool _playerCollision = false;
        protected int[,] _levelPath = new int[4, 4];                    
        protected char[,,] _3DLevelMapSections = new char[16, 12, 20];  
        protected char[,] _2DlevelMap = new char[50, 82];                
        protected char[,] _2DlevelEntity = new char[50, 82];            
        protected char[,] _2DlevelEnemies = new char[50, 82];           
        protected char[,] _2DlevelPlayer = new char[50, 82];             
        protected char[,] _AStarMap = new char[50, 82];                 
        public int _yPlayerMiniMapPosition;
        public int _xPlayerMiniMapPosition;
        public int _ySectionPositionMap;
        public int _xSectionPositionMap;
        public int _chestCompare = 0;
        char _zero = Convert.ToChar(0);
        CharacterMove _playerMove = new CharacterMove();
        CharacterCollision _characterCollision = new CharacterCollision();
        Character _player = new Character();
        Enemy _enemy = new Enemy();
        EnemyMovement _enemyMovement = new EnemyMovement();
        EnemyCollision _enemyCollision = new EnemyCollision();
        BulletShoot bulletShoot = new BulletShoot();
        public static bool _gameIdle = false;
        bool _keyPressedIsUp;
        bool _keyPressedIsLeft;
        bool _keyPressedIsRight;
        bool _keyPressedIsDown;
        public static bool _enemyCollided = false;
        int _respawnCounter = 0;

        public MainGame()
        {
            InitializeComponent();
            player.SoundLocation = "music.wav";
            suprise.SoundLocation = "Surprise.wav";
        }

        /// <summary>
        /// Loading up the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            GameIdle();
            SetupGrid();
            InitialMapSetup();
            SetupMap();
            SetupPlayer();
            SetupEnemy();
            SetupPlayerStats();
            SetupPlayerHealth();
            SetupEnemyHealth();
            player.Play();
        }

        /// <summary>
        /// The setup of the grid onto the main form
        /// </summary>
        public void SetupGrid()
        {
            InitializeMap _initializeMap = new InitializeMap();
            _initializeMap.InitializeGrid();
            _initializeMap.AddMap3D(_3DLevelMapSections);
            _initializeMap.AddMap2D(_2DlevelMap);
            _initializeMap.AddPath(_levelPath);
            InitializeGrid _initializeGrid = new InitializeGrid();
            _initializeGrid.Grid(_pbxGridMain);
            _initializeGrid.Grid(_pbxGridMini);
            AddGridMain();
            AddGridMini();
        }

        /// <summary>
        /// Determining what happens to the main form when the game is set to idle mode
        /// </summary>
        public void GameIdle()
        {
            if (_gameIdle == false)
            {
                _tmrInputCheck.Stop();
                _tmrEnemyMovement.Start();
                _tmrMovementCheck.Start();
                if (Questions._itemType == '0')
                {
                    pbx_MainItem.BackColor = Color.Red;
                }
                else if (Questions._itemType == '1')
                {
                    pbx_MainItem.BackColor = Color.Orange;
                }
                else if (Questions._itemType == '2')
                {
                    pbx_MainItem.BackColor = Color.Yellow;
                }
                else if (Questions._itemType == '3')
                {
                    pbx_MainItem.BackColor = Color.AliceBlue;
                }
                else if (Questions._itemType == '4')
                {
                    pbx_MainItem.BackColor = Color.Blue;
                }
                else if (Questions._itemType == '5')
                {
                    pbx_MainItem.BackColor = Color.LawnGreen;
                }
            }
            else
            {
                _tmrInputCheck.Start();
                _tmrEnemyMovement.Stop();
                _tmrMovementCheck.Stop();
            }
        }

        /// <summary>
        /// Initialising the map and all its contents
        /// </summary>
        public void InitialMapSetup()
        {
            LoadGrid loadGrid = new LoadGrid();
            _2DlevelEntity = loadGrid.LoadEntityGrid(_2DlevelEntity, _2DlevelMap);
            loadGrid.InitializeSectionMap(_2DlevelEntity, _levelPath, _2DlevelMap, _pbxGridMain,
                                          _pbxGridMini, _yPlayerMiniMapPosition, _xPlayerMiniMapPosition,
                                          _ySectionPositionMap, _xSectionPositionMap);
            _yPlayerMiniMapPosition = loadGrid.AddMiniMapY(_yPlayerMiniMapPosition);
            _xPlayerMiniMapPosition = loadGrid.AddMiniMapX(_xPlayerMiniMapPosition);
            _ySectionPositionMap = loadGrid.AddMiniSectionY(_ySectionPositionMap);
            _xSectionPositionMap = loadGrid.AddMiniSectionX(_xSectionPositionMap);
        }

        /// <summary>
        /// Displaying the map on the main grid
        /// </summary>
        public void SetupMap()
        {
            LoadGrid loadGrid = new LoadGrid();
            loadGrid.InitializeSectionMap(_2DlevelEntity, _levelPath, _2DlevelMap, _pbxGridMain,
                                         _pbxGridMini, _yPlayerMiniMapPosition, _xPlayerMiniMapPosition,
                                         _ySectionPositionMap, _xSectionPositionMap);
            _ySectionPositionMap = loadGrid.AddMiniSectionY(_ySectionPositionMap);
            _xSectionPositionMap = loadGrid.AddMiniSectionX(_xSectionPositionMap);
        }

        /// <summary>
        /// Seting up the character position
        /// </summary>
        public void SetupPlayer()
        {
            Character._yPlayerPositionMap = _player.PlayerPositionMapY(_ySectionPositionMap);
            Character._xPlayerPositionMap = _player.PlayerPositionMapX(_xSectionPositionMap);
            _tmrMovementCheck.Interval = _player.interval;
        }

        /// <summary>
        /// Seting Up The enemy position
        /// </summary>
        public void SetupEnemy()
        {
            _enemy.InitializeEnemy(_2DlevelMap);
            Enemy._yEnemyPositionMap = _enemy.EnemyPositionMapY(Enemy._yEnemyPositionMap);
            Enemy._xEnemyPositionMap = _enemy.EnemyPositionMapX(Enemy._xEnemyPositionMap);
        }

        /// <summary>
        /// Seting up and displaying relevant character statistics
        /// </summary>
        public void SetupPlayerStats()
        {
            _BombCount.Text = "Bombs:" + Convert.ToString(Character._bomb);
            _KeyCount.Text = "Keys:" + Convert.ToString(Character._key);
            _ChestCount.Text = "Chests:" + Convert.ToString(Character._chest);
            _CoinCount.Text = "Coins:" + Convert.ToString(Character._coin);
            if (Character._chest > _chestCompare)
            {
                _chestCompare = Character._chest;
                Questions questions = new Questions();
                questions.Show();
                GameIdle();
            }
        }

        /// <summary>
        /// Seting up and displaying the characters HP bar
        /// </summary>
        public void SetupPlayerHealth()
        {
            CharacterHealthGrid characterHealthGrid = new CharacterHealthGrid();
            _playerHealthGrid = characterHealthGrid.AddCharacterHealthGrid(_playerHealthGrid);
            _pnlCharacterHealthGrid.Controls.Clear();
            for (int _y = 0; _y < Character._playerHealth; _y++)
            {
                _pnlCharacterHealthGrid.Controls.Add(_playerHealthGrid[_y]);
            }
        }

        /// <summary>
        /// Setting up and displaying enemy HP
        /// </summary>
        public void SetupEnemyHealth()
        {
            EnemyHealthGrid enemyHealthGrid = new EnemyHealthGrid();
            _enemyHealthGrid = enemyHealthGrid.AddEnemyHealthGrid(_enemyHealthGrid);
            _pnlEnemyHealthGrid.Controls.Clear();
            for (int _y = 0; _y < Enemy._enemyHealth; _y++)
            {
                _pnlEnemyHealthGrid.Controls.Add(_enemyHealthGrid[_y]);
            }
        }

        /// <summary>
        /// Adding the Picturebox Grid to the main game form
        /// </summary>
        private void AddGridMain()
        {
            // Y Axis Generation
            for (int _y = 0; _y < 14; _y++)
            {
                // X Axis Generation
                for (int _x = 0; _x < 22; _x++)
                {
                    _GridMainMap.Controls.Add(_pbxGridMain[_y, _x]);
                }
            }
        }

        /// <summary>
        /// Adding the minimap grid to the main game form
        /// </summary>
        private void AddGridMini()
        {
            // Y Axis Generation
            for (int _y = 0; _y < 4; _y++)
            {
                // X Axis Generation
                for (int _x = 0; _x < 4; _x++)
                {
                    _GridMiniMap.Controls.Add(_pbxGridMini[_y, _x]);
                }
            }
        }

        /// <summary>
        /// Loding in the appropriate ssection based on which section the character enters into on his next move
        /// </summary>
        public void PlayerSectionSwitch()
        {
            if (Character._yPlayerPosition == 0)
            {
                _yPlayerMiniMapPosition--;
                Character._yPlayerPosition = 12;
                SetupMap();
            }
            else if (Character._yPlayerPosition == 13)
            {
                _yPlayerMiniMapPosition++;
                Character._yPlayerPosition = 1;
                SetupMap();
            }
            else if (Character._xPlayerPosition == 0)
            {
                _xPlayerMiniMapPosition--;
                Character._xPlayerPosition = 20;
                SetupMap();
            }
            else if (Character._xPlayerPosition == 21)
            {
                _xPlayerMiniMapPosition++;
                Character._xPlayerPosition = 1;
                SetupMap();
            }
            _pbxGridMini[_yPlayerMiniMapPosition, _xPlayerMiniMapPosition].BackColor = Color.OrangeRed;
        }

        /// <summary>
        /// Timer which checks if an input has been made to move characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _tmrMovementCheck_Tick(object sender, EventArgs e)
        {
            _2DlevelPlayer[Character._yPlayerPositionMap, Character._xPlayerPositionMap] = 'P';
            _pbxGridMain[Character._yPlayerPosition, Character._xPlayerPosition].BackColor = Color.DeepSkyBlue;
            _playerCollision = _characterCollision.EnemyCollision(_2DlevelEnemies, _playerCollision);
            if (_playerCollision == true)
            {
                _playerCollision = false;
                SetupPlayerHealth();
                if (Character._playerHealth == 0)
                {
                    _gameIdle = true;
                    GameIdle();
                    _GridMainMap.Controls.Clear();
                    _GridMainMap.BackgroundImage = Image.FromFile("InkedGameOver_LI.jpg");
                    _GridMainMap.Controls.Add(_lblRetry);
                    _lblRetry.Visible = true;
                }
            }
            if (_2DlevelMap[Character._yPlayerPositionMap, Character._xPlayerPositionMap] == '@' && _yPlayerMiniMapPosition == 3)
            {
                _lblExit.Visible = true;
                if (Keyboard.IsKeyDown(Key.Space))
                {
                    _gameIdle = true;
                    GameIdle();
                    _GridMainMap.Controls.Clear();
                    _GridMainMap.BackgroundImage = Image.FromFile("Victory.jpg");
                    _lblExit.Visible = false;
                }
            }
            else
            {
                _lblExit.Visible = false;
            }
            if (Keyboard.IsKeyDown(Key.W))
            {
                _2DlevelPlayer[Character._yPlayerPositionMap, Character._xPlayerPositionMap] = ' ';
                _playerMove.PositionUp(_pbxGridMain, _2DlevelMap, _zero);
                _playerCollision = _characterCollision.ItemCollision(_2DlevelEntity);
                if (_playerCollision == true)
                {
                    SetupPlayerStats();
                }
            }
            else if (Keyboard.IsKeyDown(Key.A))
            {
                _2DlevelPlayer[Character._yPlayerPositionMap, Character._xPlayerPositionMap] = ' ';
                _playerMove.PositionLeft(_pbxGridMain, _2DlevelMap, _zero);
                _playerCollision = _characterCollision.ItemCollision(_2DlevelEntity);
                if (_playerCollision == true)
                {
                    SetupPlayerStats();
                }
            }
            else if (Keyboard.IsKeyDown(Key.S))
            {
                _2DlevelPlayer[Character._yPlayerPositionMap, Character._xPlayerPositionMap] = ' ';
                _playerMove.PositionDown(_pbxGridMain, _2DlevelMap, _zero);
                _playerCollision = _characterCollision.ItemCollision(_2DlevelEntity);
                if (_playerCollision == true)
                {
                    SetupPlayerStats();
                }
            }
            else if (Keyboard.IsKeyDown(Key.D))
            {
                _2DlevelPlayer[Character._yPlayerPositionMap, Character._xPlayerPositionMap] = ' ';
                _playerMove.PositionRight(_pbxGridMain, _2DlevelMap, _zero);
                _playerCollision = _characterCollision.ItemCollision(_2DlevelEntity);
                if (_playerCollision == true)
                {
                    SetupPlayerStats();
                }
            }
            if (BulletShoot._attack == false)
            {
                BulletShoot._yBulletPositionMap = Character._yPlayerPositionMap;
                BulletShoot._xBulletPositionMap = Character._xPlayerPositionMap;
                BulletShoot._yBulletPosition = Character._yPlayerPosition;
                BulletShoot._xBulletPosition = Character._xPlayerPosition;
                if (Keyboard.IsKeyDown(Key.Right))
                {
                    BulletShoot._attack = true;
                    _keyPressedIsRight = true;
                    _tmrBulletCheck.Start();
                }
                else if (Keyboard.IsKeyDown(Key.Left))
                {
                    BulletShoot._attack = true;
                    _keyPressedIsLeft = true;

                    _tmrBulletCheck.Start();
                }
                else if (Keyboard.IsKeyDown(Key.Up))
                {
                    BulletShoot._attack = true;
                    _keyPressedIsUp = true;
                    _tmrBulletCheck.Start();
                }
                else if (Keyboard.IsKeyDown(Key.Down))
                {
                    BulletShoot._attack = true;
                    _keyPressedIsDown = true;
                    _tmrBulletCheck.Start();
                }
            }
            PlayerSectionSwitch();
        }

        /// <summary>
        /// The timer which controls how the enemy moves in my solution
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tmrEnemyMovement_Tick(object sender, EventArgs e)
        {
            _2DlevelEnemies[Enemy._yEnemyPositionMap, Enemy._xEnemyPositionMap] = 'E';
            _enemyMovement.EnemyMove(_2DlevelEnemies, _yPlayerMiniMapPosition, _xPlayerMiniMapPosition,
                                     _ySectionPositionMap, _xSectionPositionMap);
            _enemyCollision.EnemyCollide();

            if (_enemyCollided == true)
            {
                SetupEnemyHealth();
                _enemyCollided = false;
                if (Enemy._enemyHealth == 0)
                {
                    _tmrEnemyMovement.Stop();
                    _pbxGridMain[Enemy._yEnemyPositionMap - _ySectionPositionMap,
                                 Enemy._xEnemyPositionMap - _xSectionPositionMap].BackColor = Color.Aqua;
                    _tmrEnemyRespawn.Start();
                }
            }
        }

        /// <summary>
        /// A timer which check if an answer has been inputted by the user for the question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tmrInputCheck_Tick(object sender, EventArgs e)
        {
            GameIdle();
        }

        /// <summary>
        /// The timer which checks if the bullet can be shot, moving projectiles accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tmrBulletCheck_Tick(object sender, EventArgs e)
        {
            bool _bulletShot = false;
            if (Character._yPlayerPosition > 0 && Character._yPlayerPosition < 14
                && Character._xPlayerPosition > 0 && Character._xPlayerPosition < 22)
            {
                _bulletShot = bulletShoot.BulletShot(_bulletShot, _2DlevelEntity, _2DlevelMap, _keyPressedIsUp,
                                                     _keyPressedIsLeft, _keyPressedIsRight, _keyPressedIsDown, _zero);
                if (_bulletShot == true)
                {
                    _keyPressedIsRight = false;
                    _keyPressedIsLeft = false;
                    _keyPressedIsUp = false;
                    _keyPressedIsDown = false;
                    _tmrBulletCheck.Stop();
                }
            }
        }

        /// <summary>
        /// The timer which controls how fast the A* algorithm generates a path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tmrAStar_Tick(object sender, EventArgs e)
        {
            _AStarMap = _enemy.AStarPathMapWriter(_2DlevelMap, _AStarMap, _2DlevelEntity, _2DlevelEnemies, _2DlevelPlayer);
            AStar.map = _AStarMap;
            AStar.PathFinder(Character._yPlayerPositionMap, Character._xPlayerPositionMap,
                             Enemy._yEnemyPositionMap, Enemy._xEnemyPositionMap);
        }

        /// <summary>
        /// This is what happens when the retry button on the game over screen is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _lblRetry_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        /// <summary>
        /// This is responsible for the enemy respawning after they die
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tmrEnemyRespawn_Tick(object sender, EventArgs e)
        {
            _respawnCounter++;
            if (_respawnCounter == 3)
            {
                _respawnCounter = 0;
                Enemy._enemyHealth = 10;
                SetupEnemy();
                SetupEnemyHealth();
                _tmrEnemyMovement.Start();
                _tmrEnemyRespawn.Stop();
            }
        }
    }
}