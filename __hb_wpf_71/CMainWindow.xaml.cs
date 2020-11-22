namespace __hb_wpf_71
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Windows.Threading;




    public partial class CMainWindow : Window
    {
        public CMainWindow()
        {
            InitializeComponent();


            _stwc = new Stopwatch();
            _stwc.Start();


            SourceInitialized += pf_SourceInitialized;
            Activated += pf_Activated;
            Loaded += pf_Loaded;
            ContentRendered += pf_ContentRendered;
            Deactivated += pf_Deactivated;
            Closing += pf_Closing;
            Closed += pf_Closed;

            Dispatcher.BeginInvoke(DispatcherPriority.Send, (Action)pf_Dispatcher__Send);
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)pf_Dispatcher__Normal);
            Dispatcher.BeginInvoke(DispatcherPriority.DataBind, (Action)pf_Dispatcher__DataBind);
            Dispatcher.BeginInvoke(DispatcherPriority.Render, (Action)pf_Dispatcher__Render);
            Dispatcher.BeginInvoke(DispatcherPriority.Loaded, (Action)pf_Dispatcher__Loaded);
            Dispatcher.BeginInvoke(DispatcherPriority.Input, (Action)pf_Dispatcher__Input);
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)pf_Dispatcher__Background);
            Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, (Action)pf_Dispatcher__ContextIdle);
            Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, (Action)pf_Dispatcher__ApplicationIdle);
            Dispatcher.BeginInvoke(DispatcherPriority.SystemIdle, (Action)pf_Dispatcher__SystemIdle);
        }

        

        #region "~~~~~~~~~~ 1"
        private Stopwatch _stwc;

        private void pf_SourceInitialized(object tsd, EventArgs tea)
        {
            Debug.WriteLine("##pf_SourceInitialized");
            Debug.WriteLine(_stwc.Elapsed);
        }

        private void pf_Activated(object tsd, EventArgs tea)
        {
            Debug.WriteLine("##pf_Activated");
            Debug.WriteLine(_stwc.Elapsed);
        }

        private void pf_Loaded(object tsd, RoutedEventArgs tea)
        {
            Debug.WriteLine("##pf_Loaded");
            Debug.WriteLine(_stwc.Elapsed);
        }

        private void pf_ContentRendered(object tsd, EventArgs tea)
        {
            Debug.WriteLine("##pf_ContentRendered");
            Debug.WriteLine(_stwc.Elapsed);
        }

        private void pf_Deactivated(object tsd, EventArgs tea)
        {
            Debug.WriteLine("##pf_Deactivated");
            Debug.WriteLine(_stwc.Elapsed);
        }

        private void pf_Closed(object tsd, EventArgs tea)
        {
            Debug.WriteLine("##pf_Closed");
            Debug.WriteLine(_stwc.Elapsed);
        }

        private void pf_Closing(object tsd, CancelEventArgs tea)
        {
            Debug.WriteLine("##pf_Closing");
            Debug.WriteLine(_stwc.Elapsed);
        }


        private void pf_Dispatcher__Send()
        {
            Debug.WriteLine("pf_Dispatcher__Send");
            Debug.WriteLine(_stwc.Elapsed);
        }

        private void pf_Dispatcher__Normal()
        {
            Debug.WriteLine("pf_Dispatcher__Normal");
            Debug.WriteLine(_stwc.Elapsed);
        }

        private void pf_Dispatcher__DataBind()
        {
            Debug.WriteLine("pf_Dispatcher__DataBind");
            Debug.WriteLine(_stwc.Elapsed);
        }

        private void pf_Dispatcher__Render()
        {
            Debug.WriteLine("pf_Dispatcher__Render");
            Debug.WriteLine(_stwc.Elapsed);
        }

        private void pf_Dispatcher__Loaded()
        {
            Debug.WriteLine("pf_Dispatcher__Loaded");
            Debug.WriteLine(_stwc.Elapsed);
        }

        private void pf_Dispatcher__Input()
        {
            Debug.WriteLine("pf_Dispatcher__Input");
            Debug.WriteLine(_stwc.Elapsed);
        }

        private void pf_Dispatcher__Background()
        {
            Debug.WriteLine("pf_Dispatcher__Background");
            Debug.WriteLine(_stwc.Elapsed);
        }

        private void pf_Dispatcher__ContextIdle()
        {
            Debug.WriteLine("pf_Dispatcher__ContextIdle");
            Debug.WriteLine(_stwc.Elapsed);
        }

        private void pf_Dispatcher__ApplicationIdle()
        {
            Debug.WriteLine("pf_Dispatcher__ApplicationIdle");
            Debug.WriteLine(_stwc.Elapsed);
        }

        private void pf_Dispatcher__SystemIdle()
        {
            Debug.WriteLine("pf_Dispatcher__SystemIdle");
            Debug.WriteLine(_stwc.Elapsed);
        } 
        #endregion






        protected override void OnContentRendered(EventArgs tea)
        {
            base.OnContentRendered(tea);

            ResizeMode = ResizeMode.CanResize;
            SizeToContent = SizeToContent.Manual;
            _pnlrt.Width = double.NaN;
            _pnlrt.Height = double.NaN;


            _rxiv = new RxImageVisual();
            _rxivc.AddChild(_rxiv);
            _rxiv.Open(string.Empty);

            _rxibv = new RxImageBoundsVisual();
            _rxivc.AddChild(_rxibv);
            Dispatcher.BeginInvoke(DispatcherPriority.Render,
                (Action)delegate()
                {
                    _rxibv.DrawUpdate(_rxiv.GetBounds());
                });
            

            OnRenderSizeChanged(null);
        }
        private RxImageVisual _rxiv;
        private RxImageBoundsVisual _rxibv;

        protected override void OnRenderSizeChanged(SizeChangedInfo tsci)
        {
            if (tsci != null)
                base.OnRenderSizeChanged(tsci);

            if (_rxiv != null)
            {
                _rxiv.ResizeUpdate();
                if (_rxibv != null)
                    _rxibv.DrawUpdate(_rxiv.GetBounds());
            }
        }

        protected override void OnPreviewKeyDown(KeyEventArgs tea)
        {
            base.OnPreviewKeyDown(tea);

            if ((tea.Key == Key.System) && Keyboard.IsKeyDown(Key.LeftAlt))
                tea.Handled = true;
        }

        protected override void OnMouseWheel(MouseWheelEventArgs tea)
        {
            base.OnMouseWheel(tea);

            if (Keyboard.IsKeyDown(Key.LeftAlt))
            {
                if (tea.Delta < 0)
                {
                    _sa -= 0.1;
                    if (_sa < 0.1) _sa = 0.1;
                    _rxiv.SetScaleCenter(_sa, _sa);
                    _rxibv.DrawUpdate(_rxiv.GetBounds());
                }
                else if (tea.Delta > 0)
                {
                    _sa += 0.1;
                    _rxiv.SetScaleCenter(_sa, _sa);
                    _rxibv.DrawUpdate(_rxiv.GetBounds());
                }
            }
            else
            {
                if (tea.Delta < 0)
                {
                    _ag -= 5;
                    if (_ag < 0) _ag = 0;
                    _rxiv.SetRotateCenter(RxGeom.GetAngleToRadian(_ag));
                    _rxibv.DrawUpdate(_rxiv.GetBounds());
                }
                else if (tea.Delta > 0)
                {
                    _ag += 5;
                    if (_ag > 360) _ag = 360;
                    _rxiv.SetRotateCenter(RxGeom.GetAngleToRadian(_ag));
                    _rxibv.DrawUpdate(_rxiv.GetBounds());
                }

                RxLog.Trace(_ag.ToString());
            }
        }


        private double _ag = 0;
        private double _sa = 1;

        private void pf__btn1_Click(object tsd, RoutedEventArgs tea)
        {
            _ag += 15;
            _rxiv.SetRotateCenter(RxGeom.GetAngleToRadian(_ag));
        }

        private void pf__btn2_Click(object tsd, RoutedEventArgs tea)
        {
            _sa += 0.1;
            _rxiv.SetScaleCenter(_sa, _sa);
        }

    }






    public static class RxLog
    {
        public static void Trace(string tmsg)
        {
            Debug.WriteLine(tmsg);
        }
    }


    public static class RxGeom
    {
        //----------------------------------------------------------------------
        // 공통함수들 모음
        //----------------------------------------------------------------------
        /// <summary>
        /// 소수점 라운딩 (UI로 표시되는 수치의 정확도를 위함)
        /// </summary>
        /// <param name="tv"></param>
        /// <returns></returns>
        public static double DoubleRound(double tv, int td = 3)
        {
            return Math.Round(tv, td, MidpointRounding.AwayFromZero);
        }


        /// <summary>
        /// 한바퀴 돌아간 라디안 보정
        /// </summary>
        /// <param name="trd"></param>
        /// <returns></returns>
        public static double CheckRadian(double trd)
        {
            if (trd < 0)
                trd = RxGeom.FullRadianHalf + trd;
            else if (trd >= RxGeom.FullRadianHalf)
                trd = trd - RxGeom.FullRadian;
            return RxGeom.DoubleRound(trd);
        }


        /// <summary>
        /// 비주얼객체 외각 사각형 구하기
        /// </summary>
        /// <param name="tpv">TempParentVisual</param>
        /// <param name="ttv">TempTargetVisual</param>
        /// <returns></returns>
        //public static Rect GetVisualBounds(Visual tpv, Visual ttv)
        //{
        //    Rect trct = VisualTreeHelper.GetContentBounds(ttv);
        //    GeneralTransform tgtf = ttv.TransformToAncestor(tpv);
        //    return tgtf.TransformBounds(trct);
        //}


        /// <summary>
        /// 비주얼객체 외각 사각형 구하기 2
        /// </summary>
        /// <param name="tpv">TempParentVisual</param>
        /// <param name="ttv">TempTargetVisual</param>
        /// <param name="trct"></param>
        /// <returns></returns>
        //public static Rect GetVisualBounds(Visual tpv, Visual ttv, Rect trct)
        //{
        //    GeneralTransform tgtf = ttv.TransformToAncestor(tpv);
        //    return tgtf.TransformBounds(trct);
        //}


        /// <summary>
        /// 비주얼객체 외각 사각형 구하기 3
        /// </summary>
        /// <param name="tpv">TempParentVisual</param>
        /// <param name="ttv">TempTargetVisual</param>
        /// <param name="trct"></param>
        /// <returns></returns>
        public static Rect GetVisualBounds(Visual ttv, Rect trct)
        {
            Visual tpv = VisualTreeHelper.GetParent(ttv) as Visual;
            GeneralTransform tgtf = ttv.TransformToAncestor(tpv);
            return tgtf.TransformBounds(trct);
        }
        //----------------------------------------------------------------------




        //----------------------------------------------------------------------
        // 기본적으로 사용되는 것들
        //----------------------------------------------------------------------
        public const double FullAngle = 360;
        public const double FullAngleHalf = FullAngle / 2;
        public const double FullAngleQuarter = FullAngle / 4;

        public const double FullRadian = Math.PI * 2;
        public const double FullRadianHalf = FullRadian / 2;
        public const double FullRadianQuarter = FullRadian / 4;

        public const double ToRadians = Math.PI / 180;
        public const double ToAngles = 180 / Math.PI;




        public static double GetAngleToRadian(double tag)
        {
            double tv = tag * ToRadians;
            return DoubleRound(tv);
        }
        public static double GetRadianToAngle(double trd)
        {
            double tv = trd * ToAngles;
            return DoubleRound(tv);
        }



        public static double GetRadian1(Matrix tmtr)
        {
            double tv = Math.Atan2(tmtr.M12, tmtr.M11);
            return DoubleRound(tv);
        }
        public static double GetRadian2(Matrix tmtr)
        {
            double tv = -Math.Atan2(tmtr.M21, tmtr.M22); ;
            return DoubleRound(tv);
        }



        public static double GetScaleX(Matrix tmtr)
        {
            double tsx = Math.Sqrt(Math.Pow(tmtr.M11, 2) + Math.Pow(tmtr.M12, 2));
            return DoubleRound(tsx);
        }
        public static double GetScaleY(Matrix tmtr)
        {
            double tsy = Math.Sqrt(Math.Pow(tmtr.M21, 2) + Math.Pow(tmtr.M22, 2));
            return DoubleRound(tsy);
        }



        public static double GetTX(Matrix tmtr)
        {
            return DoubleRound(tmtr.OffsetX);
        }
        public static double GetTY(Matrix tmtr)
        {
            return DoubleRound(tmtr.OffsetY);
        }



        public static double GetLeft(Rect trct)
        {
            return DoubleRound(trct.Left);
        }
        public static double GetTop(Rect trct)
        {
            return DoubleRound(trct.Top);
        }
        public static double GetRight(Rect trct)
        {
            return DoubleRound(trct.Right);
        }
        public static double GetBottom(Rect trct)
        {
            return DoubleRound(trct.Bottom);
        }



        public static double GetLeftCenter(Rect trct)
        {
            double tcx = trct.Left + (trct.Width / 2);
            return DoubleRound(tcx);
        }
        public static double GetTopCenter(Rect trct)
        {
            double tcy = trct.Top + (trct.Height / 2);
            return DoubleRound(tcy);
        }


        public static double GetWidth(Rect trct)
        {
            return DoubleRound(trct.Width);
        }
        public static double GetHeight(Rect trct)
        {
            return DoubleRound(trct.Height);
        }



        public static double GetHalfWidth(Rect trct)
        {
            return DoubleRound(trct.Width / 2);
        }
        public static double GetHalfHeight(Rect trct)
        {
            return DoubleRound(trct.Height / 2);
        }
        //----------------------------------------------------------------------

    }


    public class RxImageVisualContainer : FrameworkElement
    {
        public RxImageVisualContainer()
        {
            //SnapsToDevicePixels = true;
            ClipToBounds = true;
            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            //
            _children = new VisualCollection(this);


            //TranslateTransform txa;
            //txa.
        }
        protected Rect _rctBounds;
        protected VisualCollection _children;

        public VisualCollection GetChildren()
        {
            return _children;
        }

        public void AddChild(Visual tv)
        {
            _children.Add(tv);
            //AddVisualChild(tv);
            //AddLogicalChild(tv);
        }

        

        protected override void OnRender(DrawingContext tdc)
        {
            base.OnRender(tdc);

            _rctBounds = new Rect(new Point(0, 0), RenderSize);

            Brush tbrs1 = Brushes.Green.Clone();
            tdc.DrawRectangle(tbrs1, null, _rctBounds);
        }


        protected override int VisualChildrenCount
        {
            get { return _children.Count; }
        }

        protected override Visual GetVisualChild(int ti)
        {
            if (_children.Count > 0)
                return _children[ti];
            else
                return null;
        }

    }


    public class RxImageVisual : DrawingVisual
    {
        public RxImageVisual()
        {
            _mtrtf = new MatrixTransform();
            Transform = _mtrtf;

            VisualBitmapScalingMode = BitmapScalingMode.NearestNeighbor;
        }
        protected MatrixTransform _mtrtf;
        protected BitmapSource _bmpsrc;
        protected Size _szImage;
        protected Rect _rctImage;
        protected Rect _rctBounds;
        public Rect GetBounds() { return _rctBounds; }



        public void Close()
        {
            if (_bmpsrc == null) return;
            _mtrtf.Matrix = Matrix.Identity;
            _bmpsrc = null;
        }

        public void Open(string tfp)
        {
            if (_bmpsrc == null)
            {
                _bmpsrc = new BitmapImage(
                    new Uri("pack://application:,,,/__hb_wpf_71;v1.0.0.1;component/___Images/Img1.png"));                
                _szImage = new Size(100, 100);

                pf_DrawImage();
            }
        }

        private Rect pf_MeasureBounds()
        {
            Rect trct = RxGeom.GetVisualBounds(this, _rctImage);
            trct.Inflate(10, 10);
            return trct;
        }

        protected void pf_DrawImage()
        {
            if (_bmpsrc == null) return;
            
            using (DrawingContext tdc = RenderOpen())
            {
                _rctImage = new Rect(new Point(0, 0), _szImage);
                _rctBounds = pf_MeasureBounds();

                //Brush tbrs1 = Brushes.Red.Clone();
                //tbrs1.Opacity = 1.0;
                //tdc.DrawRectangle(tbrs1, null, _rctImage);

                tdc.DrawImage(_bmpsrc, _rctImage);
            }
        }

        protected void pf_UpdateMatrix(Func<Matrix, Matrix> twcbf)
        {
            if (_bmpsrc == null) return;

            _mtrtf.Matrix = twcbf(_mtrtf.Matrix);
            _rctBounds = pf_MeasureBounds();
        }


        public void ResizeUpdate()
        {
            FrameworkElement tpfe = (FrameworkElement)VisualParent;
            double tcx = tpfe.ActualWidth / 2;
            double tcy = tpfe.ActualHeight / 2;
            MoveCenter(tcx, tcy);            
        }



        //~~~~~~~~~~
        public void MoveLeft(double tv)
        {
            pf_UpdateMatrix(delegate(Matrix tmtr)
            {
                double ttx = tv - RxGeom.GetLeft(_rctBounds);
                double tty = 0;
                tmtr.Translate(ttx, tty);

                return tmtr;
            });
        }

        public void MoveTop(double tv)
        {
            pf_UpdateMatrix(delegate(Matrix tmtr)
            {
                double ttx = 0;
                double tty = tv - RxGeom.GetTop(_rctBounds);
                tmtr.Translate(ttx, tty);

                return tmtr;
            });
        }

		
        //~~~~~~~~~~
        public void MoveLeftCenter(double tv)
        {
            pf_UpdateMatrix(delegate(Matrix tmtr)
            {
                double ttx = tv - RxGeom.GetLeftCenter(_rctBounds);
                double tty = 0;
                tmtr.Translate(ttx, tty);

                return tmtr;
            });
        }

        public void MoveTopCenter(double tv)
        {
            pf_UpdateMatrix(delegate(Matrix tmtr)
            {
                double ttx = 0;
                double tty = tv - RxGeom.GetTop(_rctBounds);
                tmtr.Translate(ttx, tty);

                return tmtr;
            });
        }


        //~~~~~~~~~~
        public void MoveCenter(double tcx, double tcy)
        {
            pf_UpdateMatrix(delegate(Matrix tmtr)
            {
                double ttx = tcx - RxGeom.GetLeftCenter(_rctBounds);
                double tty = tcy - RxGeom.GetTopCenter(_rctBounds);
                tmtr.Translate(ttx, tty);

                return tmtr;
            });
        }


        //~~~~~~~~~~
        public void SetRotateCenter(double trd)
        {
            pf_UpdateMatrix(delegate(Matrix tmtr)
            {
                double tyrd = RxGeom.GetRadian1(tmtr);
                double tnrd = RxGeom.CheckRadian(trd);
                //Debug.WriteLine(string.Format("tyrd: {0}, tnrd: {1} ", tyrd, tnrd));
                if (tnrd != tyrd)
                {
                    double tcx = RxGeom.GetLeftCenter(_rctBounds);
                    double tcy = RxGeom.GetTopCenter(_rctBounds);
                    tmtr.Translate(-tcx, -tcy);

                    tmtr.Rotate(-RxGeom.GetRadianToAngle(tyrd));
                    tmtr.Rotate(RxGeom.GetRadianToAngle(tnrd));
                    tmtr.Translate(tcx, tcy);
                }

                return tmtr;
            });
        }


        //~~~~~~~~~~
		public void SetScaleCenter(double tsx, double tsy)
		{			
			if (tsx < 0.1) return;
			if (tsy < 0.1) return;

            pf_UpdateMatrix(delegate(Matrix tmtr)
            {			
			    double tysx = RxGeom.GetScaleX(tmtr);
			    double tysy = RxGeom.GetScaleY(tmtr);
			
			    double tnsx = RxGeom.DoubleRound(tsx);
			    double tnsy = RxGeom.DoubleRound(tsy);
			
			    if ((tysx != tnsx) && (tysy != tnsy))
			    {
				    double tcx = RxGeom.GetLeftCenter(_rctBounds);
				    double tcy = RxGeom.GetTopCenter(_rctBounds);
				    tmtr.Translate(-tcx, -tcy);
				
            	    double tbsx = 1 / tysx;
            	    double tbsy = 1 / tysy;
                    tmtr.Scale(tbsx, tbsy);
                    tmtr.Scale(tnsx, tnsy);
                    tmtr.Translate(tcx, tcy);
			    }

                return tmtr;
            });
		}


    }


    public class RxImageBoundsVisual : DrawingVisual
    {
        public RxImageBoundsVisual() { }
        private Rect _rct;

        protected void pf_DrawImage()
        {
            if (_rct.IsEmpty) return;

            using (DrawingContext tdc = RenderOpen())
            {
                Debug.WriteLine(_rct);

                //Brush tbrs1 = Brushes.Blue.Clone();
                //tbrs1.Opacity = 0.25;
                //tdc.DrawRectangle(tbrs1, null, _rct);

                Brush tbrs2 = Brushes.Blue.Clone();
                tbrs2.Opacity = 1.0;
                Pen tp1 = new Pen(tbrs2, 3);                
                tdc.DrawRectangle(null, tp1, _rct);
            }
        }

        public void DrawUpdate(Rect trct)
        {
            _rct = trct;
            pf_DrawImage();
        }
    }

}
