namespace ModelOfLAN

/// type of operating system
type OS = | Windows | Linux | OS_X

/// computer of local network
type Computer(abbr:char, id:int) =
    //private
    let mutable isInfected = false
    let healthPoints =
        match abbr with
        | 'w' -> 60
        | 'l' -> 70
        | 'o' -> 50
        | _ -> 30
    
    /// ID of computer in local network
    member val ID = id with get
    
    /// checks the health of computer
    member this.IsInfected () = isInfected;
    
    /// simulates a viral attack on the computer
    member this.Infect damagePoint =
        if damagePoint >= healthPoints then
            isInfected <- true


/// this class simulates the work of the local network
type LocalNetwork(infectedComputers, input:string) =
    let mutable computers = Array.empty
    let mutable adjacencyList = Seq.empty
    let random = System.Random()
    do
        let strs = input.Split('\n')
        computers <- Seq.toArray (Seq.mapi (fun i x -> new Computer(x, i)) << Seq.head <| strs)
        Seq.iter (fun i -> computers.[i].Infect(100)) infectedComputers

        let neighbors k = Seq.map (fun x -> int x) << String.filter (fun x -> x <> '0')
                          << String.mapi (fun i x -> if (x = '1') then char i else x) <| Seq.item k strs

        adjacencyList <- Seq.take computers.Length <| Seq.init computers.Length (fun n -> neighbors <| n + 1)

    /// shows the adjacency matrix in the console
    member this.ShowAdjList () =
        Seq.iter (fun ls -> Seq.iter (fun n -> printf "%A" n
                                               printf " ") ls
                            printfn "") adjacencyList

    /// shows the health of each computer
    member this.ShowSystem () =
        let fontColor (comp:Computer) =
            if comp.IsInfected () then System.Console.ForegroundColor <- System.ConsoleColor.Red
            else System.Console.ForegroundColor <- System.ConsoleColor.Gray
        let health (comp:Computer) =
            if comp.IsInfected () then "infected"
            else "healthy"
        Seq.iter (fun x -> fontColor x
                           System.Console.WriteLine("computer number " + x.ID.ToString () + " is " + (health x))) computers
    
    /// simulates the unit of time and performs changes in the system
    member this.Step () =
        let infected =
            Array.fold
                (fun acc (comp:Computer) -> if comp.IsInfected () then comp.ID :: acc else acc)
                []
                computers
        let tryInfect =
            Seq.fold (fun acc i -> Seq.append acc <| Seq.item i adjacencyList) Seq.empty infected
        let genRandomNumbers =
            List.init computers.Length (fun _ -> random.Next ())
        Seq.iter2 (fun i dmg -> computers.[i].Infect(dmg)) tryInfect genRandomNumbers

    /// checks the health of the system
    member this.IsUnhealthy () =
        Array.forall (fun (comp:Computer) -> comp.IsInfected ()) computers

    /// returns a list of healthy computers
    member this.GetHealthyComputers () =
        Array.fold (fun acc (comp:Computer) -> if comp.IsInfected () then acc else (comp.ID :: acc)) [] computers