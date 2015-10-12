#Admin Application

## Description

Howto prevent your application from not running in administrator mode.

```csharp
protected override void OnStartup(StartupEventArgs e)
{
    base.OnStartup(e);

    if (!IsAdministrator())
    {
        MessageBox.Show("Need Administrator rights");
        Shutdown(0);
    }
}
```