let printList list = List.fold(fun acc elem -> printfn "%A" elem) () list

let rec createList list m acc =
    if m < 0 then
        list
    else
        createList
            (acc :: list)
            (m - 1)
            (acc <<< 1)



//let create n m = let powerOf2 = (2 <<< n)
//                 List.map(fun i -> i * powerOf2) (List.rev (createList [] m 1))

let create n m = let powerOf2 = (2 <<< (n - 1))
                 List.fold(fun acc elem -> elem * powerOf2 :: acc) [] (createList [] m 1)

[<EntryPoint>] 
let main argv = 
    printList(create 1 10)
    0 // возвращение целочисленного кода выхода
