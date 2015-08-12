﻿namespace Muffin.Pictures.Archiver.Tests

open Swensen.Unquote;
open Xunit;

open Muffin.Pictures.Archiver.Tests.TestHelpers
open Muffin.Pictures.Archiver.Domain

module FileMoverTests =

    open Muffin.Pictures.Archiver.FileMover
    open Muffin.Pictures.Archiver.FileSystem

    let copyToDestination _ = ()

    [<Fact>]
    let ``when directory does not exist, it gets created`` () =
        let directoryExists _ = false
        let mutable createDirectoryCalls = []
        let createDirectory path =
            createDirectoryCalls <- List.append [path] createDirectoryCalls
            ignore()

        ensureDirectoryExists directoryExists createDirectory "c:\some\path"

        test <@ ["c:\some\path"] = createDirectoryCalls @>

    [<Fact>]
    let ``when directory exists, it does not get created`` () =
        let directoryExists _ = true
        let mutable createDirectoryCalls = []
        let createDirectory path =
            createDirectoryCalls <- List.append [path] createDirectoryCalls
            ignore()

        ensureDirectoryExists directoryExists createDirectory "c:\some\path"

        test <@ List.isEmpty createDirectoryCalls @>

    [<Fact>]
    let ``when the source and destination files match byte contents, the source file gets deleted`` () =
        let compareFiles _ = true
        let mutable deleteSourceWasCalled = false
        let deleteSource _ = deleteSourceWasCalled <- true

        moveFile copyToDestination compareFiles deleteSource {MoveRequest.Source = ""; Destination = ""} |> ignore

        test <@ true = deleteSourceWasCalled @>

    [<Fact>]
    let ``when the source and destination files do NOT match byte contents, the source file does NOT get deleted`` () =
        let compareFiles _ = false
        let mutable deleteSourceWasCalled = false
        let deleteSource _ =
            deleteSourceWasCalled <- true

        moveFile copyToDestination compareFiles deleteSource {MoveRequest.Source = ""; Destination = ""} |> ignore

        test <@ false = deleteSourceWasCalled @>
