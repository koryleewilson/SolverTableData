This problem was simple enough that I did not contemplate many options.

I considered adding paging, but I did not see that giving you much more information about me.

I considered adding unit tests, but again I did not see that adding value.

I did actually enjoy solving problems and writing code again as it has now been a few weeks.

I did add an extra repository method for getting filtered data.  I mainly did that to show parameterization, but also because it just felt right.

I do agree paging should be added.  That should include a paged data object with not only the data asked for but paging information like total pages and the page number returned.

I would want to see the use but making it async would probably be beneficial as well.

As for the bonus questions:
* Can we make the amount of JSON returned smaller in any way?
	Since this is table data. you could define the header and then rows for the data.  That would avoid defining the header values for every row.
* Can we add support for paging?
	Answered above. You could that using Take and Skip on a rowset or in SQL with OFFSET and FETCH 
* Can we add a simple front-end to show it working?
	Sure, I used Postman for a front end to test with.  I am most comfortable with MVC, so that is what I would use to test with, but I feel Postman is better as it allows me to see the raw payload.
* Can we follow foreign keys to display values?
	Yes, I believe schema information is available in SQLServer.

Update: I went ahead and added a simple unit test for the controller
