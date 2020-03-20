using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace Ahorcado {


    public partial class Form1 : Form
    {
        String hiddenWord = "";

        int fails = 0;
        int totalHits = 0;

        Boolean gameOver = false;

        ArrayList pressedButtons = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            hiddenWord = word();
            String gap = "";
            for (int i = 0; i < hiddenWord.Length; i++) gap += "_ ";
            label1.Text = gap.Trim();
            pictureBox1.Image = Properties.Resources.ahorcado_0;
            
        }

        private void buttonPressed(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            pressedButtons.Add(button);
            if (!gameOver)
            {
                String letter = button.Text;
                String actualText = label1.Text;
                Boolean hit = false;
                for (int i = 0; i < hiddenWord.Length; i++)
                {
                    if (hiddenWord[i] == letter.ToCharArray()[0])
                    {
                        actualText = actualText.Substring(0, 2 * i) + letter + actualText.Substring(2 * i + 1);
                        hit = true;
                        totalHits++;
                        if (totalHits == hiddenWord.Length)
                        {
                            gameOver = true;
                            resetButton.Visible = true;
                        }
                    }
                }
                label1.Text = actualText;
                button.Visible = false;
                if (!label1.Text.Contains('_'))
                {
                    pictureBox1.Image = Properties.Resources.acertastetodo;
                }
                if (!hit)
                {
                    fails++;
                    switch (fails)
                    {
                        case 0: pictureBox1.Image = Properties.Resources.ahorcado_0; break;
                        case 1: pictureBox1.Image = Properties.Resources.ahorcado_1; break;
                        case 2: pictureBox1.Image = Properties.Resources.ahorcado_2; break;
                        case 3: pictureBox1.Image = Properties.Resources.ahorcado_3; break;
                        case 4: pictureBox1.Image = Properties.Resources.ahorcado_4; break;
                        case 5: pictureBox1.Image = Properties.Resources.ahorcado_5; break;
                        default: pictureBox1.Image = Properties.Resources.ahorcado_fin; break;
                    }
                    if (fails > 5)
                    {
                        gameOver = true;
                        resetButton.Visible = true;
                    }
                }
            }
        }

        private String word()
        {
            String[] wordList = {"CETYS", "TEST", "HOLA", "ADIOS", "VLADIKAKA", "BORREGUITO", "BABYYODA"};
            Random random = new Random();
            return wordList[random.Next(wordList.Length)];
        }

        private void reset(object sender, EventArgs e)
        {
            if (gameOver)
            {
                fails = 0;
                totalHits = 0;
                gameOver = false;

                resetButton.Visible = false;

                foreach (Button button in pressedButtons)
                {
                    button.Visible = true;
                    pressedButtons.Remove(button);
                }

                pictureBox1.Image = Properties.Resources.ahorcado_0;

                hiddenWord = word();
                String gap = "";
                for (int i = 0; i < hiddenWord.Length; i++) gap += "_ ";
                label1.Text = gap.Trim();
            }
        }
    }
}
