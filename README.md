# Exercise for Inimco :)

This project is not complete/running as it requires time and effort to design every component of the solution.

Contains:
* Frontend layer written in angular / typescript
* Backend layer written in ASP.NET / C#

## About (me)

I have never set up an angular project or ASP.NET project in my professional carreer. This execise is just a quick setup of how i would go about implementing such a project. It is a quick demonstration of my intent.


# Future work


The following things still need to be done for a functional product:
* Wire backend together
    * extend DI services, create factory for the operations in the API layer that can be injected in minimal API's
    * create wrapper around app.MapGet ect so that wrapper objects / generics can be used
    * create the persistence layer completely, currently there's no EntityFramework installed yet. Configurations and migrations should be added to the persistence layer
* Completely create the frontend, currently only a basic angular project has been setup
    * Create a nice UI layer
    * inplement service layer that connects to the backend API

Important things that are ideally also done:
* Tests, tests, tests
    * More unittests in backend, the operations should definitely be unittested
    * frontend layer can use fluent API tests describing the layout
* Dockerfile / images and a docker-compose template to wire backend and frontend nicely together
    * This is really considered the next step if you want to deploy this webapp 
* Create and use more angular components, even OOB components such as a navbar or basic styling








