## Project Features

This project provides a front end for designing applications and associated
databases in a way that is accessible to non-developers.  JigArchitect also
includes the ability to configure build pipelines for generated solutions.

The project currently uses an Angular 1 front end backed by an ASP.Net Core API.


## Build Instructions

The front end requires Node.js and subsequently NPM.  After cloning the repo,
run 'npm install' followed by 'gulp watch'.  There currently is no built in
solution for hosting the front end but IIS does just fine if pointed to wwwroot.

The back end requires ASP.Net Core to compile.  After installing, navigate to
the 'Server/src/Jig.JigArchitect.Api' directory and run 'dotnet build'.

## Road Map

## Bootstrapping process
