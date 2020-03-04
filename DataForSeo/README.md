# Create 5 tools that make API calls for given input

See [job details](docs/job-details.pdf) (ongoing project project, fixed-price), as posted on March 3, 2020 within `Scripting and Automation`, looking for freelancers with the lowest rates.

## Search Volume lookup for list of keywords

> Goal is to divide list of keywords in groups of 700 and make an API call per group. 

Note that there is no need to make an API call per keyword group (via multiple `HTTP POST` requests), as multiple tasks can be created by a single [Task POST](https://docs.dataforseo.com/v3/keywords_data/google/search_volume/task_post) request. 

>> You can send up to 700 keywords in one `keywords` array. Our system will charge your account per request, no matter what number of keywords an array has, the price for 1 or 700 keywords will be the same.

The limitation of 700 keywords is for a single task (as I did understand).

> Output should be written in a `Output.csv` file.

The `.csv` format (comma-separated values, for tabular data) might be inappropriate for the output because of hierarchical data in the response (see [CompletedTaskResultsResponse.json](src/DataForSeo.SearchVolume/CompletedTaskResultsResponse.json); I'd stick to `JSON`, as being used by the [API](https://docs.dataforseo.com/v3/keywords_data/overview)).

> Please empty `keywords.txt` file with the keywords that have successfully been queried to DataForSEO while program is running.

Note that the "plus symbol '+' will be decoded to a space character", "maximum number of words for each keyword phrase" is 10, and "the maximum number of characters for each keyword" is 80.

Following `Keywords.txt`

```
average page rpm adsense
what is this+all about
```

results in 2 keyword phrases and 9 keywords (`this+all` being split in `this all`) in total.

> Settings that need to be set in config file are
> ```xml
> <add key="Login" value="XXX@XXXXX.com"/> we will provide you with
> <add key="Password" value="XXXXXXXXXX"/>
> <add key="Location" value="France"/>
> <add key="Language" value="fr"/>
> ```

Note that these settings have to be set within the `<appSettings></appSettings>` section (see [App.config](src/DataForSeo.SearchVolume/App.config))

> Please return Cost of task in execution window when program has finished running.

Note that "your account will be charged only for setting a task", and the `cost` value is being returned on the [Task POST](https://docs.dataforseo.com/v3/keywords_data/google/search_volume/task_post) request as "total tasks cost, USD" (for all tasks created by this request), being available before task(s) completion (created with `Standard` priority) and results retrieval.