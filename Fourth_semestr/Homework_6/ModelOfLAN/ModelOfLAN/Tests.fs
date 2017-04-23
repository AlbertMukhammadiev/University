module Tests

open ModelOfLAN
open NUnit.Framework
open FsUnit

type ModelOfLANTest() =
    let LAN = new LocalNetwork([3; 11])
    
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
        let unhealthyLAN = new LocalNetwork([0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14])
        unhealthyLAN.IsUnhealthy() |> should equal true