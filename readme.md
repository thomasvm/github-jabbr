## github-jabbr
Toss your github pushes to a [Jabbr](https://github.com/davidfowl/JabbR) instance

###instructions
* git clone this repository
* modify the Jabbr.GitHub\config.json file

		{
		    default: {
		        jabbr: "http://yourjabbbr.net",
		        rooms: [ "roomA" ],
		        username: "your user name",
				password: ""
		    },
		    "name-of-your-repository": {
		        rooms: [ "roomA", "roomB" ],
				template: "customtemplate.cshtml"
		    }
		}

* You can specify custom configurations per repository. The `default` object will be used for any other repository
* for custom messages simply add a Razor template to the templates folder,
  it will receive a dynamic object containing the [payload](https://help.github.com/articles/post-receive-hooks)
* Open Solution in Visual Studio and F5

Next configure your github repository for a Post-Receive hook, we can receive payload on the `/github` path
![configure github](https://raw.github.com/thomasvm/github-jabbr/master/doc/configuration.png)

###appharbor
This project run on the awesome [AppHarbor](http://appharbor.com/), simply clone, adjust the config and push

###what i used
* [Nancy](http://nancyfx.org/), a perfect match for this project
* [Jabbr.Client](https://github.com/davidfowl/JabbR.Client), so I didn't have to care about the protocol
* [RazorEngine](http://razorengine.codeplex.com/), for easy rendering of the payload
