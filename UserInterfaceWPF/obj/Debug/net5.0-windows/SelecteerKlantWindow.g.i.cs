﻿#pragma checksum "..\..\..\SelecteerKlantWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AE3C8F52248859E3678F59D81B948F1DFECB27D4"
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
    /// SelecteerKlantWindow
    /// </summary>
    public partial class SelecteerKlantWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\..\SelecteerKlantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbx_KlantId;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\SelecteerKlantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbx_Naam;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\SelecteerKlantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbtx_Adres;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\SelecteerKlantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_PlaatsBestelling;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\SelecteerKlantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/UserInterfaceWPF;V1.0.0.0;component/selecteerklantwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SelecteerKlantWindow.xaml"
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
            this.txtbx_KlantId = ((System.Windows.Controls.TextBox)(target));
            
            #line 47 "..\..\..\SelecteerKlantWindow.xaml"
            this.txtbx_KlantId.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtbx_KlantId_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtbx_Naam = ((System.Windows.Controls.TextBox)(target));
            
            #line 48 "..\..\..\SelecteerKlantWindow.xaml"
            this.txtbx_Naam.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtbx_Naam_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtbtx_Adres = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\..\SelecteerKlantWindow.xaml"
            this.txtbtx_Adres.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtbtx_Adres_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_PlaatsBestelling = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\SelecteerKlantWindow.xaml"
            this.btn_PlaatsBestelling.Click += new System.Windows.RoutedEventHandler(this.btn_PlaatsBestelling_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 55 "..\..\..\SelecteerKlantWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 57 "..\..\..\SelecteerKlantWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
