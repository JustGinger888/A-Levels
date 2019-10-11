using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using URL.MANAGER;

namespace URL
{
    public partial class Questions : Form
    {
        public Questions()
        {
            InitializeComponent();
        }

        // ; - means a single mark
        // - means alternative response
        // - means an alternative word or sub-phrase
        // A - means acceptable creditworthy answer
        // R - means reject answer as not creditworthy
        // NE - means not enough
        // I - means ignore

        string _answer = "NAND";
        string _altAnswer = "NOT AND";
        string _playerAnswer;
        int _playerMarks;
        int _maxMarks = 1;
        int _percentage;
        public static char _itemType;

        /// <summary>
        /// This is responsoble for loading questions to the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Questions_Load(object sender, EventArgs e)
        {
            PictureQuestion();
        }

        /// <summary>
        /// This displays the picture questions on the question form
        /// </summary>
        private void PictureQuestion()
        {
            _pbxPictureQuestion.Image = Image.FromFile("LOGIC GATE.png");
        }

        /// <summary>
        /// This displays a textbox used to answer questions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnEnterText_Click(object sender, EventArgs e)
        {
            _playerAnswer = _tbxAnswer.Text;
            CheckAnswer();
        }

        /// <summary>
        /// This checks the players answer and converts it to upper case
        /// </summary>
        private void CheckAnswer()
        {
            if (_playerAnswer.ToUpper() == _answer || _playerAnswer.ToUpper() == _altAnswer)
            {
                _playerMarks++;
                CalculatePercentage();                
            }
            ItemReward();
        }

        /// <summary>
        /// The calculates the percentage the player has gotten on the question
        /// </summary>
        private void CalculatePercentage()
        {
            _percentage = (int)Math.Round((double)(_playerMarks / _maxMarks) * 100);
        }

        /// <summary>
        /// his determines the reward players will get based on the percentage
        /// </summary>
        private void ItemReward()
        {
            if (_percentage < 40)
            {
                _itemType = '0';
            }
            else if (_percentage >= 40 && _percentage < 60)
            {
                _itemType = '1';
            }
            else if (_percentage >= 60 && _percentage < 70)
            {
                _itemType = '2';
            }
            else if (_percentage >= 70 && _percentage < 80)
            {
                _itemType = '3';
            }
            else if (_percentage >= 80 && _percentage < 90)
            {
                _itemType = '4';
            }
            else if (_percentage >= 90 && _percentage <= 100)
            {
                _itemType = '5';
            }
            MainGame._gameIdle = false;
            this.Close();            
        }
    }
}