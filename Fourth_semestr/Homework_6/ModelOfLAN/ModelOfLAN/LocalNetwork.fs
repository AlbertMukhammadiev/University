namespace ModelOfLAN

open System.IO

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

//    /// type of operating system
//    member val OperatingSystem = os with get, set
    
    /// ID of computer in local network                                    ????????????????????????????????????????
    member val ID = id with get
    
    /// checks the health of computer
    member this.IsInfected () = isInfected;
    
    /// simulates a viral attack on the computer
    member this.Infect damagePoint =
        if damagePoint >= healthPoints then
            isInfected <- true


/// this class simulates the work of the local network
type LocalNetwork(file:string, infectedComputers) =
    let mutable computers = Array.empty
    let mutable adjacencyList = Seq.empty
    
    do
        use stream = new StreamReader(file)
        computers <- Seq.toArray (Seq.mapi (fun i x -> new Computer(x, i)) <| stream.ReadLine())
        Seq.iter (fun i -> computers.[i].Infect(100)) infectedComputers

        adjacencyList <-
            seq { use stream = new StreamReader(file)
                  ignore <| stream.ReadLine()
                  while not stream.EndOfStream do
                    let line = stream.ReadLine()
                    let neighbors = String.filter (fun x -> x <> '0')
                                    <| String.mapi (fun i x -> if (x = '1') then (char i) else x) line
                    yield neighbors }
    
    /// shows the adjacency matrix in the console
    member this.ShowAdjList () =
        Seq.iter (fun ls -> Seq.iter (fun c -> printf "%A" c) ls
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
    


    /// returns a list of healthy computers
    member this.GetHealthyComputers () =
        Array.fold (fun acc (comp:Computer) -> if comp.IsInfected () then (comp.ID :: acc) else acc) [] computers

//    member IsUnHealthy () =
//        Seq
//            /// <summary>
//        /// checks the health of the system
//        /// </summary>
//        /// <returns>returns true, if system is unhealthy</returns>
//        public bool IsUnhealthy() => computers.Aggregate(true, (current, computer) => current && computer.IsInfected());
//
//        
//
//
//

//
//        /// <summary>
//        /// simulates the unit of time and performs changes in the system
//        /// </summary>
//        public void Step()
//        {
//            var tryInfect = new List<int>();
//            for (int i = 0; i < adjacencyList.Count; ++i)
//            {
//                if (computers[i].IsInfected())
//                {
//                    foreach (var neighbors in adjacencyList[i])
//                    {
//                        tryInfect.AddRange(adjacencyList[i]);
//                    }
//                }
//            }
//
//            var randomDamage = new Random().Next(100);
//            foreach (var num in tryInfect)
//            {
//                computers[num].Infect(randomDamage);
//            }
//        }
//

//    }
//}