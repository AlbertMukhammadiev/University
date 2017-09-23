module Tests

open ModelOfLAN
open NUnit.Framework
open FsUnit

type ModelOfLANTest() =
    let input = "wllowlwowlolwow\n010011000000000\n101010000000000\n010110000000000\n001010101000000\n111100000000000\n100000010100000\n000100001010000\n000001001001000\n000100110000000\n000001000001100\n000000100001001\n000000010110000\n000000000100010\n000000000000101\n000000000010010"
    let LAN = new LocalNetwork([3; 11], input)
    
    [<Test>]
    member this.``test of GetHealthyComputers`` () =
        let ls = [0; 1; 2; 4; 5; 6; 7; 8; 9; 10; 12; 13; 14]
        let healthy = LAN.GetHealthyComputers()
        Seq.sort healthy |> should equal ls

    [<Test>]
    member this.``test of Step`` () =
        LAN.Step()
        let ls = [0; 1; 5; 12; 13; 14]
        let healthy = LAN.GetHealthyComputers()
        Seq.iter (fun x -> healthy |> should contain x) ls
        LAN.Step();
        LAN.GetHealthyComputers() |> should contain 13

    [<Test>]
    member this.``test of status of system`` () =
        LAN.IsUnhealthy() |> should equal false
        let unhealthyLAN = new LocalNetwork([0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14], input)
        unhealthyLAN.IsUnhealthy() |> should equal true