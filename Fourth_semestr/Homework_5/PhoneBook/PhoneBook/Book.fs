module Book

open System.IO

let read fn =
    seq { use input = File.OpenText fn in
          while not input.EndOfStream do
            yield input.ReadLine() }   

let findByName name path =
    let records =
        seq { use reader = new StreamReader(File.OpenRead path)
              while not reader.EndOfStream do
                let record = reader.ReadLine().Split()
                yield (record.[0], record.[1]) }
    let record = Seq.tryFind (fun (x, y) -> name = x) records
    match record with
    | Some (name, num) -> num
    | None -> "There is no person with such name"

let findByNumber number path =
    let records =
        seq { use reader = new StreamReader(File.OpenRead path)
              while not reader.EndOfStream do
                let record = reader.ReadLine().Split()
                yield (record.[0], record.[1]) }
    let record = Seq.tryFind (fun (x, y) -> number = y) records
    match record with
    | Some (name, num) -> name
    | None -> "There is no person with such a telephone number"

let print path =
    let data = Seq.readonly <| read path
    Seq.iter (fun elem -> printfn "%A" elem) data

let save buffer path =
    let tosave = Seq.fold (fun acc (x, y) -> (x + " " + y) :: acc  ) [] <| Seq.distinct buffer
    File.AppendAllLines (path, tosave)

let rec dialog (buffer : list<string * string>) path =
    printfn "Enter the command"
    printfn "1 - exit"
    printfn "2 - add record"
    printfn "3 - find phone number by name"
    printfn "4 - find name by phone number"
    printfn "5 - print all data from file"
    printfn "6 - save current data to a file"

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
           let number = findByName name path
           printfn "%s" number
           dialog buffer path
    | 4 -> printfn "Enter the number, please"
           let number = System.Console.ReadLine()
           let name = findByNumber number path
           printfn "%s" name
           dialog buffer path
    | 5 -> print path
           dialog buffer path
    | 6 -> save buffer path
           dialog [] path
    | _ -> printfn "Invalid query or non-existent command"


dialog [] "..\..\Book.txt"