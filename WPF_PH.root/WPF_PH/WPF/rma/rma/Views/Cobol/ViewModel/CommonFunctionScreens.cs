using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Threading;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;
using rma;
using System.IO;

namespace rma.Cobol
{   
    public class CommonFunctionScreens : Window, INotifyPropertyChanged
    {
        public ObservableCollection<ScreenData> ScreenDataCollection;
        public bool IsExitForm = false;
        private int _clearScreenFrom = 1;
        private int _clearScreenTo = 25;
        protected bool isBatchProcess = false;
        public bool _PromptExit;
        private int charSize = 10;
        private int charExtraSize = 2;
        private TextBox txtFocus;

        public event PropertyChangedEventHandler PropertyChanged;

        /*public CommonFunctionScreens(Grid layoutRoot)
        {
            LayoutRoot = layoutRoot;
        }*/

        protected void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #region Properties
        public bool PromptExit; // { get; set; }
        public int EscapeKeyValue { get; set; }

        private Grid _layoutRoot;
        public Grid LayoutRoot {
            get
            {
                return _layoutRoot;
            }
            set
            {
                _layoutRoot = value;              
            }
        }

        #endregion


        #region Screen Functions
        public void ClearControls()
        {
            foreach (var ctrl in LayoutRoot.Children)
            {

                switch (ctrl.GetType().ToString())
                {
                    case "System.Windows.Controls.TextBlock":
                        break;
                    case "System.Windows.Controls.TextBox":
                        ((TextBox)ctrl).PreviewKeyDown -= Txt_PreviewKeyUp;
                        ((TextBox)ctrl).KeyDown -= Txt_KeyDown;
                        ((TextBox)ctrl).PreviewTextInput -= TxtDecimal_PreviewTextInput;
                        ((TextBox)ctrl).TextChanged -= Txt_TextChanged;
                        ((TextBox)ctrl).GotFocus -= Numeric_GotFocus;
                        ((TextBox)ctrl).PreviewTextInput -= TxtDecimal_PreviewTextInput;
                        ((TextBox)ctrl).GotFocus -= Numeric_GotFocus;
                        ((TextBox)ctrl).LostFocus -= integer_LostFocus;
                        ((TextBox)ctrl).PreviewTextInput -= TxtInteger_PreviewTextInput;
                        ((TextBox)ctrl).PreviewKeyUp -= Txt_PreviewKeyUp;
                        break;
                    default:
                        break;
                }
            }
        }

