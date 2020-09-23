What's new in csharp 9.0?
=========================
_Quick collection of examples of what's new in C# 9.0. Also, you should check out the [what's new guide by Microsoft](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9)._

But first, how do I get this thing?
-----------------------------------
Downloads for different platforms are available at [dotnet.microsoft.com/download/dotnet/5.0](https://dotnet.microsoft.com/download/dotnet/5.0).

Top-level programs
------------------
Whish C# was more like a scripting language? Not so much ceremony? Now you can have it! Try running "TopLevel":

```shell
$ TopLevel> dotnet run -- 10
The sum of all the multiples of 3 or 5 below 10 is 23
```

Some things to note:
* Stuff all using statements at the top.
* Only do this in one file. The rest has to be done as usual.
* Please return a status code if you want.
* args will magically be available.
* Yeah, await works as well.

Init only setters
-----------------

Records
-------

Pattern matching
----------------
