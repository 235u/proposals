# Self-Update Utility

## Requirements

See Requirements.pdf for complete job description (fixed-price one-time project).

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