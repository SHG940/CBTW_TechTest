# CBTW_TechTest
This project is a tech test from CBTW which consists in infer a book based on a description given by a user.

## AI Model used
The AI model used for this is Gemini 3 Flash

## How to use?
This project could be run of several ways, the recomended one is to compose the docker file "docker-compose.yaml", that will rise up the API and Gateway on ports 5299 and 5135, respectively.

The Google's token in the appsettings.json file in the "CBTW.API" project is one which I used for testing, it's already revoked, so you will have to generate yours.