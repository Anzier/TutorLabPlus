﻿#pragma checksum "..\..\TutorCompetion.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "925DC58FDCD4E27A6E87468526EDC696"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace TL_Plus {
    
    
    /// <summary>
    /// TutorCompetion
    /// </summary>
    public partial class TutorCompetion : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\TutorCompetion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TL_Plus.TutorCompetion Tutor_Completion;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\TutorCompetion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t_ANum;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\TutorCompetion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t_SignInProblem;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\TutorCompetion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t_class;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\TutorCompetion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t_startTime;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\TutorCompetion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t_endTime;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\TutorCompetion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t_name;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\TutorCompetion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t_tutorFeedback;
        
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
            System.Uri resourceLocater = new System.Uri("/TL_Plus;component/tutorcompetion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TutorCompetion.xaml"
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
            this.Tutor_Completion = ((TL_Plus.TutorCompetion)(target));
            return;
            case 2:
            this.t_ANum = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.t_SignInProblem = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 12 "..\..\TutorCompetion.xaml"
            ((System.Windows.Controls.Button)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Action_Cancel);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 13 "..\..\TutorCompetion.xaml"
            ((System.Windows.Controls.Button)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Action_Submit);
            
            #line default
            #line hidden
            return;
            case 6:
            this.t_class = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.t_startTime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.t_endTime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.t_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.t_tutorFeedback = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

