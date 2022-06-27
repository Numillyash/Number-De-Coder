using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coder
{
    public partial class Form1 : Form
    {
        int vigener_f(int a, int b) {
            return (a + b) % 26;
        }
        int vigener_de_f(int c, int b) {
            if ((c - b) >= 0)
           	    return c - b;
            else
            	return c - b + 26; 
        }      
        int a1z26(char value) {
            for (int i = 0; i < 26; i++)
            {
                if (value == symbols[i])
                {
                    return i;
                }
            }
            return -1;
        }
        string a1z26(string value)
        {
            value = value.ToUpper();
            string result = "";
            foreach (char ch in value)
                result += (a1z26(ch)) + " ";
            return result;
        }
        char de_a1z26(int value) {
            return symbols[value]; 
        }
        string encrypt(string _message, string _key) {
            string message = _message;
            string key = _key;
            if (key.Length > message.Length)
                key = _key.Substring(0, message.Length);
            else
                if (key.Length < message.Length) 
                {
                    int len_m = _message.Length;
                    int len_k = _key.Length;
                    key = "";
                    while (len_m > len_k)
                    {
                        key += _key;
                        len_m -= len_k;
                    }
                    key += _key.Substring(0, len_m);
                }
            string result = "";
            for (int i = 0; i < message.Length; i++)
                result += vigener_f(a1z26(message[i]), a1z26(key[i])) + "-";//de_a1z26(vigener_f(a1z26(message[i]), a1z26(key[i])));
            return result;
        }
        string decrypt(string _message, string _key) {
            string message = _message;
            string[] mas = message.Split();
            message = "";
            for (int i = 0; i < mas.Length; i++)
            {
                message += de_a1z26(int.Parse(mas[i]));
            }
            string key = _key;
            if (key.Length > message.Length)
                key = _key.Substring(0, message.Length);
            else
            {
                if (key.Length < message.Length)
                {
                    int len_m = message.Length;
                    int len_k = _key.Length;
                    key = "";
                    while (len_m > len_k)
                    {
                        key += _key;
                        len_m -= len_k;
                    }
                    key += _key.Substring(0, len_m);
                }
            }
            key = key;
            string result = "";
            for (int i = 0; i < message.Length; i++)
                result += de_a1z26(vigener_de_f(a1z26(message[i]), a1z26(key[i])));
            return result;
        }

        private string input_s = "";
        private string key_s = "";
        char[] symbols = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            input_s = textBox1.Text;
            input_s = input_s.ToUpper();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            key_s = textBox2.Text;
            key_s = key_s.ToUpper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string res = encrypt(input_s, key_s);
            textBox3.Text = res;
        }
    }
}
