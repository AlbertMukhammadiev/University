module Tests


open ModelOfLAN
open NUnit.Framework
open FsUnit

type ModelOfLANTest() =
    let LAN = new LocalNetwork("C:\Users\Альберт\Documents\GitHub\University\Fourth_semestr\Homework_6\ModelOfLAN\ModelOfLAN\matrix.txt", [3; 11])
    
    [<Test>]
    let ``test of GetHealthyComputers`` () =
        let ls = [0 .. 14]
        let healthy = LAN.GetHealthyComputers()
        Seq.sort healthy |> should equal ls