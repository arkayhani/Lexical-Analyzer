using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lexical
{


    struct Token
    {
        public String name;
        public int yylval;
    };


    public partial class Form1 : Form
    {
        int LE = 2;
        int NE = 3;
        int LT = 4;
        int EQ = 5;
        int GE = 7;
        int GT = 8;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int state = 0; int counter = 0;
            Token[] tokens = new Token[1000];
            int tokencount = 0;
            String input = textBox1.Text;

            String nexttoken = "";

            String output = "";
            Char nextchar;

            while (counter < input.Length)
            {


                switch (state)
                {
                    case 0:
                        nextchar = input[counter];
                        if (nextchar == '<')
                        {
                            state = 1;

                        }
                        else if (nextchar == '=')
                        {
                            state = 5;

                        }
                        else if (nextchar == '>')
                        {
                            state = 6;

                        }
                        else if ((nextchar >= 'a' && nextchar <= 'z') || (nextchar >= 'A' && nextchar <= 'Z'))
                        {
                            state = 10;
                            nexttoken += nextchar;

                        }
                        else if (nextchar >= '0' && nextchar <= '9')
                        {
                            state = 13;
                            nexttoken += nextchar;

                        }
                        else if ((nextchar == ' ') || (nextchar == '\n') || (nextchar == '\t'))
                        {
                            state = 23;

                        }
                        else if (nextchar == '{') state = 25;
                        else if (nextchar == '}') state = 26;
                        else if (nextchar == '(') state = 27;
                        else if (nextchar == ')') state = 28;
                        else if (nextchar == ';') state = 29;
                        listBox1.Items.Add("case0");
                        counter++;
                        break;
                    case 1:
                        nextchar = input[counter];
                        if (nextchar == '=') state = 2;
                        else if (nextchar == '>') state = 3;
                        else { state = 4; }
                        listBox1.Items.Add("case1");
                        counter++;
                        break;
                    case 2:
                        tokens[tokencount].name = "relop";
                        tokens[tokencount].yylval = LE;
                        output += " <LE_state>";
                        tokencount++;
                        state = 0;
                        listBox1.Items.Add("case2");
                        break;
                    case 3:
                        tokens[tokencount].name = "relop";
                        tokens[tokencount].yylval = NE;
                    
                        tokencount++;
                        state = 0;
                        listBox1.Items.Add("case3");
                        break;
                    case 4:
                        tokens[tokencount].name = "relop";
                        tokens[tokencount].yylval = LT;
                        output += " <LT_state> ";
                        counter--;
                        tokencount++;
                        state = 0;
                        listBox1.Items.Add("case4");
                        break;
                    case 5:
                        tokens[tokencount].name = "relop";
                        tokens[tokencount].yylval = EQ;
                        tokencount++;
                        state = 0;
                        listBox1.Items.Add("case5");
                        break;
                    case 6:
                        nextchar = input[counter];
                        if (nextchar == '=') state = 7;
                        else
                        {
                            state = 8;
                        }
                        listBox1.Items.Add("case6");
                        counter++;
                        break;
                    case 7:
                        tokens[tokencount].name = "relop";
                        tokens[tokencount].yylval = GE;
                        tokencount++;
                        state = 0;
                        listBox1.Items.Add("case7");
                        break;
                    case 8:
                        tokens[tokencount].name = "relop";
                        tokens[tokencount].yylval = GT;
                        tokencount++;
                        counter--;
                        state = 0;
                        listBox1.Items.Add("case8");
                        break;
                    case 10:
                        nextchar = input[counter];
                        if ((nextchar >= 'a' && nextchar <= 'z') || (nextchar >= 'A' && nextchar <= 'Z') || (nextchar >= '0' && nextchar <= '9') || (nextchar == '_'))
                        {
                            state = 10;
                            nexttoken += nextchar;
                        }
                        else
                        {
                            state = 11;
                        }
                        counter++;
                        listBox1.Items.Add("case10");
                        break;
                    case 11:
                        counter--;

                        if (nexttoken == "if")
                            tokens[tokencount].name = "if";
                        else if (nexttoken == "then")
                            tokens[tokencount].name = "then";
                        else if (nexttoken == "else")
                            tokens[tokencount].name = "else";
                        else
                        {
                            tokens[tokencount].name = "id";
                        }
                        //cheeeeeee tokens[numberOfTokens].attribute=findAddress(temp);
                        listBox1.Items.Add("case11");
                        listBox1.Items.Add(nexttoken);
                        nexttoken = "";
                        tokencount++;
                        state = 0;
                        break;
                    case 13:
                        nextchar = input[counter];
                        if (nextchar >= '0' && nextchar <= '9')
                        {
                            state = 13;
                            nexttoken += nextchar;
                        }
                        else if (nextchar == '.')
                        {
                            state = 14;
                            nexttoken += nextchar;
                        }
                        else if (nextchar == 'E')
                        {
                            state = 16;
                            nexttoken += nextchar;
                        }
                        else
                        {
                            state = 20;
                        }
                        listBox1.Items.Add("case13");
                        counter++;
                        break;
                    case 14:
                        nextchar = input[counter];
                        if (nextchar >= '0' && nextchar <= '9')
                        {
                            state = 15;
                            nexttoken += nextchar;
                        }
                        listBox1.Items.Add("case14");
                        counter++;
                        break;
                    case 15:
                        nextchar = input[counter];
                        if (nextchar >= '0' && nextchar <= '9')
                        {
                            state = 15;
                            nexttoken += nextchar;
                        }
                        else if (nextchar == 'E')
                        {
                            state = 16;
                            nexttoken += nextchar;
                        }
                        else
                        {
                            state = 21;
                        }
                        listBox1.Items.Add("case15");
                        counter++;
                        break;
                    case 16:
                        nextchar = input[counter];
                        if (nextchar >= '0' && nextchar <= '9')
                        {
                            state = 18;
                            nexttoken += nextchar;
                        }
                        else if (nextchar == '+' || nextchar == '-')
                        {
                            state = 17;
                            nexttoken += nextchar;
                        }
                        listBox1.Items.Add("case16");
                        counter++;
                        break;
                    case 17:
                        nextchar = input[counter];
                        if (nextchar >= '0' && nextchar <= '9')
                        {
                            state = 18;
                            nexttoken += nextchar;
                        }
                        listBox1.Items.Add("case17");
                        break;
                    case 18:
                        nextchar = input[counter];
                        if (nextchar >= '0' && nextchar <= '9')
                        {
                            state = 18;
                            nexttoken += nextchar;
                        }
                        else
                        {
                            state = 19;
                            nexttoken += nextchar;
                        }
                        listBox1.Items.Add("case18");
                        counter++;
                        break;
                    case 19:
                        counter--;
                        tokens[tokencount].name = "number";
                        //                tokens[numberOfTokens].attribute=;
                        nexttoken = "";
                        tokencount++;
                        state = 0;
                        listBox1.Items.Add("case19");
                        break;
                    case 20:
                        counter--;
                        tokens[tokencount].name = "number";
                        //                tokens[numberOfTokens].attribute=;
                        nexttoken = "";
                        tokencount++;
                        state = 0;
                        listBox1.Items.Add("case20");
                        break;
                    case 21:
                        counter--;
                        tokens[tokencount].name = "number";
                       
                        nexttoken = "";
                        tokencount++;
                        state = 0;
                        listBox1.Items.Add("case21");
                        break;
                    case 23:
                        nextchar = input[counter];
                        if ((nextchar == ' ') || (nextchar == '\n') || (nextchar == '\t'))
                        {
                            state = 23;
                        }
                        else
                        {
                            state = 24;
                        }
                        listBox1.Items.Add("case23");
                        counter++;
                        break;
                    case 24:
                        counter--;
                        state = 0;
                        listBox1.Items.Add("case24");
                        break;
                    case 25:
                        tokens[tokencount].name = "right_block_op";
                        tokens[tokencount].yylval = -1;
                        nexttoken = "";
                        tokencount++;
                        state = 0;
                        listBox1.Items.Add("case25");
                        break;
                    case 26:
                        tokens[tokencount].name = "left_block_op";
                        tokens[tokencount].yylval = -1;
                        nexttoken = "";
                        tokencount++;
                        state = 0;
                        listBox1.Items.Add("case26");
                        break;
                    case 27:
                        tokens[tokencount].name = "right_par_op";
                        tokens[tokencount].yylval = -1;
                        nexttoken = "";
                        tokencount++;
                        state = 0;
                        listBox1.Items.Add("case27");
                        break;
                    case 28:
                        tokens[tokencount].name = "left_par_op";
                        tokens[tokencount].yylval = -1;
                        nexttoken = "";
                        tokencount++;
                        state = 0;
                        listBox1.Items.Add("case26");
                        break;
                    case 29:
                        tokens[tokencount].name = "end_cmd_op";
                        tokens[tokencount].yylval = -1;
                        nexttoken = "";
                        tokencount++;
                        state = 0;
                        listBox1.Items.Add("case29");
                        break;
                }

            } output = "";
            for (int i = 0; i < tokencount + 1; i++)
            {

                output += " <" + tokens[i].name + "> ";
            }
            label1.Text = output;

        }
    }
}
