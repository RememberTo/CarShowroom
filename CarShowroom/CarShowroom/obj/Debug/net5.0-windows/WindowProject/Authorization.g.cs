﻿#pragma checksum "..\..\..\..\WindowProject\Authorization.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4E50C53E7CDFFA240421A98D7DD4165F3357D313"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CarShowroomSystem;
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


namespace CarShowroomSystem {
    
    
    /// <summary>
    /// Authorization
    /// </summary>
    public partial class Authorization : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\WindowProject\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_OK;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\WindowProject\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Close;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\WindowProject\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Registr;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\WindowProject\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Login;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\WindowProject\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TextBox_Password;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\WindowProject\Authorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LabelErrorAuth;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CarShowroom;component/windowproject/authorization.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\WindowProject\Authorization.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.button_OK = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\WindowProject\Authorization.xaml"
            this.button_OK.Click += new System.Windows.RoutedEventHandler(this.button_OK_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.button_Close = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\WindowProject\Authorization.xaml"
            this.button_Close.Click += new System.Windows.RoutedEventHandler(this.button_Close_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.button_Registr = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\WindowProject\Authorization.xaml"
            this.button_Registr.Click += new System.Windows.RoutedEventHandler(this.button_Registr_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TextBox_Login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TextBox_Password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.LabelErrorAuth = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
