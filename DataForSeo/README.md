# Create 5 tools that make API calls for given input

See [job details](docs/job-details.pdf) (ongoing project project, fixed-price), as posted on March 3, 2020 within `Scripting and Automation`, looking for freelancers with the lowest rates.

## Search Volume lookup for list of keywords

> What I expect from you is to create a small tool that for a given list of keywords and a given configuration file (see below) will lookup the search volume by calling DataForSEO via API. Goal is to divide list of keywords in groups of 700 and make an API call per group. 

Yo.

> Output should be written in a `Output.csv` file.

The `.csv` format (comma-seoparated values, for tabular data) is not ideal for the output because of hierarchical data in the response (in this case at least).

> Please empty keywords.txt file with the keywords that have successfully been queried to DataForSEO while program is running.

Done.

> Settings that need to be set in config file are
> ```xml
> <add key="Login" value="XXX@XXXXX.com"/> we will provide you with
> <add key="Password" value="XXXXXXXXXX"/>
> <add key="Location" value="France"/>
> <add key="Language" value="fr"/>
> ```

Note that these settings have to be set within the `<appSettings><appSettings/>` section (see [App.config](src/DataForSeo.SearchVolume/App.config))

> Please return Cost of task in execution window when program has finished running.

Done. Note that "your account will be charged only for setting a task", this value being returned on the [Task POST](https://docs.dataforseo.com/v3/keywords_data/google/search_volume/task_post) request, available before task(s) completion (created with `Standard` priority) and results retrieval.