You've written a script and are producing an independant film about software engineers called "Hack & Slash". It's going to quickly become an expensive venture so it'd be good idea to start managing your budget now. And since the movie is about hackers, it's probably best that your budgeting tool be run from the terminal.

Most of the little things in the budget have already been handled. The only things that'll you'll have to manage are the cast, crew, and locations. You'll start with an existing codebase, and some of the cast and crew that have already signed on have already come preloaded into the program. Any additional ones will have to be entered by the users of the budgeting tool. The inital budget stands at \$1M, but if you're running low on funding, you can bring on additional executive producers who are willing to financially contribute to the project.

## Tickets

- When app starts, the following information should be displayed:

  - [Name of the movie]
  - Starring: [top 2 paid cast members]
  - Produced by: [List of producers]

- When the app starts the user should see a list of numbered items in a main menu with the following options:

  1. Manage Cast
  1. Manage Crew
  1. Manage Locations
  1. Schedule
  1. Add Producer
  1. Expense Report

  When the user selects the `Manage Cast` option, they should be presented with another menu with the following options:

  1. Show Cast
  1. Hire a Cast Member
  1. Fire a Cast Member
  1. Search by Name
  1. Go Back

  When the user selets `Go Back`, they should be taken back to the main menu.

- When the user selects `Add Producer`, they should be prompted to add the producer's name along with their financial contribution to the film.

- When the user selects `Manage Cast` from the main menu and then selects `Show Cast`, the user should see a list of all cast members in the movie, ordered descending by their pay. The user should then be prompted to hit `Enter` to return back to the main menu

- When the user selects `Manage Cast` from the main menu and then selects `Hire a Cast Member`, the user should be prompted to enter in their name followed by their pay. The cast member should then be added to the list of all cast members, the user should be taken back to the main menu and shown a success message.

- When added a Cast Member to the cast and the budget cannot accomodate their pay, the cast member should not get added to the cast list and the user should be taken back to the main menu with an error message explaining that the project does not have enough funds.

- When the user selects `Manage Cast` from the main menu and then selects `Fire a Cast Member`, they should be shown a numbered list of all cast members, along with an option to `Go Back` which takes them back to the main menu. If the user chooses the number of a cast member, they should be removed from the cast list and the user should be taken back to the main menu.

- When the user selects `Manage Cast` from the main menu and then selects `Search by Name`, they should be prompted to type in the name of a cast member. They should then be shown a list of cast members with names and pay whose name matches the user's search. The search should not be case sensitive. The user should then be prompted to hit any key to be taken back to the main menu.

- When the user selects `Manage Cast` from the main menu and then selects `Show Cast`, the resulting list should be paginated with 5 records per page. The user should be able to hit the up and down arrow keys to page through the results. Hitting `Enter` should return to the main menu.

- When the user selects `Expense Report`, the following information should be displayed:

  1. Total budget
  1. Total cost of cast
  1. Total cost of each crew title (i.e total cost all camera operators, total cost of all lighting operators, etc.)
  1. Amount remaining

  The user should then be prompted to hit any key to return to the main menu.

- When the user selects `Manage Crew` from the main menu, they should be presented with another menu with the following items:

  1. Show Crew
  1. Hire Crew Member
  1. Fire Crew Member
  1. Go Back

  When the user selects the `Go Back` option, they should be taken back to the main menu.

- When the user selects the `Manage Crew` option from the main menu and then selects `Show Crew`, they should be shown a list of all crew members, ordered descending by pay, and includes their name, job title, and pay. The user should then be prompted to hit `Enter` to return to the main menu.

- When the user selects the `Manage Crew` option from the main menu and then selects `Hire a Crew Member`, the user should be prompted to enter the crew member's name, title, and pay. The crew member should then be added to the movie's crew list.

- When the user attempts to add a crew member whose pay cannot be accomodated by the budget, they should not be added to the list of crew members. Instead the user should be returned to the main menu and be shown an error message

- When the user selects the `Manage Crew` option from the main menu and then selects `Fire a Crew Member`, they should be shown a numbered list of all crew members, along with an option to `Go Back` which takes them back to the main menu. If the user chooses the number of a crew member, they should be removed from the crew and the user should be taken back to the main menu.

- When the user selects `Manage Crew` from the main menu and then selects `Show Crew`, the resulting list should be paginated with 5 records per page. The user should be able to hit the up and down arrow keys to page through the results. Hitting `Enter` should return to the main menu.

- When the user selects `Manage Locations` from the main menu, they should be shown another menu with the following options:

  1. Show Locations
  1. Add a Location
  1. Go Back

  When the user selects the `Go Back` option, they should be taken back to the main menu.

- When the user selects `Manage Locations` from the main menu and then selects `Show Locations`, they should be shown a list of all filming locations. The user should then be prompted to hit `Enter` to return to the main menu.

- When the user selects `Manage Locations` from the main menu and then selects `Add a Location`, they should be prompted to enter the name of the location along with the cost of shooting there for one day. The location should then be added to the movie's list of shooting locations. **NOTE:** _The cost of locations does not get added to budget until it gets added to a schedule (later story)_

- When the user selects `Schedule` from the main menu, they should be shown another menu with the following options:

  1. Show Schedule
  1. Add Shoot
  1. Go Back

  When the user selects the `Go Back` option, they should be taken back to the main menu.

- When the user selects `Schedule` from the main menu and then `Add Shoot`, they should be prompted to enter a name for the scene and then presented with a numbered list of all shooting locations. The user can then select a location for the shoot. They should then be prompted to enter a start date and end date for shooting in that location.

- When the user adds a scheduling item and the resulting cost of that location (daily cost \* number of days) is more than the budget can accomodate, the user should be shown an error message and be taken back to the main menu.

- When the user selects `Expense Report` from the main menu, the report should also include the total cost of shooting locations

- When the user is adding a schedule item, after entering the start and end dates, they should be prompted to add cast members to the shoot and presented with a numbered list of all cast members. The user should be able to add multiple cast members. Once the user hits `Enter` without choosing a menu item, the shoot should be added to the schedule and the user should be taken back to the main menu.

- When the user selects `Manage Cast` from the main menu and then `Search by Name`, the results from their search should also include the cast members' schedule.

- When the user selects `Schedule` from the main menu and then `Show Schdule`, they should see a list of all scheduled shoots. Each item should show the name of the scene, the location of the shoot, the start and end dates of the shoot, and the cast members on the call sheet.
