module Book

open System.IO

type Record = { Name : string; PhoneNumber : string }

let path = "C:\Users\Альберт\Documents\GitHub\University\Fourth_semestr\Homework_5\PhoneBook\PhoneBook\Book.txt"

let mutable records = Seq.empty

let mutable buffer = List.empty

let read () =
    records <-
    seq { use reader = new StreamReader(File.OpenRead path)
          while not reader.EndOfStream do
            let record = reader.ReadLine().Split()
            yield (record.[0], record.[1]) }

let read2 fn =
    seq { use input = File.OpenText fn in
          while not input.EndOfStream do
            yield input.ReadLine() }   
            
let add (x : string, y : string) =
    buffer <- (x, y) :: buffer

let findByName name =
    let record = Seq.tryFind (fun (x, y) -> name = x) records
    match record with
    | Some (name, num) -> num
    | None -> "There is no person with such name"

let findByNumber number =
    let record = Seq.tryFind (fun (x, y) -> number = y) records
    match record with
    | Some (name, num) -> name
    | None -> "There is no person with such a telephone number"

let print () =
    let data = Seq.readonly <| read2 path
    Seq.iter (fun elem -> printfn "%A" elem) data

let save () =
    let tosave = Seq.fold (fun acc (x, y) -> (x + " " + y) :: acc  ) [] <| Seq.distinct buffer
    buffer <- List.empty
    File.AppendAllLines (path, tosave)