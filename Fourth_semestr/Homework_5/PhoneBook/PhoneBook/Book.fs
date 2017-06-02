module Book

open System.IO

let read path =
        seq { use reader = new StreamReader(File.OpenRead path)
              while not reader.EndOfStream do
                let record = reader.ReadLine().Split()
                yield (record.[0], record.[1]) }    

let rec dialog (buffer : list<string * string>) path =
    printfn "Enter the command"
    printfn "1 - exit"
    printfn "2 - add record"
    printfn "3 - find phone number by name"
    printfn "4 - find name by phone number"
    printfn "5 - print all data from file"
    printfn "6 - save current data to a file"
    printfn "7 - read data from file"

    let command = System.Console.ReadLine()
    let cmd =
        try
            int command
        with
        | :? System.FormatException as ex -> 0

    match cmd with
    | 1 -> printfn "By!!!"
    | 2 -> printfn "Enter the name, please"
           let name = System.Console.ReadLine()
           printfn "Enter the number, please"
           let number = System.Console.ReadLine()
           dialog ((name, number)::buffer) (path)
    | 3 -> printfn "Enter the name, please"
           let name = System.Console.ReadLine()
           let record = Seq.tryFind (fun (x, y) -> name = x) buffer
           match record with
           | Some (name, num) -> printfn "%s" num
           | None -> printfn "There is no person with such name"
           dialog buffer path
    | 4 -> printfn "Enter the number, please"
           let number = System.Console.ReadLine()
           let record = Seq.tryFind (fun (x, y) -> number = y) buffer
           match record with
           | Some (name, num) -> printfn "%s" name
           | None -> printfn "There is no person with such a telephone number"
           dialog buffer path
    | 5 -> printfn "All records"
           Seq.iter (fun elem -> printfn "%A" elem) buffer
           dialog buffer path
    | 6 -> let tosave = Seq.fold (fun acc (x, y) -> (x + " " + y) :: acc  ) [] <| Seq.distinct buffer
           File.AppendAllLines (path, tosave)
           dialog buffer path
    | 7 ->
        try
            let newBuffer = Seq.toList <| read path
            dialog newBuffer path
        with
        | :? FileNotFoundException -> printfn "file not found"
                                      dialog buffer path
    | _ -> printfn "Invalid query or non-existent command"


dialog [] "..\..\Book.txt"