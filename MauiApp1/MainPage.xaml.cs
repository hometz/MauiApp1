namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        string FirstBuffer = "0";
        string SecondBuffer = "0";
        bool IsOperationClicked = false;
        bool IsCommaClicked = false;
        string Operation = "";

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            Entry? entry = this.FindByName("EnterField") as Entry;

            if (!IsOperationClicked && btn.Text[0] > 48 && btn.Text[0] <= 57)
            {
                if (FirstBuffer == "0" || FirstBuffer == "Error") FirstBuffer = "";
                FirstBuffer += btn.Text;
                entry.Text = FirstBuffer;
            }

            else if (IsOperationClicked && btn.Text[0] > 48 && btn.Text[0] <= 57)
            {
                if (SecondBuffer == "0" || SecondBuffer == "Error") SecondBuffer = "";
                SecondBuffer += btn.Text;
                entry.Text = SecondBuffer;
            }

            else if (btn.Text[0] == 48)
            {
                if (IsOperationClicked && SecondBuffer != "0")
                {
                    SecondBuffer += btn.Text;
                    entry.Text = SecondBuffer;
                }

                else if (!IsOperationClicked && FirstBuffer != "0")
                {
                    FirstBuffer += btn.Text;
                    entry.Text = FirstBuffer;
                }
            }

            else
            {
                if (btn.Text == "AC")
                {
                    entry.Text = "0";
                    FirstBuffer = "0";
                    SecondBuffer = "0";
                    IsCommaClicked = false;
                    IsOperationClicked = false;
                }
                else if (btn.Text == "+/-")
                {
                    if (!IsOperationClicked)
                    {
                        FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) * -1);
                        entry.Text = FirstBuffer;
                    }
                    else if (IsOperationClicked)
                    {
                        SecondBuffer = Convert.ToString(Convert.ToDouble(SecondBuffer) * -1);
                        entry.Text = SecondBuffer;
                    }
                }
                else if (btn.Text == "%")
                {
                    if (!IsOperationClicked)
                    {
                        FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) / 100);
                        entry.Text = FirstBuffer;
                    }

                    else if (IsOperationClicked)
                    {
                        SecondBuffer = Convert.ToString(Convert.ToDouble(SecondBuffer) / 100);
                        entry.Text = SecondBuffer;
                    }
                }
                else if (btn.Text == ",")
                {
                    if (!IsCommaClicked && !IsOperationClicked)
                    {
                        FirstBuffer = FirstBuffer + ",";
                        entry.Text = FirstBuffer;
                        IsCommaClicked = true;
                    }
                    else if (!IsCommaClicked && IsOperationClicked)
                    {
                        SecondBuffer = SecondBuffer + ",";
                        entry.Text = SecondBuffer;
                        IsCommaClicked = true;
                    }
                }
                else if (btn.Text == "|x|")
                {
                    if (!IsOperationClicked)
                    {
                        FirstBuffer = Convert.ToString(Math.Abs(Convert.ToDouble(FirstBuffer)));
                        entry.Text = FirstBuffer;
                    }
                    else if (IsOperationClicked)
                    {
                        SecondBuffer = Convert.ToString(Math.Abs(Convert.ToDouble(SecondBuffer)));
                        entry.Text = SecondBuffer;
                    }
                }
                else if (btn.Text == "/")
                {
                    if (!IsOperationClicked)
                    {
                        entry.Text = "/";
                        IsOperationClicked = true;
                        Operation = "/";
                    }
                    else
                    {
                        if (Operation == "/")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) / Convert.ToDouble(SecondBuffer));
                        }
                        else if (Operation == "*")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) * Convert.ToDouble(SecondBuffer));
                        }
                        else if (Operation == "+")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) + Convert.ToDouble(SecondBuffer));
                        }
                        else if (Operation == "-")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) - Convert.ToDouble(SecondBuffer));
                        }
                        Operation = "/";
                        entry.Text = FirstBuffer;
                        IsOperationClicked = true;
                        SecondBuffer = "0";
                    }
                }
                else if (btn.Text == "x")
                {
                    if (!IsOperationClicked)
                    {
                        entry.Text = "x";
                        IsOperationClicked = true;
                        Operation = "x";
                    }
                    else
                    {
                        if (Operation == "/")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) / Convert.ToDouble(SecondBuffer));
                        }
                        else if (Operation == "*")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) * Convert.ToDouble(SecondBuffer));
                        }
                        else if (Operation == "+")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) + Convert.ToDouble(SecondBuffer));
                        }
                        else if (Operation == "-")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) - Convert.ToDouble(SecondBuffer));
                        }
                        Operation = "*";
                        entry.Text = FirstBuffer;
                        IsOperationClicked = true;
                        SecondBuffer = "0";
                    }
                }
                else if (btn.Text == "+")
                {
                    if (!IsOperationClicked)
                    {
                        entry.Text = "+";
                        IsOperationClicked = true;
                        Operation = "+";
                    }
                    else
                    {
                        if (Operation == "/")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) / Convert.ToDouble(SecondBuffer));
                        }
                        else if (Operation == "*")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) * Convert.ToDouble(SecondBuffer));
                        }
                        else if (Operation == "+")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) + Convert.ToDouble(SecondBuffer));
                        }
                        else if (Operation == "-")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) - Convert.ToDouble(SecondBuffer));
                        }
                        Operation = "+";
                        entry.Text = FirstBuffer;
                        IsOperationClicked = true;
                        SecondBuffer = "0";
                    }
                }
                else if (btn.Text == "-")
                {
                    if (!IsOperationClicked)
                    {
                        entry.Text = "-";
                        IsOperationClicked = true;
                        Operation = "-";
                    }
                    else
                    {
                        if (Operation == "/")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) / Convert.ToDouble(SecondBuffer));
                        }
                        else if (Operation == "*")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) * Convert.ToDouble(SecondBuffer));
                        }
                        else if (Operation == "+")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) + Convert.ToDouble(SecondBuffer));
                        }
                        else if (Operation == "-")
                        {
                            FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) - Convert.ToDouble(SecondBuffer));
                        }
                        Operation = "-";
                        entry.Text = FirstBuffer;
                        IsOperationClicked = true;
                        SecondBuffer = "0";
                    }
                }
                else if (btn.Text == "=")
                {
                    if (Operation == "/")
                    {
                        FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) / Convert.ToDouble(SecondBuffer));
                        entry.Text = FirstBuffer;
                        IsOperationClicked = false;
                        SecondBuffer = "0";
                    }
                    if (Operation == "x")
                    {
                        FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) * Convert.ToDouble(SecondBuffer));
                        entry.Text = FirstBuffer;
                        IsOperationClicked = false;
                        SecondBuffer = "0";
                    }
                    if (Operation == "+")
                    {
                        FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) + Convert.ToDouble(SecondBuffer));
                        entry.Text = FirstBuffer;
                        IsOperationClicked = false;
                        SecondBuffer = "0";
                    }
                    if (Operation == "-")
                    {
                        FirstBuffer = Convert.ToString(Convert.ToDouble(FirstBuffer) - Convert.ToDouble(SecondBuffer));
                        entry.Text = FirstBuffer;
                        IsOperationClicked = false;
                        SecondBuffer = "0";
                    }
                }
            }
        }
    }

}