        public void GridAddControl()
        {
            if (LayoutRoot == null) return;

            int ctr = 0;

            foreach (var obj in ScreenDataCollection)
            {
                ctr++;
               /* Debug.WriteLine("ctr : " + ctr + " " + obj.GroupNameLevel1 + "  " + obj.GroupNameLevel2);
               if (obj.GroupNameLevel1.Equals("scr-title-batch-control-data.") &&   obj.InputVariableName.Equals("sys_mm")) // ("const_yy_curr"))
                {
                    Debug.WriteLine("ctr : " + ctr + " " + obj.GroupNameLevel1 + "  " + obj.GroupNameLevel2);
                } */

                if (IsExitForm == true)
                {
                    break;
                }
                                   
                if ((obj.RowStatus == rowStatus.Display || obj.RowStatus == rowStatus.DisplayInput) && obj.RowClassType == rowClassType.Simple)
                {                   
                    TextBlock lbl = new TextBlock();
                    lbl.Tag = obj.GroupNameLevel1 + "|" +  obj.GroupNameLevel2;
                    lbl.Text = obj.Data1;
                    int leftMargin = obj.Col  * charSize + charExtraSize;
                    lbl.Margin = new Thickness(leftMargin, 0, 0, 0);
                    lbl.HorizontalAlignment = HorizontalAlignment.Left;
                    lbl.VerticalAlignment = VerticalAlignment.Center;
                    lbl.FontFamily = new FontFamily("Courier New");                            
                    lbl.Visibility = Visibility.Hidden;
                    Grid.SetRow(lbl, Convert.ToInt32(obj.Line));
                    Grid.SetColumn(lbl, 2);                    

                    if (!string.IsNullOrWhiteSpace(obj.InputVariableName))
                    {
                        lbl.Name = ControlNameValidate(obj.InputVariableName.Replace(" ", ""));
                        lbl.SetBinding(TextBlock.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.OneWay });
                    }
                    if (obj.Data1.Equals("/"))
                    {                        
                        leftMargin = (obj.Col * charSize + charExtraSize) + 2;
                        lbl.Margin = new Thickness(leftMargin, 0, 0, 0);
                    }


                    LayoutRoot.Children.Add(lbl);
                }
                else if ((obj.RowStatus == rowStatus.Input || obj.RowStatus == rowStatus.InputAutoTab) && obj.RowClassType == rowClassType.Simple && obj.RowDataType == rowDataType.AlphaNumericPassword)
                {
                    // PasswordBox txt = new PasswordBox();
                    TextBox txt = new TextBox();
                    
                    txt.Name = ControlNameValidate(obj.InputVariableName.Replace(" ", "").Replace("[", "_").Replace("]", "_")); 
                    txt.Tag = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2;
                    int leftMargin = obj.Col * charSize + charExtraSize;
                    txt.Margin = new Thickness(leftMargin, 0, 0, 0);
                    txt.HorizontalAlignment = HorizontalAlignment.Left;
                    txt.VerticalAlignment = VerticalAlignment.Top;                    
                    txt.Width = WidthGet(obj);
                    txt.Visibility = Visibility.Hidden;
                    txt.Style = (Style)Application.Current.Resources["COBOLTextStyle"];  //(Style)FindResource("TextBoxControlTemplate");                          
                    txt.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    txt.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    txt.PreviewKeyDown += Txt_PreviewKeyUp;
                    txt.KeyDown += Txt_KeyDown;
                    txt.MaxLength = obj.MaxLength;

                    if (obj.RowStatus == rowStatus.InputAutoTab)
                    {
                        txt.TextChanged += Txt_TextChanged;
                    }

                    Grid.SetRow(txt, Convert.ToInt32(obj.Line));
                    Grid.SetColumn(txt, 2);
                    
                    txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay });                    
                    LayoutRoot.Children.Add(txt);
            }
                else if ((obj.RowStatus == rowStatus.Input || obj.RowStatus == rowStatus.InputAutoTab  ) && obj.RowClassType == rowClassType.Simple && obj.RowDataType != rowDataType.AlphaNumericPassword)
                {                   
                    TextBox txt = new TextBox();
                    txt.Name = ControlNameValidate(obj.InputVariableName.Replace(" ", "").Replace("[", "_").Replace("]", "_"));
                    txt.Tag = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2;
                    int leftMargin = obj.Col * charSize + charExtraSize;
                    txt.Margin = new Thickness(leftMargin, 0, 0, 0);
                    txt.HorizontalAlignment = HorizontalAlignment.Left;
                    txt.VerticalAlignment = VerticalAlignment.Top;                    
                    txt.Width = WidthGet(obj);
                    txt.Visibility = Visibility.Hidden;                    
                    txt.Style = (Style) Application.Current.Resources["COBOLTextStyle"];  //(Style)FindResource("TextBoxControlTemplate");                          
                    txt.PreviewKeyDown += Txt_PreviewKeyUp;
                    txt.KeyDown += Txt_KeyDown;
                    txt.MaxLength = obj.MaxLength;

                    if (obj.RowStatus == rowStatus.InputAutoTab) {
                        txt.TextChanged += Txt_TextChanged;
                    }

                    Grid.SetRow(txt, Convert.ToInt32(obj.Line));
                    Grid.SetColumn(txt, 2);

                    if (obj.RowDataType == rowDataType.Numeric || obj.RowDataType == rowDataType.NumericBlankWhenZero || obj.RowDataType == rowDataType.NumberiBlankWhenZeroNoComma)
                    {
                        if (txt.MaxLength < 3)
                        {
                            txt.TextAlignment = TextAlignment.Center;
                        }
                        else
                        {
                            txt.TextAlignment = TextAlignment.Right;
                        }

                        if (obj.NumericFormat.ToLower().Contains("v") || obj.NumericFormat.Contains("."))
                        {
                            int decimalPlaces = 0;
                            bool isNegativeSignRight = false;
                            txt.PreviewTextInput += TxtDecimal_PreviewTextInput;
                            if (obj.NumericFormat.ToLower().Contains("v"))
                            {
                                string[] tmpPictureClauseData = obj.NumericFormat.Split('v');
                                decimalPlaces = tmpPictureClauseData[1].Replace(".", "").Replace(" ", "").Length;
                            }
                            else if (obj.NumericFormat.Contains("."))
                            {
                                string[] tmpPictureClauseData = obj.NumericFormat.Split('.');
                                if (tmpPictureClauseData[1].Contains("9(")) {
                                    decimalPlaces = Util.NumInt(tmpPictureClauseData[1].Replace("9(", "").Replace(")", ""));
                                } else {
                                    decimalPlaces = tmpPictureClauseData[1].Replace(".", "").Replace(" ", "").Length;
                                    if (tmpPictureClauseData[1].Contains("-")) {
                                        decimalPlaces--;
                                        isNegativeSignRight = true;
                                    }
                                }
                            }
                            txt.GotFocus += Numeric_GotFocus;
                            if (isNegativeSignRight)
                            {
                                if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                                {
                                    txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay,Converter = new ImpliedDecimalNegSignBackBWZConverter(),ConverterParameter= decimalPlaces });
                                }
                                else
                                {
                                    txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalNegSignBack(), ConverterParameter = decimalPlaces });
                                }
                            }
                            else
                            {
                                if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                                {
                                    txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalBWZConverter (), ConverterParameter = decimalPlaces });
                                } else {
                                    txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalConverter(), ConverterParameter = decimalPlaces });
                                }
                            }
                        }
                        else if (obj.NumericFormat.ToLower().Contains("z") && obj.NumericFormat.ToLower().Contains(",") && obj.NumericFormat.ToLower().Contains("9"))
                        {
                            txt.GotFocus += Numeric_GotFocus;
                            txt.LostFocus += integer_LostFocus;
                            txt.PreviewTextInput += TxtInteger_PreviewTextInput;

                            if (obj.RowDataType == rowDataType.NumericBlankWhenZero) {
                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerBWZConverter(), ConverterParameter = obj.NumericFormat });
                            }
                            else if (obj.RowDataType == rowDataType.NumberiBlankWhenZeroNoComma)
                            {
                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerBWZConverterNoComma(), ConverterParameter = obj.NumericFormat });
                            }
                            else {
                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerConverter(), ConverterParameter = obj.NumericFormat });
                            }

                        }
                        else if (!obj.NumericFormat.ToLower().Contains("z") && !obj.NumericFormat.ToLower().Contains(",") && !obj.NumericFormat.ToLower().Contains("(") && !obj.NumericFormat.ToLower().Contains(")") && !obj.NumericFormat.ToLower().Contains("v") && obj.NumericFormat.ToLower().Contains("9"))
                        {
                            txt.GotFocus += Numeric_GotFocus;
                            //txt.LostFocus += integer_LostFocus;
                            txt.PreviewTextInput += TxtInteger_PreviewTextInput;
                            
                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) {Mode = BindingMode.TwoWay, Converter = new IntegerLeftZeroesConverter(), ConverterParameter = obj.NumericFormat } );

                        }
                        else if (!obj.NumericFormat.ToLower().Contains("v") && !obj.NumericFormat.Contains(".") && !obj.NumericFormat.ToLower().Trim().Contains("x"))
                        {
                            if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                            {
                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerBWZConverter(), ConverterParameter = obj.NumericFormat });
                            }
                            else if (obj.RowDataType == rowDataType.NumberiBlankWhenZeroNoComma)
                            {
                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerBWZConverterNoComma(), ConverterParameter = obj.NumericFormat });
                            }
                            else if (obj.RowDataType == rowDataType.Numeric  && !obj.NumericFormat.ToLower().Contains("z") &&  !obj.NumericFormat.ToLower().Contains(",") &&  !obj.NumericFormat.ToLower().Contains("v") && !obj.NumericFormat.Contains(".") && !obj.NumericFormat.ToLower().Trim().Contains("x") &&  obj.NumericFormat.Contains("9(")  && obj.NumericFormat.Contains(")")) //&& obj.NumericFormat.Substring(obj.NumericFormat.Length -1,1) == ")")
                            {
                                txt.GotFocus += Numeric_GotFocus;                                
                                txt.PreviewTextInput += TxtInteger_PreviewTextInput;

                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerLeftZeroesConverter(), ConverterParameter = obj.NumericFormat });
                            }
                            else
                            {
                                txt.GotFocus += Numeric_GotFocus;
                                txt.LostFocus += integer_LostFocus;
                                txt.PreviewTextInput += TxtInteger_PreviewTextInput;

                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay });
                            }
                        }
                    }
                    else
                    {
                        if (txt.MaxLength < 3)
                        {
                            txt.TextAlignment = TextAlignment.Center;
                        }
                        else
                        {
                            txt.TextAlignment = TextAlignment.Left;
                        }
                        txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay });
                    }
                    LayoutRoot.Children.Add(txt);
                }
            }
        }

        public void GridAddControl(string groupNameLevel1)
        {
            if (LayoutRoot == null) return;

            int ctr = 0;

            //Debug.WriteLine("groupNameLevel1 --------------------->  " + groupNameLevel1 );

           
            foreach (var obj in ScreenDataCollection.Where(x => x.GroupNameLevel1.Equals(groupNameLevel1)))
            {
                ctr++;
                

                if (IsExitForm == true)
                {
                    break;
                }

                string groupName = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2;

                string line = obj.Line;
                int col = obj.Col;

                if ((obj.RowStatus == rowStatus.Display || obj.RowStatus == rowStatus.DisplayInput) && obj.RowClassType == rowClassType.Simple)
                {
                    if (LayoutRoot.Children != null)
                    {
                        bool isFound = false;
                        foreach (var  ctrl in   LayoutRoot.Children.OfType<TextBlock>().Where(x => x.Tag.Equals(groupName))) {
                            if (obj.Data1.Equals("/"))
                            {
                                if (Util.NumInt(line) == Grid.GetRow(ctrl) && ((col * charSize + charExtraSize) + 2) == ctrl.Margin.Left)
                                {
                                    isFound = true;
                                    break;
                                }
                            }
                            else
                            {
                                if (Util.NumInt(line) == Grid.GetRow(ctrl) && (col * charSize + charExtraSize) == ctrl.Margin.Left)
                                {
                                    isFound = true;
                                    break;
                                }
                            }
                        }
                     

                        if (isFound == false)
                        {
                            if ((obj.RowStatus == rowStatus.Display || obj.RowStatus == rowStatus.DisplayInput) && obj.RowClassType == rowClassType.Simple)
                            {
                                TextBlock lbl = new TextBlock();
                                lbl.Tag = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2;
                                lbl.Text = obj.Data1;
                                int leftMargin = obj.Col * charSize + charExtraSize;
                                lbl.Margin = new Thickness(leftMargin, 0, 0, 0);
                                lbl.HorizontalAlignment = HorizontalAlignment.Left;
                                lbl.VerticalAlignment = VerticalAlignment.Center;
                                lbl.FontFamily = new FontFamily("Courier New");
                                lbl.Visibility = Visibility.Hidden;
                                Grid.SetRow(lbl, Convert.ToInt32(obj.Line));
                                Grid.SetColumn(lbl, 2);

                                if (!string.IsNullOrWhiteSpace(obj.InputVariableName))
                                {
                                    lbl.Name = ControlNameValidate(obj.InputVariableName.Replace(" ", ""));
                                    lbl.SetBinding(TextBlock.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.OneWay });
                                }
                                if (obj.Data1.Equals("/"))
                                {
                                    leftMargin = (obj.Col * charSize + charExtraSize) + 2;
                                    lbl.Margin = new Thickness(leftMargin, 0, 0, 0);
                                }


                                LayoutRoot.Children.Add(lbl);
                            }
                        }

                    }
                }
                else if ((obj.RowStatus == rowStatus.Input || obj.RowStatus == rowStatus.InputAutoTab) && obj.RowClassType == rowClassType.Simple && obj.RowDataType == rowDataType.AlphaNumericPassword)
                {
                    if (LayoutRoot.Children != null)
                    {                        
                        bool isFound = false;

                        foreach (var ctrl in LayoutRoot.Children.OfType<TextBox>().Where(x => x.Tag.Equals(groupName)))
                        {                            
                            if (Util.NumInt(line) == Grid.GetRow(ctrl) && (col * charSize + charExtraSize) == ctrl.Margin.Left)
                            {
                                isFound = true;
                                break;
                            }
                        }
                       
                        if (isFound == false)
                        {
                            if ((obj.RowStatus == rowStatus.Input || obj.RowStatus == rowStatus.InputAutoTab) && obj.RowClassType == rowClassType.Simple && obj.RowDataType == rowDataType.AlphaNumericPassword)
                            {
                                // PasswordBox txt = new PasswordBox();
                                TextBox txt = new TextBox();

                                txt.Name = ControlNameValidate(obj.InputVariableName.Replace(" ", "").Replace("[", "_").Replace("]", "_"));
                                txt.Tag = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2;
                                int leftMargin = obj.Col * charSize + charExtraSize;
                                txt.Margin = new Thickness(leftMargin, 0, 0, 0);
                                txt.HorizontalAlignment = HorizontalAlignment.Left;
                                txt.VerticalAlignment = VerticalAlignment.Top;
                                txt.Width = WidthGet(obj);
                                txt.Visibility = Visibility.Hidden;
                                txt.Style = (Style)Application.Current.Resources["COBOLTextStyle"];  //(Style)FindResource("TextBoxControlTemplate");                          
                                txt.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                txt.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                txt.PreviewKeyDown += Txt_PreviewKeyUp;
                                txt.KeyDown += Txt_KeyDown;
                                txt.MaxLength = obj.MaxLength;

                                if (obj.RowStatus == rowStatus.InputAutoTab)
                                {
                                    txt.TextChanged += Txt_TextChanged;
                                }

                                Grid.SetRow(txt, Convert.ToInt32(obj.Line));
                                Grid.SetColumn(txt, 2);

                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay });
                                LayoutRoot.Children.Add(txt);
                            }
                        }
                    }
                }
                else if ((obj.RowStatus == rowStatus.Input || obj.RowStatus == rowStatus.InputAutoTab) && obj.RowClassType == rowClassType.Simple && obj.RowDataType != rowDataType.AlphaNumericPassword)
                {
                     if (LayoutRoot.Children != null)
                    {                        
                        bool isFound = false;

                        foreach (var ctrl in LayoutRoot.Children.OfType<TextBox>().Where(x => x.Tag.Equals(groupName)))
                        {                           
                            if (Util.NumInt(line) == Grid.GetRow(ctrl) && (col * charSize + charExtraSize) == ctrl.Margin.Left)
                            {
                                isFound = true;
                                break;
                            }
                        }
                       
                        if (isFound == false )
                        {
                            if ((obj.RowStatus == rowStatus.Input || obj.RowStatus == rowStatus.InputAutoTab) && obj.RowClassType == rowClassType.Simple && obj.RowDataType != rowDataType.AlphaNumericPassword)
                            {
                                TextBox txt = new TextBox();
                                txt.Name = ControlNameValidate(obj.InputVariableName.Replace(" ", "").Replace("[", "_").Replace("]", "_"));
                                txt.Tag = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2;
                                int leftMargin = obj.Col * charSize + charExtraSize;
                                txt.Margin = new Thickness(leftMargin, 0, 0, 0);
                                txt.HorizontalAlignment = HorizontalAlignment.Left;
                                txt.VerticalAlignment = VerticalAlignment.Top;
                                txt.Width = WidthGet(obj);
                                txt.Visibility = Visibility.Hidden;
                                txt.Style = (Style)Application.Current.Resources["COBOLTextStyle"];  //(Style)FindResource("TextBoxControlTemplate");                          
                                txt.PreviewKeyDown += Txt_PreviewKeyUp;
                                txt.KeyDown += Txt_KeyDown;
                                txt.MaxLength = obj.MaxLength;

                                if (obj.RowStatus == rowStatus.InputAutoTab)
                                {
                                    txt.TextChanged += Txt_TextChanged;
                                }

                                Grid.SetRow(txt, Convert.ToInt32(obj.Line));
                                Grid.SetColumn(txt, 2);

                                if (obj.RowDataType == rowDataType.Numeric || obj.RowDataType == rowDataType.NumericBlankWhenZero || obj.RowDataType == rowDataType.NumberiBlankWhenZeroNoComma)
                                {
                                    if (txt.MaxLength < 3)
                                    {
                                        txt.TextAlignment = TextAlignment.Center;
                                    }
                                    else
                                    {
                                        txt.TextAlignment = TextAlignment.Right;
                                    }

                                    if (obj.NumericFormat.ToLower().Contains("v") || obj.NumericFormat.Contains("."))
                                    {
                                        int decimalPlaces = 0;
                                        bool isNegativeSignRight = false;
                                        txt.PreviewTextInput += TxtDecimal_PreviewTextInput;
                                        if (obj.NumericFormat.ToLower().Contains("v"))
                                        {
                                            string[] tmpPictureClauseData = obj.NumericFormat.Split('v');
                                            decimalPlaces = tmpPictureClauseData[1].Replace(".", "").Replace(" ", "").Length;
                                        }
                                        else if (obj.NumericFormat.Contains("."))
                                        {
                                            string[] tmpPictureClauseData = obj.NumericFormat.Split('.');
                                            if (tmpPictureClauseData[1].Contains("9("))
                                            {
                                                decimalPlaces = Util.NumInt(tmpPictureClauseData[1].Replace("9(", "").Replace(")", ""));
                                            }
                                            else
                                            {
                                                decimalPlaces = tmpPictureClauseData[1].Replace(".", "").Replace(" ", "").Length;
                                                if (tmpPictureClauseData[1].Contains("-"))
                                                {
                                                    decimalPlaces--;
                                                    isNegativeSignRight = true;
                                                }
                                            }
                                        }
                                        txt.GotFocus += Numeric_GotFocus;
                                        if (isNegativeSignRight)
                                        {
                                            if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                                            {
                                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalNegSignBackBWZConverter(), ConverterParameter = decimalPlaces });
                                            }
                                            else
                                            {
                                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalNegSignBack(), ConverterParameter = decimalPlaces });
                                            }
                                        }
                                        else
                                        {
                                            if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                                            {
                                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalBWZConverter(), ConverterParameter = decimalPlaces });
                                            }
                                            else
                                            {
                                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalConverter(), ConverterParameter = decimalPlaces });
                                            }
                                        }
                                    }
                                    else if (obj.NumericFormat.ToLower().Contains("z") && obj.NumericFormat.ToLower().Contains(",") && obj.NumericFormat.ToLower().Contains("9"))
                                    {
                                        txt.GotFocus += Numeric_GotFocus;
                                        txt.LostFocus += integer_LostFocus;
                                        txt.PreviewTextInput += TxtInteger_PreviewTextInput;

                                        if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                                        {
                                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerBWZConverter(), ConverterParameter = obj.NumericFormat });
                                        }
                                        else if (obj.RowDataType == rowDataType.NumberiBlankWhenZeroNoComma)
                                        {
                                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerBWZConverterNoComma(), ConverterParameter = obj.NumericFormat });
                                        }
                                        else
                                        {
                                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerConverter(), ConverterParameter = obj.NumericFormat });
                                        }

                                    }
                                    else if (!obj.NumericFormat.ToLower().Contains("z") && !obj.NumericFormat.ToLower().Contains(",") && !obj.NumericFormat.ToLower().Contains("(") && !obj.NumericFormat.ToLower().Contains(")") && !obj.NumericFormat.ToLower().Contains("v") && obj.NumericFormat.ToLower().Contains("9"))
                                    {
                                        txt.GotFocus += Numeric_GotFocus;
                                        //txt.LostFocus += integer_LostFocus;
                                        txt.PreviewTextInput += TxtInteger_PreviewTextInput;

                                        txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerLeftZeroesConverter(), ConverterParameter = obj.NumericFormat });

                                    }
                                    else if (!obj.NumericFormat.ToLower().Contains("v") && !obj.NumericFormat.Contains(".") && !obj.NumericFormat.ToLower().Trim().Contains("x"))
                                    {
                                        if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                                        {
                                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerBWZConverter(), ConverterParameter = obj.NumericFormat });
                                        }
                                        else if (obj.RowDataType == rowDataType.NumberiBlankWhenZeroNoComma)
                                        {
                                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerBWZConverterNoComma(), ConverterParameter = obj.NumericFormat });
                                        }
                                        else if (obj.RowDataType == rowDataType.Numeric && !obj.NumericFormat.ToLower().Contains("z") && !obj.NumericFormat.ToLower().Contains(",") && !obj.NumericFormat.ToLower().Contains("v") && !obj.NumericFormat.Contains(".") && !obj.NumericFormat.ToLower().Trim().Contains("x") && obj.NumericFormat.Contains("9(") && obj.NumericFormat.Contains(")")) //&& obj.NumericFormat.Substring(obj.NumericFormat.Length -1,1) == ")")
                                        {
                                            txt.GotFocus += Numeric_GotFocus;
                                            txt.PreviewTextInput += TxtInteger_PreviewTextInput;

                                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerLeftZeroesConverter(), ConverterParameter = obj.NumericFormat });
                                        }
                                        else
                                        {
                                            txt.GotFocus += Numeric_GotFocus;
                                            txt.LostFocus += integer_LostFocus;
                                            txt.PreviewTextInput += TxtInteger_PreviewTextInput;

                                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay });
                                        }
                                    }
                                }
                                else
                                {
                                    if (txt.MaxLength < 3)
                                    {
                                        txt.TextAlignment = TextAlignment.Center;
                                    }
                                    else
                                    {
                                        txt.TextAlignment = TextAlignment.Left;
                                    }
                                    txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay });
                                }
                                LayoutRoot.Children.Add(txt);
                            }
                        }
                    }
                }                
            }
        }

        public void GridAddControl(string groupNameLevel1, string groupNameLevel2)
        {
            if (LayoutRoot == null) return;

            int ctr = 0;

           // Debug.WriteLine("groupNameLevel1 ------------------------------------->>>  " + groupNameLevel1 + " " + "groupNameLevel2   ---> " + groupNameLevel2);

            foreach (var obj in ScreenDataCollection.Where(x => x.GroupNameLevel1.Equals(groupNameLevel1) && x.GroupNameLevel2.Equals(groupNameLevel2)))
            {
                ctr++;


                if (IsExitForm == true)
                {
                    break;
                }

                string groupName = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2;

                string line = obj.Line;
                int col = obj.Col;

                if ((obj.RowStatus == rowStatus.Display || obj.RowStatus == rowStatus.DisplayInput) && obj.RowClassType == rowClassType.Simple)
                {
                    if (LayoutRoot.Children != null)
                    {
                        
                        bool isFound = false;

                        foreach (var ctrl in LayoutRoot.Children.OfType<TextBlock>().Where(x => x.Tag.Equals(groupName)))
                        {
                            if (obj.Data1.Equals("/"))
                            {
                                if (Util.NumInt(line) == Grid.GetRow(ctrl) && ((col * charSize + charExtraSize) + 2) == ctrl.Margin.Left)
                                {
                                    isFound = true;
                                    break;
                                }
                            }
                            else
                            {
                                if (Util.NumInt(line) == Grid.GetRow(ctrl) && (col * charSize + charExtraSize) == ctrl.Margin.Left)
                                {
                                    isFound = true;
                                    break;
                                }
                            }
                        }
                       

                        if (isFound == false)
                        {
                            if ((obj.RowStatus == rowStatus.Display || obj.RowStatus == rowStatus.DisplayInput) && obj.RowClassType == rowClassType.Simple)
                            {
                                TextBlock lbl = new TextBlock();
                                lbl.Tag = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2;
                                lbl.Text = obj.Data1;
                                int leftMargin = obj.Col * charSize + charExtraSize;
                                lbl.Margin = new Thickness(leftMargin, 0, 0, 0);
                                lbl.HorizontalAlignment = HorizontalAlignment.Left;
                                lbl.VerticalAlignment = VerticalAlignment.Center;
                                lbl.FontFamily = new FontFamily("Courier New");
                                lbl.Visibility = Visibility.Hidden;
                                Grid.SetRow(lbl, Convert.ToInt32(obj.Line));
                                Grid.SetColumn(lbl, 2);

                                if (!string.IsNullOrWhiteSpace(obj.InputVariableName))
                                {
                                    lbl.Name = ControlNameValidate(obj.InputVariableName.Replace(" ", ""));
                                    lbl.SetBinding(TextBlock.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.OneWay });
                                }
                                if (obj.Data1.Equals("/"))
                                {
                                    leftMargin = (obj.Col * charSize + charExtraSize) + 2;
                                    lbl.Margin = new Thickness(leftMargin, 0, 0, 0);
                                }


                                LayoutRoot.Children.Add(lbl);
                            }
                        }

                    }
                }
                else if ((obj.RowStatus == rowStatus.Input || obj.RowStatus == rowStatus.InputAutoTab) && obj.RowClassType == rowClassType.Simple && obj.RowDataType == rowDataType.AlphaNumericPassword)
                {
                    if (LayoutRoot.Children != null)
                    {                        
                        bool isFound = false;

                        foreach (var ctrl in LayoutRoot.Children.OfType<TextBox>().Where(x => x.Tag.Equals(groupName)))
                        {                         
                            if (Util.NumInt(line) == Grid.GetRow(ctrl) && (col * charSize + charExtraSize) == ctrl.Margin.Left)
                            {
                                isFound = true;
                                break;
                            }
                        }
                       
                        if (isFound == false)
                        {
                            if ((obj.RowStatus == rowStatus.Input || obj.RowStatus == rowStatus.InputAutoTab) && obj.RowClassType == rowClassType.Simple && obj.RowDataType == rowDataType.AlphaNumericPassword)
                            {
                                // PasswordBox txt = new PasswordBox();
                                TextBox txt = new TextBox();

                                txt.Name = ControlNameValidate(obj.InputVariableName.Replace(" ", "").Replace("[", "_").Replace("]", "_"));
                                txt.Tag = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2;
                                int leftMargin = obj.Col * charSize + charExtraSize;
                                txt.Margin = new Thickness(leftMargin, 0, 0, 0);
                                txt.HorizontalAlignment = HorizontalAlignment.Left;
                                txt.VerticalAlignment = VerticalAlignment.Top;
                                txt.Width = WidthGet(obj);
                                txt.Visibility = Visibility.Hidden;
                                txt.Style = (Style)Application.Current.Resources["COBOLTextStyle"];  //(Style)FindResource("TextBoxControlTemplate");                          
                                txt.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                txt.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                txt.PreviewKeyDown += Txt_PreviewKeyUp;
                                txt.KeyDown += Txt_KeyDown;
                                txt.MaxLength = obj.MaxLength;

                                if (obj.RowStatus == rowStatus.InputAutoTab)
                                {
                                    txt.TextChanged += Txt_TextChanged;
                                }

                                Grid.SetRow(txt, Convert.ToInt32(obj.Line));
                                Grid.SetColumn(txt, 2);

                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay });
                                LayoutRoot.Children.Add(txt);
                            }
                        }
                    }
                }
                else if ((obj.RowStatus == rowStatus.Input || obj.RowStatus == rowStatus.InputAutoTab) && obj.RowClassType == rowClassType.Simple && obj.RowDataType != rowDataType.AlphaNumericPassword)
                {
                    if (LayoutRoot.Children != null)
                    {                        
                        bool isFound = false;

                        foreach (var ctrl in LayoutRoot.Children.OfType<TextBox>().Where(x => x.Tag.Equals(groupName)))
                        {                         
                            if (Util.NumInt(line) == Grid.GetRow(ctrl) && (col * charSize + charExtraSize) == ctrl.Margin.Left)
                            {
                                isFound = true;
                                break;
                            }
                        }
                      
                        if (isFound == false)
                        {
                            if ((obj.RowStatus == rowStatus.Input || obj.RowStatus == rowStatus.InputAutoTab) && obj.RowClassType == rowClassType.Simple && obj.RowDataType != rowDataType.AlphaNumericPassword)
                            {
                                TextBox txt = new TextBox();
                                txt.Name = ControlNameValidate(obj.InputVariableName.Replace(" ", "").Replace("[", "_").Replace("]", "_"));
                                txt.Tag = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2;
                                int leftMargin = obj.Col * charSize + charExtraSize;
                                txt.Margin = new Thickness(leftMargin, 0, 0, 0);
                                txt.HorizontalAlignment = HorizontalAlignment.Left;
                                txt.VerticalAlignment = VerticalAlignment.Top;
                                txt.Width = WidthGet(obj);
                                txt.Visibility = Visibility.Hidden;
                                txt.Style = (Style)Application.Current.Resources["COBOLTextStyle"];  //(Style)FindResource("TextBoxControlTemplate");                          
                                txt.PreviewKeyDown += Txt_PreviewKeyUp;
                                txt.KeyDown += Txt_KeyDown;
                                txt.MaxLength = obj.MaxLength;

                                if (obj.RowStatus == rowStatus.InputAutoTab)
                                {
                                    txt.TextChanged += Txt_TextChanged;
                                }

                                Grid.SetRow(txt, Convert.ToInt32(obj.Line));
                                Grid.SetColumn(txt, 2);

                                if (obj.RowDataType == rowDataType.Numeric || obj.RowDataType == rowDataType.NumericBlankWhenZero || obj.RowDataType == rowDataType.NumberiBlankWhenZeroNoComma)
                                {
                                    if (txt.MaxLength < 3)
                                    {
                                        txt.TextAlignment = TextAlignment.Center;
                                    }
                                    else
                                    {
                                        txt.TextAlignment = TextAlignment.Right;
                                    }

                                    if (obj.NumericFormat.ToLower().Contains("v") || obj.NumericFormat.Contains("."))
                                    {
                                        int decimalPlaces = 0;
                                        bool isNegativeSignRight = false;
                                        txt.PreviewTextInput += TxtDecimal_PreviewTextInput;
                                        if (obj.NumericFormat.ToLower().Contains("v"))
                                        {
                                            string[] tmpPictureClauseData = obj.NumericFormat.Split('v');
                                            decimalPlaces = tmpPictureClauseData[1].Replace(".", "").Replace(" ", "").Length;
                                        }
                                        else if (obj.NumericFormat.Contains("."))
                                        {
                                            string[] tmpPictureClauseData = obj.NumericFormat.Split('.');
                                            if (tmpPictureClauseData[1].Contains("9("))
                                            {
                                                decimalPlaces = Util.NumInt(tmpPictureClauseData[1].Replace("9(", "").Replace(")", ""));
                                            }
                                            else
                                            {
                                                decimalPlaces = tmpPictureClauseData[1].Replace(".", "").Replace(" ", "").Length;
                                                if (tmpPictureClauseData[1].Contains("-"))
                                                {
                                                    decimalPlaces--;
                                                    isNegativeSignRight = true;
                                                }
                                            }
                                        }
                                        txt.GotFocus += Numeric_GotFocus;
                                        if (isNegativeSignRight)
                                        {
                                            if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                                            {
                                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalNegSignBackBWZConverter(), ConverterParameter = decimalPlaces });
                                            }
                                            else
                                            {
                                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalNegSignBack(), ConverterParameter = decimalPlaces });
                                            }
                                        }
                                        else
                                        {
                                            if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                                            {
                                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalBWZConverter(), ConverterParameter = decimalPlaces });
                                            }
                                            else
                                            {
                                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalConverter(), ConverterParameter = decimalPlaces });
                                            }
                                        }
                                    }
                                    else if (obj.NumericFormat.ToLower().Contains("z") && obj.NumericFormat.ToLower().Contains(",") && obj.NumericFormat.ToLower().Contains("9"))
                                    {
                                        txt.GotFocus += Numeric_GotFocus;
                                        txt.LostFocus += integer_LostFocus;
                                        txt.PreviewTextInput += TxtInteger_PreviewTextInput;

                                        if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                                        {
                                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerBWZConverter(), ConverterParameter = obj.NumericFormat });
                                        }
                                        else if (obj.RowDataType == rowDataType.NumberiBlankWhenZeroNoComma)
                                        {
                                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerBWZConverterNoComma(), ConverterParameter = obj.NumericFormat });
                                        }
                                        else
                                        {
                                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerConverter(), ConverterParameter = obj.NumericFormat });
                                        }

                                    }
                                    else if (!obj.NumericFormat.ToLower().Contains("z") && !obj.NumericFormat.ToLower().Contains(",") && !obj.NumericFormat.ToLower().Contains("(") && !obj.NumericFormat.ToLower().Contains(")") && !obj.NumericFormat.ToLower().Contains("v") && obj.NumericFormat.ToLower().Contains("9"))
                                    {
                                        txt.GotFocus += Numeric_GotFocus;
                                        //txt.LostFocus += integer_LostFocus;
                                        txt.PreviewTextInput += TxtInteger_PreviewTextInput;

                                        txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerLeftZeroesConverter(), ConverterParameter = obj.NumericFormat });

                                    }
                                    else if (!obj.NumericFormat.ToLower().Contains("v") && !obj.NumericFormat.Contains(".") && !obj.NumericFormat.ToLower().Trim().Contains("x"))
                                    {
                                        if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                                        {
                                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerBWZConverter(), ConverterParameter = obj.NumericFormat });
                                        }
                                        else if (obj.RowDataType == rowDataType.NumberiBlankWhenZeroNoComma)
                                        {
                                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerBWZConverterNoComma(), ConverterParameter = obj.NumericFormat });
                                        }
                                        else if (obj.RowDataType == rowDataType.Numeric && !obj.NumericFormat.ToLower().Contains("z") && !obj.NumericFormat.ToLower().Contains(",") && !obj.NumericFormat.ToLower().Contains("v") && !obj.NumericFormat.Contains(".") && !obj.NumericFormat.ToLower().Trim().Contains("x") && obj.NumericFormat.Contains("9(") && obj.NumericFormat.Contains(")")) //&& obj.NumericFormat.Substring(obj.NumericFormat.Length -1,1) == ")")
                                        {
                                            txt.GotFocus += Numeric_GotFocus;
                                            txt.PreviewTextInput += TxtInteger_PreviewTextInput;

                                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay, Converter = new IntegerLeftZeroesConverter(), ConverterParameter = obj.NumericFormat });
                                        }
                                        else
                                        {
                                            txt.GotFocus += Numeric_GotFocus;
                                            txt.LostFocus += integer_LostFocus;
                                            txt.PreviewTextInput += TxtInteger_PreviewTextInput;

                                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay });
                                        }
                                    }
                                }
                                else
                                {
                                    if (txt.MaxLength < 3)
                                    {
                                        txt.TextAlignment = TextAlignment.Center;
                                    }
                                    else
                                    {
                                        txt.TextAlignment = TextAlignment.Left;
                                    }
                                    txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName) { Mode = BindingMode.TwoWay });
                                }
                                LayoutRoot.Children.Add(txt);
                            }
                        }
                    }
                }                
            }
        }

      

        private void Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Length > 0 ) {
                if (((TextBox)sender).Text.Trim().Length == ((TextBox)sender).MaxLength)
                {                   
                    ((TextBox)sender).Focus();
                     SendKeys.Send(Key.Enter);
                }
            }
        }

        protected void GridInputControlAllDisabled()
        {
            if (LayoutRoot == null) return;

            foreach (object obj in LayoutRoot.Children.OfType<TextBox>())
            {                
                   TextBox tb = obj as TextBox;                    
                    tb.IsReadOnly = true;                
            }
        }

        protected void InputControlEnableBak(string controlName)
        {
            if (LayoutRoot == null) return;

            foreach (object obj in LayoutRoot.Children)
            {
                if (obj.GetType().Name.Equals("TextBox"))
                {
                    TextBox tb = obj as TextBox;
                    tb.BorderThickness = new Thickness(1);
                    if (tb.Name.Trim().ToLower().Equals(controlName.ToLower().Replace("[", "_").Replace("]", "_")))
                    {
                        tb.BorderThickness = new Thickness(2);
                        tb.IsEnabled = true;
                        tb.IsReadOnly = false;
                        tb.SelectAll();
                        tb.Focus();
                        break;
                    }
                }
            }
        }

        protected TextBox InputControlEnable(string controlName)
        {
            if (LayoutRoot == null) return null;
            TextBox tmpTextBox = null;
            tmpTextBox = new TextBox();

            foreach (object obj in LayoutRoot.Children.OfType<TextBox>().Where(x => x.Name.Trim().ToLower().Equals(controlName.ToLower().Replace("[", "_").Replace("]", "_"))))
            {                
                    TextBox tb = obj as TextBox;
                    tb.BorderThickness = new Thickness(1);
                    if (tb.Name.Trim().ToLower().Equals(controlName.ToLower().Replace("[", "_").Replace("]", "_")))
                    {
                        tb.BorderThickness = new Thickness(2);
                        tb.IsEnabled = true;
                        tb.IsReadOnly = false;                   
                        tb.SelectAll();
                        tb.Focus();
                        tmpTextBox = tb;
                        break;
                    }                
            }
            return tmpTextBox;
        }

        protected TextBox InputControlEnableBak(string controlName, string groupNameLevel1, string groupNameLevel2)
        {
            if (LayoutRoot == null) return null;
            TextBox tmpTextBox = null;
            tmpTextBox = new TextBox();

            foreach (object obj in LayoutRoot.Children)
            {
                if (obj.GetType().Name.Equals("TextBox"))
                {
                    TextBox tb = obj as TextBox;
                    tb.BorderThickness = new Thickness(1);
                    if (tb.Name.Trim().ToLower().Equals(controlName.ToLower().Replace("[", "_").Replace("]", "_")))
                    {
                        string groupName = groupNameLevel1 + "|" + groupNameLevel2;
                        if (tb.Tag.ToString().ToLower().Replace(".", "").Equals(groupName.ToLower().Replace(".", "")))
                        {
                            tb.BorderThickness = new Thickness(2);
                            tb.IsEnabled = true;
                            tb.IsReadOnly = false;
                            tb.SelectAll();
                            tb.Focus();
                            tmpTextBox = tb;
                            break;
                        }
                    }
                }
            }
            return tmpTextBox;
        } 

        protected TextBox InputControlEnable(string controlName, string groupNameLevel1, string groupNameLevel2)
        {
            if (LayoutRoot == null) return null;
            TextBox tmpTextBox = null;
            tmpTextBox = new TextBox();

            foreach (object obj in LayoutRoot.Children.OfType<TextBox>().Where(x => x.Name.Trim().ToLower().Equals(controlName.ToLower().Replace("[", "_").Replace("]", "_"))))
            {                
                    TextBox tb = obj as TextBox;
                    tb.BorderThickness = new Thickness(1);
                    if (tb.Name.Trim().ToLower().Equals(controlName.ToLower().Replace("[", "_").Replace("]", "_")))
                    {
                        string groupName = groupNameLevel1 + "|" + groupNameLevel2;
                        if (tb.Tag.ToString().ToLower().Replace(".", "").Equals(groupName.ToLower().Replace(".", "")))
                        {
                            tb.BorderThickness = new Thickness(2);
                            tb.IsEnabled = true;
                            tb.IsReadOnly = false;                     
                            tb.SelectAll();
                            tb.Focus();
                            tmpTextBox = tb;
                            break;
                        }
                    }               
            }
            return tmpTextBox;
        } 

        private bool ContolExist(string controlName)
        {
            bool exist = false;
            if (LayoutRoot == null) return true;

            foreach(object obj in LayoutRoot.Children)
            {
                if (obj.GetType().Name.Equals("TextBlock"))
                {
                    TextBlock tb = obj as TextBlock;
                    if (tb.Name.Trim().ToLower().Equals(controlName.ToLower()))
                    {
                        exist = true;
                        break;
                    }
                }
                else if (obj.GetType().Name.Equals("TextBox")  )
                {
                    TextBox tb = obj as TextBox;
                    if (tb.Name.Trim().ToLower().Equals(controlName.ToLower().Replace("[", "_").Replace("]", "_")))
                    {
                        exist = true;
                        break;
                    }
                }
            }
            return exist;
        }

        protected void GridAddControlList(string groupName, int initialRow = 12, int totalRowsToDisplay = 5)
        {
            if (LayoutRoot == null) return;

            int InputVariableNameIndex = 0;
            for (int row = initialRow; row < (initialRow + totalRowsToDisplay); row++)
            {
                foreach (var obj in ScreenDataCollection.Where(x => x.GroupNameLevel1 == groupName).OrderBy(y => y.Col))
                {
                    if (obj.RowStatus == rowStatus.Display && obj.RowClassType == rowClassType.Multiple)
                    {
                        TextBlock lbl = new TextBlock();
                        lbl.Name = obj.GroupNameLevel1.Replace("-", "_").Replace(".", "_") + row.ToString() + "_" + obj.Col.ToString();
                        lbl.Tag = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2;
                        lbl.Text = obj.Data1;
                        int leftMargin = obj.Col * 10;
                        lbl.Margin = new Thickness(leftMargin, 0, 0, 0);
                        lbl.HorizontalAlignment = HorizontalAlignment.Left;
                        lbl.VerticalAlignment = VerticalAlignment.Top;
                        lbl.FontFamily = new FontFamily("Arial");
                        lbl.Visibility = Visibility.Visible;
                        Grid.SetRow(lbl, row); //Convert.ToInt32(obj.Line));
                        Grid.SetColumn(lbl, 2);
                        LayoutRoot.Children.Add(lbl);

                    }
                    else if (obj.RowStatus == rowStatus.Input && obj.RowClassType == rowClassType.Multiple)
                    {
                        TextBox txt = new TextBox();
                        txt.Name = obj.GroupNameLevel1.Replace("-", "_").Replace(".", "_").Replace("[", "_").Replace("]", "_") + row.ToString() + "_" + obj.Col.ToString(); //ex: scr_claim_var_12_1  ==> 12 row 1 column
                        txt.Tag = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2; //ex:  scr-claim-var.
                        int leftMargin = obj.Col * 10;
                        txt.Margin = new Thickness(leftMargin, 0, 0, 0);
                        txt.HorizontalAlignment = HorizontalAlignment.Left;
                        txt.VerticalAlignment = VerticalAlignment.Top;
                        txt.FontFamily = new FontFamily("Arial");
                        txt.Width = WidthGet(obj);
                        txt.Visibility = Visibility.Visible;
                        txt.PreviewKeyUp += Txt_PreviewKeyUp;
                        txt.KeyDown += Txt_KeyDown;
                        txt.MaxLength = obj.MaxLength;
                        txt.Style = (Style)Application.Current.Resources["CoreTextStyle"];
                        Grid.SetRow(txt, row); //Convert.ToInt32(obj.Line));
                        Grid.SetColumn(txt, 2);

                        InputVariableNameIndex++;

                        if (obj.RowDataType == rowDataType.Numeric || obj.RowDataType == rowDataType.NumericBlankWhenZero)
                        {
                            txt.TextAlignment = TextAlignment.Right;
                            if (obj.NumericFormat.ToLower().Contains("v") || obj.NumericFormat.Contains("."))
                            {
                                int decimalPlaces = 0;
                                bool isNegativeSignRight = false;
                                txt.PreviewTextInput += TxtDecimal_PreviewTextInput;
                                if (obj.NumericFormat.ToLower().Contains("v"))
                                {
                                    string[] tmpPictureClauseData = obj.NumericFormat.Split('v');
                                    decimalPlaces = tmpPictureClauseData[1].Replace(".", "").Replace(" ", "").Length;
                                }
                                else if (obj.NumericFormat.Contains("."))
                                {
                                    string[] tmpPictureClauseData = obj.NumericFormat.Split('.');
                                    decimalPlaces = tmpPictureClauseData[1].Replace(".", "").Replace(" ", "").Length;
                                    if (tmpPictureClauseData[1].Contains("-"))
                                    {
                                        decimalPlaces--;
                                        isNegativeSignRight = true;
                                    }
                                }
                                txt.GotFocus += Numeric_GotFocus;
                                if (isNegativeSignRight)
                                {
                                    if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                                    {
                                        txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex +"]") { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalNegSignBackBWZConverter(), ConverterParameter = decimalPlaces });
                                    }
                                    else
                                    {
                                        txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex + "]") { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalNegSignBack(), ConverterParameter = decimalPlaces });
                                    }
                                }
                                else
                                {
                                    if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                                    {
                                        txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex + "]") { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalBWZConverter(), ConverterParameter = decimalPlaces });
                                    }
                                    else
                                    {
                                        txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex + "]") { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalConverter(), ConverterParameter = decimalPlaces });
                                    }
                                }
                            }
                            else if (obj.NumericFormat.ToLower().Contains("z") && obj.NumericFormat.ToLower().Contains(",") && obj.NumericFormat.ToLower().Contains("9"))
                            {
                                txt.GotFocus += Numeric_GotFocus;
                                txt.LostFocus += integer_LostFocus;
                                txt.PreviewTextInput += TxtInteger_PreviewTextInput;

                                if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                                {
                                    txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex + "]") { Mode = BindingMode.TwoWay, Converter = new IntegerBWZConverter(), ConverterParameter = obj.NumericFormat });
                                }
                                else
                                {
                                    txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex + "]") { Mode = BindingMode.TwoWay, Converter = new IntegerConverter(), ConverterParameter = obj.NumericFormat });
                                }

                            }
                            else if (!obj.NumericFormat.ToLower().Contains("v") && !obj.NumericFormat.Contains(".") && !obj.NumericFormat.ToLower().Trim().Contains("x"))
                            {
                                txt.GotFocus += Numeric_GotFocus;
                                txt.LostFocus += integer_LostFocus;
                                txt.PreviewTextInput += TxtInteger_PreviewTextInput;

                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex + "]") { Mode = BindingMode.TwoWay });
                            }
                        }
                        else
                        {
                            txt.TextAlignment = TextAlignment.Left;
                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex + "]") { Mode = BindingMode.TwoWay });
                        }

                        LayoutRoot.Children.Add(txt);
                    }
                }
            }
        }

        protected void GridAddControlListRowByRow(string groupName, int rowSet, int columnSet )
        {
            if (LayoutRoot == null) return;

            int InputVariableNameIndex = 0;
            for (int row = rowSet; row < rowSet; row++)
            {
                foreach (var obj in ScreenDataCollection.Where(x => x.GroupNameLevel1 == groupName).OrderBy(y => y.Col))
                {
                    if (obj.RowStatus == rowStatus.Display && obj.RowClassType == rowClassType.Multiple)
                    {
                        TextBlock lbl = new TextBlock();
                        lbl.Name = obj.GroupNameLevel1.Replace("-", "_").Replace(".", "_") + row.ToString() + "_" + obj.Col.ToString();

                        if (!ContolExist(lbl.Name)) {
                            lbl.Tag = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2;
                            lbl.Text = obj.Data1;
                            int leftMargin = columnSet * 10; //obj.Col * 10;
                            lbl.Margin = new Thickness(leftMargin, 0, 0, 0);
                            lbl.HorizontalAlignment = HorizontalAlignment.Left;
                            lbl.VerticalAlignment = VerticalAlignment.Top;
                            lbl.FontFamily = new FontFamily("Arial");
                            lbl.Visibility = Visibility.Visible;
                            Grid.SetRow(lbl, row); //Convert.ToInt32(obj.Line));
                            Grid.SetColumn(lbl, 2);
                            LayoutRoot.Children.Add(lbl);
                        }

                    }
                    else if (obj.RowStatus == rowStatus.Input && obj.RowClassType == rowClassType.Multiple)
                    {
                        TextBox txt = new TextBox();
                        txt.Name = obj.GroupNameLevel1.Replace("-", "_").Replace(".", "_").Replace("[", "_").Replace("]", "_") + row.ToString() + "_" + obj.Col.ToString(); //ex: scr_claim_var_12_1  ==>  row 12  column 1

                        if (ContolExist(txt.Name)) continue;

                        txt.Tag = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2; //ex:  scr-claim-var.
                        int leftMargin = columnSet * 10; //obj.Col * 10;
                        txt.Margin = new Thickness(leftMargin, 0, 0, 0);
                        txt.HorizontalAlignment = HorizontalAlignment.Left;
                        txt.VerticalAlignment = VerticalAlignment.Top;
                        txt.FontFamily = new FontFamily("Arial");
                        txt.Width = WidthGet(obj);
                        txt.Visibility = Visibility.Visible;
                        txt.PreviewKeyUp += Txt_PreviewKeyUp;
                        txt.KeyDown += Txt_KeyDown;
                        txt.MaxLength = obj.MaxLength;
                        txt.Style = (Style)Application.Current.Resources["CoreTextStyle"];
                        Grid.SetRow(txt, row); 
                        Grid.SetColumn(txt, 2);

                        InputVariableNameIndex++;

                        if (obj.RowDataType == rowDataType.Numeric || obj.RowDataType == rowDataType.NumericBlankWhenZero)
                        {
                            txt.TextAlignment = TextAlignment.Right;
                            if (obj.NumericFormat.ToLower().Contains("v") || obj.NumericFormat.Contains("."))
                            {
                                int decimalPlaces = 0;
                                bool isNegativeSignRight = false;
                                txt.PreviewTextInput += TxtDecimal_PreviewTextInput;
                                if (obj.NumericFormat.ToLower().Contains("v"))
                                {
                                    string[] tmpPictureClauseData = obj.NumericFormat.Split('v');
                                    decimalPlaces = tmpPictureClauseData[1].Replace(".", "").Replace(" ", "").Length;
                                }
                                else if (obj.NumericFormat.Contains("."))
                                {
                                    string[] tmpPictureClauseData = obj.NumericFormat.Split('.');
                                    decimalPlaces = tmpPictureClauseData[1].Replace(".", "").Replace(" ", "").Length;
                                    if (tmpPictureClauseData[1].Contains("-"))
                                    {
                                        decimalPlaces--;
                                        isNegativeSignRight = true;
                                    }
                                }
                                txt.GotFocus += Numeric_GotFocus;
                                if (isNegativeSignRight)
                                {
                                    if (obj.RowDataType == rowDataType.NumericBlankWhenZero)   //ex:  Text =" {Binding Array[1]}"
                                    {
                                        txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex + "]") { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalNegSignBackBWZConverter(), ConverterParameter = decimalPlaces });
                                    }
                                    else
                                    {
                                        txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex + "]") { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalNegSignBack(), ConverterParameter = decimalPlaces });
                                    }
                                }
                                else
                                {
                                    if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                                    {
                                        txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex + "]") { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalBWZConverter(), ConverterParameter = decimalPlaces });
                                    }
                                    else
                                    {
                                        txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex + "]") { Mode = BindingMode.TwoWay, Converter = new ImpliedDecimalConverter(), ConverterParameter = decimalPlaces });
                                    }
                                }
                            }
                            else if (obj.NumericFormat.ToLower().Contains("z") && obj.NumericFormat.ToLower().Contains(",") && obj.NumericFormat.ToLower().Contains("9"))
                            {
                                txt.GotFocus += Numeric_GotFocus;
                                txt.LostFocus += integer_LostFocus;
                                txt.PreviewTextInput += TxtInteger_PreviewTextInput;

                                if (obj.RowDataType == rowDataType.NumericBlankWhenZero)
                                {
                                    txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex + "]") { Mode = BindingMode.TwoWay, Converter = new IntegerBWZConverter(), ConverterParameter = obj.NumericFormat });
                                }
                                else
                                {
                                    txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex + "]") { Mode = BindingMode.TwoWay, Converter = new IntegerConverter(), ConverterParameter = obj.NumericFormat });
                                }

                            }
                            else if (!obj.NumericFormat.ToLower().Contains("v") && !obj.NumericFormat.Contains(".") && !obj.NumericFormat.ToLower().Trim().Contains("x"))
                            {
                                txt.GotFocus += Numeric_GotFocus;
                                txt.LostFocus += integer_LostFocus;
                                txt.PreviewTextInput += TxtInteger_PreviewTextInput;

                                txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex + "]") { Mode = BindingMode.TwoWay });
                            }
                        }
                        else
                        {
                            txt.TextAlignment = TextAlignment.Left;
                            txt.SetBinding(TextBox.TextProperty, new Binding(obj.InputVariableName + "[" + InputVariableNameIndex + "]") { Mode = BindingMode.TwoWay });
                        }

                        LayoutRoot.Children.Add(txt);
                    }
                }
            }
        }
        protected void GridAddControlListRow(string groupName, int row, int totalRowsToDisplay = 5, int initialRow = 12)
        {
            if (LayoutRoot == null) return;

            if (row >= (initialRow + totalRowsToDisplay))
            {
                EraseRowRange(12, 23);
                row = initialRow;
            }

            foreach (var obj in ScreenDataCollection.Where(x => x.GroupNameLevel1 == groupName).OrderBy(y => y.Col))
            {
                if (obj.RowStatus == rowStatus.Display && obj.RowClassType == rowClassType.Multiple)
                {
                    TextBlock lbl = new TextBlock();
                    lbl.Name = obj.GroupNameLevel1.Replace("-", "_").Replace(".", "_") + row.ToString() + "_" + obj.Col.ToString();
                    lbl.Tag = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2;
                    lbl.Text = obj.Data1;
                    int leftMargin = obj.Col * 10;
                    lbl.Margin = new Thickness(leftMargin, 0, 0, 0);
                    lbl.HorizontalAlignment = HorizontalAlignment.Left;
                    lbl.VerticalAlignment = VerticalAlignment.Top;
                    lbl.FontFamily = new FontFamily("Arial");
                    lbl.Visibility = Visibility.Visible;
                    Grid.SetRow(lbl, row);
                    Grid.SetColumn(lbl, 2);
                    LayoutRoot.Children.Add(lbl);


                }
                else if (obj.RowStatus == rowStatus.Input && obj.RowClassType == rowClassType.Multiple)
                {
                    TextBox txt = new TextBox();
                    txt.Name = obj.GroupNameLevel1.Replace("-", "_").Replace(".", "_").Replace("[", "_").Replace("]", "_") + row.ToString() + "_" + obj.Col.ToString();
                    txt.Tag = obj.GroupNameLevel1 + "|" + obj.GroupNameLevel2;
                    int leftMargin = obj.Col * 10;
                    txt.Margin = new Thickness(leftMargin, 0, 0, 0);
                    txt.HorizontalAlignment = HorizontalAlignment.Left;
                    txt.VerticalAlignment = VerticalAlignment.Top;
                    txt.FontFamily = new FontFamily("Arial");
                    txt.Width = WidthGet(obj);
                    txt.Visibility = Visibility.Visible;
                    txt.PreviewKeyUp += Txt_PreviewKeyUp;
                    txt.KeyDown += Txt_KeyDown;
                    Grid.SetRow(txt, row);
                    Grid.SetColumn(txt, 2);
                    LayoutRoot.Children.Add(txt);                    
                }
            }
        }
        protected int WidthGet(ScreenData scrData)
        {
            int rowLength = charSize;
            if (scrData.RowDataType == rowDataType.AlphaNumeric || scrData.RowDataType == rowDataType.AlphaNumericPassword)
            {
                if (scrData.NumericFormat.Contains("("))
                {
                    string[] data = scrData.NumericFormat.Split('(');
                    rowLength = Convert.ToInt32(data[1].Replace(")", "")) * charSize + charExtraSize;
                }
                else
                {
                    rowLength = scrData.NumericFormat.Length * charSize + charExtraSize;
                }
            }
            else if (scrData.RowDataType == rowDataType.Numeric || scrData.RowDataType == rowDataType.NumericBlankWhenZero || scrData.RowDataType == rowDataType.NumberiBlankWhenZeroNoComma)
            {
                if (scrData.NumericFormat.Contains("("))
                {
                    string[] data = scrData.NumericFormat.Split('(');

                    if (data[1].Contains(")") && data[1].Contains("."))
                    {
                        rowLength = Util.NumInt(data[1].Split(')')[0]) * charSize + charExtraSize;
                    } else {

                        rowLength = Convert.ToInt32(data[1].Replace(")", "")) * charSize + charExtraSize;
                    }
                    if (scrData.NumericFormat.ToLower().Contains("v"))
                    {
                        string[] vData = scrData.NumericFormat.ToLower().Split('v');  
                        rowLength += Convert.ToInt32(data[1]) * charSize + charExtraSize;
                    }                   
                    else if (scrData.NumericFormat.ToLower().Contains("."))
                    {
                        string[] vData = scrData.NumericFormat.ToLower().Split('.');                        
                        rowLength += Convert.ToInt32(vData[1].Length) * charSize + charExtraSize;
                    }
                    else if (data.Length == 2)  // z(11)9
                    {
                        string[] subData = data[1].Split(')');
                        rowLength = Convert.ToInt32(subData[0]) * charSize + charExtraSize;
                    }
                }
                else
                {
                    rowLength = scrData.NumericFormat.Length * charSize + charExtraSize;
                }
            }

            if (rowLength == charSize + charExtraSize) rowLength = 17;           
            return rowLength;
        }
        protected void EraseRow(int row)
        {
            if (LayoutRoot == null) return;

            foreach (object obj in LayoutRoot.Children.OfType<TextBlock>())
            {                
                    TextBlock tb = obj as TextBlock;
                    int currentRow = Grid.GetRow(tb);
                    if (currentRow == row)
                        TextBlockShowHideControl(false, tb, row);                
            }

            foreach (object obj in LayoutRoot.Children.OfType<TextBox>())
            {                                
                    TextBox tb = obj as TextBox;
                    int currentRow = Grid.GetRow(tb);
                    if (currentRow == row)
                        TextBoxShowHideControl(false, tb, row);                
            }
        }

        protected void EraseRowRange(int fromRow, int toRow)
        {
            if (LayoutRoot == null) return;

            foreach (object obj in LayoutRoot.Children.OfType<TextBlock>())
            {                
                    TextBlock tb = obj as TextBlock;
                    int currentRow = Grid.GetRow(tb);
                    if (currentRow >= fromRow && currentRow <= toRow)
                    {
                        TextBlockShowHideControl(false, tb, currentRow);
                    }                
            }

            foreach (object obj in LayoutRoot.Children.OfType<TextBox>())
            {                                
                    TextBox tb = obj as TextBox;
                    int CurrentRow = Grid.GetRow(tb);
                    if (CurrentRow >= fromRow && CurrentRow <= toRow)
                    {
                        TextBoxShowHideControl(false, tb, CurrentRow);
                    }                
            }
        }

        private bool Delay()
        {
            this.Dispatcher.Invoke(() =>
            {
                Thread.Sleep(1000);                
            });
            return true;
        }

        protected async Task Display(string groupName, bool isShow , bool withDelay)
        {
            Display(groupName, isShow);
            Task<bool> task = null;
            task = new Task<bool>(Delay);
            task.Start();
            bool isEndTask = await task;
        }
        protected void DisplayOrig(string groupName, bool isShow = true)
        {
            if (LayoutRoot == null) return;

            this.Dispatcher.Invoke(() => { 

            foreach (object obj in LayoutRoot.Children)
            {
                if (obj.GetType().Name.Equals("TextBlock"))
                {
                    TextBlock tb = obj as TextBlock;
                    if (tb.Tag.Equals(groupName))
                    {
                        //Debug.WriteLine("Group Name : " + groupName + " " + tb.Text);
                        if (tb.Text.ToLower().Trim().Equals("blank line"))
                        {
                            if (isShow)
                            {
                                foreach (var objRow in ScreenDataCollection.Where(x => x.GroupNameLevel1.Equals(tb.Tag)))
                                {
                                    if (objRow.Data1.Trim().Equals("blank line"))
                                        EraseRow(Convert.ToInt32(objRow.Line));
                                }
                            }
                        }
                        else if (tb.Text.ToLower().Trim().Equals("blank screen"))
                        {
                            EraseRowRange(_clearScreenFrom, _clearScreenTo);
                        }
                        else
                        {
                            if (isShow)
                                tb.Visibility = Visibility.Visible;
                            else
                                tb.Visibility = Visibility.Hidden;
                        }
                    }
                }
                else if (obj.GetType().Name.Equals("TextBox"))
                {
                    TextBox tb = obj as TextBox;
                        tb.BorderThickness = new Thickness(0);
                        if (tb.Tag.ToString().ToLower().Replace(".", "").Equals(groupName.ToLower().Replace(".", "")))
                    {
                        if (isShow)
                            tb.Visibility = Visibility.Visible;
                        else
                            tb.Visibility = Visibility.Hidden;
                    }
                }
            }                
            });
        }

        protected void Display(bool isBackgroundTransparent, string groupNameLevel1, bool isShow = true, string backgroundColorValue = "#FFEBCC")
        {
            int ctr = 0;
            if (LayoutRoot == null) return;

            this.Dispatcher.Invoke(() => {

                foreach (object obj in LayoutRoot.Children)
                {
                    if (obj.GetType().Name.Equals("TextBlock"))
                    {
                        TextBlock tb = obj as TextBlock;
                        if (tb.Tag.ToString().Split('|')[0].Equals(groupNameLevel1))
                        {
                            //Debug.WriteLine("Group Name : " + groupNameLevel1 + " " + tb.Text);
                            if (tb.Text.ToLower().Trim().Equals("blank line"))
                            {
                                if (isShow)
                                {
                                    foreach (var objRow in ScreenDataCollection.Where(x => x.GroupNameLevel1.Equals(tb.Tag.ToString().Split('|')[0])))
                                    {
                                        if (objRow.Data1.Trim().Equals("blank line"))
                                            EraseRow(Convert.ToInt32(objRow.Line));
                                    }
                                }
                            }
                            else if (tb.Text.ToLower().Trim().Equals("blank screen"))
                            {
                                EraseRowRange(_clearScreenFrom, _clearScreenTo);
                            }
                            else
                            {
                                if (isShow)
                                    tb.Visibility = Visibility.Visible;
                                else
                                    tb.Visibility = Visibility.Hidden;

                                if (isBackgroundTransparent == false)
                                    tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColorValue));
                            }
                        }
                    }
                    else if (obj.GetType().Name.Equals("TextBox"))
                    {
                        TextBox tb = obj as TextBox;
                        ctr++;
                        //Debug.WriteLine("Row " + ctr + " Tag " + tb.Tag.ToString());
                        tb.BorderThickness = new Thickness(1);
                        if (tb.Tag.ToString().Split('|')[0].ToLower().Replace(".", "").Equals(groupNameLevel1.ToLower().Replace(".", "")))
                        {
                            if (isShow)
                                tb.Visibility = Visibility.Visible;
                            else
                                tb.Visibility = Visibility.Hidden;

                            if (isBackgroundTransparent == false)
                                tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColorValue));
                        }
                    }
                }
            });
        }
      
        protected void Display3(string groupNameLevel1, bool isShow = true)
        {
            int ctr = 0;
            if (LayoutRoot == null) return;

            //Debug.WriteLine("G : " + groupNameLevel1);

            this.Dispatcher.Invoke(() => {

                GridAddControl(groupNameLevel1);

                foreach (object obj in LayoutRoot.Children.OfType<TextBlock>().Where(x => x.Tag.ToString().Split('|')[0].Equals(groupNameLevel1)))
                {
                    ctr++;
                    TextBlock tb = obj as TextBlock;
                    if (tb.Tag.ToString().Split('|')[0].Equals(groupNameLevel1))
                    {
                        //Debug.WriteLine("Group Name : " + groupNameLevel1 + " " + tb.Text + " ctr " + ctr.ToString());
                        if (tb.Text.ToLower().Trim().Equals("blank line"))
                        {
                            if (isShow)
                            {
                                foreach (var objRow in ScreenDataCollection.Where(x => x.GroupNameLevel1.Equals(tb.Tag.ToString().Split('|')[0])))
                                {
                                    if (objRow.Data1.Trim().Equals("blank line"))
                                        EraseRow(Convert.ToInt32(objRow.Line));
                                }
                            }
                        }
                        else if (tb.Text.ToLower().Trim().Equals("blank screen"))
                        {
                            EraseRowRange(_clearScreenFrom, _clearScreenTo);
                        }
                        else
                        {
                            if (isShow)
                                tb.Visibility = Visibility.Visible;
                            else
                                tb.Visibility = Visibility.Hidden;
                        }
                    }
                }

                foreach (object obj in LayoutRoot.Children.OfType<TextBox>().Where(x => x.Tag.ToString().Split('|')[0].Equals(groupNameLevel1)))
                {
                    TextBox tb = obj as TextBox;
                    ctr++;
                    //Debug.WriteLine("Row " + ctr + " Tag " + tb.Tag.ToString());
                    tb.BorderThickness = new Thickness(1);
                    if (tb.Tag.ToString().Split('|')[0].ToLower().Replace(".", "").Equals(groupNameLevel1.ToLower().Replace(".", "")))
                    {
                        if (isShow)
                            tb.Visibility = Visibility.Visible;
                        else
                            tb.Visibility = Visibility.Hidden;
                    }
                }


            });
        }

        protected void Display(string groupNameLevel1, bool isShow = true  )
        {
            int ctr = 0;
            if (LayoutRoot == null) return;

            //Debug.WriteLine("G : " + groupNameLevel1);

            this.Dispatcher.Invoke(() => {
              
                foreach (object obj in LayoutRoot.Children.OfType<TextBlock>().Where(x => x.Tag.ToString().Split('|')[0].Equals(groupNameLevel1)))
                {                                        
                        ctr++;
                        TextBlock tb = obj as TextBlock;
                        if (tb.Tag.ToString().Split('|')[0].Equals(groupNameLevel1))
                        {
                            //Debug.WriteLine("Group Name : " + groupNameLevel1 + " " + tb.Text + " ctr " + ctr.ToString());
                            if (tb.Text.ToLower().Trim().Equals("blank line"))
                            {
                                if (isShow)
                                {
                                    foreach (var objRow in ScreenDataCollection.Where(x => x.GroupNameLevel1.Equals(tb.Tag.ToString().Split('|')[0])))
                                    {
                                        if (objRow.Data1.Trim().Equals("blank line"))
                                            EraseRow(Convert.ToInt32(objRow.Line));
                                    }
                                }
                            }
                            else if (tb.Text.ToLower().Trim().Equals("blank screen"))
                            {
                                EraseRowRange(_clearScreenFrom, _clearScreenTo);
                            }
                            else
                            {
                                if (isShow)
                                    tb.Visibility = Visibility.Visible;
                                else
                                    tb.Visibility = Visibility.Hidden;                               
                            }
                        }                    
                }

                foreach (object obj in LayoutRoot.Children.OfType<TextBox>().Where(x => x.Tag.ToString().Split('|')[0].Equals(groupNameLevel1)))
                {                                        
                        TextBox tb = obj as TextBox;
                        ctr++;
                        //Debug.WriteLine("Row " + ctr + " Tag " + tb.Tag.ToString());
                        tb.BorderThickness = new Thickness(1);
                        if (tb.Tag.ToString().Split('|')[0].ToLower().Replace(".", "").Equals(groupNameLevel1.ToLower().Replace(".", "")))
                        {
                            if (isShow)
                                tb.Visibility = Visibility.Visible;
                            else
                                tb.Visibility = Visibility.Hidden;
                        }                    
                }


            });
        }

        protected void DisplayBak(string groupNameLevel1, bool isShow = true)
        {
            int ctr = 0;
            if (LayoutRoot == null) return;

            //Debug.WriteLine("G : " + groupNameLevel1);

            this.Dispatcher.Invoke(() => {

                foreach (object obj in LayoutRoot.Children.OfType<TextBlock>().Where(x => x.Tag.ToString().Split('|')[0].Equals(groupNameLevel1)))
                {
                    if (obj.GetType().Name.Equals("TextBlock"))
                    {
                        ctr++;
                        TextBlock tb = obj as TextBlock;
                        if (tb.Tag.ToString().Split('|')[0].Equals(groupNameLevel1))
                        {
                            //Debug.WriteLine("Group Name : " + groupNameLevel1 + " " + tb.Text + " ctr " + ctr.ToString());
                            if (tb.Text.ToLower().Trim().Equals("blank line"))
                            {
                                if (isShow)
                                {
                                    foreach (var objRow in ScreenDataCollection.Where(x => x.GroupNameLevel1.Equals(tb.Tag.ToString().Split('|')[0])))
                                    {
                                        if (objRow.Data1.Trim().Equals("blank line"))
                                            EraseRow(Convert.ToInt32(objRow.Line));
                                    }
                                }
                            }
                            else if (tb.Text.ToLower().Trim().Equals("blank screen"))
                            {
                                EraseRowRange(_clearScreenFrom, _clearScreenTo);
                            }
                            else
                            {
                                if (isShow)
                                    tb.Visibility = Visibility.Visible;
                                else
                                    tb.Visibility = Visibility.Hidden;
                            }
                        }
                    }
                    else if (obj.GetType().Name.Equals("TextBox"))
                    {
                        TextBox tb = obj as TextBox;
                        ctr++;
                        //Debug.WriteLine("Row " + ctr + " Tag " + tb.Tag.ToString());
                        tb.BorderThickness = new Thickness(1);
                        if (tb.Tag.ToString().Split('|')[0].ToLower().Replace(".", "").Equals(groupNameLevel1.ToLower().Replace(".", "")))
                        {
                            if (isShow)
                                tb.Visibility = Visibility.Visible;
                            else
                                tb.Visibility = Visibility.Hidden;
                        }
                    }
                }

                foreach (object obj in LayoutRoot.Children.OfType<TextBox>().Where(x => x.Tag.ToString().Split('|')[0].Equals(groupNameLevel1)))
                {
                    if (obj.GetType().Name.Equals("TextBlock"))
                    {
                        ctr++;
                        TextBlock tb = obj as TextBlock;
                        if (tb.Tag.ToString().Split('|')[0].Equals(groupNameLevel1))
                        {
                            //Debug.WriteLine("Group Name : " + groupNameLevel1 + " " + tb.Text + " ctr " + ctr.ToString());
                            if (tb.Text.ToLower().Trim().Equals("blank line"))
                            {
                                if (isShow)
                                {
                                    foreach (var objRow in ScreenDataCollection.Where(x => x.GroupNameLevel1.Equals(tb.Tag.ToString().Split('|')[0])))
                                    {
                                        if (objRow.Data1.Trim().Equals("blank line"))
                                            EraseRow(Convert.ToInt32(objRow.Line));
                                    }
                                }
                            }
                            else if (tb.Text.ToLower().Trim().Equals("blank screen"))
                            {
                                EraseRowRange(_clearScreenFrom, _clearScreenTo);
                            }
                            else
                            {
                                if (isShow)
                                    tb.Visibility = Visibility.Visible;
                                else
                                    tb.Visibility = Visibility.Hidden;
                            }
                        }
                    }
                    else if (obj.GetType().Name.Equals("TextBox"))
                    {
                        TextBox tb = obj as TextBox;
                        ctr++;
                        //Debug.WriteLine("Row " + ctr + " Tag " + tb.Tag.ToString());
                        tb.BorderThickness = new Thickness(1);
                        if (tb.Tag.ToString().Split('|')[0].ToLower().Replace(".", "").Equals(groupNameLevel1.ToLower().Replace(".", "")))
                        {
                            if (isShow)
                                tb.Visibility = Visibility.Visible;
                            else
                                tb.Visibility = Visibility.Hidden;
                        }
                    }
                }


            });
        }


        protected void Display3(string groupNameLevel1, string groupNameLevel2, bool isShow = true)
        {
            //Example:  01  scr - mask3.
            //             05  scr-misc-1      line 07 col 37 pic zz9.99 using save-curr-1 auto.
            //             05  scr - misc - 2      line 08 col 37 pic zz9.99 using save - curr - 2 auto.

            // .NET values
            //  groupName =   "scr-mask3.|scr-misc-1";


            if (LayoutRoot == null) return;

            //Debug.WriteLine("Gd : " + groupNameLevel1);


            this.Dispatcher.Invoke(() => {

                string groupName = groupNameLevel1 + "|" + groupNameLevel2;

                GridAddControl(groupNameLevel1, groupNameLevel2);

                foreach (object obj in LayoutRoot.Children.OfType<TextBlock>().Where(x => x.Tag.Equals(groupName)))
                {
                    //string groupName = groupNameLevel1 + "|" + groupNameLevel2;                    
                    TextBlock tb = obj as TextBlock;
                    if (tb.Tag.Equals(groupName))
                    {
                        // Debug.WriteLine("Group Name : " + groupName + " " + tb.Text);
                        if (tb.Text.ToLower().Trim().Equals("blank line"))
                        {
                            if (isShow)
                            {
                                foreach (var objRow in ScreenDataCollection.Where(x => x.GroupNameLevel1.Equals(tb.Tag.ToString().Split('|')[0]) && x.GroupNameLevel2.Equals(tb.Tag.ToString().Split('|')[1])))
                                {
                                    if (objRow.Data1.Trim().Equals("blank line"))
                                        EraseRow(Convert.ToInt32(objRow.Line));
                                }
                            }
                        }
                        else if (tb.Text.ToLower().Trim().Equals("blank screen"))
                        {
                            EraseRowRange(_clearScreenFrom, _clearScreenTo);
                        }
                        else
                        {
                            if (isShow)
                                tb.Visibility = Visibility.Visible;
                            else
                                tb.Visibility = Visibility.Hidden;
                        }
                        break;
                    }
                }


                foreach (object obj in LayoutRoot.Children.OfType<TextBox>().Where(x => x.Tag.ToString().ToLower().Replace(".", "").Equals(groupName.ToLower().Replace(".", ""))))
                {
                    TextBox tb = obj as TextBox;
                    tb.BorderThickness = new Thickness(1);
                    if (tb.Tag.ToString().ToLower().Replace(".", "").Equals(groupName.ToLower().Replace(".", "")))
                    {
                        if (isShow)
                        {
                            tb.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            tb.Visibility = Visibility.Hidden;
                        }
                        break;
                    }
                }


            });
        }
        protected void Display(string groupNameLevel1, string groupNameLevel2, bool isShow = true)
        {
            //Example:  01  scr - mask3.
            //             05  scr-misc-1      line 07 col 37 pic zz9.99 using save-curr-1 auto.
            //             05  scr - misc - 2      line 08 col 37 pic zz9.99 using save - curr - 2 auto.

            // .NET values
            //  groupName =   "scr-mask3.|scr-misc-1";


            if (LayoutRoot == null) return;

            //Debug.WriteLine("Gd : " + groupNameLevel1);


            this.Dispatcher.Invoke(() => {

                string groupName = groupNameLevel1 + "|" + groupNameLevel2;
                

                foreach (object obj in LayoutRoot.Children.OfType<TextBlock>().Where(x => x.Tag.Equals(groupName)))
                {
                    //string groupName = groupNameLevel1 + "|" + groupNameLevel2;                    
                        TextBlock tb = obj as TextBlock;
                        if (tb.Tag.Equals(groupName))
                        {
                            // Debug.WriteLine("Group Name : " + groupName + " " + tb.Text);
                            if (tb.Text.ToLower().Trim().Equals("blank line"))
                            {
                                if (isShow)
                                {
                                    foreach (var objRow in ScreenDataCollection.Where(x => x.GroupNameLevel1.Equals(tb.Tag.ToString().Split('|')[0]) && x.GroupNameLevel2.Equals(tb.Tag.ToString().Split('|')[1])))
                                    {
                                        if (objRow.Data1.Trim().Equals("blank line"))
                                            EraseRow(Convert.ToInt32(objRow.Line));
                                    }
                                }
                            }
                            else if (tb.Text.ToLower().Trim().Equals("blank screen"))
                            {
                                EraseRowRange(_clearScreenFrom, _clearScreenTo);
                            }
                            else
                            {
                                if (isShow)
                                    tb.Visibility = Visibility.Visible;
                                else
                                    tb.Visibility = Visibility.Hidden;
                            }
                            break;
                        }                  
                }


                foreach (object obj in LayoutRoot.Children.OfType<TextBox>().Where(x => x.Tag.ToString().ToLower().Replace(".", "").Equals(groupName.ToLower().Replace(".", ""))))
                {                                                           
                        TextBox tb = obj as TextBox;
                        tb.BorderThickness = new Thickness(1);
                        if (tb.Tag.ToString().ToLower().Replace(".", "").Equals(groupName.ToLower().Replace(".", "")))
                        {
                            if (isShow)
                            {
                                tb.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                tb.Visibility = Visibility.Hidden;
                            }
                            break;
                        }                    
                }


            });
        }

        protected void DisplayBak(string groupNameLevel1, string groupNameLevel2,  bool isShow = true)
        {
            //Example:  01  scr - mask3.
            //             05  scr-misc-1      line 07 col 37 pic zz9.99 using save-curr-1 auto.
            //             05  scr - misc - 2      line 08 col 37 pic zz9.99 using save - curr - 2 auto.

            // .NET values
            //  groupName =   "scr-mask3.|scr-misc-1";


            if (LayoutRoot == null) return;

            //Debug.WriteLine("Gd : " + groupNameLevel1);


            this.Dispatcher.Invoke(() => {

                foreach (object obj in LayoutRoot.Children)
                {
                    string groupName = groupNameLevel1 + "|" + groupNameLevel2;
                    if (obj.GetType().Name.Equals("TextBlock"))
                    {
                        TextBlock tb = obj as TextBlock;
                        if (tb.Tag.Equals(groupName))
                        {
                           // Debug.WriteLine("Group Name : " + groupName + " " + tb.Text);
                            if (tb.Text.ToLower().Trim().Equals("blank line"))
                            {
                                if (isShow)
                                {
                                    foreach (var objRow in ScreenDataCollection.Where(x => x.GroupNameLevel1.Equals(tb.Tag.ToString().Split('|')[0]) && x.GroupNameLevel2.Equals(tb.Tag.ToString().Split('|')[1])))
                                    {
                                        if (objRow.Data1.Trim().Equals("blank line"))
                                            EraseRow(Convert.ToInt32(objRow.Line));
                                    }
                                }
                            }
                            else if (tb.Text.ToLower().Trim().Equals("blank screen"))
                            {
                                EraseRowRange(_clearScreenFrom, _clearScreenTo);
                            }
                            else
                            {
                                if (isShow)
                                    tb.Visibility = Visibility.Visible;
                                else
                                    tb.Visibility = Visibility.Hidden;
                            }
                            break;
                        }
                    }
                    else if (obj.GetType().Name.Equals("TextBox"))
                    {
                        TextBox tb = obj as TextBox;
                        tb.BorderThickness = new Thickness(1);
                        if (tb.Tag.ToString().ToLower().Replace(".", "").Equals(groupName.ToLower().Replace(".", "")))
                        {
                            if (isShow)
                            {
                                tb.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                tb.Visibility = Visibility.Hidden;
                            }
                            break;
                        }
                    }
                }
            });
        }

        protected bool IsDisplayBak(string groupNameLevel1, string groupNameLevel2)
        {
            //Example:  01  scr - mask3.
            //             05  scr-misc-1      line 07 col 37 pic zz9.99 using save-curr-1 auto.
            //             05  scr - misc - 2      line 08 col 37 pic zz9.99 using save - curr - 2 auto.

            // .NET values
            //  groupName =   "scr-mask3.|scr-misc-1";

            bool isVisible = false;

            if (LayoutRoot == null) return isVisible;

            //Debug.WriteLine("Gd : " + groupNameLevel1);


            this.Dispatcher.Invoke(() => {

                foreach (object obj in LayoutRoot.Children)
                {
                    string groupName = groupNameLevel1 + "|" + groupNameLevel2;
                    if (obj.GetType().Name.Equals("TextBlock"))
                    {
                        TextBlock tb = obj as TextBlock;
                        if (tb.Tag.Equals(groupName))
                        {
                            if (tb.Visibility == Visibility.Visible)
                            {
                                isVisible = true;
                            }
                            else
                            {
                                isVisible = false;
                            }
                            break;
                        }
                    }
                    else if (obj.GetType().Name.Equals("TextBox"))
                    {
                        TextBox tb = obj as TextBox;
                        tb.BorderThickness = new Thickness(1);
                        if (tb.Tag.ToString().ToLower().Replace(".", "").Equals(groupName.ToLower().Replace(".", "")))
                        {
                            if (tb.Visibility == Visibility.Visible)
                            {
                                isVisible = true;
                            }
                            else
                            {
                                isVisible = false;
                            }
                            break;
                        }
                    }
                }
            });
            return isVisible;
        }

        protected bool IsDisplay(string groupNameLevel1, string groupNameLevel2)
        {
            //Example:  01  scr - mask3.
            //             05  scr-misc-1      line 07 col 37 pic zz9.99 using save-curr-1 auto.
            //             05  scr - misc - 2      line 08 col 37 pic zz9.99 using save - curr - 2 auto.

            // .NET values
            //  groupName =   "scr-mask3.|scr-misc-1";

            bool isVisible = false;

            if (LayoutRoot == null) return isVisible;

            //Debug.WriteLine("Gd : " + groupNameLevel1);


            this.Dispatcher.Invoke(() => {

                string groupName = groupNameLevel1 + "|" + groupNameLevel2;

                GridAddControl(groupNameLevel1, groupNameLevel2);

                foreach (object obj in LayoutRoot.Children.OfType<TextBlock>().Where(x => x.Tag.Equals(groupName)))
                {                                      
                        TextBlock tb = obj as TextBlock;
                        if (tb.Tag.Equals(groupName))
                        {
                            if (tb.Visibility == Visibility.Visible)
                            {
                                isVisible = true;
                            }
                            else
                            {
                                isVisible = false;
                            }
                            break;
                        }                  
                }

                foreach (object obj in LayoutRoot.Children.OfType<TextBox>().Where(x => x.Tag.Equals(groupName)))
                {                  
                        TextBox tb = obj as TextBox;
                        tb.BorderThickness = new Thickness(1);
                        if (tb.Tag.ToString().ToLower().Replace(".", "").Equals(groupName.ToLower().Replace(".", "")))
                        {
                            if (tb.Visibility == Visibility.Visible)
                            {
                                isVisible = true;
                            }
                            else
                            {
                                isVisible = false;
                            }
                            break;
                        }                  
                }
            });
            return isVisible;
        }

        protected void ClearScreen()
        {
            EraseRowRange(_clearScreenFrom, _clearScreenTo);
        }
        protected void TextBlockShowHideControl(bool isShowControl, TextBlock tb, int row)
        {
            if (LayoutRoot == null) return;

            if (row == Grid.GetRow(tb))
            {
                if (isShowControl == false)
                {
                    tb.Visibility = Visibility.Hidden;
                }
                else
                {
                    tb.Visibility = Visibility.Visible;
                }
            }
        }
        protected void TextBoxShowHideControl(bool isShowControl, TextBox tb, int row)
        {
            if (LayoutRoot == null) return;

            if (row == Grid.GetRow(tb))
            {
                if (isShowControl == false)
                {
                    tb.Visibility = Visibility.Hidden;
                }
                else
                {
                    tb.Visibility = Visibility.Visible;
                }
            }
        }
        protected string ControlNameValidate(string value)
        {
            if (value.Contains("("))
            {
                int pos = value.IndexOf("(");
                string newValue = value.Substring(0, pos - 1);
                return newValue;
            }
            else
            {
                return value;
            }
        }
        protected void DisplayAllControlsInfo()
        {
            if (LayoutRoot == null) return;

            foreach (object obj in LayoutRoot.Children)
            {
                if (obj.GetType().Name.Equals("TextBlock"))
                {
                    TextBlock lbl = obj as TextBlock;
                    //Debug.WriteLine("TextBlock : " + lbl.Name.PadRight(50) + " " + lbl.Tag.ToString());
                }
                else if (obj.GetType().Name.Equals("TextBox"))
                {
                    TextBox tb = obj as TextBox;
                    //Debug.WriteLine("TextBox : " + tb.Name.PadRight(50) + " " + tb.Tag.ToString());
                }
            }
        }
        protected TextBox CurrentControl(string textBoxName)
        {
            if (LayoutRoot == null) return null;

            TextBox tb = null;
            foreach (var obj in LayoutRoot.Children)
            {
                if (obj.GetType().Name.Equals("TextBox"))
                {
                    tb = obj as TextBox;
                    if (tb.Name.Equals(textBoxName))
                    {
                        break;
                    }
                }
            }
            return tb;
        }
        #endregion

        #region Keyboard
        public void TxtInteger_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == ".")
            {
                e.Handled = true;
            }
            else if (e.Text == ",")
            {
                e.Handled = true;
            }
            else if (e.Text == "-" )
            {
                if ( ((TextBox)sender).Text.IndexOf(e.Text) > -1 )
                {
                    e.Handled = true;
                }
            }
            else if (Util.IsNumeric(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        public void TxtDecimal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == ".")
            {
                if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                {
                    e.Handled = true;
                }
            }
            // else if (e.Text != "," && Util.IsNumeric(e.Text) == false)
            else if (e.Text == ",")
            {
                e.Handled = true;
            }
            else if (e.Text == "-")
            {
                if ( ((TextBox)sender).Text.IndexOf(e.Text) > - 1 )
                {
                    e.Handled = true;
                }
            }
            else if (Util.IsNumeric(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        public void Txt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Return))
            {
                PromptExit = true;
            }
        }
        public void Txt_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Return))
            {
                PromptExit = true;
            }
            else
            {
                switch (e.Key)
                {
                    case Key.Return:
                        EscapeKeyValue = 0;
                        break;
                  //  case Key.Escape:
                  //      EscapeKeyValue = 1;
                    case Key.F1:
                        SendKeys.Send(Key.Enter);
                        EscapeKeyValue = 2; 
                        break;
                    case Key.F2:
                        SendKeys.Send(Key.Enter);
                        EscapeKeyValue = 3;
                        break;
                    case Key.F3:
                        SendKeys.Send(Key.Enter);
                        EscapeKeyValue = 4;
                        break;
                    case Key.F4:
                        SendKeys.Send(Key.Enter);
                        EscapeKeyValue = 5;
                        break;
                    case Key.F5:
                        SendKeys.Send(Key.Enter);
                        EscapeKeyValue = 6;
                        break;
                    case Key.F6:
                        SendKeys.Send(Key.Enter);
                        EscapeKeyValue = 7;
                        break;
                    case Key.F7:
                        SendKeys.Send(Key.Enter);
                        EscapeKeyValue = 8;
                        break;
                    case Key.F8:
                        SendKeys.Send(Key.Enter);
                        EscapeKeyValue = 9;
                        break;
                    case Key.F9:
                        SendKeys.Send(Key.Enter);
                        EscapeKeyValue = 10;
                        break;
                    case Key.F10:
                        SendKeys.Send(Key.Enter);
                        EscapeKeyValue = 11;
                        break;
                    case Key.F11:
                        SendKeys.Send(Key.Enter);
                        EscapeKeyValue = 12;
                        break;
                    case Key.F12:
                        SendKeys.Send(Key.Enter);
                        EscapeKeyValue = 13;
                        break;
                    case Key.NumLock:
                        SendKeys.Send(Key.Enter);
                        EscapeKeyValue = 14;
                        break;  
                }
            }
        }
        public void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                PromptExit = true;
            }
        }
       

        public void Numeric_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Util.IsNumeric(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.Replace(",", "");
                ((TextBox)sender).SelectAll();
            }
        }

        public void integer_LostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Length > 0)
            {
                ((TextBox)sender).Text = string.Format("{0:#,0}", Util.NumDec(((TextBox)sender).Text));
            }
        }

        #endregion

        #region ControlPrompts

        private bool HasDataBypass(object value)
        {
            bool retVal = false;

            if (value != null)
            {
                if (Util.IsNumeric(value.ToString()))
                {
                    if (Util.NumDec(value) > 0)
                    {
                        retVal = true;
                    }
                }
                else if (value.ToString().Trim().Length > 0)
                {
                    retVal = true;
                }
            }
            return retVal;
        }
        private bool IsRequired(string controlName)
        {
            ScreenData objScreenData = ScreenDataCollection.Where(x => x.InputVariableName.ToLower().Trim().Equals(controlName.Trim().ToLower())).FirstOrDefault();

            if (objScreenData != null)
            {
                if (objScreenData.IsRequired)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private bool HasData(string controlName)
        {
            bool retVal = false;
            foreach (object obj in LayoutRoot.Children)
            {
                if (obj.GetType().Name.Equals("TextBox"))
                {
                    TextBox tb = obj as TextBox;
                    if (tb.Name.Trim().ToLower().Equals(controlName.Trim().ToLower().Replace("[", "_").Replace("]", "_")))
                    {
                        if (tb.Text.Trim().Length > 0)
                        {
                            retVal = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return retVal;
        }

        private int UserPromptEscKeys()
        {
            bool flag = false;
            PromptExit = false;
            int retEscKeyValue = -1;
            EscapeKeyValue = -1;

            try
            {
                while (flag == false)
                {
                    //Sleep used to reduce the CPU usage
                    Thread.Sleep(100);

                    this.Dispatcher.Invoke(() =>
                    {
                        if (txtFocus != null)
                        {
                            txtFocus.Focus();
                        }
                        if (EscapeKeyValue == 0 || (EscapeKeyValue >= 2 && EscapeKeyValue <= 13))
                        {
                            retEscKeyValue = EscapeKeyValue;
                            EscapeKeyValue = -1;
                            PromptExit = true;
                        }

                        if (PromptExit == true)
                        {
                            flag = true;
                        }
                    });
                }
            }

            catch (TaskCanceledException timeoutEx)
            {
            }

            return retEscKeyValue;
        }

        protected async Task<int> PromptEscKeys(string controlName, bool batchHasValueBypass = false, object value = null)
        {
            bool isDone = false;
            int keycode = -1;

            try
            {
                if (batchHasValueBypass == true)
                {
                    return -1;
                }

                do
                {
                    GridInputControlAllDisabled();
                    txtFocus =  InputControlEnable(controlName); 
                    PromptExit = false;
                    if (IsExitForm) break;
                    Task<int> task = null;
                    task = new Task<int>(UserPromptEscKeys);
                    task.Start();
                    keycode = await task;

                    if (IsRequired(controlName))
                    {
                        if (HasData(controlName))
                        {
                            isDone = true;
                        }
                        else
                        {
                            PromptExit = false;
                        }
                    }
                    else
                    {
                        isDone = true;
                    }

                } while (isDone == false);
            }

            catch (TaskCanceledException timeoutEx)
            {
            }

            return keycode;
        }

        protected async Task<int> PromptEscKeys(string controlName, string groupNameLevel1, string groupNameLevel2, bool batchHasValueBypass = false, object value = null)
        {
            bool isDone = false;
            int keycode = -1;

            try
            {
                if (batchHasValueBypass == true)
                {
                    return -1;
                }

                do
                {
                    GridInputControlAllDisabled();
                    txtFocus =  InputControlEnable(controlName, groupNameLevel1, groupNameLevel2);
                    PromptExit = false;
                    if (IsExitForm) break;
                    Task<int> task = null;
                    task = new Task<int>(UserPromptEscKeys);
                    task.Start();
                    keycode = await task;

                    if (IsRequired(controlName))
                    {
                        if (HasData(controlName))
                        {
                            isDone = true;
                        }
                        else
                        {
                            PromptExit = false;
                        }
                    }
                    else
                    {
                        isDone = true;
                    }

                } while (isDone == false);
            }

            catch (TaskCanceledException timeoutEx)
            {
            }

            return keycode;
        }


        private bool UserPrompt()
        {
            bool flag = false;
            bool ftf = false;
            PromptExit = false;
            
            while (flag == false)
            {
                //Sleep used to reduce the CPU usage
                Thread.Sleep(50);

                this.Dispatcher.Invoke(() =>
                {
                    if (ftf== false)
                    {
                        if (txtFocus != null)
                        {
                            txtFocus.SelectAll();
                            txtFocus.Focus();
                        }
                        PromptExit = false;
                        ftf = true;
                    }
                    if (PromptExit == true)
                    {
                        flag = true;                        
                    }
                });
            }
            return true;
        }

        private bool UserPromptDelay()
        {
            bool flag = false;            

            while (flag == false)
            {
                Thread.Sleep(50);
                this.Dispatcher.Invoke(() =>
                {
                    flag = true;
                });
            }
            return true;
        }

        protected async Task PromptDelay()
        {
            Task<bool> task = null;
            task = new Task<bool>(UserPromptDelay);
            task.Start();
            bool isEndTask = await task;
        }

        protected async Task Prompt(string controlName, bool batchHasValueBypass = false, object value = null)
        {
            bool isDone = false;

            try
            {
                if (batchHasValueBypass == true)
                {
                    return;
                }

                do
                {
                    GridInputControlAllDisabled();
                    txtFocus =  InputControlEnable(controlName);
                    PromptExit = false;
                    if (IsExitForm) break;
                    Task<bool> task = null;
                    task = new Task<bool>(UserPrompt);
                    task.Start();
                    bool isEndTask = await task;

                    if (IsRequired(controlName))
                    {
                        if (HasData(controlName))
                        {
                            isDone = true;
                        }
                        else
                        {
                            PromptExit = false;
                        }
                    }
                    else
                    {
                        isDone = true;
                    }

                } while (isDone == false);
            }

            catch (TaskCanceledException timeoutEx)
            {
            }

        }

        protected async Task Prompt(string controlName, string groupNameLevel1, string groupNameLevel2,  bool batchHasValueBypass = false, object value = null)
        {
            bool isDone = false;

            try
            {
                if (batchHasValueBypass == true)
                {
                    return;
                }

                do
                {
                    GridInputControlAllDisabled();
                    txtFocus =  InputControlEnable(controlName, groupNameLevel1, groupNameLevel2);
                    PromptExit = false;
                    if (IsExitForm) break;
                    Task<bool> task = null;
                    task = new Task<bool>(UserPrompt);
                    task.Start();
                    bool isEndTask = await task;

                    if (IsRequired(controlName))
                    {
                        if (HasData(controlName))
                        {
                            isDone = true;
                        }
                        else
                        {
                            PromptExit = false;
                        }
                    }
                    else
                    {
                        isDone = true;
                    }

                } while (isDone == false);
            }

            catch (TaskCanceledException timeoutEx)
            {
            }
        }

        #endregion
    }

    public static class SendKeys
    {
        /// <summary>
        ///   Sends the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public static void Send(Key key)
        {
            if (Keyboard.PrimaryDevice != null)
            {
                if (Keyboard.PrimaryDevice.ActiveSource != null)
                {
                    var e1 = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key) { RoutedEvent = Keyboard.PreviewKeyDownEvent};
                    InputManager.Current.ProcessInput(e1);
                }
            }
        }
    }

}
