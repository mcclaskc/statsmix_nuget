[dl_nuget]: https://www.statsmix.com/download/java/statsmix.jar
[dl_dep]: https://www.statsmix.com/download/java/statsmix-lib-dependencies.tar.gz
[track_exmpl]: https://github.com/mcclaskc/statsmix_nuget/blob/master/StatsMix/Examples/Track.csa

StatsMix
========
This Nuget offers easy access to the StatsMix API. See www.statsmix.com/developers/documentation for more information.
What is StatsMix?
-----------------
StatsMix makes it easy to track, chart, and share application and business metrics. Use StatsMix to:

*Log every time a particular event happens (such as a user creating a new blog post)
*View a real-time chart of these application events in StatsMix's web UI
*Share the charts with users inside and outside your organization
*Create and share custom dashboards that aggregate multiple metrics together
  *Example dashboard: http://www.statsmix.com/d/0e788d59208900e7e3bc
  *Example embedded dashboard: http://www.statsmix.com/example-embedded
To get started, you'll need an API key for StatsMix. You can get a free developer account here: http://www.statsmix.com/try?plan=developer

Full gem documentation is at http://www.statsmix.com/developers/ruby_gem

Download and Install
--------------------
Our Nuget can be found in the Nuget Gallery [here] [dl_nuget].

Usage 
------
###Initialize
Create a new StatsMix Client
```c#
using StatsMix;
...
Client smClient = new Client("YOUR_API_KEY");
```
###Track
The track method sends a request to the track API, and returns the XML response as a string. The following snippets were taken from [this example file.] [track_exmpl] 

Basic Tracking.  Adds a new stat with default value of 1 to the metric.
```c#
smClient.track("Metric Name");
```

Track with a value other than one
```c#
smClient.track("Metric Name", 5.2);
```

Track with additional properties
```c#
var properties = new Dictionary<string, string>();
properties.Add("value", "5.1"); //If you do not include value, it will default to 1
properties.Add("ref_id", "Test01");
properties.Add("generated_at", DateTime.Now.ToString());
smClient.track("metric_name", properties);
```

Track with meta data
```c#
var meta = new Dictionary<string, string>();
meta.Add("food", "icecream");
meta.Add("calories", "500");
smClient.track("metric_name", properties, meta);
```