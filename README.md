# CBTW_TechTest
This project is a tech test from CBTW which consists in infer a book based on a description given by a user.

## Architecture
The main idea is a Gateway/Microservices architecture, but because of the disposition of the solution, it's more like a modular monolith, where easily can be moved to a microservices architecture.

## AI Model used
The AI model used for this is Gemini 3 Flash

## How to use?
This project could be run of several ways, the recomended one is to compose the docker file "docker-compose.yaml", that will rise up the API and Gateway on ports 5299 and 5135, respectively.

### AI model key
The Google's token in the appsettings.json file in the "CBTW.API" project is one which I used for testing, it's already revoked, so you will have to generate yours.

https://aistudio.google.com/app/api-keys

### Testing strategy
In this project there are just a couple of unit tests on which I made the test of relevant transformations and examples of how the other services/repositories should be implemented, because of the short period of time the rest of the test are pending.

At existing unit test the idea is to create a mock object of the dependency which is being injected and validate the result with XUnit assertions, in some complex objects I used AutoFixture to generate them in order to save some time and avoid large object declarations.

## Future Improvements
There are a lot of improvements which can be done; complete unit tests, usage of retry strategy with Poly (or implement it on Kubernetes), extract API and Gateway in different projects, replacement of custom made Gateway with a library as Ocelot.

With those changes it can be easily adapted to CI/CD and the architecture could be gateway/microservices.