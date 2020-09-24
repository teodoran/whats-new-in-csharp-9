What's new in csharp 9.0?
=========================
_Quick collection of examples of what's new in C# 9.0. Also, you should check out the [what's new guide by Microsoft](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9)._

### But first, how do I get this thing?
Downloads for different platforms are available at [dotnet.microsoft.com/download/dotnet/5.0](https://dotnet.microsoft.com/download/dotnet/5.0).

### Top-level programs
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

Where could this be useful?
* When writing short scripts
* When working on batch jobs

### Init only setters
A lot of times you have properties on objects that should not be changed after the object is created. Traditionally this require a lot of work with `readonly` and constructors. Init only setters makes this easier.

Have a look at the example is "InitProperties". Status.Name should not be changed. Here we could use an init only setter to avoid the problem.

Where could this be useful?
* When you have select properties that should not change. Maybe ID-properties?
* Would probably use record more?

### Records
Sometimes all properties on an object should not be mutable. This is where records shine. In addition they come with built in equality by properties. Have a look at "Records" to see some examples of how records can be used.

Where could this be useful?
* All over the place in domain models.
* How will they work with libraries and frameworks?

### Pattern matching
Have a look at the [pattern matching enhancements section](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#pattern-matching-enhancements) in the what's new in C# 9.0 article from Microsoft.

The "PatternMatching" project includes some examples, with and without switch expressions.

Where could this be useful?
* Would probably implement some stuff as methods on different sub-objects.
* When working on complex logic.
