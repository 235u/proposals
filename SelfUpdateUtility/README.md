# Self-Update Utility

## Requirements

See [Requirements.pdf](Requirements.pdf) for complete job description (one-time project, fixed-price).

> I need to write a class in c# that will self update an application and restart it.
>
> You just need to complete the class bellow and write a simple form testing app with 2 buttons that will call the methods:
```
public class SelfUpdate
{
    //the list should come from .config file
    string files2update = "somefile.dll,someotherfile.txt";

    public void UploadLatestFiles()
    {
        //this should ZIP the latest .exe and .config plus files in files2update and upload it to S3 bucket
        //also upload a small file called "lastmodified.txt" with a current timestamp
    }

    public void SelfUpdate()
    {
        /*
            * THIS SHOULD UPDATE THE APP AND RESTART IT:
            *
        check the lastmodified.txt on S3 and if it's different from the current one
        then download the ZIP file, rename currently running exe to appname.old.exe and then
and unzip it overwriting the old files            
        then it should start a new process exactly as currently running one and exit currently running process     the exe name and command line arguments for the new process should be copied from current process. Keep in mind it should work in MONO too.
        */
    }
}
```

## Solution

Top-level components:

- Class Library (.NET Standard 2.0)
- Windows Forms Test Application (.NET Framework 4.7.2)

### Major Adjustments

- The version check is done explicitly (extracted from the self-update function), to be able to provide feedback to the users;
- the self-update function does not close it's host application instance, it has to be done by the host application itself:
```csharp
private async void OnPullButtonClick(object sender, EventArgs e)
{
    try
    {
        if (await SelfUpdate.IsUpToDate())
        {
            MessageBox.Show(
                "The application is up to date.",
                MessageBoxCaption.Information,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        else
        {
            Cursor.Current = Cursors.WaitCursor;
            await SelfUpdate.Pull();
            Cursor.Current = Cursors.Default;
            Close();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, MessageBoxCaption.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```
The final implementation will vary depending on the host application type (e.g. by calling the [Close](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.close?view=netframework-4.7.2) method on the main window or [Application.Exit](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.application.exit?view=netframework-4.7.2) in a Windows Forms application, not available for console applications).


### Issues

Getting a TrustFailure WebException with Mono 6.4.0.198 on Windows x64 ...

> Windows Mono builds don't currently support TLS 1.2

... according [this](https://github.com/mono/mono/issues/10489) (still open) GitHub issue, being recommended by Amazon (see [Infrastructure Security in Amazon S3](https://docs.aws.amazon.com/AmazonS3/latest/dev/network-isolation.html)).