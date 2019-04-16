# leagueScheduler, work in progress

I cannot find a season schedule generation application that takes in a teams preferences or blackout days, so I am making one. It can take in a teams preferred day, time of play, or field and will try and generate the full league schedule with teams playing in their preferred slots as much as possible. It also handles schedules with double headers, and the preffered day can be used inversly filling all days except a non-preferred day if a team has scheduling conflicts.

PC application, gui/forms input to an excel output file with the full schedule, and field/each team schedule on their own sheets.

The working C# applicaiton found in c-Application folder.

Task List Core:
[x] Schedule based on prefered days
[x]  Gui input forms
[]  Excel output formatting
[]  Test

Extra:
[]  Implement time pref fully
[]  Implement field pref fully
[]  Test

![alt text](https://github.com/stuckatmarine/leagueScheduler/blob/master/guiLayout.PNG?raw=true "Gui v1")
