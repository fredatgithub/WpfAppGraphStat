using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfAppGraphStat
{
  /// <summary>
  /// Logique d'interaction pour MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void MyCanvas_Loaded(object sender, RoutedEventArgs e)
    {
      DessinerAxes();
      DessinerGraduations();
      DessinerCourbe();
    }

    private void DessinerGraduations()
    {
      double canvasWidth = MyCanvas.ActualWidth;
      double canvasHeight = MyCanvas.ActualHeight;
      List<double> valeurs = new List<double> { 10, 50, 80, 40, 90, 60, 30 };

      double stepX = canvasWidth / (valeurs.Count - 1);

      // Graduations pour l'axe des abscisses (X)
      for (int i = 0; i < valeurs.Count; i++)
      {
        double x = i * stepX;
        Line graduation = new Line
        {
          X1 = x,
          Y1 = canvasHeight,
          X2 = x,
          Y2 = canvasHeight - 5,
          Stroke = Brushes.Black,
          StrokeThickness = 1
        };
        MyCanvas.Children.Add(graduation);

        TextBlock labelX = new TextBlock
        {
          Text = $"Pt{i + 1}",
          Foreground = Brushes.Black
        };
        Canvas.SetLeft(labelX, x - 10);
        Canvas.SetTop(labelX, canvasHeight + 5);
        MyCanvas.Children.Add(labelX);
      }

      // Graduations pour l'axe des ordonnées (Y)
      int nombreGraduationsY = 10;
      for (int i = 0; i <= nombreGraduationsY; i++)
      {
        double y = canvasHeight - (i / (double)nombreGraduationsY * canvasHeight);
        Line graduation = new Line
        {
          X1 = 0,
          Y1 = y,
          X2 = 5,
          Y2 = y,
          Stroke = Brushes.Black,
          StrokeThickness = 1
        };

        MyCanvas.Children.Add(graduation);

        TextBlock labelY = new TextBlock
        {
          Text = $"{i * 10}",
          Foreground = Brushes.Black
        };
        Canvas.SetLeft(labelY, 10);
        Canvas.SetTop(labelY, y - 10);
        MyCanvas.Children.Add(labelY);
      }
    }

    private void DessinerAxes()
    {
      double canvasWidth = MyCanvas.ActualWidth;
      double canvasHeight = MyCanvas.ActualHeight;

      // Axe des abscisses (X)
      Line axeX = new Line
      {
        X1 = 0,
        Y1 = canvasHeight,
        X2 = canvasWidth,
        Y2 = canvasHeight,
        Stroke = Brushes.Black,
        StrokeThickness = 2
      };

      // Axe des ordonnées (Y)
      Line axeY = new Line
      {
        X1 = 0,
        Y1 = 0,
        X2 = 0,
        Y2 = canvasHeight,
        Stroke = Brushes.Black,
        StrokeThickness = 2
      };

      // Ajouter les axes au Canvas
      MyCanvas.Children.Add(axeX);
      MyCanvas.Children.Add(axeY);
    }

    private void DessinerCourbe()
    {
      // Exemple de données
      List<double> valeurs = new List<double> { 10, 50, 80, 40, 90, 60, 30, 10, 50, 80, 40, 90, 60, 30 };

      // Dimensions du Canvas
      double canvasWidth = MyCanvas.ActualWidth;
      double canvasHeight = MyCanvas.ActualHeight;

      // Préparer la courbe (Polyline)
      Polyline polyline = new Polyline
      {
        Stroke = Brushes.Blue,
        StrokeThickness = 2
      };

      // Calculer l'espacement horizontal
      double stepX = canvasWidth / (valeurs.Count - 1);

      // Ajouter les points à la Polyline
      for (int i = 0; i < valeurs.Count; i++)
      {
        double x = i * stepX;
        double y = canvasHeight - (valeurs[i] / 100 * canvasHeight);
        polyline.Points.Add(new Point(x, y));
      }

      // Ajouter la courbe au Canvas
      MyCanvas.Children.Add(polyline);
    }
  }
}
