﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5B9C51C4C4F0832C76A75055FEB99CAD8501C1A74DE61AEBC110E702A1965789"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using calculator;


namespace calculator {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ExpressionDisplay;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ResultDisplay;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ExpressionDisplay = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ResultDisplay = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 37 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FunctionButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 38 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ConstantButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 39 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ConstantButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 40 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClearAll);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 41 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 43 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FunctionButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 44 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FunctionButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 45 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FunctionButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 46 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FunctionButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 47 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FunctionButton_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 49 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FunctionButton_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 50 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ParenthesisButton_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 51 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ParenthesisButton_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 52 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FunctionButton_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 53 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OperatorButton_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 55 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PowerButton_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 56 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DigitButton_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 57 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DigitButton_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 58 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DigitButton_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 59 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OperatorButton_Click);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 61 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FunctionButton_Click);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 62 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DigitButton_Click);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 63 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DigitButton_Click);
            
            #line default
            #line hidden
            return;
            case 26:
            
            #line 64 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DigitButton_Click);
            
            #line default
            #line hidden
            return;
            case 27:
            
            #line 65 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OperatorButton_Click);
            
            #line default
            #line hidden
            return;
            case 28:
            
            #line 67 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FunctionButton_Click);
            
            #line default
            #line hidden
            return;
            case 29:
            
            #line 68 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DigitButton_Click);
            
            #line default
            #line hidden
            return;
            case 30:
            
            #line 69 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DigitButton_Click);
            
            #line default
            #line hidden
            return;
            case 31:
            
            #line 70 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DigitButton_Click);
            
            #line default
            #line hidden
            return;
            case 32:
            
            #line 71 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OperatorButton_Click);
            
            #line default
            #line hidden
            return;
            case 33:
            
            #line 73 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FunctionButton_Click);
            
            #line default
            #line hidden
            return;
            case 34:
            
            #line 74 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PlusMinusButton_Click);
            
            #line default
            #line hidden
            return;
            case 35:
            
            #line 75 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DigitButton_Click);
            
            #line default
            #line hidden
            return;
            case 36:
            
            #line 76 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DigitButton_Click);
            
            #line default
            #line hidden
            return;
            case 37:
            
            #line 77 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CalculateResult);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

