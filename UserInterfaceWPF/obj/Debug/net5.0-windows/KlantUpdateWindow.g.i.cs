﻿#pragma checksum "..\..\..\KlantUpdateWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E83226618F9BAF710D35239F663A7687AA537A8F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using UserInterfaceWPF;


namespace UserInterfaceWPF {
    
    
    /// <summary>
    /// KlantUpdateWindow
    /// </summary>
    public partial class KlantUpdateWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\..\KlantUpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_Naam;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\KlantUpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Adres;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\KlantUpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NaamHuidig;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\KlantUpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label AdresHuidig;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\KlantUpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label GiantTitel;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\KlantUpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Naam;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\KlantUpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Adres;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\KlantUpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_NaamHuidig;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\KlantUpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_AdresHuidig;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\KlantUpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateWindow;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.12.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UserInterfaceWPF;V1.0.0.0;component/klantupdatewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\KlantUpdateWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.12.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lbl_Naam = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Adres = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.NaamHuidig = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.AdresHuidig = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.GiantTitel = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.txt_Naam = ((System.Windows.Controls.TextBox)(target));
            
            #line 77 "..\..\..\KlantUpdateWindow.xaml"
            this.txt_Naam.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_Naam_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txt_Adres = ((System.Windows.Controls.TextBox)(target));
            
            #line 81 "..\..\..\KlantUpdateWindow.xaml"
            this.txt_Adres.KeyDown += new System.Windows.Input.KeyEventHandler(this.txt_Adres_KeyDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txt_NaamHuidig = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txt_AdresHuidig = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.UpdateWindow = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\KlantUpdateWindow.xaml"
            this.UpdateWindow.Click += new System.Windows.RoutedEventHandler(this.UpdateWindow_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
