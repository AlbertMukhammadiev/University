module program

open Book

//System.IO.Directory.SetCurrentDirectory "C:\Users\Альберт\Documents\GitHub\University\Fourth_semestr\Homework_5\PhoneBook\PhoneBook"

let rec dialog () =
    printfn "%A" "Enter the command"
    let query = System.Console.ReadLine()
    match query with
    | "exit"           -> printfn "%A" "By!!!"
    | "add"            -> printfn "%A" "Enter the name, please"
                          let name = System.Console.ReadLine()
                          printfn "%A" "Enter the number, please"
                          let number = System.Console.ReadLine()
                          add (name, number)
                          dialog ()
    | "find by name"   -> printfn "%A" "Enter the name, please"
                          let name = System.Console.ReadLine()
                          let number = findByName (name)
                          printfn "%A" number
                          dialog ()
    | "find by number" -> printfn "%A" "Enter the number, please"
                          let number = System.Console.ReadLine()
                          let name = findByNumber (number)
                          printfn "%A" name
                          dialog ()
    | "print all"      -> print ()
                          dialog ()
    | "save"           -> save ()
                          dialog ()
    | "read from file" -> read ()
                          dialog ()
    | _                -> printfn "%A" "incorrect command"
                          dialog ()

[<EntryPoint>]
let main argv = 
    dialog ()
    0 // возвращение целочисленного кода выхода
