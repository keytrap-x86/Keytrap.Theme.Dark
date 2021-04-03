## Keytrap Theme "Dark"

This is a theme inspired by Discord & JetBrain's Rider

![](https://github.com/varKeytrap/Keytrap.Theme/blob/master/Keytrap.Theme.Demo/Medias/kt_d.png)

![](https://github.com/varKeytrap/Keytrap.Theme/blob/master/Keytrap.Theme.Demo/Medias/demo_screenshot.PNG)

### Installation

```Powershell
Install-Package Keytrap.Theme.Dark
```

### Usage

- *App.xaml* should look like this :

```xaml
<Application
    x:Class="Keytrap.Theme.Demo.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="clr-namespace:Keytrap.Theme.Demo"
    StartupUri="MainWindow.xaml">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/Keytrap.Theme.Dark;component/Themes/Generic.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

- *MainWindow.xaml* :

```xaml
<kt:DarkWindow
    x:Class="Keytrap.Theme.Demo.MainWindow"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:kt="clr-namespace:Keytrap.Theme.Controls;assembly=Keytrap.Theme"
    Title="Keytrap's Dark Theme for WPF"
    Width="970"
    Height="562"
    Style="{StaticResource DarkWindowStyle}"
    mc:Ignorable="d" >
    <Grid>

    </Grid>
</kt:DarkWindow>
```

