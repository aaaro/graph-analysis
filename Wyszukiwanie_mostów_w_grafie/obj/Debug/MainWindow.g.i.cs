﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1067C0A82B69A654ED155EE47CEDBC2136A7BC2C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using Wyszukiwanie_mostów_w_grafie;


namespace Wyszukiwanie_mostów_w_grafie {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wyszukiwanie_mostów_w_grafie.MainWindow window;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas ZoomSpace;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer sv;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas DrawSpace;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ScaleTransform st;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel ToolBar;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FindBridgesButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddEdge;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddVertex;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteElements;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MoveElements;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetGraph;
        
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
            System.Uri resourceLocater = new System.Uri("/Wyszukiwanie_mostów_w_grafie;component/mainwindow.xaml", System.UriKind.Relative);
            
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
            this.window = ((Wyszukiwanie_mostów_w_grafie.MainWindow)(target));
            return;
            case 2:
            this.ZoomSpace = ((System.Windows.Controls.Canvas)(target));
            
            #line 11 "..\..\MainWindow.xaml"
            this.ZoomSpace.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.ZoomSpace_MouseWheel);
            
            #line default
            #line hidden
            return;
            case 3:
            this.sv = ((System.Windows.Controls.ScrollViewer)(target));
            
            #line 12 "..\..\MainWindow.xaml"
            this.sv.PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.HandlePreviewMouseWheel);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DrawSpace = ((System.Windows.Controls.Canvas)(target));
            
            #line 13 "..\..\MainWindow.xaml"
            this.DrawSpace.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.DrawSpace_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.st = ((System.Windows.Media.ScaleTransform)(target));
            return;
            case 6:
            this.ToolBar = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 7:
            this.FindBridgesButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\MainWindow.xaml"
            this.FindBridgesButton.Click += new System.Windows.RoutedEventHandler(this.FindBridgesButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AddEdge = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\MainWindow.xaml"
            this.AddEdge.Click += new System.Windows.RoutedEventHandler(this.AddEdge_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.AddVertex = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\MainWindow.xaml"
            this.AddVertex.Click += new System.Windows.RoutedEventHandler(this.AddVertex_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.DeleteElements = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\MainWindow.xaml"
            this.DeleteElements.Click += new System.Windows.RoutedEventHandler(this.DeleteElements_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.MoveElements = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\MainWindow.xaml"
            this.MoveElements.Click += new System.Windows.RoutedEventHandler(this.MoveElements_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ResetGraph = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\MainWindow.xaml"
            this.ResetGraph.Click += new System.Windows.RoutedEventHandler(this.ResetGraph_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

