using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// TODO VS 排版快捷鍵
namespace Calculator
{
    public partial class Form1 : Form
    {
        // TODO 請說明 property 和 feilds 差異
        // TODO 請說明下面三個變數的存取修飾子範圍，EX：public、private ....
        Double value = 0;
        String operation = ""; //設定運算子
        bool operation_pressed = false;

       
        public Form1()
        {
            InitializeComponent();
        }
        public static String SwitchLetter(String num)//將國字轉成數字的function
        {
            switch (num)
            {
                case "零":
                    return "0";
                case "一":
                    return "1";
                case "二":
                    return "2";
                case "三":
                    return "3";
                case "四":
                    return "4";
                case "五":
                    return "5";
                case "六":
                    return "6";
                case "七":
                    return "7";
                case "八":
                    return "8";
                case "九":
                    return "9";
                default:
                    return "";
            }
            

        }

        private void button_click(object sender, EventArgs e)
        {
            // TODO 數字按鈕用國字一 ~ 九來呈現，詳見 UI 畫面，這個我已經改好
            //  這個沒有實務商業邏輯意義，單純程式練習
            if (result.Text == "0" || (operation_pressed))
            {
                result.Clear();
            }

            Button b = (Button)sender;

            String Switchnum= SwitchLetter(b.Text);


            if (b.Text == ".")
            {
                if (!result.Text.Contains("."))
                {
                    result.Text = result.Text + b.Text;
                }

            }
            else
            { 
                    result.Text = result.Text + Switchnum;
            }

        }

        private void operator_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            value = double.Parse(result.Text);
            operation_pressed = true;
            op.Text = value + " " + operation;
        }

        private void CE_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            operation_pressed = false;
            op.Text = "";
            Double resultnum = Double.Parse(result.Text);//統一轉換
            // TODO Double.Parse 部分在四則運算內都有，統一轉換就好
            switch (operation)
            {
                case "+":
                    result.Text = (value + resultnum).ToString();
                    break;
                case "-":
                    result.Text = (value - resultnum).ToString();
                    break;
                case "*":
                    result.Text = (value * resultnum).ToString();
                    break;
                case "/":
                    // TODO 除法沒有防呆，分母為零時，結果
                    if (resultnum == 0)
                    {
                        result.Text = "Error";
                    }
                    else
                    {
                        result.Text = (value / resultnum).ToString();
                    }
                    break;
                default:
                    break;
            }//end switch

        }

        private void C_Click(object sender, EventArgs e)
        {
            result.Clear();
            value = 0;
        }
    
}



}
