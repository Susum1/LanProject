using System.Windows;
using MineLAN.Controllers;

namespace MineLAN;

public partial class MainWindow : Window
{
    private readonly MainWindowController _controller;

    public MainWindow()
    {
        InitializeComponent();

        _controller = new MainWindowController(this);

        _controller.Initialize();
    }

    private void CreateProfileButton_Click(object sender, RoutedEventArgs e)
    {
        _controller.CreateProfile();
    }

    private void DeleteProfileButton_Click(object sender, RoutedEventArgs e)
    {
        _controller.DeleteSelectedProfile();
    }
}