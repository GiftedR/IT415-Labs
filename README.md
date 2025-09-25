# Reflection

__a.__ The O(1) time went down with each, but I believe that is as a result of the data being cached. However without the caching, the time would be the same.

__b.__ The O(n) time also went down then back up with the increasing number of items, for the same reason as before. But it was still slower in relation to O(1).

__c.__ The O(n²) time showed a vast increase with each increase in items. It was wildly slower thatn the other methods. (I had to run it a few times as the first ones had quadratic n=1000 being faster than linear n=1000)

__d.__ My results do when considering margin of error. I believe the places it doesnt match is in relation to how the compiler handles processing of some data (Like caching).

__Results:__

![Test Results](/docs/ResultsScreenshot.png)
