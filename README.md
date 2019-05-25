# Discord RichPresence Updater

Command line arguments:

```

--app-id              Required. The ID of the application created at discord's developers portal                              
                                                                                                                              
--details             What the user is currently doing                                                                        
                                                                                                                              
--state               The user's current party status                                                                         
                                                                                                                              
--large-image         Name of the uploaded image for the large profile artwork                                                
                                                                                                                              
--large-image-text    The tooltip for the large square image. For example, "Summoners Rift" or "Horizon Lunar Colony"         
                                                                                                                              
--small-image         Name of the uploaded image for the small profile artwork                                                
                                                                                                                              
--small-image-text    The tooltip for the small circle image. For example, "LvL 6" or "Ultimate 85%"                          
                                                                                                                              
--tick-rate           (Default: 1000) How often to change rich presence, in milliseconds                                      
                                                                                                                              
--help                Display this help screen.                                                                               
                                                                                                                              
--version             Display version information.          

```


Example with `RpcUpdater.exe --app-id 580402365937483796 --details "A problem has been detected and Windows has been shut down to prevent damage to your computer." --large-image bsod`:

![image](https://user-images.githubusercontent.com/4542110/58374539-4a23b780-7f40-11e9-892a-b7a49ba2e562.png)
