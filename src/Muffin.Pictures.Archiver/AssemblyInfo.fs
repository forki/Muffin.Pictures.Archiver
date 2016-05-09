﻿namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("Muffin.Pictures.Archiver")>]
[<assembly: AssemblyProductAttribute("Muffin.Pictures.Archiver")>]
[<assembly: AssemblyDescriptionAttribute("Archiver for Muffin's pictures")>]
[<assembly: AssemblyVersionAttribute("0.4.0")>]
[<assembly: AssemblyFileVersionAttribute("0.4.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.4.0"
