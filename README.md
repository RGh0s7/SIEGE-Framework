# SIEGE Framework #
SIEGE Framework is a open source cross site scripting framework written to simplify Cross Site Scripting across multiple sites / pages
## Lets get started ##
First of all you should compile this project with Any C# Compiler. When you got the compiled binary you can create a directory called "Siege" and put all your compatible exploits in it.
When you are done with putting your exploit directory together, you can start or reload the program 
and use to find the Exploit you want to use.
```
search Example
```
when you finally found the exploit that 
you want to use you can select it with
```
use Example
```
when you selected your exploit you can see the required variables with
```
show
```
when you know what variables must be set you can use
```
set target example.com
```
and
```
set var0 test
```
when you finished configuring your settings and varibales you can run the exploit with
```
exploit
```
## Features ##
* Simple Exploit writing
* Reading Targets from a list
## Examples ##
### Exploits ###
for example if your url is 
```
http://example.com/index.php?q=1
```
save it to a new file in the exploit directory like this
```
http://+target/index.php?q=+var0
```
### List ###
```
example.com
example.com
example.com
```
## FAQ ##

