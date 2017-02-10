# SerenataFlowers

*Notes*

To get everything started just execute the SF.Webserver.exe program, it will begin listening for requests at ```http://localhost:9092/```
The latest SPA build is located in the web servers 'App' folder so visiting ``http://localhost:9092/``` will serve it up.

The SPA does come with it's own development server however. To start that up, run ``` npm run dev ```. The development server brings
strict ES Linting, in browser error reports, Hot module reloading and many other development conveniences. It runs on ```http://localhost:8080/```

There are three projects:

*SF.WebServer*

A self hosted owin server that hosts a WebApi server and a File Server. The WebApi server has two controllers. 
  - The cart controller which contains The List, Add, Remove and Clear cart commands
  - The product controller which returns all products

The file server may be used to host the built SPA, just add the built distributable files of the SPA into the 'App' folder at the program root.

*SF.Web*

The SPA written in VueJS. This project was built in VS Code using the Vue-Cli program to create the basic template.
In order to run the development version, please run ``` npm run dev ``` from the main directory.

To build the distributable files just run ``` npm run build ```. The files are output to the ```dist``` directory.

* Design *


